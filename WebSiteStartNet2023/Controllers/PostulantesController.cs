using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;
using WebSiteStartNet2023.Models.ModelView;

namespace WebSiteStartNet2023.Controllers
{
    public class PostulantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostulantesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Postulantes
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Postulantes.Include(p => p.Localidad);
            //return View(await applicationDbContext.ToListAsync());
            var lista = await _context.Postulantes
                .Select(p => new PostulanteIndexVM
                {
                    Postulante = p,
                    NombreIdioma = p.IdiomasPostulantes
                        .Where(ip => ip.PostulanteId == p.Id)
                        .Select(ip => ip.Idioma.Nombre)
                        .FirstOrDefault(),
                    NombreTecnologia = p.TecnologiasPostulantes.Where(tp => tp.PostulanteId == p.Id)
                        .Select(tp => tp.Tecnologia.Nombre)
                        .FirstOrDefault(),
                    NombreNivelConocimiento = p.TecnologiasPostulantes.Where(tp => tp.PostulanteId == p.Id)
                    .Select(tp => tp.NivelConocimiento.Nombre).FirstOrDefault(),
                    NombreNivelOral = p.IdiomasPostulantes.Where(ip => ip.PostulanteId == p.Id).Select(x => x.NivelOral.Nombre).FirstOrDefault(),
                    NombreNivelEscritura = p.IdiomasPostulantes.Where(ip => ip.PostulanteId == p.Id).Select(x => x.NivelEscritura.Nombre).FirstOrDefault(),
                    NombreNivelLectura = p.IdiomasPostulantes.Where(ip => ip.PostulanteId == p.Id).Select(x => x.NivelLectura.Nombre).FirstOrDefault(),
                    NombrePuestoTrabajo = p.PuestosTrabajoPostulantes.Where(pp => pp.PostulanteId == p.Id)
                    .Select(pp => pp.PuestoTrabajo.Nombre).FirstOrDefault(),
                    NombreExperienciaTrabajo = p.PuestosTrabajoPostulantes.Where(pp => pp.PostulanteId == p.Id)
                    .Select(pp => pp.ExperienciaTrabajo.Nombre).FirstOrDefault(),
                    NombreLocalidadPostulante = p.Localidad.Nombre
                })
                .ToListAsync();

            return View(lista);
        }

        // GET: Postulantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postulantes == null)
            {
                return NotFound();
            }

            var postulante = await _context.Postulantes
                .Include(p => p.Localidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postulante == null)
            {
                return NotFound();
            }

            return View(postulante);
        }

        // GET: Postulantes/Create
        public IActionResult Create()
        {
            //ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id");
            ViewBag.Provincias = _context.Provincias.ToList();
            ViewBag.Tecnologias = _context.Tecnologias.ToList();
            ViewBag.NivelesConocimiento = _context.NivelesConocimiento.ToList();
            ViewBag.Idiomas = _context.Idiomas.ToList();
            ViewBag.NivelesOral = _context.NivelOral.ToList();
            ViewBag.NivelesEscritura = _context.NivelEscrito.ToList();
            ViewBag.NivelesLectura = _context.NivelLectura.ToList();
            ViewBag.PuestosTrabajo = _context.PuestoTrabajos.ToList();
            ViewBag.ExperienciasTrabajo = _context.ExperienciasTrabajo.ToList();
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostulanteCreateVM postulanteCreate)
        {
            ModelState.Remove("Postulante.Localidad");
            ModelState.Remove("Tecnologia");
            ModelState.Remove("NivelConocimiento");
            ModelState.Remove("Idioma");
            ModelState.Remove("NivelOral");
            ModelState.Remove("NivelEscritura");
            ModelState.Remove("NivelLectura");
            ModelState.Remove("PuestoTrabajos");
            ModelState.Remove("ExperienciaTrabajos");

            if (!ModelState.IsValid)
                return View(postulanteCreate);

            if (postulanteCreate.Postulante.ArchivoCVFile != null && postulanteCreate.Postulante.ArchivoCVFile.Length > 0)
            {
                #region Alta de Postulante y archivo CV
                string carpetaCV = Path.Combine(_webHostEnvironment.WebRootPath, "CVs");
                if (!Directory.Exists(carpetaCV))
                {
                    Directory.CreateDirectory(carpetaCV);
                }

                string extension = Path.GetExtension(postulanteCreate.Postulante.ArchivoCVFile.FileName);
                string fechaHoy = DateTime.Now.ToString("yyyyMMdd");
                string nombreArchivo = $"{postulanteCreate.Postulante.Nombre}_{postulanteCreate.Postulante.Apellido}_{fechaHoy}{extension}";

                //Limar caracteres invalidos
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    nombreArchivo = nombreArchivo.Replace(c.ToString(), "");
                }

                string rutaFinal = Path.Combine(carpetaCV, nombreArchivo);

                using (var stream = new FileStream(rutaFinal, FileMode.Create))
                {
                    await postulanteCreate.Postulante.ArchivoCVFile.CopyToAsync(stream);
                }

                postulanteCreate.Postulante.ArchivoCV = nombreArchivo;
                postulanteCreate.Postulante.FechaAlta = DateTime.Now;
                postulanteCreate.Postulante.FechaNacimiento = postulanteCreate.Postulante.FechaNacimiento.Date;
                _context.Add(postulanteCreate.Postulante);
                await _context.SaveChangesAsync();

                #endregion

                #region Alta de tecnologias postulante 

                var tecnologia = new TecnologiaPostulante
                {
                    PostulanteId = postulanteCreate.Postulante.Id,
                    TecnologiaId = postulanteCreate.TecnologiaId,
                    NivelConocimientoId = postulanteCreate.NivelConocimientoId
                };

                _context.TecnologiasPostulantes.Add(tecnologia);
                await _context.SaveChangesAsync();

                #endregion

                #region Alta de idiomas postulante

                var idioma = new IdiomaPostulante
                {
                    PostulanteId = postulanteCreate.Postulante.Id,
                    IdiomaId = postulanteCreate.IdiomaId,
                    NivelOralId = postulanteCreate.NivelOralId,
                    NivelEscrituraId = postulanteCreate.NivelEscrituraId,
                    NivelLecturaId = postulanteCreate.NivelLecturaId
                };

                _context.IdiomasPostulantes.Add(idioma);
                await _context.SaveChangesAsync();

                #endregion
                #region Altas de puestos trabajos posulantes
                var puestoTrabajo = new PuestoTrabajoPostulante
                {
                    PostulanteId = postulanteCreate.Postulante.Id,
                    PuestoTrabajoId = postulanteCreate.PuestoTrabajoId,
                    ExperienciaTrabajoId = postulanteCreate.ExperienciaTrabajoId
                };

                _context.PuestosTrabajoPostulantes.Add(puestoTrabajo);
                await _context.SaveChangesAsync();
                #endregion

            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Postulantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Provincias = _context.Provincias.ToList();
            if (id == null || _context.Postulantes == null)
            {
                return NotFound();
            }

            var postulante = await _context.Postulantes.FindAsync(id);
            if (postulante == null)
            {
                return NotFound();
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", postulante.LocalidadId);
            return View(postulante);
        }

        // POST: Postulantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,DNI,FechaNacimiento,LocalidadId,CodigoArea,TelefonoCelular,Email,ArchivoCV,ArchivoCVFile,FechaAlta")] Postulante postulante)
        {
            if (id != postulante.Id)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(Postulante.Localidad));

            if (ModelState.IsValid)
            {
                try
                {
                    if (postulante.ArchivoCVFile != null && postulante.ArchivoCVFile.Length > 0)
                    {
                        string carpetaCV = Path.Combine(_webHostEnvironment.WebRootPath, "CVs");
                        if (!Directory.Exists(carpetaCV))
                        {
                            Directory.CreateDirectory(carpetaCV);
                        }

                        string extension = Path.GetExtension(postulante.ArchivoCVFile.FileName);
                        string fechaHoy = DateTime.Now.ToString("yyyyMMdd");
                        string nombreArchivo = $"{postulante.Nombre}_{postulante.Apellido}_{fechaHoy}{extension}";

                        //Limar caracteres invalidos
                        foreach (char c in Path.GetInvalidFileNameChars())
                        {
                            nombreArchivo = nombreArchivo.Replace(c.ToString(), "");
                        }

                        string rutaFinal = Path.Combine(carpetaCV, nombreArchivo);

                        using (var stream = new FileStream(rutaFinal, FileMode.Create))
                        {
                            await postulante.ArchivoCVFile.CopyToAsync(stream);
                        }

                        postulante.ArchivoCV = nombreArchivo;

                        _context.Update(postulante);
                        await _context.SaveChangesAsync();

                    }
                     
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostulanteExists(postulante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", postulante.LocalidadId);
            return View(postulante);
        }

        // GET: Postulantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Postulantes == null)
            {
                return NotFound();
            }

            var postulante = await _context.Postulantes
                .Include(p => p.Localidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postulante == null)
            {
                return NotFound();
            }

            return View(postulante);
        }

        // POST: Postulantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Postulantes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Postulantes'  is null.");
            }
            var postulante = await _context.Postulantes.FindAsync(id);
            if (postulante != null)
            {
                _context.Postulantes.Remove(postulante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostulanteExists(int id)
        {
          return (_context.Postulantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

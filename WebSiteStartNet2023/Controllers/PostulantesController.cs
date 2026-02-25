using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index(int? tecnologiaId)
        {
            ViewBag.Tecnologias = await _context.Tecnologias.ToListAsync();

            var query = _context.Postulantes.AsQueryable();
            if (tecnologiaId.HasValue)
            {
                query = query.Where(p =>
                    p.TecnologiasPostulantes
                     .Any(tp => tp.TecnologiaId == tecnologiaId.Value));
            }

            var lista = await query
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
                }).ToListAsync();

            return View(lista);
        }

        // GET: Postulantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postulantes == null)
            {
                return NotFound();
            }

            var postulante = await _context.Postulantes.Where(x => x.Id == id)
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
                }).FirstOrDefaultAsync();
            
            return View(postulante);
        }

        // GET: Postulantes/Create
        public async Task<IActionResult> Create()
        {            
            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Tecnologias = await _context.Tecnologias.ToListAsync();
            ViewBag.NivelesConocimiento = await _context.NivelesConocimiento.ToListAsync();
            ViewBag.Idiomas = await _context.Idiomas.ToListAsync();
            ViewBag.NivelesOral = await _context.NivelOral.ToListAsync();
            ViewBag.NivelesEscritura = await _context.NivelEscrito.ToListAsync();
            ViewBag.NivelesLectura = await _context.NivelLectura.ToListAsync();
            ViewBag.PuestosTrabajo = await _context.PuestoTrabajos.ToListAsync();
            ViewBag.ExperienciasTrabajo = await _context.ExperienciasTrabajo.ToListAsync();
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

            //TODO:Mejorar (quitar del modelo postulante)
            ModelState.Remove("Postulante.IdiomasPostulantes");
            ModelState.Remove("Postulante.TecnologiasPostulantes");
            ModelState.Remove("Postulante.PuestosTrabajoPostulantes");

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

            TempData["SuccessMessage"] = "Tu postulación fue enviada correctamente.";
            return RedirectToAction(nameof(Create));
        }

        // GET: Postulantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var postulantedb = await _context.Postulantes.Where(x => x.Id == id).FirstOrDefaultAsync();
            
            ViewBag.Provincias = await _context.Provincias.ToListAsync();
            ViewBag.Tecnologias = await _context.Tecnologias.ToListAsync();
            ViewBag.NivelesConocimiento = await _context.NivelesConocimiento.ToListAsync();
            ViewBag.Idiomas = await _context.Idiomas.ToListAsync();
            ViewBag.NivelesOral = await _context.NivelOral.ToListAsync();
            ViewBag.NivelesEscritura = await _context.NivelEscrito.ToListAsync();
            ViewBag.NivelesLectura = await _context.NivelLectura.ToListAsync();
            ViewBag.PuestosTrabajo = await _context.PuestoTrabajos.ToListAsync();
            ViewBag.ExperienciasTrabajo = await _context.ExperienciasTrabajo.ToListAsync();

            if (id == null || postulantedb == null)
            {
                return NotFound();
            } else
            {
                return View(new PostulanteEditarVM
                {
                    Postulante = postulantedb
                });
            }
        }

        // POST: Postulantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PostulanteEditarVM postulanteEditarVM)
        {
            var postulante = await _context.Postulantes.Where(x => x.Id == postulanteEditarVM.Id).FirstOrDefaultAsync();

            if ( postulante == null)
            {
                ViewBag.Provincias = await _context.Provincias.ToListAsync();
                ViewBag.Tecnologias = await _context.Tecnologias.ToListAsync();
                ViewBag.NivelesConocimiento = await _context.NivelesConocimiento.ToListAsync();
                ViewBag.Idiomas = await _context.Idiomas.ToListAsync();
                ViewBag.NivelesOral = await _context.NivelOral.ToListAsync();
                ViewBag.NivelesEscritura = await _context.NivelEscrito.ToListAsync();
                ViewBag.NivelesLectura = await _context.NivelLectura.ToListAsync();
                ViewBag.PuestosTrabajo = await _context.PuestoTrabajos.ToListAsync();
                ViewBag.ExperienciasTrabajo = await _context.ExperienciasTrabajo.ToListAsync();
                return NotFound();
            }

            ModelState.Remove("Postulante.Localidad");
            ModelState.Remove("Tecnologia");
            ModelState.Remove("NivelConocimiento");
            ModelState.Remove("Idioma");
            ModelState.Remove("NivelOral");
            ModelState.Remove("NivelEscritura");
            ModelState.Remove("NivelLectura");
            ModelState.Remove("PuestoTrabajos");
            ModelState.Remove("ExperienciaTrabajos");

            //TODO:Mejorar (quitar del modelo postulante)
            ModelState.Remove("Postulante.IdiomasPostulantes");
            ModelState.Remove("Postulante.TecnologiasPostulantes");
            ModelState.Remove("Postulante.PuestosTrabajoPostulantes");

            if (ModelState.IsValid)
            {
                try
                {
                    if (postulanteEditarVM.Postulante.ArchivoCVFile != null && postulanteEditarVM.Postulante.ArchivoCVFile.Length > 0)
                    {
                        string carpetaCV = Path.Combine(_webHostEnvironment.WebRootPath, "CVs");
                        if (!Directory.Exists(carpetaCV))
                        {
                            Directory.CreateDirectory(carpetaCV);
                        }

                        string extension = Path.GetExtension(postulanteEditarVM.Postulante.ArchivoCVFile.FileName);
                        string fechaHoy = DateTime.Now.ToString("yyyyMMdd");
                        string nombreArchivo = $"{postulanteEditarVM.Postulante.Nombre}_{postulanteEditarVM.Postulante.Apellido}_{fechaHoy}{extension}";

                        //Limar caracteres invalidos
                        foreach (char c in Path.GetInvalidFileNameChars())
                        {
                            nombreArchivo = nombreArchivo.Replace(c.ToString(), "");
                        }

                        string rutaFinal = Path.Combine(carpetaCV, nombreArchivo);

                        using (var stream = new FileStream(rutaFinal, FileMode.Create))
                        {
                            await postulanteEditarVM.Postulante.ArchivoCVFile.CopyToAsync(stream);
                        }

                        postulanteEditarVM.Postulante.ArchivoCV = nombreArchivo;

                        _context.Postulantes.Update(postulante);
                        await _context.SaveChangesAsync();

                        #region Modificar tecnologias postulante 

                        var tec = await _context.TecnologiasPostulantes.Where(x => x.PostulanteId == postulanteEditarVM.Id).FirstOrDefaultAsync();

                        if (tec == null)
                        {
                            var tecnologia = new TecnologiaPostulante
                            {
                                PostulanteId = postulanteEditarVM.Postulante.Id,
                                TecnologiaId = postulanteEditarVM.TecnologiaId,
                                NivelConocimientoId = postulanteEditarVM.NivelConocimientoId
                            };
                            _context.TecnologiasPostulantes.Add(tecnologia);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            tec.TecnologiaId = postulanteEditarVM.TecnologiaId;
                            tec.NivelConocimientoId = postulanteEditarVM.NivelConocimientoId;
                            _context.TecnologiasPostulantes.Update(tec);
                            await _context.SaveChangesAsync();
                        }

                        #endregion

                        #region Modificar idiomas postulante
                        var Idio = await _context.IdiomasPostulantes.Where(x => x.PostulanteId == postulanteEditarVM.Id).FirstOrDefaultAsync();
                        if (Idio == null)
                        {
                            var idioma = new IdiomaPostulante
                            {
                                PostulanteId = postulanteEditarVM.Postulante.Id,
                                IdiomaId = postulanteEditarVM.IdiomaId,
                                NivelOralId = postulanteEditarVM.NivelOralId,
                                NivelEscrituraId = postulanteEditarVM.NivelEscrituraId,
                                NivelLecturaId = postulanteEditarVM.NivelLecturaId
                            };
                            _context.IdiomasPostulantes.Add(idioma);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            Idio.IdiomaId = postulanteEditarVM.IdiomaId;
                            Idio.NivelOralId = postulanteEditarVM.NivelOralId;
                            Idio.NivelEscrituraId = postulanteEditarVM.NivelEscrituraId;
                            Idio.NivelLecturaId = postulanteEditarVM.NivelLecturaId;
                            _context.IdiomasPostulantes.Update(Idio);
                            await _context.SaveChangesAsync();
                        }
                        #endregion

                        #region Modificar puestos trabajos posulantes

                        var Puest = await _context.PuestosTrabajoPostulantes.Where(x => x.PostulanteId == postulanteEditarVM.Id).FirstOrDefaultAsync();
                        
                        if (Puest == null)
                        {
                            var puestoTrabajo = new PuestoTrabajoPostulante
                            {
                                PostulanteId = postulanteEditarVM.Postulante.Id,
                                PuestoTrabajoId = postulanteEditarVM.PuestoTrabajoId,
                                ExperienciaTrabajoId = postulanteEditarVM.ExperienciaTrabajoId
                            };
                            _context.PuestosTrabajoPostulantes.Add(puestoTrabajo);
                            await _context.SaveChangesAsync();

                        }
                        else
                        {
                            Puest.PuestoTrabajoId = postulanteEditarVM.PuestoTrabajoId;
                            Puest.ExperienciaTrabajoId = postulanteEditarVM.ExperienciaTrabajoId;
                            _context.PuestosTrabajoPostulantes.Update(Puest);
                            await _context.SaveChangesAsync();                            
                        }
                        #endregion
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

                TempData["SuccessMessage"] = "La postulación fue modificada correctamente.";
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                ViewBag.Provincias = await _context.Provincias.ToListAsync();
                ViewBag.Tecnologias = await _context.Tecnologias.ToListAsync();
                ViewBag.NivelesConocimiento = await _context.NivelesConocimiento.ToListAsync();
                ViewBag.Idiomas = await _context.Idiomas.ToListAsync();
                ViewBag.NivelesOral = await _context.NivelOral.ToListAsync();
                ViewBag.NivelesEscritura = await _context.NivelEscrito.ToListAsync();
                ViewBag.NivelesLectura = await _context.NivelLectura.ToListAsync();
                ViewBag.PuestosTrabajo = await _context.PuestoTrabajos.ToListAsync();
                ViewBag.ExperienciasTrabajo = await _context.ExperienciasTrabajo.ToListAsync();
            }            
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

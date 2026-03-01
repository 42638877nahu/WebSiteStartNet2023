using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;
using WebSiteStartNet2023.Models.ModelView;

namespace WebSiteStartNet2023.Controllers
{
    public class PostulantesPublicController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostulantesPublicController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

        #region obtener Localidades por provincias (ajax)

        [HttpGet]
        public IActionResult GetLocalidades(int ProvinciaId)
        {

            var Localidades = _context.Localidades.Where(x => x.ProvinciaId == ProvinciaId).ToList();
            return Json(Localidades);
        }

        #endregion
    }
}

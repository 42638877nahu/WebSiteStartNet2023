using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.Areas.ContentAdmin.Controllers
{
    [Area("ContentAdmin")]
    [Authorize(Roles = "Admin")]
    public class ServiciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentAdmin/Servicios
        public async Task<IActionResult> Index()
        {
            return _context.Servicios != null ?
                        View(await _context.Servicios.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Servicios'  is null.");
        }

        // GET: ContentAdmin/Servicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // GET: ContentAdmin/Servicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentAdmin/Servicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,NombreSlider,FotoSlider,Detalle,Fecha,NombreHome,FotoHome")] Servicio servicio)
        {
            if (servicio.FotoSlider != null)
            {
                servicio.NombreSlider = Path.GetFileName(servicio.FotoSlider.FileName);
            }

            if (servicio.FotoHome != null)
            {
                servicio.NombreHome = Path.GetFileName(servicio.FotoHome.FileName);
            }

            servicio.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (servicio.FotoSlider != null)
                {
                    string _path = $"Data/Imagenes/Servicios/" + servicio.NombreSlider;

                    using (FileStream fs = System.IO.File.Create(_path))
                    {
                        servicio.FotoSlider.CopyTo(fs);
                    }
                }

                if (servicio.FotoHome != null)
                {
                    string _path = $"Data/Imagenes/Servicios/" + servicio.NombreHome;

                    using (FileStream fs = System.IO.File.Create(_path))
                    {
                        servicio.FotoHome.CopyTo(fs);
                    }
                }

                _context.Add(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }
            return View(servicio);
        }

        // GET: ContentAdmin/Servicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return View(servicio);
        }

        // POST: ContentAdmin/Servicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,NombreSlider,FotoSlider,Detalle,Fecha,NombreHome,FotoHome")] Servicio servicio)
        {
            if (id != servicio.Id)
            {
                return NotFound();
            }

            if (servicio.FotoSlider != null)
            {
                servicio.NombreSlider = Path.GetFileName(servicio.FotoSlider.FileName);
            }

            if (servicio.FotoHome != null)
            {
                servicio.NombreHome = Path.GetFileName(servicio.FotoHome.FileName);
            }

            servicio.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    if (servicio.FotoSlider != null)
                    {
                        string _path = $"Data/Imagenes/Servicios/" + servicio.NombreSlider;

                        using (FileStream fs = System.IO.File.Create(_path))
                        {
                            servicio.FotoSlider.CopyTo(fs);
                        }
                    }

                    if (servicio.FotoHome != null)
                    {
                        string _path = $"Data/Imagenes/Servicios/" + servicio.NombreHome;

                        using (FileStream fs = System.IO.File.Create(_path))
                        {
                            servicio.FotoHome.CopyTo(fs);
                        }
                    }

                    _context.Update(servicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioExists(servicio.Id))
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
            return View(servicio);
        }

        // GET: ContentAdmin/Servicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: ContentAdmin/Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Servicios'  is null.");
            }
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioExists(int id)
        {
            return (_context.Servicios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

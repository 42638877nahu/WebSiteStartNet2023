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
    public class NovedadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NovedadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentAdmin/Novedades
        public async Task<IActionResult> Index()
        {
              return _context.Novedades != null ? 
                          View(await _context.Novedades.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Novedades'  is null.");
        }

        // GET: ContentAdmin/Novedades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Novedades == null)
            {
                return NotFound();
            }

            var novedad = await _context.Novedades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novedad == null)
            {
                return NotFound();
            }

            return View(novedad);
        }

        // GET: ContentAdmin/Novedades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentAdmin/Novedades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Titulo,Detalle,Descripcion,NombreFoto,Foto")] Novedad novedad)
        {
            if (novedad.Foto != null)
            {
                novedad.NombreFoto = Path.GetFileName(novedad.Foto.FileName);
            }

            if (ModelState.IsValid)
            {
                if (novedad.Foto != null)
                {
                    string _path = $"Data/Imagenes/Novedades/" + novedad.NombreFoto;

                    using (FileStream fs = System.IO.File.Create(_path))
                    {
                        novedad.Foto.CopyTo(fs);
                    }
                }

                _context.Add(novedad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(novedad);
        }

        // GET: ContentAdmin/Novedades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Novedades == null)
            {
                return NotFound();
            }

            var novedad = await _context.Novedades.FindAsync(id);
            if (novedad == null)
            {
                return NotFound();
            }
            return View(novedad);
        }

        // POST: ContentAdmin/Novedades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Titulo,Detalle,Descripcion,NombreFoto,Foto")] Novedad novedad)
        {
            if (id != novedad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (novedad.Foto != null)
                    {
                        novedad.NombreFoto = Path.GetFileName(novedad.Foto.FileName);
                    }

                    if (novedad.Foto != null)
                    {
                        string _path = $"Data/Imagenes/Novedades/" + novedad.NombreFoto;

                        using (FileStream fs = System.IO.File.Create(_path))
                        {
                            novedad.Foto.CopyTo(fs);
                        }
                    }

                    _context.Update(novedad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovedadExists(novedad.Id))
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
            return View(novedad);
        }

        // GET: ContentAdmin/Novedades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Novedades == null)
            {
                return NotFound();
            }

            var novedad = await _context.Novedades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novedad == null)
            {
                return NotFound();
            }

            return View(novedad);
        }

        // POST: ContentAdmin/Novedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Novedades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Novedades'  is null.");
            }
            var novedad = await _context.Novedades.FindAsync(id);
            if (novedad != null)
            {
                _context.Novedades.Remove(novedad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovedadExists(int id)
        {
          return (_context.Novedades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.Controllers
{
    public class TecnologiaPostulantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TecnologiaPostulantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TecnologiaPostulantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TecnologiasPostulantes.Include(t => t.NivelConocimiento).Include(t => t.Postulante).Include(t => t.Tecnologia);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TecnologiaPostulantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TecnologiasPostulantes == null)
            {
                return NotFound();
            }

            var tecnologiaPostulante = await _context.TecnologiasPostulantes
                .Include(t => t.NivelConocimiento)
                .Include(t => t.Postulante)
                .Include(t => t.Tecnologia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologiaPostulante == null)
            {
                return NotFound();
            }

            return View(tecnologiaPostulante);
        }

        // GET: TecnologiaPostulantes/Create
        public IActionResult Create()
        {
            ViewData["NivelConocimientoId"] = new SelectList(_context.NivelesConocimiento, "Id", "Id");
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido");
            ViewData["TecnologiaId"] = new SelectList(_context.Tecnologias, "Id", "Id");
            return View();
        }

        // POST: TecnologiaPostulantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostulanteId,TecnologiaId,NivelConocimientoId")] TecnologiaPostulante tecnologiaPostulante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnologiaPostulante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NivelConocimientoId"] = new SelectList(_context.NivelesConocimiento, "Id", "Id", tecnologiaPostulante.NivelConocimientoId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", tecnologiaPostulante.PostulanteId);
            ViewData["TecnologiaId"] = new SelectList(_context.Tecnologias, "Id", "Id", tecnologiaPostulante.TecnologiaId);
            return View(tecnologiaPostulante);
        }

        // GET: TecnologiaPostulantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TecnologiasPostulantes == null)
            {
                return NotFound();
            }

            var tecnologiaPostulante = await _context.TecnologiasPostulantes.FindAsync(id);
            if (tecnologiaPostulante == null)
            {
                return NotFound();
            }
            ViewData["NivelConocimientoId"] = new SelectList(_context.NivelesConocimiento, "Id", "Id", tecnologiaPostulante.NivelConocimientoId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", tecnologiaPostulante.PostulanteId);
            ViewData["TecnologiaId"] = new SelectList(_context.Tecnologias, "Id", "Id", tecnologiaPostulante.TecnologiaId);
            return View(tecnologiaPostulante);
        }

        // POST: TecnologiaPostulantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostulanteId,TecnologiaId,NivelConocimientoId")] TecnologiaPostulante tecnologiaPostulante)
        {
            if (id != tecnologiaPostulante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnologiaPostulante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnologiaPostulanteExists(tecnologiaPostulante.Id))
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
            ViewData["NivelConocimientoId"] = new SelectList(_context.NivelesConocimiento, "Id", "Id", tecnologiaPostulante.NivelConocimientoId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", tecnologiaPostulante.PostulanteId);
            ViewData["TecnologiaId"] = new SelectList(_context.Tecnologias, "Id", "Id", tecnologiaPostulante.TecnologiaId);
            return View(tecnologiaPostulante);
        }

        // GET: TecnologiaPostulantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TecnologiasPostulantes == null)
            {
                return NotFound();
            }

            var tecnologiaPostulante = await _context.TecnologiasPostulantes
                .Include(t => t.NivelConocimiento)
                .Include(t => t.Postulante)
                .Include(t => t.Tecnologia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologiaPostulante == null)
            {
                return NotFound();
            }

            return View(tecnologiaPostulante);
        }

        // POST: TecnologiaPostulantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TecnologiasPostulantes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TecnologiasPostulantes'  is null.");
            }
            var tecnologiaPostulante = await _context.TecnologiasPostulantes.FindAsync(id);
            if (tecnologiaPostulante != null)
            {
                _context.TecnologiasPostulantes.Remove(tecnologiaPostulante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnologiaPostulanteExists(int id)
        {
          return (_context.TecnologiasPostulantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

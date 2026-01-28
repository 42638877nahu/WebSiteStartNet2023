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
    public class IdiomaPostulantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdiomaPostulantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IdiomaPostulantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.IdiomasPostulantes.Include(i => i.Idioma).Include(i => i.Postulante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: IdiomaPostulantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IdiomasPostulantes == null)
            {
                return NotFound();
            }

            var idiomaPostulante = await _context.IdiomasPostulantes
                .Include(i => i.Idioma)
                .Include(i => i.Postulante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomaPostulante == null)
            {
                return NotFound();
            }

            return View(idiomaPostulante);
        }

        // GET: IdiomaPostulantes/Create
        public IActionResult Create()
        {
            ViewData["IdiomaId"] = new SelectList(_context.Idiomas, "Id", "Id");
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido");
            return View();
        }

        // POST: IdiomaPostulantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostulanteId,IdiomaId,NivelOralId,NivelEscrituraId,NivelLecturaId")] IdiomaPostulante idiomaPostulante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idiomaPostulante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdiomaId"] = new SelectList(_context.Idiomas, "Id", "Id", idiomaPostulante.IdiomaId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", idiomaPostulante.PostulanteId);
            return View(idiomaPostulante);
        }

        // GET: IdiomaPostulantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IdiomasPostulantes == null)
            {
                return NotFound();
            }

            var idiomaPostulante = await _context.IdiomasPostulantes.FindAsync(id);
            if (idiomaPostulante == null)
            {
                return NotFound();
            }
            ViewData["IdiomaId"] = new SelectList(_context.Idiomas, "Id", "Id", idiomaPostulante.IdiomaId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", idiomaPostulante.PostulanteId);
            return View(idiomaPostulante);
        }

        // POST: IdiomaPostulantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostulanteId,IdiomaId,NivelOralId,NivelEscrituraId,NivelLecturaId")] IdiomaPostulante idiomaPostulante)
        {
            if (id != idiomaPostulante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idiomaPostulante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomaPostulanteExists(idiomaPostulante.Id))
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
            ViewData["IdiomaId"] = new SelectList(_context.Idiomas, "Id", "Id", idiomaPostulante.IdiomaId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", idiomaPostulante.PostulanteId);
            return View(idiomaPostulante);
        }

        // GET: IdiomaPostulantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IdiomasPostulantes == null)
            {
                return NotFound();
            }

            var idiomaPostulante = await _context.IdiomasPostulantes
                .Include(i => i.Idioma)
                .Include(i => i.Postulante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomaPostulante == null)
            {
                return NotFound();
            }

            return View(idiomaPostulante);
        }

        // POST: IdiomaPostulantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IdiomasPostulantes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.IdiomasPostulantes'  is null.");
            }
            var idiomaPostulante = await _context.IdiomasPostulantes.FindAsync(id);
            if (idiomaPostulante != null)
            {
                _context.IdiomasPostulantes.Remove(idiomaPostulante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdiomaPostulanteExists(int id)
        {
          return (_context.IdiomasPostulantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

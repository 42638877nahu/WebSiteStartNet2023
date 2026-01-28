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
    public class NivelConocimientoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NivelConocimientoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NivelConocimientoes
        public async Task<IActionResult> Index()
        {
              return _context.NivelesConocimiento != null ? 
                          View(await _context.NivelesConocimiento.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NivelesConocimiento'  is null.");
        }

        // GET: NivelConocimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NivelesConocimiento == null)
            {
                return NotFound();
            }

            var nivelConocimiento = await _context.NivelesConocimiento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelConocimiento == null)
            {
                return NotFound();
            }

            return View(nivelConocimiento);
        }

        // GET: NivelConocimientoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelConocimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] NivelConocimiento nivelConocimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelConocimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelConocimiento);
        }

        // GET: NivelConocimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NivelesConocimiento == null)
            {
                return NotFound();
            }

            var nivelConocimiento = await _context.NivelesConocimiento.FindAsync(id);
            if (nivelConocimiento == null)
            {
                return NotFound();
            }
            return View(nivelConocimiento);
        }

        // POST: NivelConocimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] NivelConocimiento nivelConocimiento)
        {
            if (id != nivelConocimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelConocimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelConocimientoExists(nivelConocimiento.Id))
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
            return View(nivelConocimiento);
        }

        // GET: NivelConocimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NivelesConocimiento == null)
            {
                return NotFound();
            }

            var nivelConocimiento = await _context.NivelesConocimiento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelConocimiento == null)
            {
                return NotFound();
            }

            return View(nivelConocimiento);
        }

        // POST: NivelConocimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NivelesConocimiento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NivelesConocimiento'  is null.");
            }
            var nivelConocimiento = await _context.NivelesConocimiento.FindAsync(id);
            if (nivelConocimiento != null)
            {
                _context.NivelesConocimiento.Remove(nivelConocimiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelConocimientoExists(int id)
        {
          return (_context.NivelesConocimiento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class NivelLecturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NivelLecturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NivelLectura
        public async Task<IActionResult> Index()
        {
              return _context.NivelLectura != null ? 
                          View(await _context.NivelLectura.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NivelLectura'  is null.");
        }

        // GET: NivelLectura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NivelLectura == null)
            {
                return NotFound();
            }

            var nivelLectura = await _context.NivelLectura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelLectura == null)
            {
                return NotFound();
            }

            return View(nivelLectura);
        }

        // GET: NivelLectura/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelLectura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] NivelLectura nivelLectura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelLectura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelLectura);
        }

        // GET: NivelLectura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NivelLectura == null)
            {
                return NotFound();
            }

            var nivelLectura = await _context.NivelLectura.FindAsync(id);
            if (nivelLectura == null)
            {
                return NotFound();
            }
            return View(nivelLectura);
        }

        // POST: NivelLectura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] NivelLectura nivelLectura)
        {
            if (id != nivelLectura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelLectura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelLecturaExists(nivelLectura.Id))
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
            return View(nivelLectura);
        }

        // GET: NivelLectura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NivelLectura == null)
            {
                return NotFound();
            }

            var nivelLectura = await _context.NivelLectura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelLectura == null)
            {
                return NotFound();
            }

            return View(nivelLectura);
        }

        // POST: NivelLectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NivelLectura == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NivelLectura'  is null.");
            }
            var nivelLectura = await _context.NivelLectura.FindAsync(id);
            if (nivelLectura != null)
            {
                _context.NivelLectura.Remove(nivelLectura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelLecturaExists(int id)
        {
          return (_context.NivelLectura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

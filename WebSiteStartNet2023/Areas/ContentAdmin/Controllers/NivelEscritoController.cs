using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.Areas.ContentAdmin.Controllers
{
    [Area("ContentAdmin")]
    [Authorize(Roles = "Admin")]
    public class NivelEscritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NivelEscritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NivelEscrito
        public async Task<IActionResult> Index()
        {
              return _context.NivelEscrito != null ? 
                          View(await _context.NivelEscrito.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NivelEscrito'  is null.");
        }

        // GET: NivelEscrito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NivelEscrito == null)
            {
                return NotFound();
            }

            var nivelEscrito = await _context.NivelEscrito
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelEscrito == null)
            {
                return NotFound();
            }

            return View(nivelEscrito);
        }

        // GET: NivelEscrito/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelEscrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] NivelEscrito nivelEscrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelEscrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelEscrito);
        }

        // GET: NivelEscrito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NivelEscrito == null)
            {
                return NotFound();
            }

            var nivelEscrito = await _context.NivelEscrito.FindAsync(id);
            if (nivelEscrito == null)
            {
                return NotFound();
            }
            return View(nivelEscrito);
        }

        // POST: NivelEscrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] NivelEscrito nivelEscrito)
        {
            if (id != nivelEscrito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelEscrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelEscritoExists(nivelEscrito.Id))
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
            return View(nivelEscrito);
        }

        // GET: NivelEscrito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NivelEscrito == null)
            {
                return NotFound();
            }

            var nivelEscrito = await _context.NivelEscrito
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelEscrito == null)
            {
                return NotFound();
            }

            return View(nivelEscrito);
        }

        // POST: NivelEscrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NivelEscrito == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NivelEscrito'  is null.");
            }
            var nivelEscrito = await _context.NivelEscrito.FindAsync(id);
            if (nivelEscrito != null)
            {
                _context.NivelEscrito.Remove(nivelEscrito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelEscritoExists(int id)
        {
          return (_context.NivelEscrito?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

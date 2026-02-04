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
    public class NivelOralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NivelOralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NivelOral
        public async Task<IActionResult> Index()
        {
              return _context.NivelOral != null ? 
                          View(await _context.NivelOral.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NivelOral'  is null.");
        }

        // GET: NivelOral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NivelOral == null)
            {
                return NotFound();
            }

            var nivelOral = await _context.NivelOral
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelOral == null)
            {
                return NotFound();
            }

            return View(nivelOral);
        }

        // GET: NivelOral/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelOral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] NivelOral nivelOral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelOral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelOral);
        }

        // GET: NivelOral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NivelOral == null)
            {
                return NotFound();
            }

            var nivelOral = await _context.NivelOral.FindAsync(id);
            if (nivelOral == null)
            {
                return NotFound();
            }
            return View(nivelOral);
        }

        // POST: NivelOral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] NivelOral nivelOral)
        {
            if (id != nivelOral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelOral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelOralExists(nivelOral.Id))
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
            return View(nivelOral);
        }

        // GET: NivelOral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NivelOral == null)
            {
                return NotFound();
            }

            var nivelOral = await _context.NivelOral
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelOral == null)
            {
                return NotFound();
            }

            return View(nivelOral);
        }

        // POST: NivelOral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NivelOral == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NivelOral'  is null.");
            }
            var nivelOral = await _context.NivelOral.FindAsync(id);
            if (nivelOral != null)
            {
                _context.NivelOral.Remove(nivelOral);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelOralExists(int id)
        {
          return (_context.NivelOral?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

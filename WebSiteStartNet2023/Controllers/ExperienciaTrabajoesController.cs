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
    public class ExperienciaTrabajoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperienciaTrabajoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExperienciaTrabajoes
        public async Task<IActionResult> Index()
        {
              return _context.ExperienciasTrabajo != null ? 
                          View(await _context.ExperienciasTrabajo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ExperienciasTrabajo'  is null.");
        }

        // GET: ExperienciaTrabajoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExperienciasTrabajo == null)
            {
                return NotFound();
            }

            var experienciaTrabajo = await _context.ExperienciasTrabajo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienciaTrabajo == null)
            {
                return NotFound();
            }

            return View(experienciaTrabajo);
        }

        // GET: ExperienciaTrabajoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExperienciaTrabajoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] ExperienciaTrabajo experienciaTrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienciaTrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experienciaTrabajo);
        }

        // GET: ExperienciaTrabajoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExperienciasTrabajo == null)
            {
                return NotFound();
            }

            var experienciaTrabajo = await _context.ExperienciasTrabajo.FindAsync(id);
            if (experienciaTrabajo == null)
            {
                return NotFound();
            }
            return View(experienciaTrabajo);
        }

        // POST: ExperienciaTrabajoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] ExperienciaTrabajo experienciaTrabajo)
        {
            if (id != experienciaTrabajo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienciaTrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaTrabajoExists(experienciaTrabajo.Id))
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
            return View(experienciaTrabajo);
        }

        // GET: ExperienciaTrabajoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExperienciasTrabajo == null)
            {
                return NotFound();
            }

            var experienciaTrabajo = await _context.ExperienciasTrabajo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienciaTrabajo == null)
            {
                return NotFound();
            }

            return View(experienciaTrabajo);
        }

        // POST: ExperienciaTrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExperienciasTrabajo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExperienciasTrabajo'  is null.");
            }
            var experienciaTrabajo = await _context.ExperienciasTrabajo.FindAsync(id);
            if (experienciaTrabajo != null)
            {
                _context.ExperienciasTrabajo.Remove(experienciaTrabajo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciaTrabajoExists(int id)
        {
          return (_context.ExperienciasTrabajo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

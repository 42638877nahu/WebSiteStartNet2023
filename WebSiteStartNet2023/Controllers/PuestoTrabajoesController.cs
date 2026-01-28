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
    public class PuestoTrabajoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PuestoTrabajoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PuestoTrabajoes
        public async Task<IActionResult> Index()
        {
              return _context.PuestoTrabajos != null ? 
                          View(await _context.PuestoTrabajos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PuestoTrabajos'  is null.");
        }

        // GET: PuestoTrabajoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PuestoTrabajos == null)
            {
                return NotFound();
            }

            var puestoTrabajo = await _context.PuestoTrabajos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoTrabajo == null)
            {
                return NotFound();
            }

            return View(puestoTrabajo);
        }

        // GET: PuestoTrabajoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PuestoTrabajoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] PuestoTrabajo puestoTrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestoTrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puestoTrabajo);
        }

        // GET: PuestoTrabajoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PuestoTrabajos == null)
            {
                return NotFound();
            }

            var puestoTrabajo = await _context.PuestoTrabajos.FindAsync(id);
            if (puestoTrabajo == null)
            {
                return NotFound();
            }
            return View(puestoTrabajo);
        }

        // POST: PuestoTrabajoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] PuestoTrabajo puestoTrabajo)
        {
            if (id != puestoTrabajo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestoTrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoTrabajoExists(puestoTrabajo.Id))
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
            return View(puestoTrabajo);
        }

        // GET: PuestoTrabajoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PuestoTrabajos == null)
            {
                return NotFound();
            }

            var puestoTrabajo = await _context.PuestoTrabajos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoTrabajo == null)
            {
                return NotFound();
            }

            return View(puestoTrabajo);
        }

        // POST: PuestoTrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PuestoTrabajos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PuestoTrabajos'  is null.");
            }
            var puestoTrabajo = await _context.PuestoTrabajos.FindAsync(id);
            if (puestoTrabajo != null)
            {
                _context.PuestoTrabajos.Remove(puestoTrabajo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoTrabajoExists(int id)
        {
          return (_context.PuestoTrabajos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

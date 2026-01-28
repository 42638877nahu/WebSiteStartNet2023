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
    public class PuestoTrabajoPostulantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PuestoTrabajoPostulantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PuestoTrabajoPostulantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PuestosTrabajoPostulantes.Include(p => p.ExperienciaTrabajo).Include(p => p.Postulante).Include(p => p.PuestoTrabajo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PuestoTrabajoPostulantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PuestosTrabajoPostulantes == null)
            {
                return NotFound();
            }

            var puestoTrabajoPostulante = await _context.PuestosTrabajoPostulantes
                .Include(p => p.ExperienciaTrabajo)
                .Include(p => p.Postulante)
                .Include(p => p.PuestoTrabajo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoTrabajoPostulante == null)
            {
                return NotFound();
            }

            return View(puestoTrabajoPostulante);
        }

        // GET: PuestoTrabajoPostulantes/Create
        public IActionResult Create()
        {
            ViewData["ExperienciaTrabajoId"] = new SelectList(_context.ExperienciasTrabajo, "Id", "Id");
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido");
            ViewData["PuestoTrabajoId"] = new SelectList(_context.PuestoTrabajos, "Id", "Nombre");
            return View();
        }

        // POST: PuestoTrabajoPostulantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostulanteId,PuestoTrabajoId,ExperienciaTrabajoId")] PuestoTrabajoPostulante puestoTrabajoPostulante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puestoTrabajoPostulante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExperienciaTrabajoId"] = new SelectList(_context.ExperienciasTrabajo, "Id", "Id", puestoTrabajoPostulante.ExperienciaTrabajoId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", puestoTrabajoPostulante.PostulanteId);
            ViewData["PuestoTrabajoId"] = new SelectList(_context.PuestoTrabajos, "Id", "Nombre", puestoTrabajoPostulante.PuestoTrabajoId);
            return View(puestoTrabajoPostulante);
        }

        // GET: PuestoTrabajoPostulantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PuestosTrabajoPostulantes == null)
            {
                return NotFound();
            }

            var puestoTrabajoPostulante = await _context.PuestosTrabajoPostulantes.FindAsync(id);
            if (puestoTrabajoPostulante == null)
            {
                return NotFound();
            }
            ViewData["ExperienciaTrabajoId"] = new SelectList(_context.ExperienciasTrabajo, "Id", "Id", puestoTrabajoPostulante.ExperienciaTrabajoId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", puestoTrabajoPostulante.PostulanteId);
            ViewData["PuestoTrabajoId"] = new SelectList(_context.PuestoTrabajos, "Id", "Nombre", puestoTrabajoPostulante.PuestoTrabajoId);
            return View(puestoTrabajoPostulante);
        }

        // POST: PuestoTrabajoPostulantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostulanteId,PuestoTrabajoId,ExperienciaTrabajoId")] PuestoTrabajoPostulante puestoTrabajoPostulante)
        {
            if (id != puestoTrabajoPostulante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puestoTrabajoPostulante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuestoTrabajoPostulanteExists(puestoTrabajoPostulante.Id))
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
            ViewData["ExperienciaTrabajoId"] = new SelectList(_context.ExperienciasTrabajo, "Id", "Id", puestoTrabajoPostulante.ExperienciaTrabajoId);
            ViewData["PostulanteId"] = new SelectList(_context.Postulantes, "Id", "Apellido", puestoTrabajoPostulante.PostulanteId);
            ViewData["PuestoTrabajoId"] = new SelectList(_context.PuestoTrabajos, "Id", "Nombre", puestoTrabajoPostulante.PuestoTrabajoId);
            return View(puestoTrabajoPostulante);
        }

        // GET: PuestoTrabajoPostulantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PuestosTrabajoPostulantes == null)
            {
                return NotFound();
            }

            var puestoTrabajoPostulante = await _context.PuestosTrabajoPostulantes
                .Include(p => p.ExperienciaTrabajo)
                .Include(p => p.Postulante)
                .Include(p => p.PuestoTrabajo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puestoTrabajoPostulante == null)
            {
                return NotFound();
            }

            return View(puestoTrabajoPostulante);
        }

        // POST: PuestoTrabajoPostulantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PuestosTrabajoPostulantes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PuestosTrabajoPostulantes'  is null.");
            }
            var puestoTrabajoPostulante = await _context.PuestosTrabajoPostulantes.FindAsync(id);
            if (puestoTrabajoPostulante != null)
            {
                _context.PuestosTrabajoPostulantes.Remove(puestoTrabajoPostulante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuestoTrabajoPostulanteExists(int id)
        {
          return (_context.PuestosTrabajoPostulantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

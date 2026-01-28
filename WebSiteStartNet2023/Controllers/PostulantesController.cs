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
    public class PostulantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostulantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Postulantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Postulantes.Include(p => p.Localidad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Postulantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postulantes == null)
            {
                return NotFound();
            }

            var postulante = await _context.Postulantes
                .Include(p => p.Localidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postulante == null)
            {
                return NotFound();
            }

            return View(postulante);
        }

        // GET: Postulantes/Create
        public IActionResult Create()
        {
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id");
            return View();
        }

        // POST: Postulantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,DNI,FechaNacimiento,LocalidadId,CodigoArea,TelefonoCelular,Email,ArchivoCV,FechaAlta")] Postulante postulante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postulante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", postulante.LocalidadId);
            return View(postulante);
        }

        // GET: Postulantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Postulantes == null)
            {
                return NotFound();
            }

            var postulante = await _context.Postulantes.FindAsync(id);
            if (postulante == null)
            {
                return NotFound();
            }
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", postulante.LocalidadId);
            return View(postulante);
        }

        // POST: Postulantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,DNI,FechaNacimiento,LocalidadId,CodigoArea,TelefonoCelular,Email,ArchivoCV,FechaAlta")] Postulante postulante)
        {
            if (id != postulante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postulante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostulanteExists(postulante.Id))
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
            ViewData["LocalidadId"] = new SelectList(_context.Localidades, "Id", "Id", postulante.LocalidadId);
            return View(postulante);
        }

        // GET: Postulantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Postulantes == null)
            {
                return NotFound();
            }

            var postulante = await _context.Postulantes
                .Include(p => p.Localidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postulante == null)
            {
                return NotFound();
            }

            return View(postulante);
        }

        // POST: Postulantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Postulantes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Postulantes'  is null.");
            }
            var postulante = await _context.Postulantes.FindAsync(id);
            if (postulante != null)
            {
                _context.Postulantes.Remove(postulante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostulanteExists(int id)
        {
          return (_context.Postulantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

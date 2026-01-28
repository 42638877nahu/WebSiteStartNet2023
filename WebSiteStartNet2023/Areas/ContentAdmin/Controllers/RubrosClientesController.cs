using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.Areas.ContentAdmin.Controllers
{
    [Area("ContentAdmin")]
    [Authorize(Roles = "Admin")]
    public class RubrosClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RubrosClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentAdmin/RubrosClientes
        public async Task<IActionResult> Index()
        {
              return _context.RubrosClientes != null ? 
                          View(await _context.RubrosClientes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RubrosClientes'  is null.");
        }

        // GET: ContentAdmin/RubrosClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RubrosClientes == null)
            {
                return NotFound();
            }

            var rubroCliente = await _context.RubrosClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rubroCliente == null)
            {
                return NotFound();
            }

            return View(rubroCliente);
        }

        // GET: ContentAdmin/RubrosClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentAdmin/RubrosClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] RubroCliente rubroCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rubroCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rubroCliente);
        }

        // GET: ContentAdmin/RubrosClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RubrosClientes == null)
            {
                return NotFound();
            }

            var rubroCliente = await _context.RubrosClientes.FindAsync(id);
            if (rubroCliente == null)
            {
                return NotFound();
            }
            return View(rubroCliente);
        }

        // POST: ContentAdmin/RubrosClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] RubroCliente rubroCliente)
        {
            if (id != rubroCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rubroCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RubroClienteExists(rubroCliente.Id))
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
            return View(rubroCliente);
        }

        // GET: ContentAdmin/RubrosClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RubrosClientes == null)
            {
                return NotFound();
            }

            var rubroCliente = await _context.RubrosClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rubroCliente == null)
            {
                return NotFound();
            }

            return View(rubroCliente);
        }

        // POST: ContentAdmin/RubrosClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RubrosClientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RubrosClientes'  is null.");
            }
            var rubroCliente = await _context.RubrosClientes.FindAsync(id);
            if (rubroCliente != null)
            {
                _context.RubrosClientes.Remove(rubroCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RubroClienteExists(int id)
        {
          return (_context.RubrosClientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

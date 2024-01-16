using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.Areas.ContentAdmin.Controllers
{
    [Area("ContentAdmin")]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentAdmin/Clientes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Clientes.Include(c => c.RubroCliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContentAdmin/Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.RubroCliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: ContentAdmin/Clientes/Create
        public IActionResult Create()
        {
            ViewData["IdRubroCliente"] = new SelectList(_context.RubrosClientes, "Id", "Nombre");
            return View();
        }

        // POST: ContentAdmin/Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreFantasia,NombreLogo,Fecha,Orden,VisibleEnHome,IdRubroCliente,FotoLogo")] Cliente cliente)
        {
            if (cliente.FotoLogo != null)
            {
                cliente.NombreLogo = Path.GetFileName(cliente.FotoLogo.FileName);
            }

            cliente.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (cliente.FotoLogo != null)
                {
                    string _path = $"Data/Imagenes/LogosClientes/" + cliente.NombreLogo;

                    using (FileStream fs = System.IO.File.Create(_path))
                    {
                        cliente.FotoLogo.CopyTo(fs);
                    }
                }

                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRubroCliente"] = new SelectList(_context.RubrosClientes, "Id", "Nombre", cliente.IdRubroCliente);
            return View(cliente);
        }

        // GET: ContentAdmin/Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["IdRubroCliente"] = new SelectList(_context.RubrosClientes, "Id", "Nombre", cliente.IdRubroCliente);
            return View(cliente);
        }

        // POST: ContentAdmin/Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreFantasia,NombreLogo,Fecha,Orden,VisibleEnHome,IdRubroCliente,FotoLogo")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (cliente.FotoLogo != null)
            {
                cliente.NombreLogo = Path.GetFileName(cliente.FotoLogo.FileName);
            }

            cliente.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    if (cliente.FotoLogo != null)
                    {
                        string _path = $"Data/Imagenes/LogosClientes/" + cliente.NombreLogo;

                        using (FileStream fs = System.IO.File.Create(_path))
                        {
                            cliente.FotoLogo.CopyTo(fs);
                        }
                    }

                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            ViewData["IdRubroCliente"] = new SelectList(_context.RubrosClientes, "Id", "Nombre", cliente.IdRubroCliente);
            return View(cliente);
        }

        // GET: ContentAdmin/Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.RubroCliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ContentAdmin/Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

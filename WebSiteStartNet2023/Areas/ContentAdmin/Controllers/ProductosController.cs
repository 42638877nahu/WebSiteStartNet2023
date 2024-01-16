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
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentAdmin/Productos
        public async Task<IActionResult> Index()
        {
              return _context.Productos != null ? 
                          View(await _context.Productos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Productos'  is null.");
        }

        // GET: ContentAdmin/Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: ContentAdmin/Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentAdmin/Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,NombreSlider,FotoSlider,Detalle,Fecha,NombreHome,FotoHome")] Producto producto)
        {
            producto.Fecha = DateTime.Now;

            if (producto.FotoSlider != null)
            {
                producto.NombreSlider = Path.GetFileName(producto.FotoSlider.FileName);
            }

            if (producto.FotoHome != null)
            {
                producto.NombreHome = Path.GetFileName(producto.FotoHome.FileName);
            }

            if (ModelState.IsValid)
            {
                if (producto.FotoSlider != null)
                {
                    string _path = $"Data/Imagenes/Productos/" + producto.NombreSlider;

                    using (FileStream fs = System.IO.File.Create(_path))
                    {
                        producto.FotoSlider.CopyTo(fs);
                    }
                }

                if (producto.FotoHome != null)
                {
                    string _path = $"Data/Imagenes/Productos/" + producto.NombreHome;

                    using (FileStream fs = System.IO.File.Create(_path))
                    {
                        producto.FotoHome.CopyTo(fs);
                    }
                }

                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: ContentAdmin/Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: ContentAdmin/Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,NombreSlider,FotoSlider,Detalle,Fecha,NombreHome,FotoHome")] Producto producto)
        {
            producto.Fecha = DateTime.Now;

            if (id != producto.Id)
            {
                return NotFound();
            }

            if (producto.FotoSlider != null)
            {
                producto.NombreSlider = Path.GetFileName(producto.FotoSlider.FileName);
            }

            if (producto.FotoHome != null)
            {
                producto.NombreHome = Path.GetFileName(producto.FotoHome.FileName);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (producto.FotoSlider != null)
                    {
                        string _path = $"Data/Imagenes/Productos/" + producto.NombreSlider;

                        using (FileStream fs = System.IO.File.Create(_path))
                        {
                            producto.FotoSlider.CopyTo(fs);
                        }
                    }

                    if (producto.FotoHome != null)
                    {
                        string _path = $"Data/Imagenes/Productos/" + producto.NombreHome;

                        using (FileStream fs = System.IO.File.Create(_path))
                        {
                            producto.FotoHome.CopyTo(fs);
                        }
                    }

                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            return View(producto);
        }

        // GET: ContentAdmin/Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: ContentAdmin/Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
          return (_context.Productos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

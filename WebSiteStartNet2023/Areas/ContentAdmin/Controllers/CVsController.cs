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
    public class CVsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CVsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentAdmin/CVs
        public async Task<IActionResult> Index()
        {
              return _context.CVs != null ? 
                          View(await _context.CVs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CVs'  is null.");
        }

        // GET: ContentAdmin/CVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CVs == null)
            {
                return NotFound();
            }

            var cV = await _context.CVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cV == null)
            {
                return NotFound();
            }

            return View(cV);
        }

        // GET: ContentAdmin/CVs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentAdmin/CVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Localidad,Provincia,CodigoArea,TeléfonoCelular,Email,NombreArchivo,Archivo")] CV cV)
        {
            cV.Fecha = DateTime.Now;

            if (cV.Archivo != null)
            {
                cV.NombreArchivo = Path.GetFileName(cV.Archivo.FileName);
            }

            if (ModelState.IsValid)
            {
                if (cV.Archivo != null)
                {
                    string _path = $"Data/Archivos/Cvs/" + cV.NombreArchivo;

                    using (FileStream fs = System.IO.File.Create(_path))
                    {
                        cV.Archivo.CopyTo(fs);
                    }
                }

                _context.Add(cV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cV);
        }

        // GET: ContentAdmin/CVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CVs == null)
            {
                return NotFound();
            }

            var cV = await _context.CVs.FindAsync(id);
            if (cV == null)
            {
                return NotFound();
            }
            return View(cV);
        }

        // POST: ContentAdmin/CVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Localidad,Provincia,CodigoArea,Celular,Email,NombreArchivo")] CV cV)
        {
            if (id != cV.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVExists(cV.Id))
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
            return View(cV);
        }

        // GET: ContentAdmin/CVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CVs == null)
            {
                return NotFound();
            }

            var cV = await _context.CVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cV == null)
            {
                return NotFound();
            }

            return View(cV);
        }

        // POST: ContentAdmin/CVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CVs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CVs'  is null.");
            }
            var cV = await _context.CVs.FindAsync(id);
            if (cV != null)
            {
                _context.CVs.Remove(cV);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVExists(int id)
        {
          return (_context.CVs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

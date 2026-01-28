using Microsoft.AspNetCore.Mvc;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.ViewComponents
{
    public class ProductosViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ProductosViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Producto> productos = _context.Productos.ToList();
            return View(productos);
        }
    }
}

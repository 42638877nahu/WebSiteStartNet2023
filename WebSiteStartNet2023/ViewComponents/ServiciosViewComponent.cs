using Microsoft.AspNetCore.Mvc;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.ViewComponents
{
    public class ServiciosViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public ServiciosViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Servicio> servicios = _context.Servicios.ToList();
            return View(servicios);
        }
    }
}

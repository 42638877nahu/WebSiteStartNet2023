using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebSiteStartNet2023.Areas.ContentAdmin.Controllers
{
    [Area("ContentAdmin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Web.Helpers;
using WebSiteStartNet2023.Data;
using WebSiteStartNet2023.Models;
using System.Web;
using System.Net.Mail;
using System.Net;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSiteStartNet2023.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly GoogleCaptchaService _captchaService;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context,GoogleCaptchaService captchaService)
        {
            _logger = logger;
            _context = context;
            _captchaService = captchaService;
        }

        public IActionResult Index()
        {
            ViewBag.Productos = _context.Productos;
            ViewBag.Servicios = _context.Servicios;
            ViewBag.Novedades = _context.Novedades.Take(3).OrderByDescending(x => x.Fecha);
            ViewBag.Clientes = _context.Clientes.Where(x=>x.VisibleEnHome).OrderBy(x=>x.Orden);

            #region Carga Fotos de Slider de Productos y Servicios

            List<VmSlider> slider = new List<VmSlider>();

            foreach (var item in _context.Productos)
            {
                VmSlider vmSlider = new VmSlider();
                vmSlider.Nombre = item.Nombre;
                vmSlider.Descripcion = item.Descripcion;
                vmSlider.Ruta = "/Data/Imagenes/Productos/" + item.NombreSlider;
                vmSlider.Link = "/Productos/Details/" + item.Id;
                slider.Add(vmSlider);
            }

            foreach (var item in _context.Servicios)
            {
                VmSlider vmSlider = new VmSlider();
                vmSlider.Nombre = item.Nombre;
                vmSlider.Descripcion = item.Descripcion;
                vmSlider.Ruta = "/Data/Imagenes/Servicios/" + item.NombreSlider;
                vmSlider.Link = "Servicios/Details/" + item.Id;
                slider.Add(vmSlider);
            }

            #endregion

            ViewBag.Sliders = slider;
            ViewBag.PrimerSlider = slider.First();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            ViewBag.Productos = _context.Productos;
            ViewBag.Servicios = _context.Servicios;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contacto([Bind("Id,Nombre,Apellido,AreaCelular,TeléfonoCelular,Email,Mensaje,Fecha,Area,SubArea,Token")]Contacto contacto)
        {
            //Verificar Respuesta de Token de Google
            var capthaResult = await _captchaService.VerifyToken(contacto.Token);
            if (!capthaResult)
            {
                return RedirectToAction(nameof(Contacto));
            }


            contacto.Fecha = DateTime.Now;

            if (ModelState.IsValid)
            {

                var emailBody = "Fecha: " + contacto.Fecha + "<br />Nombre y Apellido: " + contacto.Nombre + " " + contacto.Apellido + "<br />Email: " + contacto.Email + "<br /> Telefono: " + contacto.AreaCelular + "-" + contacto.TeléfonoCelular + "<br />Area: " + contacto.Area + "<br />SubArea: " + contacto.SubArea + "<br />Mensaje: " + contacto.Mensaje ;

                //Crear Mensaje/Mail

                string desde = "avisos@stnt.com.ar";
                string hacia = "web@stnt.com.ar";
                string contraseña = "DmEY*6k8bE";

                MailMessage mailMessage = new MailMessage(desde, hacia, "Contacto por StartNet", emailBody);

                mailMessage.IsBodyHtml = true;

                //Crear y configurar parametros

                SmtpClient smtpClient = new SmtpClient("mail.stnt.com.ar");
                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(desde, contraseña);

                smtpClient.Send(mailMessage);//Enviar
                smtpClient.Dispose();//Cerrar Conexión

                _context.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Contacto));
            }

            return RedirectToAction(nameof(Contacto));
        }

        public IActionResult Empresa()
        {
            return View();
        }

        public IActionResult CV()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CV([Bind("Id,Nombre,Apellido,Localidad,Provincia,CodigoArea,TeléfonoCelular,Email,NombreArchivo,Archivo,Fecha,Token")]CV cv)
        {
            //Verificar Respuesta de Token de Google
            var capthaResult = await _captchaService.VerifyToken(cv.Token);
            if (!capthaResult)
            {
                return RedirectToAction(nameof(CV));
            }

            cv.Fecha = DateTime.Now;

            if (cv.Archivo != null)
            {
                cv.NombreArchivo = Path.GetFileName(cv.Archivo.FileName);
            }

            if (ModelState.IsValid)
            {

                if (cv.Archivo != null)
                {
                    string _path = $"Data/Archivos/Cvs/" + cv.NombreArchivo;

                    using (FileStream fs = System.IO.File.Create(_path))
                    {
                        cv.Archivo.CopyTo(fs);
                    }
                }
                var emailBody = "Fecha: " + cv.Fecha + "<br />Nombre y Apellido: " + cv.Nombre +" "+ cv.Apellido +"<br />Email: " + cv.Email +"<br /> Telefono: " + cv.CodigoArea + "-" + cv.TeléfonoCelular + "<br />Localidad: " +cv.Localidad +"<br />Provincia: " + cv.Provincia;

                //Crear Mensaje/Mail

                string desde = "avisos@stnt.com.ar";
                string hacia = "web@stnt.com.ar";
                string contraseña = "DmEY*6k8bE";

                MailMessage mailMessage = new MailMessage(desde,hacia, "Currículum para StartNet",emailBody);

                mailMessage.Attachments.Add(new Attachment($"Data/Archivos/Cvs/" + cv.NombreArchivo));

                mailMessage.IsBodyHtml = true;

                //Crear y configurar parametros

                SmtpClient smtpClient = new SmtpClient("mail.stnt.com.ar");
                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(desde, contraseña);

                smtpClient.Send(mailMessage);//Enviar
                smtpClient.Dispose();//Cerrar Coneción

                _context.Add(cv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CV));
            }

            return View(cv);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
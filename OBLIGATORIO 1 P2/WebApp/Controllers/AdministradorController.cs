using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdministradorController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UsuarioRol") != "ADMIN") // protege para que no entren por url manualmente
            {
                return RedirectToAction("Login", "Anonimo");
            }

            return View();
        }
    }
}
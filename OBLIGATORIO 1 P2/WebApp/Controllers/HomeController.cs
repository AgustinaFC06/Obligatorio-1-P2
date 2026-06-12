using Biblioteca_de_Clase;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            string rol = HttpContext.Session.GetString("UsuarioRol");

            if (rol != "OPERADOR" && rol != "ADMIN")
            {
                return RedirectToAction("Login", "Anonimo");
            }

            int? cedula = HttpContext.Session.GetInt32("UsuarioCedula");

            if (cedula == null)
            {
                return RedirectToAction("Login", "Anonimo");
            }

            Persona persona = s.BuscarPersonaPorCedula(cedula.Value);

            if (persona == null)
            {
                return RedirectToAction("Login", "Anonimo");
            }

            return View(persona);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Anonimo");
        }
    }
}

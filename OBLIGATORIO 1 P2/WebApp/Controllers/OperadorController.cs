using Biblioteca_de_Clase;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [OperadorAuth]
    public class OperadorController : Controller // en esta clase agrege la logica de operador puede ver todos sus activos ordenados por codigo de activo ascendente
    {
        Sistema s = Sistema.GetInstancia();

        public IActionResult Index()
        {
            return View("MisActivos");
        }
        public IActionResult MisActivos()
        {
            // El filtro ya validó la sesión, obtenemos la cédula directo
            int cedula = HttpContext.Session.GetInt32("UsuarioCedula")!.Value;

            // Llamamos al método optimizado del sistema que ya devuelve todo procesado y ordenado
            List<Activo> activosOrdenados = s.ListarActivosDePersonaOrdenados(cedula);

            // Enviamos la lista prolija a la Vista
            return View(activosOrdenados);
        }

        public IActionResult Perfil()
        {
            return RedirectToAction("Perfil", "Home");
        }
    }
}

using Biblioteca_de_Clase;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class OperadorController : Controller // en esta clase agrege la logica de operador puede ver todos sus activos ordenados por codigo de activo ascendente
    {
        Sistema s = Sistema.GetInstancia();

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UsuarioRol") != "OPERADOR")
            {
                return RedirectToAction("Login", "Anonimo");
            }

            return View();
        }

        public IActionResult MisActivos()
        {
            if (HttpContext.Session.GetString("UsuarioRol") != "OPERADOR")
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

            List<Activo> activos = new List<Activo>();

            foreach (Cuenta cuenta in persona.Cuentas)
            {
                foreach (Activo activo in cuenta.Activos)
                {
                    activos.Add(activo);
                }
            }

            // ordena los activos por codigo ascendente!!!
            for (int i = 0; i < activos.Count - 1; i++)
            {
                for (int j = i + 1; j < activos.Count; j++)
                {
                    if (activos[i].CrearAlfanumerico().CompareTo(activos[j].CrearAlfanumerico()) > 0)
                    {
                        Activo aux = activos[i];
                        activos[i] = activos[j];
                        activos[j] = aux;
                    }
                }
            }
            return View(activos);
        }

        public IActionResult Perfil()
        {
            return RedirectToAction("Perfil", "Home");
        }
    }
}

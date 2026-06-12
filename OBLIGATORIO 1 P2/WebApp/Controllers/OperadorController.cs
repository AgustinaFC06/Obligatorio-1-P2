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

        //public IActionResult MisActivos()
        //{
        //  
        //    int cedula = HttpContext.Session.GetInt32("UsuarioCedula")!.Value;
        //   
        //
        //    Persona persona = s.BuscarPersonaPorCedula(cedula);
        //
        //  
        //    List<Activo> activos = new List<Activo>();
        //
        //    foreach (Cuenta cuenta in persona.Cuentas)
        //    {
        //        foreach (Activo activo in cuenta.Activos)
        //        {
        //            activos.Add(activo);
        //        }
        //    }
        //
        //    // ordena los activos por codigo ascendente!!!
        //    for (int i = 0; i < activos.Count - 1; i++)
        //    {
        //        for (int j = i + 1; j < activos.Count; j++)
        //        {
        //            if (activos[i].CrearAlfanumerico().CompareTo(activos[j].CrearAlfanumerico()) > 0)
        //            {
        //                Activo aux = activos[i];
        //                activos[i] = activos[j];
        //                activos[j] = aux;
        //            }
        //        }
        //    }
        //    return View(activos);
        //}

        public IActionResult Perfil()
        {
            return RedirectToAction("Perfil", "Home");
        }
    }
}

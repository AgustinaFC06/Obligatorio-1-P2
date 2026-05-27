using Biblioteca_de_Clase;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AnonimoController : Controller
    {
        Sistema s = Sistema.GetInstancia();
        // public IActionResult Index()
        // {
        //     return View();
        // }
        [HttpGet] //se ve cuando el usuario entra a la URL 
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string txtEmail, string txtContrasena)
        {
            try
            {
                // 1. Buscamos la persona en tus listas precargadas
                Persona usuarioLogueado = s.ValidarEmailContrasena(txtEmail, txtContrasena);

                if (usuarioLogueado != null)
                {
                    // 2. Nos quedamos con el email y la cédula guardándolos en la Sesión
                    HttpContext.Session.SetString("UsuarioEmail", usuarioLogueado.Email);
                    HttpContext.Session.SetInt32("UsuarioCedula", usuarioLogueado.Cedula);
                    // Validacion con ENUM
                    if (usuarioLogueado.Rol == TipoUsuario.Administrador)
                    {
                        // Guardamos el rol en sesión para proteger las pantallas después
                        HttpContext.Session.SetString("UsuarioRol", "ADMIN");

                        // REDIRECCIÓN: Lo mandamos al Index del AdminController
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        HttpContext.Session.SetString("UsuarioRol", "OPERADOR");

                        // REDIRECCIÓN: Lo mandamos al Index del OperadorController
                        return RedirectToAction("Index", "Operador");
                    }
                }
                else
                {
                    // Si el método devolvió null, las credenciales no existen
                    ViewBag.Error = "El correo electrónico o la contraseña son incorrectos.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error: " + ex.Message;
                return View();
            }
        }
    }
}
    


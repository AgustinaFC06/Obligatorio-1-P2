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
                // 1. Buscamos la persona en listas precargadas
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
                        return RedirectToAction("Index", "Administrador");
                    }
                    else
                    {
                        HttpContext.Session.SetString("UsuarioRol", "OPERADOR");

                        // REDIRECCIÓN: Lo mandamos al Index del OperadorController
                        return RedirectToAction("MisActivos", "Operador");
                    }
                }
                else
                {   // Como vamos a usar un Redirect, guardamos el mensaje en TempleDate
                    ViewBag.Error = "El correo electrónico o la contraseña son incorrectos."; // cambie temp por un viewbag 
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrió un error inesperado: " + ex.Message;
                return RedirectToAction("Login");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        // 2. EL POST: Procesa los datos cuando el usuario le da al botón "Registrarse"
        [HttpPost]
        public IActionResult Registro(Persona p, string Contrasena) // El framework arma el objeto 'p' solo con los datos de la web
        {
            try
            {
                                
                p.Contrasena = Contrasena;
                               
                p.Rol = TipoUsuario.Operador;
                
                p.Validar();                       
                                           
                s.AltaPersona(p);

                Cuenta nuevaCuenta = new Cuenta(false, DateTime.Now);
                s.AgregarCuentaAPersona(p, nuevaCuenta);
                //p.AgregarCuenta(nuevaCuenta); se va a agregar a la persona desde el sistema, no desde la persona misma, para mantener la lógica de negocio en un solo lugar
                                               
                HttpContext.Session.SetString("UsuarioEmail", p.Email); // Guardamos los datos simétricos en la Sesión para el Login automático
                HttpContext.Session.SetString("UsuarioRol", "OPERADOR");
                HttpContext.Session.SetInt32("UsuarioCedula", p.Cedula);
                                
                return RedirectToAction("MisActivos", "Operador"); // Todo correcto, ingresamos al panel
            }
            catch(Exception e)
{
                ViewBag.Msg = e.Message; 
                return View(p);
            }
        }
    }
}
    


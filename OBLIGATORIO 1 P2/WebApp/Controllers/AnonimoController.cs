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
                // 1. Validamos la contraseña acá antes de hacer nada, para que no pase vacía
                if (string.IsNullOrWhiteSpace(Contrasena))
                {
                    throw new Exception("La contraseña no puede ser vacia");
                }

                // Forzamos el rol del operador
                p.Rol = TipoUsuario.Operador;

                // 2. Ejecutamos tus validaciones de Persona (Nombre, Cédula, Email, Teléfono)
                p.Validar();

                // 3. Si la persona es válida, le creamos su Cuenta de forma obligatoria 
                // Pasamos 'false' en MFA por defecto y la Contrasena que capturamos
                Cuenta nuevaCuenta = new Cuenta(false, Contrasena);

                // Usamos tu propio método para meter la cuenta adentro de la lista de la persona
                p.AgregarCuenta(nuevaCuenta);

                // 4. Invocamos el alta en tu clase Sistema (capa Dominio)
                // Nota: Asegurate de que tu método AltaPersona agregue a la persona 'p' a tu lista del sistema
                s.AltaPersona(p);

                // Guardamos los datos simétricos en la Sesión para el Login automático
                HttpContext.Session.SetString("UsuarioEmail", p.Email);
                HttpContext.Session.SetString("UsuarioRol", "OPERADOR");
                HttpContext.Session.SetInt32("UsuarioCedula", p.Cedula);

                // Todo correcto, ingresamos al panel
                return RedirectToAction("MisActivos", "Operador");
            }
            catch(Exception e)
{
                ViewBag.Msg = e.Message; 
                return View(p);
            }
        }
    }
}
    


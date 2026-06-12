using Biblioteca_de_Clase;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AnonimoAuth]
    public class AnonimoController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            try
            {
                Persona usuarioLogueado = s.ValidarEmailContrasena(vm.Email, vm.Contrasena);

                if (usuarioLogueado != null)
                {
                    HttpContext.Session.SetString("UsuarioEmail", usuarioLogueado.Email);
                    HttpContext.Session.SetInt32("UsuarioCedula", usuarioLogueado.Cedula);

                    if (usuarioLogueado.Rol == TipoUsuario.Administrador)
                    {
                        HttpContext.Session.SetString("UsuarioRol", "ADMIN");
                        return RedirectToAction("Index", "Administrador");
                    }

                    HttpContext.Session.SetString("UsuarioRol", "OPERADOR");
                    return RedirectToAction("MisActivos", "Operador");
                }

                ViewBag.Error = "El correo electronico o la contrasena son incorrectos.";
                return View(vm);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Ocurrio un error: " + ex.Message;
                return RedirectToAction("Login");
            }
        }

       
        [HttpGet]
        public IActionResult Registro()
        {
            return View(new RegistroViewModel());
        }

        [HttpPost]
        public IActionResult Registro(RegistroViewModel vm)
        {
            try
            {
                Persona persona = new Persona(vm.Cedula, vm.Nombre, vm.Email, vm.Telefono, vm.Contrasena);
                persona.Rol = TipoUsuario.Operador;

                s.AltaPersona(persona);

                Cuenta nuevaCuenta = new Cuenta(false, DateTime.Now);
                s.AgregarCuentaAPersona(persona, nuevaCuenta);

                HttpContext.Session.SetString("UsuarioEmail", persona.Email);
                HttpContext.Session.SetString("UsuarioRol", "OPERADOR");
                HttpContext.Session.SetInt32("UsuarioCedula", persona.Cedula);

                return RedirectToAction("MisActivos", "Operador");
            }
            catch (Exception e)
            {
                ViewBag.Msg = e.Message;
                return View(vm);
            }
        }
    }
}

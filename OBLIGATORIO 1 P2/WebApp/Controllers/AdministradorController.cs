using Biblioteca_de_Clase;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdministradorController : Controller
    {
        Sistema s = Sistema.GetInstancia();

        // Verifica si el usuario logueado tiene rol de administrador.
        // Se usa en todas las acciones para proteger las pantallas del admin.
        private bool EsAdmin()
        {
            return HttpContext.Session.GetString("UsuarioRol") == "ADMIN";
        }

        // Pantalla inicial del administrador.
        // Si el usuario no es admin, lo manda al login.
        // Si es admin, lo redirige directamente al listado de personas.
        public IActionResult Index()
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            return RedirectToAction("Personas");
        }

        // Lista todas las personas del sistema.
        // Desde esta vista el admin puede entrar a ver las cuentas de cada persona.
        public IActionResult Personas()
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            List<Persona> personas = s.ObtenerPersonasConActivos();
            return View(personas);
        }

        // Muestra el perfil del administrador logueado.
        // Usa la cedula guardada en Session para buscar la Persona correspondiente.
        public IActionResult Perfil()
        {
            if (!EsAdmin())
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

        // Muestra las cuentas asociadas a una persona.
        // Recibe la cedula porque es el dato que identifica a la Persona.
        public IActionResult Cuentas(int cedula)
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            return View(persona);
        }

        // Muestra los activos asociados a una cuenta puntual de una persona.
        // Se recibe cedula para encontrar la persona y cuentaId para encontrar la cuenta.
        public IActionResult ActivosCuenta(int cedula, int cuentaId)
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            Cuenta cuenta = BuscarCuentaDePersona(persona, cuentaId);

            if (cuenta == null)
            {
                TempData["Error"] = "No se encontro la cuenta.";
                return RedirectToAction("Cuentas", new { cedula = cedula });
            }

            ViewBag.Persona = persona;
            return View(cuenta);
        }

        // Muestra el formulario para crear una nueva cuenta para una persona.
        // La persona debe existir para poder asignarle la cuenta.
        [HttpGet]
        public IActionResult CrearCuenta(int cedula)
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            ViewBag.Persona = persona;
            return View();
        }

        // Procesa el formulario de creacion de cuenta.
        // Crea la cuenta y la asocia a la Persona seleccionada.
        [HttpPost]
        public IActionResult CrearCuenta(int cedula, bool mfa, string contrasena)
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            try
            {
                Cuenta cuenta = new Cuenta(mfa, contrasena);
                s.AgregarCuentaAPersona(persona, cuenta);
                //persona.AgregarCuenta(cuenta); // No es necesario porque el sistema ya lo hace al agregar la cuenta a la persona.

                TempData["Mensaje"] = "Cuenta creada correctamente.";
                return RedirectToAction("Cuentas", new { cedula = cedula });
            }
            catch (Exception ex)
            {
                ViewBag.Persona = persona;
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Muestra el formulario para crear un activo dentro de una cuenta.
        // Primero se valida que existan la persona y la cuenta.
        [HttpGet]
        public IActionResult CrearActivo(int cedula, int cuentaId)
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            Cuenta cuenta = BuscarCuentaDePersona(persona, cuentaId);

            if (cuenta == null)
            {
                TempData["Error"] = "No se encontro la cuenta.";
                return RedirectToAction("Cuentas", new { cedula = cedula });
            }

            ViewBag.Persona = persona;
            ViewBag.Cuenta = cuenta;
            return View();
        }

        // Procesa el formulario de creacion de activo.
        // Crea el activo y lo agrega automaticamente a la cuenta seleccionada.
        [HttpPost]
        public IActionResult CrearActivo(int cedula, int cuentaId, string nombre, TipoActivo tipoActivo, int criticidad, bool backup)
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            Cuenta cuenta = BuscarCuentaDePersona(persona, cuentaId);

            if (cuenta == null)
            {
                TempData["Error"] = "No se encontro la cuenta.";
                return RedirectToAction("Cuentas", new { cedula = cedula });
            }

            try
            {
                Activo activo = new Activo(nombre, tipoActivo, criticidad, backup);
                s.AgregarActivoACuenta(cuenta, activo);
                //cuenta.Activo.Add(activo); // No es necesario porque el sistema ya lo hace al agregar el activo a la cuenta.

                TempData["Mensaje"] = "Activo creado correctamente.";
                return RedirectToAction("ActivosCuenta", new { cedula = cedula, cuentaId = cuentaId });
            }
            catch (Exception ex)
            {
                ViewBag.Persona = persona;
                ViewBag.Cuenta = cuenta;
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Desasocia un activo de una cuenta.
        // No borra el activo del sistema completo, solamente lo quita de esa cuenta.
        [HttpPost]
        public IActionResult DesasociarActivo(int cedula, int cuentaId, int activoId)
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            Cuenta cuenta = BuscarCuentaDePersona(persona, cuentaId);

            if (cuenta == null)
            {
                TempData["Error"] = "No se encontro la cuenta.";
                return RedirectToAction("Cuentas", new { cedula });
            }

            Activo activo = BuscarActivoDeCuenta(cuenta, activoId);

            if (activo != null)
            {
                try
                {
                    s.DesasociarActivoDeCuenta(cuenta, activo);
                    TempData["Mensaje"] = "Activo desasociado correctamente.";
                }
                catch (Exception ex)
                {
                    
                    TempData["Error"] = ex.Message;
                }
                // cuenta.Activo.Remove(activo);
                // TempData["Mensaje"] = "Activo desasociado correctamente.";
            }
            else
            {
                TempData["Error"] = "No se encontro el activo.";
            }

            return RedirectToAction("ActivosCuenta", new { cedula, cuentaId });
        }

        // Lista todos los incidentes del sistema.
        // Antes de enviarlos a la vista, los ordena por severidad descendente.
        public IActionResult Incidentes()
        {
            if (!EsAdmin())
            {
                return RedirectToAction("Login", "Anonimo");
            }

            List<Incidente> incidentes = s.Incidentes;

            for (int i = 0; i < incidentes.Count - 1; i++)
            {
                for (int j = i + 1; j < incidentes.Count; j++)
                {
                    if (incidentes[i].CalcularSeveridad() < incidentes[j].CalcularSeveridad())
                    {
                        Incidente aux = incidentes[i];
                        incidentes[i] = incidentes[j];
                        incidentes[j] = aux;
                    }
                }
            }

            return View(incidentes);
        }

        // Busca una cuenta dentro de las cuentas de una persona.
        
        private Cuenta BuscarCuentaDePersona(Persona persona, int cuentaId)
        {
            foreach (Cuenta cuenta in persona.Cuenta)
            {
                if (cuenta.Id == cuentaId)
                {
                    return cuenta;
                }
            }

            return null;
        }

        // Busca un activo dentro de una cuenta.
        // Se usa para poder desasociarlo desde la vista del administrador.
        private Activo BuscarActivoDeCuenta(Cuenta cuenta, int activoId)
        {
            foreach (Activo activo in cuenta.Activo)
            {
                if (activo.Id == activoId)
                {
                    return activo;
                }
            }

            return null;
        }
    }
}
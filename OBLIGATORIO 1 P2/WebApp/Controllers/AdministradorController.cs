using Biblioteca_de_Clase;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AdminAuth]
    public class AdministradorController : Controller
    {
        Sistema s = Sistema.GetInstancia();
              
        // si es admin lo mando al listado de personas
        public IActionResult Index()
        {          
           return RedirectToAction("Personas");
        }

        // muestro todas las personas del sistema
        public IActionResult Personas()
        {
            List<Persona> personas = s.ObtenerPersonasConActivos();
            return View(personas);
        }

        // mando al perfil comun que esta en home
        public IActionResult Perfil()
        {
            return RedirectToAction("Perfil", "Home");
        }

        // muestro las cuentas de una persona
        public IActionResult Cuentas(int cedula)
        {
            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            return View(persona);
        }

        // muestro los activos de una cuenta
        public IActionResult ActivosCuenta(int cedula, int cuentaId)
        {
            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            Cuenta cuenta = s.BuscarCuentaDePersona(persona, cuentaId);

            if (cuenta == null)
            {
                TempData["Error"] = "No se encontro la cuenta.";
                return RedirectToAction("Cuentas", new { cedula });
            }

            ViewBag.Persona = persona;
            return View(cuenta);
        }

        // muestro el formulario para crear cuenta
        [HttpGet]
        public IActionResult CrearCuenta(int cedula)
        {           
            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            if (persona.Rol != TipoUsuario.Operador)
            {
                TempData["Error"] = "Solo se pueden crear cuentas para operadores.";
                return RedirectToAction("Cuentas", new { cedula });
            }

            CrearCuentaViewModel vm = new CrearCuentaViewModel();
            vm.Cedula = persona.Cedula;
            vm.NombrePersona = persona.Nombre;

            return View(vm);
        }

        // creo la cuenta y la asocio a la persona
        [HttpPost]
        public IActionResult CrearCuenta(CrearCuentaViewModel vm)
        {
            Persona persona = s.BuscarPersonaPorCedula(vm.Cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            if (persona.Rol != TipoUsuario.Operador)
            {
                TempData["Error"] = "Solo se pueden crear cuentas para operadores.";
                return RedirectToAction("Cuentas", new { cedula = vm.Cedula });
            }

            try
            {
                Cuenta cuenta = new Cuenta(vm.Mfa, DateTime.Now);
                s.AgregarCuentaAPersona(persona, cuenta);

                TempData["Mensaje"] = "Cuenta creada correctamente.";
                return RedirectToAction("Cuentas", new { cedula = vm.Cedula });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                vm.NombrePersona = persona.Nombre;
                return View(vm);
            }
        }

        // muestro el formulario para crear activo
        [HttpGet]
        public IActionResult CrearActivo(int cedula, int cuentaId)
        {
            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            Cuenta cuenta = s.BuscarCuentaDePersona(persona, cuentaId);

            if (cuenta == null)
            {
                TempData["Error"] = "No se encontro la cuenta.";
                return RedirectToAction("Cuentas", new { cedula });
            }

            CrearActivoViewModel vm = new CrearActivoViewModel();
            vm.Cedula = persona.Cedula;
            vm.CuentaId = cuenta.Id;
            vm.NombrePersona = persona.Nombre;

            return View(vm);
        }

        // creo el activo y lo agrego a la cuenta
        [HttpPost]
        public IActionResult CrearActivo(CrearActivoViewModel vm)
        {
            Persona persona = s.BuscarPersonaPorCedula(vm.Cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            Cuenta cuenta = s.BuscarCuentaDePersona(persona, vm.CuentaId);

            if (cuenta == null)
            {
                TempData["Error"] = "No se encontro la cuenta.";
                return RedirectToAction("Cuentas", new { cedula = vm.Cedula });
            }

            try
            {
                Activo activo = new Activo(vm.Nombre, vm.TipoActivo, vm.Criticidad, vm.Backup);
                s.AgregarActivoACuenta(cuenta, activo);

                TempData["Mensaje"] = "Activo creado correctamente.";
                return RedirectToAction("ActivosCuenta", new { cedula = vm.Cedula, cuentaId = vm.CuentaId });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                vm.NombrePersona = persona.Nombre;
                return View(vm);
            }
        }

        // desasocio un activo de una cuenta
        [HttpPost]
        public IActionResult DesasociarActivo(int cedula, int cuentaId, int activoId) 
        {
            Persona persona = s.BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                TempData["Error"] = "No se encontro la persona.";
                return RedirectToAction("Personas");
            }

            Cuenta cuenta = s.BuscarCuentaDePersona(persona, cuentaId);

            if (cuenta == null)
            {
                TempData["Error"] = "No se encontro la cuenta.";
                return RedirectToAction("Cuentas", new { cedula }); 
            }

            Activo activo = s.BuscarActivoDeCuenta(cuenta, activoId);

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
            }
            else
            {
                TempData["Error"] = "No se encontro el activo.";
            }

            return RedirectToAction("ActivosCuenta", new { cedula, cuentaId }); 
        }

        // muestro los incidentes ordenados por severidad
        public IActionResult Incidentes()
        {
            List<Incidente> incidentes = s.ListarIncidentesOrdenadosPorSeveridad();
            List<IncidenteListadoViewModel> lista = new List<IncidenteListadoViewModel>();

            foreach (Incidente incidente in incidentes)
            {
                IncidenteListadoViewModel vm = new IncidenteListadoViewModel();
                vm.Id = incidente.Id;
                vm.FechaReporte = incidente.FechaReporte;
                vm.Estado = incidente.Estado;
                vm.CodigoActivo = incidente.Activo != null ? incidente.Activo.CrearAlfanumerico() : "Sin activo";
                vm.Severidad = incidente.CalcularSeveridad();

                lista.Add(vm);
            }

            return View(lista);
        }

    }
}

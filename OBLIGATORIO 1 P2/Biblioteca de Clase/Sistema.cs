using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Sistema
    {
        #region LISTAS
        private List<Persona> _personas { get; } = new List<Persona>();
        private List<Cuenta> _cuentas { get; } = new List<Cuenta>();
        private List<Activo> _activos { get; } = new List<Activo>();
        private List<Incidente> _incidentes { get; } = new List<Incidente>();
        private static Sistema _instancia;
        #endregion

        public static Sistema GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }

        #region PRECARGA DE DATOS
        private Sistema()
        {
            PrecargarDatos();
        }

        private void PrecargarDatos() 
        { 
            PrecargarPersonas();
            PrecargarActivos();
            PrecargarCuentas();
            PrecargarIncidentes();
        }
        private void PrecargarPersonas() 
            {
                AltaPersona(new Persona(12345678, "Ana García", "ana.garcia@empresa.com", "099111222"));
                AltaPersona(new Persona(23456789, "Luis Pérez", "luis.perez@empresa.com", "098222333"));
                AltaPersona(new Persona(34567890, "María López", "maria.lopez@empresa.com", "097333444"));
                AltaPersona(new Persona(45678901, "Carlos Rodríguez", "carlos.rodriguez@empresa.com", "096444555"));
                AltaPersona(new Persona(56789012, "Laura Martínez", "laura.martinez@empresa.com", "095555666"));
                AltaPersona(new Persona(67890123, "Diego Fernández", "diego.fernandez@empresa.com", "094666777"));
                AltaPersona(new Persona(78901234, "Sofía González", "sofia.gonzalez@empresa.com", "093777888"));
                AltaPersona(new Persona(89012345, "Martín Díaz", "martin.diaz@empresa.com", "092888999"));
                AltaPersona(new Persona(90123456, "Valentina Torres", "valentina.torres@empresa.com", "091999000"));
                AltaPersona(new Persona(11223344, "Pablo Sánchez", "pablo.sanchez@empresa.com", "090000111"));
            }

        private void PrecargarActivos() 
        {
            AltaActivo(new Activo("Laptop Ventas", TipoActivo.PC, 3, true));
            AltaActivo(new Activo("Laptop Gerencia", TipoActivo.PC, 5, true));
            AltaActivo(new Activo("PC Recepción", TipoActivo.PC, 1, false));
            AltaActivo(new Activo("PC Contabilidad", TipoActivo.PC, 4, true));
            AltaActivo(new Activo("PC Soporte", TipoActivo.PC, 2, false));
            AltaActivo(new Activo("Servidor Principal", TipoActivo.SERVER, 5, true));
            AltaActivo(new Activo("Servidor Backup", TipoActivo.SERVER, 4, true));
            AltaActivo(new Activo("Servidor Web", TipoActivo.SERVER, 5, false));
            AltaActivo(new Activo("Servidor Base de Datos", TipoActivo.SERVER, 5, true));
            AltaActivo(new Activo("Servidor de Correo", TipoActivo.SERVER, 3, false));
            AltaActivo(new Activo("Celular Gerencia", TipoActivo.MOVIL, 4, true));
            AltaActivo(new Activo("Celular Ventas", TipoActivo.MOVIL, 2, false));
            AltaActivo(new Activo("Celular Soporte", TipoActivo.MOVIL, 2, false));
            AltaActivo(new Activo("Tablet Dirección", TipoActivo.MOVIL, 3, true));
            AltaActivo(new Activo("Tablet Logística", TipoActivo.MOVIL, 1, false));
        }

        private void PrecargarCuentas() 
        {
            AltaCuenta(new Cuenta(true, "Pass123!"));
            AltaCuenta(new Cuenta(false, "Clave456!"));
            AltaCuenta(new Cuenta(true, "Segura789!"));
            AltaCuenta(new Cuenta(false, "Admin2024!"));
            AltaCuenta(new Cuenta(true, "Empresa001!"));
            AltaCuenta(new Cuenta(false, "Usuario555!"));
            AltaCuenta(new Cuenta(true, "Acceso321!"));
            AltaCuenta(new Cuenta(true, "Sistema789!"));
            AltaCuenta(new Cuenta(false, "Contable11!"));
            AltaCuenta(new Cuenta(true, "Gerencia22!"));
            AltaCuenta(new Cuenta(false, "Soporte333!"));
            AltaCuenta(new Cuenta(true, "Ventas4444!"));
        }


        private void PrecargarIncidentes()
        {
            // 15 Phishing
            AltaIncidente(new Phishing("email", false, false, new DateTime(2024, 1, 10), _activos[0], "Correo falso suplantando al banco", Estado.Cerrado, 3, 2));
            AltaIncidente(new Phishing("whatsapp", true, false, new DateTime(2024, 2, 14), _activos[1], "Phishing por WhatsApp con link malicioso", Estado.Cerrado, 4, 3));
            AltaIncidente(new Phishing("llamada", false, false, new DateTime(2024, 3, 5), _activos[2], "Llamada falsa solicitando credenciales", Estado.Contenido, 2, 2));
            AltaIncidente(new Phishing("email", true, true, new DateTime(2024, 3, 20), _activos[3], "Email con adjunto malicioso de RRHH", Estado.Contenido, 3, 4));
            AltaIncidente(new Phishing("redes sociales", false, false, new DateTime(2024, 4, 8), _activos[4], "Phishing en redes sociales con sorteo", Estado.EnAnalisis, 2, 3));
            AltaIncidente(new Phishing("email", true, true, new DateTime(2024, 4, 22), _activos[5], "Suplantación del soporte técnico interno", Estado.EnAnalisis, 4, 4));
            AltaIncidente(new Phishing("whatsapp", false, false, new DateTime(2024, 5, 1), _activos[6], "SMS falso de proveedor de pagos", Estado.Abierto, 3, 3));
            AltaIncidente(new Phishing("email", true, true, new DateTime(2024, 5, 15), _activos[7], "Correo falso con factura adjunta", Estado.Abierto, 5, 5));
            AltaIncidente(new Phishing("email", true, true, new DateTime(2024, 6, 3), _activos[8], "Phishing dirigido a gerencia", Estado.Cerrado, 5, 4));
            AltaIncidente(new Phishing("llamada", false, false, new DateTime(2024, 6, 18), _activos[9], "Llamada falsa de soporte Microsoft", Estado.Contenido, 2, 2));
            AltaIncidente(new Phishing("redes sociales", false, false, new DateTime(2024, 7, 7), _activos[10], "Phishing por Instagram a celular gerencia", Estado.Abierto, 3, 3));
            AltaIncidente(new Phishing("email", true, false, new DateTime(2024, 7, 25), _activos[11], "Email falso de actualización de sistema", Estado.EnAnalisis, 4, 3));
            AltaIncidente(new Phishing("whatsapp", false, false, new DateTime(2024, 8, 10), _activos[12], "Phishing por WhatsApp a soporte", Estado.Cerrado, 2, 2));
            AltaIncidente(new Phishing("email", true, true, new DateTime(2024, 8, 28), _activos[13], "Correo falso simulando ser de dirección", Estado.Abierto, 4, 4));
            AltaIncidente(new Phishing("redes sociales", false, false, new DateTime(2024, 9, 5), _activos[14], "Phishing en LinkedIn a tablet logística", Estado.EnAnalisis, 3, 3));

            // 15 Ransomware
            AltaIncidente(new Ramsomware(true, false, new DateTime(2024, 1, 20), _activos[0], "Ransomware cifró archivos de ventas", Estado.Cerrado, 5, 4));
            AltaIncidente(new Ramsomware(true, true, new DateTime(2024, 2, 8), _activos[1], "Ransomware en laptop gerencia", Estado.Cerrado, 5, 5));
            AltaIncidente(new Ramsomware(false, false, new DateTime(2024, 3, 15), _activos[2], "Ransomware en PC recepción", Estado.Contenido, 3, 2));
            AltaIncidente(new Ramsomware(true, true, new DateTime(2024, 4, 1), _activos[3], "Ransomware cifró base contable", Estado.Contenido, 5, 4));
            AltaIncidente(new Ramsomware(false, false, new DateTime(2024, 4, 18), _activos[4], "Ransomware detectado en PC soporte", Estado.EnAnalisis, 3, 3));
            AltaIncidente(new Ramsomware(true, true, new DateTime(2024, 5, 10), _activos[5], "Ransomware en servidor principal", Estado.EnAnalisis, 5, 5));
            AltaIncidente(new Ramsomware(true, false, new DateTime(2024, 5, 28), _activos[6], "Ransomware en servidor backup", Estado.Abierto, 4, 4));
            AltaIncidente(new Ramsomware(true, true, new DateTime(2024, 6, 12), _activos[7], "Ransomware cifró servidor web", Estado.Abierto, 5, 5));
            AltaIncidente(new Ramsomware(true, true, new DateTime(2024, 7, 3), _activos[8], "Ransomware en servidor de base de datos", Estado.Cerrado, 5, 5));
            AltaIncidente(new Ramsomware(false, false, new DateTime(2024, 7, 20), _activos[9], "Ransomware en servidor de correo", Estado.Contenido, 4, 3));
            AltaIncidente(new Ramsomware(true, false, new DateTime(2024, 8, 5), _activos[10], "Ransomware en celular de gerencia", Estado.Abierto, 4, 4));
            AltaIncidente(new Ramsomware(false, false, new DateTime(2024, 8, 22), _activos[11], "Ransomware detectado en celular ventas", Estado.EnAnalisis, 2, 2));
            AltaIncidente(new Ramsomware(false, false, new DateTime(2024, 9, 8), _activos[12], "Ransomware en celular soporte", Estado.Cerrado, 3, 2));
            AltaIncidente(new Ramsomware(true, true, new DateTime(2024, 9, 25), _activos[13], "Ransomware cifró tablet dirección", Estado.Abierto, 4, 5));
            AltaIncidente(new Ramsomware(false, false, new DateTime(2024, 10, 3), _activos[14], "Ransomware en tablet logística", Estado.EnAnalisis, 2, 3));
        }
          
         #endregion





        #region 4a Listar todas las personas con sus activos

        public void ListarPersonasConActivos()
        {
            if (_personas.Count == 0)
            {
                Console.WriteLine("No hay personas registradas.");
                return;
            }

            Console.WriteLine("=== LISTADO DE PERSONAS Y SUS ACTIVOS ===");

            foreach (Persona persona in _personas)
            {
                Console.WriteLine(persona.ToString());

                bool tieneActivos = false;

                foreach (Cuenta cuenta in persona.Cuenta)
                {
                    foreach (Activo activo in cuenta.Activo)
                    {
                        Console.WriteLine($"  - {activo.CrearAlfanumerico()} - {activo.Nombre}"); //aca crea ej pc001 - DELL
                        tieneActivos = true;
                    }
                }

                if (!tieneActivos)
                {
                    Console.WriteLine("  (Sin activos asignados)");
                }

                Console.WriteLine();
            }
        }

        #endregion


        #region 4c Alta
        public void AltaPersona(Persona persona)
        {
            try
            {
                if (persona != null)
                {
                    persona.Validar();

                    if (!_personas.Contains(persona)) //Equals en persona por ci
                    {
                        _personas.Add(persona);
                    }
                    else
                    {
                        throw new Exception("Ya existe esta persona");
                    }
                }
            }
            catch (Exception e) { throw e; }

        }


        #endregion

        #region 4b Listado de incidentes dada una persona

        public List<Incidente> ListarIncidentesPersona(Persona p)
        {
            List<Incidente> aux = new List<Incidente>();

            foreach (Cuenta cuenta in p.Cuenta)
            {
                foreach (Activo activo in cuenta.Activo)
                {
                    foreach (Incidente incidente in _incidentes)
                    {
                        if (incidente.Activo == activo)
                        {
                            aux.Add(incidente);
                        }
                    }
                }
            }
            return aux;
        }
        #endregion

        #region 4d Listar activos que carecen de BackUp

        public List<Activo> ActivosSinBackup()
        {
            List<Activo> aux = new List<Activo>();
            foreach (Activo activo in _activos)
            {
                if (!activo.Backup)
                {
                    aux.Add(activo);
                }
            }
            return aux;
        }

        #endregion

        #region Alta Cuenta, Activo e Incidente

        public void AltaIncidente(Incidente incidente)
        {
            if (!_incidentes.Contains(incidente)) 
            {
                _incidentes.Add(incidente);
            }
            else
            {
                throw new Exception("Ya existe ese incidente");
            }
        }

        private void AltaCuenta(Cuenta cuenta)
        {
            if (cuenta != null)
            {
                cuenta.Validar();

                if (!_cuentas.Contains(cuenta))
                {
                    _cuentas.Add(cuenta);
                }
                else
                {
                    throw new Exception("Ya existe esa cuenta");
                }
            }
        }

        private void AltaActivo(Activo activo)
        {
            if (activo != null)
            {
                activo.Validar();

                if (!_activos.Contains(activo))
                {
                    _activos.Add(activo);
                }
                else
                {
                    throw new Exception("Ya existe ese activo");
                }
            }
        }
        #endregion



    }
}

using System;
using System.Collections.Generic;
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

        #region Corroboracion de cuenta tiene que tener una persona
        private void CuentaTienePersona()
        {
            foreach (Cuenta cuenta in _cuentas)
            {
                bool tienePersona = false;
                foreach (Persona persona in _personas)
                {
                    if (persona.Cuenta.Contains(cuenta))
                    {
                        tienePersona = true;
                        break;
                    }
                }

                if (!tienePersona)
                {
                    throw new Exception("Esta cuenta no tiene persona, no es valido");
                }
            }
        }
        #endregion

        #region PRECARGA DE DATOS
        public void PrecargarDatos()
        {
            PrecargarPersonas();
            PrecargarActivos();
            PrecargarCuentas();
            PrecargarIncidentes();
            CuentaTienePersona();
        }
        private Sistema()  //Constructor de sistema
        {
            PrecargarDatos();
        }
        public static Sistema GetInstancia()   //Patron Singlenton
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
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
            AltaPersona(new Persona(11228344, "Pedro Perez", "pedro.perez@empresa.com", "011100111"));
            AltaPersona(new Persona(41223344, "Jose Munoz", "jose.munoz@empresa.com", "090000211"));
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
            // Cuenta 1 → Persona 0 (Ana García)
            Cuenta c1 = new Cuenta(true, "Pass123!");
            _personas[0].AgregarCuenta(c1);
            AltaCuenta(c1);

            // Cuenta 2 → Persona 1 (Luis Pérez)
            Cuenta c2 = new Cuenta(false, "Clave456!");
            _personas[1].AgregarCuenta(c2);
            AltaCuenta(c2);

            // Cuenta 3 → Persona 2 (María López)
            Cuenta c3 = new Cuenta(true, "Segura789!");
            _personas[2].AgregarCuenta(c3);
            AltaCuenta(c3);

            // Cuenta 4 → Persona 3 (Carlos Rodríguez)
            Cuenta c4 = new Cuenta(false, "Admin2024!");
            _personas[3].AgregarCuenta(c4);
            AltaCuenta(c4);

            // Cuenta 5 → Persona 4 (Laura Martínez)
            Cuenta c5 = new Cuenta(true, "Empresa001!");
            _personas[4].AgregarCuenta(c5);
            AltaCuenta(c5);

            // Cuenta 6 → Persona 5 (Diego Fernández)
            Cuenta c6 = new Cuenta(false, "Usuario555!");
            _personas[5].AgregarCuenta(c6);
            AltaCuenta(c6);

            // Cuenta 7 → Persona 6 (Sofía González)
            Cuenta c7 = new Cuenta(true, "Acceso321!");
            _personas[6].AgregarCuenta(c7);
            AltaCuenta(c7);

            // Cuenta 8 → Persona 7 (Martín Díaz)
            Cuenta c8 = new Cuenta(true, "Sistema789!");
            _personas[7].AgregarCuenta(c8);
            AltaCuenta(c8);

            // Cuenta 9 → Persona 8 (Valentina Torres)
            Cuenta c9 = new Cuenta(false, "Contable11!");
            _personas[8].AgregarCuenta(c9);
            AltaCuenta(c9);

            // Cuenta 10 → Persona 9 (Pablo Sánchez)
            Cuenta c10 = new Cuenta(true, "Gerencia22!");
            _personas[9].AgregarCuenta(c10);
            AltaCuenta(c10);

            // Cuenta 11 → Persona 10 (Pedro Perez)
            Cuenta c11 = new Cuenta(false, "Soporte333!");
            _personas[10].AgregarCuenta(c11);
            AltaCuenta(c11);

            // Cuenta 12 → Persona 11 (Jose Munoz)
            Cuenta c12 = new Cuenta(true, "Ventas4444!");
            _personas[11].AgregarCuenta(c12);
            AltaCuenta(c12);
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
                throw new Exception("No hay personas registradas.");
                return;
            }

            throw new Exception("=== LISTADO DE PERSONAS Y SUS ACTIVOS ===");

            foreach (Persona persona in _personas)
            {
                throw new Exception(persona.ToString());

                bool tieneActivos = false;

                foreach (Cuenta cuenta in persona.Cuenta)
                {
                    foreach (Activo activo in cuenta.Activo)
                    {
                        throw new Exception($"  - {activo.CrearAlfanumerico()} - {activo.Nombre}"); //aca crea ej pc001 - DELL
                        tieneActivos = true;
                    }
                }

                if (!tieneActivos)
                {
                    throw new Exception("  (Sin activos asignados)");
                }

                throw new Exception();
            }
        }

        #endregion


        #region 4c Alta persona
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

        #region 4b Mosttrar inciddente de una persona
        public Persona BuscarPersonaPorCedula(int cedula)
        {
            foreach (Persona p in _personas)
            {
                if (p.Cedula == cedula)
                    return p;
            }
            return null;
        }

        public void MostrarIncidentesPersona(int cedula)
        {
            Persona persona = BuscarPersonaPorCedula(cedula);

            if (persona == null)
            {
                throw new Exception("No se encontro ninguna persona con esa cedula.");
            }
            else
            {
                throw new Exception($"Persona: {persona}");
                List<Incidente> incidentes = persona.ObtenerMisIncidentes(_incidentes);

                if (incidentes.Count == 0)
                {
                    throw new Exception("  (Sin incidentes registrados)");
                }
                else
                {
                    foreach (Incidente inc in incidentes)
                    {
                        // POLIMORFISMO: inc es Incidente pero ejecuta
                        // el ToString() de Phishing o Ransomware segun corresponda
                        throw new Exception(inc.ToString());
                    }
                }
            }
        }
        #endregion

        //#region 4b Listado de incidentes dada una persona

        //public List<Incidente> ListarIncidentesPersona(Persona p)
        //{
        //    List<Incidente> aux = new List<Incidente>();
        //
        //    foreach (Cuenta cuenta in p.Cuenta)
        //    {
        //        foreach (Activo activo in cuenta.Activo)
        //        {
        //            foreach (Incidente incidente in _incidentes)
        //            {
        //                if (incidente.Activo == activo)
        //                {
        //                    aux.Add(incidente);
        //                }
        //            }
        //        }
        //    }
        //    return aux;
        //}


        //#endregion

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

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
        public List<Incidente> Incidentes { get { return new List<Incidente>(_incidentes); } }

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
            PrecargarCuentas();
            PrecargarActivos();
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
            AltaPersona(new Persona(47485283, "Agustina Figueroa", "agustinafigueroacardozo@gmail.com", "099456653"));
            AltaPersona(new Persona(52066838, "Enzo Curbelo", "enzo.curbelo@koin.com.br", "091186172"));

        }


        private void PrecargarActivos()
        {
            Activo a1 = new Activo("Laptop Ventas", TipoActivo.PC, 3, true);
            _cuentas[0].Activo.Add(a1);
            AltaActivo(a1);

            Activo a2 = new Activo("Laptop Gerencia", TipoActivo.PC, 5, true);
            _cuentas[1].Activo.Add(a2);
            AltaActivo(a2);

            Activo a3 = new Activo("PC Recepción", TipoActivo.PC, 1, false);
            _cuentas[2].Activo.Add(a3);
            AltaActivo(a3);

            Activo a4 = new Activo("PC Contabilidad", TipoActivo.PC, 4, true);
            _cuentas[3].Activo.Add(a4);
            AltaActivo(a4);

            Activo a5 = new Activo("PC Soporte", TipoActivo.PC, 2, false);
            _cuentas[4].Activo.Add(a5);
            AltaActivo(a5);

            Activo a6 = new Activo("Servidor Principal", TipoActivo.SERVER, 5, true);
            _cuentas[5].Activo.Add(a6);
            AltaActivo(a6);

            Activo a7 = new Activo("Servidor Backup", TipoActivo.SERVER, 4, true);
            _cuentas[6].Activo.Add(a7);
            AltaActivo(a7);

            Activo a8 = new Activo("Servidor Web", TipoActivo.SERVER, 5, false);
            _cuentas[7].Activo.Add(a8);
            AltaActivo(a8);

            Activo a9 = new Activo("Servidor Base de Datos", TipoActivo.SERVER, 5, true);
            _cuentas[8].Activo.Add(a9);
            AltaActivo(a9);

            Activo a10 = new Activo("Servidor de Correo", TipoActivo.SERVER, 3, false);
            _cuentas[9].Activo.Add(a10);
            AltaActivo(a10);

            Activo a11 = new Activo("Celular Gerencia", TipoActivo.MOVIL, 4, true);
            _cuentas[0].Activo.Add(a11);
            AltaActivo(a11);

            Activo a12 = new Activo("Celular Ventas", TipoActivo.MOVIL, 2, false);
            _cuentas[1].Activo.Add(a12);
            AltaActivo(a12);

            Activo a13 = new Activo("Celular Soporte", TipoActivo.MOVIL, 2, false);
            _cuentas[2].Activo.Add(a13);
            AltaActivo(a13);

            Activo a14 = new Activo("Tablet Dirección", TipoActivo.MOVIL, 3, true);
            _cuentas[3].Activo.Add(a14);
            AltaActivo(a14);

            Activo a15 = new Activo("Tablet Logística", TipoActivo.MOVIL, 1, false);
            _cuentas[4].Activo.Add(a15);
            AltaActivo(a15);
        }

        

        private void PrecargarCuentas()
        {
            Cuenta c1 = new Cuenta(true, "Pass123!");
            _personas[0].AgregarCuenta(c1);
            AltaCuenta(c1);

            Cuenta c2 = new Cuenta(false, "Clave456!");
            _personas[1].AgregarCuenta(c2);
            AltaCuenta(c2);

            Cuenta c3 = new Cuenta(true, "Segura789!");
            _personas[2].AgregarCuenta(c3);
            AltaCuenta(c3);

            Cuenta c4 = new Cuenta(false, "Admin2024!");
            _personas[3].AgregarCuenta(c4);
            AltaCuenta(c4);

            Cuenta c5 = new Cuenta(true, "Empresa001!");
            _personas[4].AgregarCuenta(c5);
            AltaCuenta(c5);

            Cuenta c6 = new Cuenta(false, "Usuario555!");
            _personas[5].AgregarCuenta(c6);
            AltaCuenta(c6);

            Cuenta c7 = new Cuenta(true, "Acceso321!");
            _personas[6].AgregarCuenta(c7);
            AltaCuenta(c7);

            Cuenta c8 = new Cuenta(true, "Sistema789!");
            _personas[7].AgregarCuenta(c8);
            AltaCuenta(c8);

            Cuenta c9 = new Cuenta(false, "Contable11!");
            _personas[8].AgregarCuenta(c9);
            AltaCuenta(c9);

            Cuenta c10 = new Cuenta(true, "Gerencia22!");
            _personas[9].AgregarCuenta(c10);
            AltaCuenta(c10);

            Cuenta c11 = new Cuenta(true, "Contaduria12!");
            _personas[10].AgregarCuenta(c11);
            AltaCuenta(c11);

            Cuenta c12 = new Cuenta(true, "Porteria01!");
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
            AltaIncidente(new Ransomware(true, false, new DateTime(2024, 1, 20), _activos[0], "Ransomware cifró archivos de ventas", Estado.Cerrado, 5, 4));
            AltaIncidente(new Ransomware(true, true, new DateTime(2024, 2, 8), _activos[1], "Ransomware en laptop gerencia", Estado.Cerrado, 5, 5));
            AltaIncidente(new Ransomware(false, false, new DateTime(2024, 3, 15), _activos[2], "Ransomware en PC recepción", Estado.Contenido, 3, 2));
            AltaIncidente(new Ransomware(true, true, new DateTime(2024, 4, 1), _activos[3], "Ransomware cifró base contable", Estado.Contenido, 5, 4));
            AltaIncidente(new Ransomware(false, false, new DateTime(2024, 4, 18), _activos[4], "Ransomware detectado en PC soporte", Estado.EnAnalisis, 3, 3));
            AltaIncidente(new Ransomware(true, true, new DateTime(2024, 5, 10), _activos[5], "Ransomware en servidor principal", Estado.EnAnalisis, 5, 5));
            AltaIncidente(new Ransomware(true, false, new DateTime(2024, 5, 28), _activos[6], "Ransomware en servidor backup", Estado.Abierto, 4, 4));
            AltaIncidente(new Ransomware(true, true, new DateTime(2024, 6, 12), _activos[7], "Ransomware cifró servidor web", Estado.Abierto, 5, 5));
            AltaIncidente(new Ransomware(true, true, new DateTime(2024, 7, 3), _activos[8], "Ransomware en servidor de base de datos", Estado.Cerrado, 5, 5));
            AltaIncidente(new Ransomware(false, false, new DateTime(2024, 7, 20), _activos[9], "Ransomware en servidor de correo", Estado.Contenido, 4, 3));
            AltaIncidente(new Ransomware(true, false, new DateTime(2024, 8, 5), _activos[10], "Ransomware en celular de gerencia", Estado.Abierto, 4, 4));
            AltaIncidente(new Ransomware(false, false, new DateTime(2024, 8, 22), _activos[11], "Ransomware detectado en celular ventas", Estado.EnAnalisis, 2, 2));
            AltaIncidente(new Ransomware(false, false, new DateTime(2024, 9, 8), _activos[12], "Ransomware en celular soporte", Estado.Cerrado, 3, 2));
            AltaIncidente(new Ransomware(true, true, new DateTime(2024, 9, 25), _activos[13], "Ransomware cifró tablet dirección", Estado.Abierto, 4, 5));
            AltaIncidente(new Ransomware(false, false, new DateTime(2024, 10, 3), _activos[14], "Ransomware en tablet logística", Estado.EnAnalisis, 2, 3));
        }

        #endregion

        #region 4a Obtener personas
        public List<Persona> ObtenerPersonasConActivos()
        {
            List<Persona> aux = new List<Persona>();
            {
                return _personas;
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

        #region 4b Mostrar inciddente de una persona
        public Persona BuscarPersonaPorCedula(int cedula)
        {
            foreach (Persona p in _personas)
            {
                if (p.Cedula == cedula)
                    return p;
            }
            return null;
        }

        public List<Incidente> ListarIncidentesPersona(int cedula)
        {
            Persona persona = BuscarPersonaPorCedula(cedula);
            if (persona == null)
            {
                throw new Exception("No existe una persona registrada con esa cedula.");
            }
            return persona.ObtenerMisIncidentes(_incidentes);
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
            if (incidente != null)
            {
                incidente.Validar();
            }
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

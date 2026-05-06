using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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

        #region PRECARGA de DATOS


        //patron Singleton
        public void PrecargarDatos()
        {
            PrecargarActivos();
            PrecargarCuentas();
            PrecargarPersonas();
        }

       
        public static Sistema GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }
        private void PrecargarActivos()
        {
            throw new NotImplementedException();
        }

        private void PrecargarCuentas()
        {
            throw new NotImplementedException();
        }

        private void PrecargarPersonas()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Alta
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
}
}

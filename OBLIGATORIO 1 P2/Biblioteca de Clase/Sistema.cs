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
        public static Sistema GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }
        #endregion


        #region Alta
        public void AltaPersona(Persona persona)
        {
            persona.Validar();

            //validamos que la cedula sea unica
            foreach (Persona p in _personas)
            {
                if (p.Cedula == persona.Cedula)
                {
                    throw new Exception($"Ya existe una persona con cedula {persona.Cedula}");
                }
            }
            _personas.Add(persona);
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

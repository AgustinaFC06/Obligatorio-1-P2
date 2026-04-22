using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Sistema
    {
        #region LISTAS
        private List<Persona> _personas { get; }=new List<Persona>();
        private List<Cuenta> _cuentas { get; } =new List<Cuenta>();
        private List<Activo>_activos { get; }= new List<Activo>();
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



    }
}

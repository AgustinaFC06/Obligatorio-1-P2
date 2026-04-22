using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Sistema
    {
        #region LISTAS
        private List<Persona> _personas { get; }=new List<Persona>();
        private List<Cuenta> _Cuentas { get; } =new List<Cuenta>();
        private List<Activo>_Activos { get; }= new List<Activo>();
        private List<Incidente> _Incidentes { get; } = new List<Incidente>();
        private static Sistema _instancia;
        #endregion

        #region PRECARGA de DATOS
        #endregion



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


    }
}

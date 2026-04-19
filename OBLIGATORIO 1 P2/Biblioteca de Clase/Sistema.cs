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


    }
}

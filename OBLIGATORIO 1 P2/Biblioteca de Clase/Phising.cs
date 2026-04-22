using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Phising : Incidente
    {
        #region GET and SET
        public string Canal { get; set; }
        public bool Credenciales { get; set; }
        public bool TransferenciaDatos { get; set; }

        #endregion

        #region CONSTRUCTOR
        public Phising(){}

        public Phising(string canal, bool credenciales, bool transferenciaDatos, DateTime fechaReporte, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad) :base (fechaReporte,  activo,  descripcion, estado, impacto, probabilidad)
        {
            Canal = canal;
            Credenciales = credenciales;
            TransferenciaDatos = transferenciaDatos;
        }

        #endregion

        #region
        #endregion
    }
}

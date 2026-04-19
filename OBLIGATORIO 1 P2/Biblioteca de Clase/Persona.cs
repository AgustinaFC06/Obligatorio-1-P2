using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    internal class Persona
    {
        #region GET and SET
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        private List<Cuenta>_cuentas {  get; }= new List<Cuenta>();
        #endregion

        #region CONSTRUCTOR
        #endregion
    }
}

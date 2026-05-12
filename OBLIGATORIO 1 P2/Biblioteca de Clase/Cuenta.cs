using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Cuenta : IValidable
    {
        #region GET and SET
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public bool Mfa { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaUltimoCambioPassword { get; set; }
        private List<Activo> _activos { get; } = new List<Activo>();
        public List<Activo> Activo { get { return _activos; } }


        #endregion

        #region CONSTRUCTORES
        public Cuenta()
        {
            Id = UltimoId++;
            FechaUltimoCambioPassword = DateTime.Now; ////?????

        }

        public Cuenta(bool mfa, string contrasena)
        {
            Id = UltimoId++;
            Mfa = mfa;
            Contrasena = contrasena;
            FechaUltimoCambioPassword = DateTime.Now;
            Validar();
        }
                 

        #endregion

        #region VALIDACIONES
        public void Validar()
        {
            ValidarContrasena();
        }

        private void ValidarContrasena()
        {
            if (string.IsNullOrWhiteSpace(Contrasena))
            {
                throw new Exception("No puede ser vacio");
            }
        }
        #endregion

        #region    
        #endregion

    }
}

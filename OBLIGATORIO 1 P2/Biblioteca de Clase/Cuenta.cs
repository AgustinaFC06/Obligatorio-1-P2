using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Cuenta
    {
        #region GET and SET
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public bool Mfa { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaUltimoCambioPassword { get; set; }
        private List<Activo> _activos { get; } = new List<Activo>();

        #endregion

        #region CONSTRUCTORES
        public Cuenta()
        {
            Id = UltimoId++;
        }

        public Cuenta(bool mfa, string contrasena, DateTime fechaUltimoCambioPassword, List<Activo> activos)
        {
            Id = UltimoId++;
            Mfa = mfa;
            Contrasena = contrasena;
            FechaUltimoCambioPassword = fechaUltimoCambioPassword;
            _activos = activos;
            Validar();
        }
                 

        #endregion

        #region VALIDACIONES
        private void Validar()
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

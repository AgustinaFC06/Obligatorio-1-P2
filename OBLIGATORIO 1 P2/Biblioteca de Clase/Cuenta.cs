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
        public DateTime FechaUltimoCambioPassword { get; set; }
        private List<Activo> _activos { get; } = new List<Activo>();
        public List<Activo> Activos { get { return _activos; } }


        #endregion

        #region CONSTRUCTORES
        public Cuenta(DateTime fechaUltimoCambioPassword)
        {
            Id = UltimoId++;
            FechaUltimoCambioPassword = fechaUltimoCambioPassword; //// fechas ponesrlas a mano para que no queden todas con la misma fecha 

        }

        public Cuenta(bool mfa, DateTime fechaUltimoCambioPassword)
        {
            Id = UltimoId++;
            Mfa = mfa;
            FechaUltimoCambioPassword = fechaUltimoCambioPassword;
        }


        #endregion

        #region   Equals
        public override bool Equals(object? obj)
        {
            return obj is Cuenta cuenta &&
                Id == cuenta.Id;
        }
        #endregion

        #region IValidable
        public void Validar()
        {
            // la cuenta no valida contrasena porque ahora esta en persona
        }
        #endregion


    }
}

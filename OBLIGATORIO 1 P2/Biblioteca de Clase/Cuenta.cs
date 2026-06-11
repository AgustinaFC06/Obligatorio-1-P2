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
        //public string Contrasena { get; set; }
        public DateTime FechaUltimoCambioPassword { get; set; }
        private List<Activo> _activos { get; } = new List<Activo>();
        public List<Activo> Activos { get { return _activos; } } /// nombre de la listas en plural
        // Alias para mantener compatibilidad con el resto del código que usa `cuenta.Activo`
        public List<Activo> Activo { get { return _activos; } }


        #endregion

        #region CONSTRUCTORES
        public Cuenta(DateTime fechaPassword)
        {
            Id = UltimoId++;
            FechaUltimoCambioPassword = fechaPassword; //// fechas ponesrlas a mano para que no queden todas con la misma fecha 

        }

        public Cuenta(bool mfa, string contrasena)
        {
            Id = UltimoId++;
            Mfa = mfa;
            //Contrasena = contrasena;
            FechaUltimoCambioPassword = DateTime.Now;
            //Validar();
        }


        #endregion

        #region VALIDACIONES
        // public void Validar() ESTO SE VE PORQUE CONTRASEÑA ESTA EN PERSONA
        // {
        //     ValidarContrasena();
        // }
        //
        // private void ValidarContrasena()
        // {
        //     if (string.IsNullOrWhiteSpace(Contrasena))
        //     {
        //         throw new Exception("No puede ser vacio");
        //     }
        // }
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
            // Validación mínima: la cuenta es válida por estructura.
            // Si en el futuro se requiere validar contraseña u otros datos,
            // implementar las comprobaciones correspondientes aquí.
        }
        #endregion


    }
}

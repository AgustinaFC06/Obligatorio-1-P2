using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Persona
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
        public Persona()
        {
            Id = UltimoId++;
            _cuentas = new List<Cuenta>();
        }

        public Persona(int cedula, string nombre, string email, string telefono, List<Cuenta> cuentas)
        {   
            Id = UltimoId++;
            Cedula = cedula;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            _cuentas = cuentas;
            Validar();
        }       
         #endregion

        #region VALDACIONES
        public void Validar()
        {
            ValidarCedula();
            ValidalNombre();
            ValidarEmail();
            ValidarTelefono();
        }

        private void ValidarTelefono()
        { 
            if (string.IsNullOrWhiteSpace(Telefono))
            throw new Exception("El telefono no puede ser vacio");
        }

        private void ValidarEmail()
        { 
        
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            throw new Exception("Email tiene que contener @ y no puede ser vacio");
        }

        private void ValidalNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new Exception("Nombre no puede ser vacio");            
            }
        }

        private void ValidarCedula() //hacer unica
        {
            if (Cedula >= 0)
            {
                throw new Exception("No puede ser vacia");  
            }
        }



        public void AgregarCuenta(Cuenta cuenta)
        {
            if(cuenta != null || !_cuentas.Contains(cuenta))
            {
                _cuentas.Add(cuenta); 
            }
        }

        public override string ToString()
        {
            return $"[{Id}] {Nombre} - CI: {Cedula} - {Email} - Tel: {Telefono}";
        }

        #endregion

        #region Equals
        public override bool Equals(object? obj)
        {
            return obj is Persona persona &&
                Cedula == persona.Cedula;
        }


        #endregion

    }
}

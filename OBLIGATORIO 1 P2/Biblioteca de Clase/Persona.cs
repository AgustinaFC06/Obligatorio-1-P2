using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Persona : IValidable
    {
        #region GET and SET
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public TipoUsuario Rol {  get; set; }
        private List<Cuenta>_cuentas {  get; }= new List<Cuenta>();
        public List<Cuenta> Cuentas { get { return new List<Cuenta>(_cuentas); } }


        #endregion

        #region CONSTRUCTOR
        public Persona()
        {
            Id = UltimoId++;
        }

        public Persona(int cedula, string nombre, string email, string telefono, string contrasena)
        {   
            Id = UltimoId++;
            Cedula = cedula;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            Contrasena = contrasena;
            Rol = TipoUsuario.Operador; 
            Validar();
        }       
         #endregion

        #region VALDACIONES
        public void Validar()
        {
            ValidarCedula();
            ValidarNombre();
            ValidarEmail();
            ValidarTelefono();
            ValidarContrasena();
        }

        private void ValidarCedula() //hacer unica
        {
            if (Cedula <= 0)
            {
                throw new Exception("Ingrese la cedula");
            }
        }
        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new Exception("Nombre no puede ser vacio");
            }
        }
        private void ValidarEmail()
        {

            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                throw new Exception("Email tiene que contener @ y no puede ser vacio");
            }

        }

        private void ValidarTelefono()
        { 
            if (string.IsNullOrWhiteSpace(Telefono))
            {
                throw new Exception("El telefono no puede ser vacio");
            }
            
        }
           
               
          private void ValidarContrasena()
        {
            if (string.IsNullOrWhiteSpace(Contrasena))
            {
                throw new Exception("La contraseña no puede ser vacio");
            }
        }

        #endregion

        #region AgregarCuenta
        public void AgregarCuenta(Cuenta cuenta) //??????????
        {
            if(cuenta != null && !_cuentas.Contains(cuenta))
            {
                _cuentas.Add(cuenta); 
            }
        }
        #endregion

        #region ToString 
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

        #region 4B Encapsulamiento
        
        public List<Incidente> ObtenerMisIncidentes(List<Incidente> todosLosIncidentes)
        {
            List<Incidente> listRet = new List<Incidente>();

            
            foreach (Cuenta c in this.Cuentas) 
            {                
                foreach (Activo a in c.Activos)  
                {                    
                    foreach (Incidente i in todosLosIncidentes)
                    {                        
                        if (i.Activo != null && i.Activo.Equals(a))   // Persona filtra sus propios incidentes
                        {
                            listRet.Add(i);
                        }
                    }
                }
            }
            return listRet;
        }
        #endregion

    }
}
  

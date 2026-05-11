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
        private List<Cuenta>_cuentas {  get; }= new List<Cuenta>();
        public List<Cuenta> Cuenta { get { return _cuentas; } }


        #endregion

        #region CONSTRUCTOR
        public Persona()
        {
            Id = UltimoId++;
        }

        public Persona(int cedula, string nombre, string email, string telefono)
        {   
            Id = UltimoId++;
            Cedula = cedula;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
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

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new Exception("Nombre no puede ser vacio");            
            }
        }

        private void ValidarCedula() //hacer unica
        {
            if (Cedula <= 0)
            {
                throw new Exception("No puede ser vacia");  
            }
        }



        public void AgregarCuenta(Cuenta cuenta)
        {
            if(cuenta != null && !_cuentas.Contains(cuenta))
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

        #region 4B con Polimorfismo
        
        public List<Incidente> ObtenerMisIncidentes(List<Incidente> todosLosIncidentes)
        {
            List<Incidente> listRet = new List<Incidente>();

            
            foreach (Cuenta c in this.Cuenta) // Recorremos las cuentas de la persona
            {                
                foreach (Activo a in c.Activo)  // Recorremos los activos de cada cuenta
                {                    
                    foreach (Incidente i in todosLosIncidentes)  // Recorremos la lista total de incidentes
                    {                        
                        if (i.Activo != null && i.Activo.Equals(a))  // POLIMORFISMO: a) El 'i' puede ser Phishing o Ransomware, pero comparamos su propiedad 'Activo' b) que es común a todos los Incidentes.
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

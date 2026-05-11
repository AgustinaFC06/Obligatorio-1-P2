using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    #region GET and SET

    public abstract class Incidente : IValidar
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public DateTime FechaReporte { get; set; }
        public Activo Activo { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
        public int Impacto { get; set; }
        public int Probabilidad { get; set; }


        #endregion

        #region CONSTRUCTORES 
        public Incidente()
        {
            Id = UltimoId++;
            FechaReporte = DateTime.Now; 
        }

        public Incidente(DateTime fechaReporte, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad)
        {
            Id = UltimoId++;
            FechaReporte = DateTime.Now;
            Activo = activo;
            Descripcion = descripcion;
            Estado = estado;
            Impacto = impacto;
            Probabilidad = probabilidad;
            Validar();
        }


        #endregion

        #region METODOS

        public void Validar()
        {
            ValidarDescripcion();
            ValidarImpacto();
            ValidarProbabilidad();
           
        }

        private void ValidarDescripcion()
        {
            if (Descripcion == null)
            {
                throw new Exception("La descripcion no puede ser vacia");
            }

        }


        private void ValidarImpacto()
        {
            if (Impacto < 1 || Impacto > 5)
            {
                throw new Exception("Impacto debe estar entre 1 y 5");
            }
        }

        private void ValidarProbabilidad()
        {
            if (Probabilidad  < 1 || Probabilidad > 5)
            {
                throw new Exception("Probabilidad debe estar entre 1 y 5");
            }
        }


        public virtual double CalcularSeveridad()
        {
            throw new Exception("Se aplicara en la segunda entrega");
        }


        #endregion

        #region       
        #endregion
    }
}
 
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    public abstract class Incidente
    {
        #region GET adn SET
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public DateTime FechaReporte { get; set; }
        public Activo Activo { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
        public int Impacto { get; set; }
        public int Probabilidad { get; set; }

        protected Incidente()
        {
            Id = UltimoId++;
        }

        protected Incidente(DateTime fechaReporte, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad)
        {
            Id = UltimoId++;
            FechaReporte = fechaReporte;
            Activo = activo;
            Descripcion = descripcion;
            Estado = estado;
            Impacto = impacto;
            Probabilidad = probabilidad;
        }


        #endregion

        #region 


        #endregion
    }
}

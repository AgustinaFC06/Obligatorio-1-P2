using Biblioteca_de_Clase;

namespace WebApp.Models
{
    public class IncidenteListadoViewModel
    {
        public int Id { get; set; }
        public DateTime FechaReporte { get; set; }
        public Estado Estado { get; set; }
        public string CodigoActivo { get; set; } = "";
        public double Severidad { get; set; }
    }
}

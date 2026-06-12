using Biblioteca_de_Clase;

namespace WebApp.Models
{
    public class CrearActivoViewModel
    {
        public int Cedula { get; set; }
        public int CuentaId { get; set; }
        public string NombrePersona { get; set; } = "";
        public string Nombre { get; set; } = "";
        public TipoActivo TipoActivo { get; set; }
        public int Criticidad { get; set; }
        public bool Backup { get; set; }
    }
}

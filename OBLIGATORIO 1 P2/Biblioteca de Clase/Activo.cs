using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Activo
    {
        #region GET and SET
        public int Id { get; set; }
        public static int UltimoId { get; set; } = 1;
        public string Nombre { get; set; }
        public TipoActivo TipoActivo { get; set; }
        public int Criticidad { get; set; }
        public bool Backup { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Activo()
        {
            Id = UltimoId++;
        }

        public Activo(string nombre, TipoActivo tipoActivo, int criticidad, bool backup)
        {
            Id = UltimoId++;
            Nombre = nombre;
            TipoActivo = tipoActivo;
            Criticidad = criticidad;
            Backup = backup;
        }
        #endregion

        #region VALIDACIONES
        public void Validar()
        { ValidarNombre(); }

        private void ValidarNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new Exception("Nombre no puede ser vacio");
            }
        }

        private void ValidarCriticidad()
        {
            if (Criticidad > 5 || Criticidad < 1)
            {
                throw new Exception("Criticidad debe de ser entre 1 y 5");
            }
        }

        #endregion

        #region
        #endregion

    }
}

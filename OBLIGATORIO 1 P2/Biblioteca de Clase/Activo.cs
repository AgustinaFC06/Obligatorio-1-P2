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
        public TipoActivo TipoActibvo { get; set; }
        public int Criticidad { get; set; }
        public bool Backup { get; set; }
        #endregion

        #region CONSTRUCTORES
        public Activo()
        {
            Id = UltimoId++;
        }

        public Activo(string nombre, TipoActivo tipoActibvo, int criticidad, bool backup)
        {
            Id = UltimoId++;
            Nombre = nombre;
            TipoActibvo = tipoActibvo;
            Criticidad = criticidad;
            Backup = backup;
        }
        #endregion

        #region VALIDACIONES
        public void ValidarNombre()
        { ValidarNombre(); }

        private void ValidalNombre()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new Exception("Nombre no puede ser vacio");
            }
        }

        #endregion

        #region
        #endregion

    }
}

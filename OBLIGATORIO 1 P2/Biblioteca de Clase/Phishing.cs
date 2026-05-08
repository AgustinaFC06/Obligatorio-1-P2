using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Phishing : Incidente
    {
        #region GET and SET
        public string Canal { get; set; }
        public bool Credenciales { get; set; }
        public bool TransferenciaDatos { get; set; }

        #endregion

        #region CONSTRUCTOR
        public Phishing(){}

        public Phishing(string canal, bool credenciales, bool transferenciaDatos, DateTime fechaReporte, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad) :base (fechaReporte,  activo,  descripcion, estado, impacto, probabilidad)
        {
            Canal = canal;
            Credenciales = credenciales;
            TransferenciaDatos = transferenciaDatos;
        }

        #endregion

#region METODOS

        public void Validar()
        {
            ValidarCanal();
        }

        private void ValidarCanal()
        {
            if (string.IsNullOrWhiteSpace(Canal))
            {
                throw new Exception("Canal no puede ser vacío ni nulo.");
            }
        }

        public override string ToString()
        {
            return $"[{Id}] Phising - {Descripcion} - Estado: {Estado} - Canal: {Canal}";
        }
        #endregion

    }
}

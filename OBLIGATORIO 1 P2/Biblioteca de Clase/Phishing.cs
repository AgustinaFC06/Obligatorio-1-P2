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
           Validar();
        }

        #endregion

        #region Validar

        public override void Validar()
        {
            base.Validar();
            ValidarCanal();
        }

        private void ValidarCanal()
        {
            if (string.IsNullOrWhiteSpace(Canal))
            {
                throw new Exception("Canal no puede ser vacío ni nulo.");
            }
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return $"Phishing ({base.ToString()},- {Descripcion} - Canal: {Canal}";
        }
        #endregion

        #region Calcular Severidad
        public override double CalcularSeveridad()
        {
            double severidad = base.CalcularSeveridad();
            if (severidad > 100) severidad = 100; // Phishing no tiene ajustes adicionales, solo aplica el tope de 100
            
                return severidad;
            
        }
        #endregion

    }
}

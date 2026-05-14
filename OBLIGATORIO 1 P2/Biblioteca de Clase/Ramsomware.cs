using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Ramsomware : Incidente
    {
        #region Get and Set
        public bool Encriptados { get; set; }
        public bool Exfiltracion { get; set; }

        #endregion

        #region CONSTRUCTORES
        public Ramsomware(){}

        public Ramsomware(bool encriptados, bool exfiltracion, DateTime fechaReporte, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad) :base ( fechaReporte,  activo,  descripcion,  estado,  impacto,  probabilidad)
        {
            Encriptados = encriptados;
            Exfiltracion = exfiltracion;
        }
        #endregion

        #region Metodos

        public override double CalcularSeveridad()
        {
            throw new Exception("Se hara en segunda entrega");
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return $"[{Id}] Ransomware - {Descripcion} - Estado: {Estado} - Encriptados: {(Encriptados ? "Si" : "No")}";
        }
        #endregion

    }

}

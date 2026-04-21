using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_de_Clase
{
    internal class Ramsomweare : Incidente
    {
        public bool Encriptados { get; set; }
        public bool Exfiltracion { get; set; }

        public Ramsomweare(){}

        public Ramsomweare(bool encriptados, bool exfiltracion, DateTime fechaReporte, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad) :base ( fechaReporte,  activo,  descripcion,  estado,  impacto,  probabilidad)
        {
            Encriptados = encriptados;
            Exfiltracion = exfiltracion;
        }
    }

}

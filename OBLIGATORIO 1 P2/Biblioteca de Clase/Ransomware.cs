using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Biblioteca_de_Clase
{
    public class Ransomware : Incidente
    {
        #region Get and Set
        public bool Encriptados { get; set; }
        public bool Exfiltracion { get; set; }

        #endregion

        #region CONSTRUCTORES
        public Ransomware(){}

        public Ransomware(bool encriptados, bool exfiltracion, DateTime fechaReporte, Activo activo, string descripcion, Estado estado, int impacto, int probabilidad) :base ( fechaReporte,  activo,  descripcion,  estado,  impacto,  probabilidad)
        {
            Encriptados = encriptados;
            Exfiltracion = exfiltracion;
            
        }
        #endregion   
        
        #region ToString
        public override string ToString()
        {
            return $"[{Id}] Ransomware - {base.ToString()} - Encriptados: {(Encriptados ? "Si" : "No")} - Exfiltrados: {(Exfiltracion ? "Si" : "No")}";
        }
        #endregion

        #region Calcular Severidad
        public override double CalcularSeveridad()
        {
            double severidad = base.CalcularSeveridad();
            if (Encriptados)
            { severidad += 20; } //Si los datos estan encriptados se suma 20

            if ( Exfiltracion ) 
            {severidad += 25; } //Si hubo exfiltracion se suma 25
            if (Activo != null && Activo.Backup)
            {severidad -= 15; } //Si el activo tien backup se resta 15
            if (severidad > 100) 
            {severidad = 100; } // Tope maximo de 100
            return severidad;
        }
        #endregion

    }

}

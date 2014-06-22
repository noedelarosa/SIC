using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TiempoSolicitudSeguroFunerario
    {
        public tsolicitudfunenario Solicitud { get; set; }
        private GrupoTiempoSeguroFunerario _grupo = GrupoTiempoSeguroFunerario.GetInstance();
        public List<STiempos> Tiempos { get; set; }
        
        /// <summary>
        /// Indica el Total del Proceso de todas las tareas.
        /// </summary>
        public int TotalProcesos { get; set; }
        public int TiempoGlobal { get; set; }
        public int DiferenciaTiempos { get; set; }
        public double DiferenciaTiemposPorciento { get; set; }

        private int Calculo_TiempoGlobal(){
            
            if(Solicitud != null){
                System.TimeSpan tiempo = Empresa.Comun.Server.DameTiempo() - this.Solicitud.FechaEntrada;

                if((this.TotalProcesos - tiempo.Days) < 0){
                    //negativo 
                    return 0;
                }
                else {
                    return this.TotalProcesos - tiempo.Days;
                }

            }
            else{
                return 0;
            }

        }

        public string EtiquetaTiempos
        {
            get
            {
                return this.DiferenciaTiempos.ToString() + "/" + this.TotalProcesos.ToString();
            }
        }


        public TiempoSolicitudSeguroFunerario(){
        
        
        }

        public TiempoSolicitudSeguroFunerario(tsolicitudfunenario item){
            this.Solicitud = item;
            this.Tiempos = new List<STiempos>();

            //Inicializando Total del proceso en tiempos globales.
            this.TotalProcesos = this._grupo.TotalProceso;
            this.TiempoGlobal = this.Calculo_TiempoGlobal();
            
            this.DiferenciaTiempos = Math.Abs(this.TotalProcesos - TiempoGlobal);
            this.DiferenciaTiemposPorciento = ((double)DiferenciaTiempos / (double)this.TotalProcesos) * 100.00;


        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public struct STiempos{
        public TGrupoTiempos Tiempo { get; set; }
        public int Diferencia { get; set; }
    };

    public class TiemposSolicitud{

        public tsolicitudpj Solicitud {get; set;}
        private GrupoTiempos g = GrupoTiempos.GetInstance();
        public List<STiempos> Tiempos {get;set;}

        public TiemposSolicitud(tsolicitudpj item){
            this.Solicitud = item;
            this.Tiempos = new List<STiempos>();
            
            //Inicializando Total del proceso en tiempos globales.
            this.TotalTiempoGlobal = g.TotalProceso;

            foreach(TPasospjAsignados itemc in item.Pasos.Lista) {
                if (itemc.EsActivo){
                    STiempos t = new STiempos();
                    t.Tiempo = itemc.Paso.GrupoTiempo;

                    TimeSpan sp = Empresa.Comun.Server.DameTiempo() - itemc.Fecha;
                    t.Diferencia = itemc.Paso.GrupoTiempo.Valor - sp.Days;   
                    this.Tiempos.Add(t);
                }
            }

            this.TiempoGlobal = this.Calculo_TiempoGlobal();

            this.DiferenciaTiempos = Math.Abs(this.TotalTiempoGlobal - TiempoGlobal);
            this.DiferenciaTiemposPorciento = ((double)DiferenciaTiempos / (double)this.TotalTiempoGlobal) * 100.00;
        }

        private int Calculo_TiempoGlobal() { 

            if(Solicitud != null){
                    GrupoTiempos g = GrupoTiempos.GetInstance();
                    System.TimeSpan tiempo = Empresa.Comun.Server.DameTiempo() - this.Solicitud.Fecha;

                    if ((g.TotalProceso - tiempo.Days) < 0)
                    {
                        //negativo 
                        return 0;
                    }
                    else
                    {
                        return g.TotalProceso - tiempo.Days;
                    }
                }
                else {
                    return 0;
                }
        }

        public int TiempoGlobal{get;set;}
        public int TotalTiempoGlobal { get;set; }
        public int DiferenciaTiempos { get;set; }
        public double DiferenciaTiemposPorciento{get;set;}

        public string EtiquetaTiempos {
            get 
            {
                return this.DiferenciaTiempos.ToString() + "/" + this.TotalTiempoGlobal.ToString();
            }
        }

        public TiemposSolicitud(){
            //this.Solicitud = new tsolicitudpj();
            this.Tiempos = new List<STiempos>();
        }


    }
}

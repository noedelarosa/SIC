using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


namespace Empresa.Citas
{
    public class TCitasVisitas {

        public int Id { get; set; }

        public RHH.tpersonal Visitante { get; set;      }
        public Empresa.RHH.tpersonal Personal { get; set;}
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set;  }
        public Comun.TEstandar Estado { get; set;}
        public ObservableCollection<tvaloracion> Valoracion { get; set;}
        
        public string Referencia { get; set;     }
        public TMotivoVisitas Motivo { get; set;}
        public RHH.TDepartamento Departamento { get; set;}
        public string Numero { get; set; }

        public int ExisteHistorico { get; set; }

        public TimeSpan TiempoAtension {
            get {
                return FechaSalida - FechaEntrada;
                
            }
        }


        public TCitasVisitas(){
            this.Id = 0;
            this.Visitante = new RHH.tpersonal();
            this.Personal = new RHH.tpersonal();
            this.Personal.Departamento = new RHH.TDepartamento();

            this.FechaEntrada = DateTime.MinValue;
            this.FechaSalida = DateTime.MaxValue;
            this.Estado = new Comun.TEstandar();
            this.Valoracion = new Empresa.Citas.Valoraciones().Lista;
            this.Referencia = string.Empty;
            this.Departamento = new RHH.TDepartamento();
        }

        public TCitasVisitas(int id) {
            this.Id = id;
            this.Visitante = new RHH.tpersonal();
            this.Personal = new RHH.tpersonal();
            this.FechaEntrada = DateTime.MinValue;
            this.FechaSalida = DateTime.MaxValue;
            this.Estado = new Comun.TEstandar();
            this.Valoracion = new Empresa.Citas.Valoraciones().Lista;
            this.Referencia = string.Empty;
            this.Departamento = new RHH.TDepartamento();
        }

        public TCitasVisitas(RHH.tpersonal visitante)
        {
            this.Id = 0;
            this.Visitante = visitante;
            this.Personal = new RHH.tpersonal();
            this.FechaEntrada = DateTime.MinValue;
            this.FechaSalida = DateTime.MaxValue;
            this.Estado = new Comun.TEstandar();
            this.Valoracion = new Empresa.Citas.Valoraciones().Lista;
            this.Referencia = string.Empty;
            this.Departamento = new RHH.TDepartamento();
        }

    }
}

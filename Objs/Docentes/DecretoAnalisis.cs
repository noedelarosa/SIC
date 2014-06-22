using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DecretoAnalisis{

        public int Repetidos {get; set;}
        public int Duplicados { get; set; }
        public int PromedioEdad { get; set; }
        public double TotalSueldos { get; set; }
        public double PromedioSueldos { get; set; }
        
        public int CantidadNectaDocente {
            get {
                return this.Docentes.Count - this.Repetidos;
            }
        }

        public ObservableCollection<Empresa.Docente.tdocente> Docentes { get; set; }
        public Empresa.Docente.TDecreto Decreto { get; set; }

        public DecretoAnalisis(ObservableCollection<Empresa.Docente.tdocente> docentes, Empresa.Docente.TDecreto decreto){
            this.Docentes = docentes;
            this.Decreto = decreto;
            __duplicados();
            __repetidos();
            __promedioedad();
            __montototalsueldopromedios();
        }

        private void __repetidos() {
            string cedula = string.Empty;
            foreach (tdocente item in this.Docentes){
                if (item.Cedula.Equals(cedula)) this.Repetidos += 1;
                   cedula = item.Cedula;
            }
        }
        
        private void __duplicados(){
            string cedula = string.Empty;
            double sueldo =0;
            Empresa.RHH.testadolaboral estadolaboral = new RHH.testadolaboral();

            foreach (tdocente item in this.Docentes){
                if (item.Cedula.Equals(cedula) && item.DecretoActual.Monto.Equals(sueldo) && item.DecretoActual.Estado.Id.Equals(estadolaboral.Id)) this.Duplicados += 1;
                cedula = item.Cedula;
                sueldo = item.DecretoActual.Monto;
                estadolaboral = item.DecretoActual.Estado;
            }

        }
        
        private void __promedioedad(){
            int suma =0 ;
            int cantidad =0;

            foreach(tdocente item in this.Docentes){
                suma += item.Edad;
                cantidad += 1;
            }

            if(cantidad != 0) this.PromedioEdad = suma / cantidad;
        }

        private void __montototalsueldopromedios() {
            double sueldototal = 0;

            int conteo = 0;
            foreach (tdocente item in this.Docentes) {
                foreach (TDecretoDocente itemd in item.Decretos) {
                    if (itemd.Decreto.Numero.Equals(this.Decreto.Numero)) {
                        sueldototal += itemd.Monto;
                        conteo += 1;
                    }    
                }
            }

            this.TotalSueldos = sueldototal;
            this.PromedioSueldos = TotalSueldos / conteo;
        }

        public DecretoAnalisis() { 
        


        }



    }
}

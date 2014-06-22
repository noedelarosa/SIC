using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class TNomina {
        public ObservableCollection<tdocente> Docentes { get; set; }
        
        //definido para el docente como ESTADO en la nomina
        public Empresa.RHH.testadolaboral Tipo { get; set; }
        public DateTime Fecha { get; set; }
        
        public int ConteoDocentes{
            get {
                return this.Docentes.Count;
            }
        }

        public double TotalSueldos {
            get {
                double valor = 0;

                foreach(tdocente item in this.Docentes){
                   
                    //item.HistorialPagos.Lista[0].MontoBruto 

                }
                //this.Docentes.Sum(ss => ss.HistorialPagos.
                return valor;
            }
        }

        public double Promedio {
            get {
                return (this.TotalSueldos / Convert.ToDouble(this.ConteoDocentes));
            }
        }
        
        public TNomina() {
            this.Docentes = new ObservableCollection<tdocente>();
        }

        public TNomina(int id) {
            this.Docentes = new ObservableCollection<tdocente>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class Tanda
    {
        //Listado de Tandas
        public ObservableCollection<ttanda> Lista { get; set; }

        //Suma de tandas
        public ttanda Tandas {
            get {
                return new ttanda();
            }

            private set {
            
            }
        }

        private Empresa.Docente.PagoDetalle pagos;
        public Tanda(tdocente item){
            pagos = new Empresa.Docente.PagoDetalle(item.Cedula);
            int numerotanda = 0;
            foreach (TPagoDetalle pago in pagos.Lista){ 
                //numerotanda 
                

            }
        }

        public Tanda(string cedula){



        }



    }
}

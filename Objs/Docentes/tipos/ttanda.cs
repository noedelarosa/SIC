using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class ttanda {
        
        //Codigo de Tanda
        public int Codigo { get; set; }
        //Lista de Descuentos
        public ObservableCollection<TPagoDetalle> Lista { get; set; }

        public ttanda() {
            this.Codigo = 0;
            this.Lista = new ObservableCollection<TPagoDetalle>();
        }

        public ttanda(int codigo, ObservableCollection<TPagoDetalle> ingreso_egresos){
            this.Codigo = 0;
            this.Lista = ingreso_egresos;
        }

    }
}

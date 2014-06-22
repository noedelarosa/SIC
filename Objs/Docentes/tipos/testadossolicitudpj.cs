using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class testadossolicitudpj {

        public testadopj Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public testadossolicitudpj(){
            //this.Id = 0;
            this.Estado = new testadopj();
            this.Fecha = DateTime.MinValue;
            this.Descripcion = string.Empty;
        }

        public testadossolicitudpj(testadopj estado){
           // this.Id = 0;
            this.Estado = estado;
            this.Fecha = DateTime.MinValue;
            this.Descripcion = string.Empty;
        } 
    }
}

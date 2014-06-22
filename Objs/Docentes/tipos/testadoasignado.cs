using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class testadoasignado{
        public int Id { get; set; }
        public Empresa.Comun.TEstandar Estado { get; set; }
        public DateTime Fecha { set;get;}
        public string Descripcion { get; set; }

        public testadoasignado() {
            this.Id = 0;
            this.Estado = new Comun.TEstandar();
            this.Fecha = DateTime.MinValue;
            this.Descripcion = string.Empty;
        }

        public testadoasignado(int id)
        {
            this.Id = id;
            this.Estado = new Comun.TEstandar();
            this.Fecha = DateTime.MinValue;
            this.Descripcion = string.Empty;
        }

        public testadoasignado(Comun.TEstandar estado)
        {
            this.Id = 0;
            this.Estado = estado;
            this.Fecha = DateTime.MinValue;
            this.Descripcion = string.Empty;
        }


    }
}

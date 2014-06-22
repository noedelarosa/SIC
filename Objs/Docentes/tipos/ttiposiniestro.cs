using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class ttiposiniestro:Empresa.Comun.TEstandar {

        public ttiposiniestro() {
            this.Nombre = string.Empty;
            this.Id = 0;
            this.Descripcion = string.Empty;
        }
        public ttiposiniestro(int id) {
            this.Id = id;
        }
        public ttiposiniestro(string nombre,string descripcion)
        {
            this.Nombre = nombre ;
            this.Descripcion = descripcion;
        }

        public ttiposiniestro(int id,string nombre, string descripcion)
        {
            this.Id = id;
            this.Nombre = nombre ;
            this.Descripcion = descripcion;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class testadopj : Empresa.Comun.TEstandar
    {
        public testadopj() {
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
            this.Id = 0;
        }

        public testadopj(int id){
            this.Id = id;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }

        public testadopj(int id, string nombre, string descripcion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class TParentesco: Empresa.Comun.TEstandar 
    {
        public TParentesco() {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }
        public TParentesco(int id) {
            this.Id = id;
            this.Nombre = string.Empty;
            this.Descripcion = string.Empty;
        }
        public TParentesco(int id, string nombre){
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = string.Empty;
        }
    }
}

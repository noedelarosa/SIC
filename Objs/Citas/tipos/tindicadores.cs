using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Citas
{
    public class tindicadores: Empresa.Comun.TEstandar {
        public int Valoracion { get; set; }

        public tindicadores() {
            this.Id = 0;
            this.Valoracion = 10;
            this.Habilitado = true;
            this.Nombre = string.Empty;
        }

        public tindicadores(int id){
            this.Id = id;
 
            this.Valoracion = 0;
            this.Nombre = string.Empty;
        }

    }
}

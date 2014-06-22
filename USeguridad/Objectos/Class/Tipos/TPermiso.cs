using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.USeguridad
{
    public class TPermiso{
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TPermiso() {
            Id = 0;
            Nombre = string.Empty;
        }
        public TPermiso(int id, string nombre) {
            this.Id = id;
            this.Nombre = nombre;
        }
        public TPermiso(int id) {
            this.Id = id;
        }

     }
}

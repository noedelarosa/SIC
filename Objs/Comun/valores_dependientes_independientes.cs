using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class valores_dependientes_independientes
    {
        public Type Tipo { get; set; }
        public string Nombre { get; set; }

        public valores_dependientes_independientes() {
            this.Tipo = typeof(string);
            Nombre = string.Empty;
        }

        public valores_dependientes_independientes(Type tipo, string nombre)
        {
            this.Tipo = tipo;
            Nombre = nombre;
        }
    }
}

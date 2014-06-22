using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class tcuentanomina
    {
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public tcuentanomina() {
            this.Cantidad = 0;
            this.Fecha = DateTime.MinValue;
        }

        public tcuentanomina(int cantidad, DateTime fecha)
        {
            this.Cantidad = cantidad;
            this.Fecha = fecha;
        }

    }
}

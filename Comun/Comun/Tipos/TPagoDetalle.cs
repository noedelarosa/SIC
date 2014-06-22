using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TPagoDetalle: TPago
    {
        public Empresa.Comun.TEstandar IngresoDescuento { get; set; }

        public TPagoDetalle() {
            this.Id = 0;
            this.Fecha = DateTime.MinValue;
            this.MontoBruto = 0;
            this.IngresoDescuento = new Comun.TEstandar();
            this.Estado = new testadolaboral();
        }
    }
}

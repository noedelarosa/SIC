using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TPagoDetalle: TPago
    {
        public Empresa.Comun.TEstandar IngresoDescuento { get; set; }
        public bool EsIngreso {
            get {
                return Convert.ToInt32(this.IngresoDescuento.Mus) <= 44;
            }
        }
        public int CodigoTanda { get;set; }

        public string Descripcion {

            get {
                if (Convert.ToInt32(this.IngresoDescuento.Mus) <= 44)
                {
                    return "Ingreso";
                }
                else {
                    return "Egreso";
                }

            }
        }

        public TPagoDetalle() {
            this.Id = 0;
            this.Fecha = DateTime.MinValue;
            this.MontoBruto = 0;
            this.IngresoDescuento = new Comun.TEstandar();
            this.Estado = new RHH.testadolaboral();
            this.CodigoTanda = 0;
        }
    }
}

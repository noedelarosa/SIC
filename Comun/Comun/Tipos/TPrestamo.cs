using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContraPrestamos
{
    public class TPrestamo{

        public int Id { get; private set; }
        public string Numero { get; private set; }

        public Empresa.RHH.tpersonal Director { get; set; }
        public Empresa.RHH.TNotario Notario { get; set; }
        public tdocente Deudor { get; set; }

        public tdocente[] Garantes { get; set; }

        public DateTime Fecha { get; private set; }
        public double Monto { get; set; }



    }
}

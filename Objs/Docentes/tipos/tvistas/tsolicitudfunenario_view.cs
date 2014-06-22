using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class tsolicitudfunenario_view
    {
        public string Numero { get; set; }
        public DateTime FechaEntrada { get; set; }
        public string EstadoActual { get; set; }
        public string EstadoPago { get; set; }
        public double Monto { get; set; }
        public string DocenteCedula { get; set; }
        public string DocenteNombre { get; set; }
        public string DocenteApellido { get; set; }
    }
}

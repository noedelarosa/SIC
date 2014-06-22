using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.RegistroEventos
{
    public class tlog
    {
        public DateTime FechaHora { get; set; }
        public Exception Excepcion { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreComputadora { get; set; }

        public tlog() {
            this.FechaHora = DateTime.Now;
            Excepcion = new Exception();
            NombreComputadora = string.Empty;
            this.NombreUsuario = string.Empty; 
        } 


    }
}

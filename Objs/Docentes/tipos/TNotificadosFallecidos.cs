using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TNotificadosFallecidos
    {
        public int Id { get; set; }
        public tdocente Docente { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public RHH.TDeparamentoAsignado Departamento { get; set; }
        public bool CorreoEnvidado { get; set; }
        public bool EsFallecidoMinimo { get; set; }
        
        public TNotificadosFallecidos() 
        {
            this.Docente = new tdocente();
            this.Fecha = DateTime.MinValue;
            this.Descripcion = string.Empty;
            this.Departamento = new RHH.TDeparamentoAsignado();
            this.CorreoEnvidado = false;
            this.EsFallecidoMinimo = false;
        }

    }


}

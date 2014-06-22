using System;
using System.Collections.Generic;
using System.Linq;

namespace Empresa.USeguridad
{
    public class TAutorizacion{
        public TBoleto Boleto { get;set; }
        public TRecurso Recurso { get; set; }
        
        public TAutorizacion() {
            Boleto = new TBoleto();
            Recurso = new TRecurso();
        }
        public TAutorizacion(TBoleto boleto, TRecurso recurso) {
            this.Boleto = boleto; 
            this.Recurso = recurso;
        }
    }
}

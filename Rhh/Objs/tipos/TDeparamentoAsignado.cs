using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.RHH
{
    public class TDeparamentoAsignado
    {
        public int Id { get; set; }
        public TDepartamento Departamento { get; set; }
        public tpersonal Personal {get;set;}
        public bool Habilitado { get; set; }

        public TDeparamentoAsignado() {
            this.Id = 0;
            this.Departamento = new TDepartamento();
            this.Personal = new tpersonal();
        }

        public TDeparamentoAsignado(int id){
            this.Id = id;
            this.Departamento = new TDepartamento();
            this.Personal = new tpersonal();
        }

    }
}

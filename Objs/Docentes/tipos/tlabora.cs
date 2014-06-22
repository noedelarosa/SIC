using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class tlabora {
        public int Id { get; set; }
        public Empresa.Comun.TSuplidor Empresa { get; set; }
        public double SueldoBase  { get; set; }
        public double SueldoBruto { get; set; }

        public tlabora(){
            this.Empresa = new Empresa.Comun.TSuplidor();
            SueldoBase = 0;
            SueldoBruto = 0;
        }

        public tlabora(int id) {
            this.Id = id;
        }

        public tlabora(int id,Empresa.Comun.TSuplidor empresa,double sueldobase, double sueldobruto){
            this.Id = id;
            this.Empresa = empresa;
            this.SueldoBase = sueldobase;
            this.SueldoBruto = sueldobruto;
        }
    }
}

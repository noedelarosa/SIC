using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class AseguradoresRecurrentes{
        public List<TSuplidor> Lista {get;set;}
        // Id DB.
        public AseguradoresRecurrentes() {
            this.Lista = new List<TSuplidor>();
            Empresa.Comun.Suplidor sup = new Suplidor(1660931);
            this.Lista.Add(sup[0]);
        }
    }
}

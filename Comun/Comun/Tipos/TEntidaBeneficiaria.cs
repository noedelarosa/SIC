using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Comun{

    public class TEntidaBeneficiaria: Validacion.ReglaContenido {
        private Numalet cl = new Numalet();

        public int Id { get; set; }
        public TSuplidor Entidad {get;set; }

        double _Monto;
        public double Monto
        {
            get
            {
                return _Monto;
            }
            set
            {
                if (!this.ValidNumero(value).IsValid)
                {
                    this.AgregoError("Monto", "Falta Monto");
                }
                else
                {
                    this.BorrarError("Monto");
                    _Monto = value;
                }
            }
        }

        public string MontoF{
            get{
                if (!this.Monto.Equals(0)){
                    return cl.ToCustomCardinal(Monto).ToUpper();
                }
                return string.Empty;
            }
            private set {}
        }

        string _concepto;
        public string Concepto
        {
            get{
                return _concepto;
            }
            set{
                if (!this.ValidContenido(value).IsValid){
                    this.AgregoError("Concepto", "Falta Concepto");
                }
                else{
                    this.BorrarError("Concepto");
                    _concepto = value;
                }
            }
        }

        public TEntidaBeneficiaria() {
            Entidad = new TSuplidor();
            Monto = 0;
            Concepto = string.Empty;
        }

        public TEntidaBeneficiaria(int id) {
            this.Id = 0;
        }
        
        public TEntidaBeneficiaria(TSuplidor entidad, double monto, string concepto){
            this.Entidad = entidad;
            this.Monto = monto;
            this.Concepto = concepto;
        }


    }

}


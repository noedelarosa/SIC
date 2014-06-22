using System;
namespace Empresa.Docente
{
    public class TDecretoDocente{

        public int Id {get;set;}
        public double Monto { get;set; }
        public TDecreto Decreto { get; set; }
        public Empresa.RHH.testadolaboral Estado { get; set; }

        /// <summary>
        /// Resultado de la scala establecida para decretar una persona.
        /// </summary>
        public double Porciento { get; set; }

        public TDecretoDocente() {
            this.Id = 0;
            this.Decreto = new TDecreto();
            this.Monto = 0;
            this.Estado = new RHH.testadolaboral();
            this.Porciento = 0;
        }

        public TDecretoDocente(int id) {
            this.Id = id;
            this.Decreto = new TDecreto();
            this.Monto = 0;
            this.Porciento = 0;
        }

        public TDecretoDocente(TDecreto decreto, double monto){
            this.Id = 0;
            this.Decreto = decreto;
            this.Monto= monto;
            this.Porciento = 0;
        }

        public TDecretoDocente(TDecreto decreto, double monto,Empresa.RHH.testadolaboral estado)
        {
            this.Id = 0;
            this.Decreto = decreto;
            this.Monto = monto;
            this.Estado = estado;
            this.Porciento = 0;
        }
        public TDecretoDocente(TDecreto decreto, double monto, Empresa.RHH.testadolaboral estado, double porciento)
        {
            this.Id = 0;
            this.Decreto = decreto;
            this.Monto = monto;
            this.Estado = estado;
            this.Porciento = porciento;
        }

    }
}

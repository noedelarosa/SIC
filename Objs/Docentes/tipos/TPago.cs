using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TPago{
        
        public int Id { get;set; }

        public double MontoBruto {
            get ;
            set; 
        }

        public string MontoBrutoToString {
            get {
                try{
                    return new Numalet().ToCustomCardinal(this.MontoBruto).ToUpper();
                }
                catch {
                    return "--";
                }
              }
        }

        public DateTime Fecha { get; set; }
        public Empresa.RHH.testadolaboral Estado { get; set; }
        public tdocente Docente;



        public TPago() {
            this.Id = 0;
            this.MontoBruto = 0;
            this.Fecha = DateTime.MinValue;
            this.Estado = new RHH.testadolaboral();
        }

        public TPago(int id)
        {
            this.Id = id;
            this.MontoBruto = 0;
            this.Fecha = DateTime.MinValue;
            this.Estado = new RHH.testadolaboral();
        }


        public TPago(int id, double montobruto, DateTime fecha, Empresa.RHH.testadolaboral estado)
        {
            this.Id = id;
            this.MontoBruto = montobruto;
            this.Fecha = fecha;
            this.Estado = estado;
        }

        public TPago(double montobruto, DateTime fecha, Empresa.RHH.testadolaboral estado)
        {
            this.Id = 0;
            this.MontoBruto = montobruto;
            this.Fecha = fecha;
            this.Estado = estado;
        }

        public TPago(string cedula, double montobruto, DateTime fecha, Empresa.RHH.testadolaboral estado)
        {
            this.Id = 0;
            this.MontoBruto = montobruto;
            this.Fecha = fecha;
            this.Estado = estado;

            this.Docente = new tdocente();
            this.Docente.Cedula = cedula;
        }



        public TPago(int id, string cedula, double montobruto, DateTime fecha, Empresa.RHH.testadolaboral estado)
        {
            this.Id = id;
            this.MontoBruto = montobruto;
            this.Fecha = fecha;
            this.Estado = estado;

            this.Docente = new tdocente();
            this.Docente.Cedula = cedula;
        }

        public TPago(tdocente docente, double montobruto, DateTime fecha, Empresa.RHH.testadolaboral estado)
        {
            this.Id = 0;
            this.MontoBruto = montobruto;
            this.Fecha = fecha;
            this.Estado = estado;
            this.Docente = docente;
        }

        public TPago(tdocente docente, double montobruto, DateTime fecha)
        {
            this.Id = 0;
            this.MontoBruto = montobruto;
            this.Fecha = fecha;
            this.Estado = new RHH.testadolaboral();
            this.Docente = docente;
        }

        public TPago(int id, tdocente docente, double montobruto, DateTime fecha, Empresa.RHH.testadolaboral estado)
        {
            this.Id = id;
            this.MontoBruto = montobruto;
            this.Fecha = fecha;
            this.Estado = estado;
            this.Docente = docente;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class tdatosfallecimiento
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Acta { get; set;  }
        public string Libro { get; set; }
        public string Folio { get; set; }
        public DateTime FechaFallecimiento { get; set; }
        public Empresa.Comun.TDireccionAsignada Direccion { get; set; }
        public Empresa.Comun.TEstandar TipoMuerte { get; set; }
        public string Causa { get; set; }
        public string Oficialia { get; set; }

        public tdatosfallecimiento() {
            this.Id = 0;
            this.Acta = string.Empty;
            this.Libro = string.Empty;
            this.Folio = string.Empty;
            this.FechaFallecimiento = DateTime.MinValue;
            this.Direccion = new Comun.TDireccionAsignada();
            this.TipoMuerte = new Comun.TEstandar();
            this.Causa = string.Empty;
            this.Numero = string.Empty;
            this.Oficialia = string.Empty;
        }

        public tdatosfallecimiento(int id)
        {
            this.Id = id;
            this.Acta = string.Empty;
            this.Libro = string.Empty;
            this.Folio = string.Empty;
            this.FechaFallecimiento = DateTime.MinValue;
            this.Direccion = new Comun.TDireccionAsignada();
            this.TipoMuerte = new Comun.TEstandar();
            this.Causa = string.Empty;
            this.Numero = string.Empty;
            this.Oficialia = string.Empty;
        } 



    }
}

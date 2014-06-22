using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class TDireccionAsignada
    {
        public int Id { get; set; }
        public string Referencia { get; set; }
        public TMunicipio Municipio { get; set; }
        public TProvincia Provincia { get; set; }
        public TSector Sector { get; set; }
        public TEstandar Tipo { get; set; }
        
        public bool Existe {
            get {
                return !Id.Equals(0); 
            }
        }

        public TDireccionAsignada(){
            this.Id = 0;
            Referencia = string.Empty;
            this.Municipio = new TMunicipio();
            this.Provincia = new TProvincia();
            this.Sector = new TSector();
        }

        public TDireccionAsignada(int id) {
            this.Id = id;
            Referencia = string.Empty;
            this.Municipio = new TMunicipio();
            this.Provincia = new TProvincia();
            this.Sector = new TSector();
        }

    }
}

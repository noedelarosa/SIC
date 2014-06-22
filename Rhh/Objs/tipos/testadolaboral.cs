using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.RHH
{
    public class testadolaboral : Empresa.Comun.TEstandar
    {
        public string Abreviatura { get; set; }
        
        public testadolaboral(){
            this.Id = 0;
            this.Nombre = string.Empty;
        }

        public testadolaboral(int id){
            this.Id = id;
            this.Nombre = string.Empty;
        }

        public testadolaboral(string nombre){
            this.Id = 0;
            this.Nombre = nombre; ;
        }

        public testadolaboral(int id, string nombre){
            this.Id = id;
            this.Nombre = nombre;
        }

        public testadolaboral(int id, string nombre,string abreviatura){
            this.Id = id;
            this.Nombre = nombre;
            this.Abreviatura = abreviatura;
        }

    }

}
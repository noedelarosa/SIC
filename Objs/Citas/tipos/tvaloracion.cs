using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Citas
{
    public class tvaloracion
    {
        public tindicadores Indicador { get; set; }
        public int Resultado { get; set; }

        public tvaloracion(){
            this.Indicador = new tindicadores();
            this.Resultado = 0;
        }

        public tvaloracion(tindicadores indicador)
        {
            this.Indicador = indicador;
            this.Resultado = 0;
        }


    }
}

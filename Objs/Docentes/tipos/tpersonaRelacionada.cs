using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class tpersonaRelacionada
    {
        public bool EsNuevo { get; set; }
        public Empresa.RHH.tpersonal Persona { get; set; }
        public Empresa.Comun.TEstandar Parentesco { get; set; }


        public tpersonaRelacionada() {
            this.Parentesco = new Comun.TEstandar();
            this.Persona = new RHH.tpersonal();
            this.EsNuevo = true;
        }

        public tpersonaRelacionada(RHH.tpersonal persona){
            this.Parentesco = new Comun.TEstandar();
            this.EsNuevo = true;
            this.Persona = persona;
        }

        public tpersonaRelacionada(RHH.tpersonal persona, Comun.TEstandar parentesco)
        {
            this.Parentesco = parentesco;
            this.EsNuevo = true;
            this.Persona = persona;
        }

        public tpersonaRelacionada(RHH.tpersonal persona, Comun.TEstandar parentesco, bool esnuevo)
        {
            this.Parentesco = parentesco;
            this.EsNuevo = esnuevo;
            this.Persona = persona;
        }
    }
}

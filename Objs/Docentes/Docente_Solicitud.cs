using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DocenteSolicitud:DocenteFamilia
    {

        public DocenteSolicitud() : base() { 
        
        
        }

        public DocenteSolicitud(string cedula):base(cedula){
            foreach (tdocente docente in this) {
                //Agregandole la solicitud PJ.
                docente.SolicitudPJ = new SolicitudPJ(docente);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel ;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
   public class DocenteFamilia:DocenteDecreto{

       public DocenteFamilia():base() {
       }

       public DocenteFamilia(string cedula):base(cedula) {
           foreach (tdocente docente in this){
                   if (!string.IsNullOrEmpty(docente.Cedula)){
                       if (docente.EsInabima)
                       {
                           docente.Familiares = new Familiares(cedula, docente.DecretoBeneficiarios);
                       }
                       else
                       {
                           docente.Familiares = new Familiares(cedula, docente.Aseguradora);
                       }
                   }
                   else{
                       docente.Familiares = new Familiares();
                   }
           }
       }

       


    }
}

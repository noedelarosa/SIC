using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class DocenteDecreto : Docente
    {
        public DocenteDecreto():base(){


        }

        public DocenteDecreto(string cedula):base(cedula) {
            DecretoDocente decret;

            foreach (tdocente docente in this){

                docente.Calculando_MontoDecretoCalculado();
                decret = new DecretoDocente(docente);

                if (decret.Docentes != null){
                    if(decret.Docentes.Count > 0)
                    {

                        docente.Decretos = decret.Docentes[0].Decretos;
                        if (docente.DecretoActual.Decreto.Id != 0){
                            docente.EstadoLaboral = docente.DecretoActual.Estado;
                        }
                        else{
                            docente.EstadoLaboral = Empresa.RHH.EstadoLaboral.GetInstance()[1];
                        }

                    }
                    else{
                        docente.Decretos = new ObservableCollection<TDecretoDocente>();
                        docente.EstadoLaboral = Empresa.RHH.EstadoLaboral.GetInstance()[1];
                    }

                }
                else
                {
                    docente.Decretos = new ObservableCollection<TDecretoDocente>();
                    docente.EstadoLaboral = Empresa.RHH.EstadoLaboral.GetInstance()[1];
                }
                docente.Comentarios = new Comun.Comentario(docente.Cedula, docente.Tipo.Id).Lista;
            }//en for
        }

        public DocenteDecreto(Empresa.Docente.TDecreto item){
           Empresa.Docente.DecretoDocente Decredocente = new DecretoDocente(item);


           foreach (tdocente itemdecre in Decredocente.Docentes){
               //itemdecre.Calculando_MontoDecretoCalculado();
               this.Add(itemdecre);
           }

       }

        public tdocente Primero() {
            if (this.Count > 0)
            {

                if (this[0] != null){
                    return this[0];
                }
                else{
                    return new tdocente();
                }

            }
            else {
                return new tdocente();
            }
        }

        public tdocente Ultimo()
        {
            if (this.Count > 0)
            {

                if (this[this.Count - 1] != null){
                    return this[this.Count - 1];
                }
                else{
                    return new tdocente();
                }

            }
            else {
                return new tdocente();
            }

        }

    }
}

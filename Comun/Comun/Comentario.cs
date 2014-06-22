using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class Comentario
    {
        public ObservableCollection<TComentario> Lista;

        public Comentario() {
            Lista = new ObservableCollection<TComentario>();
        }

        public Comentario(object arg, int tipo){
            Lista = new ObservableCollection<TComentario>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@come_referencia", arg);
            consulta.Parameters.Add("@comet_id", tipo);
            TComentario come;
            
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_ComentariosView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
               come = new TComentario();
               come.Id = Convert.ToInt32(fila["come_id"]);
               come.Fecha = Convert.ToDateTime(fila["come_fecha"]);
               come.Comentario =  fila["come_argumento"].ToString();
               come.Referencia = fila["come_referencia"].ToString();
               come.Tipo = new TEstandar(Convert.ToInt32(fila["comet_id"]));
               come.EsPresencial = Convert.ToBoolean(fila["come_espresencial"]);
               this.Lista.Add(come);
            }

        }

        public void Insert(TComentario item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@come_argumento", item.Comentario);
            consulta.Parameters.Add("@come_fecha", item.Fecha);
            consulta.Parameters.Add("@come_referencia", item.Referencia);
            consulta.Parameters.Add("@comet_id", item.Tipo.Id);
            consulta.Parameters.Add("@come_espresencial", item.EsPresencial);

            consulta.Execute.NoQuery("dbo.Comun_ComentariosInsert", System.Data.CommandType.StoredProcedure);
            
            this.Lista.Add(item);
        }

        public void Update(TComentario item){



        }

    }
}

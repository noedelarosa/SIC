using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class RequisitosAsignados 
    {
        public ObservableCollection<trequesitosasignados> Lista { get;set; }
        
        public RequisitosAsignados(){
            this.Lista = new ObservableCollection<trequesitosasignados>();
            
        }

        public RequisitosAsignados(int idSol){
            this.Lista = new ObservableCollection<trequesitosasignados>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@solpj_id", idSol);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Pensiones_RequisitosAsignadosView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                Lista.Add(new trequesitosasignados(Convert.ToInt32(fila["reqa_id"]), Requisitos.GetInstante().GetItem(Convert.ToInt32(fila["req_id"])), Convert.ToBoolean(fila["reqa_valor"]), Convert.ToDateTime(fila["reqa_fecha"]), fila["reqa_comentario"].ToString()));
            }
        }

        public void Insert(tsolicitudpj item){
            foreach (trequesitosasignados req in item.Requisitos) {
                //solo Agregar los nuevos.
                if (req.Id.Equals(0))
                {
                    SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                    consulta.Parameters.Add("@req_id", req.Requisito.Id);
                    consulta.Parameters.Add("@reqa_valor", req.Valor);
                    consulta.Parameters.Add("@reqa_comentario", req.Comentario);
                    consulta.Parameters.Add("@solpj_id", item.Id);
                    consulta.Execute.NoQuery("dbo.Pensiones_RequisitosAsignadosInsert", System.Data.CommandType.StoredProcedure);
                    consulta.Parameters.ClerAll();
                }

            }
        }

        public void Update(tsolicitudpj item){

            foreach (trequesitosasignados req in item.Requisitos)
            {
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

                consulta.Parameters.Add("@reqa_valor", req.Valor);
                consulta.Parameters.Add("@reqa_comentario", req.Comentario);
                consulta.Parameters.Add("@solpj_id", item.Id);
                consulta.Execute.NoQuery("dbo.Pensiones_RequisitosAsignadosUpdate", System.Data.CommandType.StoredProcedure);
                
                consulta.Parameters.ClerAll();
            }
        }


    }
}

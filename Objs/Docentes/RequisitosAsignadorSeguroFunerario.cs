using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente

{
    
    public class RequisitosAsignadorSeguroFunerario{
        public ObservableCollection<trequesitosasignados> Lista { get; set; }

        public RequisitosAsignadorSeguroFunerario() {
            this.Lista = new ObservableCollection<trequesitosasignados>();
        }

        public RequisitosAsignadorSeguroFunerario(tsolicitudfunenario item)
        {
            this.Lista = new ObservableCollection<trequesitosasignados>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            RequisitosSeguroFunerario _requisitos = RequisitosSeguroFunerario.GetInstante();

            consulta.Parameters.Add("@solsf_id", item.Id);
            //tsolicitudfunenario sol;
            trequesitosasignados req;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.SeguroFunerario_RequisitoAsignados_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                req = new trequesitosasignados();

                req.Id = Convert.ToInt32(fila["reqa_id"]);
                req.Requisito = _requisitos.GetItem(Convert.ToInt32(fila["req_id"]));
                req.Fecha = Convert.ToDateTime(fila["reqa_fecha"]);
                req.Valor = Convert.ToBoolean(fila["reqa_valor"]);
                req.Comentario = fila["reqa_detalle"].ToString();
                req.FotoArreglo = fila["reqa_imagen"] == DBNull.Value ? null : (byte[])fila["reqa_imagen"];

                this.Lista.Add(req);
            }
        }


        public void Insert(tsolicitudfunenario item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            foreach (trequesitosasignados itemrequ in item.Requisitos)
            {
                if (itemrequ.Id.Equals(0)){            
                        consulta.Parameters.Add("@reqa_valor", itemrequ.Valor);
                        consulta.Parameters.Add("@reqa_fecha", itemrequ.Fecha);
                        consulta.Parameters.Add("@req_id", itemrequ.Requisito.Id);
                        consulta.Parameters.Add("@solsf_id", item.Id);
                        consulta.Parameters.Add("@reqa_detalle", itemrequ.Comentario);
                        consulta.Parameters.Add("@reqa_imagen", itemrequ.FotoArreglo == null? new byte[0]: itemrequ.FotoArreglo);
                        consulta.Execute.NoQuery("dbo.SeguroFunerario_RequisitoAsignados_Insert", System.Data.CommandType.StoredProcedure);
                        consulta.Parameters.ClerAll();
                }
            }

        }

     

        public void Update(tsolicitudfunenario item){
            //SeguroFunerario_RequisitoAsignados_Update
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            foreach (trequesitosasignados itemrequ in item.Requisitos){
                consulta.Parameters.Add("@reqa_fecha", itemrequ.Fecha);
                consulta.Parameters.Add("@reqa_detalle", itemrequ.Comentario);
                consulta.Parameters.Add("@reqa_imagen", itemrequ.FotoArreglo == null ? new byte[0] : itemrequ.FotoArreglo);

                if (itemrequ.Id.Equals(0)){
                    //Nuevo Item, Para Insertar
                    consulta.Parameters.Add("@reqa_valor", itemrequ.Valor);
                    consulta.Parameters.Add("@req_id", itemrequ.Requisito.Id);
                    consulta.Parameters.Add("@solsf_id", item.Id);
                    consulta.Execute.NoQuery("dbo.SeguroFunerario_RequisitoAsignados_Insert", System.Data.CommandType.StoredProcedure);
                }
                else {
                    //Para Actualizar
                    consulta.Parameters.Add("@reqa_id", itemrequ.Id);
                    consulta.Execute.NoQuery("[dbo].[SeguroFunerario_RequisitoAsignados_Update]", System.Data.CommandType.StoredProcedure);
                }

                consulta.Parameters.ClerAll();
            }
        }


    }


}

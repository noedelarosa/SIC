using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class ListaPensionadoenBeneficio
    {
        public ObservableCollection<tlistadopensionadosenbeneficio> Lista { get; set; }
        
        public ListaPensionadoenBeneficio(){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new ObservableCollection<tlistadopensionadosenbeneficio>();
            tlistadopensionadosenbeneficio item;

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_ListaBeneficiariosPension_CalculoAseguradora_View]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                item = new tlistadopensionadosenbeneficio();

                item.Id = Convert.ToInt32(fila["lisbp_id"]);
                item.FechaCorte = Convert.ToDateTime(fila["lisbp_fcorte"]);
                item.Fecha = Convert.ToDateTime(fila["lisbp_Fecha"]);
                item.Descripcion = fila["lisbp_descripcion"].ToString();
                

                this.Lista.Add(item);
            }
        }

        public int Insert(tlistadopensionadosenbeneficio item){
            int indice = 0;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@lisbp_fecha", item.FechaCorte);
            consulta.Parameters.Add("@lisbp_descripcion", item.FechaCorte);
            consulta.Parameters.Add("@lisbp_fcorte", item.FechaCorte);

            consulta.Execute.NoQuery("dbo.Comun_ListaBeneficiariosPension_CalculoAseguradora_Insert", System.Data.CommandType.StoredProcedure);
            return indice;   
        }

        public void Update(tlistadopensionadosenbeneficio item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@lisbp_id", item.Id);
            consulta.Parameters.Add("@lisbp_fecha", item.FechaCorte);
            consulta.Parameters.Add("@lisbp_descripcion", item.FechaCorte);
            consulta.Parameters.Add("@lisbp_fcorte", item.FechaCorte);

            consulta.Execute.NoQuery("dbo.Comun_ListaBeneficiariosPension_CalculoAseguradora_Update", System.Data.CommandType.StoredProcedure);
        }

        

    }
}

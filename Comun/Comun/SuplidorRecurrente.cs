using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class SuplidorRecurrente
    {
        public ObservableCollection<TSuplidor> Lista { get; set; }

        public SuplidorRecurrente() {
            this.Lista = new ObservableCollection<TSuplidor>();
        }

        public SuplidorRecurrente(Empresa.Comun.TEstandar tipo){
            this.Lista = new ObservableCollection<TSuplidor>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@tsupr_id", tipo.Id);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_Supli_RecurrenteCertificaciones_01_View]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                Lista.Add(new TSuplidor(Convert.ToInt32(fila["sup_id"]), fila["sup_nombre"].ToString(), fila["sup_rnc"].ToString(), false, fila["sup_web"].ToString(), fila["sup_fax"].ToString(), fila["sup_telefonoPrimario"].ToString(), null));
            }
        }




    }
}

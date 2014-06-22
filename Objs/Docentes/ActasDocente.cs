using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;

namespace Empresa.Docente
{
    public class ActasDocente
    {
        public ObservableCollection<tdocenteactas> Lista {get;set;}

        public void Fill() {
            Lista = new ObservableCollection<tdocenteactas>();
            //dbo.
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            tdocenteactas docente;
            Empresa.Comun.Provincia pro = Empresa.Comun.Provincia.GetInstance();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Legal_ActasBancoView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                docente = new tdocenteactas();
                docente.Id = Convert.ToInt32(fila["acta_id"]);
                docente.Nss = fila["acta_nss"].ToString();
                docente.Cedula = fila["acta_cedula"].ToString();
                docente.Provincia = pro.Source(Convert.ToInt32(fila["provi_id"]));
                this.Lista.Add(docente);
            }
        }

        public ActasDocente() {
            this.Fill();
        } 

        public void Insert(tdocenteactas item) {
            this.Lista.Clear();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@acta_nss", item.Nss);
            consulta.Parameters.Add("@acta_cedula", item.Cedula == null ? string.Empty : item.Cedula);
            consulta.Parameters.Add("@provi_id", item.Provincia.Id);
            consulta.Execute.NoQuery("dbo.Legal_ActasBancoInsert", CommandType.StoredProcedure);
            this.Fill();
        }

        public void delete(tdocenteactas item) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@acta_id", item.Id);
            consulta.Execute.NoQuery("dbo.Legal_ActasBancoDelete", CommandType.StoredProcedure);
            this.Fill();
        }

    }
}

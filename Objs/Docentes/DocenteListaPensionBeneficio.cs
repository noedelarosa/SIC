using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DocenteListaPensionBeneficio
    {
        public ObservableCollection<tdocente> Lista { get; set; }
        
        public DocenteListaPensionBeneficio(){
            this.Lista = new ObservableCollection<tdocente>();
        

        }

        public DocenteListaPensionBeneficio(int id){
            this.Lista = new ObservableCollection<tdocente>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            //padron.SEXO,
            //doc.lisbp_id

            consulta.Parameters.Add("@lisbp_id", id);
            List<string> cedulas = new List<string>();
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_DocenteListaBeneficiariosPension_CalculoAseguradora_View]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                
                cedulas.Add(fila["cedula"].ToString());
                //item = new tdocente();
                //item.Nombres = fila["NOMBRES"].ToString();
                //item.Apellidos = fila["apellidos"].ToString();
                //item.Cedula = fila["cedula"].ToString();
                //item.FechaNacimiento = Convert.ToDateTime(fila["FECHA_NAC"]);
                //item.HistorialPagos = new Pagos(item.Cedula);
                //itemsol = new tsolicitudpj();
                //itemsol.Id = Convert.ToInt32(fila["solpj_id"]);
                //itemsol._calculando_EscalaPensionDiscapcidad();
                //itemsol.FechaConcrecion = Convert.ToDateTime(fila["solpj_fconcrecion"]);
                //itemsol.NoExpediente = fila["solpj_noexpedientes"].ToString();
                //itemsol._calculando_Monto();
                //itemsol._calculando_MontoRetroactivo();
                //item.SolicitudPJ.Actual = itemsol;
                //item.SolicitudPJ.Lista.Add(itemsol);
                //this.Lista.Add(item);
            }
            this.Lista = new DocenteBase(cedulas);

        }

        public void Insert(tdocente item, int id) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@lisbp_id", id);
            consulta.Parameters.Add("@docf_cedula", item.Cedula);

            consulta.Execute.NoQuery("dbo.Comun_DocenteListaBeneficiariosPension_CalculoAseguradora_Insert", System.Data.CommandType.StoredProcedure);
            this.Lista.Add(item);
        }

        public void Delete(tdocente item, int id){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@lisbp_id", id);
            consulta.Parameters.Add("@docf_cedula", item.Cedula);
            consulta.Execute.NoQuery("dbo.Comun_DocenteListaBeneficiariosPension_CalculoAseguradora_Delete", System.Data.CommandType.StoredProcedure);
            this.Lista.Remove(item);

        }

    }
}

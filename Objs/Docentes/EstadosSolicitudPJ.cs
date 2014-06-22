using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class EstadosSolicitudPJ {
        public ObservableCollection<testadossolicitudpj> Lista { get; set; }

        public EstadosSolicitudPJ() {
            this.Lista = new ObservableCollection<testadossolicitudpj>(); 
        }

        public EstadosSolicitudPJ(tsolicitudpj item)
        {
            this.Lista = new ObservableCollection<testadossolicitudpj>();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            testadossolicitudpj _estadoasig;
            EstadoPJ _estados = EstadoPJ.GetInstance();
            
            consulta.Parameters.Add("@solpj_id", item.Id);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_EstadoSolicitudAsignadosView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                _estadoasig = new testadossolicitudpj();
                _estadoasig.Estado = _estados.GetItem(Convert.ToInt32(fila["esolpj_id"]));
                _estadoasig.Fecha = Convert.ToDateTime(fila["aesolpj_fecha"]);
                _estadoasig.Descripcion = fila["aesolpj_detalle"].ToString();
                this.Lista.Add(_estadoasig); 
            }
        }
       
        public void Insert(tsolicitudpj item) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@solpj_id", item.Id);
            consulta.Parameters.Add("@esolpj_id", item.EstadoActual.Estado.Id);
            consulta.Parameters.Add("@aesolpj_fecha", item.EstadoActual.Fecha);
            consulta.Parameters.Add("@aesolpj_detalle", item.EstadoActual.Descripcion);

            consulta.Execute.NoQuery("dbo.Pensiones_EstadoSolicitudAsignadosInsert", System.Data.CommandType.StoredProcedure);
        }

        public void Update(testadopj estado)
        {



        }

        


    }

}

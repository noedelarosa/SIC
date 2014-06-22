using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{

    public class SeguroFunerarioEstados{
        public ObservableCollection<testadoasignado> Lista { get; set; }

        public SeguroFunerarioEstados(){
            this.Lista = new ObservableCollection<testadoasignado>();





        }
        
        private void _contructor(int id) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@solsf_id", id);
            SeguroFunerarioEstado _estado = SeguroFunerarioEstado.GetInstance();
            testadoasignado _testado;

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.SeguroFunerario_EstadoAsignados_view", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                _testado = new testadoasignado();

                _testado.Id = Convert.ToInt32(fila["esolsfa_id"]);
                _testado.Estado = _estado.GetItem(Convert.ToInt32(fila["esolsf_id"]));
                _testado.Fecha = Convert.ToDateTime(fila["esolsfa_fecha"]);

                this.Lista.Add(_testado);
            }
        }

        public SeguroFunerarioEstados(int id){
            this.Lista = new ObservableCollection<testadoasignado>();
            this._contructor(id);  
        }

        public SeguroFunerarioEstados(tsolicitudfunenario item) {
            this.Lista = new ObservableCollection<testadoasignado>();
            this._contructor(item.Id);  
        }

        public void Insert(tsolicitudfunenario item) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@solsf_id", item.Id);
            consulta.Parameters.Add("@esolsf_id", item.EstadoActual.Estado.Id);

            consulta.Execute.NoQuery("[dbo].[SeguroFunerario_EstadoAsignados_Insert]", System.Data.CommandType.StoredProcedure);
        }


    }

}

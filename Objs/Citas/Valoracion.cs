using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Citas
{
    public class Valoraciones {
        public ObservableCollection<tvaloracion> Lista { get; set; }

        private void BindingDefault() {
            foreach (Empresa.Citas.tindicadores item in Empresa.Citas.Indicadores.GetInstance().Lista){
                this.Lista.Add(new Empresa.Citas.tvaloracion(item));
            }
        }

        public Valoraciones() {
            this.Lista = new ObservableCollection<tvaloracion>();
            this.BindingDefault();        
        }

        
        public void Insert(tvaloracion item) {
            //SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //consulta.Parameters.Add("@cit_id", );
            //consulta.Parameters.Add("@citi_id", );
            //consulta.Parameters.Add("@cval_resultado", );
            //consulta.Execute.NoQuery("dbo.Citas_Valoraciones_Insert", System.Data.CommandType.StoredProcedure);
        }

        public void Insert(TCitasVisitas item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            foreach (tvaloracion itemv in item.Valoracion){
                consulta.Parameters.Add("@cit_id", item.Id);
                consulta.Parameters.Add("@citi_id", itemv.Indicador.Id);
                consulta.Parameters.Add("@cval_resultado", itemv.Resultado);
                consulta.Execute.NoQuery("dbo.Citas_Valoraciones_Insert", System.Data.CommandType.StoredProcedure);
                consulta.Parameters.ClerAll();
            }

        }


        public void Update(TCitasVisitas item)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            foreach (tvaloracion itemv in item.Valoracion){

                consulta.Parameters.Add("@cit_id", item.Id);
                consulta.Parameters.Add("@citi_id", itemv.Indicador.Id);
                consulta.Parameters.Add("@cval_resultado", itemv.Resultado);

                consulta.Execute.NoQuery("dbo.Citas_Valoraciones_Update", System.Data.CommandType.StoredProcedure);
                consulta.Parameters.ClerAll();

            }
        }


    }
}

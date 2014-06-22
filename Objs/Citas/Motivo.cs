using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Citas
{
    public class MotivoVisitas {

        public ObservableCollection<TMotivoVisitas> Lista { get; set; }
        private static MotivoVisitas _motivovisitas;

        private MotivoVisitas() {
            Lista = new ObservableCollection<TMotivoVisitas>();
            TMotivoVisitas item;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Citas_Motivos_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                
                item = new TMotivoVisitas();
                item.Id = Convert.ToInt32(fila["motc_id"]);
                item.Nombre = fila["motc_Nombre"].ToString();
                item.Tiempo = Convert.ToDouble(fila["motc_tiempo"]);
                this.Lista.Add(item);

                //item.Id = Convert.ToInt32(fila["dep_id"]);
            }
        }

        public void Insert(TMotivoVisitas item) {
            if (this.Exite(item) == false){
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                consulta.Parameters.Add("@motc_nombre", item.Nombre);
                consulta.Parameters.Add("@depe_id", item.Departamento.Id);
                consulta.Parameters.Add("@motc_tiempo", item.Tiempo);
                consulta.Execute.NoQuery("dbo.Citas_Motivos_Insert", System.Data.CommandType.StoredProcedure);
            }
        }
       
        public static MotivoVisitas GetInstance() {
            if (_motivovisitas == null) _motivovisitas = new MotivoVisitas();
            return _motivovisitas;
        }

        public bool Exite(TMotivoVisitas item){
            foreach (TMotivoVisitas itemb in Lista) {
                if (itemb.Nombre.Equals(item.Nombre)) return true; 
            }
            return false;
        }

        public static MotivoVisitas Recarga(){
            _motivovisitas = null;
            return GetInstance(); 
        }

        public TMotivoVisitas GetItem(int id)
        {
            foreach (TMotivoVisitas itemf in this.Lista) {
                if (itemf.Id.Equals(id)) return itemf;
            }
            return new TMotivoVisitas();
        }

    }
}

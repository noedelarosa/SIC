using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    
    public class TipoSiniestros: ObservableCollection<ttiposiniestro>{

        public TipoSiniestros(){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Pensiones_TiposSiniestrosVista", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Add(new ttiposiniestro(Convert.ToInt32(fila["sin_id"]), fila["sin_nombre"].ToString(), fila["sin_descripcion"].ToString()));
            }
        }

        public ttiposiniestro GetItem(int id) {
            foreach (ttiposiniestro item in this) {
                if (item.Id.Equals(id)) return item;
            }
            return new ttiposiniestro();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class OrigenSiniestro: ObservableCollection<Empresa.Comun.TEstandar>{
        public OrigenSiniestro(){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Pensiones_OrigenSiniestroView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Add(new Empresa.Comun.TEstandar(fila["oris_nombres"].ToString(), fila["oris_decripcion"].ToString(), Convert.ToInt32(fila["oris_id"])));
            }
        }

        public Empresa.Comun.TEstandar GetItem(int id)
        {
            foreach (Empresa.Comun.TEstandar item in this)
            {
                if (item.Id.Equals(id)) return item;
            }
            return new Empresa.Comun.TEstandar();
        }
    }
}

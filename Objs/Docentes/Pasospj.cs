using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class Pasospj {
        public ObservableCollection<TPasospj> Lista { get; set; }
        private static Pasospj _Pasospj;

        public static Pasospj GetInstance(){
            if (_Pasospj == null) {
                _Pasospj = new Pasospj();
            }
            return _Pasospj;
        }

        private Pasospj() {
            Lista = new ObservableCollection<TPasospj>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Pensiones_PasosPJView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new TPasospj(Convert.ToInt32(fila["pas_id"]), fila["pas_nombre"].ToString(), Convert.ToInt32(fila["pas_orden"]), GrupoTiempos.GetInstance().GetItem(Convert.ToInt32(fila["grt_id"]))));
            }
          
        }

        public TPasospj GetItem(int id){
            var resul = from x in Lista where x.Id.Equals(id) select x;
            return resul.ToList<TPasospj>()[0];  
        }

    }
}

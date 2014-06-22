using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class Presidentes
    {
        public ObservableCollection<tpresidente> Lista { get; set; }

        private static Presidentes _Presidente;
        private Presidentes() {
            tpresidente pre;
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new ObservableCollection<tpresidente>();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Decretos_Presidente_View]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                pre = new tpresidente();

                pre.Id = Convert.ToInt32(fila["presd_id"]);
                pre.Nombres = fila["presd_nombre"].ToString();
                pre.EsActual = Convert.ToBoolean(fila["presd_esactual"]);
                this.Lista.Add(pre);
            }
        }

        public static Presidentes GetInstance() {
            if (_Presidente == null) _Presidente = new Presidentes();
            return _Presidente;
        }

        public tpresidente GetItem(int id){
            foreach (tpresidente item in this.Lista){
                if (item.Id.Equals(id)) return item;
            }
            return new tpresidente();
        }

        public tpresidente Actual()
        {
            foreach (tpresidente item in this.Lista){
                if (item.EsActual == true) return item;
            }
            return new tpresidente();
        }

        public static void Clear()
        {
            _Presidente.Lista = null;
            _Presidente = null;
        }


    }
}

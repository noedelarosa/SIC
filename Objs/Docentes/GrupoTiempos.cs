using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class GrupoTiempos
    {
        public ObservableCollection<TGrupoTiempos> Lista { get;set; }
        private static GrupoTiempos _GrupoTiempos;
        /// <summary>
        /// Total del proceso expresado en Días.
        /// </summary>
        public int TotalProceso {
            get {
                int t = 0;
                foreach (TGrupoTiempos it in this.Lista) {
                    t += it.Valor;
                }
                return t;
            }
        }

        public static GrupoTiempos GetInstance() {
            if (_GrupoTiempos == null) _GrupoTiempos = new GrupoTiempos();
            return _GrupoTiempos;
        }

        private GrupoTiempos() {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new ObservableCollection<TGrupoTiempos>();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_GrupoTiemposView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new TGrupoTiempos(Convert.ToInt32(fila["grt_id"]), Convert.ToInt32(fila["grt_valor"]), fila["grt_nombre"].ToString()));
            }

        }
        
        public TGrupoTiempos GetItem(int id) {
            foreach (TGrupoTiempos gr in this.Lista) {
                if (gr.Id.Equals(id)) return gr;
            }
            return new TGrupoTiempos();
        }

        public static void Clear()
        {
            _GrupoTiempos.Lista = null;
            _GrupoTiempos = null;
        }

    }
}

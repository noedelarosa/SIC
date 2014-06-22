using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class TipoSolicitante {

        public ObservableCollection<Empresa.Comun.TEstandar> Lista;
        private static TipoSolicitante _TipoSolicitante;
        
        private TipoSolicitante(){
            Lista = new ObservableCollection<Comun.TEstandar>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Pensiones_TipoSolicitanteView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                Lista.Add(new Comun.TEstandar(fila["spjtsol_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["spjtsol_id"])));
            }
        }

        public static TipoSolicitante GetInstance() {
            if (_TipoSolicitante == null) _TipoSolicitante = new TipoSolicitante();
            return _TipoSolicitante;
        }

        public Empresa.Comun.TEstandar GetItem(int id) {
            foreach (Empresa.Comun.TEstandar tip in this.Lista) {
                if (tip.Id.Equals(id)) return tip;
            }
            return new Comun.TEstandar();
        }

        public static void Clear()
        {
            _TipoSolicitante.Lista = null;
            _TipoSolicitante = null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente{
    public class EstadoPJ: ObservableCollection<Empresa.Docente.testadopj> {
        private static EstadoPJ _EstadoPJ;
        private EstadoPJ(){
            //Pensiones_EstadoSolicitudView
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Pensiones_EstadoSolicitudView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Add(new testadopj(Convert.ToInt32(fila["esolpj_id"]), fila["esolpj_nombre"].ToString(), fila["esolpj_decripcion"].ToString()));
            }
        }

        public static EstadoPJ GetInstance(){
            if (_EstadoPJ == null) _EstadoPJ = new EstadoPJ();
            return _EstadoPJ;
        }

        public testadopj GetItem(int id) {
            foreach (testadopj item in this) {
                if (item.Id.Equals(id)) return item;
            }
            return new testadopj();
        }

        public static void ClearObject()
        {
            _EstadoPJ = null;
        }
    }
}

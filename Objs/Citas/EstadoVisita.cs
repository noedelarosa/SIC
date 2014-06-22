using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Citas{
    
    public class EstadoVisita{

        public ObservableCollection<Empresa.Comun.TEstandar> Lista;
        public static EstadoVisita _estadovisita;

        private EstadoVisita() {
            this.Lista = new ObservableCollection<Comun.TEstandar>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Citas_Estado_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                Lista.Add(new Comun.TEstandar(fila["cite_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["cite_id"])));  
            }
        }

        public static EstadoVisita GetInstance() {
            if (_estadovisita == null) _estadovisita = new EstadoVisita();
            return _estadovisita;
        }

        public Empresa.Comun.TEstandar GetItem(int id) {
            foreach (Empresa.Comun.TEstandar item in this.Lista) {
                if (item.Id.Equals(id)) return item;
            }
            return new Comun.TEstandar();
        }

    }
}

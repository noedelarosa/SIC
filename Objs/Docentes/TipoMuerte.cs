using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Comun
{
    public class TipoMuerte 
    {
        public ObservableCollection<Empresa.Comun.TEstandar> Lista { get; set; }
        private static TipoMuerte _tipomuerte;

        public static TipoMuerte GetInstance() {
            if (_tipomuerte == null) _tipomuerte = new TipoMuerte();
            return _tipomuerte;
        }

        private TipoMuerte(){
            this.Lista = new ObservableCollection<TEstandar>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_TipoMuerteView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new TEstandar(fila["tmue_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["tmue_id"].ToString())));
            }
        }

        public TEstandar GetItem(int id) {
            foreach (TEstandar item in this.Lista) {
                if (item.Id.Equals(id)) return item;
            }
            return new TEstandar();
        }




    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class TipoDireccion
    {
        public ObservableCollection<TEstandar> Lista { get; set; }
        private static TipoDireccion _tipodireccion;

        public TipoDireccion(){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            Empresa.Comun.TEstandar item;

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_TipoDireccionView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                item = new TEstandar();

                item.Id = Convert.ToInt32(fila["tdire_id"]);
                item.Nombre = fila["tdire_nombre"].ToString();

                this.Lista.Add(item);
            }

        }

        public static TipoDireccion GetInstance() {
            if (_tipodireccion == null) _tipodireccion = new TipoDireccion();
            return _tipodireccion;
        }

        public TEstandar GetItem(int id) {
            foreach (TEstandar item in this.Lista) {
                if (item.Id.Equals(id)) return item;
            }
            return new TEstandar();
        }



    }
}

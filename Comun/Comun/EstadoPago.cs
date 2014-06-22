using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Comun
{
    public class EstadoPago
    {
        public ObservableCollection<TEstandar> Lista { get; set; }

        private static EstadoPago _estadopago;
        public static EstadoPago GetInstance(){
            if (_estadopago == null) _estadopago = new EstadoPago();
            return _estadopago;
        }

        private EstadoPago()
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new ObservableCollection<TEstandar>();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Comun_EstadoPago_view", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new TEstandar(fila["estp_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["estp_id"])));
            }

        }

        public static EstadoPago ReLoad(){
            _estadopago = null;
            return _estadopago;
        }

        public TEstandar GetItem(int id)
        {
            foreach (TEstandar item in this.Lista)
            {
                if (item.Id.Equals(id)) return item;
            }
            return new TEstandar();
        }
    }
}

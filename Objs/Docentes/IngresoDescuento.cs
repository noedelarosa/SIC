using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class IngresoDescuento {

        public ObservableCollection<Comun.TEstandar> Lista { get; set; }
        private static IngresoDescuento _IngresoDescuento;


        private IngresoDescuento() {
            Lista = new ObservableCollection<Comun.TEstandar>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            Comun.TEstandar item;

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[View_Minerd_IngresosDescuentos]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                item = new Comun.TEstandar();
                item.Id = Convert.ToInt32(fila["igde_id"]);
                item.Nombre = fila["igde_nombre"].ToString();
                item.Mus = fila["igde_codigo"].ToString();
                
                this.Lista.Add(item);
            }
        }
        public static IngresoDescuento GetInstance(){
            if (_IngresoDescuento == null) _IngresoDescuento = new IngresoDescuento();
            return _IngresoDescuento;
        }

        public Comun.TEstandar GetItem(int id) {
            foreach (Comun.TEstandar item in this.Lista){
                if (item.Id.Equals(id)) return item;
            }
            return new Comun.TEstandar();
        }

        public Comun.TEstandar GetItem(string codigo)
        {
            foreach (Comun.TEstandar item in this.Lista){
                if (item.Mus.Equals(codigo)) return item;
            }
            return new Comun.TEstandar();
        }

        public static void Clear()
        {
            _IngresoDescuento.Lista = null;
            _IngresoDescuento = null;
        }
    }
}

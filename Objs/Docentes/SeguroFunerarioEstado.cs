using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class SeguroFunerarioEstado
    {
        public ObservableCollection<Empresa.Comun.TEstandar> Lista { get; set; }
        private static SeguroFunerarioEstado _estadosf;

        private SeguroFunerarioEstado()
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new ObservableCollection<Comun.TEstandar>();
            Empresa.Comun.TEstandar items;

            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("SeguroFunerario_Estado_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                items = new Comun.TEstandar();

                items.Id = Convert.ToInt32(fila["esolsf_id"]);
                items.Nombre = fila["esolsf_nombre"].ToString();
                this.Lista.Add(items);
            }
        }

        public static SeguroFunerarioEstado GetInstance()
        {
            if (_estadosf == null) _estadosf = new SeguroFunerarioEstado();
            return _estadosf;
        }

        public Empresa.Comun.TEstandar GetItem(int id) {
            foreach (Empresa.Comun.TEstandar item in this.Lista){
                if (item.Id.Equals(id)) return item;
            }

            return new Comun.TEstandar();
        }

        public static void Clear()
        {
            _estadosf.Lista = null;
            _estadosf = null;
        }




    }
}

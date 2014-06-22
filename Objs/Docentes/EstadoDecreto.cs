using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
namespace Empresa.Docente
{
    public class EstadoDecreto
    {
        public ObservableCollection<Empresa.Comun.TEstandar> Lista { get; set; }
        private static EstadoDecreto _EstadoDecreto;

        private EstadoDecreto() {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new ObservableCollection<Comun.TEstandar>();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Minerd_Decretos_Estado_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new Empresa.Comun.TEstandar(fila["decs_nombre"].ToString(), string.Empty, Convert.ToInt32(fila["decs_id"])));
            }
        }

        public static EstadoDecreto GetInstance() {
            if (_EstadoDecreto == null) _EstadoDecreto = new EstadoDecreto();
            return _EstadoDecreto;
        }

        public Empresa.Comun.TEstandar GetItem(int id)
        {
            foreach (Empresa.Comun.TEstandar item in this.Lista)
            {
                if (item.Id.Equals(id)) return item;
            }
            return new Comun.TEstandar();
        }

        public static void Clear()
        {
            _EstadoDecreto.Lista = null;
            _EstadoDecreto = null;
        }

    }
}

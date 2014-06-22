using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TipoDocumento
    {
        public ObservableCollection<Empresa.Comun.TEstandar> Lista { get; set; }
        private static TipoDocumento _tipodocumento;

        public TipoDocumento(){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Comun_TipoDocumentoView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new Comun.TEstandar(fila["tipdoc_nombre"].ToString(), fila["tipdoc_descripcion"].ToString(), Convert.ToInt32(fila["tipdoc_id"])));
            }

        }

        public static TipoDocumento GetInstance() {
            if (_tipodocumento == null) _tipodocumento = new TipoDocumento();
            return _tipodocumento;
        }

        public Comun.TEstandar Getitem(int id) {
            foreach (Comun.TEstandar item in this.Lista)
            {
                if (item.Id.Equals(id)) return item;
            }
            return new Comun.TEstandar();
        }
    }
}

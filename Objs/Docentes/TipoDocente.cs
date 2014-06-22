using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class TipoDocente
    {
        public ObservableCollection<Empresa.RHH.testadolaboral> Lista { get; set; }
        private static TipoDocente _TipoDocente;
        private TipoDocente() { 
            Lista = new ObservableCollection<Empresa.RHH.testadolaboral>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Ver_Todos_TipoAfiliados]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                Lista.Add(new Empresa.RHH.testadolaboral(Convert.ToInt32(fila["taf_id"]),fila["taf_detalle"].ToString()));
            }

        }
        public static TipoDocente GetInstance() {
            if (_TipoDocente == null) _TipoDocente = new TipoDocente();
            return _TipoDocente;
        }
        public Empresa.Comun.TEstandar GetItem(int id) {
            return new Comun.TEstandar();
        }

        public static void Clear()
        {
            _TipoDocente.Lista = null;
            _TipoDocente = null;
        }
    }
}

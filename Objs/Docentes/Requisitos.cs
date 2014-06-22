using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class Requisitos
    {
        public ObservableCollection<trequisitos> Lista { get; set; }
        private static Requisitos _Requisitos;
        private Requisitos(){
            Lista = new ObservableCollection<trequisitos>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Pensiones_RequisitosSolicitudView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){    
                Lista.Add(new trequisitos(Convert.ToInt32(fila["req_id"]), fila["req_nombre"].ToString(), fila["req_descripcion"].ToString()));
            }
        }

        public static Requisitos GetInstante() {
            if (_Requisitos == null) _Requisitos = new Requisitos();
            return _Requisitos;
        }

        public trequisitos GetItem(int id) {
            foreach (trequisitos req in this.Lista) {
                if (req.Id.Equals(id)) return req;
            }
            return new trequisitos();
        }

        public static void Clear()
        {
            _Requisitos.Lista = null;
            _Requisitos = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class RequisitosSeguroFunerario
    {

        public ObservableCollection<trequisitos> Lista { get; set; }
        private static RequisitosSeguroFunerario _Requisitos;

        private RequisitosSeguroFunerario(){
            Lista = new ObservableCollection<trequisitos>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            trequisitos req;

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.SeguroFunerario_Requisito_View", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                req = new trequisitos();
                
                req.Nombre = fila["req_nombre"].ToString();
                req.Id = Convert.ToInt32(fila["req_id"].ToString());

                this.Lista.Add(req);
            }

        }

        public static RequisitosSeguroFunerario GetInstante()
        {
            if (_Requisitos == null) _Requisitos = new RequisitosSeguroFunerario();
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

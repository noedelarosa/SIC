using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Docente
{
    public class EstadoBeneficio
    {
        public ObservableCollection<Empresa.Comun.TEstandar> Lista { get; set; }
        private EstadoBeneficio() {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new ObservableCollection<Comun.TEstandar>();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Legal_EstadoBeneficioView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new Empresa.Comun.TEstandar(fila["estb_nombre"].ToString(),string.Empty,Convert.ToInt32(fila["estb_id"])));
            }
        }

        public Empresa.Comun.TEstandar GetItem(int id){
            foreach (Empresa.Comun.TEstandar item in this.Lista) {
                if (item.Id.Equals(id)) return item;
            }
            return new Comun.TEstandar();
        }

        private static EstadoBeneficio _EstadoBeneficio;
        public static EstadoBeneficio GetInstance() {
            if (_EstadoBeneficio == null) _EstadoBeneficio = new EstadoBeneficio();
            return _EstadoBeneficio;
        }
         
        public static void Clear() {
            _EstadoBeneficio.Lista = null;
            _EstadoBeneficio = null;
        }

    }
}

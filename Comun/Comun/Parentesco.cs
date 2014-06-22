using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class Parentesco: ObservableCollection<TParentesco>
    {
        private void Fill(){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Comun_ParentescoView", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Add(new TParentesco(Convert.ToInt32(fila["parn_id"]), fila["parn_nombres"].ToString()));
            }
        }
        public Parentesco(){
            this.Fill();
        }
        public TParentesco GetItem(int id){
            foreach (TParentesco item in this) {
                if (item.Id.Equals(id)) return item;
            }
            return new TParentesco();
        }

    }
}

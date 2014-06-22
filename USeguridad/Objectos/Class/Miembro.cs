using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.USeguridad
{
    public class Miembro: IList<TMiembro> {
        List<TMiembro> _Lista;
        private Grupos Gr = Grupos.GetInstance();
        private SSData.Servicios consulta;
        public Miembro(int IDUsuario) {
            _Lista = new List<TMiembro>();
            List<TGrupo> glis = new List<TGrupo>();
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@usua_id", IDUsuario);
            
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Com_ViewUsuarioGrupoAsignadoU", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
               glis.Add(Grupos.GetInstance(Convert.ToInt32(fila["grup_id"]))[0]);
            }

            _Lista.Add(new TMiembro(glis,IDUsuario));
        }

        public int IndexOf(TMiembro item){
            return _Lista.IndexOf(item);
        }

        public void Insert(int index, TMiembro item)
        {
            _Lista.Insert(index,item);
        }

        public void RemoveAt(int index){
            this._Lista.RemoveAt(index); 
        }

        public TMiembro this[int index]{
            get
            {
                return _Lista[index];
            }
            set
            {
                _Lista[index] = value;
            }
        }

        public void Add(TMiembro item)
        {
            ///
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach(TGrupo gr in item.Grupos) {
                consulta.Parameters.Add("@usua_id",gr.Id);
                consulta.Parameters.Add("@grup_id",item.IDUsuario);
                consulta.Execute.NoQuery("Com_InsertUsuarioGrupoAsignado",System.Data.CommandType.StoredProcedure);
                consulta.Parameters.ClerAll(); 
            }
        }

        public void Clear()
        {
            _Lista.Clear();
        }

        public bool Contains(TMiembro item)
        {
            return _Lista.Contains(item); 
        }

        public void CopyTo(TMiembro[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _Lista.Count; }
        }

        public bool IsReadOnly
        {
            get { return false;  }
        }

        public bool Remove(TMiembro item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TMiembro> GetEnumerator()
        {
           return _Lista.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _Lista.GetEnumerator();
        }
    }
}

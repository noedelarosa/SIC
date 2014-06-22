using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.USeguridad
{
    public class Roles:IDictionary<int,TRoles>{

        private Dictionary<int, TRoles> _Dic;
        SSData.Servicios consulta;
        public TGrupo Grupo { get; set; }

        public Roles(TGrupo grupo) {
            _Dic = new Dictionary<int, TRoles>();

            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Grupo = grupo;
            

            Rol rol = Rol.GetInstance();
            consulta.Parameters.Add("@grup_id", Grupo.Id);
             
            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("[inventario].dbo.Com_ViewUsuarioRolAsignadoG", System.Data.CommandType.StoredProcedure)){
                 while(lector.Read()){
                     _Dic.Add( Convert.ToInt32(lector["rolea_id"]), new TRoles(Convert.ToInt32(lector["rolea_id"]), rol[Convert.ToInt32(lector["role_id"])]) );
                 }
            }
        }


        public Roles(){
            _Dic = new Dictionary<int, TRoles>();
        }


        /// <summary>
        /// Agregando un Grupo a un Rol
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(int key, TRoles value){
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@grup_id", this.Grupo.Id);
            consulta.Parameters.Add("@role_id", value.Rol.Id);

            consulta.Execute.NoQuery("[inventario].[dbo].[Com_InsertUsuarioRolAsignadoG]", System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// Agregando un Grupo a un Rol
        /// </summary>
        /// <param name="value"></param>
        public void AddEx(TRoles value){
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@grup_id", value.Grupo.Id);
            consulta.Parameters.Add("@role_id", value.Rol.Id);
            
            consulta.Execute.NoQuery("[inventario].[dbo].[Com_InsertUsuarioRolAsignadoG]", System.Data.CommandType.StoredProcedure);
        }


        public bool ContainsKey(int key)
        {
            return _Dic.ContainsKey(key); 
        }

        public ICollection<int> Keys
        {
            get { return _Dic.Keys; }
        }

        public bool Remove(int key){
            return _Dic.Remove(key);
        }

        public bool TryGetValue(int key, out TRoles value){
            return this.TryGetValue(key, out value);
        }

        public ICollection<TRoles> Values{
            get { return this._Dic.Values; }
        }

        public TRoles this[int key]{
            get{
                return _Dic[key];
            }
            set{
                _Dic[key] = value;
            }
        }

        public void Add(KeyValuePair<int, TRoles> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _Dic.Clear();
        }

        public bool Contains(KeyValuePair<int, TRoles> item)
        {
            return _Dic.Contains(item); 
        }

        public void CopyTo(KeyValuePair<int, TRoles>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _Dic.Count; }
        }

        public bool IsReadOnly{
            get { return false; }
        }

        private bool _Remove(KeyValuePair<int, TRoles> item){
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@rolea_id", item.Value.Id);

            return consulta.Execute.NoQuery("[inventario].dbo.Com_DeleteUsuarioRolAsignadoG", System.Data.CommandType.StoredProcedure);
        }

        public bool Remove(KeyValuePair<int, TRoles> item){
            if( _Remove(item)){
                return _Dic.Remove(item.Key);
            }
            else {
                return false;
            }
        }

        public IEnumerator<KeyValuePair<int, TRoles>> GetEnumerator(){
            return _Dic.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
            return _Dic.GetEnumerator();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace Empresa.USeguridad
{
    public class Rol:IDictionary<int,TRol> , Empresa.Comun.IFirma  { 
        private Dictionary<int, TRol> _Dic;
        private static Rol _Rol;

        private Rol() {    
            _Dic = new Dictionary<int, TRol>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("[inventario].dbo.Com_ViewUsuarioRol", System.Data.CommandType.StoredProcedure))
            {
                while(lector.Read()) {
                    _Dic.Add(Convert.ToInt32(lector["role_id"]), new TRol(Convert.ToInt32(lector["role_id"]), lector["role_nombre"].ToString(), lector["role_descripcion"].ToString(), Convert.ToBoolean(lector["role_habilitado"])));
                }
            }
        }

        public static Rol GetInstance(){
            if (_Rol == null) _Rol = new Rol();
            return _Rol;
            
        }

        public void Add(int key, TRol value){
           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL); 
           consulta.Parameters.Add("@role_nombre", value.Nombre);
           consulta.Parameters.Add("@role_descripcion", value.Descripcion);
           consulta.Parameters.Add("@role_habilitado", value.Habilitado);
           consulta.Execute.NoQuery("[inventario].dbo.Com_InsertUsuarioRol", System.Data.CommandType.StoredProcedure);
        }

        public bool ContainsKey(int key){
            return _Dic.ContainsKey(key); 
        }
        public ICollection<int> Keys
        {
            get { return _Dic.Keys; }
        }
        public bool Remove(int key)
        {
            return _Dic.Remove(key);
        }

        public bool TryGetValue(int key, out TRol value)
        {
            return _Dic.TryGetValue(key, out value); 
        }

        public ICollection<TRol> Values
        {
            get { return _Dic.Values; }
        }

        public TRol this[int key]{
            get{
                return _Dic[key];
            }
            set {
                    SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                    consulta.Parameters.Add("@role_id", key);
                    consulta.Parameters.Add("@role_nombre", value.Nombre);
                    consulta.Parameters.Add("@role_descripcion", value.Descripcion);
                    consulta.Parameters.Add("@role_habilitado", value.Habilitado);
                    consulta.Execute.NoQuery("[inventario].dbo.Com_UpdateUsuarioRol", System.Data.CommandType.StoredProcedure);
            }
        }

        public void Add(KeyValuePair<int, TRol> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Clear(){
            _Dic.Clear();
            _Rol = null;
        }

        public bool Contains(KeyValuePair<int, TRol> item){
            return _Dic.Contains(item); 
        }

        public void CopyTo(KeyValuePair<int, TRol>[] array, int arrayIndex){
            array.CopyTo(array, arrayIndex); 
        }

        public int Count{
            get { return _Dic.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(KeyValuePair<int, TRol> item)
        {
            return _Dic.Remove(item.Key);
        }
        public IEnumerator<KeyValuePair<int, TRol>> GetEnumerator()
        {
            return _Dic.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
            return _Dic.GetEnumerator();
        }

        public string Nombre { get { return "Rol"; } }

        public string Modulo
        {
            get {
                return new Empresa.Comun.Info(System.Reflection.Assembly.GetExecutingAssembly()).ModuloNombre;
            }
        }

        public string CModulo
        {
            get {return new Empresa.Comun.Info(System.Reflection.Assembly.GetExecutingAssembly()).GUID; }
        }

        public string objecto
        {
            get { return this.Nombre; }
        }

        public string Cobjecto
        {
            get { return "rolobj_9386Ui_p1rqnjk70"; }
        }
        public string Descripcion
        {
            get { return "Rol Usuario"; }
        }
    }
}

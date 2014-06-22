using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace Empresa.USeguridad
{
    public class Recurso: IDictionary<string,TRecurso>, Empresa.Comun.IFirma {

        private Dictionary<string, TRecurso> _Dic = new Dictionary<string,TRecurso>();
        private static Recurso _Recursos;
        SSData.Servicios consulta;
        
        private Recurso() {
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("[inventario].dbo.Com_ViewUsuarioRecursos", System.Data.CommandType.StoredProcedure)){
                while (lector.Read()){
                    _Dic.Add(lector["usuar_codigo"].ToString(), new TRecurso(Convert.ToInt32(lector["usuar_id"]), lector["usuar_Nombre"].ToString(), lector["usuar_Codigo"].ToString(), lector["usuar_Modulo"].ToString(), lector["usuar_CModulo"].ToString()));
                }
            }
        }

        public Dictionary<string, TRecurso> Source(string key) {
            var resul = from x in _Dic where x.Value.Codigo.Equals(key) select x;
            return (Dictionary<string, TRecurso>)resul;
        }

        public static Recurso GetInstance(){
            if (_Recursos == null) _Recursos = new Recurso();
            return _Recursos;
        }

        public void Flush()
        {
            this._Dic = null;
            _Recursos = null;
        }

        public void Add(string key, TRecurso value){
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usuar_nombre", value.Nombre);
            consulta.Parameters.Add("@usuar_codigo", value.Codigo);
            consulta.Parameters.Add("@usuar_modulo", value.Modulo);
            consulta.Parameters.Add("@suar_cmodulo", value.CModulo);

            consulta.Execute.NoQuery("[inventario].dbo.Com_InsertUsuarioRecursos", System.Data.CommandType.StoredProcedure);
            _Dic.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _Dic.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return _Dic.Keys; }
        }

        public bool Remove(string key)
        {
            return _Dic.Remove(key);
        }

        public bool TryGetValue(string key, out TRecurso value)
        {
            return _Dic.TryGetValue(key,out value);
        }

        public ICollection<TRecurso> Values
        {
            get { return _Dic.Values; }
        }
        public TRecurso this[string key]
        {
            get{
                return _Dic[key];
            }
            set{
                _Dic[key]=value;
            }
        }
        public void Add(KeyValuePair<string, TRecurso> item){
            if (!_Dic.ContainsKey(item.Key)){
                this.Add(item.Key, item.Value);
                _Dic.Add(item.Key, item.Value);
            }
        }

        public void Clear(){
            _Dic.Clear();
        }

        public bool Contains(KeyValuePair<string, TRecurso> item){
            return _Dic.Contains(item); 
        }

        public void CopyTo(KeyValuePair<string, TRecurso>[] array, int arrayIndex){
            array.CopyTo(array, arrayIndex); 
        }

        public int Count{
            get { return _Dic.Count; }
        }

        public bool IsReadOnly{
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, TRecurso> item){
            return this._Dic.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, TRecurso>> GetEnumerator(){
            return _Dic.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
            return _Dic.GetEnumerator();
        }

        public string Nombre { get { return "Recursos"; } }

        public string Modulo
        {
            get {
                return string.Empty;
                //return new Empresa.Comun.Info(System.Reflection.Assembly.GetExecutingAssembly()).ModuloNombre; 
            }
        }

        public string CModulo
        {
            get {
                return string.Empty;
                //return new Empresa.Comun.Info(System.Reflection.Assembly.GetExecutingAssembly()).GUID; 
            }
        }

        public string objecto
        {
            get { return this.Nombre; }
        }

        public string Cobjecto
        {
            get { return "recobj_83O-llg_.87120"; }
        }

        public string Descripcion
        {
            get { return "Recurso de la aplicación"; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace Empresa.USeguridad
{
    public class Permisos : IDictionary<string, Permiso>
    {
        //RECURSOS ASIGNADOS

        private Dictionary<string, Permiso> _Dic;
        

        public Permisos(int IDRol)
        {
            //cursos rec = Recursos.GetInstance();
            _Dic = new Dictionary<string, Permiso>();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@role_id", IDRol);
            using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Com_ViewUsuarioPermisoAsignadoROL", System.Data.CommandType.StoredProcedure))
            {
                while (lector.Read()){
                    ///Cargando Recursos desde la misma CONSULTA.
                    //Permiso per = (Permiso)Convert.ToByte(lector["usuap_id"]);
                    //_Dic.Add(lector["usuar_codigo"].ToString(), per);
                }
            }
        }

        //public static Permisos GetInstance(int IDRol){
           
        //}

        public void Add(string key, Permiso value)
        {
            _Dic.Add(key, value); 
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKeyParValue(string key, Permiso value){
            Permiso valuetemp;
            if(TryGetValue(key, out valuetemp)){
                return (valuetemp.Equals(value));
            }
            return false;
        }
        public ICollection<string> Keys
        {
            get { return _Dic.Keys; }
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out Permiso value)
        {
            return _Dic.TryGetValue(key, out value);
        }

        public ICollection<Permiso> Values
        {
            get { return _Dic.Values; }
        }

        public Permiso this[string key]
        {
            get
            {
                return _Dic[key];
            }
            set
            {
                _Dic[key] = value;
            }
        }

        public void Add(KeyValuePair<string, Permiso> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _Dic.Clear();
        }

        public bool Contains(KeyValuePair<string, Permiso> item)
        {
            return _Dic.Contains(item); 
        }

        public void CopyTo(KeyValuePair<string, Permiso>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _Dic.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, Permiso> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, Permiso>> GetEnumerator()
        {
            return _Dic.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return  _Dic.GetEnumerator();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Empresa.USeguridad
{
    public class Autorizacion : IDictionary<int,TAutorizacion>
    {
        private Dictionary<int, TAutorizacion> _Dic;
        public int Rol { get; set; }
        
        public Autorizacion(){
            _Dic = new Dictionary<int, TAutorizacion>();
        }

        public Autorizacion(int rol){
            this.Rol = rol;
            _Dic = new Dictionary<int, TAutorizacion>();
            Recurso rec = Recurso.GetInstance();

            //Dictionary<int, TBoleto> dicboletos = new Dictionary<int, TBoleto>();
            TBoleto tbo;

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("role_id", rol);

            Permiso per = new Permiso();
            Accion aci = new Accion();
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[inventario].dbo.Com_ViewUsuarioPermisoAsignadoROL", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {


                var accion = aci.Where(vaccion => vaccion.Id == Convert.ToInt32(fila["usuaa_id"])).First();
                var permiso = per.Where(vpermi => vpermi.Id == Convert.ToInt32(fila["usuap_id"])).First();
                tbo = new TBoleto(permiso, accion);

                //dicboletos.Add(dicboletos.Count, tbo);
                
                _Dic.Add(Convert.ToInt32(fila["usuapa_id"]), new TAutorizacion(tbo, rec[fila["usuar_codigo"].ToString()]));
            }
        }
        
        public Autorizacion(int rol, int usuario){
            _Dic = new Dictionary<int, TAutorizacion>();
            


            
        }
        
        public Autorizacion(object item){
            if(item.GetType().Equals(Type.GetType("TRol"))){
                
                

            
            }
            if (item.GetType().Equals(Type.GetType("TUsuario"))){




            }
            _Dic = new Dictionary<int, TAutorizacion>();
        }

        public void Add(int key, TAutorizacion value){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
               
            //foreach(KeyValuePair<int,TBoleto> bol in value.Boleto) {
                consulta.Parameters.Add("@role_id", this.Rol);
                consulta.Parameters.Add("@usuaa_id",value.Boleto.Accion.Id);
                consulta.Parameters.Add("@usuap_id",value.Boleto.Permiso.Id);
                consulta.Parameters.Add("@usuar_id",value.Recurso.Id);
                consulta.Execute.NoQuery("[inventario].[dbo].[Com_InsertUsuarioPermisoAsignado]", System.Data.CommandType.StoredProcedure);
                consulta.Parameters.ClerAll(); 
            //}
        }

        public bool ContainsKey(int key){
            return _Dic.ContainsKey(key); 
        }

        public ICollection<int> Keys
        {
            get {
                return _Dic.Keys;
            }
        }

        public bool Remove(int key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int key, out TAutorizacion value)
        {
            return _Dic.TryGetValue(key,out value);
        }

        public ICollection<TAutorizacion> Values
        {
            get { return _Dic.Values; }
        }

        public TAutorizacion this[int key]
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

        public void Add(KeyValuePair<int, TAutorizacion> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            this._Dic.Clear();
        }

        public bool Contains(KeyValuePair<int, TAutorizacion> item)
        {
            return _Dic.Contains<KeyValuePair<int, TAutorizacion>>(item);
        }

        public void CopyTo(KeyValuePair<int, TAutorizacion>[] array, int arrayIndex)
        {
            CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _Dic.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<int, TAutorizacion> item){
            throw new NotImplementedException();        
        }

        public IEnumerator<KeyValuePair<int, TAutorizacion>> GetEnumerator()
        {
            return _Dic.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _Dic.GetEnumerator();
        }
    }
}

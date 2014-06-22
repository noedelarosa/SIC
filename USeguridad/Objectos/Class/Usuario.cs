using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Empresa.USeguridad
{
    public class Usuario:IList<TUsuario>, Empresa.Comun.IFirma
    {
        List<TUsuario> _Lista;
        private SSData.Servicios consulta;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Usuario(){
            _Lista = new List<TUsuario>();
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[inventario].dbo.Com_ViewUsuarioTodos", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                _Lista.Add(new TUsuario(Convert.ToInt32(fila["usua_id"]), fila["usua_nombre"].ToString(), fila["usua_pclave"].ToString(), string.Empty, Convert.ToBoolean(fila["usua_habilitado"])));
            }

        }

        public Usuario(bool habilitado){
            _Lista = new List<TUsuario>();
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usua_habilitado", habilitado);
            TUsuario _usuario;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[inventario].dbo.Com_ViewUsuarioHab", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                _usuario = new TUsuario(Convert.ToInt32(fila["usua_id"]), fila["usua_nombre"].ToString(), fila["usua_pclave"].ToString(), string.Empty, Convert.ToBoolean(fila["usua_habilitado"]));
                _usuario.Personal = new Comun.tbasepersona(fila["per_Cedula"].ToString());
                _Lista.Add(_usuario);
            }

        }

        public Usuario(int id){
            _Lista = new List<TUsuario>();
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usua_id", id);
            TUsuario _usuario;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[inventario].dbo.Com_ViewUsuarioID", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                _usuario = new TUsuario(Convert.ToInt32(fila["usua_id"]), fila["usua_nombre"].ToString(), fila["usua_pclave"].ToString(), string.Empty, Convert.ToBoolean(fila["usua_habilitado"]));
                _usuario.Personal = new Comun.tbasepersona(fila["per_Cedula"].ToString());
                _Lista.Add(_usuario);
                //_Lista.Add(new TUsuario(Convert.ToInt32(fila["usua_id"]), fila["usua_nombre"].ToString(), fila["usua_pclave"].ToString(), string.Empty, Convert.ToBoolean(fila["usua_habilitado"])));
            }
        }

        public Usuario(string nombre)
        {
            _Lista = new List<TUsuario>();
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usua_nombre", nombre);
            System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("[inventario].[dbo].[Com_ViewUsuarioAutenticadoNCs]", System.Data.CommandType.StoredProcedure);
            TUsuario _usuario;
            if (lector.Read()){
                //_Lista.Add(new TUsuario(Convert.ToInt32(lector["usua_id"]), lector["usua_nombre"].ToString(), lector["usua_pclave"].ToString(), string.Empty, Convert.ToBoolean(lector["usua_habilitado"])));
                _usuario = new TUsuario(Convert.ToInt32(lector["usua_id"]), lector["usua_nombre"].ToString(), lector["usua_pclave"].ToString(), string.Empty, Convert.ToBoolean(lector["usua_habilitado"]));
                _usuario.Personal = new Comun.tbasepersona(lector["per_Cedula"].ToString());
                _Lista.Add(_usuario);
            }
        }

        public Usuario(string nombre, bool habilitado)
        {
            _Lista = new List<TUsuario>();
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usua_nombre", nombre);
            consulta.Parameters.Add("@usua_habilitado", habilitado);
            System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("[inventario].[dbo].[Com_ViewUsuarioAutenticadoNChs]", System.Data.CommandType.StoredProcedure);
            TUsuario _usuario;
            if (lector.Read())
            {
                _usuario = new TUsuario(Convert.ToInt32(lector["usua_id"]), lector["usua_nombre"].ToString(), lector["usua_pclave"].ToString(), string.Empty, Convert.ToBoolean(lector["usua_habilitado"]));
                _usuario.Personal = new Comun.tbasepersona(lector["per_Cedula"].ToString());
                _Lista.Add(_usuario);
                //_Lista.Add(new TUsuario(Convert.ToInt32(lector["usua_id"]), lector["usua_nombre"].ToString(), lector["usua_pclave"].ToString(), string.Empty, Convert.ToBoolean(lector["usua_habilitado"])));
            }
        }

        public int IndexOf(TUsuario item){
            return _Lista.IndexOf(item);
        }

        public void Insert(int index, TUsuario item){
            _Lista.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _Lista.RemoveAt(index); 
        }

        private void update(TUsuario item){
                consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                consulta.Parameters.Add("@usua_Id", item.Id);
                consulta.Parameters.Add("@usua_nombre", item.Nombre);
                consulta.Parameters.Add("@usua_Habilitado", item.Habilitado);
                consulta.Parameters.Add("@usua_pclave", item.PClave);
                consulta.Execute.NoQuery("[inventario].[dbo].[Com_UpdateUsuario]", System.Data.CommandType.StoredProcedure);
        }

        public TUsuario this[int index]
        {
            get {
                var resul = from x in _Lista where x.Id.Equals(index) select x;
                if (resul != null) return resul.ToList<TUsuario>()[0];
                return new TUsuario();
            }
            set{
                var resul = from x in _Lista where x.Id.Equals(index) select x;

                if (resul != null) {

                    if (value.IsValid()){
                        this.update(value);
                        _Lista[_Lista.IndexOf(resul.ToList<TUsuario>()[0])] = value;
                    }

                } 
            }
        }

        public void Add(TUsuario item){
            if (item.IsValid())
            {
                item.BorrarError("Nombre");
                if (!this.Contains(item.Nombre))
                { 
                    Seguridad.Seguridades.Encriptacion encry = new Seguridad.Seguridades.Encriptacion();
                    consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                    consulta.Parameters.Add("@usua_nombre", item.Nombre);
                    consulta.Parameters.Add("@usua_clave", encry.Encriptar(item.Clave));
                    consulta.Parameters.Add("@usua_Habilitado", item.Habilitado);
                    consulta.Parameters.Add("@usua_pclave", item.PClave);

                    try
                    {
                        consulta.Execute.NoQuery("[inventario].[dbo].[Com_InsertUsuario]", System.Data.CommandType.StoredProcedure);
                        _Lista.Add(item);
                        ///this.PropertyChanged = new PropertyChangedEventHandler(this, new  PropertyChangedEventArgs("_Lista"));  
                        //PropertyChanged(this, new PropertyChangedEventArgs("Count"));

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else {
                    item.AgregoError("Nombre", "Nombre Existente"); 
                }
            }
        }

        public void Clear(){
            _Lista.Clear();
        }

        public TUsuario FirstItem() {
            return _Lista[0];
        }

        public bool Contains(TUsuario item){
            return _Lista.Contains(item); 
        }

        public bool Contains(string nombre)
        {
            bool ret = false;
            foreach (TUsuario item in _Lista) {
                if (item.Nombre.Equals(nombre)) {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public bool Contains(int id)
        {
            bool ret = false;
            foreach (TUsuario item in _Lista)
            {
                if (item.Id.Equals(id))
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public void CopyTo(TUsuario[] array, int arrayIndex)
        {
            _Lista.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _Lista.Count; }
        }

        public bool IsReadOnly{
            get { return false; }
        }

        public bool Remove(TUsuario item){
            return _Lista.Remove(item);
        }

        public IEnumerator<TUsuario> GetEnumerator(){
            return _Lista.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator(){
            return _Lista.GetEnumerator();
            //var r = usu[0].Miembro[0].Grupos[0].Role.
        }

        public string Nombre { get { return "Usuario"; } }

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
            get { return "usuobj_OpnA587130L.mA"; }
        }

        public string Descripcion
        {
            get { return "Usuario"; }
        }
        
    }
}

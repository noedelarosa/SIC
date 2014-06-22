using System;
using System.Collections.Generic;
using System.Linq;

namespace Empresa.USeguridad
{
    public class Grupos: IList<TGrupo>, Empresa.Comun.IFirma
    {
        private List<TGrupo> _Lista = new List<TGrupo>();
        private static Grupos _Grupos;

        SSData.Servicios consulta;
        private Grupos(){
             consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

             foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[inventario].dbo.Com_ViewGrupos", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
             _Lista.Add(new TGrupo(Convert.ToInt32(fila["grup_id"]),fila["grup_nombre"].ToString(),Convert.ToBoolean(fila["grup_habilitado"])));
             }
        }

        private Grupos(bool habilitado){
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@grup_habilitado", habilitado);
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[inventario].dbo.Com_ViewGruposH", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                _Lista.Add(new TGrupo(Convert.ToInt32(fila["grup_id"]), fila["grup_nombre"].ToString(), Convert.ToBoolean(fila["grup_habilitado"])));
            }
        }

        public static Grupos GetInstance(){
            //if (_Grupos == null) 
            _Grupos = new Grupos();
            return _Grupos;
        }

        public static Grupos GetInstance(bool habilitado){
            _Grupos = new Grupos(habilitado);
            return _Grupos;
        }

        public static List<TGrupo> GetInstance(int idGrupo){
            if (_Grupos == null) _Grupos = new Grupos();
            var resul = from x in _Grupos where x.Id.Equals(idGrupo) select x;
            return resul.ToList(); 
        }

        public int IndexOf(TGrupo item){
            var resul = from x in _Lista where x.Nombre.Equals(item.Nombre) select x.Id;
            return resul.Single();
        }

        public void Insert(int index, TGrupo item)
        {
            _Lista.Insert(index, item);
        }

        public void RemoveAt(int index){
            _Lista.RemoveAt(index);
        }
        private TGrupo update(int index, TGrupo item){

            try {

                consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                consulta.Parameters.Add("@grup_id", index);
                consulta.Parameters.Add("@grup_nombre", item.Nombre);
                consulta.Parameters.Add("@grup_descripcion", string.Empty);
                consulta.Parameters.Add("@grup_habilitado", item.Habilitado);
                consulta.Execute.Dataset("[inventario].dbo.Com_UpdateUsuarioGrupo", System.Data.CommandType.StoredProcedure);
                
                return item;
            
            }
            catch(Exception ex){
                //Empresa.Comun.RegFunEvento.Reg(ex.Message);
                return null;
            }

        }

        public TGrupo this[int index]
        {
            get{
                var resul = (from x in _Lista where x.Id.Equals(index) select x).ToList<TGrupo>()[0];
                return resul;
            }
            set{
                var tmp = this.update(index, value);
                if (tmp != null) {
                   _Lista[ _Lista.IndexOf( (from x in _Lista where x.Id.Equals(index) select x).ToList<TGrupo>()[0] )  ] = value;
                }
            }
        }
        public void Add(TGrupo item) {
            this.AddEx(item);
        }

        /// <summary>
        /// Add Extra
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int AddEx(TGrupo item){
            if(item.IsValid()){
                    consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

                    consulta.Parameters.Add("@grup_nombre", item.Nombre);
                    consulta.Parameters.Add("@grup_descripcion", item.Descripcion);
                    consulta.Parameters.Add("@grup_habilitado", item.Habilitado);

                    return  Convert.ToInt32(consulta.Execute.Dataset("[inventario].dbo.Com_InsertUsuarioGrupo", System.Data.CommandType.StoredProcedure).Tables[0].Rows[0].ItemArray[0].ToString());
             }else{
                return 0;
            }
        }

        public void Clear(){
            _Lista.Clear();
            _Grupos = null;
        }

        public bool Contains(TGrupo item)
        {
            return _Lista.Contains(item);
        } 
        public bool Contains(string nombre)
        {
            var resul = from x in _Lista where x.Nombre.ToLower().Equals(nombre.ToLower()) select x;
            return resul.Count() > 0 ? true : false;
        }

        public void CopyTo(TGrupo[] array, int arrayIndex)
        {
            this._Lista.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _Lista.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(TGrupo item)
        {
           return _Lista.Remove(item);
        }

        public IEnumerator<TGrupo> GetEnumerator()
        {
            return _Lista.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _Lista.GetEnumerator();
        }

        public string Modulo
        {
            get { return "Usuario"; }
        }

        public string CModulo
        {
            get { return "adfadfadfadfdas"; }
        }

        public string objecto
        {
            get { return "Grupo"; }
        }

        public string Cobjecto
        {
            get { return "gruobj_IoGrew:lad584097r"; }
        }

        public string Nombre
        {
            get { return "Grupo Usuario"; }
        }

        public string Descripcion
        {
            get { return "Grupo de usuarios"; }
        }
    }
}

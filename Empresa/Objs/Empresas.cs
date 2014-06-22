namespace Empresa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Empresas : IList<TEmpresa>  
    {
        public static TEmpresa EmpresaActual {get;set;}
        private static Empresas _Empresa;
        private List<TEmpresa> _List = new List<TEmpresa>();

        public void Asigno(TEmpresa item){
            EmpresaActual= Source(item)[0];
        }

        public static void Inicializar(){
            GetInstance();
        }
        
        public static Empresas GetInstance(){
            if(_Empresa == null){_Empresa = new Empresas();}
            return _Empresa;
        }

        private Empresas(){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            //Empresa.Comun.Direccion dir = Empresa.Comun.Direccion.GetInstance();
            //foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Com_View_Todas_INV_Empresa]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
            //    _List.Add(new TEmpresa(Convert.ToInt32(fila["Emp_id"]), fila["Emp_nombre"].ToString(), fila["Emp_rnc"].ToString(), fila["Emp_telefono"].ToString(), fila["Emp_telefono1"].ToString(), fila["Emp_fax"].ToString(), fila["Emp_web"].ToString(), fila["Emp_email1"].ToString(), fila["Emp_email2"].ToString(), dir.Source(new Comun.TDireccion(Convert.ToInt32(fila["dire_id"])))[0], fila["Emp_logo"], fila["Emp_descripcion"].ToString(), new RHH.Personal((int)fila["pers_id"])[0]));
            //}

        }

        public void update(TEmpresa item){
            throw new NotImplementedException();
        }

        public List<TEmpresa> Source(){
            return _List;
        }

        public TEmpresa Source(int id){
            var resul = from x in _List where x.Id.Equals(id) select x;
            if (resul.Count() > 0){
                return resul.ToList<TEmpresa>()[0]; 
            }
            else{
                return new TEmpresa();
            }
        }

        public List<TEmpresa> Source(TEmpresa item){
            var resul = from x in _List where x.Id==item.Id select x;
            return resul.ToList<TEmpresa>();
        }
        
        public System.Collections.IEnumerable SourceView(){
            //var resul = from x in _List select new { x.Id, x.Nombre, x.Rnc, x.Logo, x.Telefono, x.Telefono1, x.Fax, x.Web, x.Descripcion, NumeroResidencia = x.Direccion.ReferenciaResidencia, Residencia = x.Direccion.ReferenciaSitio, Sector = x.Direccion.Sector.Nombre, Municipio = x.Direccion.Sector.Municipio.Nombre, Provincia = x.Direccion.Sector.Municipio.Provincia.Nombre };
            //return resul; 
            return null;
        }

        //public System.Data.DataSet SourceView(TEmpresa item)
        //{
        //    var resul = from x in _List select new { x.Id, x.Nombre, x.Rnc, x.Logo, x.Telefono, x.Telefono1, x.Fax, x.Web, x.Descripcion, NumeroResidencia = x.Direccion.ReferenciaResidencia, Residencia = x.Direccion.ReferenciaSitio, Sector = x.Direccion.Sector.Nombre, Municipio = x.Direccion.Sector.Municipio.Nombre, Provincia = x.Direccion.Sector.Municipio.Provincia.Nombre };
        //    return CollectionExtensions.ToDataSet(resul, "Empresa");
        //}

        public int IndexOf(TEmpresa item){
            throw new NotImplementedException();
        }

        public void Insert(int index, TEmpresa item){
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public TEmpresa this[int index]
        {
            get
            {
                return _List[index];
            }
            set
            {
                _List[index] = value;
            }
        }

        public void Add(TEmpresa item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _List.Clear();
        }

        public bool Contains(TEmpresa item)
        {
            return _List.Contains(item); 
        }

        public void CopyTo(TEmpresa[] array, int arrayIndex)
        {
            this.CopyTo(array, arrayIndex); 
        }

        public int Count
        {
            get { return _List.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(TEmpresa item)
        {
            return _List.Remove(item);
        }

        public IEnumerator<TEmpresa> GetEnumerator()
        {
            return _List.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _List.GetEnumerator();
        }
    }
}


namespace Empresa.RHH
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;

   public class Departamento:IList<TDepartamento> {
       private List<TDepartamento> _Lista  = new List<TDepartamento>();
       private static Departamento _Departamento;

       public List<TDepartamento> Source(){
           return _Lista; 
       }

       public List<TDepartamento> Source(int id) {
           var resul = from x in _Lista where x.Id.Equals(id) select x;
           return resul.ToList<TDepartamento>(); 
       }

       public List<TDepartamento> Source(string nombre){
           var resul = from x in _Lista where x.Nombre.ToLower().StartsWith(nombre.ToLower())  || x.Nombre.ToLower().Contains(nombre.ToLower()) select x;
           return resul.ToList<TDepartamento>();
       }

       private Departamento(){
           _Lista = new List<TDepartamento>();
           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

           consulta.Parameters.Add("@emp_id", 0); // Emrpesa por defecto inabima...
           foreach (System.Data.DataRow fila in consulta.Execute.Dataset("INVENTARIO.dbo.RHH_View_Departamentos", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
               TDepartamento depa = new TDepartamento(Convert.ToInt32(fila["depa_id"]), fila["depa_nombre"].ToString(), string.Empty, fila["depa_email"].ToString());
               depa.Abreviatura = fila["depa_abreviatura"] == null ? string.Empty : fila["depa_abreviatura"].ToString();
               _Lista.Add(depa);
           }
       }

       public static Departamento GetInstance() {
           if (_Departamento == null) 
           {
               _Departamento = new Departamento();
           }
           return _Departamento;
       }

       //public Departamento(int id) {
       //    _Lista = new List<TDepartamento>();
       //    SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
       //    consulta.Parameters.Add("@emp_id", Empresa.Empresas.EmpresaActual.Id);
       //    consulta.Parameters.Add("@depe_id", id);
       //    foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.RHH_View_DepartamentosID", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
       //    {
       //        _Lista.Add(new TDepartamento(Convert.ToInt32(fila["depa_id"]), fila["depa_nombre"].ToString(), string.Empty));
       //    }
       
       //}

       public int IndexOf(TDepartamento item)
       {
           return _Lista.IndexOf(item); 
       }

       public void Insert(int index, TDepartamento item)
       {
           this._Lista.Insert(index, item); 
       }
       
       public void RemoveAt(int index)
       {
           _Lista.RemoveAt(index); 
       }

       public TDepartamento this[int index]{
           get{
               return this._Lista[index];
           }
           set{
               this._Lista[index] = value; 
           }
       }

       public void Add(TDepartamento item)
       {
           this._Lista.Add(item);
       }

       public void Clear()
       {
           this._Lista.Clear();
       }

       public bool Contains(TDepartamento item)
       {
           return this._Lista.Contains(item); 
       }

       public void CopyTo(TDepartamento[] array, int arrayIndex)
       {
           this._Lista.CopyTo(array, arrayIndex);
       }

       public int Count
       {
           get { return this._Lista.Count; }
       }

       public bool IsReadOnly
       {
           get { return false; }
       }

       public bool Remove(TDepartamento item)
       {
           return this._Lista.Remove(item);
       }

       public IEnumerator<TDepartamento> GetEnumerator()
       {
           return _Lista.GetEnumerator();
       }

       System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
       {
           return _Lista.GetEnumerator();
       }
       
   }
}

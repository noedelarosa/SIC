using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.RHH
{
   public class EstadoLaboral:IList<testadolaboral>
    {
       private static EstadoLaboral __EstadoLaboral;
       private List<testadolaboral> _Lista; 

       private void _EstadoLaboral(){
           _Lista = new List<testadolaboral>();
            //procedimiento: ViewTodo_TipoAfiliado
           _Lista.Add(new testadolaboral(1, "Activo(a)","A"));
           _Lista.Add(new testadolaboral(2, "Jubilado(a)","J"));
           _Lista.Add(new testadolaboral(3, "Pensionado(a)","P"));
       }

       private EstadoLaboral(){
           _EstadoLaboral();
       }

       public static EstadoLaboral GetInstance(){
           if (__EstadoLaboral == null) __EstadoLaboral = new EstadoLaboral();
           return __EstadoLaboral;
       }

       public int IndexOf(testadolaboral item){
           throw new NotImplementedException();
       }

       public void Insert(int index, testadolaboral item)
       {
           throw new NotImplementedException();
       }

       public void RemoveAt(int index)
       {
           throw new NotImplementedException();
       }

       private testadolaboral GetIndexRoot(int index) {
           var resul = from x in _Lista where x.Id.Equals(index) select x;
           if (resul.Count() > 0){
               return resul.ToList<testadolaboral>()[0];
           }
           else { 
           return new testadolaboral();
           }
       }

       private void SetIndexRoot(int index, testadolaboral value) {
           var resul = from x in _Lista where x.Id.Equals(index) select x=value;
       }
       public testadolaboral this[int index]{
           get
           {
               return this.GetIndexRoot(index); 
           }
           set
           {
               this.SetIndexRoot(index, value);       
           }
       }

       public void Add(testadolaboral item){
           _Lista.Add(item);
       }

       public void Clear(){
           _Lista.Clear();
       }

       public bool Contains(testadolaboral item){
           return _Lista.Contains(item);
       }

       public void CopyTo(testadolaboral[] array, int arrayIndex)
       {
           throw new NotImplementedException();
       }

       public int Count
       {
           get { return _Lista.Count; }
       }

       public bool IsReadOnly
       {
           get { return false; }
       }

       public bool Remove(testadolaboral item)
       {
           throw new NotImplementedException();
       }

       public IEnumerator<testadolaboral> GetEnumerator()
       {
           return _Lista.GetEnumerator();
       }

       System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
       {
           return _Lista.GetEnumerator();
       }
    }
}


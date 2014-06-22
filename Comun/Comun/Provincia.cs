namespace Empresa
{
    namespace Comun
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        public class Provincia:IList<TDireccion>
        {
            private static Provincia _Provincia;
            private List<TProvincia> _Lista = new List<TProvincia>();
            private Provincia()
            {
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Com_View_Todas_Provincias", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                    _Lista.Add(new TProvincia(Convert.ToInt32(fila["Provi_id"]), fila["Provi_nombre"].ToString(), fila["provi_codigo"].ToString()));
                }

            }

            public static Provincia GetInstance(){
                if (_Provincia == null) { _Provincia = new Provincia(); }
                return _Provincia;
            }
            public void update(TProvincia item)
            {
                throw new NotImplementedException();
            }

            public List<TProvincia> Source()
            {
                return _Lista;
            }
            public List<TProvincia> Source(TProvincia item)
            {
                var result = from x in _Lista where x.Codigo == item.Codigo select x;
                return result.ToList<TProvincia>();
            }

            public TProvincia GetItem(int id)
            {
                foreach (TProvincia item in this._Lista)
                {
                    if (item.Id.Equals(id)) return item;
                }
                return new TProvincia();
            }

            public TProvincia Source(int id)
            {
                if(!id.Equals(0)) {
                    var result = from x in _Lista where x.Id.Equals(id) select x;
                    return result.ToList<TProvincia>()[0];
                }else {
                    return new TProvincia();
                } 
            }

            public System.Collections.IEnumerable SourceView()
            {
                throw new NotImplementedException();
            }

            public int IndexOf(TProvincia item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, TProvincia item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            public TProvincia this[int index]
            {
                get{
                    return this._Lista[index]; 
                }
                set{
                    this._Lista[index] = value;
                }
            }

            public void Add(TProvincia item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                _Lista.Clear();
            }

            public bool Contains(TProvincia item)
            {
                return _Lista.Contains(item);
            }

            public void CopyTo(TProvincia[] array, int arrayIndex)
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

            public bool Remove(TProvincia item)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<TProvincia> GetEnumerator()
            {
                return _Lista.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _Lista.GetEnumerator();
            }

            public void update(TDireccion item)
            {
                throw new NotImplementedException();
            }

            public int IndexOf(TDireccion item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, TDireccion item)
            {
                throw new NotImplementedException();
            }

            TDireccion IList<TDireccion>.this[int index]
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public void Add(TDireccion item)
            {
                throw new NotImplementedException();
            }

            public bool Contains(TDireccion item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(TDireccion[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(TDireccion item)
            {
                throw new NotImplementedException();
            }

            IEnumerator<TDireccion> IEnumerable<TDireccion>.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
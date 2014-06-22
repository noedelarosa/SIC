namespace Empresa
{
    namespace Comun
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        public class Municipio : IList<TMunicipio>
        {
            private static Municipio _Municipio;
            private List<TMunicipio> _Lista = new List<TMunicipio>();

            private Municipio(){

                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                Provincia pro = Provincia.GetInstance();

                foreach(System.Data.DataRow fila in consulta.Execute.Dataset("Com_View_TodasMunicipio", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                    _Lista.Add(new TMunicipio(Convert.ToInt32(fila["Muni_id"]), fila["Muni_Nombre"].ToString(), pro.Source(new TProvincia(fila["provi_codigo"].ToString()))[0], fila["muni_codigo"].ToString()));
                }

            }

            public static Municipio GetInstance()
            {
                if (_Municipio == null) { _Municipio = new Municipio(); }
                return _Municipio;
            }

            public void update(TMunicipio item)
            {
                throw new NotImplementedException();
            }

            public List<TMunicipio> Source()
            {
                return _Lista;
            }

            public List<TMunicipio> Source(int id){
                
                if (id.Equals(0)){
                    return new List<TMunicipio>();
                }else {
                    var result = from x in _Lista where x.Id.Equals(id) select x;
                    return result.ToList<TMunicipio>();
                }

            }

            public TMunicipio GetItem(int id)
            {
                foreach (TMunicipio item in this._Lista)
                {
                    if (item.Id.Equals(id)) return item;
                }
                return new TMunicipio();
            }


            public List<TMunicipio> Source(TProvincia item){
                if (item != null)
                {
                    var resul = from x in _Lista where x.Provincia.Codigo.Equals(item.Codigo) select x;
                    return resul.ToList<TMunicipio>();
                }
                else {
                    return new List<TMunicipio>();
                }
            }

            public System.Collections.IEnumerable SourceView()
            {
                throw new NotImplementedException();
            }

            public int IndexOf(TMunicipio item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, TMunicipio item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            public TMunicipio this[int index]
            {
                get
                {
                    return _Lista[index];
                }
                set
                {
                    _Lista[index]= value;
                }
            }

            public void Add(TMunicipio item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                _Lista.Clear();
            }

            public bool Contains(TMunicipio item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(TMunicipio[] array, int arrayIndex)
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

            public bool Remove(TMunicipio item)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<TMunicipio> GetEnumerator()
            {
                return _Lista.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _Lista.GetEnumerator();
            }
        }
    }
}
namespace Empresa.Comun
{
        using System;
        using System.Collections.Generic;
        using System.Linq;
        public class Sector :IList<TSector>
        {
            private static Sector _Sector;
            private List<TSector> _Lista = new List<TSector>();
            private Sector(){
                //Provincia pro = Provincia.GetInstance();
                Municipio mun = Municipio.GetInstance();
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Com_View_TodasSector", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
                {
                    _Lista.Add(new TSector(Convert.ToInt32(fila["sect_id"]), fila["sect_nombre"].ToString(), mun.Source(Convert.ToInt32(fila["muni_codigo"].ToString()))[0], fila["sect_codigo"].ToString()));
                }
            }
            public static Sector GetInstance(){
                if (_Sector == null) { _Sector = new Sector(); }
                return _Sector;
            }

            public void update(TSector item){
                throw new NotImplementedException();
            }

            public List<TSector> Source(){
                return _Lista;
            }

            public List<TSector> Source(int id){
                    var resul = from x in _Lista where x.Id.Equals(id) select x;
                    return resul.ToList<TSector>();
            }

            public TSector GetItem(int id) {
                foreach (TSector item in this._Lista) {
                    if (item.Id.Equals(id)) return item;
                }
                return new TSector();
            }

            public List<TSector> Source(TMunicipio item){
                var resul = from x in _Lista where x.Municipio.Codigo.Equals(item.Codigo) select x;
                return resul.ToList<TSector>(); 
            }

            public System.Collections.IEnumerable SourceView()
            {
                throw new NotImplementedException();
            }

            public int IndexOf(TSector item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, TSector item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            public TSector this[int index]
            {
                get
                {
                    return _Lista[index];
                }
                set
                {
                    _Lista[index] = value;
                }
            }

            public void Add(TSector item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                _Lista.Clear();
            }

            public bool Contains(TSector item){
                return _Lista.Contains(item);
            }

            public void CopyTo(TSector[] array, int arrayIndex){
                throw new NotImplementedException();
            }

            public int Count{
                get { return _Lista.Count; }
            }

            public bool IsReadOnly{
                get { return false; }
            }

            public bool Remove(TSector item){
                throw new NotImplementedException();
            }

            public IEnumerator<TSector> GetEnumerator(){
                return _Lista.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _Lista.GetEnumerator();
            }
        }
    }
namespace Empresa
{
    namespace Comun
    {
        using System;
        using System.Collections;
        using System.Collections.Generic;

        public enum EAcccion { 
            Insertar =0,
            Agregar=1
        }

        public class Suplidor:IList<TSuplidor> 
        {
            private List<TSuplidor> _Lista;
            public Suplidor() {
                _Lista = new List<TSuplidor>();
            } 
            
            public Suplidor(string arg){
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                _Lista = new List<TSuplidor>();
                consulta.Parameters.Add("@arg", arg);
                foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Invent_Ver_Suplidor]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                    _Lista.Add(new TSuplidor(Convert.ToInt32(fila["sup_id"]), fila["sup_nombre"].ToString(), fila["sup_rnc"].ToString(), false, fila["sup_web"].ToString(), fila["sup_fax"].ToString(), fila["sup_telefonoPrimario"].ToString(), null));
                }
            }
            
            public Suplidor(int id){
                SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

                _Lista = new List<TSuplidor>();
                consulta.Parameters.Add("@id", id);
                
                foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Invent_Ver_Suplidor_id]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                    _Lista.Add(new TSuplidor(Convert.ToInt32(fila["sup_id"]), fila["sup_nombre"].ToString(), fila["sup_rnc"].ToString(), false, fila["sup_web"].ToString(), fila["sup_fax"].ToString(), fila["sup_telefonoPrimario"].ToString(), null));
                }

            }

            public Suplidor(object nombre){
                //SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                //consulta.Parameters.Add("@rnd", rnc);
                //consulta.Execute.Dataset("[dbo].[Invent_Ver_Suplidor_nombre]", System.Data.CommandType.StoredProcedure);
            }

            /// <summary>
            /// Importa Archivo de la Dgii de suplidores.
            /// </summary>
            /// <param name="file"></param>
            /// <param name="Accion"></param>
            public void Import(string file, EAcccion Accion) {
                string nombre=string.Empty;
                string rnc=string.Empty;

                System.Data.DataTable tabla = new System.Data.DataTable("Temp_DGII");

                tabla.Columns.Add(new System.Data.DataColumn("rnc",typeof(string)));
                tabla.Columns.Add(new System.Data.DataColumn("nombre",typeof(string)));
                System.Data.DataRow fila;


                int[] tindex={0};

                int inx1 = 0;
                int inx2 = 0;

                if (System.IO.File.Exists(file)){
                    System.IO.StreamReader lector = new System.IO.StreamReader(file);

                    while (!lector.EndOfStream) {
                        string linea = lector.ReadLine();
                         inx1 = 0;
                         inx2 = 0;

                        for (int cont = 0; cont <= 1; cont++)
                        {
                            inx2 = linea.IndexOf("|", inx1 + 1);
                            if (cont.Equals(0)){
                                rnc = linea.Substring(inx1, inx2 - inx1);
                            }
                            else {
                                nombre = linea.Substring(inx1+1, (inx2 - inx1)-1);
                            }
                            inx1 = inx2;
                        }
                        fila = tabla.NewRow();
                        fila["rnc"] = rnc;
                        fila["nombre"] = nombre;
                        tabla.Rows.Add(fila);

                        rnc = string.Empty;
                        nombre = string.Empty;
                    }

                    lector.Close();
                    lector.Dispose();

                    SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                    consulta.Execute.BulkCopy(tabla);
                }
            
            }

            public void update(TSuplidor item){
                throw new NotImplementedException();
            }

            public System.Collections.Generic.List<TSuplidor> Source()
            {
                throw new NotImplementedException();
            }

            public System.Collections.IEnumerable SourceView()
            {
                throw new NotImplementedException();
            }

            public int IndexOf(TSuplidor item)
            {
                return _Lista.IndexOf(item);
            }

            public void Insert(int index, TSuplidor item)
            {
                _Lista.Insert(index, item);  
            }

            public void RemoveAt(int index){
                _Lista.RemoveAt(index);

            }

            public TSuplidor this[int index]
            {
                get
                {
                    if (this.Count.Equals(0)) {
                        return new TSuplidor();
                    }else {
                        return _Lista[index];
                    }
                }
                set
                {
                    _Lista[index] = value;
                }
            }

            public void Add(TSuplidor item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                _Lista.Clear();
            }

            public bool Contains(TSuplidor item)
            {
                return _Lista.Contains(item); 
            }

            public void CopyTo(TSuplidor[] array, int arrayIndex)
            {
                _Lista.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return _Lista.Count; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public bool Remove(TSuplidor item)
            {
               return  _Lista.Remove(item);
            }

            public System.Collections.Generic.IEnumerator<TSuplidor> GetEnumerator()
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
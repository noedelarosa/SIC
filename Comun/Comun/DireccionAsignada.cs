using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class DireccionAsignada
    {
        public ObservableCollection<TDireccionAsignada> Lista { get; set; }
        
        public DireccionAsignada() 
        {
            this.Lista = new ObservableCollection<TDireccionAsignada>();

           //SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
           //Comun.Sector sec = Comun.Sector.GetInstance();
           //Comun.Municipio mun = Comun.Municipio.GetInstance();
           //TDireccionAsignada dire;


            //foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Comun_Direccion_ViewCedula", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            //{
            //    dire = new TDireccionAsignada();
            //    if(fila["sect_id"] != null && Convert.ToInt32(fila["sect_id"]) != 0){
            //        dire.Id = Convert.ToInt32(fila["dire_id"]);
            //        dire.Referencia = fila["Dire_referencia"].ToString();
            //        dire.Sector = sec.Source(Convert.ToInt32(fila["sect_id"]))[0];
            //    }
            //    else {
            //        dire.Id = Convert.ToInt32(fila["dire_id"]);
            //        dire.Referencia = fila["Dire_referencia"].ToString();
            //        dire.Municipio = mun.Source(Convert.ToInt32(fila["muni_id"]))[0];
            //    }
            //}

        }

        public DireccionAsignada(int id) {
            this.Lista = new ObservableCollection<TDireccionAsignada>();


            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            Comun.Sector sec = Comun.Sector.GetInstance();
            Comun.Municipio mun = Comun.Municipio.GetInstance();
            Comun.Provincia pro = Comun.Provincia.GetInstance();

            TDireccionAsignada dire;
            consulta.Parameters.Add("@dire_cedula", id);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Comun_Direccion_ViewId", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                dire = new TDireccionAsignada();
                dire.Id = Convert.ToInt32(fila["dire_id"]);
                dire.Referencia = fila["Dire_referencia"].ToString();

                if (fila["sect_id"] != null && Convert.ToInt32(fila["sect_id"]) != 0){
                    
                    //Existe Sector
                    dire.Sector = sec.Source(Convert.ToInt32(fila["sect_id"]))[0];
                    dire.Municipio = mun.Source(Convert.ToInt32(fila["muni_id"]))[0];
                    dire.Provincia = pro.Source(Convert.ToInt32(fila["provi_id"]));
                }
                else{
                    //dire.Id = Convert.ToInt32(fila["dire_id"]);
                    //dire.Referencia = fila["Dire_referencia"].ToString();
                    //No Existe Sector
                    dire.Municipio = mun.Source(Convert.ToInt32(fila["muni_id"]))[0];
                    dire.Provincia = pro.Source(Convert.ToInt32(fila["provi_id"]));
                }
                this.Lista.Add(dire);
            }
        }

        public DireccionAsignada(string cedula, int tipo) {
            this.Lista = new ObservableCollection<TDireccionAsignada>();

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            Comun.Sector sec = Comun.Sector.GetInstance();
            Comun.Municipio mun = Comun.Municipio.GetInstance();
            Comun.Provincia pro = Comun.Provincia.GetInstance();

            TDireccionAsignada dire;
            consulta.Parameters.Add("@dire_cedula", cedula);
            consulta.Parameters.Add("@tdire_id", tipo);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Comun_Direccion_ViewCedula", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                dire = new TDireccionAsignada();

                dire.Id = Convert.ToInt32(fila["dire_id"]);
                dire.Referencia = fila["Dire_referencia"].ToString();

                if(fila["sect_id"] != null && Convert.ToInt32(fila["sect_id"]) != 0){
                    //dire.Id = Convert.ToInt32(fila["dire_id"]);
                    //dire.Referencia = fila["Dire_referencia"].ToString();
                    
                    //Existe Sector
                    dire.Sector = sec.GetItem(Convert.ToInt32(fila["sect_id"]));
                    dire.Municipio = mun.GetItem(Convert.ToInt32(fila["muni_id"]));
                    dire.Provincia = pro.GetItem(Convert.ToInt32(fila["provi_id"]));

                    //dire.Municipio = mun.Source(Convert.ToInt32(fila["muni_id"]))[0];
                    //dire.Provincia = pro.Source(Convert.ToInt32(fila["provi_id"]));
                }
                else{
                    //No Existe Sector
                    //dire.Municipio = mun.Source(Convert.ToInt32(fila["muni_id"]))[0];
                    //dire.Provincia = pro.Source(Convert.ToInt32(fila["provi_id"]));
                    dire.Municipio = mun.GetItem(Convert.ToInt32(fila["muni_id"]));
                    dire.Provincia = pro.GetItem(Convert.ToInt32(fila["provi_id"]));

                }

                this.Lista.Add(dire);
            }

        }

        public DireccionAsignada(ObservableCollection<TDireccionAsignada> docentes) {


        }

        public TDireccionAsignada GetLast() {
            if (this.Lista.Count > 0){
                return Lista[Lista.Count - 1];
            }
            else {
                return new TDireccionAsignada();
            }
        }

        public void Insert(string cedula, TDireccionAsignada direccion, int tipo){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@dire_cedula", cedula);
            consulta.Parameters.Add("@tdire_id", tipo);
            consulta.Parameters.Add("@sect_id", direccion.Sector==null?0:direccion.Sector.Id);
            consulta.Parameters.Add("@muni_id", direccion.Municipio.Id);
            consulta.Parameters.Add("@dire_referencia", direccion.Referencia);

            consulta.Execute.NoQuery("[dbo].[Comun_DireccionInsert]", System.Data.CommandType.StoredProcedure);
        }

        public void Update(TDireccionAsignada direccion){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@dire_id", direccion.Id);
            consulta.Parameters.Add("@sect_id", direccion.Sector == null ? 0 : direccion.Sector.Id);
            consulta.Parameters.Add("@muni_id", direccion.Municipio.Id);
            consulta.Parameters.Add("@dire_referencia", direccion.Referencia);

            consulta.Execute.NoQuery("[dbo].[Comun_DireccionUpdate]", System.Data.CommandType.StoredProcedure);
        }

        public void Update(string cedula, TDireccionAsignada direccion, int tipo){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@cedula", cedula);
            consulta.Parameters.Add("@tdire_id", tipo);
            consulta.Parameters.Add("@sect_id", direccion.Sector == null ? 0 : direccion.Sector.Id);
            consulta.Parameters.Add("@muni_id", direccion.Municipio.Id);
            consulta.Parameters.Add("@dire_referencia", direccion.Referencia);

            consulta.Execute.NoQuery("[dbo].[Comun_DireccionUpdateCedula]", System.Data.CommandType.StoredProcedure);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Comun{
	
   public class Direcciones: ObservableCollection<TDireccion>{
       private bool InDB = false;
       public TDireccion UltimoInsertado { get; private set; }
       
       public Direcciones(bool indb){
           this.InDB = indb;

           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
           Comun.Sector sec = Comun.Sector.GetInstance();
           Comun.Municipio mun = Comun.Municipio.GetInstance();

           TDireccion dire = new TDireccion();
           foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Com_ViewTodasDirecciones]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
               //var r = fila["sect_id"];
               //var r2 = fila["dire_id"];

               if (Convert.ToInt32(fila["sect_id"]) != 0){
                   //int idd = Convert.ToInt32(fila["dire_id"]);
                   dire = new TDireccion(Convert.ToInt32(fila["dire_id"]), fila["Dire_referencia"].ToString(), sec.Source(Convert.ToInt32(fila["sect_id"]))[0]);
               }
               else {

                    if(Convert.ToInt32(fila["muni_id"]) != 0){
                       dire = new TDireccion(Convert.ToInt32(fila["dire_id"]), fila["Dire_referencia"].ToString(), mun.Source(Convert.ToInt32(fila["muni_id"]))[0]);
                    }
                    else{
                       dire = new TDireccion(Convert.ToInt32(fila["dire_id"]), fila["Dire_referencia"].ToString(), new TMunicipio());
                    }

               }
               this.SetItem(dire);
           }

       }

       public Direcciones(int id) {
           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
           
           Comun.Sector sec = Comun.Sector.GetInstance();
           Comun.Municipio mun = Comun.Municipio.GetInstance();

           TDireccion dire = new TDireccion();

           foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Com_ViewTodasDirecciones]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
               
               if (fila["sect_id"] != null && Convert.ToInt32(fila["sect_id"]) != 0){
                   //int idd = Convert.ToInt32(fila["dire_id"]);
                   dire = new TDireccion(Convert.ToInt32(fila["dire_id"]), fila["Dire_referencia"].ToString(), sec.Source(Convert.ToInt32(fila["sect_id"]))[0]);
               }
               else{
                   dire = new TDireccion(Convert.ToInt32(fila["dire_id"]), fila["Dire_referencia"].ToString(), mun.Source(Convert.ToInt32(fila["muni_id"]))[0]);
               }

               this.SetItem(dire);
           }
       
       }

       public TDireccion GetItem(int id) {
           foreach (TDireccion item in this) {
               if (item.Id.Equals(id)) {
                   return item;
               }
           }
           return new TDireccion(); 
       }

       public void Insert(TDireccion item) {
           bool tm = InDB;
           InDB = true;
           this.Add(item);
           InDB = tm;
       }

       public void Update(TDireccion item){
           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

           consulta.Parameters.Add("@dire_id", item.Id);
           consulta.Parameters.Add("@dire_referencia", item.Referencia);
           consulta.Parameters.Add("@muni_id", item.Sector.Municipio.Id);
           consulta.Parameters.Add("@sect_id", item.Sector.Id);

           consulta.Execute.NoQuery("[dbo].[Comun_DireccionUpdate]", System.Data.CommandType.StoredProcedure);
       }

       public void SetItem(TDireccion item) {
           bool tm = InDB;
           InDB = false;
           this.Add(item);
           InDB = tm;
       }
       
       private int _Add(TDireccion item){
       
           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);    
           consulta.Parameters.Add("@dire_referencia", item.Referencia);
           consulta.Parameters.Add("@muni_id", item.Sector.Municipio.Id);
           consulta.Parameters.Add("@sect_id", item.Sector.Id);
           
           using (System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Comun_DireccionInsert", System.Data.CommandType.StoredProcedure)){
               if (lector.Read()) return Convert.ToInt32(lector[0]);
           }

           return 0;
       }

       protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e){
           
           switch (e.Action){
               case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                   if (InDB){
                       ((TDireccion)e.NewItems[0]).Id =  this._Add((TDireccion)e.NewItems[0]);
                       this.UltimoInsertado = ((TDireccion)e.NewItems[0]);
                   }
                   break;
               case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                   break;
               case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                   break;
           }
           base.OnCollectionChanged(e);

       }
   
   
   }
}

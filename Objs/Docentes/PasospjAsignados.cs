using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Empresa.Docente
{
    public class PasospjAsignados: INotifyPropertyChanged{
        public ObservableCollection<TPasospjAsignados> Lista { get; set; }

        public bool EsCompleto{
            get;
            set;
        }

        private bool OrdenEsPermitido(TPasospjAsignados item){
        
            if(item.Paso.Orden.Equals(1)){
                return true;
            }else {
                foreach(TPasospjAsignados t in Lista){
                    if(t.Paso.Orden.Equals((item.Paso.Orden - 1))) {
                        return t.EsActivo;
                    }
                }
                return false;
            }
        }

        public void ActivarItem(TPasospjAsignados item) {
            Lista[Lista.IndexOf(item)].EsActivo = OrdenEsPermitido(item);
            if(Lista[Lista.IndexOf(item)].EsActivo) Lista[Lista.IndexOf(item)].FechaIngreso = Empresa.Comun.Server.DameTiempo(); 
        }

        public PasospjAsignados(Pasospj pasos) {

            Lista = new ObservableCollection<TPasospjAsignados>();
            //LLenar por defecto.
            foreach (TPasospj paso in pasos.Lista)
            {
                Lista.Add(new TPasospjAsignados(Empresa.Comun.Server.DameTiempo(), DateTime.Now, false, paso, 0));
            }
        
        }

        public PasospjAsignados(){
            Lista = new ObservableCollection<TPasospjAsignados>();    
            //LLenar por defecto.
            //Pasospj pasos = Pasospj.GetInstance();
            //foreach(TPasospj paso in pasos.Lista){
            //    Lista.Add(new TPasospjAsignados(Empresa.Comun.Server.DameTiempo(), DateTime.Now, false, paso, 0));
            //}
        }



        public PasospjAsignados(int idsol)
        {
            Lista = new ObservableCollection<TPasospjAsignados>();
            //Recuperacion de pasos
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@solpj_id", idsol);
            Pasospj pasos = Pasospj.GetInstance();

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_PasosPJAsignadosView]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                this.Lista.Add(new TPasospjAsignados(Convert.ToInt32(fila["pasa_id"]), fila["pasa_fecha"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pasa_fecha"], fila["pasa_fechaingreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pasa_fechaingreso"], Convert.ToBoolean(fila["pasa_esactivo"]), pasos.GetItem(Convert.ToInt32(fila["pas_id"])), new tsolicitudpj(Convert.ToInt32(fila["solpj_id"]))));
            }

            this.Refres();
        }

        public PasospjAsignados(ObservableCollection<tsolicitudpj> sols){
            List<string> _lista = new List<string>();
            foreach (tsolicitudpj item in sols) {
                _lista.Add(item.Id.ToString());
            }

             Lista = new ObservableCollection<TPasospjAsignados>();
             //Recuperacion de pasos
             SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
             consulta.Parameters.Add("@solpj_id", Empresa.Comun.Servicios.DividirCAD(_lista));
             Pasospj pasos = Pasospj.GetInstance();

             foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_PasosPJAsignadosView_Solicitudes]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                 this.Lista.Add(new TPasospjAsignados(Convert.ToInt32(fila["pasa_id"]), fila["pasa_fecha"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pasa_fecha"], fila["pasa_fechaingreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pasa_fechaingreso"], Convert.ToBoolean(fila["pasa_esactivo"]), pasos.GetItem(Convert.ToInt32(fila["pas_id"])), new tsolicitudpj(Convert.ToInt32(fila["solpj_id"]))));
             }

        }
        


        public void Refres(){
            // Es completo.
            foreach(TPasospjAsignados item in this.Lista){
                
                if(!item.EsActivo){
                    EsCompleto = false;
                    break;
                }
                else {
                    this.EsCompleto = true;
                }

            }
        }

        public void Insert(TPasospjAsignados item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            //consulta.Parameters.Add("@solpj_id", 0);
            //consulta.Parameters.Add("@pas_id", item.Paso.Id);
            //consulta.Parameters.Add("@pasa_esactivo", item.EsActivo);
            //consulta.Parameters.Add("@pasa_fechaingreso", item.FechaIngreso);
            //consulta.Execute.NoQuery("[dbo].[Pensiones_PasosPJAsignadosInsert]", System.Data.CommandType.StoredProcedure);
        }

        public void Insert(tsolicitudpj item) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            foreach(TPasospjAsignados paso in item.Pasos.Lista){
                consulta.Parameters.Add("@solpj_id", item.Id);
                consulta.Parameters.Add("@pas_id", paso.Paso.Id);
                consulta.Parameters.Add("@pasa_esactivo", paso.EsActivo);
                consulta.Parameters.Add("@pasa_fechaingreso", paso.FechaIngreso);
                consulta.Execute.NoQuery("[dbo].[Pensiones_PasosPJAsignadosInsert]", System.Data.CommandType.StoredProcedure);
                consulta.Parameters.ClerAll(); 
            }
        }

        public void Update(tsolicitudpj item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            

            foreach (TPasospjAsignados paso in item.Pasos.Lista){
                consulta.Parameters.Add("@pasa_id", paso.Id);
                consulta.Parameters.Add("@pasa_esactivo", paso.EsActivo);
                consulta.Parameters.Add("@pasa_fechaingreso", paso.FechaIngreso);
                //[dbo].[Pensiones_PasosPJAsignadosUpdate]
                consulta.Execute.NoQuery("[dbo].[Pensiones_PasosPJAsignadosUpdate]", System.Data.CommandType.StoredProcedure);
                consulta.Parameters.ClerAll();
            }


        }

        public TPasospjAsignados GetItem(int id){
            TPasospjAsignados Paso = new TPasospjAsignados();
            var resul = from x in this.Lista where x.Id.Equals(id) select Paso = x;
            return Paso;
        }

        public TPasospjAsignados UltimoPaso() {
            TPasospjAsignados item = new TPasospjAsignados();

            foreach(TPasospjAsignados itemc in this.Lista){
                if (itemc.Fecha > item.Fecha) item = itemc;
            }

            return item;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void EnCambio(string nombre)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;
            if (manejador != null)
            {
                manejador(this, new PropertyChangedEventArgs(nombre));
            }
        }


    }
}

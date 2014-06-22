using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class Decreto{
        public List<TDecreto> Lista {get;set;}
        private static Decreto _Decreto;

        public static Decreto GetInstnace(){
            if (_Decreto == null) _Decreto = new Decreto();
            return _Decreto;
        }

        private Decreto(){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            this.Lista = new List<TDecreto>();
            Empresa.Docente.EstadoDecreto estadodecre = Empresa.Docente.EstadoDecreto.GetInstance();
            
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Ver_Decretos_Todos]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                TDecreto _decreto = new TDecreto(Convert.ToInt32(fila["dec_id"]), fila["dec_numero"].ToString(), Convert.ToDateTime(fila["dec_fechaemision"]), fila["dec_fechapago"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["dec_fechapago"], estadodecre.GetItem(Convert.ToInt32(fila["decs_id"])));
                _decreto.FechaPromedio = fila["dec_fechapromedio"] == DBNull.Value ? Convert.ToDateTime(fila["dec_fechaemision"]) : Convert.ToDateTime(fila["dec_fechapromedio"]);
                this.Lista.Add(_decreto);
            }

        }

        public TDecreto GetItem(int id){
            foreach (TDecreto item in this.Lista) {
                if (item.Id.Equals(id)) return item;
            }
            return new TDecreto();
        }

        public List<TDecreto> GetItems(Empresa.Comun.TEstandar estado)
        {
            List<TDecreto> _lista = new List<TDecreto>();
            foreach (TDecreto item in this.Lista){
                if (item.Estado.Id.Equals(estado.Id)) _lista.Add(item);
            }
            return _lista;
        }

        public TDecreto GetItem(string numero)
        {
            foreach (TDecreto item in this.Lista){
                if (item.Numero.ToUpper().Equals(numero.ToUpper())) return item;
            }
            return new TDecreto();
        }

        public bool ExisteEnLista(string numero) {
            foreach (TDecreto item in this.Lista){
                if (item.Numero.ToUpper().Equals(numero.ToUpper())) return true;
            }
            return false;
        }

        public bool Insert(TDecreto item) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            if (this.ExisteEnLista(item.Numero) == false){
                consulta.Parameters.Add("@dec_numero", item.Numero);
                consulta.Parameters.Add("@dec_fechaemision", item.FechaEmision);
                consulta.Parameters.Add("@dec_fechapago", item.FechaPrimerPago);
                consulta.Parameters.Add("@decs_id", item.Estado.Id);
                consulta.Parameters.Add("@presd_id", item.Presidente.Id);
                consulta.Parameters.Add("@dec_fechapromedio", item.FechaPromedio);
                consulta.Execute.NoQuery("[dbo].[Decretos_Insert]", System.Data.CommandType.StoredProcedure);
                return true;
            }
            else {
                item.AgregoError("Numero", "Exise número de decreto.");
                return false;
            }
        }

        public void Update(TDecreto item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@dec_id", item.Id);
            consulta.Parameters.Add("@dec_numero", item.Numero);
            consulta.Parameters.Add("@dec_fechaemision", item.FechaEmision);
            consulta.Parameters.Add("@dec_fechapago", item.FechaPrimerPago);
            consulta.Parameters.Add("@decs_id", item.Estado.Id);
            consulta.Parameters.Add("@dec_fechapromedio", item.FechaPromedio);

            consulta.Execute.NoQuery("[dbo].[Decretos_Update]", System.Data.CommandType.StoredProcedure);
        }

        public void Delete(TDecreto item){



        }

        public TDecreto UltimoDecreto {
            get { 
                int id = this.Lista.Select(e => e.Id).Max();
                var resul = from x in this.Lista where x.Id.Equals(id) select x;
                return resul.ToList()[0];
            }
        }

        public static Decreto Recarga()
        {
            _Decreto = null;
            return GetInstnace(); 
        }

        public static void Clear() {
            _Decreto.Lista = null;
            _Decreto = null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class PagoDetalle {

        public ObservableCollection<TPagoDetalle> Lista;

        public PagoDetalle() {
            this.Lista = new ObservableCollection<TPagoDetalle>();
        }

        public ObservableCollection<CalculoNomina> Resumidos { get; set; }
        
        public CalculoNomina Resumido { get; set; }

        public void RefreshResumido(DateTime fecha) {
            this.Resumido.Base = 0;
            this.Resumido.TotalIngresos = 0;
            this.Resumido.TotalDescuentos = 0;

            foreach (TPagoDetalle item in this.Lista){
                if (item.Fecha.Month == fecha.Month && item.Fecha.Year == fecha.Year)
                {
                    if (item.IngresoDescuento.Mus.ToString().Equals("20")) this.Resumido.Base = item.MontoBruto;
                    if (Convert.ToInt32(item.IngresoDescuento.Mus) <= 44) this.Resumido.TotalIngresos += item.MontoBruto;
                    if (Convert.ToInt32(item.IngresoDescuento.Mus) >= 45) this.Resumido.TotalDescuentos += item.MontoBruto;
                    Resumido.Fecha = item.Fecha;
                }
            }
        }

        public PagoDetalle(string cedula){
            Lista = new ObservableCollection<TPagoDetalle>();
            //this.Resumidos = new ObservableCollection<CalculoNomina>();
            this.Resumido = new CalculoNomina();

            ConteoIngresoDescuento = 0;

            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@cedula", cedula);
            TPagoDetalle item;
            IngresoDescuento ingdes = IngresoDescuento.GetInstance();
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[View_Minerd_Detalles_IngresosDescuentos]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                item = new TPagoDetalle();

                item.Id = Convert.ToInt32(fila["det_id"]);
                item.MontoBruto = Convert.ToDouble(fila["det_Monto"]);
                item.Fecha = Convert.ToDateTime(fila["det_fecha"]);
                item.IngresoDescuento = ingdes.GetItem(fila["igde_codigo"].ToString());
                item.CodigoTanda = Convert.ToInt32(fila["map_numerocargo"]);

                this.Lista.Add(item);
            }
        }

        public PagoDetalle(string cedula, DateTime fecha){ 
        

        }

        /// <summary>
        /// Suma de IngresoDescuento
        /// </summary>
        /// <param name="Ingreso o Descuento"></param>
        /// <returns>double</returns>
        public double SumaIngresoDescuento(string codigo){
            return this.SumaIngresoDescuento(new Comun.TEstandar(codigo), DateTime.MinValue);
        }

        private DateTime NormalizarFecha(DateTime fecha) {
            if (fecha.Day >= 25){
                return fecha;
            }
            else{
                fecha = fecha.AddDays((25 - fecha.Day));
                return fecha;
            }
        }

        /// <summary>
        ///  Suma de IngresoDescuento
        /// </summary>
        /// <param name="Ingreso o Descuento"></param>
        /// <param name="fecha limite del calculo(incluye el limite)"></param>
        /// <returns>double</returns>
        public double SumaIngresoDescuento(Empresa.Comun.TEstandar item, DateTime limite)
        {
            double temp = 0;
            this.ConteoIngresoDescuento = 0;

            limite = this.NormalizarFecha(limite);
            foreach (TPagoDetalle itemi in this.Lista)
            {
                if (itemi.IngresoDescuento.Mus.Equals(item.Mus)) {
                    
                    if(limite == DateTime.MinValue){
                        temp += itemi.MontoBruto;
                        this.ConteoIngresoDescuento += 1;
                    }
                    else{
                        if(this.NormalizarFecha(itemi.Fecha) <= limite){
                            temp += itemi.MontoBruto;
                            this.ConteoIngresoDescuento += 1;
                        }
                    }
                }
            }

            this.ResultSumaIngresoDescuento = System.Math.Abs(temp);
            return System.Math.Abs(temp);
        }

        public ObservableCollection<TPagoDetalle> DameLista(string codigo, DateTime limite) {
            ObservableCollection<TPagoDetalle> dl = new ObservableCollection<TPagoDetalle>();

            double temp = 0;
            this.ConteoIngresoDescuento = 0;

            limite = this.NormalizarFecha(limite);
            foreach (TPagoDetalle itemi in this.Lista)
            {
                if (itemi.IngresoDescuento.Mus.Equals(codigo))
                {
                    if (limite == DateTime.MinValue){
                        dl.Add(itemi);
                    }
                    else{
                        if (this.NormalizarFecha(itemi.Fecha) <= limite){
                            dl.Add(itemi);
                        }
                    }
                }
            }
             
                
            return dl;
        }

        public int ConteoIngresoDescuento {get;set;}
        public double ResultSumaIngresoDescuento { get; set; }
        public ObservableCollection<TPagoDetalle> UltimoMes(){
            ObservableCollection<TPagoDetalle> listatemp = new ObservableCollection<TPagoDetalle>();
            DateTime fecha = this.Lista[Lista.Count - 1].Fecha;

            foreach(TPagoDetalle item in this.Lista)
            {
                if(item.Fecha.Month == fecha.Month && item.Fecha.Year == fecha.Year){
                    listatemp.Add(item);
                }
            }

            this.RefreshResumido(fecha);
            return listatemp;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Empresa.Docente
{
    public class tdocente:Empresa.Comun.tbasepersona {
        
        /// <summary>
        /// Indica si el docente es fallecido y posee fecha de fallecimiento, como requisito minimo.
        /// </summary>
        public bool EsFallecidoMinimo {
            get {
                return (EsFallecido && !(FechaFallecido == DateTime.MinValue || FechaFallecido == DateTime.MaxValue));
            }
        }

        /// <summary>
        /// Indica si el personal es incluido, por consiguiente no es docente.
        /// </summary>
        public bool EsDocente { get; set; }
        //Indica la empresa donde labora el docente.
        public Empresa.Comun.TSuplidor TrabajoLabora { get; set; }

        public bool EsNotificadoFallecido { get; set; }

        public double SueldoBrutoActual {get; set;}
        public RHH.testadolaboral EstadoLaboral {get; set;}
        public tdatosfallecimiento DatosFellecimiento {get; set;}
        //public Empresa.Comun.TDireccion Direccion {get; set;}
        public Empresa.Comun.TDireccionAsignada Direccion {get; set;}
        public Empresa.Comun.tcontacto Contacto {get; set;}
        public Empresa.Docente.PagoDetalle PagosDetalle {get;set;}

        public SolicitudPJ SolicitudPJ { get; set; }
        public SeguroFunerario SeguroFunerario { get; set; }
        public bool EsRenunciaSobrevivencia { 
            get 
            {
                if (!string.IsNullOrEmpty(this.Cedula)){

                    SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                    consulta.Parameters.Add("@Exc_Cedula", this.Cedula);
                    System.Data.SqlClient.SqlDataReader lector = (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("View_Minerd_Exclusiones_Autoseguro_cedula", System.Data.CommandType.StoredProcedure);

                    if (lector.Read()){
                        if (Convert.ToInt32(lector[0]) == 0){
                            return false;
                        }
                        else{
                            return true;
                        }
                    }
                    else{
                        return false;
                    }
                }
                else {
                    return true;
                }
            }
        }
        public trenunciasobrevivencia RenunciaSobrevivencia {
            get {
                if (!string.IsNullOrEmpty(this.Cedula))
                {
                    return new RenunciaSobrevivencia(this.Cedula).Renuncia;
                }
                else {
                    return new trenunciasobrevivencia();
                }
            }
        }
        public ObservableCollection<Empresa.Docente.tlabora> Labora { get; set; }
        public DateTime _FechaFallecido;
        public DateTime FechaFallecido {
            get {
                return _FechaFallecido;
            }
            set {
                if (this.EsFallecido)
                {
                    _FechaFallecido = value;
                    if (FechaFallecido.Equals(DateTime.MinValue) || FechaFallecido.Equals(DateTime.MaxValue)){
                        this.AgregoError("FechaFallecido", "Error falta fecha de fallecimiento");
                    }
                    else {
                        this.BorrarError("FechaFallecido"); 
                    }
                }
                else {
                    this.BorrarError("FechaFallecido"); 
                }
            }
        }
        public Pagos HistorialPagos {get; set;}
        public bool RevicionSimple {
            get{

                if((this.FechaFallecido != DateTime.MinValue || this.FechaFallecido != null) && (this.FechaIngresoEducacion != DateTime.MinValue || this.FechaIngresoEducacion != null) && (this.FechaNacimiento != DateTime.MinValue || this.FechaNacimiento != null)){
                    return (this.FechaNacimiento < this.FechaFallecido) && (this.FechaNacimiento < this.FechaIngresoEducacion) && (this.FechaFallecido > this.FechaIngresoEducacion);
                }
                else{
                    return false;
                }

            }
        }
        public DateTime FechaIngresoEducacion {get; set;}

        public Empresa.Comun.StFechasPartes EdadPartida {
            get {

                if (FechaNacimiento != DateTime.MinValue)
                {

                    if (!this.EsFallecido){
                        return Empresa.Comun.Servicios.FechasDifencia(this.FechaNacimiento, Empresa.Comun.Server.DameTiempo());
                    }
                    else{
                        return Empresa.Comun.Servicios.FechasDifencia(this.FechaNacimiento, this.FechaFallecido);
                    }

                }
                else {
                    return new Comun.StFechasPartes();
                }
                
            }
        }
        public string EdadPartida_FormatoA {
            get {
                Empresa.Comun.ConvertDataToAnoMes conver = new Comun.ConvertDataToAnoMes();
                return (string)conver.Convert(this.EdadPartida,this.GetType(),null,System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        public Empresa.Comun.StFechasPartes TiempoServicioEducacionPartida {
            get{
                if (this.EsFallecido){
                   return Empresa.Comun.Servicios.FechasDifencia(this.FechaIngresoEducacion, this.FechaFallecido);
                }
                else{
                   return Empresa.Comun.Servicios.FechasDifencia(this.FechaIngresoEducacion,Empresa.Comun.Server.DameTiempo());
                }
            }
        }
        public int TiempoServicioEducacion{
            get{
                if (this.EsFallecido){
                  return Empresa.Comun.Servicios.FechasDifencia(this.FechaIngresoEducacion,this.FechaFallecido).Anos;   
                }
                else {
                  return Empresa.Comun.Servicios.FechasDifencia(this.FechaIngresoEducacion, Empresa.Comun.Server.DameTiempo()).Anos;   
                }
            }
        }
        public string TiempoServicioEducacionPartida_FormatoA
        {
            get
            {
                Empresa.Comun.ConvertDataToAnoMes conver = new Comun.ConvertDataToAnoMes();
                return (string)conver.Convert(this.TiempoServicioEducacionPartida, this.GetType(), null, System.Globalization.CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Ultimo Cargos
        /// </summary>
        public string Cargo { get; set; }
        /// <summary>
        /// Ultima Dependencia
        /// </summary>
        public string Dependencia { get; set; }
        /// <summary>
        /// Ultima Regional
        /// </summary>
        public string Regional { get; set; }

        /// <summary>
        /// Comentarios.
        /// </summary>
        public ObservableCollection<Empresa.Comun.TComentario> Comentarios {get;set;}

        public Empresa.Comun.TEstandar Tipo {
            get;
            set;
        }

        public int ScalaPension {
            get {
                 if(this.EstadoLaboral.Id.Equals(1)){
                    if (this.TiempoServicioEducacion <= 15){
                        return 60;
                    }
                    else if(this.TiempoServicioEducacion >= 16 && this.TiempoServicioEducacion <= 20){
                        return 70;
                    }
                    else if (this.TiempoServicioEducacion >= 21){
                        return 80;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return 100;
                }
            }
        }

        //MONTOS DE SEGURO FUNERARIO

        /// <summary>
        /// Monto de plan funerario
        /// </summary>
        public double MontoFunerario
        {
            //get {
            //    //Constante Numero de descuento 81, Descuento Funerario.
            //    //Fecha limite fecha de fallecimiento para el docente.

            //    //if (this.FechaFallecido != DateTime.MinValue){
            //    //    this.PagosDetalle.SumaIngresoDescuento(new Empresa.Comun.TEstandar("81"), this.FechaFallecido);
            //    //}
            //    //else {
            //    //    this.PagosDetalle.SumaIngresoDescuento("81");
            //    //}

            //    int cuotas = this.PagosDetalle.ConteoIngresoDescuento;

            //    if(cuotas >= 1 && cuotas <= 6){
            //        return 50000.0;
            //    }

            //    if(cuotas >= 7 && cuotas <= 12){
            //        return 55000.0;
            //    }

            //    if(cuotas >= 13 && cuotas <= 18){
            //        return 60000.0;
            //    }

            //    if(cuotas >= 19 && cuotas <= 24){
            //        return 65000.0;
            //    }

            //    if(cuotas >= 25 && cuotas <= 30){
            //        return 70000.0;
            //    }

            //    if(cuotas >= 31 && cuotas <= 36){
            //        return 75000.0;
            //    }

            //    if(cuotas >= 37 && cuotas <= 42){
            //        return 80000.0;
            //    }

            //    if(cuotas >= 43 && cuotas <= 48){
            //        return 90000.0;
            //    }

            //    if(cuotas >= 49){
            //        return 100000.0;
            //    }

            //    return 0;
            //}
            get;
            set;
        }
        
        /// <summary>
        /// Número de Montos de Seguro Funerario
        /// </summary>
        public int ConteoFunerario
        {
            //get {
            //    this.PagosDetalle.SumaIngresoDescuento("81");
            //    return this.PagosDetalle.ConteoIngresoDescuento;
            //}
            get;
            set;
        }
        
        /// <summary>
        /// Suma de Seguro Funerario.
        /// </summary>
        public double AcumuladoFunerario
        {
            //get {
            //    return this.PagosDetalle.SumaIngresoDescuento("81");
            //}
            get;
            set;
        }

        

        public void Calculo_Seguro_Funerario() {

            if (this.EsFallecido){

                if(this.FechaFallecido != DateTime.MinValue){

                    DateTime FechaFallecimientoCalculo = this.FechaFallecido;
                    if(this.FechaFallecido.Day <= 24) FechaFallecimientoCalculo = FechaFallecido.AddMonths(-1);

                    this.AcumuladoFunerario = this.PagosDetalle.SumaIngresoDescuento(new Empresa.Comun.TEstandar("81"), FechaFallecimientoCalculo);
                    this.ConteoFunerario = this.PagosDetalle.ConteoIngresoDescuento;
                    //Escala a Aplicar 
                    if (this.ConteoFunerario >= 1 && this.ConteoFunerario <= 6){
                        MontoFunerario = 50000.0;
                    }

                    if (this.ConteoFunerario >= 7 && this.ConteoFunerario <= 12){
                        MontoFunerario = 55000.0;
                    }

                    if (this.ConteoFunerario >= 13 && this.ConteoFunerario <= 18){
                        MontoFunerario = 60000.0;
                    }

                    if (this.ConteoFunerario >= 19 && this.ConteoFunerario <= 24)
                    {
                        MontoFunerario = 65000.0;
                    }

                    if (this.ConteoFunerario >= 25 && this.ConteoFunerario <= 30)
                    {
                        MontoFunerario = 70000.0;
                    }

                    if (this.ConteoFunerario >= 31 && this.ConteoFunerario <= 36)
                    {
                        MontoFunerario = 75000.0;
                    }

                    if (this.ConteoFunerario >= 37 && this.ConteoFunerario <= 42)
                    {
                        MontoFunerario = 80000.0;
                    }

                    if (this.ConteoFunerario >= 43 && this.ConteoFunerario <= 48)
                    {
                        MontoFunerario = 90000.0;
                    }

                    if (this.ConteoFunerario >= 49)
                    {
                        MontoFunerario = 100000.0;
                    }

                }
            }
        
        }

        //PAGO POSTUMES
        private List<TPago> _PagosPostumes;
        /// <summary>
        /// Lista de Pagos Postumes(Despues de haber fallecido)
        /// </summary>
        public List<TPago> PagosPostumes
        {
            get{

                _PagosPostumes = new List<TPago>();
                DateTime ffell = new DateTime(this.FechaFallecido.Year, this.FechaFallecido.Month, 1);
                DateTime fpago;

                foreach (TPago item in this.HistorialPagos.Lista){
                    //Reinicializando Fecha pago omitiendo los dias.
                    fpago = new DateTime(item.Fecha.Year, item.Fecha.Month, 1);

                    if (ffell <= fpago){
                        this._PagosPostumes.Add(item);
                    }
                }
                return _PagosPostumes;
            }
        }
        /// <summary>
        /// Total Cuenta de Pagos Postumes(Conteo).
        /// </summary>
        public int TotalPagoPostumes
        {
            get
            {
                if (_PagosPostumes != null)
                {
                    return _PagosPostumes.Count;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Monto Total de Pagos Postumes(Dinero)
        /// </summary>
        public double MontoPagosPostumes {
            get {
                if (this.PagosPostumes != null)
                {
                    double valor=0;
                    foreach (TPago item in this.PagosPostumes) {
                        valor += item.MontoBruto;
                    }
                    return valor;
                }
                else {
                    return 0.0;
                }
            }
        }

        /// <summary>
        /// Monto de RectroActivo
        /// </summary>
        public double MontoPagosRectroactivo{get;set;}
        /// <summary>
        /// Tiempo en retroactivo
        /// </summary>
        public Empresa.Comun.StFechasPartes TiempoPagosRectroactivoPartida{get; set;}
        public string TiempoPagosRectroactivoPartida_FormatoA {
            get {
                return this.TiempoPagosRectroactivoPartida.ToString();
            }
        }

        //public Empresa.Comun.StFechasPartes TiempoServicioConcrecion

        public double ScalaMonto {
            get {
                 
                if (this.HistorialPagos != null){
                    return this.HistorialPagos.Ultimo.MontoBruto * (Convert.ToDouble(this.ScalaPension) / 100.00);
                }
                else {
                    return 0;
                }
            }
        }
        
        private Familiares _Familiares;
        public Familiares Familiares {
            get {
                this.Calculo_FechasPension_Familiar();
                this.Calculo_Edad_Familiar();
                this.Calculo_MontoPension_Familiar();
                return _Familiares;
            }
            set {
                _Familiares = value;
                this.Calculo_FechasPension_Familiar();
                this.Calculo_Edad_Familiar();
                this.Calculo_MontoPension_Familiar();
            }
        }

        /// <summary>
        /// Calculo para Familiares Beneficiarios, Calculo de Fechas en Pensión. 
        /// </summary>
        public void Calculo_FechasPension_Familiar()
        {
            if (this.EsFallecido)
            {

                if (this._Familiares != null)
                {
                    foreach (TFamiliares item in _Familiares)
                    {
                        /// CALCULANDO LA FECHA FINAL ///
                        if (!EsInabima)
                        {
                            //No Pertenece a Inabima
                            //Fecha de inicio sera la fecha de Fallecimiento
                            item.FechaInicioPJ = this.FechaFallecido;
                        }
                        else
                        {
                            // Pertenece a Inabima, la fecha de inicio sera la del decreto.
                            //TDecreto idecreto = decretos.GetItem(item.Decreto);
                            /// CALCULANDO LA FECHA DE INICIO ///
                            item.FechaInicioPJ = DecretoBeneficiarios.FechaEP;
                        }
                        //Inicializando Variable de FechaFinal.
                        item.FechaFinalPJ = item.FechaInicioPJ;

                        if (item.Parentesco.Id.Equals(1))
                        {
                            /// Hijo o Hija
                            /// 
                            if (item.EsDiscapacitado)
                            {
                                //Es 
                                item.FechaFinalPJ = DateTime.MaxValue;
                            }
                            else
                            {
                                //Solo Entran los que son Menores o Igual a 21 al momento del fallecimiento
                                if (item.EdadFallecimientoDocente <= 21)
                                {
                                    ///CALCULANDO EL TIEMPO EN PENSION
                                    DateTime a18;
                                    //Verificando edad al momento de fallecimiento del docente.
                                    if (item.EdadFallecimientoDocentePartida.Anos <= 17 && item.EdadFallecimientoDocentePartida.Meses <= 1)
                                    {
                                        //Menores de 17 Años y un Mes.
                                        DateTime resul1 = this.FechaFallecido.AddYears((-1) * item.EdadFallecimientoDocentePartida.Anos);
                                        resul1 = resul1.AddMonths((-1) * item.EdadFallecimientoDocentePartida.Meses);
                                        //resul1 = resul1.AddDays((-1) * item.EdadFallecimientoDocentePartida.Dias);
                                        a18 = item.FechaNacimiento.AddYears(18);
                                        //Establece el limite del calculo
                                        item.TipoCalculo = "18";
                                    }
                                    else
                                    {
                                        //Mayores de 17 y un Mes
                                        DateTime resul1 = this.FechaFallecido.AddYears((-1) * item.EdadFallecimientoDocentePartida.Anos);
                                        resul1 = resul1.AddMonths((-1) * item.EdadFallecimientoDocentePartida.Meses);
                                        //resul1 = resul1.AddDays((-1) * item.EdadFallecimientoDocentePartida.Dias);
                                        a18 = resul1.AddYears(21);
                                        //Establece el limite del calculo
                                        item.TipoCalculo = "21";
                                    }

                                    //Buscando Diferencia de tiempo de fecha de fallecimiento y cumple mayor(18 o 21)
                                    Empresa.Comun.StFechasPartes resul = Empresa.Comun.Servicios.FechasDifencia(this.FechaFallecido, a18);
                                    //Tiempo en pensión, no definido fecha final.
                                    item.TiempoPensionAnos = resul.Anos;
                                    item.TiempoPensionMeses = resul.Meses;
                                    //Estableciendo fecha final, apartir de la fecha de inicio, fecha de fallecimiento.
                                    item.FechaFinalPJ = item.FechaFinalPJ.AddYears(item.TiempoPensionAnos);
                                    item.FechaFinalPJ = item.FechaFinalPJ.AddMonths(item.TiempoPensionMeses);
                                }
                            }
                        }

                        if (item.Parentesco.Id.Equals(2) || item.Parentesco.Id.Equals(3) || item.Parentesco.Id.Equals(4))
                        {
                            //Esposo o Esposa

                            //Establece el limite del calculo, No Definido
                            item.TipoCalculo = "n/d";
                            //Fecha Final fue establecido como la fecha de inicio.
                            if (item.EdadFallecimientoDocentePartida.Anos <= 49)
                            {
                                item.FechaFinalPJ = item.FechaFinalPJ.AddMonths(60);
                            }

                            if (item.EdadFallecimientoDocentePartida.Anos >= 50 && item.EdadFallecimientoDocentePartida.Anos <= 55){
                                item.FechaFinalPJ = item.FechaFinalPJ.AddMonths(72);
                            }

                            if(item.EdadFallecimientoDocentePartida.Anos > 55){
                                item.FechaFinalPJ = DateTime.MaxValue;
                            }

                            if (item.FechaFinalPJ.Equals(DateTime.MaxValue))
                            {
                                item.TiempoPensionAnos = 0;
                                item.TiempoPensionMeses = 0;
                            }
                            else
                            {
                                Empresa.Comun.StFechasPartes resul = Empresa.Comun.Servicios.FechasDifencia(item.FechaInicioPJ, item.FechaFinalPJ);
                                //Tiempo en pensión 
                                item.TiempoPensionAnos = resul.Anos;
                                item.TiempoPensionMeses = resul.Meses;
                            }
                        }
                    }
                }//no is null
            }// es fallecido
        }

        /// <summary>
        /// Calculo de Monto en pension para los familiares.
        /// </summary>
        private void Calculo_MontoPension_Familiar()
        {
            foreach (TFamiliares item in _Familiares)
            {
                item.MontoPension = (item.Scala * this.ScalaMonto);
            }
        }

        /// <summary>
        /// Calculo para Familiares Beneficiarios, Calculo de Edades en función a la fecha de fallecimiento de docente.
        /// </summary>
        public void Calculo_Edad_Familiar()
        { 
            foreach(TFamiliares item in _Familiares){
                if (this.EsFallecido) {
                    Empresa.Comun.StFechasPartes tfecha = Empresa.Comun.Servicios.FechasDifencia(item.FechaNacimiento, this.FechaFallecido);
                    // TimeSpan, para calculo anterior.
                    item.EdadFallecimientoDocente = tfecha.Anos;
                    item.EdadFallecimientoDocentePartida = tfecha;
                }
            }
        }

        /// <summary>
        /// Calculo del rectro activo para los familiares.
        /// </summary>
        public void CalculoRetroActivo() {
            
            if(this.ScalaMonto != 0){

                Empresa.Comun.StFechasPartes dif = Empresa.Comun.Servicios.FechasDifencia(this.FechaFallecido, this.FechaPrimerPago);

                this.TiempoPagosRectroactivoPartida = dif;

                double valor1 = 0;
                int valordia = dif.Dias >= 25 ? 1 : 0;
                valor1 = this.ScalaMonto * ((dif.Anos * 12) + dif.Meses + valordia);
                this.MontoPagosRectroactivo = valor1;

            }

        }

        public string EstadoPR {
            get;
            set;
        }

        public string EntidadAsegura {
            get {
                if (this.EsInabima){
                    return "INABIMA";
                }
                else {
                    if (this.Aseguradora != null)
                    {
                        return this.Aseguradora.Nombre;
                    }
                    else {
                        return string.Empty;
                    }
                }
            }
        }

        public void Calculando_MontoDecretoCalculado() {
            
            if (HistorialPagos.Lista.Count > 0)
            {
                if (this.TiempoServicioEducacionPartida.Anos <= 20){
                    this.MontoDecretoCalculado = this.HistorialPagos.PromedioUltimo(12) * 0.60;
                }

                if (this.TiempoServicioEducacionPartida.Anos > 20 && this.EdadPartida.Anos >= 60){
                    this.MontoDecretoCalculado = this.HistorialPagos.PromedioUltimo(12) * 0.85;
                }

                if (this.TiempoServicioEducacionPartida.Anos >= 25 && this.EdadPartida.Anos >= 55){
                    this.MontoDecretoCalculado = this.HistorialPagos.PromedioUltimo(12) * 0.90;
                }

                if (this.TiempoServicioEducacionPartida.Anos >= 30){
                    this.MontoDecretoCalculado = this.HistorialPagos.PromedioUltimo(12);
                }

            }
        }

        public byte[] Foto {get;set;}
        BitmapSource _AImagen;
        public BitmapSource AImagen {
            get {
                _AImagen = WorkImage.ToImage(this.Foto, TypeImagen.JPG); 
                return _AImagen;  
            }
            set { this.Foto = WorkImage.GetArray(_AImagen); }
        }
        
        public bool EsActivoEstadoLaboral {
            get {
                return EstadoLaboral.Id.Equals(1);
            }
        }

        public string CedulaF
        {
            get{
                return !string.IsNullOrEmpty(this.Cedula) ? this.Cedula.Insert(3, "-").Insert(11, "-") : string.Empty;
            }
        }
        /// <summary>
        /// Se puede Escribir y Leer, el ultimo decreto Aprobado.
        /// </summary>
        public TDecretoDocente DecretoActual
        {
            //  get{

            //     if(Decretos.Count > 0)
            //     {
            //       DateTime ftem =DateTime.MinValue;
            //       TDecretoDocente dec = new TDecretoDocente();

            //         foreach(TDecretoDocente x in this.Decretos){  
            //           if(x.Decreto.Estado.Id == 3){
            //               if (x.Decreto.FechaEP > ftem){
            //                   dec = x;
            //                   ftem = x.Decreto.FechaPrimerPago;
            //               }
            //           }

            //       }
            //       return dec;
            //   }

            //   else{
            //       return null;
            //   }
            //}  
            get;
            set;
        }

        public TDecretoDocente DecretoTransito {
            get{
                foreach(TDecretoDocente x in this.Decretos){
                    if(x.Decreto.Estado.Id == 1 || x.Decreto.Estado.Id == 2){  
                        return x;
                    }
                }
                   
                return this.DecretoActual;
            }
        }

        public double MontoDecretoCalculado
        {
            get;
            private set;
        }

        public bool EsTransito {
            get 
            {
                foreach(TDecretoDocente x in this.Decretos){
                    if(x.Decreto.Estado.Id == 1 || x.Decreto.Estado.Id == 2){
                        return true;
                    }
                }
                return false;
            }
        }
        public ObservableCollection<TDecretoDocente> Decretos { get; set; }
        public string FechaDecretoF {
            get {
                if(this.DecretoActual != null) return ConverToDate.FormatoA(this.DecretoActual.Decreto.FechaEmision);
                return string.Empty;
            }
        }

        private Empresa.Comun.TSuplidor _Aseguradora;
        /// <summary>
        /// Aseguradora para seguro de Sobrevivencia, si no es de inabima
        /// </summary>
        public Empresa.Comun.TSuplidor Aseguradora
        {
            get { return _Aseguradora; }
            set{
                _Aseguradora = value;
                if (this.EsFallecido)
                {
                    //Es valido No es de inabima
                    if (!this.EsInabima == true)
                    {

                        if (_Aseguradora == null)
                        {
                            //Falta Aseguradora
                            this.AgregoError("Aseguradora", "Falta Aseguradora");
                        }
                        else
                        {
                            if (_Aseguradora.Id.Equals(0))
                            {
                                //No valido 
                                this.AgregoError("Aseguradora", "Falta Aseguradora");
                            }
                            else
                            {
                                this.BorrarError("Aseguradora");
                            }
                        }
                    }
                    else
                    {
                        this.BorrarError("Aseguradora");
                    }
                }
            }
        }

        Empresa.Docente.TDecreto _DecretoBeneficiarios;
        /// <summary>
        /// Decreto Perteneciente a los beneficiarios para el seguro de sobrevivencia. si es de inabima.
        /// </summary>
        public Empresa.Docente.TDecreto DecretoBeneficiarios
        {
          
            get;
            set;
        }

        private DateTime _FechaPrimerPago;
        /// <summary>
        /// Fecha del primer pago, Aseguradora o Decreto
        /// </summary>
        public DateTime FechaPrimerPago
        {
            //get { return _FechaPrimerPago; }
            //set {
            //    _FechaPrimerPago = value;
            //    if(_FechaPrimerPago.Equals(DateTime.MinValue) || _FechaPrimerPago.Equals(DateTime.MaxValue)){
            //        this.AgregoError("FechaPrimerPago", "Falta Fecha de pago");
            //    }
            //    else {
            //        this.BorrarError("FechaPrimerPago");

            //    }
            //}
            get;
            set;

        }
        /// <summary>
        /// Inidica si/no sera saegurado(sobrevivencia) por inabima.
        /// </summary>
        public bool EsInabima { get; set; }
        private string _nombrecompleto;
       
        public string NombreCompleto
        {
            get {
                return _nombrecompleto;
            }
            set {

                if (!this.ValidContenido(value).IsValid){
                    this.AgregoError("NombreCompleto", "Falta Nombre");
                }
                else{
                    this.BorrarError("NombreCompleto");
                    _nombrecompleto = value;
                }
            }
        }

        public bool TieneSeguroFunerario{get;set;}
        public bool TieneSobrevivencia { get; set; }

        public tdocente() {
            //this.Comentarios.Lista[0].
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = 0;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty;
            this.EsMasculino = true;
            this.EstadoLaboral = new RHH.testadolaboral();
            this.NombreCompleto = string.Empty;
            this.Nss = string.Empty;
            this.SueldoBrutoActual = 0;
            this.FechaFallecido = DateTime.MinValue;
            this.FechaIngresoEducacion = DateTime.MinValue;
            this.FechaPrimerPago = DateTime.MinValue;
            this.Decretos = new ObservableCollection<TDecretoDocente>();
            this.Familiares = new Familiares();
            this.EsInabima = true;
            this.DecretoBeneficiarios = new TDecreto();
            this.Familiares = new Familiares();
            this.PagosDetalle = new PagoDetalle();
            this.HistorialPagos = new Pagos();
            this.DatosFellecimiento = new tdatosfallecimiento();
            this.Direccion = new Comun.TDireccionAsignada();
            this.TieneSeguroFunerario = false;
            this.TieneSobrevivencia = false;
            this.EsDocente = true;
            //this.Aseguradora = new Comun.TSuplidor();
            //this.Contacto = new Empresa.Comun.tcontacto();
            //this.Direccion = new Comun.TDireccion();
            //this.SolicitudPJ = new SolicitudPJ();
            //this.Aseguradora = new Comun.TSuplidor();
            //this.Decreto = new TDecreto(); 

        }

        public tdocente(int id) {
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = id;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = string.Empty;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty ;
            this.EstadoLaboral = new RHH.testadolaboral();
            this.Contacto = new Empresa.Comun.tcontacto();
            this.Decretos = new System.Collections.ObjectModel.ObservableCollection<TDecretoDocente>();
            //this.DecretoActual = new TDecretoDocente();
            this.EsMasculino = true;
            this.SueldoBrutoActual = 0;
            this.FechaFallecido = DateTime.MinValue;
            this.Familiares = new Familiares();
            this.FechaIngresoEducacion = DateTime.MinValue;
            //this.Direccion = new Comun.TDireccion();
            this.SolicitudPJ = new SolicitudPJ();
            this.Decretos = new ObservableCollection<TDecretoDocente>();
            this.Direccion = new Comun.TDireccionAsignada();
            this.EsDocente = true;
            this.EsNotificadoFallecido = false;
        }

        public tdocente(string cedula){

            this.Tipo = new Comun.TEstandar(1);  // tipo inicial 1;
            this.Id = 0;
            this.Nombres = string.Empty;
            this.Apellidos = string.Empty;
            this.Cedula = cedula;
            this.EsCasado = false;
            this.FechaNacimiento = DateTime.Now;
            this.Profesion = string.Empty;
            this.EsMasculino = true;
            this.SueldoBrutoActual = 0;
            this.FechaFallecido = DateTime.MinValue;
            this.FechaIngresoEducacion = DateTime.MinValue;
            this.Decretos = new ObservableCollection<TDecretoDocente>();
            this.EsDocente = true;
            this.EsNotificadoFallecido = false;
            //this.SolicitudPJ.Actual.PorcientoDiscapacidad
            //this.EstadoLaboral = new RHH.testadolaboral();
            //this.Contacto = new Empresa.Comun.tcontacto();
            //this.Direccion = new Comun.TDireccion();
            //this.SolicitudPJ = new SolicitudPJ();
            //this.Familiares = new Familiares();
            //this.Decreto = new TDecreto();
        }

        //Variable.
        private Empresa.Docente.Decreto _DecretoObj = Empresa.Docente.Decreto.GetInstnace();
                
        public tdocente(int id, string nombres, string apellidos, string nombrec, string cedula, bool escasado, bool esmasculino, DateTime fechanacimiento, string profesion, RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto){
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.EstadoLaboral = estadolaboral;
            this.Contacto = contacto;
            this.EsMasculino = esmasculino;
            this.NombreCompleto = nombrec;
            this.Nss = string.Empty;
            this.SueldoBrutoActual = 0;
            this.FechaPrimerPago = DateTime.MinValue;
            this.FechaFallecido = DateTime.MinValue;
            this.Familiares = new Familiares();
            this.FechaIngresoEducacion = DateTime.MinValue;
            //this.Direccion = new Comun.TDireccion();
            this.SolicitudPJ = new SolicitudPJ();
            this.Direccion = new Comun.TDireccionAsignada();
            this.EsDocente = true;
            this.EsNotificadoFallecido = false;
        }

        public tdocente(int id, string nombres, string apellidos, string nombrec, string cedula, bool escasado, bool esmasculino, DateTime fechanacimiento, string profesion, RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, string decreto, DateTime fechadecreto)
        {
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.EstadoLaboral = estadolaboral;
            this.Contacto = contacto;
            this.EsMasculino = esmasculino;
            this.NombreCompleto = nombrec;
            this.Nss = string.Empty;
            this.SueldoBrutoActual = 0;
            this.Familiares = new Familiares();
            this.FechaIngresoEducacion = DateTime.MinValue;
            //this.Direccion = new Comun.TDireccion();
            this.SolicitudPJ = new SolicitudPJ();
            this.FechaPrimerPago = DateTime.MinValue;
            this.Direccion = new Comun.TDireccionAsignada();
            this.EsDocente = true;
            this.EsNotificadoFallecido = false;
        }

        public tdocente(int id, string nombres, string apellidos, string nombrec, string cedula, bool escasado, bool esmasculino, DateTime fechanacimiento, string profesion, RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, string decreto, DateTime fechadecreto, byte[] foto)
        {
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.EstadoLaboral = estadolaboral;
            this.Contacto = contacto;
            this.EsMasculino = esmasculino;
            this.NombreCompleto = nombrec;
            this.Foto = foto;
            this.Nss = string.Empty;
            this.SueldoBrutoActual = 0;
            this.FechaFallecido = DateTime.MinValue;
            //this.Direccion = new Comun.TDireccion();
            this.Familiares = new Familiares();
            this.FechaIngresoEducacion = DateTime.MinValue;
            this.SolicitudPJ = new SolicitudPJ();
            this.FechaPrimerPago = DateTime.MinValue;
            this.Direccion = new Comun.TDireccionAsignada();
            this.EsDocente = true;
            this.EsNotificadoFallecido = false;
        }

        public tdocente(int id, string nombres, string apellidos, string nombrec, string cedula, bool escasado, bool esmasculino, DateTime fechanacimiento, string profesion, RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, string decreto, DateTime fechadecreto, byte[] foto, string estadopr, string nss, double sueldobaseactual, bool esfallecido, DateTime fechafallecido, DateTime fechaingresoeducacion, DateTime decretofechapago, Pagos historicopagos)
        {
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EstadoLaboral = estadolaboral;
            this.HistorialPagos = historicopagos;

            if (!string.IsNullOrEmpty(this.Cedula)) { 
                this.Familiares = new Familiares(cedula);
                this.CalculoRetroActivo();
            } else { 
                this.Familiares = new Familiares(); 
            }

            this.PagosDetalle = new PagoDetalle(this.Cedula);

            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.Contacto = contacto;
            this.FechaPrimerPago = DateTime.MinValue;
            this.EsMasculino = esmasculino;
            this.NombreCompleto = nombrec;
            this.Foto = foto;
            this.EstadoPR = estadopr;
            this.Nss = nss;
            this.SueldoBrutoActual = sueldobaseactual;
            this.EsFallecido = esfallecido;
            this.FechaFallecido = fechafallecido;
            this.FechaIngresoEducacion = fechaingresoeducacion;
            this.SolicitudPJ = new SolicitudPJ(new tdocente(cedula));
            //this.Direccion = new Comun.TDireccion();
            this.Contacto = new Comun.tcontacto();
            this.EsDocente = true;
            this.EsNotificadoFallecido = false;
        }

        public tdocente(string nombres, string apellidos, string nombrec, string cedula, bool escasado, bool esmasculino, DateTime fechanacimiento, string profesion, RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto)
        {
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = 0;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.EstadoLaboral = estadolaboral;
            this.Contacto = contacto;
            this.EsMasculino = esmasculino;
            this.NombreCompleto = nombrec;
            this.Nss = string.Empty;
            this.SueldoBrutoActual = 0;
            this.FechaFallecido = DateTime.MinValue;
            this.Familiares = new Familiares();
            this.FechaIngresoEducacion = DateTime.MinValue;
            this.SolicitudPJ = new SolicitudPJ();
           // this.Direccion = new Comun.TDireccion();
            this.FechaPrimerPago = DateTime.MinValue;
            this.Direccion = new Comun.TDireccionAsignada();
            this.EsDocente = true;
            this.EsNotificadoFallecido = false;
        }

        public tdocente(string nombres, string apellidos, string nombrec, string cedula, bool escasado, bool esmasculino, DateTime fechanacimiento, string profesion, RHH.testadolaboral estadolaboral, Empresa.Comun.tcontacto contacto, string decreto, DateTime fechadecreto){
            
            this.Tipo = new Comun.TEstandar(1); // tipo inicial 1;
            this.Id = 0;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Cedula = cedula;
            this.EsCasado = escasado;
            this.FechaNacimiento = fechanacimiento;
            this.Profesion = profesion;
            this.EstadoLaboral = estadolaboral;
            this.Contacto = contacto;
            this.EsMasculino = esmasculino;
            this.NombreCompleto = nombrec;
            this.Nss = string.Empty;
            this.SueldoBrutoActual = 0;
            this.FechaFallecido = DateTime.MinValue;
            this.Familiares = new Familiares();
            this.FechaIngresoEducacion = DateTime.MinValue;
            this.SolicitudPJ = new SolicitudPJ();
            //this.Direccion = new Comun.TDireccion();
            this.FechaPrimerPago = DateTime.MinValue;
            this.Direccion = new Comun.TDireccionAsignada();
            this.EsDocente = true;
            this.EsNotificadoFallecido = false;
        }


        public static implicit operator tdocente(Empresa.RHH.tpersonal arg) {
            tdocente __doctemp = new tdocente();
            __doctemp.Cedula = arg.Cedula;
            __doctemp.Nombres = arg.Nombres;
            __doctemp.NombreCompleto = arg.NombreCompleto;
            __doctemp.EsMasculino = arg.EsMasculino;
            __doctemp.EsCasado = arg.EsCasado;
            __doctemp.EsFallecido = arg.EsFallecido;
            __doctemp.FechaNacimiento = arg.FechaNacimiento;
            __doctemp.Foto = arg.Foto;
            __doctemp.Apellidos = arg.Apellidos;
            return __doctemp;
        }


    }
}

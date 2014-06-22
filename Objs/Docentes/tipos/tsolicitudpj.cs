using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Empresa.Docente
{
    public class tsolicitudpj:Empresa.Comun.Validacion.HdError, INotifyPropertyChanged {

        public int Id                           { get; set; }
        public string Detalles                  { get; set; }
        public tdocente Docente                 { get; set; }
        public double Monto                     { get; set; }
        public double Rectroactivo              { get; set; }
        public double PorcientoDiscapacidad     { get; set; }
        public double EscalaPesionDiscapacidad  { get; set; }

        public DateTime FechaConcrecionCalculo {
            
            get {
            return _fechaconcrecioncalculo;
            }

        }

        public DateTime _fechaconcrecioncalculo;

        public bool EsSoloLectura {
            get {
                return (this.EstadoActual.Estado.Id == 2 || this.EstadoActual.Estado.Id == 3); 
            }
        
        }

        private double _porcientoaplicado;

        public Empresa.Comun.StFechasPartes TiempoServicioFechaConcrecion {
            get {
                if(this.FechaConcrecion != DateTime.MinValue) return Empresa.Comun.Servicios.FechasDifencia(this.Docente.FechaIngresoEducacion, this.FechaConcrecion);
                return new Comun.StFechasPartes();
            }
        }

        public double PorcientoAplicado {
            
            get { return _porcientoaplicado; }
            set {
                _porcientoaplicado = value;
                //this._calculando_Monto();
            }

        }

        public void _calculando_Monto()
        {
            if(this.FechaConcrecion != DateTime.MinValue){

                if (this.Docente.HistorialPagos != null){
                    Monto = (this.Docente.HistorialPagos.PromedioUltimo(12, this._fechaconcrecioncalculo) * this.EscalaPesionDiscapacidad) / 100;
                    this._calculando_EscalaPensionDiscapcidad();   
                }
                else {
                    this.Monto = 0;
                }
                this.EnCambio("Monto"); 
            }
        }

        public void _calculando_MontoRetroactivo(){
            
            if (this.FechaConcrecion != DateTime.MinValue){
                if (this.Docente.HistorialPagos != null){

                 if (this.FechaConcrecion != DateTime.MinValue)
                 {

                    switch (this.OrigenBeneficio.Id) { 
                    
                        case 1:
                            //Decreto
                            break;
                        case 2:
                            //Inabima Recapitalizable
                            break;
                        case 3:
                            //Aseguradora
                            Empresa.Comun.StFechasPartes fechas = Empresa.Comun.Servicios.FechasDifencia(Docente.HistorialPagos.Ultimo.Fecha, this._fechaconcrecioncalculo);
                            
                            int dias = DateTime.DaysInMonth(_fechaconcrecioncalculo.Year, _fechaconcrecioncalculo.Month);
                            double montocalcular = this.Monto / Convert.ToDouble(dias);
                            int diferenciadias = dias - _fechaconcrecioncalculo.Day;

                            double montoarestar = montocalcular * Convert.ToDouble(diferenciadias);

                            this.Rectroactivo =  (fechas.Meses + (fechas.Anos * 12))  * this.Monto;
                            this.Rectroactivo = this.Rectroactivo - montoarestar;

                            // Descuento a aplicar por ley. 
                            this.Rectroactivo = Rectroactivo - 30.01;  //Descuento Fijo
                            this.Rectroactivo = Rectroactivo - (Rectroactivo * 0.0419); // sumados los descuento de 1.15 y 3.04;
                            break;
                        }
                    }
                    else {
                        this.Rectroactivo = 0;
                    }

                }
                else{
                    this.Rectroactivo = 0;
                }


                this.EnCambio("Rectroactivo");
            }
        }

        public void _calculando_EscalaPensionDiscapcidad() {

            if (this.TiempoServicioFechaConcrecion.Anos <= 15){
                 this.EscalaPesionDiscapacidad = 60.00;
            }

            if (this.TiempoServicioFechaConcrecion.Anos > 15 && this.TiempoServicioFechaConcrecion.Anos <= 20){
                    this.EscalaPesionDiscapacidad =  70.00;
            }

            if(this.TiempoServicioFechaConcrecion.Anos > 20){
                this.EscalaPesionDiscapacidad = 80.00;
            }

            this.EnCambio("EscalaPesionDiscapacidad"); 
        }

        private DateTime _fechaconcrecion;
        public DateTime FechaConcrecion
        {
            get { return _fechaconcrecion; }
            set 
            {
                _fechaconcrecion = value;
                if(!_fechaconcrecion.Equals(DateTime.MinValue)){
                    if (_fechaconcrecion.Day <= 24){
                            this._fechaconcrecioncalculo = _fechaconcrecion.AddMonths(-1);
                    }
                    else{
                        this._fechaconcrecioncalculo = _fechaconcrecion;
                    }
                    this._calculando_Monto();
                }
            
            }
        }
        DateTime _Fecha;
        public DateTime Fecha {

            get {return _Fecha;}
            set {

                if (value == null || value == DateTime.MinValue){
                    this.AgregoError("Fecha", "Falta fecha de solicitud");
                }
                else {
                    this.BorrarError("Fecha");
                    _Fecha = value;
                }
            } 
        }
        public string NoExpediente { get; set; }
        public Empresa.Comun.TSuplidor Aseguradora { get; set; }
        ObservableCollection<trequesitosasignados> _requisitos;
        public ObservableCollection<trequesitosasignados> Requisitos {
            get { 
                return _requisitos; 
            }
            set {
                _requisitos = value;
                
                EnCambio("Requisitos");
                EnCambio("RequisitosTotal");
                EnCambio("RequisitosCompletadosS");
                EnCambio("RequisitosCompletadosP");
            }
        }
        public TSolicitante Solicitante { get; set; }
        public testadossolicitudpj EstadoActual { get; set; }
        public EstadosSolicitudPJ Estados { get;set; }
        public TiemposSolicitud Tiempos { get; set; }
        private ttiposiniestro _TipoSiniestro;
        public ttiposiniestro TipoSiniestro {
            get {
                return _TipoSiniestro; 
            }
            set {
                _TipoSiniestro = value;
                if (value == null){
                    this.AgregoError("TipoSiniestro", "Falta tipo de siniestro");
                }
                else {
                    if (value.Id.Equals(0)){
                        this.AgregoError("TipoSiniestro", "Falta tipo de siniestro");
                    }
                    else {
                        this.BorrarError("TipoSiniestro");
                        
                    }
                }

                this.EnCambio("TipoSiniestro");
            }
        }
        private DateTime _FechaSiniestro;
        [DisplayName("FechaSiniestro")]
        public DateTime FechaSiniestro {
            get {return _FechaSiniestro;}
            set {
                _FechaSiniestro = value;

                if(_FechaSiniestro == DateTime.MinValue){
                    this.AgregoError("FechaSiniestro", "Falta fecha de siniestro");
                }
                else {
                    this.BorrarError("FechaSiniestro");
                }

                this.EnCambio("FechaSiniestro");
            }
        }
        
        DateTime _FechaEntrada;
        /// <summary>
        /// Fecha en que el usuario registra la entrada(puede ser diferente a la fecha actual).
        /// </summary>
        public DateTime FechaEntrada {
            get { return _FechaEntrada; }
            set {
                _FechaEntrada = value;
                if (_FechaEntrada == DateTime.MinValue){
                    this.AgregoError("FechaEntrada", "Falta fecha de entrada de solicitud");
                }
                else{
                    this.BorrarError("FechaEntrada");
                }
                this.EnCambio("FechaEntrada");
            
            }
        }
        
        public Empresa.Comun.TEstandar Tipo { get; set; }

        /// <summary>
        /// Tipo de solicitud(Decreto, Inabima Recapitalizable, Aseguradora).
        /// </summary>
        private Empresa.Comun.TEstandar _OrigenBeneficio;
        public Empresa.Comun.TEstandar OrigenBeneficio {
            get { return _OrigenBeneficio; }
            set {
                _OrigenBeneficio = value;
                if (_OrigenBeneficio == null){
                    this.AgregoError("OrigenBeneficio", "Error falta Tipo de solicitud");
                }
                else {
                    if (_OrigenBeneficio.Id.Equals(0)){
                        this.AgregoError("OrigenBeneficio", "Error falta Tipo de solicitud");
                    }
                    else {
                        this.BorrarError("OrigenBeneficio");
                    }
                }
                this.EnCambio("OrigenBeneficio");
            }
        }
        
        private Empresa.Comun.TEstandar _OrigenSiniestro;
        public Empresa.Comun.TEstandar OrigenSiniestro {
            get
            {
                return _OrigenSiniestro;
            }
            set
            {
                _OrigenSiniestro = value;
                if (_OrigenSiniestro == null){
                    this.AgregoError("OrigenSiniestro", "Falta origen del siniestro");
                }
                else{
                    if (value.Id.Equals(0)){
                        this.AgregoError("OrigenSiniestro", "Falta origen del siniestro");
                    }
                    else{
                        this.BorrarError("OrigenSiniestro");
                    }
                }
            }
        
        }

        public int RequisitosTotal{
            get {
                return Empresa.Docente.Requisitos.GetInstante().Lista.Count; 
            }
        }

        public string RequisitosCompletadosS {
            get {
                return this.Requisitos.Count.ToString() + "/" + this.RequisitosTotal.ToString(); 
            }
        }

        public double RequisitosCompletadosP {
            get{
                return ( Convert.ToDouble(this.Requisitos.Count) / Convert.ToDouble(this.RequisitosTotal)) * 100;
            }
        }

        PasospjAsignados _pasos;
        public PasospjAsignados Pasos {
            get { return _pasos; }
            set {
                this._pasos = value;
                this.EnCambio("Pasos"); 
                
            }
        }

        public tsolicitudpj(){
            
            this.Tipo = new Comun.TEstandar(4);
            this.Id = 0;
            this.Fecha = DateTime.MinValue;
            this.FechaSiniestro = DateTime.MinValue;
            this.FechaConcrecion = DateTime.MinValue;
            this.NoExpediente = string.Empty;
            this.Aseguradora = new Comun.TSuplidor();
            this.Requisitos = new ObservableCollection<trequesitosasignados>() ;
            this.OrigenSiniestro = new Comun.TEstandar();            
            this.EstadoActual = new testadossolicitudpj(EstadoPJ.GetInstance().GetItem(4));
            this.Solicitante = new TSolicitante();
            this.Pasos = new PasospjAsignados(Pasospj.GetInstance());
            this.TipoSiniestro = new ttiposiniestro();
            this.Detalles = string.Empty;
            this.PorcientoAplicado = 0;
            this.Tiempos = new TiemposSolicitud();


            this.FechaConcrecion = DateTime.MinValue;
        }

        public tsolicitudpj(tdocente docente)
        {
            this.Tipo = new Comun.TEstandar(4);
            this.Id = 0;
            this.Fecha = DateTime.MinValue;
            this.FechaSiniestro = DateTime.MinValue;
            this.NoExpediente = string.Empty;
            this.Aseguradora = new Comun.TSuplidor();
            this.Requisitos = new ObservableCollection<trequesitosasignados>();
            this.OrigenSiniestro = new Comun.TEstandar();
            this.EstadoActual = new testadossolicitudpj(EstadoPJ.GetInstance().GetItem(4));
            this.Solicitante = new TSolicitante();
            this.Pasos = new PasospjAsignados(Pasospj.GetInstance());
            this.TipoSiniestro = new ttiposiniestro();
            this.Detalles = string.Empty;
            this.PorcientoAplicado = 0;
            this.Tiempos = new TiemposSolicitud();
            this.Docente = docente;
            this.FechaConcrecion = DateTime.MinValue;
        }

        public tsolicitudpj(int id){
            this.Tipo = new Comun.TEstandar(4);
            this.Id = id;
            this.Fecha = DateTime.MinValue;
            this.NoExpediente = string.Empty;
            //this.Aseguradora = new Comun.TSuplidor();
            this.Requisitos = new ObservableCollection<trequesitosasignados>();
            //this.OrigenSiniestro = new Comun.TEstandar();
            //this.EstadoActual = new testadossolicitudpj(EstadoPJ.GetInstance().GetItem(4));
            //this.Solicitante = new TSolicitante();
            this.Detalles = string.Empty;
            this.PorcientoAplicado = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void EnCambio(string nombre){
              PropertyChangedEventHandler manejador = PropertyChanged;
              if (manejador != null)
              {
                  manejador(this, new PropertyChangedEventArgs(nombre));
              }
          }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Empresa.Docente
{
    public class tsolicitudfunenario:Empresa.Comun.Validacion.HdError, INotifyPropertyChanged {
        
        /// <summary>
        /// Tipo de Documento
        /// </summary>
        public int Tipo       { get{return 4;}}
        public int Id         { get; set; }
        public string Numero  { get; set; }
        public int Porciento  { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto   { get;set;  }

        /// <summary>
        /// Indica si la solicitud fue pagada.
        /// </summary>
        public Empresa.Comun.TEstandar EstadoPago { get; set; }

        public bool EsPago { get; set; }

        private DateTime _fechaEntrada;
        
        public DateTime FechaEntrada {
            get {
                return _fechaEntrada;
            }
            set {
                _fechaEntrada = value;

                if(_fechaEntrada == DateTime.MinValue){
                    this.AgregoError("FechaEntrada", "Error Falta Fecha"); 
                }
                else {
                    this.BorrarError("FechaEntrada");
                }

            }
        }

        public bool EsLectura {
            get {
                return (this.EstadoActual.Estado.Id.Equals(3) || this.EstadoActual.Estado.Id.Equals(4));
            }
        }

        public bool EsEstadoCambia{
            get{
                return !(this.EstadoActual.Estado.Id.Equals(2));
            }
        }

        public string Detalle { get; set; }
        public tdocente Docente { get; set; }
        public bool Existe { get; set; }
        public testadoasignado EstadoActual { get; set; }
        public TiempoSolicitudSeguroFunerario Tiempos { get; set; }

        //El Solicitante
        public TSolicitante Solicitante { get; set; }
        //Los Beneficiarios
        public ObservableCollection<tpersonaRelacionada> Beneficiarios { get; set; }
        public ObservableCollection<trequesitosasignados> Requisitos   { get; set; }

        /// <summary>
        /// Indica el primer beneficiario de la lista de beneficiarios.
        /// </summary>
        public tpersonaRelacionada DamePrimerBeneficiario{
            get;
            set;
        }

        public bool ExiteBeneficiario(string cedula){
            foreach (tpersonaRelacionada itemper in Beneficiarios){
                    if (itemper.Persona.Cedula.Equals(cedula)) return true;
            }
            return false;
        }

        public int RequisitosTotal{
            get{
                return Empresa.Docente.RequisitosSeguroFunerario.GetInstante().Lista.Count;
            }
        }

        public string RequisitosCompletadosS{
            get {
                return this.Requisitos.Count.ToString() + "/" + this.RequisitosTotal.ToString();
            }
        }

        public double RequisitosCompletadosP
        {
            get{
                return (Convert.ToDouble(this.Requisitos.Count) / Convert.ToDouble(this.RequisitosTotal)) * 100;
            }
        }

        /// <summary>
        /// Ultimo Estado
        /// </summary>
        //public testadoasignado Estado { get; set; }

        public tsolicitudfunenario(){
            this.Id = 0;
            this.Numero = string.Empty;
            this.Porciento = 0;
            this.Fecha = DateTime.MinValue;
            this.FechaEntrada = DateTime.MinValue;
            this.Detalle = string.Empty;
            this.Existe = false;
            this.EstadoActual = new testadoasignado(SeguroFunerarioEstado.GetInstance().GetItem(1));
            this.Requisitos = new ObservableCollection<trequesitosasignados>();
            this.Beneficiarios = new ObservableCollection<tpersonaRelacionada>();
            this.Docente = new tdocente();
            this.Solicitante = new TSolicitante();
            this.EsPago = false;
            this.Monto = 0;

            //DameBeneficiario.Persona.CedulaF
        }

        public tsolicitudfunenario(int id){
            this.Id = id;
            this.Numero = string.Empty;
            this.Porciento = 0;
            this.Fecha = DateTime.MinValue;
            this.FechaEntrada = DateTime.MinValue;
            this.Detalle = string.Empty;
            this.Docente = new tdocente();
            this.Existe = false;
            this.EstadoActual = new testadoasignado(SeguroFunerarioEstado.GetInstance().GetItem(1));
            this.Requisitos = new ObservableCollection<trequesitosasignados>();
            this.EsPago = false;
            this.Monto = 0;
        }

        public tsolicitudfunenario(string cedula){
            this.Id = 0;
            this.Numero = string.Empty;
            this.Porciento = 0;
            this.Fecha = DateTime.MinValue;
            this.FechaEntrada = DateTime.MinValue;
            this.Detalle = string.Empty;
            this.Docente = new tdocente(cedula);
            this.Existe = false;
            this.EstadoActual = new testadoasignado(SeguroFunerarioEstado.GetInstance().GetItem(1));
            this.Requisitos = new ObservableCollection<trequesitosasignados>();
            this.EsPago = false;
            this.Monto = 0;
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

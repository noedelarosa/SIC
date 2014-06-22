using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Empresa.Comun;
using Empresa.Comun.Validacion;
using System.Windows.Controls;

namespace Empresa.Docente
{
    public class TDecreto: Comun.TEstandar
    {
        DateTime _fechaemision;
        public DateTime FechaEmision{
            get { return _fechaemision; }
            set {
                _fechaemision = value;
                if (_fechaemision == DateTime.MinValue || _fechaemision == DateTime.MaxValue){
                    AgregoError("FechaEmision", "Falta Fecha de Emisión");
                }
                else{
                    BorrarError("FechaEmision"); 
                }
            }
        }
        public tpresidente Presidente { get; set; }

        DateTime _fechaprimerpago;
        public DateTime FechaPrimerPago {
            get { return _fechaprimerpago; }
            set {
                _fechaprimerpago = value;

                if(_fechaprimerpago == DateTime.MinValue || _fechaprimerpago == DateTime.MaxValue){
                    AgregoError("FechaPrimerPago", "Falta Fecha de Emisión");
                }
                else{
                    BorrarError("FechaPrimerPago");
                }

            }
        }

        public string FechaPrimerPagoTostring {
            get {
                return Empresa.Comun.ConverToDates.FormatoA(this.FechaEmision); 
            }
        }

        public DateTime FechaPromedio { get; set; }

        string _numero;
        public string Numero {
            get { return _numero; }
            set {
                _numero = value.Trim();
                if (string.IsNullOrEmpty(_numero))
                {
                    AgregoError("Numero", "Falta el Número de decreto");
                }
                else {
                    BorrarError("Numero"); 
                }
            }
        }

        Empresa.Comun.TEstandar _estado;
        public Empresa.Comun.TEstandar Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                if (_estado == null){
                    _estado.AgregoError("Estado", "Falta Estado de Decreto.");
                }
                else{
                    _estado.BorrarError("Estado");
                }
            }
        }
        public bool PuedeAgregar {
            get {
                return Estado.Id.Equals(1);
            }
        }

        /// <summary>
        /// Retorna la fecha valida del primer pago o la fecha de Emision del decreto
        /// </summary>
        /// <returns></returns>
        /// 
        public DateTime FechaEP {
            get
            {
                if (FechaPrimerPago.Equals(DateTime.MinValue))
                {
                    //No existe Fecha de primer pago
                    return FechaEmision;
                }
                else
                {
                    return FechaPrimerPago;
                }
            }
        }

        public TDecreto(){
            this.Id = 0;
            this.Numero = string.Empty;
            this.Descripcion = string.Empty;
            this.FechaEmision = DateTime.MinValue;
            this.FechaPrimerPago = DateTime.MinValue;
        }
        public TDecreto(int id) {
            this.Id = id;
            this.Descripcion = string.Empty;
            this.FechaEmision = DateTime.MinValue;
            this.FechaPrimerPago = DateTime.MinValue;
            this.Numero = string.Empty;
            
        }
        
        public TDecreto(string numero)
        {
            this.Id = 0;
            this.Descripcion = string.Empty;
            this.FechaEmision = DateTime.MinValue;
            this.FechaPrimerPago = DateTime.MinValue;
            this.Numero = numero;
            this.Estado = EstadoDecreto.GetInstance().GetItem(1);
        }

        public TDecreto(DateTime fechaemision, DateTime feprimerpago)
        {
            this.Id = 0;
            this.Descripcion = string.Empty;
            this.FechaEmision = fechaemision;
            this.FechaPrimerPago = feprimerpago;
            this.Numero = string.Empty;
            this.Estado = EstadoDecreto.GetInstance().GetItem(1);
            this.Presidente = Presidentes.GetInstance().Actual();

        }

        public TDecreto(int id, string numero,DateTime fechaemision, DateTime feprimerpago)
        {
            this.Id = id;
            this.Descripcion = string.Empty;
            this.FechaEmision = fechaemision;
            this.FechaPrimerPago = feprimerpago;
            this.Numero = numero;
            this.Estado = EstadoDecreto.GetInstance().GetItem(1);
        }

        public TDecreto(int id, string numero, DateTime fechaemision, DateTime feprimerpago,Empresa.Comun.TEstandar estado)
        {
            this.Id = id;
            this.Descripcion = string.Empty;
            this.FechaEmision = fechaemision;
            this.FechaPrimerPago = feprimerpago;
            this.Numero = numero;
            this.Estado = estado;
            this.Presidente = new tpresidente();
            
        }

        private DecretoDocente _InclusionExlucion;
        public DecretoDocente InclusionExlucion
        {
            get {
                _InclusionExlucion = new DecretoDocente(this);
                return _InclusionExlucion;
            }
        }

    }
}

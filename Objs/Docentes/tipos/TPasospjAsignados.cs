using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Empresa.Docente
{

    public class TPasospjAsignados: INotifyPropertyChanged {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaIngreso { get; set; }
        private bool _EsActivo;
        public bool EsActivo {
            get { return _EsActivo; }
            set {
                _EsActivo = value;
                this.EnCambio("EsActivo");
            }
        }
        
        public TPasospj Paso { get; set; }
        public tsolicitudpj Solicitud { get; set; }
        public bool EsLeible {
            get {
                return !EsActivo;
            }
        }

        public int IdSolicitud { get; set; }

        public TPasospjAsignados(){
            this.Id = 0;
            this.Fecha = DateTime.MinValue;
            this.FechaIngreso = DateTime.MinValue;
            this.EsActivo = false;
            this.Paso = new TPasospj();
        }

        public TPasospjAsignados(int id){
            this.Id = id;
            this.Fecha = DateTime.MinValue;
            this.FechaIngreso = DateTime.MinValue;
            this.EsActivo = false;
            this.Paso = new TPasospj();
        }

        public TPasospjAsignados(int id, DateTime fecha, DateTime fechaingreso, bool esactivo, TPasospj paso){
            this.Id = id;
            this.Fecha = fecha;
            this.FechaIngreso =fechaingreso;
            this.EsActivo = esactivo;
            this.Paso = paso;
        }

        public TPasospjAsignados(DateTime fecha, DateTime fechaingreso, bool esactivo, TPasospj paso){
            this.Id = 0;
            this.Fecha = fecha;
            this.FechaIngreso = fechaingreso;
            this.EsActivo = esactivo;
            this.Paso = paso;
        }

        public TPasospjAsignados(DateTime fecha, DateTime fechaingreso, bool esactivo, TPasospj paso, tsolicitudpj solicitud)
        {
            this.Id = 0;
            this.Fecha = fecha;
            this.FechaIngreso = fechaingreso;
            this.EsActivo = esactivo;
            this.Paso = paso;
            this.Solicitud = solicitud;
        }

        public TPasospjAsignados(int id,DateTime fecha, DateTime fechaingreso, bool esactivo, TPasospj paso, tsolicitudpj solicitud)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.FechaIngreso = fechaingreso;
            this.EsActivo = esactivo;
            this.Paso = paso;
            this.Solicitud = solicitud;
        }

        public TPasospjAsignados(DateTime fecha, DateTime fechaingreso, bool esactivo, TPasospj paso, int idsolicitud){
            this.Id = 0;
            this.Fecha = fecha;
            this.FechaIngreso = fechaingreso;
            this.EsActivo = esactivo;
            this.Paso = paso;
            this.IdSolicitud = idsolicitud;
        }

        public TPasospjAsignados(int id, bool esactivo, TPasospj paso){
            this.Id = id;
            this.Fecha = DateTime.MinValue;
            this.FechaIngreso = DateTime.MinValue;
            this.EsActivo = esactivo;
            this.Paso = paso;
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

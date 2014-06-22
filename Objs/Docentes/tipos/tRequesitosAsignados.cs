using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Empresa.Docente
{
    public class trequesitosasignados: Empresa.Comun.Validacion.ReglaContenido {

        public int Id { get; set; }

        private trequisitos _requisito;
        public trequisitos Requisito {
            get { return _requisito; }
            set {
                _requisito = value;
                if (_requisito == null){
                    this.AgregoError("Requisito", "Falta Requisito");
                }
                else {
                    if (_requisito.Id.Equals(0)){
                        this.AgregoError("Requisito", "Falta Requisito");
                    }
                    else {
                        this.BorrarError("Requisito");
                    }
                }
            }
        }

        private DateTime _fecha;
        public DateTime Fecha {
            get { return _fecha; }
            set {
                _fecha = value;
                if (_fecha == DateTime.MinValue){
                    this.AgregoError("Fecha", "Falta Fecha");
                }
                else {
                    this.BorrarError("Fecha");
                }
            }
        }


        public bool Valor { get; set; }
        
        public string Comentario { get; set; }
        public bool TieneImagen { 
            get {
                if (this.FotoArreglo != null){
                    return (this.FotoArreglo.Count() > 0);
                }
                else {
                    return false;
                }
            } 
        }
        public byte[] FotoArreglo { get; set; }
        
        public BitmapSource AImagen {
            get {
                return WorkImage.ToImage(this.FotoArreglo, TypeImagen.JPG);
            }
            set {
                FotoArreglo = WorkImage.GetArray(value, TypeImagen.JPG);
            }
        }

        public trequesitosasignados() {
            this.Id = 0;
            this.Requisito = new trequisitos();
            this.Valor = false;
            this.Fecha = DateTime.MinValue;
            this.Comentario = string.Empty;
        }

        public trequesitosasignados(int id){
            this.Id = id;
            this.Requisito = new trequisitos();
            this.Valor = false;
            this.Fecha = DateTime.MinValue;
            this.Comentario = string.Empty;
        }

        public trequesitosasignados(int id,trequisitos requisito, bool valor, DateTime fecha, string comentario){
            this.Id = id;
            this.Requisito = requisito;
            this.Valor = valor;
            this.Fecha = fecha;
            this.Comentario = comentario;
        }

        public trequesitosasignados(trequisitos requisito, bool valor, DateTime fecha, string comentario){
            this.Id = 0;
            this.Requisito = requisito;
            this.Valor = valor;
            this.Fecha = fecha;
            this.Comentario = comentario;
        }

        public trequesitosasignados(trequisitos requisito, bool valor, string comentario){
            this.Id = 0;
            this.Requisito = requisito;
            this.Valor = valor;
            this.Comentario = comentario;
            this.Fecha = DateTime.MinValue;
        } 
    }
}

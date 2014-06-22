using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class TComentario: Empresa.Comun.Validacion.HdError
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string _Comentario;
        public string Comentario {
            get { return _Comentario; }
            set {

                if (string.IsNullOrEmpty(value)){
                    this.AgregoError("Comentario", "Falta comentario");
                }
                else {
                    this.BorrarError("Comentario");
                    _Comentario = value;
                }
            }
        }

        public bool EsPresencial { get; set; }

        public DateTime Fecha { get; set; }
        public TEstandar Tipo { get; set; } //establece el tipo de documento
        public object Referencia {get;set;}
        public TComentario(){
            this.Id = 0;
            this.Comentario = string.Empty;
            this.Fecha = DateTime.MinValue;
            this.Tipo = new TEstandar();
            this.Referencia = new object();
        }

        public TComentario(int id){
            this.Id = id;
            this.Comentario = string.Empty;
            this.Fecha = DateTime.MinValue;
            this.Tipo = new TEstandar();
            this.Referencia = new object();
        }

        public TComentario(int id, DateTime fecha, string comentario, TEstandar tipo, object referencia)
        {
            this.Id = id;
            this.Comentario = comentario;
            this.Fecha = fecha;
            this.Tipo = tipo;
            this.Referencia = referencia;
        }

        public TComentario(DateTime fecha, string comentario, TEstandar tipo, object referencia, bool espresencial)
        {
            this.Id = 0;
            this.Comentario = comentario;
            this.Fecha = fecha;
            this.Tipo = tipo;
            this.Referencia = referencia;
            this.EsPresencial = espresencial;
        }
    }
}

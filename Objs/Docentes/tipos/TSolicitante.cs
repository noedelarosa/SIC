using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class TSolicitante:Empresa.RHH.tpersonal {
        private Empresa.Comun.TEstandar _tipo;
        public Empresa.Comun.TEstandar Tipo {
            get { return _tipo; }
            set {
                _tipo = value;
                if (_tipo == null){
                    this.AgregoError("Tipo", "Falta Parentesco" );
                }
                else {
                    if (_tipo.Id.Equals(0))
                    {
                        this.AgregoError("Tipo", "Falta Parentesco");
                    }
                    else {
                        this.BorrarError("Tipo");
                    }
                }
            }
        }
        public string Otros { get; set; }
        public Empresa.Comun.TParentesco Parentesco { get; set; } 

        public bool Exite {
            get {
                return (!this.Id.Equals(0));
            }
        }
    
        public TSolicitante() {
            
            this.Id = 0;
            this.Nombres = string.Empty;
            this.Nss = string.Empty;
            this.EsCasado = false;
            this.EsDiscapacitado = false;
            this.EsMasculino = true;
            this.Cedula = string.Empty;
            this.Otros = string.Empty;
            this.Tipo = new Comun.TEstandar();
        }

        public TSolicitante(string cedula){
            this.Cedula = cedula;
            this.Nombres = string.Empty;
            this.Nss = string.Empty;
            this.EsCasado = false;
            this.Tipo = new Comun.TEstandar();
            this.Otros = string.Empty;
        }


        public TSolicitante(RHH.tpersonal item) {
            this.Id = item.Id;
            this.Nombres = item.Nombres;
            this.Nss = item.Nss;
            this.EsCasado = item.EsCasado;
            this.EsDiscapacitado = item.EsDiscapacitado;
            this.EsMasculino = item.EsMasculino;
            this.Cedula = item.Cedula;
            this.Apellidos = item.Apellidos;
            this.DireccionAsignada = item.DireccionAsignada;
            this.Otros = string.Empty;
            this.Tipo = new Comun.TEstandar();
        }

    }
}

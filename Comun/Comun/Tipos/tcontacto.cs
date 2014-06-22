using System;
namespace Empresa.Comun {

    public class tcontacto: Empresa.Comun.Validacion.ReglaContenido {
        public int Id { get; set; }
        
        public bool Existe {
            get {
                return !Id.Equals(0); 
            }
        }

        public string TelefonoA { get; set;  }
        public string TelefonoB { get; set;  }

        public string ExtensionA { get; set; }
        public string ExtensionB { get; set; }

        public string MovilA { get; set; }
        public string MovilB { get; set; }

        public string EmailA { get; set; }
        public string EmailB { get; set; }

        public string CodigoPostal { get; set; }

        public string FaxA { get; set; }
        public string FaxB { get; set; }

        public string WebA { get; set; }
        public string WebB { get; set; }

        public object Muso { get; set; } // Multi Uso

        public tcontacto() {
            this.Id = 0;

            this.TelefonoA = string.Empty;
            this.TelefonoB = string.Empty;

            this.ExtensionA = string.Empty;
            this.ExtensionB = string.Empty;

            this.MovilA = string.Empty;
            this.MovilB = string.Empty;

            this.EmailA = string.Empty;
            this.EmailB = string.Empty;

            this.FaxA = string.Empty;
            this.FaxB = string.Empty;

            this.WebA = string.Empty;
            this.WebB = string.Empty;

            this.CodigoPostal = string.Empty;
        }
        
        public tcontacto(int id) {
            this.Id = id;

            this.TelefonoA = string.Empty;
            this.TelefonoB = string.Empty;

            this.ExtensionA = string.Empty;
            this.ExtensionB = string.Empty;

            this.MovilA = string.Empty;
            this.MovilB = string.Empty;

            this.EmailA = string.Empty;
            this.EmailB = string.Empty;

            this.FaxA = string.Empty;
            this.FaxB = string.Empty;

            this.WebA = string.Empty;
            this.WebB = string.Empty;
            this.CodigoPostal = string.Empty;
        }

        public tcontacto(int id, string telefonoa, string movila, string emaila) {
            this.Id = id;
            this.TelefonoA = telefonoa;
            this.MovilA = movila;
            this.EmailA = emaila;
            
            this.TelefonoB = string.Empty;

            this.ExtensionA = string.Empty;
            this.ExtensionB = string.Empty;

            this.MovilB = string.Empty;
            
            this.EmailB = string.Empty;

            this.FaxA = string.Empty;
            this.FaxB = string.Empty;

            this.WebA = string.Empty;
            this.WebB = string.Empty;
            this.CodigoPostal = string.Empty;
        }

    }
}

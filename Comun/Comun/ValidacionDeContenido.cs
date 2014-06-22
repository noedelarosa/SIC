using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Empresa.Comun
{
    public class ValidacionDeContenido : ValidationRule {
        int __min { get; set; }
        int __max { get; set; }

        public int Max {
            get {
                return __max;
            }
            set {
                __max = value;
            }
        }

        public int Min {
            get {
                return __min;
            }
            set {
                __min = value;
            }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo){            
            //throw new NotImplementedException();
            try {
                string valor = value as string;
                if(valor.Length == 0) return new ValidationResult(false,"No contenido presente");
                int valorint = Convert.ToInt32(valor);

                if ((valorint < Min) || (valorint > Max))
                {
                    return new ValidationResult(false, "No contenido presente");
                } else {
                    return new ValidationResult(true, null);
                }
            }
            catch {
                return new ValidationResult(false, "error contenido");
            
            }
        }


    }
}

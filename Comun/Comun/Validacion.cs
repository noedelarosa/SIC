using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
namespace Empresa.Comun.Validacion
{
   
            //class MandatoryInputRule : ValidationRule
            //{
            //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            //    {
            //        if (value != null)
            //        {
            //            if (((string)value).Length > 0)
            //            {
            //                return new ValidationResult(true, value);
            //            }
            //        }
            //        return new ValidationResult(false, "Error de validación, debe introducir información.");
            //    }
            //}

            //public class ReglaRango:ValidationRule {
                
            //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            //    {
            //        throw new NotImplementedException();
            //    }
            //}

            //public class ReglaContenido: ValidationRule {
            //    //public ReglaContenido(object value) { this.Value = value; }
            //    //public object Value { get; set; }
            //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            //    {
            //        if (value == null || value.ToString().Equals(string.Empty) || value.ToString().Length.Equals(0) || value.ToString().Trim().Length.Equals(0))
            //        {
            //            return new ValidationResult(false, "Error, Contenido no valido.");    
            //        }
            //        return new ValidationResult(true, null);
            //    }
            //}
            //public class ReglaNumero { }
            //public class ReglaLetra { }
            //public class ReglaNumerosMoneda:ValidationRule {
            //    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            //    {
            //        if (!(Regex.IsMatch(value.ToString(), @"((0)+(\.[1-9](\d)?))|((0)+(\.(\d)[1-9]+))|(([1-9]+(0)?)+(\.\d+)?)|(([1-9]+(0)?)+(\.\d+)?)").Equals(true)))
            //        {
            //            return new ValidationResult(false, "Error Numerico en el contenido.");
            //        }

            //        if ((double)value == 0)
            //        {
            //            return new ValidationResult(false, "Error Numerico en el contenido, valor no cero.");
            //        }

            //        return new ValidationResult(true, null); 
            //    }
            //}

            public class ReglaContenido: HdError 
            {
                
                /// <summary>
                /// Valida el contenido de tipo numerico: No numerico, no cero,no en blanco o espacio
                /// </summary>
                /// <param name="value"></param>
                /// <param name="cultureInfo"></param>
                /// <returns>ValidationResult</returns>
                public ValidationResult ValidNumero(object value, System.Globalization.CultureInfo cultureInfo)
                {
                        if (!(Regex.IsMatch(value.ToString(), @"((0)+(\.[1-9](\d)?))|((0)+(\.(\d)[1-9]+))|(([1-9]+(0)?)+(\.\d+)?)|(([1-9]+(0)?)+(\.\d+)?)").Equals(true))){
                            return new ValidationResult(false, "Error Numerico en el contenido.");
                        }
                       
                        if (Convert.ToDouble(value) == 0){
                            return new ValidationResult(false, "Error Numerico en el contenido, valor no cero.");
                    
                        }
                        if (!this.ValidContenido(value, cultureInfo).IsValid) {
                            return new ValidationResult(false, "Error Numerico en el contenido, el valor no puede esta en blanco(vacio).");
                        }
                        return new ValidationResult(true, null);
                }

                /// <summary>
                /// Valida el contenido de tipo numerico: No numerico, no cero,no en blanco o espacio
                /// </summary>
                /// <param name="value"></param>
                /// <returns></returns>
                public ValidationResult ValidNumero(object value) {
                    return this.ValidNumero(value, System.Globalization.CultureInfo.InstalledUICulture);
                }

                public ValidationResult ValidContenido(object value, System.Globalization.CultureInfo cultureInfo)
                {
                    if ((value == null || value.ToString().Equals(string.Empty) || value.ToString().Length.Equals(0) || value.ToString().Trim().Length.Equals(0))){
                        return new ValidationResult(false, "Error de contenido, verifique la información");
                    }
                    else {
                        return new ValidationResult(true, null);
                    }
                }

                public ValidationResult ValidContenido(object value)
                {

                    if ((value == null || value.ToString().Equals(string.Empty) || value.ToString().Length.Equals(0) || value.ToString().Trim().Length.Equals(0))){
                        return new ValidationResult(false, "Error de contenido, verifique la información");
                    }
                    else{
                        return new ValidationResult(true, null);
                    }
                }

                //public bool EsValido(object value){
                //     return (value == null || value.ToString().Equals(string.Empty) || value.ToString().Length.Equals(0) || value.ToString().Trim().Length.Equals(0));
                //}
                //public bool Moneda(object value) {    
                //       if ((Regex.IsMatch(value.ToString(), @"((0)+(\.[1-9](\d)?))|((0)+(\.(\d)[1-9]+))|(([1-9]+(0)?)+(\.\d+)?)|(([1-9]+(0)?)+(\.\d+)?)").Equals(true) )){
                //       return false;
                //       }
                //       if ((double)value==0){
                //        return true;
                //       }
                //       return false;
                //}
                
            }
        }
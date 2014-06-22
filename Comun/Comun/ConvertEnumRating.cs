using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Empresa.Comun
{
   public class ConvertEnumRating:IValueConverter
   {
        //public enum EnumOpciones
        //{
        //   Primero = 1,
        //   Segundo = 2,
        //   Tercero = 3,
        //   Cuarto = 4,
        //   Quinto = 5
        //};

        public struct StOpciones {
            public bool Primero;
            public bool Segundo;
            public bool Tercero;
            public bool Cuarto;
            public bool Quinto;
        }

        public StOpciones Opciones;
        //public EnumOpciones Opciones { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            switch(value.ToString()) { 
                case "Primero":
                    Opciones.Segundo = false;
                    Opciones.Tercero = false;
                    Opciones.Cuarto = false;
                    Opciones.Quinto = false;

                    break;
                case "Segundo":
                    Opciones.Primero = true;
                    Opciones.Segundo = true;

                    Opciones.Tercero = false;
                    Opciones.Cuarto = false;
                    Opciones.Quinto = false;

                    break;
                case "Tercero":
                    Opciones.Primero = true;
                    Opciones.Segundo = true;
                    Opciones.Tercero = true;

                    Opciones.Cuarto = false;
                    Opciones.Quinto = false;

                    break;
                case "Cuarto":
                    Opciones.Primero = true;
                    Opciones.Segundo = true;
                    Opciones.Tercero = true;
                    Opciones.Cuarto = true;

                    Opciones.Quinto = false;
                    break;
                case "Quinto":
                    Opciones.Primero = true;
                    Opciones.Segundo = true;
                    Opciones.Tercero = true;
                    Opciones.Cuarto = true;
                    Opciones.Quinto = true;
                    break;
            }
            return Opciones;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

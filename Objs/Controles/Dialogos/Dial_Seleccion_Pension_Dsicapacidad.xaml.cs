using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for Dial_Seleccion_Pension_Dsicapacidad.xaml
    /// </summary>
    public partial class Dial_Seleccion_Pension_Dsicapacidad : Window
    {
        public enum SDSeleccion { 
            Solicitud,
            Busqueda,
            NULA
        }
        public SDSeleccion Seleccion { get; set; }

        public Dial_Seleccion_Pension_Dsicapacidad()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            // Solicitud 
            this.Seleccion = SDSeleccion.Solicitud;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Seleccion = SDSeleccion.Busqueda;
        }
    }
}

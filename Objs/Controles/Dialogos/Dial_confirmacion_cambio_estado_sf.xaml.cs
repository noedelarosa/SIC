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
    /// Interaction logic for Dial_confirmacion_cambio_estado_sf.xaml
    /// </summary>
    public partial class Dial_confirmacion_cambio_estado_sf : Window
    {
        public System.Windows.MessageBoxResult Resultado { get; set; }
        public Dial_confirmacion_cambio_estado_sf()
        {
            InitializeComponent();
            this.Resultado = MessageBoxResult.No;
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = MessageBoxResult.Yes;
            this.Hide();
        }

        private void But_No_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = MessageBoxResult.No;
            this.Hide();
        }
    }
}

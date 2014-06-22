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
    /// Interaction logic for Dial_DeseaNotificarFallecido.xaml
    /// </summary>
    public partial class Dial_DeseaNotificarFallecido : Window
    {
        public MessageBoxResult Resultado { get; set; }
        public bool EnviarNotificacionEmail { get; set; }
        public Dial_DeseaNotificarFallecido()
        {
            this.EnviarNotificacionEmail = true;
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

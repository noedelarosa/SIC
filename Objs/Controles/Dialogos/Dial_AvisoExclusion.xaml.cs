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
    /// Interaction logic for Dial_ExisteDocente.xaml
    /// </summary>
    public partial class Dial_AvisoExclusion : Window
    {
        public System.Windows.MessageBoxResult Resultado = new MessageBoxResult();

        public Dial_AvisoExclusion()
        {
            InitializeComponent();
        }

        private void But_Si_Click(object sender, RoutedEventArgs e)
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

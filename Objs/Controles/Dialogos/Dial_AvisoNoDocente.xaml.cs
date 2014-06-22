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
    /// Interaction logic for Dial_AvisoNoDocente.xaml
    /// </summary>
    public partial class Dial_AvisoNoDocente : Window
    {
        public Dial_AvisoNoDocente()
        {
            InitializeComponent();
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

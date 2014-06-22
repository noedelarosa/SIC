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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for wus_direccion.xaml
    /// </summary>
    public partial class wus_direccion : Window
    {
        public Empresa.Comun.TDireccion Direccion
        {
            get;
            set;
        }

        public wus_direccion(){
            InitializeComponent();
            
        }

        public wus_direccion(Empresa.Comun.TDireccion item){
            InitializeComponent();
            usc_direccion.Direccion = item;
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            //this.Direccion = usc_direccion.Direccionc;
            this.Close();
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Direccion = null;
            this.Close();
        }
    }
}

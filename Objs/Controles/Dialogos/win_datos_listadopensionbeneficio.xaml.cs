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
    /// Interaction logic for win_datos_listadopensionbeneficio.xaml
    /// </summary>
    public partial class win_datos_listadopensionbeneficio : Window
    {
        public Empresa.Docente.tlistadopensionadosenbeneficio Item { get; set; }
        public win_datos_listadopensionbeneficio(){
            this.Item = new Empresa.Docente.tlistadopensionadosenbeneficio();
            InitializeComponent();
        }
        private void But_Guardar_Click(object sender, RoutedEventArgs e){
            this.Hide();
        }
        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.Item = null;
            this.Hide();
        }

    }
}

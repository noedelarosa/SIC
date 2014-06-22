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
    /// Interaction logic for Win_Docente_Detalle.xaml
    /// </summary>
    public partial class Win_Docente_Detalle : Window
    {
        public Empresa.Docente.tdocente Docente { get; set; }

        public Win_Docente_Detalle(){
            InitializeComponent();
        }

        public Win_Docente_Detalle(Empresa.Docente.tdocente item){
            this.Docente = item;
            InitializeComponent();
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void But_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("No Acceso a la impresion de este documento", "Acceso Denegado", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}

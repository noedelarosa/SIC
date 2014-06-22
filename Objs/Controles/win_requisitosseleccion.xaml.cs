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
    /// Interaction logic for win_requisitosseleccion.xaml
    /// </summary>
    public partial class win_requisitosseleccion : Window {

        public Empresa.Docente.trequesitosasignados Requisito {get;set;}
        
        public win_requisitosseleccion(){
            InitializeComponent();
            Lis_Requisitos.ItemsSource =  Empresa.Docente.Requisitos.GetInstante().Lista;
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.Requisito = null;
            this.Close();
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            if (Lis_Requisitos.SelectedItem != null && Dp_Fecha.SelectedDate != null){
                this.Requisito = new Empresa.Docente.trequesitosasignados((Empresa.Docente.trequisitos)this.Lis_Requisitos.SelectedItem, true, Dp_Fecha.SelectedDate.Value, Txt_Espesificaciones.Text);
                this.Close();
            }
            else{
                MessageBox.Show("Faltan Datos, verifique.", "Faltan Datos", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

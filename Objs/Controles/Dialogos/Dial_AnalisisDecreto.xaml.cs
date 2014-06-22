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
using System.Collections.ObjectModel;
  
namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for Dial_AnalisisDecreto.xaml
    /// </summary>
    public partial class Dial_AnalisisDecreto : Window {
        public Empresa.Docente.TDecreto Decreto { get; set; }
        public ObservableCollection<Empresa.Docente.tdocente> Docentes { get; set; }


        public Empresa.Docente.DecretoAnalisis Analisis { get; set; }
        
        public Dial_AnalisisDecreto(){
            InitializeComponent();
        }

        public Dial_AnalisisDecreto(ObservableCollection<Empresa.Docente.tdocente> docentes, Empresa.Docente.TDecreto decreto){
            this.Decreto = decreto;
            this.Docentes = docentes;

            this.Analisis = new Empresa.Docente.DecretoAnalisis(docentes, decreto);
            
            InitializeComponent();
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.Close();
        }

        private void But_Imprimir_Click(object sender, RoutedEventArgs e){
            
            try {
                Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
                SIC.Objs.Docentes.Reportes.Xtra_AnalisisDecreto analisis = new Docentes.Reportes.Xtra_AnalisisDecreto();
                analisis.bindingSource1.DataSource = this.Analisis;
                vista.MostarReporte(analisis);
            }
            catch {
                MessageBox.Show("Error al imprimir el reporte", "Error Reporte", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

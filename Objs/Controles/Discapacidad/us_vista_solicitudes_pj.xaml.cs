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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for us_vista_solicitudes_pj.xaml
    /// </summary>
    public partial class us_vista_solicitudes_pj : UserControl{
        public event DInicio Abrir = delegate { };
        public event DInicio Nuevo = delegate { };
        public event DInicio Imprimir = delegate { }; 
        public Empresa.Docente.tdocente Docente {get; set;}
        
        public Empresa.Docente.tsolicitudpj SolicitudSelect
        {
            get {
                return (Empresa.Docente.tsolicitudpj)this.lis_solicitudes.SelectedItem;
            }
        }

        
        public us_vista_solicitudes_pj(){
            InitializeComponent();
        }

        public us_vista_solicitudes_pj(Empresa.Docente.tdocente docente){
            this.Docente = docente;
            InitializeComponent();
        }


        private void But_Abrir_Click(object sender, RoutedEventArgs e)
        {
            if(this.lis_solicitudes.SelectedItem != null){
                this.Abrir(this.lis_solicitudes.SelectedItem);
            }
        }

        private void But_Nuevo_Click(object sender, RoutedEventArgs e)
        {
           
            if (MessageBox.Show("Desea Agregar una nueva solicitud de Pensión Por Discapacidad. Si/No?", "Desea Agregar una nueva solicitud. Si/No?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                this.Nuevo(new Empresa.Docente.tsolicitudpj());
            }
            else {
                e = null;
            }

        }

        private void But_Imprimir_Click(object sender, RoutedEventArgs e){
            if(this.lis_solicitudes.SelectedItem != null){
                this.Imprimir(this.lis_solicitudes.SelectedItem);
            }
        }
    }
}

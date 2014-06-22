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
using System.ComponentModel;

namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for win_seleccion_requisitos_segurofunerario.xaml
    /// </summary>
    public partial class win_seleccion_requisitos_segurofunerario : Window, INotifyPropertyChanged
    {
        
        public Empresa.Docente.trequesitosasignados RequisitoSeleccionado {
            get {
                return (Empresa.Docente.trequesitosasignados)DataContext;
            }
            set {
                DataContext = value;
                this.EnCambio("RequisitoSeleccionado");
            }
        }
        
        /// <summary>
        /// Indica cuando el requisito es llenado debidamente y es aceptado(Pulsa el boton aceptar).
        /// </summary>
        public bool EsAceptado { get; set; }
        public bool EsModificacion { get; set; }

        public win_seleccion_requisitos_segurofunerario(){
            //Indica un nuevo requisito
            this.RequisitoSeleccionado = new Empresa.Docente.trequesitosasignados();

            InitializeComponent();
            //Inicializan los requisitos.
            this.Lis_Requisitos.ItemsSource = Empresa.Docente.RequisitosSeguroFunerario.GetInstante().Lista;
            
            //se establece en falso la aceptaacion del requisito por defecto.
            this.EsAceptado = false;
            this.EsModificacion = false;
        }

        public win_seleccion_requisitos_segurofunerario(Empresa.Docente.trequesitosasignados item){
            //Indica un nuevo requisito
            InitializeComponent();
            //Inicializan los requisitos.
            this.Lis_Requisitos.ItemsSource = Empresa.Docente.RequisitosSeguroFunerario.GetInstante().Lista;
            //se establece en falso la aceptaacion del requisito por defecto.
            this.EsAceptado = false;
            this.RequisitoSeleccionado = item;
            this.EsModificacion = true;
            Lis_Requisitos.IsEnabled = false;

        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){

            if (RequisitoSeleccionado.IsValid())
            {
                if (Lis_Requisitos.SelectedItem != null && Dp_Fecha.SelectedDate != null)
                {
                    this.EsAceptado = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Faltan Datos, verifique.", "Faltan Datos", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else {
                MessageBox.Show("Faltan Datos, verifique.", "Faltan Datos", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.EsAceptado = false;
            this.Close();
        }

        private void But_Scan_Click(object sender, RoutedEventArgs e){
            ScanEXP.Win_ScanArea scan = new ScanEXP.Win_ScanArea();
            scan.ShowDialog();

            if(scan.Imagen != null){

                if (this.RequisitoSeleccionado == null) this.RequisitoSeleccionado = new Empresa.Docente.trequesitosasignados();
                if(scan.Imagen != null){
                    this.RequisitoSeleccionado.AImagen = (BitmapSource)scan.DameImagen;
                }

            }
            scan.Close();
        }

        private void Lis_Requisitos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.RequisitoSeleccionado = null;
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void EnCambio(string nombre)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;
            if (manejador != null)
            {
                manejador(this, new PropertyChangedEventArgs(nombre));
            }

        }
    }
}

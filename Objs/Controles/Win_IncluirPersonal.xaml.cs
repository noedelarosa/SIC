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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for Win_IncluirPersonal.xaml
    /// </summary>
    public partial class Win_IncluirPersonal : Window, INotifyPropertyChanged
    {
        public bool EsValida = false;
        public Empresa.Docente.tdocente DocenteIncluido { get; set; }
        
        public Win_IncluirPersonal()
        {
            InitializeComponent();

            //Inicializando Fecha Actual.
            Txt_Fecha.Text = Empresa.Comun.Server.DameTiempo().ToShortDateString();

            //Iniciliazndo Variables. 
            this.DocenteIncluido = new Empresa.Docente.tdocente();
            this.DocenteIncluido.HistorialPagos = new Empresa.Docente.Pagos();
            this.DocenteIncluido.TrabajoLabora = new Empresa.Comun.TSuplidor();
            //
        }

        private void ERBuscarPersona_Limpiando(object e)
        {
            this.DocenteIncluido = new Empresa.Docente.tdocente();
            this.EnCambio("DocenteIncluido");
        }

        private void ERBuscarPersona_SeleccionItem(object e)
        {

            if (e != null) {
                if (((Empresa.RHH.tpersonal)e).Cedula != null) {
                    this.DocenteIncluido = (Empresa.RHH.tpersonal)e;

                    //this.DocenteIncluido = ((Empresa.RHH.tpersona)e);
                    this.grid_inicial.Visibility = System.Windows.Visibility.Collapsed;
                    this.EnCambio("DocenteIncluido");
                }
            }
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.EsValida = false;
            this.Hide();
        }

        private void But_OtraBusqueda_Click(object sender, RoutedEventArgs e)
        {
            this.EsValida = false;
            this.DocenteIncluido = new Empresa.Docente.tdocente();
            this.grid_inicial.Visibility = System.Windows.Visibility.Visible;
        }

        private void But_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try{
                this.DocenteIncluido.HistorialPagos = new Empresa.Docente.Pagos();
                this.DocenteIncluido.HistorialPagos.Lista.Add(new Empresa.Docente.TPago(Convert.ToDouble(Txt_Monto.Text),Empresa.Comun.Server.DameTiempo(), new Empresa.RHH.testadolaboral(3)));

                this.EsValida = true;
                this.Hide();
            }
            catch {
                MessageBox.Show("Verifique el monto del sueldo o el tiempo en servicio.", "Falta monto sueldo o tiempo servicio.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void EnCambio(string nombre)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;
            if (manejador != null){
                manejador(this, new PropertyChangedEventArgs(nombre));
            }
        }

        private void us_er_empresa_SeleccionItem(object e)
        {
            if (e != null) {
                if (((Empresa.Comun.TSuplidor)e).Id != 0) {
                    this.DocenteIncluido.TrabajoLabora = (Empresa.Comun.TSuplidor)e;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.us_buscarempresa.InicBusqueda();
        }

    }
}

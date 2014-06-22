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
    /// Interaction logic for win_direccion.xaml
    /// </summary>
    public partial class win_direccion : Window
    {
        public Empresa.Comun.TDireccionAsignada Direccion {
            get {
                return (Empresa.Comun.TDireccionAsignada)DataContext;
            }
            set {
                DataContext = value;
            }
        }

        private Empresa.Comun.TDireccionAsignada _origendireccion;

        public win_direccion(){
            InitializeComponent();
            //llenando provincias.
            com_provincia.ItemsSource = Empresa.Comun.Provincia.GetInstance();
            this.Direccion = new Empresa.Comun.TDireccionAsignada();
            this._origendireccion = this.Direccion;
        }

        public win_direccion(Empresa.Comun.TDireccionAsignada direccion){
            InitializeComponent();
            //llenando provincias.
            com_provincia.ItemsSource = Empresa.Comun.Provincia.GetInstance();
            this.Direccion = direccion;
            this._origendireccion = this.Direccion;
        }

        public win_direccion(Empresa.Docente.tdocente  docente){
            this.Direccion = docente.Direccion;
            InitializeComponent();
            //llenando provincias.
            com_provincia.ItemsSource = Empresa.Comun.Provincia.GetInstance();
            this._origendireccion = this.Direccion;
        }

        private void com_provincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (com_provincia != null){
                //this.Direccion = new Empresa.Comun.TDireccion();
                Binding bin = new Binding();
                bin.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                if (com_provincia.SelectedItem != null){
                    bin.Source = Empresa.Comun.Municipio.GetInstance().Source((Empresa.Comun.TProvincia)com_provincia.SelectedItem);    
                }
                else {
                    bin.Source = null;
                }
                com_municipio.SetBinding(ComboBox.ItemsSourceProperty, bin);
            }
        }

        private void com_municipio_SelectionChanged(object sender, SelectionChangedEventArgs e){
            if (com_municipio != null){
                Binding bin = new Binding();
                bin.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                if (com_municipio.SelectedItem != null){
                    bin.Source = Empresa.Comun.Sector.GetInstance().Source((Empresa.Comun.TMunicipio)com_municipio.SelectedItem);
                }
                else{
                    bin.Source = null;
                }
                com_sector.SetBinding(ComboBox.ItemsSourceProperty, bin);
            }

        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            this.Hide();
        }

        private void But_Cerrar_Click(object sender, RoutedEventArgs e){
            this.Direccion = this._origendireccion;
            this.Hide();
        }
    }
}

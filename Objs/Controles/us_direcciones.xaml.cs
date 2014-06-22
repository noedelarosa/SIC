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
using System.ComponentModel;

namespace SIC.Objs.Controles {
    /// <summary>
    /// Interaction logic for us_direcciones.xaml
    /// </summary>
	/// 
    public partial class us_direcciones : UserControl,INotifyPropertyChanged {
        
        public Empresa.Comun.Provincia Provincias {get; set;}
        public Empresa.Comun.Municipio Municipios {get;set;}
        public Empresa.Comun.Sector Sectors {get;set;}

        private static DependencyProperty _depen_direccion = DependencyProperty.Register("Direccion", typeof(Empresa.Comun.TDireccion), typeof(us_direcciones));
		public Empresa.Comun.TDireccion Direccion {
			get {
				return (Empresa.Comun.TDireccion)GetValue(_depen_direccion);
			}
            set {
				SetValue(_depen_direccion, value);
				this.EnCambio("Direccion");
			}
        }

        public us_direcciones(){
            this.Provincias = Empresa.Comun.Provincia.GetInstance();
            this.Municipios = Empresa.Comun.Municipio.GetInstance();
            this.Sectors = Empresa.Comun.Sector.GetInstance();
            this.Direccion = new Empresa.Comun.TDireccion();

            
            InitializeComponent();
        }

        public us_direcciones(Empresa.Comun.TDireccion item){
            this.Provincias = Empresa.Comun.Provincia.GetInstance();
            this.Municipios = Empresa.Comun.Municipio.GetInstance();
            this.Sectors = Empresa.Comun.Sector.GetInstance();
            
            this.Direccion = item;
            InitializeComponent(); 
        }

        private void Com_Sector_KeyDown(object sender, KeyEventArgs e){
            if(e.Key.Equals(Key.Enter)){
                Txt_Direccion.Focus();
            }
        }

        private void Com_Provincia_SelectionChanged(object sender, SelectionChangedEventArgs e){
            
            if (Com_Provincia != null){
                if (Com_Provincia.SelectedItem != null)
                {
                    Binding bin = new Binding();
                    bin.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    bin.Source = Municipios.Source((Empresa.Comun.TProvincia)Com_Provincia.SelectedItem);
                    
                    if (Com_Municipio != null) Com_Municipio.SetBinding(ComboBox.ItemsSourceProperty, bin);
                }
            }

        }

        private void Com_Municipio_SelectionChanged(object sender, SelectionChangedEventArgs e){
            //if (((ComboBox)sender).SelectedItem != null){
            //    Com_Sector.ItemsSource = sec.Source((Empresa.Comun.TMunicipio)((ComboBox)sender).SelectedItem);
            //}
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

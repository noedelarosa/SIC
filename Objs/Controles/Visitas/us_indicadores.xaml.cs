using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for us_indicadores.xaml
    /// </summary>
    public partial class us_indicadores : UserControl{

        public Empresa.Citas.Indicadores _indicadores;
        public Empresa.Citas.tindicadores Item { get; set; }


        public void NewItem(){
            Item = new Empresa.Citas.tindicadores();
        }

        
        public void Saved(){

            
        
        }


        public us_indicadores(){
            _indicadores = Empresa.Citas.Indicadores.GetInstance();
            Item = new Empresa.Citas.tindicadores();

            InitializeComponent();
            this.DataContext = _indicadores.Lista;
        }

        private void But_Refresh_Click(object sender, RoutedEventArgs e){
            try{
                this._indicadores.Insert(this.Item);
                this.DataContext = _indicadores.Recarga().Lista; 
            }
            catch {
                MessageBox.Show("Error al ingresar el Indicador.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}

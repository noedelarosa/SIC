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
    /// Interaction logic for Dial_empresasrecurrentes_01.xaml
    /// </summary>
    public partial class Dial_empresasrecurrentes_01 : Window
    {
        private string Aquienpueda = "A QUIEN PUEDA INTERESAR";

        public Empresa.Comun.TSuplidor Suplidor {get;set;}
        private void _incializandoquienpuedainteresar() {
            this.Suplidor = new Empresa.Comun.TSuplidor(Aquienpueda, string.Empty, new Empresa.Comun.TDireccion());
            this.Suplidor.Id = -1;
        
        }
        public Dial_empresasrecurrentes_01(){
            InitializeComponent();

            this._incializandoquienpuedainteresar();
            this.lis_suple.ItemsSource = new Empresa.Comun.SuplidorRecurrente(new Empresa.Comun.TEstandar(1)).Lista;
        }

        
        private void but_Cancelar_Click(object sender, RoutedEventArgs e){
            this.Suplidor = null;
            this.Hide();
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)ch_quienpueda.IsChecked){
                this._incializandoquienpuedainteresar();  
            }
            this.Hide();
        }

        private void ERSuplidormini_SeleccionItem(object e){
            this.Suplidor = (Empresa.Comun.TSuplidor)e;
        }

        private void lis_suple_MouseDoubleClick(object sender, MouseButtonEventArgs e){
            if(this.lis_suple.SelectedItem != null){

                this.Suplidor = (Empresa.Comun.TSuplidor)this.lis_suple.SelectedItem;
                this.Hide();

            }
        }

        private void ch_quienpueda_Click(object sender, RoutedEventArgs e){
            this.er_suplidor.IsEnabled = !((CheckBox)sender).IsChecked.Value;
        }
    }
}

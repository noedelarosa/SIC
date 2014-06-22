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

namespace Empresa.Comun.Controls
{
    /// <summary>
    /// Interaction logic for DateTimePlus.xaml
    /// </summary>
    public partial class DateTimePlus : UserControl
    {
        public DateTimePlus(){
            InitializeComponent();
        }

        private void com_hora_TextInput(object sender, TextCompositionEventArgs e){
            var r = e.Text;
        }

        private bool EsNumeroPermitido(Key tecla){
            if(tecla == Key.Delete || tecla == Key.Back) return false;
            return !((tecla >= Key.D0 && tecla <= Key.D9) || (tecla >= Key.NumPad0 && tecla <= Key.NumPad9));
        }

        private bool IsHoraPermitido(string arg)
        {
            int resul=0;
            int.TryParse(arg,out resul);
            return !(resul <= 12);
        }

        private void com_hora_PreviewKeyDown(object sender, KeyEventArgs e){
            
            e.Handled = this.EsNumeroPermitido(e.Key);

        }

        private void com_hora_PreviewKeyUp(object sender, KeyEventArgs e){
            //if (!e.Handled) e.Handled = this.IsHoraPermitido((e.Source as ComboBox).Text);
        }

    }
}

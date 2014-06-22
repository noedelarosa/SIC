using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manager
{
    /// <summary>
    /// Interaction logic for Win_ReentrarClave.xaml
    /// </summary>
    public partial class Win_ReentrarClave : Window
    {
        public bool EsValido = false;
        private string argmento;
        public Win_ReentrarClave(string arg){
            InitializeComponent();
            this.argmento = arg;
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            if (this.argmento.Equals(Txt_Clave.Password)) {
                this.EsValido = true;
            }
            else{
                this.EsValido = false;
                MessageBox.Show("Las Claves suplidas no coinciden, intente de nuevo", "Claves no coinciden", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.Hide();
        }
    }
}

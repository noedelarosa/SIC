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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for EditText.xaml
    /// </summary>
    public partial class EditText : Window
    {

        public string Titulo;
        public string Detalle {
            get { return Txt_Detalle.Text; }
            set { Txt_Detalle.Text = value; } 
        }

        public EditText(string titulo){
            InitializeComponent();
            this.Titulo = titulo;
            this.Title = this.Titulo;
            this.Txt_CabezaDetalle.Text = "Detalle(s), " + this.Titulo;
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
    /// Interaction logic for wus_contacto.xaml
    /// </summary>
    public partial class wus_contacto : Window
    {
        public Empresa.Comun.tcontacto Contacto { get; set; }
        
        public wus_contacto(){
            InitializeComponent();
        }

        public wus_contacto(Empresa.Comun.tcontacto item)
        {
            InitializeComponent();
            this.usc_contacto.Contacto = item;
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Contacto = null;
            this.Close();
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            
            this.Contacto = usc_contacto.Contacto;
            this.Close();
        }
    }
}

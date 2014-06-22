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
    /// Interaction logic for win_MantenimientoContactoDireccion.xaml
    /// </summary>
    public partial class win_MantenimientoContactoDireccion : Window
    {
        public Empresa.Comun.tcontacto Contacto { get; set; }
        public Empresa.Comun.TDireccion Direccion { get; set; }

        public win_MantenimientoContactoDireccion(){
            InitializeComponent();
            this.Contacto = new Empresa.Comun.tcontacto();
            this.Direccion = new Empresa.Comun.TDireccion();
        }

        public win_MantenimientoContactoDireccion(Empresa.Comun.tcontacto contacto, Empresa.Comun.TDireccion direccion)
        {
            InitializeComponent();
            this.Contacto = contacto;
            this.Direccion = direccion;
        }

        public win_MantenimientoContactoDireccion(Empresa.Comun.EnlaceContacto items){
            InitializeComponent();
            this.Contacto = items.Contacto;
            this.Direccion = items.Direccion;
            
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.Close();
        }

    }
}

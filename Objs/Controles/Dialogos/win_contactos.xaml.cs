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
    /// Interaction logic for win_contactos.xaml
    /// </summary>
    public partial class win_contactos : Window{

        public Empresa.Comun.tcontacto Contacto {
            get { return (Empresa.Comun.tcontacto)DataContext; }
            set { DataContext = value; } 
        }

        private Empresa.Comun.tcontacto _contactoorigen;

        public win_contactos(){
            InitializeComponent();
            this.Contacto = new Empresa.Comun.tcontacto();
            this._contactoorigen = this.Contacto;
        }

        public win_contactos(Empresa.Docente.tdocente docente) {
            InitializeComponent();
            this.Contacto = docente.Contacto;

            this._contactoorigen = this.Contacto;
        }

        public win_contactos(Empresa.Comun.tcontacto  contacto){
            InitializeComponent();
            this.Contacto = contacto;

            this._contactoorigen = this.Contacto;
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            this.Hide();
        }

        private void But_Cerrar_Click(object sender, RoutedEventArgs e){
            this.Contacto = this._contactoorigen;
            this.Hide();
        }

    }
}

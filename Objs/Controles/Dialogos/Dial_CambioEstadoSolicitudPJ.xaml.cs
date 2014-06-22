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
    /// Interaction logic for Dial_CambioEstadoSolicitudPJ.xaml
    /// </summary>
    public partial class Dial_CambioEstadoSolicitudPJ : Window
    {
        public Empresa.Docente.testadossolicitudpj Estado { get; set; }
        //public DateTime FechaActual {get;set;} 

        public Dial_CambioEstadoSolicitudPJ(){
            this.Estado = new Empresa.Docente.testadossolicitudpj();
            
            InitializeComponent();
        }

        public Dial_CambioEstadoSolicitudPJ(Empresa.Docente.testadossolicitudpj item){
            this.Estado = item;
            this.Estado.Fecha = Empresa.Comun.Server.DameTiempo();
            InitializeComponent();
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            //Re nueva la fecha para satisfaccer el lapson de tiempo.
            this.Estado.Fecha = Empresa.Comun.Server.DameTiempo();
            this.Hide();
        }

        private void But_Cerrar_Click(object sender, RoutedEventArgs e){
            this.Estado = null;
            this.Hide();
        }
    }
}

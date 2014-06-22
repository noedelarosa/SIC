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
    /// Interaction logic for Dial_confirmacion_AprobacionSeguroFunerario.xaml
    /// </summary>
    public partial class Dial_confirmacion_AprobacionSeguroFunerario : Window
    {
        public System.Windows.MessageBoxResult Resultado { get; set; }
        private Empresa.Docente.tsolicitudfunenario _solicitud;
        public Dial_confirmacion_AprobacionSeguroFunerario(){
            InitializeComponent();
            this.Resultado = MessageBoxResult.No;
        }

        public Dial_confirmacion_AprobacionSeguroFunerario(Empresa.Docente.tsolicitudfunenario item)
        {
            InitializeComponent();
            this._solicitud = item;
            this.Resultado = MessageBoxResult.No;

            //Aplicando mensaje. 
            this.txb_mensaje.Text = "Desea Aprobar la siguiente solicitud con el MONTO DE: " + item.Monto.ToString() + " , Si/no?";
        }

        private void But_Si_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = MessageBoxResult.Yes;
            this.Hide();
        }

        private void But_No_Click(object sender, RoutedEventArgs e)
        {
            this.Resultado = MessageBoxResult.No;
            this.Hide();
        }
    }
}

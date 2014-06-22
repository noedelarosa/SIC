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
    /// Interaction logic for Dial_SeleccionPagina_01.xaml
    /// </summary>
    public partial class Dial_SeleccionPagina_01 : Window
    {
        public enum ESeleccion{
            LimiteEdad,
            ProyeccionExclucion,
            NotificacionExclucion,
            Excluidos,
            NoDefinido,
            BusquedaBeneficiario
        };
        public ESeleccion Seleccion { get; set; }
        
        public Dial_SeleccionPagina_01()
        {
            InitializeComponent();
            this.Seleccion = ESeleccion.NoDefinido; 
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            //Limite Edad;
            this.Seleccion = ESeleccion.LimiteEdad;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Seleccion = ESeleccion.ProyeccionExclucion;
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.Seleccion = ESeleccion.NoDefinido;
            this.Hide();
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            But_Salir_Click(null, null);
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            this.Seleccion = ESeleccion.NotificacionExclucion;
        }

        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {
            //Listado Excluidos.
            this.Seleccion = ESeleccion.Excluidos;
        }

        private void RadioButton_Click_4(object sender, RoutedEventArgs e)
        {
            this.Seleccion = ESeleccion.BusquedaBeneficiario;
        }
    }
}

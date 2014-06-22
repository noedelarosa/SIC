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

namespace SIC.Objs.Controles.SeguroFunerario.Asistentes
{
    /// <summary>
    /// Interaction logic for win_dial_sel_estadistica_sf.xaml
    /// </summary>
    public partial class win_dial_sel_estadistica_sf : Window
    {
        public bool EsValido = false;
        public enum enum_eje_depe{
            Monto =1,
            Fecha =2
        }
        public enum enum_eje_inde
        {
            Estado      =1,
            EstadoPago  =2,
            Parentesco  =3,
            Monto       =4
        }

        public enum_eje_depe SeleccionDependiente   { get; set; }
        public enum_eje_inde SeleccionIndependiente { get; set; }

        public win_dial_sel_estadistica_sf(){
            InitializeComponent();
            this.EsValido = false;
        }

        private void ch_monto_Click(object sender, RoutedEventArgs e){
            this.SeleccionDependiente = enum_eje_depe.Monto;
        }
        private void ch_fecha_Click(object sender, RoutedEventArgs e){
            this.SeleccionDependiente = enum_eje_depe.Fecha;
        }
        private void ch_estadopago_Click(object sender, RoutedEventArgs e){
            this.SeleccionIndependiente = enum_eje_inde.EstadoPago;
        }
        private void ch_parentesco_Click(object sender, RoutedEventArgs e){
            this.SeleccionIndependiente = enum_eje_inde.Parentesco;
        }
        private void ch_estado_Click(object sender, RoutedEventArgs e){
            this.SeleccionIndependiente = enum_eje_inde.Estado;
        }
        private void ch_Monto_Independiente_Click(object sender, RoutedEventArgs e)
        {
            this.SeleccionIndependiente = enum_eje_inde.Monto;
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            try{
                this.EsValido = true;
                this.Hide();
            }
            catch {

            }
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            try{
                this.EsValido = false;
                this.Hide();
            }
            catch {

            }
        }

        

    }
}

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
    /// Interaction logic for seleccion_impresion_cambio_estado_sf.xaml
    /// </summary>
    public partial class seleccion_impresion_cambio_estado_sf : Window
    {

        public enum enum_seleccion_impresion_cambio_estado_sf { 
            resumen =1,
            listado =2,
            nada =3
        }
        public bool EsValido;
        public enum_seleccion_impresion_cambio_estado_sf Seleccion;

        public seleccion_impresion_cambio_estado_sf()
        {
            InitializeComponent();
            this.Seleccion = enum_seleccion_impresion_cambio_estado_sf.nada;
            this.EsValido = false;
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.EsValido = true;
                this.Hide();
            }
            catch { 
            
            }
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Seleccion = enum_seleccion_impresion_cambio_estado_sf.nada;
            this.EsValido = false;
            this.Hide();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Seleccion = enum_seleccion_impresion_cambio_estado_sf.resumen;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.Seleccion = enum_seleccion_impresion_cambio_estado_sf.listado;
        }
    }
}

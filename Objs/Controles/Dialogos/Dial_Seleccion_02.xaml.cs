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
    /// Interaction logic for Dial_Seleccion_02.xaml
    /// </summary>
    public partial class Dial_Seleccion_02 : Window
    {

        public enum EnumSeleccionTipoReporteDocente
        {
            Basico = 1,
            Certificacion = 2,
            Nula =3
        };

        public EnumSeleccionTipoReporteDocente Seleccion { get; set; }

        public Dial_Seleccion_02()
        {
            InitializeComponent();
        }

        private void But_Si_Click(object sender, RoutedEventArgs e){
            this.Hide();
        }

        private void But_No_Click(object sender, RoutedEventArgs e)
        {
            this.Seleccion = EnumSeleccionTipoReporteDocente.Nula;
            this.Hide();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e){
            //Certificacion
            Seleccion = EnumSeleccionTipoReporteDocente.Certificacion;

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e){
            //Datos Basicos
            Seleccion = EnumSeleccionTipoReporteDocente.Basico;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {

        }
    }
}

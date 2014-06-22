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
    /// Interaction logic for Dial_ReporteDatosFellecidos.xaml
    /// </summary>
    public partial class Dial_ReporteDatosFellecidos : Window
    {
        public bool EsValido = false;

        public bool IncluirDetalle {
            get {
                return ch_Incluir.IsChecked.Value;
            }
        }

        public enum EnumSeleccionTipoReporteFallecimiento{
            Nada = 0,
            Basico = 1,
            BasicoFallecimiento = 2,
            SeguroFunerario =3,
            PostActivo =4
        };

        public EnumSeleccionTipoReporteFallecimiento Seleccion { get; set; }

        public Dial_ReporteDatosFellecidos(){
            InitializeComponent();
            Seleccion = EnumSeleccionTipoReporteFallecimiento.Nada;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e){
            //Basico
            this.Seleccion = EnumSeleccionTipoReporteFallecimiento.Basico;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e){
            // Basico + Fallecimiento
            this.Seleccion = EnumSeleccionTipoReporteFallecimiento.BasicoFallecimiento;
        }

        private void But_Si_Click(object sender, RoutedEventArgs e){
            //Aceptar
            this.EsValido = true;
            this.Hide();
        }

        private void But_No_Click(object sender, RoutedEventArgs e){
            this.EsValido = false;
            Seleccion = EnumSeleccionTipoReporteFallecimiento.Nada;
            // Cancelar
            this.Hide();
        }

        private void ch_Seguro_Funerario_Checked(object sender, RoutedEventArgs e){
            Seleccion = EnumSeleccionTipoReporteFallecimiento.SeguroFunerario;
        }

        private void ch_postactivo_Checked(object sender, RoutedEventArgs e){
            Seleccion = EnumSeleccionTipoReporteFallecimiento.PostActivo;
        }
    }
}

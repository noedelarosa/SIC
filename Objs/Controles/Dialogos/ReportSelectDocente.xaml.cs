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
    /// Interaction logic for ReportSelectDocente.xaml
    /// </summary>
    public partial class ReportSelectDocente : Window
    {
        public enum ESelecion { 
             Solicitud,
             Paso,
             Beneficios     
        }

        public Empresa.Docente.tdocente Docente { get; set; }
        public Empresa.Docente.tsolicitudpj Solicitud { get; set; }

        public ESelecion Seleccion { get; set; }

        public ReportSelectDocente(){
            InitializeComponent();
        }

        public ReportSelectDocente(Empresa.Docente.tdocente docente){
            InitializeComponent();
            this.Docente = docente;
        }

        public ReportSelectDocente(Empresa.Docente.tsolicitudpj solicitud){
            InitializeComponent(); 
            this.Solicitud = solicitud;
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.Close();
        }

        private void Presentacion(ESelecion seleccion){
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            switch (seleccion){ 
                case ESelecion.Solicitud:
                    
                        SIC.Objs.Docentes.Reportes.Xtra_DocenteSolicitudPJ ex = new Objs.Docentes.Reportes.Xtra_DocenteSolicitudPJ();
                        ex.bindingSource1.DataSource = this.Solicitud;
                        vista.MostarReporte(ex);

                        break;
                case ESelecion.Paso:

                        SIC.Objs.Docentes.Reportes.Xtra_DocentePaso ex2 = new Docentes.Reportes.Xtra_DocentePaso();
                        ex2.bindingSource1.DataSource = this.Solicitud;
                        vista.MostarReporte(ex2);

                    break;
                case ESelecion.Beneficios:

                    SIC.Objs.Docentes.Reportes.Xtra_DocentePesionDiscap_Beneficio ex3 = new Docentes.Reportes.Xtra_DocentePesionDiscap_Beneficio();
                    ex3.Parameters[0].Value = this.Solicitud.Docente.HistorialPagos.PromedioMI;
                    ex3.bindingSource1.DataSource = this.Solicitud;
                    vista.MostarReporte(ex3);

                    break;
            }
        }

        private void But_Ver_Click(object sender, RoutedEventArgs e){
            try{
                this.Presentacion(this.Seleccion);
                this.Close();
            }
            catch (Exception ex){ }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //solicitud
            this.Seleccion = ESelecion.Solicitud;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            //
            this.Seleccion = ESelecion.Paso;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Seleccion = ESelecion.Beneficios;
        }
    }
}

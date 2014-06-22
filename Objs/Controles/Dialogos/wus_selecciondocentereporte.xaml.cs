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
    /// Interaction logic for wus_selecciondocentereporte.xaml
    /// </summary>
    public partial class wus_selecciondocentereporte : Window
    {
        Empresa.Docente.tdocente Docente;
        public enum ESelecion
        {
            FamiliasBeneficiarios,
            PlanFunerario,
            SueldosPostumes,
            RetroActivo,
            Comentario
        }

        public ESelecion Seleccion { get; set; }


        public wus_selecciondocentereporte(){
            InitializeComponent();
        }

        public wus_selecciondocentereporte(Empresa.Docente.tdocente docente){
            InitializeComponent();
            this.Docente = docente;
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.Close();
        }

        private void Presentacion(ESelecion seleccion)
        {
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            switch (seleccion)
            {
                case ESelecion.FamiliasBeneficiarios:
                    SIC.Objs.Docentes.Reportes.Xtra_DocenteDependientes ex = new Objs.Docentes.Reportes.Xtra_DocenteDependientes();
                    ex.bindingSource3.DataSource = this.Docente;
                    vista.MostarReporte(ex);
                    break;
                case ESelecion.PlanFunerario:
                    SIC.Objs.Docentes.Reportes.Xtra_DocenteBenPlanf ex2 = new Docentes.Reportes.Xtra_DocenteBenPlanf();
                    ex2.bindingSource1.DataSource = this.Docente;
                    vista.MostarReporte(ex2);
                    break;
                case ESelecion.SueldosPostumes:
                    SIC.Objs.Docentes.Reportes.Xtra_PostActivo ex3 = new Docentes.Reportes.Xtra_PostActivo();
                    ex3.bindingSource1.DataSource = this.Docente;
                    vista.MostarReporte(ex3);
                    break;
                case ESelecion.RetroActivo:
                    SIC.Objs.Docentes.Reportes.Xtra_RetroActivo ex4 = new Docentes.Reportes.Xtra_RetroActivo();
                    ex4.bindingSource1.DataSource = this.Docente;
                    vista.MostarReporte(ex4);
                    break;
                case ESelecion.Comentario:
                    SIC.Objs.Docentes.Reportes.Xtra_ComentarioDocente ex5 = new Docentes.Reportes.Xtra_ComentarioDocente();
                    ex5.bindingSource1.DataSource = this.Docente;
                    vista.MostarReporte(ex5);
                    break;
            }
        }


        private void But_Ver_Click(object sender, RoutedEventArgs e)
        {
            try {
                this.Presentacion(this.Seleccion);
                this.Close();
            }
            catch{
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e){
            //familiares
            this.Seleccion = ESelecion.FamiliasBeneficiarios;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e){
           this.Seleccion = ESelecion.PlanFunerario;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.Seleccion = ESelecion.SueldosPostumes;
        }

        private void rb_rectroactivo_Checked(object sender, RoutedEventArgs e){
            this.Seleccion = ESelecion.RetroActivo;
        }

        private void rb_comentario_Checked(object sender, RoutedEventArgs e){
            this.Seleccion = ESelecion.Comentario;
        }
    }
}

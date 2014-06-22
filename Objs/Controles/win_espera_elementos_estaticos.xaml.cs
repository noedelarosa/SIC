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
    /// Interaction logic for win_espera_elementos_estaticos.xaml
    /// </summary>
    public partial class win_espera_elementos_estaticos : Window
    {

       // public bool DeboCerrar;

        //private void cargarelementos() {
            
        //    Empresa.Docente.Decreto.GetInstnace();
        //  //  this.pro_carga.Value += 6;
          
        //    //this.OnRender();

        //    Empresa.Docente.EstadoBeneficio.GetInstance();
        //   // this.pro_carga.Value += 6;
        //    Empresa.Docente.EstadoDecreto.GetInstance();
        //  //  this.pro_carga.Value += 6;
        //    Empresa.Docente.EstadoPJ.GetInstance();
        //   // this.pro_carga.Value += 6;
        //    Empresa.Docente.GrupoTiempos.GetInstance();
        //   // this.pro_carga.Value += 6;
        //    Empresa.Docente.GrupoTiempoSeguroFunerario.GetInstance();
        //   // this.pro_carga.Value += 6;
        //    Empresa.Docente.IngresoDescuento.GetInstance();
        //   // this.pro_carga.Value += 6;
        //    Empresa.Docente.OrigenBeneficio.GetInstance();
        //    //this.pro_carga.Value += 6;
        //    Empresa.Docente.Presidentes.GetInstance();
        //   // this.pro_carga.Value += 6;
        //    Empresa.Docente.Requisitos.GetInstante();
        //  //  this.pro_carga.Value += 6;
        //    Empresa.Docente.RequisitosSeguroFunerario.GetInstante();
        //  //  this.pro_carga.Value += 6;
        //    Empresa.Docente.SeguroFunerarioEstado.GetInstance();
        //  //  this.pro_carga.Value += 6;
        //    Empresa.Docente.TipoDocente.GetInstance();
        //  //  this.pro_carga.Value += 6;
        //    //Empresa.Docente.TipoDocumento.GetInstance();
        //  //  this.pro_carga.Value += 6;
        //    Empresa.Docente.TipoSolicitante.GetInstance();

        //    SIC.Objs.Docentes.Reportes.Xtra_AnalisisDecreto r = new Docentes.Reportes.Xtra_AnalisisDecreto();
        //    Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
        //    vista.CargaReporte(r); 
           
           
        //  //  this.pro_carga.Value = 100;
        //    this.Hide();
        //}

        public win_espera_elementos_estaticos()
        {
            InitializeComponent();
           
        }

        //public void InicializarCarga() {
        //    this.Show();
        //    System.Threading.Thread.SpinWait(100);
        //    this.cargarelementos();
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

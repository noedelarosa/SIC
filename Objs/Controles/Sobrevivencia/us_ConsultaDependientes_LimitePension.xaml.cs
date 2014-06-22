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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for us_ConsultaDependientes_LimitePension.xaml
    /// </summary>
    public partial class us_ConsultaDependientes_LimitePension : UserControl, Empresa.Comun.IFirma{
        private BackgroundWorker bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera Espera = new Dialogos.Dial_Espera();
       
        public us_ConsultaDependientes_LimitePension(){
            InitializeComponent();
            this.Com_Parentesco.ItemsSource = new Empresa.Comun.Parentesco();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e) {

            object[] valores = (object[])e.Argument;
            object ano = Convert.ToInt32(valores[0]);
            object mes = valores[1];
            Empresa.Comun.TParentesco parentesco = (Empresa.Comun.TParentesco)valores[2];

            Empresa.Docente.Docentes docs = new Empresa.Docente.Docentes();
            //e.Result = docs.GetItem(true);

            if(string.IsNullOrEmpty(mes.ToString())){
                e.Result = docs.GetItem(Convert.ToInt32(ano), parentesco);
            }
            else
            {
                if (Convert.ToInt32(mes) <= 0)
                {
                    e.Result = docs.GetItem(Convert.ToInt32(ano), parentesco);
                }
                else
                {
                    e.Result = docs.GetItem(Convert.ToInt32(ano), Convert.ToInt32(mes), parentesco);
                }
            }


        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            this.DataContext = e.Result;
            this.Espera.Hide();
        }

        private void But_Aplicar_Click(object sender, RoutedEventArgs e){
            if (!string.IsNullOrEmpty(Txt_Ano.Text)){
                this.Espera.Show();
                try{
                    if (Com_Parentesco.SelectedItem != null){
                        bw.RunWorkerAsync(new object[3] { Txt_Ano.Text, Txt_Mes.Text, Com_Parentesco.SelectedItem });
                    }
                    else {
                        this.Espera.Hide();
                    }
                }catch{
                this.Espera.Hide();
                } 
            }
            else {
                MessageBox.Show("Debe Introducir el Año para iniciar la busqueda.", "Falta Año", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e){
            this.bw.Dispose();
            this.Espera.Close();
        }

        public void Print() {
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            var r = ((Xceed.Wpf.DataGrid.DataGridCollectionViewBase)this.datagrid1.Items.SourceCollection).SourceCollection;
            SIC.Objs.Docentes.Reportes.Xtra_Proyeccion proyec = new Docentes.Reportes.Xtra_Proyeccion();
            
            //Ingresando para metros
            proyec.Parameters[0].Value = Txt_Ano.Text;
            proyec.Parameters[0].Visible = false;

            proyec.Parameters[1].Value = Txt_Mes.Text;
            proyec.Parameters[1].Visible = false;
            
            proyec.Parameters[2].Value = Com_Parentesco.Text;
            proyec.Parameters[2].Visible = false;

            proyec.bindingSource1.DataSource = r;
            vista.MostarReporte(proyec);
        }

        private void But_Exclucion_Click(object sender, RoutedEventArgs e){
            if (MessageBox.Show("Desea Excluir el siguiente Beneficiario, Si/No", "Desea Excluir, Si/No", MessageBoxButton.OK, MessageBoxImage.Question)== MessageBoxResult.Yes) {
                MessageBox.Show("Función no disponible", "Función no disponible");
            }
        }


        public string CModulo
        {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto
        {
            get { return "__doco___000laKjaLL_"; }
        }

        public string Descripcion
        {
            get { throw new NotImplementedException(); }
        }

        public string Modulo
        {
            get { return "Docente"; }
        }

        public string Nombre
        {
            get { return "Consulta Dependiente Limite Pension"; }
        }

        public string objecto
        {
            get { return "ConsultaDependienteLimitePension"; }
        }

    }
}

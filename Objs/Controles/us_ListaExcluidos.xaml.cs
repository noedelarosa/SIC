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
    /// Interaction logic for us_ListaExcluidos.xaml
    /// </summary>
    public partial class us_ListaExcluidos : UserControl
    {

        private BackgroundWorker _bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera _espera = new Dialogos.Dial_Espera();
        private SIC.Objs.Controles.Dialogos.Dial_AvisoExclusion _avisoexcluir = new SIC.Objs.Controles.Dialogos.Dial_AvisoExclusion();

        public us_ListaExcluidos(){
            InitializeComponent();

            _bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e){
            Empresa.Docente.Docentes docs = new Empresa.Docente.Docentes();

            e.Result = docs.GetItem(new Empresa.Comun.TEstandar(2));
        }

        public void Print(){
            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();

            var r = ((Xceed.Wpf.DataGrid.DataGridCollectionViewBase)this.datagrid1.Items.SourceCollection).SourceCollection;
            SIC.Objs.Docentes.Reportes.Xtra_ListadoExcluidos proyec = new Docentes.Reportes.Xtra_ListadoExcluidos();

            //Ingresando para metros
            proyec.Parameters[0].Value = "";
            proyec.Parameters[0].Visible = false;

            proyec.Parameters[1].Value = "";
            proyec.Parameters[1].Visible = false;

            proyec.Parameters[2].Value = "";
            proyec.Parameters[2].Visible = false;

            proyec.bindingSource1.DataSource = r;
            vista.MostarReporte(proyec);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DataContext = e.Result;
            this._espera.Hide();
            var r = datagrid1.CurrentContext.Items.Count;
        }


        private void But_Inclusion_Click(object sender, RoutedEventArgs e){


        }

        private void But_Editar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Empresa.Docente.TFamiliares familiar = (Empresa.Docente.TFamiliares)datagrid1.CurrentContext.CurrentItem;
                if (familiar != null){
                    SIC.Objs.Controles.win_AgregarPersona editar = new win_AgregarPersona(familiar);
                    editar.ShowDialog();

                    if (editar.Familiar != null){
                        ((Empresa.Docente.tdocente)datagrid1.CurrentContext.ParentItem).Familiares.Update(editar.Familiar);
                        But_Refresh_Click(null, null);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al Actulizar los Datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void But_Refresh_Click(object sender, RoutedEventArgs e){
            try{
                _bw.RunWorkerAsync();
                this._espera.ShowDialog();
            }
            catch{
                this._espera.Hide();
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e){
            this._bw.Dispose();
            this._espera.Close();
        }


    }
}

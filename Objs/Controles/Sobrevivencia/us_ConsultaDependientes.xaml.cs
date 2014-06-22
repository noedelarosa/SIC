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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for us_ConsultaDependientes.xaml
    /// </summary>
    public partial class us_ConsultaDependientes : UserControl, Empresa.Comun.IFirma {
        private Empresa.Docente.Familiares Familiares;
        private BackgroundWorker bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera Espera = new Dialogos.Dial_Espera();

        public us_ConsultaDependientes(){
            InitializeComponent();
            this.com_parentesco.ItemsSource = new Empresa.Comun.Parentesco();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

        }

        private void filtro(int AnoIni, int AnoFin,bool DocumentoEstudio, Empresa.Comun.TParentesco Parentesco){
            if(this.Familiares != null){
                ObservableCollection<Empresa.Docente.TFamiliares> items = Familiares.GetItem(AnoIni, AnoFin, DocumentoEstudio, Parentesco);
                this.DataContext = items;
            }
        }

        private void But_Buscar_Click(object sender, RoutedEventArgs e){
            if (string.IsNullOrEmpty(Txt_FInicio.Text)) Txt_FInicio.Text = "0";
            if (com_parentesco.SelectedItem != null && !string.IsNullOrEmpty(Txt_FInicio.Text)){
                Espera.Show();
                try{
                    bw.RunWorkerAsync();
                }
                catch (Exception ex){
                    Espera.Hide();
                }
            }
            else {
                MessageBox.Show("Verifique que tenga un Parentesco seleccionado y una edad de inicio", "Falta Parentesco o edad inicio", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e){
            e.Result = new Empresa.Docente.Familiares(Empresa.Comun.Server.DameTiempo(), 17, 60);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            this.Familiares = (Empresa.Docente.Familiares)e.Result;
            this.filtro(Convert.ToInt32(Txt_FInicio.Text), Convert.ToInt32(Txt_FFinal.Text), ch_documentospresente.IsChecked.Value, (Empresa.Comun.TParentesco)com_parentesco.SelectedItem);
            Espera.Hide();
        }


        private void ch_documentospresente_Click(object sender, RoutedEventArgs e){
            CheckBox control = sender as CheckBox;
            this.filtro(Convert.ToInt32(Txt_FInicio.Text), Convert.ToInt32(Txt_FFinal.Text), ch_documentospresente.IsChecked.Value, (Empresa.Comun.TParentesco)com_parentesco.SelectedItem);
        }

        public void Print() {
            ObservableCollection<Empresa.Docente.TFamiliares> items = (ObservableCollection<Empresa.Docente.TFamiliares>)((Xceed.Wpf.DataGrid.DataGridCollectionView)datagrid12.ItemsSource).SourceCollection;

            Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
            SIC.Objs.Docentes.Reportes.Xtra_LimiteEdad rep = new Docentes.Reportes.Xtra_LimiteEdad();
            rep.bindingSource1.DataSource = items;
            
            foreach(Empresa.Docente.TFamiliares fitem in items){
                try {
                    fitem.Docente = new Empresa.Docente.DocenteBase(fitem.Docente.Cedula)[0];
                }
                catch(ArgumentOutOfRangeException ex){
                    fitem.Docente = new Empresa.Docente.tdocente();
                }
            }

            vista.MostarReporte(rep);
        }
        
        private void Refresh(object e){
            

        }

        private void But_Editar_Click(object sender, RoutedEventArgs e){
            try
            {
                Empresa.Docente.TFamiliares familiar = (Empresa.Docente.TFamiliares)datagrid12.SelectedItem;
                if (familiar != null){
                    SIC.Objs.Controles.win_AgregarPersona editar = new win_AgregarPersona(familiar);
                    editar.ShowDialog();

                    if (Familiares != null) {
                        if (editar.Familiar != null){
                            Familiares.Update(editar.Familiar);
                            datagrid12.SelectedItem = editar.Familiar;
                            datagrid12.Items.Refresh();
                        }
                    }
                }
            }
            catch { 
            
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e){
            Print();
            
        }

        private void But_Aplicar_Click(object sender, RoutedEventArgs e)
        {
            if (Familiares != null)
            {
                this.filtro(Convert.ToInt32(Txt_FInicio.Text), Convert.ToInt32(Txt_FFinal.Text), ch_documentospresente.IsChecked.Value, (Empresa.Comun.TParentesco)com_parentesco.SelectedItem);
            }
        }

        private void ch_documentospresente_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Txt_FInicio_PreviewKeyDown(object sender, KeyEventArgs e){
           
        

        }

        private void Txt_FInicio_PreviewTextInput(object sender, TextCompositionEventArgs e){
            
            if (string.IsNullOrEmpty(e.Text)){
                if (!char.IsNumber(e.Text, 0)){
                    e.Handled = true;
                }
            }
            else{
                if (!char.IsNumber(e.Text, e.Text.Length - 1)){
                    e.Handled = true;
                }
            }

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            this.bw.Dispose();
            this.Espera.Close();
        }

        public string CModulo{
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto
        {
            get { return "__doc878__0oaaafc"; }
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
            get { return "Consulta de Dependientes"; }
        }

        public string objecto
        {
            get { return "ConsultaDependientes"; }
        }

        private void Txt_FFinal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Txt_FInicio_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

    }
}

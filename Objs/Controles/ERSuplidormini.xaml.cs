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
    /// Interaction logic for ERSuplidormini.xaml
    /// </summary>
    public partial class ERSuplidormini : UserControl, Empresa.Comun.IFirma
    {
     
        public Empresa.Comun.TSuplidor SelectItem { set; get; }

        public event Empresa.Comun.DSeleccion SeleccionItem = delegate {};
        public event Empresa.Comun.DFinalizar Limpiando = delegate{};

        public event Empresa.Comun.DSeleccion InicioBusqueda = delegate {};
        public event Empresa.Comun.DFinalizar FinBusqueda = delegate {};
        BackgroundWorker bw;

        public ERSuplidormini(){
            
            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += worker_RunWorkerCompleted;
            InitializeComponent();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Argument.ToString())){
                e.Result = Buscar(e.Argument.ToString());
            }
            else {
                e.Result = new List<Empresa.Comun.TSuplidor>();  
            }
        }

        public void InicBusqueda() {
            if (!bw.IsBusy){
                Lis_resultado.Visibility = System.Windows.Visibility.Visible;
                this.InicioBusqueda.Invoke(Txt_Argumetno.Text);
                bw.RunWorkerAsync(Txt_Argumetno.Text);
            }
        }

        public void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.SelectItem = (Empresa.Comun.TSuplidor)e.Result;
            //this.SeleccionItem.Invoke(this.SelectItem);
            //FinBusqueda.Invoke(this.SelectItem);
            this.prg_progreso.Visibility = System.Windows.Visibility.Hidden;

            this.DataContext = e.Result;
            this.FinBusqueda.Invoke(e.Result);
            this.bw.Dispose();
        }

        private List<Empresa.Comun.TSuplidor> Buscar(string arg){
            try {
                  return new Empresa.Comun.Suplidor("%" + arg + "%").ToList<Empresa.Comun.TSuplidor>();
            }
            catch {
               // Empresa.Comun.RegFunEvento.Reg(ex.Message);
            }
            return new List<Empresa.Comun.TSuplidor>();
        }

        private void Txt_Argumetno_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down){
                Lis_resultado.Focus();
                if(Lis_resultado.Items.Count >= 1){
                    Lis_resultado.SelectedIndex = 0;
                }
            }
            if (e.Key == Key.Escape) {
                LimpiandoItem();
            }
        }

        private void Txt_Argumetno_KeyUp_1(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (!bw.IsBusy){
                    Lis_resultado.Visibility = System.Windows.Visibility.Visible;
                    this.InicioBusqueda.Invoke(Txt_Argumetno.Text);
                    this.prg_progreso.Visibility = System.Windows.Visibility.Visible;
                    bw.RunWorkerAsync(Txt_Argumetno.Text);
                }
            }

        }

        private void Txt_Argumetno_PreviewKeyUp_1(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text.Length.Equals(0))
            {
                LimpiandoItem();
            }
        }

        private void Lis_resultado_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter){
                Lis_resultado_MouseDoubleClick_1(sender, null);
            }
            if (e.Key == Key.Escape){
                LimpiandoItem();
            }
         
        }

        private void Lis_resultado_MouseDoubleClick_1(object sender, MouseButtonEventArgs e){
            if (((ListBox)sender).SelectedItem != null) {
                SeleccionandoItem((Empresa.Comun.TSuplidor)Lis_resultado.SelectedItem);
            }
        }

        private void SeleccionandoItem(Empresa.Comun.TSuplidor item)
        {
            this.SelectItem = item;
            if (item != null)
            {
                this.SeleccionItem.Invoke(this.SelectItem);
                this.DataContext = null;
                Lis_resultado.Visibility = System.Windows.Visibility.Hidden;
                Txt_Argumetno.Text = this.SelectItem.Nombre;
            }
        }

        public void LimpiandoItem() {
            this.DataContext = null;
            this.SelectItem = null;

            Txt_Argumetno.Text = string.Empty;
            Txt_Argumetno.Focus();
            Limpiando(null);
            Lis_resultado.Visibility = System.Windows.Visibility.Hidden;
        }

        public void SetItem(Empresa.Comun.TSuplidor item) {
            SeleccionandoItem(item); 
        }

        public string CModulo {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto{
            get { return "__doco_opioqiop0_09ei9"; }
        }

        public string Descripcion{
            get { throw new NotImplementedException(); }
        }

        public string Modulo
        {
            get { return "Docente"; }
        }

        public string Nombre{
            get { return "Buscando Suplidor"; }
        }

        public string objecto
        {
            get { return "BuscandoSuplidor"; }
        }
    }
}

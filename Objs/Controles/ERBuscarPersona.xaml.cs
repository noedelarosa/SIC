using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace Contrato.objects.paginas
{
    /// <summary>
    /// Interaction logic for ERBuscarPersona.xaml
    /// </summary>
    public partial class ERBuscarPersona : UserControl, Empresa.Comun.IFirma {

        public static DependencyProperty DepSelectItem = DependencyProperty.RegisterAttached("SelectItem", typeof(Empresa.RHH.tpersonal), typeof(Contrato.objects.paginas.ERBuscarPersona), new PropertyMetadata()); 
        
        public Empresa.RHH.tpersonal SelectItem {
            set {
                SetValue(DepSelectItem, value);
            }
            get {
                return GetValue(DepSelectItem) as Empresa.RHH.tpersonal;
            }
        }

        public event Empresa.Comun.DSeleccion SeleccionItem = delegate { };
        public event Empresa.Comun.DFinalizar Limpiando = delegate { };

        public event Empresa.Comun.DSeleccion InicioBusqueda = delegate { };
        public event Empresa.Comun.DFinalizar FinBusqueda = delegate    { };
        BackgroundWorker bw;

        public string CedulaPresente {
            get { return Txt_Cedula.Text; }
            private set { }
        }

        public void LimpiandoItem(){
            this.SelectItem = null;
            this.Txt_Cedula.Text = string.Empty;
            Limpiando.Invoke(null); 
        }

        private Empresa.RHH.tpersonal Buscar(string arg){
            //inicio de la busqueda
            var resul = new Empresa.RHH.Persona(arg);
            
            if (resul.Count > 0){ 
                return resul[0];
            }else{
                return new Empresa.RHH.tpersonal();
            }
        }

        public ERBuscarPersona(){
            InitializeComponent();
            bw = new BackgroundWorker();

            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
         
        private void bw_DoWork(object sender, DoWorkEventArgs e){
            e.Result = Buscar(e.Argument.ToString());
        }

        public void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            prg_progreso.Visibility = System.Windows.Visibility.Hidden;
            
            this.SelectItem = (Empresa.RHH.tpersonal)e.Result;
            this.SeleccionItem.Invoke(this.SelectItem);
            FinBusqueda.Invoke(this.SelectItem);
        }

        public void InicBusqueda(){
            if (!bw.IsBusy){
                this.SelectItem = Buscar(Txt_Cedula.Text);
                this.SeleccionItem.Invoke(this.SelectItem);
            }
        }

        public void SetItem(string cedula) {
            if(!string.IsNullOrEmpty(cedula)){
                this.Txt_Cedula.Text = cedula;

                prg_progreso.Visibility = System.Windows.Visibility.Visible;
                InicioBusqueda.Invoke(Txt_Cedula.Text);
                bw.RunWorkerAsync(Txt_Cedula.Text);
            }
        }

        //public void SetItem(Empresa.RHH.tpersonal item)
        //{
        //    this.SelectItem = item;
        //    this.Txt_Cedula.Text = item.Cedula;
        //    this.SeleccionItem.Invoke(this.SelectItem);
        //}

        public void SetItem(Empresa.RHH.tpersona item)
        {
            this.SelectItem = item;
            this.Txt_Cedula.Text = item.Cedula;
            this.SeleccionItem.Invoke(this.SelectItem);
            this.FinBusqueda.Invoke(this.SelectItem);
        }

        private void Txt_Cedula_PreviewKeyDown_1(object sender, KeyEventArgs e){
            if (e.Key == Key.Escape) {
                this.LimpiandoItem(); 
            }
        }

        private void Txt_Cedula_PreviewKeyUp_1(object sender, KeyEventArgs e){
            if (string.IsNullOrEmpty(((TextBox)sender).Text)) this.LimpiandoItem(); 
        }

        private void Txt_Cedula_KeyUp_1(object sender, KeyEventArgs e){
            if (e.Key == Key.Enter){
                if (!bw.IsBusy){
                    prg_progreso.Visibility = System.Windows.Visibility.Visible;
                    InicioBusqueda.Invoke(Txt_Cedula.Text);
                    bw.RunWorkerAsync(Txt_Cedula.Text);
                }
            }
        }
        
        public void SetFocus() {
            this.Txt_Cedula.Focus();
        }


        public string CModulo
        {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto
        {
            get { return "__doco_bpagetactodohe_"; }
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
            get { return "Buscando Persona"; }
        }

        public string objecto
        {
            get { return "BuscandoPersona"; }
        }
    }
}

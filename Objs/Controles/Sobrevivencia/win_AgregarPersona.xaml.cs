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
    /// Interaction logic for win_AgregarPersona.xaml
    /// </summary>
    public partial class win_AgregarPersona:Window, Empresa.Comun.IFirma
    {

        public Empresa.Docente.TFamiliares Familiar {
            get { return (Empresa.Docente.TFamiliares)DataContext; }
            set { this.DataContext = value; }
        }

        private void Refresh(object e) {
            this.DataContext = null;
            this.DataContext = e;
        }

        public win_AgregarPersona(Empresa.Docente.tdocente docente){
            InitializeComponent();
            com_relacion.ItemsSource = new Empresa.Comun.Parentesco();
            com_EstadoBeneficio.ItemsSource = Empresa.Docente.EstadoBeneficio.GetInstance().Lista;

            //Estableciendo datos
            this.Familiar = new Empresa.Docente.TFamiliares();
            if (docente.EsInabima){
                this.Familiar.Decreto = docente.DecretoBeneficiarios;
            }
            else {
                this.Familiar.Aseguradora = docente.Aseguradora;
            }
            this.Familiar.Docente = docente;
        }

        public win_AgregarPersona(Empresa.Docente.TFamiliares item){
            InitializeComponent();

            com_relacion.ItemsSource = new Empresa.Comun.Parentesco();
            com_EstadoBeneficio.ItemsSource = Empresa.Docente.EstadoBeneficio.GetInstance().Lista;
            
            //Estableciendo datos
            this.DataContext = item;
            if(string.IsNullOrEmpty(item.Cedula) || item.Cedula.Equals("0")){
                //Menor.
                ch_edad.IsChecked = true;
                Ch_esMasculino.IsChecked = item.EsMasculino;
                if(!string.IsNullOrEmpty(item.Tutor.Cedula)) usc_BuscarTutor.SetItem(item.Tutor.Cedula);
            }
            else{
                //Mayor.
                ch_edad.IsChecked = false;
                //Buscando Persona
                usc_buscar.SetItem(item.Cedula);
            }
        }

        private void Limpiando() {
            this.Familiar.Nombres = string.Empty;
            this.Familiar.Apellidos = string.Empty;
            this.Familiar.FechaNacimiento = DateTime.MinValue;
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            //Aceptar
            //this.Familiar.Aseguradora = us_suplidor.SelectItem;
            if(Familiar.IsValid()){
                this.Hide();
            }
            else{
                MessageBox.Show("Contenido no valido, verifique los datos, Error: " + Familiar.Error, "Contenido no valido", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            //Salir
            this.Familiar = null;
            this.Close();
        }

        private void usc_buscar_SeleccionItem(object e){
            if(e != null){

                var persona = (Empresa.RHH.tpersonal)e;

                this.Familiar.Nombres = persona.Nombres;
                this.Familiar.Apellidos = persona.Apellidos;
                this.Familiar.FechaNacimiento = persona.FechaNacimiento;
                this.Familiar.EsMasculino = persona.EsMasculino;
                this.Familiar.Cedula = persona.Cedula;

                this.Refresh(this.DataContext);

            }
        }

        private void usc_buscar_Limpiando(object e){
            this.Limpiando();
            this.Refresh(this.DataContext);
        }

        private void ch_edad_Checked(object sender, RoutedEventArgs e){
            var i = sender as CheckBox;
            //se le asigna un numero arbitrario por no utilizar esta propiedad
            //usc_buscar.LimpiandoItem();
            if (i.IsChecked==true) this.Familiar.Cedula = "0";
            
        }

        private void usc_BuscarTutor_SeleccionItem(object e)
        {
            if (e != null){

                if (this.Familiar != null){
                    this.Familiar.Tutor = (Empresa.RHH.tpersonal)e;
                    Txt_NombreTutor.Text = this.Familiar.Tutor.Nombres + "  " + this.Familiar.Tutor.Apellidos;
                }
                else{
                    MessageBox.Show("Debe seleccionar el Primero el familiar", "Debe seleccionar el familiar", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Familiar = null;
        }

        private void Window_Closed(object sender, EventArgs e){
            this.Familiar = null;
        }

        private void But_VerContacto_Click(object sender, RoutedEventArgs e){

            SIC.Objs.Controles.win_comentarios comen = new win_comentarios(this.Familiar,this.Familiar.Docente.Cedula);
            comen.ShowDialog();
        }

        public string CModulo{
            get {return "__docm_09o4u3ja;hu823_";}
        }

        public string Cobjecto
        {
            get { return "__doco67_10293o_09123"; }
        }

        public string Descripcion
        {
            get { return "Para Agregar, quitar Beneficiarios."; }
        }

        public string Modulo
        {
            get { return "Docente"; }
        }

        public string Nombre
        {
            get { return "Mantenimiento Persona"; }
        }

        public string objecto
        {
            get { return "MantenimientoPersona"; }
        }
    }
}

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
using System.ComponentModel;

namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for Win_Busqueda_Personal_Estandar.xaml
    /// </summary>
    public partial class Win_Busqueda_Personal_Estandar : Window, INotifyPropertyChanged
    {
        public bool Editame { get; set; }
        public Empresa.Docente.tpersonaRelacionada PersonaRelacion{
            
            //get {
            //    if (this.Persona == null){
            //        return null;
            //    }
            //    else {
            //        if(this.com_relacion.SelectedItem == null) {
            //            return new Empresa.Docente.tpersonaRelacionada(this.Persona, new Empresa.Comun.TEstandar());
            //        }
            //        else {
            //            return new Empresa.Docente.tpersonaRelacionada(this.Persona, (Empresa.Comun.TEstandar)com_relacion.SelectedItem);
            //        }
            //    }
            //}

            get;
            set;
        }
        public Win_Busqueda_Personal_Estandar(){
            Editame = false;
            InitializeComponent();
            this.PersonaRelacion = new Empresa.Docente.tpersonaRelacionada();
            this.com_relacion.ItemsSource = new Empresa.Comun.Parentesco();
        }

        public Win_Busqueda_Personal_Estandar(Empresa.Docente.tpersonaRelacionada item){
            this.PersonaRelacion = item;
            Editame = false;

            InitializeComponent();

            this.com_relacion.ItemsSource = new Empresa.Comun.Parentesco();
            //Busqueda en control de la persona.
            this.usc_buscarPersona.SetItem(this.PersonaRelacion.Persona.Cedula);
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            if (com_relacion.SelectedItem != null){

                if(this.PersonaRelacion.Persona != null){
                    if (!string.IsNullOrEmpty(PersonaRelacion.Persona.Cedula)){
                        Editame = true;
                        this.Hide();
                    }
                    else {
                        MessageBox.Show("Falta la persona que servira como beneficiario.", "Seleccione Persona", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
                else {
                    MessageBox.Show("Falta la persona que servira como beneficiario.", "Seleccione Persona", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            else {
                MessageBox.Show("Falta Selección de parentesco", "Seleccione parentesco", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void But_Cerrar_Click(object sender, RoutedEventArgs e){
            Editame = false;
            this.Hide();
        }

        private void But_DireccionSolicitante_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.Dialogos.win_direccion diresdialog = new Objs.Controles.Dialogos.win_direccion(this.PersonaRelacion.Persona.DireccionAsignada);
            diresdialog.ShowDialog();
        }

        private void But_ContactoSolicitante_Click(object sender, RoutedEventArgs e){
            SIC.Objs.Controles.wus_contacto conta = new Objs.Controles.wus_contacto(this.PersonaRelacion.Persona.Contacto);
            conta.ShowDialog();
            //asignación de contactos.
            this.PersonaRelacion.Persona.Contacto = conta.Contacto;
        }

        private void usc_buscarPersona_FinBusqueda(object e){


        }

        private void usc_buscarPersona_Limpiando(object e){
            this.PersonaRelacion.Persona = new Empresa.RHH.tpersonal();
            this.EnCambio("PersonaRelacion");
        }

        private void usc_buscarPersona_SeleccionItem(object e){

            if(string.IsNullOrEmpty(((Empresa.RHH.tpersonal)e).Cedula)){

                Direccion_Solicitante.IsEnabled = false;
                Contactos_Solicitante.IsEnabled = false;

                MessageBox.Show("Cedula no valida, verifique.", "Cedula no valida", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else {
                //Encontrado
                this.PersonaRelacion.Persona.Nombres  = ((Empresa.RHH.tpersonal)e).Nombres;
                this.PersonaRelacion.Persona.Apellidos = ((Empresa.RHH.tpersonal)e).Apellidos;

                this.PersonaRelacion.Persona.Cedula = ((Empresa.RHH.tpersonal)e).Cedula;
                this.PersonaRelacion.Persona.EsMasculino = ((Empresa.RHH.tpersonal)e).EsMasculino;
                this.PersonaRelacion.Persona.FechaNacimiento = ((Empresa.RHH.tpersonal)e).FechaNacimiento;
                this.PersonaRelacion.Persona.Foto = ((Empresa.RHH.tpersonal)e).Foto;

                this.EnCambio("PersonaRelacion");
                Direccion_Solicitante.IsEnabled = true;
                Contactos_Solicitante.IsEnabled = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void EnCambio(string nombre)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;
            if (manejador != null){
                manejador(this, new PropertyChangedEventArgs(nombre));
            }
        }
    }
}

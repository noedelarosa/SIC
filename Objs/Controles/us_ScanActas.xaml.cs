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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for us_ScanActas.xaml
    /// </summary>
    public partial class us_ScanActas : UserControl
    {
        private Empresa.Docente.ActasDocente actas;

        public us_ScanActas(){
            InitializeComponent();
            actas = new Empresa.Docente.ActasDocente();
            //binding
            this.Com_Provincia.ItemsSource = Empresa.Comun.Provincia.GetInstance();
            this.BindingGrid(actas.Lista);
        }

        private void AgregandoItem(string nss){
            //Empresa.Docente.tdocente indocen;
            //Empresa.Docente.tdocenteactas docente = new Empresa.Docente.tdocenteactas();
             
            //if (Com_Provincia.SelectedItem != null)
            //{
            //    if (!string.IsNullOrEmpty(Txt_nss.Text.Trim()))
            //    {
            //        var resul = new Empresa.Docente.DocenteNss(nss);
            //        if (resul.Count > 0){
            //            indocen = resul[0];
            //        }
            //        else{
            //            indocen = new Empresa.Docente.tdocente();
            //        }

            //        docente.Id = indocen.Id;
            //        docente.Nombres = indocen.Nombres;
            //        docente.Cedula = indocen.Cedula;
            //        docente.Nss = nss;
            //        docente.Provincia = (Empresa.Comun.TProvincia)Com_Provincia.SelectedItem;

            //        this.AgregandoGrid(docente);
            //    }
            //}
            //else {
            //    MessageBox.Show("Debe seleccionar una provincia", "Falta Provincia", MessageBoxButton.OK, MessageBoxImage.Error);
            //    UserControl_Loaded_1(null, null);
            //}
        }

        private void BindingGrid(ObservableCollection<Empresa.Docente.tdocenteactas> items) {
            //this.datagrid1.ItemsSource = null;
            //this.datagrid1.ItemsSource = items;
            
            txt_cantidad.Text = "Cantidad: " + items.Count.ToString();
        }

        private void AgregandoGrid(Empresa.Docente.tdocenteactas item) {
            actas.Insert(item);
            this.BindingGrid(actas.Lista);
        }

        private void Txt_nss_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) {
                this.AgregandoItem(((TextBox)sender).Text);
                ((TextBox)sender).Text = string.Empty; 
            }
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            Txt_nss.Focus();
        }

        private void But_Borrar_Click(object sender, RoutedEventArgs e){
            //if (MessageBox.Show("Borrar " + datagrid1.VisibleRowCount.ToString() + " Actas. Desea Hacer esta acción Si/No.", "Desea Borrar Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){


            //    //foreach (Empresa.Docente.tdocenteactas fila in datagrid1.VisibleRowCount)
            //    //{
            //    //    actas.delete(fila);
            //    //}

            //    But_Recargar_Click(null, null);
            //}
        }

        private void But_Recargar_Click(object sender, RoutedEventArgs e){
            actas = new Empresa.Docente.ActasDocente();
            this.BindingGrid(actas.Lista); 
        }
    }
}

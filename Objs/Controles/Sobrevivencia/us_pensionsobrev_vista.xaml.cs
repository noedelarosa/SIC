using System;
using System.Collections.Generic;
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

namespace SIC
{
	/// <summary>
	/// Interaction logic for us_pensionsobrev_vista.xaml
	/// </summary>
	public partial class us_pensionsobrev_vista : UserControl {

		public us_pensionsobrev_vista(){
			this.InitializeComponent();
		}

        private void SettingSeguridad(Empresa.Docente.tdocente item){

            if (item.EsInabima){
                //Decreto
                //item.DecretoActual.Monto
                if (item.DecretoBeneficiarios  != null){
                    if (item.DecretoBeneficiarios.Id != 0){
                        But_AgregarFamiliar.IsEnabled = true;
                        But_EditarFamiliar.IsEnabled = true;
                        But_Eliminar.IsEnabled = true;
                    }
                    else{
                        But_AgregarFamiliar.IsEnabled = false;
                        But_EditarFamiliar.IsEnabled = false;
                        But_Eliminar.IsEnabled = false;
                    }
                }
                else{
                    But_AgregarFamiliar.IsEnabled = false;
                    But_EditarFamiliar.IsEnabled = false;
                    But_Eliminar.IsEnabled = false;
                }
            }
            else { 
            //Aseguradora
                if (item.Aseguradora != null){
                    if (item.Aseguradora.Id != 0)
                    {
                        But_AgregarFamiliar.IsEnabled = true;
                        But_EditarFamiliar.IsEnabled = true;
                        But_Eliminar.IsEnabled = true;
                    }
                    else {
                        But_AgregarFamiliar.IsEnabled = false;
                        But_EditarFamiliar.IsEnabled = false;
                        But_Eliminar.IsEnabled = false;
                    }
                }
                else {
                    But_AgregarFamiliar.IsEnabled = false;
                    But_EditarFamiliar.IsEnabled = false;
                    But_Eliminar.IsEnabled = false;
                }
            }

        }

        public us_pensionsobrev_vista(Empresa.Docente.tdocente item){
            this.InitializeComponent();
            this.SettingSeguridad(item);

            item.Familiares = new Empresa.Docente.Familiares(item);
            this.DataContext = item;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e){
            

        }

        public void Imprimir(){
            SIC.Objs.Controles.wus_selecciondocentereporte seler = new Objs.Controles.wus_selecciondocentereporte((Empresa.Docente.tdocente)this.DataContext);
            seler.Show();
        }

        public void Guardar(){ 
        

        }

        public void Refresh(object e) {
            object tempe = e;
            this.DataContext = null;
            this.DataContext = tempe;
        }

        private void But_AgregarFamiliar_Click(object sender, RoutedEventArgs e){
            //Agregando.
            SIC.Objs.Controles.win_AgregarPersona agre = new Objs.Controles.win_AgregarPersona((Empresa.Docente.tdocente)this.DataContext);
            agre.ShowDialog();

            if(agre.Familiar != null){

                try{
                    ((Empresa.Docente.tdocente)this.DataContext).Familiares.Insert(agre.Familiar);
                    this.Refresh(this.DataContext);

                    datagrid1.Items.Refresh();
                }
                catch (Exception ex) {
                    MessageBox.Show("Existe un error en el formulario, Vefique las fechas o si estan todos los campos con información." + ex.Message, "Falta Información", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            agre.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e){
            //Eliminando Beneficiario.
            if (!datagrid1.SelectedItems.Count.Equals(0)){

                if(MessageBox.Show("Desea Eliminar el siguiente Beneficiario, Si/No", "Desea Eliminar Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                    try{
                        ((Empresa.Docente.tdocente)this.DataContext).Familiares.Delete((Empresa.Docente.TFamiliares)datagrid1.SelectedItem);
                        //Refresh
                        this.Refresh(this.DataContext);
                        datagrid1.Items.Refresh();
                    }
                    catch(Exception ex){
                        MessageBox.Show("Existe un error en el formulario, Vefique las fechas o si estan todos los campos con información." + ex.Message, "Falta Información", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
            }
        }

        private void But_ComentariosHistorico_Click(object sender, RoutedEventArgs e){
            //Comentario
            SIC.Objs.Controles.win_comentarios wcomen = new Objs.Controles.win_comentarios((Empresa.Docente.tdocente)this.DataContext);
            wcomen.ShowDialog();
        }

        private void But_EditarFamiliar_Click(object sender, RoutedEventArgs e){
            //Editando Familiar.
            if(!datagrid1.SelectedItems.Count.Equals(0)){
                SIC.Objs.Controles.win_AgregarPersona agre = new Objs.Controles.win_AgregarPersona((Empresa.Docente.TFamiliares)datagrid1.SelectedItems[0]);
                agre.ShowDialog();

                if(agre.Familiar != null){
                 try{
                        ((Empresa.Docente.tdocente)this.DataContext).Familiares.Update(agre.Familiar);
                        this.Refresh(this.DataContext);
                        datagrid1.Items.Refresh();
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Existe un error en el formulario, Vefique las fechas o si estan todos los campos con información", "Falta Información", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
            }

        }

        private void datagrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete) {
                Button_Click_2(null, null);
            }
        }

        private void mconx_Editar_Click(object sender, RoutedEventArgs e)
        {
            this.But_EditarFamiliar_Click(null, null);
        }

        private void mconx_Agregar_Click(object sender, RoutedEventArgs e)
        {
            But_AgregarFamiliar_Click(null, null);
        }

        private void mconx_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Button_Click_2(null, null);
        }
	}
}
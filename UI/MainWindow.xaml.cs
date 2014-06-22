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

namespace SIC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private us_mantenimiento_procesos proc;
		private us_pensionsobrev_vista visps;

        public MainWindow(){
            InitializeComponent();
            //ConectionString.ManagerString.SetConeccionString("INABIMA", "Mr_Coco-LAPTOP", "INABIMA", "NONE", "Mr_coco", true);
            //ConectionString.ManagerString.SetConeccionString("INABIMA", "srv-inabima", "INABIMA", "Ks35EfR3aA", "sa", false);
            usc_buscardocente.But_PJ.Click += But_PJ_Click;
			usc_buscardocente.But_PS.Click += But_PS_Click;

            
            try{
                usc_buscardocente.DefaultFocus();
                pag_trans.ShowPage(new SIC.Objs.Controles.Screenw());
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }

		}

        private void But_PJ_Click(object sender, RoutedEventArgs e){
            proc = new us_mantenimiento_procesos();
            pag_trans.ShowPage(proc);
        }
		
		private void But_PS_Click(object sender, RoutedEventArgs e){
            try
            {
                visps = new us_pensionsobrev_vista(usc_buscardocente.Docente);
                pag_trans.ShowPage(visps);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void usc_buscardocente_EsResultado_1(object sender, RoutedEventArgs e){

        }

        private void usc_buscardocente_EsLimpiado_1(object sender, RoutedEventArgs e){
            try{
                pag_trans.ShowPage(new SIC.Objs.Controles.Screenw());
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            } 
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            
        }
    }
}

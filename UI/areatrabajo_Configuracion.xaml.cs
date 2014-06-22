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

namespace SIC.UI
{
    /// <summary>
    /// Interaction logic for areatrabajo.xaml
    /// </summary>
    public partial class areatrabajo_Configuracion : UserControl
    {

        Empresa.RegistrosEventos.RegistroEventos.ViewEvent vista_eventos;
        //Empresa.RegistroEventos.
        public areatrabajo_Configuracion()
        {
            InitializeComponent();

            try{
                pag_trans.ShowPage(scn);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message); 
            }

        }

        private SIC.Objs.Controles.Screenw scn = new SIC.Objs.Controles.Screenw();

        private void But_Imprimir_Click(object sender, System.Windows.RoutedEventArgs e){
       	// TODO: Add event handler implementation here.
		//impresion de documento
           try
           {
               pag_trans.ShowPage(scn);
       
           }
           catch (Exception ex) {
               MessageBox.Show("Verifique la seleccion del documento", "Documento no seleccionado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
           }
       }

        private void But_Eventos_Click(object sender, RoutedEventArgs e)
        {

            try{
                vista_eventos = new Empresa.RegistrosEventos.RegistroEventos.ViewEvent();
                pag_trans.ShowPage(vista_eventos);
            }
            catch { 
            
            }

        }


    }




    
}

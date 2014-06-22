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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for ListaPensionadosBeneficio.xaml
    /// </summary>
    public partial class ListaPensionadosBeneficio : UserControl
    {
        Empresa.Docente.tlistadopensionadosenbeneficio Item {get;set;}
        private Empresa.Docente.DocenteListaPensionBeneficio _ListadoDocentes;
        public ListaPensionadosBeneficio(){
            Item = new Empresa.Docente.tlistadopensionadosenbeneficio();
            InitializeComponent();
        }

        public ListaPensionadosBeneficio(Empresa.Docente.tlistadopensionadosenbeneficio item){
            this.Item = item;
            _ListadoDocentes = new Empresa.Docente.DocenteListaPensionBeneficio(item.Id);
            item.Docente = _ListadoDocentes.Lista;
            this.DataContext = item.Docente;
            InitializeComponent();
        }

        private void But_Agregar_Click(object sender, RoutedEventArgs e){
            Empresa.Docente.tdocente docenteseleccionado = GlobalItems.DocenteGlobal;
            if(docenteseleccionado != null){
                try{
                    _ListadoDocentes.Insert(docenteseleccionado, this.Item.Id);
                    this.DataContext = _ListadoDocentes.Lista;
                }
                catch { 
                
                }
            }
        }

        private void cm_agregardocente_canexecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private void cm_agregardocente_execute(object sender, ExecutedRoutedEventArgs e)
        {
            //MessageBox.Show("hola esta alt-s");
        }
    }
}

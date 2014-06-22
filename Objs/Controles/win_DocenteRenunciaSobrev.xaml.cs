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

namespace SIC.Objs
{
    /// <summary>
    /// Interaction logic for win_DocenteRenunciaSobrev.xaml
    /// </summary>
    public partial class win_DocenteRenunciaSobrev : Window, Empresa.Comun.IFirma
    {
        
        public win_DocenteRenunciaSobrev(){
            InitializeComponent();
        }

        public win_DocenteRenunciaSobrev(Empresa.Docente.tdocente item){
            InitializeComponent();
            this.DataContext = item;
        }

        private void Button_Click(object sender, RoutedEventArgs e){
            this.Close();
        }

        public string CModulo
        {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto
        {
            get { return "__doco___0992j_09kmnM_"; }
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
            get { return "Vista Renuncia"; }
        }

        public string objecto
        {
            get { return "VistaRenuncia"; }
        }

    }
}

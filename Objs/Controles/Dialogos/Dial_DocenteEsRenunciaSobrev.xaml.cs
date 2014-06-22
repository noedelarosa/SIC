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

namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for Dial_DocenteEsRenunciaSobrev.xaml
    /// </summary>
    public partial class Dial_DocenteEsRenunciaSobrev : Window
    {
        public Dial_DocenteEsRenunciaSobrev()
        {
            InitializeComponent();
        }

        public Empresa.Docente.tdocente Docente { get; set; }
        public Dial_DocenteEsRenunciaSobrev(Empresa.Docente.tdocente item){
            InitializeComponent();
            this.Docente = item;
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Txt_Anuncio_TextChanged(object sender, TextChangedEventArgs e){


        }

        private void But_Ver_Click(object sender, RoutedEventArgs e){
            win_DocenteRenunciaSobrev sobrv = new win_DocenteRenunciaSobrev(this.Docente);
            sobrv.Show();
            this.Close();
        }
    }
}

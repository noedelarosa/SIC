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
    /// Interaction logic for Win_nota.xaml
    /// </summary>
    public partial class Win_nota : Window
    {
        Empresa.Comun.TComentario Nota { get; set; }
        public Win_nota(){
            InitializeComponent();
            Nota = null;
        }

        private void But_Si_Click(object sender, RoutedEventArgs e){
            this.Hide();
        }

        private void But_No_Click(object sender, RoutedEventArgs e){
            this.Hide();
            this.Nota = null;
            
        }

    }
}

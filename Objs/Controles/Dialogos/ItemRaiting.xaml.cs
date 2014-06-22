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

namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for ItemRaiting.xaml
    /// </summary>
    public partial class ItemRaiting : UserControl
    {

        



        public ItemRaiting(){
            InitializeComponent();
            
        }

      

        private void op_2_Checked(object sender, RoutedEventArgs e)
        {
            op_1.IsChecked = true;
        }

        private void op_3_Checked(object sender, RoutedEventArgs e)
        {
            op_2.IsChecked = true;
        }
    }
}

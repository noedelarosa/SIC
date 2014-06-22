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
using System.Windows.Media.Animation;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for esperacircular.xaml
	/// </summary>
	public partial class esperacircular : UserControl
	{
        private Storyboard myStoryboard;
		public esperacircular()
		{
			this.InitializeComponent();   
		}

        public void Iniciar() {
            //Storyboard3
            myStoryboard = (Storyboard)this.Resources["Storyboard3"];
            myStoryboard.Begin(this);
        }
        
        public void Detener() {
            myStoryboard = (Storyboard)this.Resources["Storyboard3"];
            myStoryboard.Stop(this);
        }
	}
}
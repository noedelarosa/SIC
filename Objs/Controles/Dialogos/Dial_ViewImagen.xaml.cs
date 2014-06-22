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
using System.Diagnostics;


namespace SIC.Objs.Controles.Dialogos
{
    /// <summary>
    /// Interaction logic for Dial_ViewImagen.xaml
    /// </summary>
    public partial class Dial_ViewImagen : Window
    {
        public Dial_ViewImagen(){
            InitializeComponent();
            var r = grid_contenido.Width;
        }

        public Dial_ViewImagen(BitmapImage imagen) {
            InitializeComponent();
            this.img_documento.Source = imagen;
            
            this.vb_contenido.Width = imagen.Width;
            this.vb_contenido.Height = imagen.Height;
        }

        public Dial_ViewImagen(ImageSource imagen){
            InitializeComponent();
            this.img_documento.Source = imagen;
   
            this.vb_contenido.Width = imagen.Width;
            this.vb_contenido.Height = imagen.Height;
        }
        public Dial_ViewImagen(byte[] imagen){
            InitializeComponent();
            //this.img_documento.Source = WorkImage.GetArray()
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue < e.OldValue)
            {
                //bajando 
                this.vb_contenido.Width -= 5;
                this.vb_contenido.Height -= 5;
            }
            else { 
            //subiendo 
            this.vb_contenido.Width += 5;
            this.vb_contenido.Height += 5;
            }
        }

        private void But_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //prceso.StartInfo.FileName = Environment.CurrentDirectory + "\\" + origen;
                //string origen = GlobalItems.____cd_tempfile + "//img_tempfile_01.bmp";
                //Environment.CurrentDirectory + "\\" + origen;

                string origen = Environment.CurrentDirectory + "\\" + GlobalItems.____cd_tempdirectorio + "\\" + GlobalItems.____ar_temparchivofoto;
                WorkImage.ToFile((BitmapSource)this.img_documento.Source, origen);
                Process prceso = new Process();
                prceso.StartInfo.Verb = "Print";
                prceso.StartInfo.FileName = origen;
                prceso.Start(); 
            }
            catch {
                MessageBox.Show("No se puede procesar la solicitud", "No se puede procesar la solictud.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

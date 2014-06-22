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
    /// Interaction logic for us_Mantenimiento_Decreto.xaml
    /// </summary>
    public partial class us_Mantenimiento_Decreto : UserControl, Empresa.Comun.IFirma {
        public Empresa.Docente.TDecreto Decreto { get; set; }
        public Empresa.Docente.TDecreto UltimoDecreto { get; set; }

        private Empresa.Docente.Decreto decretos = Empresa.Docente.Decreto.GetInstnace();

        private void MostrandoUltimoDecreto() {
            this.UltimoDecreto = decretos.UltimoDecreto;
            this.Txt_UltimoDecreto.Text = this.UltimoDecreto.Numero;
        }

        public us_Mantenimiento_Decreto(){
            this.Decreto = new Empresa.Docente.TDecreto(DateTime.Now,DateTime.Now);
            InitializeComponent();
            this.MostrandoUltimoDecreto();
        }

        public us_Mantenimiento_Decreto(Empresa.Docente.TDecreto item){
            this.Decreto = item;
            InitializeComponent();

            this.MostrandoUltimoDecreto();
        }

        private void But_Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (this.Decreto.IsValid())
            {
                if (MessageBox.Show("Seguro que DESEA INSERTAR UN DECRETO NUEVO CON EL NUMERO: " + this.Decreto.Numero + ", SI ES AFIRMATIVO PRESIONE EL BOTON 'SI' DE LO CONTRARIO PRESIONE EL BOTON 'NO'", "DESEA INSERTAR UN DECRETO NUEVO SI/NO", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                    try{
                        if (decretos.Insert(this.Decreto)){
                            MessageBox.Show("Decreto fue insertado Sactifactoriamente.", "Insertado Sactifactoriamente", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.decretos = Empresa.Docente.Decreto.Recarga();

                            this.MostrandoUltimoDecreto();
                        }
                    }
                    catch{
                        MessageBox.Show("Error el insertar el decreto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else {
                MessageBox.Show(this.Decreto.Error , "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void But_Cancelar_Click(object sender, RoutedEventArgs e){
            
        }

        public string CModulo
        {
            get { return "__docm_09o4u3ja;hu823_"; }
        }

        public string Cobjecto
        {
            get { return "__doco_maAtiOp092_d"; }
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
            get { return "Mantenimiento Decreto"; }
        }

        public string objecto
        {
            get { return "MantenimientoDecreto"; }
        }
    }
}

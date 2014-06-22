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
using System.ComponentModel;

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for us_VisorDocente.xaml
    /// </summary>
    /// 
    public partial class us_VisorDocente : UserControl, INotifyPropertyChanged
    {
        public Empresa.Citas.TCitasVisitas Cita { get; set; }
        public Empresa.Docente.tdocente Docente { get; set; }

        public us_VisorDocente(){
            Cita = new Empresa.Citas.TCitasVisitas();
            InitializeComponent();
        }
        
        private void bindingpaster(Empresa.Docente.tdocente docente, byte cual) {
            grad_paster.Diagram.Series[0].Points.Clear();
            this.DataContext = docente.PagosDetalle.UltimoMes();

            foreach(Empresa.Docente.TPagoDetalle pago in docente.PagosDetalle.UltimoMes()){
                
                if(pago.MontoBruto != 0){
                    //Descuentos e Ingresos.
                    if(cual == 0){
                        grad_paster.Diagram.Series[0].Points.Add(new DevExpress.Xpf.Charts.SeriesPoint(pago.IngresoDescuento.Nombre, System.Math.Abs(pago.MontoBruto)));
                    }

                    //Solo Descuentos
                    if(cual == 1){
                        if (pago.MontoBruto < 0 || pago.IngresoDescuento.Mus.ToString() == "20"){
                                grad_paster.Diagram.Series[0].Points.Add(new DevExpress.Xpf.Charts.SeriesPoint(pago.IngresoDescuento.Nombre, System.Math.Abs(pago.MontoBruto)));
                        }
                    }
                    //Solo Ingresos.
                    if(cual == 2){
                        if (pago.MontoBruto > 0){
                            grad_paster.Diagram.Series[0].Points.Add(new DevExpress.Xpf.Charts.SeriesPoint(pago.IngresoDescuento.Nombre, System.Math.Abs(pago.MontoBruto)));
                        }
                    }

                }
            
            } 
        }

        public us_VisorDocente(Empresa.Docente.tdocente docente, byte cual){
            Cita = new Empresa.Citas.TCitasVisitas();
            //Docente
            this.Docente = docente;
            
            InitializeComponent();
            this.bindingpaster(this.Docente, cual);
            this.EnCambio("Docente");
        }

        public us_VisorDocente(Empresa.Citas.TCitasVisitas item){
            Cita = item;
            this.Docente = new Empresa.Docente.DocenteDecreto(item.Visitante.Cedula).Primero();
            
            InitializeComponent();
            this.bindingpaster(this.Docente,0);
            this.EnCambio("Docente");
        }

        private void But_Ingresos_Click(object sender, RoutedEventArgs e)
        {
            this.bindingpaster(this.Docente, 2);
        }

        private void But_Descuentos_Click(object sender, RoutedEventArgs e)
        {
            this.bindingpaster(this.Docente, 1);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void EnCambio(string nombre)
        {
            PropertyChangedEventHandler manejador = PropertyChanged;
            if (manejador != null)
            {
                manejador(this, new PropertyChangedEventArgs(nombre));
            }
        }

        private void But_IE_Click(object sender, RoutedEventArgs e)
        {
            this.bindingpaster(this.Docente, 0);
        }
        
    }
}

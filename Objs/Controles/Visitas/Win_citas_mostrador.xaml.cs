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
using System.ComponentModel;

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for Win_citas_mostrador.xaml
    /// </summary>
    public partial class Win_citas_mostrador : Window
    {
        public Empresa.RHH.TDepartamento Departamento { get; set; }
        private System.Windows.Threading.DispatcherTimer _tiempo;
        private BackgroundWorker bw;
        private Empresa.Citas.CitasVisitas _citas;

        public Win_citas_mostrador(){
            this.Departamento = new Empresa.RHH.TDepartamento();
            InitializeComponent();
        }
        
       private void bw_DoWork(object sender, DoWorkEventArgs e){
           object[] argm = (object[])e.Argument;
           Empresa.Comun.TEstandar estado = (Empresa.Comun.TEstandar)argm[1];
           Empresa.RHH.TDepartamento depart = (Empresa.RHH.TDepartamento)argm[0];

           e.Result = new Empresa.Citas.CitasVisitas(estado, depart).Lista;
       }

       private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
           this.list01.DataContext = e.Result;
       }

       private void _bindingbw()
       {
           bw = new BackgroundWorker();
           bw.DoWork += new DoWorkEventHandler(bw_DoWork);
           bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
       }

       private void binndingtime(TimeSpan time) {
            this._tiempo = new System.Windows.Threading.DispatcherTimer();
            this._tiempo.Interval = time;
            this._tiempo.Tick += Tiempo_Tick;
        }

       public void Tiempo_Tick(object sedner, EventArgs e){
           try{
               bw.RunWorkerAsync(new object[2] { this.Departamento, new Empresa.Comun.TEstandar(2) });
           }
           catch { 
           
           } 
       }

        public Win_citas_mostrador(Empresa.RHH.TDepartamento departamento){
            InitializeComponent();

            this.Departamento = departamento;
            this._bindingbw();

            this.binndingtime(new TimeSpan(0, 0, 0, 4));
            this._tiempo.Start();
        }

    }
}

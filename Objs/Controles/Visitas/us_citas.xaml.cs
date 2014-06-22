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
    /// Interaction logic for us_citas.xaml
    /// </summary>
    public partial class us_citas : UserControl {

        public Empresa.RHH.tpersonal Persona    {get; set;}
        public Empresa.Citas.TCitasVisitas Cita {get; set;}
        public event DInicio Finalizar = delegate {};
        private Empresa.Citas.CitasVisitas _citas;

        public Empresa.Citas.MotivoVisitas Motivos {get;set;}
        public Empresa.RHH.Departamento Departamentos {get; set;}
        public Empresa.Citas.PersonalPreAsignado Personal {get;set;}

        public us_citas(){
            this.Motivos = Empresa.Citas.MotivoVisitas.GetInstance();
            this.Departamentos = Empresa.RHH.Departamento.GetInstance();
            this.Personal = Empresa.Citas.PersonalPreAsignado.GetInstance();
            this.Cita = new Empresa.Citas.TCitasVisitas();

            InitializeComponent();
            //this.lis_valoracion.ItemsSource = Empresa.Citas.Indicadores.GetInstance().Lista;
        }

        public us_citas(Empresa.RHH.tpersonal item){
            this.Motivos = Empresa.Citas.MotivoVisitas.GetInstance();
            this.Departamentos = Empresa.RHH.Departamento.GetInstance();
            this.Personal = Empresa.Citas.PersonalPreAsignado.GetInstance();
            this.Cita = new Empresa.Citas.TCitasVisitas(item);
            Persona = item;
            
            InitializeComponent();
        }
        public void Print(Empresa.Citas.TCitasVisitas item){
            try{
                //Empresa.Comun.ViewReportes vista = new Empresa.Comun.ViewReportes();
                //SIC.Objs.Citas.Reports.XtraTick proyec = new SIC.Objs.Citas.Reports.XtraTick();
                //proyec.bindingSource1.DataSource = item;
                //vista.PrintReporte(proyec);
            }
            catch{ 
            
            }
        }

        private void But_Finalizar_Click(object sender, RoutedEventArgs e){
            _citas = new Empresa.Citas.CitasVisitas();

            try {
                 //Fechas por defecto.
                 this.Cita.FechaEntrada = Empresa.Comun.Server.DameTiempo();
                 this.Cita.FechaSalida = this.Cita.FechaEntrada;
                 _citas.Insert(this.Cita);
                 
                 this.Print(this.Cita);
                 Finalizar(this.Cita);
            }
            catch {

            
            }
          
        }

    }
}

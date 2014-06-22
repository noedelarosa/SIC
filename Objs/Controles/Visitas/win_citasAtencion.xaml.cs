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

namespace SIC.Objs.Controles
{
    /// <summary>
    /// Interaction logic for win_citasAtencion.xaml
    /// </summary>
    public partial class win_citasAtencion : Window{
        private System.Windows.Threading.DispatcherTimer Tiempo;
        public Empresa.Citas.TCitasVisitas Cita { get; set; }
        private DateTime _horaactual;
        private bool _cerrar=true;

        public event DInicio Finalizando = delegate { };
        public event DInicio Cerrando = delegate { };

        public win_citasAtencion(){
            InitializeComponent();

            this._horaactual = Empresa.Comun.Server.DameTiempo(); 
            this.Tiempo = new System.Windows.Threading.DispatcherTimer();
            this.Tiempo.Interval = new TimeSpan(0, 0, 0, 6);
            this.Tiempo.Tick += Tiempo_Tick;
            this.txt_tiempoespero.Text = "0:0:0";
            
            this.Tiempo.Start();
        }

        public win_citasAtencion(Empresa.Citas.TCitasVisitas cita){
            this.Cita = cita;
            InitializeComponent();

            this._horaactual = Empresa.Comun.Server.DameTiempo();
            this.Tiempo = new System.Windows.Threading.DispatcherTimer();
            this.Tiempo.Interval = new TimeSpan(0, 0, 0, 6);
            this.Tiempo.Tick += Tiempo_Tick;
            this.txt_tiempoespero.Text = Empresa.Comun.Servicios.FechasDifencia(cita.FechaEntrada, _horaactual).ToStrings(Empresa.Comun.EnumFormatoTiempo.Hora);

            this.progreso1.Minimum = 0;
            this.progreso1.Maximum = cita.Motivo.Tiempo;

            this.Tiempo.Start();
        }

        public void Tiempo_Tick(object sedner, EventArgs e){
            Empresa.Comun.StFechasPartes parte = Empresa.Comun.Servicios.FechasDifencia(_horaactual, Empresa.Comun.Server.DameTiempo());
            if(parte.Minutos <= this.Cita.Motivo.Tiempo) progreso1.Value = parte.Minutos;
            Txt_Segundos.Text = parte.ToStrings(Empresa.Comun.EnumFormatoTiempo.Hora); 
        }

        private void But_Finalizar_Click(object sender, RoutedEventArgs e){
            this.Tiempo.Stop();
            _cerrar = false;

            this.Cita.Estado = new Empresa.Comun.TEstandar(3);
            //Disparando Evento
            this.Hide();
            this.Finalizando(this.Cita);
        }

        private void But_Cancelar_Click(object sender, RoutedEventArgs e){
            //Disparando Evento
            this.Tiempo.Stop();
            _cerrar = true;
            this.Hide();
            this.Cerrando(this.Cita);
        }

        private void win_citasatencioncontrol_Closed(object sender, EventArgs e){
            this.Tiempo.Stop();
            //Se cerror sin cambiar el estado, sin modificación.
            if (_cerrar) this.Cita.Estado = new Empresa.Comun.TEstandar(1);
        }

        public void Cerrar() {
            _cerrar = true;
            this.Close();
        }

    }
}

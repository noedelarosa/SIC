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
    /// Interaction logic for Dial_IndiqueSueldoDecreto.xaml
    /// </summary>
    public partial class Dial_IndiqueSueldoDecreto : Window
    {
        public bool EsEdicion = false;
        public bool EsValido { get; set; }
        public double SueldoDecreto {
            get {
                return Convert.ToDouble(Txt_SueldoDecreto.Text); 
            }
        }
        
        Empresa.Docente.TDecretoDocente DecretoDocente { get; set; }


        private const string __ValorPorcientoDefecto = "100";

        public Empresa.Docente.TDecreto Decreto { get; set; }
        public Empresa.Docente.tdocente Docente { get; set; }

        private Empresa.RHH.testadolaboral _tipo;
        public Empresa.RHH.testadolaboral Tipo {
            get {
                return _tipo;
            }
            set {
                _tipo = value;
            }
        }

        public Dial_IndiqueSueldoDecreto(){
            //inicializando propiedades
            this.EsValido = false;
            this.EsEdicion = false;
            this.Decreto = new Empresa.Docente.TDecreto();
            this.Docente = new Empresa.Docente.tdocente();
            
            InitializeComponent();
            Com_PJ.ItemsSource = Empresa.RHH.EstadoLaboral.GetInstance();
        }

        public Dial_IndiqueSueldoDecreto(Empresa.Docente.tdocente docente, Empresa.Docente.TDecreto decreto) {
            //inicializando propiedades
            this.EsValido = false;
            this.EsEdicion = false;

            this.Docente = docente;
            this.Decreto = decreto;

            InitializeComponent();
            Com_PJ.ItemsSource = Empresa.RHH.EstadoLaboral.GetInstance();

            //zona de calculos.
            //Calcular monto Promedio.
            CalcularMontoPromedio();
        }

        public Dial_IndiqueSueldoDecreto(Empresa.Docente.tdocente docente)
        {
            //inicializando propiedades
            this.EsValido = false;
            this.EsEdicion = true;
            this.Docente = docente;

            InitializeComponent();
            Com_PJ.ItemsSource = Empresa.RHH.EstadoLaboral.GetInstance();

            //zona de calculos.
            //Calcular monto Promedio.
            CalcularMontoPromedio();
        }

        private void CalcularMontoPromedio() {
            try
            {
                this.lbl_montopromedio.Text = Docente.HistorialPagos.PromedioUltimo(12, this.Decreto.FechaPromedio).ToString("n");
            }
            catch
            {
                this.lbl_montopromedio.Text = "0";
            }
        }

        private void But_Aceptar_Click(object sender, RoutedEventArgs e){
            try
            {
                if (Txt_SueldoDecreto.Text.Trim() == string.Empty) Txt_SueldoDecreto.Text = "0";
                if (string.IsNullOrEmpty(Txt_Porciento.Text)) Txt_Porciento.Text = "0";
                
                if(ch_NoSueldo.IsChecked.Value){
                    //Existe Sueldo
                    double __poricento =0;
                    if (double.TryParse(Txt_Porciento.Text, out __poricento))
                    {
                        if (Convert.ToDouble(Txt_SueldoDecreto.Text) == 0)
                        {
                            MessageBox.Show("Sueldo del decreto NO valido. indique un sueldo mayor de cero(0).", "Sueldo del decreto no valido.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            this.EsValido = false;
                        }
                        else
                        {
                            if (Com_PJ.SelectedItem != null)
                            {
                                if (((Empresa.RHH.testadolaboral)Com_PJ.SelectedItem).Id != 1)
                                {
                                    if (MessageBox.Show("Seguro que Desea asignarle al DOCENTE el siguiente Sueldo ; " + Txt_SueldoDecreto.Text + ", para su decreto, Afirmativo presione el boton 'Si',  de lo contrario presione el boton 'NO'", "Desea Asignarle el siguiente sueldo al docente: " + Txt_SueldoDecreto.Text + ", SI/NO", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {

                                        if (this.EsEdicion)
                                        {
                                            this.Docente.DecretoTransito.Monto = Convert.ToDouble(Txt_SueldoDecreto.Text);
                                            this.Docente.DecretoTransito.Estado = (Empresa.RHH.testadolaboral)Com_PJ.SelectedItem;
                                            this.Docente.DecretoTransito.Porciento = Convert.ToDouble(Txt_Porciento.Text);
                                        }
                                        else
                                        {
                                            this.Docente.Decretos.Add(new Empresa.Docente.TDecretoDocente(this.Decreto, Convert.ToDouble(Txt_SueldoDecreto.Text), (Empresa.RHH.testadolaboral)Com_PJ.SelectedItem, Convert.ToDouble(Txt_Porciento.Text)));
                                        }

                                        this.EsValido = true;
                                        this.Hide();
                                    }
                                    else{
                                        MessageBox.Show("Debe seleccionar Pensión o Jubilación, No Activo(a).", "Selección incorrecta(debe ser Pensionado o Jubilado)", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Debe Seleccionar un Tipo, para el docente. Pensión/Jubilación", "Falta Seleccionar Tipo(Pensionado o Jubilado)", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                        }
                    }
                    else {
                        MessageBox.Show("Debe introducir un porciento para calcular el monto del sueldo.", "Falta porciento.", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
                else {
                    //No Existe Sueldo.
                    if(MessageBox.Show("Desea ingresar este docente sin especificar el sueldo? Si/No", "Desea ingresar docente sin especificar el sueldo. Si/No", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        Txt_SueldoDecreto.Text = "0";
                        if (string.IsNullOrEmpty(Txt_Porciento.Text)) Txt_Porciento.Text = "0";

                        if (Com_PJ.SelectedItem != null )
                        {
                            if (((Empresa.RHH.testadolaboral)Com_PJ.SelectedItem).Id != 1)
                            {
                                if (this.EsEdicion)
                                {
                                    this.Docente.DecretoTransito.Monto = Convert.ToDouble(Txt_SueldoDecreto.Text);
                                    this.Docente.DecretoTransito.Estado = (Empresa.RHH.testadolaboral)Com_PJ.SelectedItem;
                                    this.Docente.DecretoTransito.Porciento = Convert.ToDouble(Txt_Porciento.Text);
                                }
                                else
                                {
                                    this.Docente.Decretos.Add(new Empresa.Docente.TDecretoDocente(this.Decreto, 0, (Empresa.RHH.testadolaboral)Com_PJ.SelectedItem, Convert.ToDouble(Txt_Porciento.Text)));
                                }
                                this.EsValido = true;
                                this.Hide();
                            }
                            else {
                                MessageBox.Show("Debe seleccionar Pensión o Jubilación, No Activo(a)", "Selección incorrecta(debe ser Pensionado o Jubilado)", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                        }
                        else{
                            MessageBox.Show("Debe Seleccionar un Tipo, para el docente. Pensión/Jubilación", "Falta Seleccionar Tipo(Pensionado o Jubilado)", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }

                    }
                }
            }
            
            catch {
                Txt_SueldoDecreto.Text = "0";
                MessageBox.Show("Verifique el monto indicado u otros datos suministrados.", "Verifique Monto", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void But_Salir_Click(object sender, RoutedEventArgs e){
            this.EsValido = false;
            this.Hide();
        }

        private void But_SueldoActualMismo_Click(object sender, RoutedEventArgs e){
            //Asignando ultimo sueldo de la nomina.
            this.Txt_SueldoDecreto.Text = lbl_montopromedio.Text; 
        }

        private void Com_PJ_SelectionChanged(object sender, SelectionChangedEventArgs e){
            _tipo = (Empresa.RHH.testadolaboral)Com_PJ.SelectedItem;
        }

        private void But_CalcularSueldoPromedio_Click(object sender, RoutedEventArgs e){
            try
            {
                if (Txt_Porciento.Text.Trim().Length == 0) Txt_Porciento.Text = "0";
                Txt_SueldoDecreto.Text = (Convert.ToDouble(lbl_montopromedio.Text) * (Convert.ToDouble(Txt_Porciento.Text) / 100)).ToString("n");
            }
            catch {
                Txt_SueldoDecreto.Text = string.Empty;
            } 
        }

        private void Txt_Porciento_KeyDown(object sender, KeyEventArgs e)
        {
            Txt_SueldoDecreto.Text = string.Empty;
        }

        private void but_promediotabla_Click(object sender, RoutedEventArgs e)
        {
            try{
                if (this.Docente != null){
                    if (this.Docente.EsDocente)
                    {
                        Dialogos.win_mostrar_promedio_salarial __pro = new Dialogos.win_mostrar_promedio_salarial(this.Docente);
                        __pro.ShowDialog();
                        __pro.Close();
                    }
                    else {
                        MessageBox.Show("El promedio salaria solo es para los docentes.", "Solo docente(s)", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch{

            }

        }

   

    }
}

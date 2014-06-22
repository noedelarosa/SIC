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

namespace SIC.Objs.Controles.SeguroFunerario
{
    /// <summary>
    /// Interaction logic for us_cambiar_estado_pagado.xaml
    /// </summary>
    public partial class us_cambiar_estado_pagado : UserControl
    {
        private Empresa.Docente.SeguroFunerario _sol;
        private BackgroundWorker bw = new BackgroundWorker();
        private SIC.Objs.Controles.Dialogos.Dial_Espera _espera = new Dialogos.Dial_Espera();

        public us_cambiar_estado_pagado()
        {
            InitializeComponent();
            _sol = new Empresa.Docente.SeguroFunerario();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            com_estadopago.ItemsSource = Empresa.Comun.EstadoPago.GetInstance().Lista; 
        }

        private void But_Guardar_Click(object sender, RoutedEventArgs e)
        {
            SIC.Objs.Controles.Dialogos.Dial_confirmacion_cambio_estado_sf __cmestado = new Dialogos.Dial_confirmacion_cambio_estado_sf();
            try
            {
                _espera.Show();
                //Reasignacion de estado.
                this.datagrid1.EndEdit();
                this.datagrid1.Items.Refresh();
                __cmestado.ShowDialog();
                if (__cmestado.Resultado == MessageBoxResult.Yes){
                    foreach (Empresa.Docente.tsolicitudfunenario item in this.datagrid1.Items)
                    {
                        if (item.EsPago) item.EstadoPago = new Empresa.Comun.TEstandar(2);
                        _sol.CambioEstadoPago(item);
                    }
                    But_ReCarga_Click(null, null);
                }
                __cmestado.Close();
                //Busqueda
            }
            catch
            {
                __cmestado.Close();
                _espera.Hide();
                
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e){

            bool esfecha = Convert.ToBoolean(((object[])e.Argument)[0]);
            Empresa.Comun.TEstandar estado =     (Empresa.Comun.TEstandar)((object[])e.Argument)[1];
            Empresa.Comun.TEstandar estadopago = (Empresa.Comun.TEstandar)((object[])e.Argument)[2];

            if(esfecha){
                DateTime finicio = Convert.ToDateTime(((object[])e.Argument)[3]);
                DateTime ffinal = Convert.ToDateTime(((object[])e.Argument)[4]);
                e.Result = new Empresa.Docente.SeguroFunerario(estado, estadopago, finicio, ffinal).Lista;
            }
            else{
                e.Result = new Empresa.Docente.SeguroFunerario(estado, estadopago).Lista;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            this.DataContext = e.Result;
            _espera.Hide();
        }

        private void But_ReCarga_Click(object sender, RoutedEventArgs e)
        {
            try {
                //Busqueda.
                _espera.Show();

                if (ch_habilitar_control_contenido.IsChecked.Value == true){
                    //Busque por fecha
                    bw.RunWorkerAsync(new object[5] { true, new Empresa.Comun.TEstandar(3), com_estadopago.SelectedItem == null ? new Empresa.Comun.TEstandar() : com_estadopago.SelectedItem, dp_finicio.SelectedDate.Value, dp_ffinal.SelectedDate.Value });
                }
                else {
                    bw.RunWorkerAsync(new object[5] { false, new Empresa.Comun.TEstandar(3), com_estadopago.SelectedItem == null ? new Empresa.Comun.TEstandar() : com_estadopago.SelectedItem, string.Empty, string.Empty });
                }

            }
            catch{
                _espera.Hide();
                MessageBox.Show("Verifique los argumentos(fecha).", "Verifique los argumentos.",MessageBoxButton.OK,MessageBoxImage.Stop);
            }
        }
        Empresa.Comun.ViewReportes view;
        private void But_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            if (com_estadopago.SelectedItem != null)
            {
                SIC.Objs.Controles.Dialogos.seleccion_impresion_cambio_estado_sf __winselec = new Dialogos.seleccion_impresion_cambio_estado_sf();
                __winselec.ShowDialog();

                try
                {
                    
                    if (__winselec.EsValido == true){
                        //Seleccion de tipo de reporte.
                        switch (__winselec.Seleccion)
                        {
                            case Dialogos.seleccion_impresion_cambio_estado_sf.enum_seleccion_impresion_cambio_estado_sf.listado:
                                SIC.Objs.Docentes.Reportes.Xtra_SeguroFunerarioListado _list = new Docentes.Reportes.Xtra_SeguroFunerarioListado();
                                _list.Parameters[0].Value = ((Empresa.Comun.TEstandar)com_estadopago.SelectedItem).Nombre;

                                Empresa.Docente.SeguroFunerario result = new Empresa.Docente.SeguroFunerario();

                                foreach (Empresa.Docente.tsolicitudfunenario item in this.datagrid1.Items)
                                {
                                    result.Lista.Add(item);
                                }

                                _list.bindingSource1.DataSource = result;
                                view = new Empresa.Comun.ViewReportes();
                                view.MostarReporte(_list);

                                break;
                            case Dialogos.seleccion_impresion_cambio_estado_sf.enum_seleccion_impresion_cambio_estado_sf.resumen:
                                break;
                        }
                    }
                    __winselec.Close();
                }
                catch{
                    __winselec.Close();
                }

            }
            else {
                MessageBox.Show("Debe seleccionar un estado de pago", "Debe seleccionar un estado de pago.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void But_EstadoLimpiar_Click(object sender, RoutedEventArgs e)
        {
            com_estadopago.SelectedIndex = -1;
        }

    }
}

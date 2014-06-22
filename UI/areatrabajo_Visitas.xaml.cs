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

namespace SIC.UI
{
    /// <summary>
    /// Interaction logic for areatrabajo.xaml
    /// </summary>
    public partial class areatrabajo_Visitas : UserControl
    {
        public areatrabajo_Visitas()
        {
            InitializeComponent();

            us_buscandoPersona.EsResultadoPersona += ResultadoBusquedaPersona;
            us_buscandoPersona.EsLimpiadoPersona += usc_buscardocente_EsLimpiado_1;
            
            //Motivos Citas.
            citas_motivos = new Objs.Controles.us_CitasMotivos();

            us_buscandoPersona.But_MotivosCitas.Click += But_CitasMotivos_Click;
            us_buscandoPersona.But_Atension.Click += But_Atencion_Click;
            us_buscandoPersona.But_Indicadores.Click += But_Indicadores_Click;
            us_buscandoPersona.But_Monitore.Click += But_Monitoreo_Click;
            us_buscandoPersona.But_Mostrador.Click += But_Mostrador_Click;

            try{
                pag_trans.ShowPage(scn);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message); 
            }

        }

        public enum ESeleccion{
            SOLICITUDPJ,
            SCAN,
            PRESENTACION,
            DISCAPACIDAD
        }

        public ESeleccion SeleccionActual;

        private SIC.Objs.Controles.us_CitasUsuarios citas_paso_1;
        private SIC.Objs.Controles.us_citas citas_paso_2;
        private SIC.Objs.Controles.us_CitasMotivos citas_motivos;
        private SIC.Objs.Controles.CitasAtension Citas_Atension_01;
        private SIC.Objs.Controles.us_indicadores _indicadores;
        private SIC.Objs.Controles.us_citasMonitoreo _monitoreo;
        private SIC.Objs.Controles.Dialogos.Dial_Config_CitasMostrador  _confgmostrador;
        private Objs.Controles.us_VisorDocente _visordocente;


        private SIC.Objs.Controles.Screenw scn = new SIC.Objs.Controles.Screenw();

        private void ResultadoBusquedaPersona(object sender, RoutedEventArgs arg){
            citas_paso_1 = new Objs.Controles.us_CitasUsuarios(us_buscandoPersona.Persona);
            citas_paso_1.EventSiguiente += But_Siguiente_Click;
            pag_trans.ShowPage(citas_paso_1);
        }

        private void usc_buscardocente_EsLimpiado_1(object sender, RoutedEventArgs e){
            try {
                if (citas_paso_1 != null) citas_paso_1 = null;
                if (citas_paso_2 != null) citas_paso_2 = null;

                pag_trans.ShowPage(scn);
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
         }

        private void But_Siguiente_Click(object sender, EventArgs e){
           Empresa.RHH.tpersonal resultado = (Empresa.RHH.tpersonal)sender;
            
           citas_paso_2 = new Objs.Controles.us_citas(resultado);
           citas_paso_2.Finalizar += FinalizandoPaso2;
           
           pag_trans.ShowPage(citas_paso_2);
       }

        private void But_Imprimir_Click(object sender, System.Windows.RoutedEventArgs e){
       	// TODO: Add event handler implementation here.
		//impresion de documento
           try{
                switch (this.SeleccionActual)
                {
                   case ESeleccion.SOLICITUDPJ:
                       //proc.Imprimir();
                       break;
                   case ESeleccion.DISCAPACIDAD:
                       //visps.Imprimir();
                       break;
                }
           }
           catch (Exception ex) {
               MessageBox.Show("Verifique la seleccion del documento", "Documento no seleccionado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
           }
       }

        private void But_CitasMotivos_Click(object sender, System.Windows.RoutedEventArgs e) {
           try{
               pag_trans.ShowPage(this.citas_motivos);
           }
           catch {
           
           } 
       }

        private void EstadoDocente_Carga(object sender) {
            try
            {
                _visordocente = new Objs.Controles.us_VisorDocente((Empresa.Citas.TCitasVisitas)sender);
                pag_trans.ShowPage(this._visordocente);
            }
            catch{

            }
        }

        private void But_Atencion_Click(object sender, System.Windows.RoutedEventArgs e){
            try{
                Citas_Atension_01 = new Objs.Controles.CitasAtension();
                Citas_Atension_01.NotificancionCargaEstado += EstadoDocente_Carga;

                pag_trans.ShowPage(this.Citas_Atension_01);
            }
            catch{

            }
        }

        private void But_Indicadores_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try{
                _indicadores = new Objs.Controles.us_indicadores();
                pag_trans.ShowPage(this._indicadores);
            }
            catch{
            }
        
        }

        public void FinalizandoPaso2(object sender){
           us_buscandoPersona.Limpiar();
           us_buscandoPersona.DefaultFocus();
       }

        private void But_Monitoreo_Click(object sender, RoutedEventArgs e) {
            try{
                _monitoreo = new Objs.Controles.us_citasMonitoreo();
                pag_trans.ShowPage(this._monitoreo);
            }
            catch{

            }
        }

        private void But_Mostrador_Click(object sender, RoutedEventArgs e){
            try{
                _confgmostrador = new Objs.Controles.Dialogos.Dial_Config_CitasMostrador();
                _confgmostrador.Show();
                //pag_trans.ShowPage(this._confgmostrador);
            }
            catch {

            }
        }

        private void But_Nuevo_Click(object sender, RoutedEventArgs e){
            _indicadores.NewItem();
        }

    }




    
}

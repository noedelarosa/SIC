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
    /// Interaction logic for us_fallecidos_nomina.xaml
    /// </summary>
    public partial class us_fallecidos_nomina : UserControl
    {
        //Comun_View_Notificados_UltimaNomina

        private BackgroundWorker __bw;
        private SIC.Objs.Controles.Dialogos.Dial_Espera _espera;

        public us_fallecidos_nomina(){
            InitializeComponent();

            __bw = new BackgroundWorker();
            __bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            __bw.DoWork += bw_DoWork;

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e){
            e.Result = new Empresa.Docente.Nomina().DameNotificadosFallecidos();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {






        }



    }
}

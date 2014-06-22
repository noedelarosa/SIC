using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Empresa.Comun
{
    public class ViewReportes
    {
        public void MostarReporte(DevExpress.XtraReports.UI.XtraReport reporte) {
            reporte.CreateDocument();
            DevExpress.Xpf.Printing.XtraReportPreviewModel modelo = new DevExpress.Xpf.Printing.XtraReportPreviewModel(reporte);
            modelo.AutoShowParametersPanel = false;
            modelo.IsParametersPanelVisible = false;
            //Ocultando cada paraemtros
           foreach(DevExpress.XtraReports.Parameters.Parameter par in reporte.Parameters){
            par.Visible = false;
           }
           DevExpress.Xpf.Printing.DocumentPreviewWindow prevista = new DevExpress.Xpf.Printing.DocumentPreviewWindow() { Model = modelo };
           prevista.Show();
           modelo.Dispose();
        }

        public void CargaReporte(DevExpress.XtraReports.UI.XtraReport reporte)
        {
            reporte.CreateDocument();
            DevExpress.Xpf.Printing.XtraReportPreviewModel modelo = new DevExpress.Xpf.Printing.XtraReportPreviewModel(reporte);
            modelo.AutoShowParametersPanel = false;
            modelo.IsParametersPanelVisible = false;
            //Ocultando cada paraemtros
            foreach (DevExpress.XtraReports.Parameters.Parameter par in reporte.Parameters)
            {
                par.Visible = false;
            }
            DevExpress.Xpf.Printing.DocumentPreviewWindow prevista = new DevExpress.Xpf.Printing.DocumentPreviewWindow() { Model = modelo };
        }

        public void PrintReporte(DevExpress.XtraReports.UI.XtraReport reporte)
        {
            reporte.CreateDocument();
            DevExpress.Xpf.Printing.XtraReportPreviewModel modelo = new DevExpress.Xpf.Printing.XtraReportPreviewModel(reporte);
            modelo.AutoShowParametersPanel = false;
            modelo.IsParametersPanelVisible = false;
            //Ocultando cada paraemtros
            foreach (DevExpress.XtraReports.Parameters.Parameter par in reporte.Parameters)
            {
                par.Visible = false;
            }
            //DevExpress.Xpf.Printing.DocumentPreviewWindow prevista = new DevExpress.Xpf.Printing.DocumentPreviewWindow() { Model = modelo };
            modelo.PrintDirect();
        }

    }
}

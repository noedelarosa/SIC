using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace SIC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application{
        
        public App() {
            try{
                //Zona de carga
                ConectionString.ManagerString.SetConeccionString("INABIMA", "10.0.0.252", "INABIMA", "Ks35EfR3aA", "sa", false);
                //Agregando licencia del Xceed Grid.
                Xceed.Wpf.DataGrid.Licenser.LicenseKey = "DGP40-ETNBJ-TMBWP-3NXA";
                //Tomando Id Del procesador.
                GlobalItems.IDProcesor = Empresa.Comun.Servicios.DameIdProcesador();
                //Inicializando cultura por defecto.
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-DO");
                if (!System.IO.Directory.Exists(GlobalItems.____cd_tempdirectorio)) System.IO.Directory.CreateDirectory(GlobalItems.____cd_tempdirectorio);

                Empresa.Comun.Unidad_LLaves un = new Empresa.Comun.Unidad_LLaves();
                un.GetUniqueId();



            }
            catch {
                    MessageBox.Show("Aviso la aplicación no puede ejecutarse.", "Programa no se puede Ejecutar", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Application.Current.Shutdown(); 
            }

        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
           
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ///Registro de Evento
            Empresa.RegistroEventos.Evento.Insert(new Empresa.RegistroEventos.tevento(string.Empty, string.Empty, string.Empty, new Empresa.RegistroEventos.ttarea(Empresa.RegistroEventos.EnumIdentificadorTarea.CerrandoSessionUsuario), new Empresa.Usuarios.TUsuario(), GlobalItems.IDProcesor, Environment.MachineName, Environment.UserDomainName));
        }
    }
}

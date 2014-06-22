using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;


namespace Empresa.RegistroEventos
{
    public class Log
    {
         private const string _NOMBREARCHIVO = "log_sistema.xml";

        public List<tlog> Lista { get; set; }

        private void Existe() {
            if (!File.Exists(_NOMBREARCHIVO)) {
                File.Create(_NOMBREARCHIVO);
            }
        }

        public Log(DateTime fechahora) {
            this.Lista = new List<tlog>();
            this.Existe();
        }

        public Log() {
            this.Lista = new List<tlog>();
            this.Existe(); 
        }

        public static void Escribir() {
            XmlDocument doc = new XmlDocument();
            


            
        }


    }
}

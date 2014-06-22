using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Empresa.Comun
{
    public class tdocumentosc {

        public int Id { get; set; }
        public string Nombre { get; set;        }
        public byte[] Imagen { get; set;        }
        public BitmapSource ImgDoc { get; set;  }
        public string Detalles { get; set;      }

        public tdocumentosc() {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Imagen = new byte[]{};
            //this.ImgDoc = (BitmapSource)new object();
            this.Detalles = string.Empty;
        }

        public tdocumentosc(int id)
        {

        

        }


    }
}

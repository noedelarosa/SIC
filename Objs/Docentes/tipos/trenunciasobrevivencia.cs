using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Empresa.Docente
{
    public class trenunciasobrevivencia: Empresa.Comun.TEstandar
    {
        public DateTime Fecha { get; set; }
        public byte[] Foto { get; set; }
        public tdocente Docente { get; set; }

        BitmapSource _AImagen;
        public BitmapSource AImagen
        {
            get
            {
                _AImagen = WorkImage.ToImage(this.Foto, TypeImagen.JPG);
                return _AImagen;
            }
            set { this.Foto = WorkImage.GetArray(_AImagen); }
        }

        public trenunciasobrevivencia(){
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Mus = new object();
            this.Fecha = DateTime.MinValue;
        }

        public trenunciasobrevivencia(string cedula)
        {
            this.Docente = new tdocente();
            this.Docente.Cedula = cedula;
        }

    }
}

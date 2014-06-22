using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Comun
{
    public class timpresiondocumento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdSolicitudSeguroFunerario { get; set; }
        public int IdSolcitudPesionJubilacion { get; set; }
        public int IdUsuario { get; set; }

        public string Comentario { get; set; }

        public Empresa.Docente.EnumDocumento Documento { get; set; }
        
        //

        public timpresiondocumento() {
            this.Id = 0;
            this.Fecha = DateTime.Now;
            this.IdSolcitudPesionJubilacion = 0;
            this.IdSolicitudSeguroFunerario = 0;
            this.IdUsuario = 0;
            this.Comentario = string.Empty;
        }

        public timpresiondocumento(int id)
        {
            this.Id = id;
            this.Fecha = DateTime.Now;
            this.IdSolcitudPesionJubilacion = 0;
            this.IdSolicitudSeguroFunerario = 0;
            this.IdUsuario = 0;
            this.Comentario = string.Empty;
        }

        public timpresiondocumento(int id, int idsolicitudsegurofunerario, int idsolicitudpensionjubilacion, int idusuario)
        {
            this.Id = id;
            this.Fecha = DateTime.Now;
            this.IdSolcitudPesionJubilacion = idsolicitudpensionjubilacion;
            this.IdSolicitudSeguroFunerario = idsolicitudsegurofunerario;
            this.IdUsuario = idusuario;
        }

        public timpresiondocumento(int idsolicitudsegurofunerario, int idsolicitudpensionjubilacion, int idusuario)
        {
            this.Id = 0;
            this.Fecha = DateTime.Now;
            this.IdSolcitudPesionJubilacion = idsolicitudpensionjubilacion;
            this.IdSolicitudSeguroFunerario = idsolicitudsegurofunerario;
            this.IdUsuario = idusuario;
        }

        public timpresiondocumento(int idsolicitudsegurofunerario, int idsolicitudpensionjubilacion, int idusuario,string comentario, Empresa.Docente.EnumDocumento documento)
        {
            this.Id = 0;
            this.Fecha = DateTime.Now;
            this.IdSolcitudPesionJubilacion = idsolicitudpensionjubilacion;
            this.IdSolicitudSeguroFunerario = idsolicitudsegurofunerario;
            this.IdUsuario = idusuario;
            this.Comentario = comentario;
            this.Documento = documento;
        }


    }
}

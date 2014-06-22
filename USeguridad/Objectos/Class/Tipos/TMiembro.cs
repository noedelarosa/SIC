using System;
using System.Collections.Generic;
namespace Empresa.USeguridad
{
    public class TMiembro
    {
        public int Id { get; set; }
        public List<TGrupo> Grupos { get; set; }
        public int IDUsuario { get; set; }
        public TMiembro() { }
        public TMiembro(List<TGrupo> grupos, int idusuario) {
            this.Grupos = grupos;
            this.IDUsuario = idusuario;
        }
    }
}

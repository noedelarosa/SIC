using System;
using System.Collections.Generic;
namespace Empresa.USeguridad
{
    public class Miembro
    {
        public int Id { get; set; }
        public List<TGrupo> Grupos { get; set; }
        public int IDUsuario { get; set; }
        private SSData.Servicios consulta;

        public Miembro() {
            this.Id = 0;
            this.Grupos = new List<TGrupo>();
            this.IDUsuario = 0;        
        }
        public Miembro(int idusuario){ 
            //this.Grupos  = new List<TGrupo>();
            //gr = Empresa.USeguridad.Grupos.GetInstance();
            //foreach(TGrupo item in Empresa.USeguridad.Grupos.GetInstance(idusuario)){
            //    this.Grupos.Add(item); 
            //}

            Grupos = new List<TGrupo>();
            this.IDUsuario = idusuario;
            //Empresa.USeguridad.Grupos grupos = Empresa.USeguridad.Grupos.GetInstance(); 
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usua_id", this.IDUsuario);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[inventario].dbo.Com_ViewUsuarioGrupoAsignadoU", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                this.Grupos.Add(Empresa.USeguridad.Grupos.GetInstance(Convert.ToInt32(fila["grup_id"]))[0]);
            }

        }

        public Miembro(List<TGrupo> grupos, int idusuario){
            this.Grupos = grupos;
            this.IDUsuario = idusuario;
        }

        public void Agregate(Miembro item) {
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (TGrupo gr in item.Grupos)
            {
                consulta.Parameters.Add("@usua_id", item.IDUsuario);
                consulta.Parameters.Add("@grup_id", gr.Id);
                consulta.Execute.NoQuery("[inventario].dbo.Com_InsertUsuarioGrupoAsignado", System.Data.CommandType.StoredProcedure);
                consulta.Parameters.ClerAll();
            }
        }

        public void Agregate(int Idusuario, TGrupo grupo){

            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);            
            consulta.Parameters.Add("@usua_id", Idusuario);
            consulta.Parameters.Add("@grup_id", grupo.Id);
            if (consulta.Execute.NoQuery("[inventario].dbo.Com_InsertUsuarioGrupoAsignado", System.Data.CommandType.StoredProcedure)) this.Grupos.Add(grupo);
        }


        public void Remove(Miembro item){
            consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            foreach (TGrupo gr in item.Grupos)
            {
                consulta.Parameters.Add("@usua_id", item.IDUsuario);
                consulta.Parameters.Add("@grup_id", gr.Id);
                consulta.Execute.NoQuery("[inventario].dbo.Com_DeleteUsuarioGrupoAsignado", System.Data.CommandType.StoredProcedure);
                consulta.Parameters.ClerAll();
            }
        }

        public void Remove(TGrupo grupo){
                consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
                consulta.Parameters.Add("@usua_id", this.IDUsuario);
                consulta.Parameters.Add("@grup_id", grupo.Id);
                consulta.Execute.NoQuery("[inventario].dbo.Com_DeleteUsuarioGrupoAsignado", System.Data.CommandType.StoredProcedure);

        }

    }
}

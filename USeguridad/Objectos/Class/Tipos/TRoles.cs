using System;
using System.Collections.Generic;
namespace Empresa.USeguridad
{
    public class TRoles {
      public int Id { get; set;  }
      public TRol Rol { get; set; }
      public List<TRecurso> Recurso { get; set; }

      Autorizacion _Autorizaciones;

      public Autorizacion Autorizaciones {
          get {
              return _Autorizaciones;
          }
          set{
              _Autorizaciones = value;
          }
      }
      public TGrupo Grupo { get; set; }
      
      public TRoles(){
          Id = 0;
          Rol = new TRol();
          Recurso = new List<TRecurso>(); //recursos asignados
          _Autorizaciones = new Autorizacion();
      }

      public TRoles(int id, TRol rol, List<TRecurso> recurso){
          this.Id = id;
          this.Rol = rol;
          this.Recurso = recurso;
          _Autorizaciones = new Autorizacion(this.Rol.Id);
      }

      public TRoles(int id, TRol rol, List<TRecurso> recurso, TGrupo grupo){
          this.Id = id;
          this.Rol = rol;
          this.Recurso = recurso;
          this.Grupo = grupo;
          _Autorizaciones = new Autorizacion(this.Rol.Id);
      }

      public TRoles(TRol rol, TGrupo grupo)
      {
          this.Id = 0;
          this.Rol = rol;
          this.Recurso = new List<TRecurso>();
          this.Grupo = grupo;
          _Autorizaciones = new Autorizacion(this.Rol.Id);
      }

      public TRoles(int id, TRol rol) {
          this.Id = id;
          this.Rol = rol;
          _Autorizaciones = new Autorizacion(this.Rol.Id);
      }

      public TRoles(TRol rol){
          this.Rol = rol;
      }

      public TRoles(TRol rol, List<TRecurso> recurso){
          this.Rol = rol;
          this.Recurso = recurso;
      }

    }
}

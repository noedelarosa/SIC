using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa.Usuarios
{
    public static class Seccion {
        private static bool _EsAutenticado= false; 
        public static bool EsAutenticado { 
            get {              
                return _EsAutenticado; 
          }
        }

        private static TUsuario _Usuario;
      
        public static TUsuario Usuario{
            get{
                return _Usuario;
            }
            set{
                _Usuario = value;
            }
        }

        public static void Iniciar(string nombre,string clave){
           Autenticar Auten = new Autenticar(nombre, clave);
          _EsAutenticado = Auten.IsAutenticado;
           if(_EsAutenticado){
                _Usuario = Auten.Usuario;
          }
        }

        public static void Cerrar(){
            _EsAutenticado = false;
            _Usuario = null;
        }

        public static void Finalizar(){
            Cerrar();
        }

        public static bool PermisoAutorizado(string codigo, Empresa.USeguridad.TPermiso Permiso) {
            //var r = Usuario.Miembro;
            foreach (USeguridad.TGrupo tg in Usuario.Miembro.Grupos)
            {
                foreach (KeyValuePair<int, USeguridad.TRoles> trs in tg.Role)
                {
                    foreach (KeyValuePair<int, USeguridad.TAutorizacion> aut in trs.Value.Autorizaciones)
                    {
                            if (aut.Value.Recurso.Codigo.Equals(codigo))           {
                                if (aut.Value.Boleto.Permiso.Id.Equals(Permiso.Id)){
                                    
                                    if (aut.Value.Boleto.Accion.Id.Equals(1)){
                                        return false;
                                    }
                                    else{
                                        return true;
                                    }

                                }
                                else{
                                    return false;
                                }
                            }
                        }
                    }
                }
            
            
            return false;
        }


        public static bool PermisoAutorizado(string codigo, USeguridad.TBoleto boleto)
        {
            //var r = Usuario.Miembro;
            foreach (USeguridad.TGrupo tg in Usuario.Miembro.Grupos)
            {
                foreach (KeyValuePair<int, USeguridad.TRoles> trs in tg.Role)
                {
                    foreach (KeyValuePair<int, USeguridad.TAutorizacion> aut in trs.Value.Autorizaciones)
                    {
                        if (aut.Value.Recurso.Codigo.Equals(codigo))
                        {
                            if (aut.Value.Boleto.Permiso.Id.Equals(boleto.Permiso.Id)){
                                if (aut.Value.Boleto.Accion.Id.Equals(boleto.Accion.Id)){
                                    return true;
                                }
                                else{
                                    return false;
                                }
                            }
                            else{
                                return false;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}

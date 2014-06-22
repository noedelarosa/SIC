using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.RegistroEventos
{
    public class Evento
    {
        public ObservableCollection<tevento> Lista { get; set; }
        public Evento(Empresa.Usuarios.TUsuario usuario) {
            tevento __evento;
            Empresa.Usuarios.TUsuario __usuario;
            this.Lista = new ObservableCollection<tevento>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usua_id", usuario.Id);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_SistemaEventos_usuario]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
                {
                    __evento = new tevento();
                    
                    __evento.IdProcesador = fila["even_idprocesador"].ToString();
                    __evento.Modulo = fila["even_modulo"].ToString();
                    __evento.NombreComputadora = fila["even_computadora"].ToString();
                    __evento.NombreUsuario = fila["even_usuario"].ToString();
                    __evento.Objecto = fila["even_objecto"].ToString();
                    __evento.Referencia = fila["even_referencia"].ToString();
                    __evento.Fecha = Convert.ToDateTime (fila["even_fecha"].ToString());
                    __evento.Tarea = Tarea.GetInstance().GetItem(Convert.ToInt32(fila["tar_id"]));

                    __usuario = new Usuarios.TUsuario();
                    __usuario.Personal = new RHH.tpersonal();
                    __usuario.Id = Convert.ToInt32(fila["id"]);
                    __usuario.Nombre = fila["nombreusuario"].ToString();
                    __usuario.PClave = fila["pclave"].ToString();
                    __usuario.Personal.Nombres = fila["nombres"].ToString();
                    __usuario.Personal.Cedula = fila["cedula"].ToString();
                    
                    //Asignando departamento a usuario.
                    __usuario.Personal.Departamento = new RHH.TDepartamento();
                    __usuario.Personal.Departamento.Nombre = fila["departamento"].ToString();
                    
                    //Asignado usuario a envento
                    __evento.Usuario = __usuario;

                    //Agregando a la lista.
                    this.Lista.Add(__evento);
                }
        }

        //public Evento(Empresa.Usuarios.TUsuario usuario, DateTime fechainicio){
        //}

        public Evento(Empresa.Usuarios.TUsuario usuario, DateTime fechainicio, DateTime fechafinal){

            tevento __evento;
            Empresa.Usuarios.TUsuario __usuario;
            this.Lista = new ObservableCollection<tevento>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@usua_id", usuario.Id);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Comun_SistemaEventos_usuario]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                __evento = new tevento();

                __evento.IdProcesador = fila["even_idprocesador"].ToString();
                __evento.Modulo = fila["even_modulo"].ToString();
                __evento.NombreComputadora = fila["even_computadora"].ToString();
                __evento.NombreUsuario = fila["even_usuario"].ToString();
                __evento.Objecto = fila["even_objecto"].ToString();
                __evento.Referencia = fila["even_referencia"].ToString();
                __evento.Fecha = Convert.ToDateTime(fila["even_fecha"].ToString());
                __evento.Tarea = Tarea.GetInstance().GetItem(Convert.ToInt32(fila["tar_id"]));

                __usuario = new Usuarios.TUsuario();
                __usuario.Personal = new RHH.tpersonal();
                __usuario.Id = Convert.ToInt32(fila["id"]);
                __usuario.Nombre = fila["nombreusuario"].ToString();
                __usuario.PClave = fila["pclave"].ToString();
                __usuario.Personal.Nombres = fila["nombres"].ToString();
                __usuario.Personal.Cedula = fila["cedula"].ToString();

                //Asignando departamento a usuario.
                __usuario.Personal.Departamento = new RHH.TDepartamento();
                __usuario.Personal.Departamento.Nombre = fila["departamento"].ToString();

                //Asignado usuario a envento
                __evento.Usuario = __usuario;

                //Agregando a la lista.
                this.Lista.Add(__evento);
            }

        }


        public static void Insert(tevento evento){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@even_descripcion", evento.Descripcion);
            consulta.Parameters.Add("@even_referencia", evento.Referencia);
            consulta.Parameters.Add("@tar_id ", evento.Tarea.Id);
            consulta.Parameters.Add("@usua_id", evento.Usuario.Id);
            consulta.Parameters.Add("@even_idprocesador", evento.IdProcesador);
            consulta.Parameters.Add("@even_usuario", evento.NombreUsuario);
            consulta.Parameters.Add("@even_computadora", evento.NombreComputadora);
            consulta.Parameters.Add("@even_modulo", evento.Modulo);
            consulta.Parameters.Add("@even_objecto", evento.Objecto);
            consulta.Execute.NoQuery("dbo.Comun_SistemaEventos_Insert", System.Data.CommandType.StoredProcedure);
        }


    }
}

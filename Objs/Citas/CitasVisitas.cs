using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.Citas
{
    
    public class CitasVisitas {
        public ObservableCollection<TCitasVisitas> Lista {get;set;}

        public CitasVisitas(){
            





        }
        
        Empresa.Citas.Valoraciones _valoraciones = new Valoraciones();
        public CitasVisitas(Empresa.Comun.TEstandar estado)
        {
            Lista = new ObservableCollection<TCitasVisitas>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            TCitasVisitas _cita;
            RHH.tpersonal _visitante;
            RHH.tpersonal _personal;

            MotivoVisitas _motivos = MotivoVisitas.GetInstance();
            EstadoVisita _estado = EstadoVisita.GetInstance();

            consulta.Parameters.Add("@cite_id", estado.Id);
            
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Citas_Visitas_ViewEstado", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                _cita = new TCitasVisitas();

                _cita.Id = Convert.ToInt32(fila["cit_id"]);
                _cita.Motivo = _motivos.GetItem(Convert.ToInt32(fila["motc_id"]));
                _cita.Numero = fila["cit_numero"].ToString();
                _cita.FechaEntrada = Convert.ToDateTime (fila["cit_fechaentrada"]);
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechasalida"]);
                _cita.ExisteHistorico = Convert.ToInt32(fila["cit_existe"]);
                _cita.Referencia = fila["cit_referencia"].ToString();
                _cita.Estado = _estado.GetItem(estado.Id);

                 //Recuperando Visitante.
                _visitante = new RHH.tpersonal();
                _visitante.Nombres = fila["cit_nombres"].ToString();
                _visitante.Cedula = fila["cit_cedula"].ToString();
                _visitante.EsMasculino = Convert.ToBoolean(fila["cit_esmasculino"]);
                _visitante.Foto = new Empresa.RHH.Persona(_visitante.Cedula)[0].Foto;
                _cita.Visitante = _visitante;

                //Recuperando Personal
                //_cita.Personal = new RHH.Personal(Convert.ToInt32(fila["per_id"])).PrimerItem();
                
                _cita.Personal = PersonalPreAsignado.GetInstance().GetItem(fila["per_cedula"].ToString());
                this.Lista.Add(_cita);
            }
        }

        public CitasVisitas(Empresa.Comun.TEstandar estado, DateTime fecha)
        {
            Lista = new ObservableCollection<TCitasVisitas>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            TCitasVisitas _cita;
            RHH.tpersonal _visitante;
            RHH.tpersonal _personal;

            MotivoVisitas _motivos = MotivoVisitas.GetInstance();
            EstadoVisita _estado = EstadoVisita.GetInstance();

            consulta.Parameters.Add("@cite_id", estado.Id);
            consulta.Parameters.Add("@cit_fecha", fecha);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("dbo.Citas_Visitas_ViewEstadoFecha", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                _cita = new TCitasVisitas();

                _cita.Id = Convert.ToInt32(fila["cit_id"]);
                _cita.Motivo = _motivos.GetItem(Convert.ToInt32(fila["motc_id"]));
                _cita.Numero = fila["cit_numero"].ToString();
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechaentrada"]);
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechasalida"]);
                _cita.ExisteHistorico = Convert.ToInt32(fila["cit_existe"]);
                _cita.Referencia = fila["cit_referencia"].ToString();
                _cita.Estado = _estado.GetItem(estado.Id);

                //Recuperando Visitante.
                _visitante = new RHH.tpersonal();
                _visitante.Nombres = fila["cit_nombres"].ToString();
                _visitante.Cedula = fila["cit_cedula"].ToString();
                _visitante.EsMasculino = Convert.ToBoolean(fila["cit_esmasculino"]);
                _visitante.Foto = new Empresa.RHH.Persona(_visitante.Cedula)[0].Foto;
                _cita.Visitante = _visitante;

                //Recuperando Personal
                //_cita.Personal = new RHH.Personal(Convert.ToInt32(fila["per_id"])).PrimerItem();

                _cita.Personal = PersonalPreAsignado.GetInstance().GetItem(fila["per_cedula"].ToString());
                this.Lista.Add(_cita);
            }
        }

        public CitasVisitas(Empresa.Comun.TEstandar estado, Empresa.Comun.tbasepersona usuario) {

            Lista = new ObservableCollection<TCitasVisitas>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            TCitasVisitas _cita;
            RHH.tpersonal _visitante;
            RHH.tpersonal _personal;

            MotivoVisitas _motivos = MotivoVisitas.GetInstance();
            EstadoVisita _estado = EstadoVisita.GetInstance();

            consulta.Parameters.Add("@cite_id", estado.Id);
            consulta.Parameters.Add("@per_cedula", usuario.Cedula);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Citas_Visitas_ViewEstado_cedula]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                _cita = new TCitasVisitas();

                _cita.Id = Convert.ToInt32(fila["cit_id"]);
                _cita.Motivo = _motivos.GetItem(Convert.ToInt32(fila["motc_id"]));
                _cita.Numero = fila["cit_numero"].ToString();
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechaentrada"]);
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechasalida"]);
                _cita.ExisteHistorico = Convert.ToInt32(fila["cit_existe"]);
                _cita.Referencia = fila["cit_referencia"].ToString();
                _cita.Estado = _estado.GetItem(estado.Id);

                //Recuperando Visitante.
                _visitante = new RHH.tpersonal();
                _visitante.Nombres = fila["cit_nombres"].ToString();
                _visitante.Cedula = fila["cit_cedula"].ToString();
                _visitante.EsMasculino = Convert.ToBoolean(fila["cit_esmasculino"]);
                _visitante.Foto = new Empresa.RHH.Persona(_visitante.Cedula)[0].Foto;
                _cita.Visitante = _visitante;

                //Recuperando Personal
                //_cita.Personal = new RHH.Personal(Convert.ToInt32(fila["per_id"])).PrimerItem();

                _cita.Personal = PersonalPreAsignado.GetInstance().GetItem(fila["per_cedula"].ToString());
                this.Lista.Add(_cita);
            }

        }

        public CitasVisitas(Empresa.Comun.TEstandar estado, Empresa.RHH.tpersonal personalasignado){
            Lista = new ObservableCollection<TCitasVisitas>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            TCitasVisitas _cita;
            RHH.tpersonal _visitante;
            RHH.tpersonal _personal;

            MotivoVisitas _motivos = MotivoVisitas.GetInstance();
            EstadoVisita _estado = EstadoVisita.GetInstance();

            consulta.Parameters.Add("@cite_id", estado.Id);
            consulta.Parameters.Add("@per_cedula", personalasignado.Cedula);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Citas_Visitas_ViewEstado_cedula]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                _cita = new TCitasVisitas();

                _cita.Id = Convert.ToInt32(fila["cit_id"]);
                _cita.Motivo = _motivos.GetItem(Convert.ToInt32(fila["motc_id"]));
                _cita.Numero = fila["cit_numero"].ToString();
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechaentrada"]);
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechasalida"]);
                _cita.ExisteHistorico = Convert.ToInt32(fila["cit_existe"]);
                _cita.Referencia = fila["cit_referencia"].ToString();
                _cita.Estado = _estado.GetItem(estado.Id);

                //Recuperando Visitante.
                _visitante = new RHH.tpersonal();
                _visitante.Nombres = fila["cit_nombres"].ToString();
                _visitante.Cedula = fila["cit_cedula"].ToString();
                _visitante.EsMasculino = Convert.ToBoolean(fila["cit_esmasculino"]);
                _visitante.Foto = new Empresa.RHH.Persona(_visitante.Cedula)[0].Foto;
                _cita.Visitante = _visitante;

                //Recuperando Personal
                //_cita.Personal = new RHH.Personal(Convert.ToInt32(fila["per_id"])).PrimerItem();

                _cita.Personal = PersonalPreAsignado.GetInstance().GetItem(fila["per_cedula"].ToString());
                this.Lista.Add(_cita);
            }




        }

        public CitasVisitas(Empresa.Comun.TEstandar estado, Empresa.RHH.TDepartamento departamento) {


            Lista = new ObservableCollection<TCitasVisitas>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            TCitasVisitas _cita;
            RHH.tpersonal _visitante;
            RHH.tpersonal _personal;

            MotivoVisitas _motivos = MotivoVisitas.GetInstance();
            EstadoVisita _estado = EstadoVisita.GetInstance();

            consulta.Parameters.Add("@cite_id", estado.Id);
            consulta.Parameters.Add("@depe_id", departamento.Id);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Citas_Visitas_ViewEstadoDepartamento]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                _cita = new TCitasVisitas();

                _cita.Id = Convert.ToInt32(fila["cit_id"]);
                _cita.Motivo = _motivos.GetItem(Convert.ToInt32(fila["motc_id"]));
                _cita.Numero = fila["cit_numero"].ToString();
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechaentrada"]);
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechasalida"]);
                _cita.ExisteHistorico = Convert.ToInt32(fila["cit_existe"]);
                _cita.Referencia = fila["cit_referencia"].ToString();
                _cita.Estado = _estado.GetItem(estado.Id);

                //Recuperando Visitante.
                _visitante = new RHH.tpersonal();
                _visitante.Nombres = fila["cit_nombres"].ToString();
                _visitante.Cedula = fila["cit_cedula"].ToString();
                _visitante.EsMasculino = Convert.ToBoolean(fila["cit_esmasculino"]);
                _visitante.Foto = new Empresa.RHH.Persona(_visitante.Cedula)[0].Foto;
                _cita.Visitante = _visitante;

                //Recuperando Personal
                //_cita.Personal = new RHH.Personal(Convert.ToInt32(fila["per_id"])).PrimerItem();

                _cita.Personal = PersonalPreAsignado.GetInstance().GetItem(fila["per_cedula"].ToString());
                this.Lista.Add(_cita);
            }



        }
        
        public CitasVisitas(Empresa.Comun.TEstandar estado, Empresa.RHH.tpersonal personalasignado, Empresa.RHH.TDepartamento departamento){




        }

        public CitasVisitas(Empresa.Comun.TEstandar estado, Empresa.RHH.tpersonal personalasignado, Empresa.RHH.TDepartamento departamento, DateTime fecha)
        {
            
            Lista = new ObservableCollection<TCitasVisitas>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            TCitasVisitas _cita;
            RHH.tpersonal _visitante; 

            MotivoVisitas _motivos = MotivoVisitas.GetInstance();
            EstadoVisita _estado = EstadoVisita.GetInstance();

            consulta.Parameters.Add("@cite_id", estado.Id);
            consulta.Parameters.Add("@depe_id", departamento.Id);
            consulta.Parameters.Add("@per_cedula", personalasignado.Cedula);
            consulta.Parameters.Add("@cit_fechaentrada", fecha);

            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Citas_Visitas_ViewEstadoDepartamentoFechaPersonal]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                _cita = new TCitasVisitas();

                _cita.Id = Convert.ToInt32(fila["cit_id"]);
                _cita.Motivo = _motivos.GetItem(Convert.ToInt32(fila["motc_id"]));
                _cita.Numero = fila["cit_numero"].ToString();
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechaentrada"]);
                _cita.FechaEntrada = Convert.ToDateTime(fila["cit_fechasalida"]);
                _cita.ExisteHistorico = Convert.ToInt32(fila["cit_existe"]);
                _cita.Referencia = fila["cit_referencia"].ToString();
                _cita.Estado = _estado.GetItem(estado.Id);

                //Recuperando Visitante.
                _visitante = new RHH.tpersonal();
                _visitante.Nombres = fila["cit_nombres"].ToString();
                _visitante.Cedula = fila["cit_cedula"].ToString();
                _visitante.EsMasculino = Convert.ToBoolean(fila["cit_esmasculino"]);
                _visitante.Foto = new Empresa.RHH.Persona(_visitante.Cedula)[0].Foto;
                _cita.Visitante = _visitante;

                //Recuperando Personal
                //_cita.Personal = new RHH.Personal(Convert.ToInt32(fila["per_id"])).PrimerItem();

                _cita.Personal = PersonalPreAsignado.GetInstance().GetItem(fila["per_cedula"].ToString());
                this.Lista.Add(_cita);
            }


        }
        

        public void Insert(TCitasVisitas item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@cit_nombres", item.Visitante.NombreCompleto);
            consulta.Parameters.Add("@cit_cedula", item.Visitante.Cedula);
            consulta.Parameters.Add("@cit_esmasculino", item.Visitante.EsMasculino);
            consulta.Parameters.Add("@cit_fechaentrada", item.FechaEntrada);
            consulta.Parameters.Add("@cit_fechasalida", item.FechaSalida);
            consulta.Parameters.Add("@motc_id", item.Motivo.Id);
            consulta.Parameters.Add("@cit_referencia", item.Referencia);
            
            //Persona y/o departamento
            consulta.Parameters.Add("@per_cedula", item.Personal.Cedula);
            consulta.Parameters.Add("@per_id", item.Personal.Id);
            consulta.Parameters.Add("@depe_id", item.Personal.Departamento.Id);
            
            //Recuperando Id
            System.Data.SqlClient.SqlDataReader Lector =   (System.Data.SqlClient.SqlDataReader)consulta.Execute.Reader("dbo.Citas_Visitas_Insert", System.Data.CommandType.StoredProcedure);
            if (Lector.Read()){
                item.Id = Lector[0] == DBNull.Value? -1:Convert.ToInt32(Lector[0]);
                item.Numero = Lector[1].ToString();
            }
            else {
                item.Id = -1;
                item.Numero = string.Empty;
            }
            //Cerrando Lector
            Lector.Close();
            Lector.Dispose();
            
            //Insertando Indicadores
            _valoraciones.Insert(item);
        }
        
        public void Update(TCitasVisitas item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@cit_id", item.Id);

            consulta.Parameters.Add("@cit_nombres", item.Visitante.NombreCompleto);
            consulta.Parameters.Add("@cit_cedula", item.Visitante.Cedula);
            consulta.Parameters.Add("@cit_esmasculino", item.Visitante.EsMasculino);
            consulta.Parameters.Add("@cit_fechaentrada", item.FechaEntrada);
            consulta.Parameters.Add("@cit_fechasalida", item.FechaSalida);
            consulta.Parameters.Add("@motc_id", item.Motivo.Id);
            consulta.Parameters.Add("@cite_id", item.Estado.Id);
            consulta.Parameters.Add("@cit_referencia", item.Referencia);

            //Persona y/o departamento
            consulta.Parameters.Add("@per_cedula", item.Personal.Cedula);
            consulta.Parameters.Add("@per_id", item.Personal.Id);
            consulta.Parameters.Add("@depe_id", item.Personal.Departamento.Id);

            consulta.Execute.NoQuery("dbo.Citas_Visitas_Update", System.Data.CommandType.StoredProcedure);
            
            //Actualizando Indicadores
            _valoraciones.Update(item);

        }

        

    }
}

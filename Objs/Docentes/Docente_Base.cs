using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{
    public class DocenteBase : ObservableCollection<tdocente>{

        public DocenteBase(){




        }


        public DocenteBase(ObservableCollection<tdocente> items){

            //solsf_cedula
            //


        }

        public DocenteBase(List<string> items){
            this.Contructor(items);
        }

        private void Contructor(List<string> items){

                        SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

                        consulta.Parameters.Add("@cedulas", Empresa.Comun.Servicios.DividirCAD(items));
                        tdocente docente;

                        foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[ViewCed_ViewDecretosPadron_V2_Docentes]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
                        {

                            docente = new tdocente();

                            docente.Nombres = fila["pdr_nombres"].ToString();
                            docente.Apellidos = fila["pdr_Apellidos"].ToString();
                            docente.NombreCompleto = fila["pdr_NombreCompleto"].ToString();

                            docente.Cedula = fila["pdr_cedula"].ToString();
                            docente.EsMasculino = Convert.ToBoolean(fila["pdr_sexo"]);
                            docente.FechaNacimiento = (DateTime)fila["pdr_FechaNac"];

                            docente.Foto = fila["pdr_foto"] == DBNull.Value ? null : (byte[])fila["pdr_foto"];
                            docente.EstadoPR = fila["EstadoPr"].ToString();
                            docente.Nss = fila["pdr_nss"].ToString();
                            docente.EsFallecido = Convert.ToBoolean(fila["pdr_esfallecido"]);
                            docente.FechaFallecido = fila["pdr_ffallecido"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_ffallecido"];
                            docente.FechaIngresoEducacion = fila["pdr_fingreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_fingreso"];
                            docente.EsInabima = fila["docf_esinabima"] == DBNull.Value ? true : Convert.ToBoolean(fila["docf_esinabima"]);

                            //docente.Cargo = fila["car_descipcion"] == DBNull.Value ? string.Empty : fila["car_descipcion"].ToString().Trim();
                            //docente.Dependencia = fila["dep_nombre"] == DBNull.Value ? string.Empty : fila["dep_nombre"].ToString().Trim();
                            //docente.Regional = fila["reg_nombre"] == DBNull.Value ? string.Empty : fila["reg_nombre"].ToString().Trim();

                            //Estableciendo Decretos De Beneficiarios
                            if (docente.EsFallecido)
                            {
                                //Ingresar Datos de Fallecimiento.
                                docente.DatosFellecimiento = new tdatosfallecimiento();
                                docente.DatosFellecimiento.Acta = fila["docf_acta"].ToString();
                                docente.DatosFellecimiento.Causa = fila["docf_mdescripcion"].ToString();
                                docente.DatosFellecimiento.Folio = fila["docf_nfolio"].ToString();
                                docente.DatosFellecimiento.Libro = fila["docf_libro"].ToString();
                                docente.DatosFellecimiento.Numero = fila["docf_noacta"].ToString();
                                docente.DatosFellecimiento.Oficialia = fila["docf_oficialia"].ToString();


                                docente.DatosFellecimiento.TipoMuerte = Empresa.Comun.TipoMuerte.GetInstance().GetItem(Convert.ToInt32(fila["tmue_id"]));
                                //Direccion del fallecimiento es Buscada en una instancea mayor.

                                if (docente.EsInabima){
                                    //Por decreto.
                                    docente.DecretoBeneficiarios = Empresa.Docente.Decreto.GetInstnace().GetItem(Convert.ToInt32(fila["fech_id"]));
                                    docente.FechaPrimerPago = docente.DecretoBeneficiarios.FechaEP;
                                }
                                else{
                                    //Por la aseguradora.
                                    docente.Aseguradora = new Comun.Suplidor(Convert.ToInt32(fila["sup_id"]))[0];
                                    //docente.FechaPrimerPago = fila["pdr_fprimerpagoaseguradora"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_fprimerpagoaseguradora"];
                                }
                            }

                            if (docente.FechaNacimiento != DateTime.MinValue){
                                if(!docente.EsFallecido){
                                    docente.Edad = Empresa.Comun.Servicios.FechasDifencia(docente.FechaNacimiento, Empresa.Comun.Server.DameTiempo()).Anos;
                                }
                                else {
                                    docente.Edad = Empresa.Comun.Servicios.FechasDifencia(docente.FechaNacimiento, docente.FechaFallecido).Anos;
                                }
                            }
                            
                            docente.HistorialPagos = new Pagos(docente.Cedula);
                            docente.SolicitudPJ = new SolicitudPJ();
                            tsolicitudpj itemsol = new tsolicitudpj(docente);

                            itemsol.Id = Convert.ToInt32(fila["solpj_id"]); 
                            itemsol.FechaEntrada = fila["solpj_fechaentrada"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["solpj_fechaentrada"];
                            itemsol.Fecha = fila["solpj_fecha"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["solpj_fecha"];
                            itemsol.NoExpediente = fila["solpj_noexpedientes"].ToString();
                            itemsol.Estados.Lista.Add(new testadossolicitudpj(new testadopj()));

                            itemsol._calculando_EscalaPensionDiscapcidad();
                            itemsol._calculando_Monto();
                            itemsol._calculando_MontoRetroactivo();
                            itemsol.FechaConcrecion = fila["solpj_fconcrecion"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["solpj_fconcrecion"];

                            docente.SolicitudPJ.Lista.Add(itemsol);
                            docente.SolicitudPJ.Actual = itemsol;

                           

                            this.Add(docente);
                            docente.CalculoRetroActivo();

                        } // for end
                        //consulta.Parameters.ClerAll();
                   // }// cedula valida
        }


        public DocenteBase(string cedula) {

           if (!string.IsNullOrEmpty(cedula)){
               SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
               cedula = cedula.Replace("-", string.Empty);

               //Cedula is valida
               if (Empresa.Comun.Servicios.CedulaEsValida(cedula)){
                   consulta.Parameters.Add("@cedula", cedula);
                   tdocente docente;
                   //Empresa.Comun.EnlaceContacto Enlace = new Comun.EnlaceContacto(cedula);
                   //Empresa.Comun.Direccion Enlace = new Comun.Direccion(cedula);

                   foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[ViewCed_ViewDecretosPadron_V2]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){

                       docente = new tdocente();

                       docente.Nombres = fila["pdr_nombres"].ToString();
                       docente.Apellidos = fila["pdr_Apellidos"].ToString();
                       docente.NombreCompleto = fila["pdr_NombreCompleto"].ToString();

                       docente.Cedula = fila["pdr_cedula"].ToString();
                       docente.EsMasculino = Convert.ToBoolean(fila["pdr_sexo"]);
                       docente.FechaNacimiento = (DateTime)fila["pdr_FechaNac"];

                       docente.Foto = fila["pdr_foto"] == DBNull.Value ? null : (byte[])fila["pdr_foto"];
                       docente.EstadoPR = fila["EstadoPr"].ToString();
                       docente.Nss = fila["pdr_nss"].ToString();
                       docente.EsFallecido = Convert.ToBoolean(fila["pdr_esfallecido"]);
                       docente.FechaFallecido = fila["pdr_ffallecido"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_ffallecido"];
                       docente.FechaIngresoEducacion = fila["pdr_fingreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_fingreso"];
                       docente.EsInabima = fila["docf_esinabima"] == DBNull.Value ? true : Convert.ToBoolean(fila["docf_esinabima"]);

                       docente.Cargo = fila["car_descipcion"] == DBNull.Value ? string.Empty : fila["car_descipcion"].ToString().Trim();
                       docente.Dependencia = fila["dep_nombre"] == DBNull.Value ? string.Empty : fila["dep_nombre"].ToString().Trim();
                       docente.Regional = fila["reg_nombre"] == DBNull.Value ? string.Empty : fila["reg_nombre"].ToString().Trim();
                       docente.EsDocente = Convert.ToBoolean(fila["pdr_esdocente"]);
                       docente.EsNotificadoFallecido = Convert.ToInt32(fila["EsNotificado"])==0? false: true;
                       



                       //Estableciendo Decretos De Beneficiarios
                       if (docente.EsFallecido){
                           //Ingresar Datos de Fallecimiento.
                           docente.DatosFellecimiento = new tdatosfallecimiento();
                           docente.DatosFellecimiento.Acta = fila["docf_acta"].ToString();
                           docente.DatosFellecimiento.Causa = fila["docf_mdescripcion"].ToString();
                           docente.DatosFellecimiento.Folio = fila["docf_nfolio"].ToString();
                           docente.DatosFellecimiento.Libro = fila["docf_libro"].ToString();
                           docente.DatosFellecimiento.Numero = fila["docf_noacta"].ToString();
                           docente.DatosFellecimiento.Oficialia = fila["docf_oficialia"].ToString();
                           docente.DatosFellecimiento.TipoMuerte = Empresa.Comun.TipoMuerte.GetInstance().GetItem(Convert.ToInt32(fila["tmue_id"]));
                           //Direccion del fallecimiento es Buscada en una instancea mayor.
                           
                           if(docente.EsInabima){
                               //Por decreto.
                               docente.DecretoBeneficiarios = Empresa.Docente.Decreto.GetInstnace().GetItem(Convert.ToInt32(fila["fech_id"]));
                               docente.FechaPrimerPago = docente.DecretoBeneficiarios.FechaEP;
                           }
                           else {
                               //Por la aseguradora.
                               docente.Aseguradora = new Comun.Suplidor(Convert.ToInt32(fila["sup_id"]))[0];
                               //docente.FechaPrimerPago = fila["pdr_fprimerpagoaseguradora"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_fprimerpagoaseguradora"];
                           }
                       }

                       if(docente.FechaNacimiento != DateTime.MinValue){
                           if (!docente.EsFallecido){
                               docente.Edad = Empresa.Comun.Servicios.FechasDifencia(docente.FechaNacimiento, Empresa.Comun.Server.DameTiempo()).Anos;
                           }
                           else{
                               docente.Edad = Empresa.Comun.Servicios.FechasDifencia(docente.FechaNacimiento, docente.FechaFallecido).Anos;
                           }
                       }

                       if (!Convert.ToInt32(fila["solpj_cedula"]).Equals(0)){
                           //No tiene
                           docente.TieneSobrevivencia = true;
                       }

                       if(!Convert.ToInt32(fila["solsf_cedula"]).Equals(0)){
                           //No tiene
                           docente.TieneSeguroFunerario = true;
                       }

                       docente.DecretoActual = new TDecretoDocente();
                       
                      
                       //Cargando Decreto Actual 
                       if (Convert.ToInt32(fila["dec_id"]) != 0){
                           //Existe un Decreto
                           docente.DecretoActual.Decreto = Empresa.Docente.Decreto.GetInstnace().GetItem(Convert.ToInt32(fila["dec_id"]));
                           docente.DecretoActual.Monto = Convert.ToDouble(fila["decd_monto"]);
                           docente.DecretoActual.Estado = Empresa.RHH.EstadoLaboral.GetInstance()[Convert.ToInt32(fila["taf_id"])];
                           //Se define por defecto el mismo estado laboral.
                           docente.EstadoLaboral = docente.DecretoActual.Estado;
                       }
                       else{
                       //Es activo, Estado Laboral cambia.
                           docente.EstadoLaboral = Empresa.RHH.EstadoLaboral.GetInstance()[Convert.ToInt32(fila["taf_id"])];
                       }
                       docente.CalculoRetroActivo();
                       this.Add(docente);
                   } // for end
               }// cedula valida
           }

        }

        public void Update(tdocente item)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@docf_cedula", item.Cedula);

            /// Modificando Datos Basicos. ///
            /// Inclusion y exclucion de los registro de fallecidos.
            
            if (item.EsFallecido == false){
                //Eliminar fallecidos
                consulta.Execute.NoQuery("dbo.Legal_DocentesFallecidosDelete", System.Data.CommandType.StoredProcedure);
            }
            else {
                //Agregando Fallecido.
                
                if(item.FechaPrimerPago == DateTime.MinValue  || item.FechaPrimerPago == DateTime.MinValue){
                    consulta.Parameters.Add("@docf_fprimerpago",  DBNull.Value);
                }else{
                    consulta.Parameters.Add("@docf_fprimerpago", item.FechaPrimerPago);
                }
                
                consulta.Parameters.Add("@docf_esinabima", item.EsInabima);
                consulta.Parameters.Add("@sup_id", item.Aseguradora == null ? 0 : item.Aseguradora.Id);
                
                consulta.Parameters.Add("@fech_id", item.DecretoBeneficiarios == null ? 0 : item.DecretoBeneficiarios.Id);

                consulta.Parameters.Add("@docf_ffallecimiento", item.FechaFallecido);
                consulta.Parameters.Add("docf_acta", item.DatosFellecimiento.Acta);
                consulta.Parameters.Add("docf_mdescripcion",item.DatosFellecimiento.Causa);
                consulta.Parameters.Add("docf_nfolio",item.DatosFellecimiento.Folio);
                consulta.Parameters.Add("docf_libro",item.DatosFellecimiento.Libro);
                consulta.Parameters.Add("docf_noacta", item.DatosFellecimiento.Numero);
                consulta.Parameters.Add("tmue_id", item.DatosFellecimiento.TipoMuerte.Id);
                consulta.Parameters.Add("@docf_oficialia", item.DatosFellecimiento.Oficialia);
                

                consulta.Execute.NoQuery("dbo.Legal_DocentesFallecidosUpdate", System.Data.CommandType.StoredProcedure);
            }
        }
        
    }
}

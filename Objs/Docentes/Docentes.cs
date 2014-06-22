using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;  

namespace Empresa.Docente
{
   public  class Docentes: DocentesBase {

       public Docentes()
       {

           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
           tdocente docente;
           string temp = string.Empty;

           //Empresa.Comun.Direcciones dire = new Empresa.Comun.Direcciones(false);
           System.Data.DataSet ds = consulta.Execute.Dataset("[dbo].[ViewCed_ViewDecretosPadron_ActivosFallecidos]", System.Data.CommandType.StoredProcedure);

           foreach(System.Data.DataRow fila in ds.Tables[0].Rows){
               docente = new tdocente();

               docente.Nombres = fila["pdr_nombres"].ToString();
               docente.Apellidos = fila["pdr_apellido1"].ToString() + fila["pdr_apellido2"].ToString();
               docente.NombreCompleto = fila["pdr_NombreCompleto"].ToString();
               docente.Cedula = fila["pdr_cedula"].ToString();
               docente.EsMasculino = Convert.ToBoolean(fila["pdr_sexo"]);
               docente.EsFallecido = Convert.ToBoolean(fila["pdr_esfallecido"]);

               docente.FechaFallecido = fila["pdr_ffallecido"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_ffallecido"];
               docente.FechaIngresoEducacion = fila["pdr_fingreso"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_fingreso"];
               docente.FechaNacimiento = (DateTime)fila["pdr_FechaNac"];
               
               DecretoDocente decret = new DecretoDocente(docente);

               if(decret.Docentes != null){
                   
                   if(decret.Docentes.Count > 0){
                       docente.Decretos = decret.Docentes[0].Decretos;
                       //docente.EstadoLaboral = docente.DecretoActual.Estado;
                   }
                   else {
                       docente.Decretos = new ObservableCollection<TDecretoDocente>();
                       docente.EstadoLaboral = Empresa.RHH.EstadoLaboral.GetInstance()[1];
                   }

               }
               else{
                   docente.Decretos = new ObservableCollection<TDecretoDocente>();
                   docente.EstadoLaboral = Empresa.RHH.EstadoLaboral.GetInstance()[1];
               }

               if(docente.EsFallecido){
                   docente.EsInabima = fila["docf_esinabima"] == DBNull.Value ? true : Convert.ToBoolean(fila["docf_esinabima"]);
                   if (docente.EsInabima){
                       //Por decreto.
                       docente.DecretoBeneficiarios = Empresa.Docente.Decreto.GetInstnace().GetItem(Convert.ToInt32(fila["fech_id"]));
                       docente.FechaPrimerPago = docente.DecretoBeneficiarios.FechaEP;
                   }
                   else{
                       //Por la aseguradora.
                       docente.Aseguradora = new Comun.Suplidor(Convert.ToInt32(fila["sup_id"]))[0];
                      // docente.FechaPrimerPago = fila["pdr_fprimerpagoaseguradora"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["pdr_fprimerpagoaseguradora"];
                   }
               }

               this.Add(docente);
           }

           Familiares fami = new Familiares(this);

           foreach (tdocente item in this){
               foreach (TFamiliares itemf in fami.Diccionario.Values){
                   if (itemf.Docente.Cedula.Equals(item.Cedula)){
                       item.Familiares.Add(itemf);
                       item.Familiares.ReglaCalculo();
                       item.Calculo_FechasPension_Familiar();
                       item.Calculo_Edad_Familiar();
                   }
               }
           }
       }

       public Docentes(List<string> arg):base(arg){
               DecretoDocente decretos = new DecretoDocente(this);
               foreach (Empresa.Docente.tdocente itemdecre in decretos.Docentes)
               {
                   foreach (Empresa.Docente.tdocente itemdocen in this)
                   {
                       if (itemdecre.Cedula.Equals(itemdocen.Cedula))
                       {
                           itemdocen.Decretos = itemdecre.Decretos;
                           //Asignado, Estado Laboral.
                           if (itemdocen.Decretos == null){
                               //Estado laboral si no se encuentra, pension o jubilación
                               itemdocen.EstadoLaboral = Empresa.RHH.EstadoLaboral.GetInstance()[1];
                           }
                           else{
                               
                               if(itemdocen.Decretos.Count == 0){
                                   itemdocen.EstadoLaboral = itemdocen.DecretoActual.Estado;
                               }
                               else{
                                   itemdocen.EstadoLaboral = Empresa.RHH.EstadoLaboral.GetInstance()[1];
                               }
                           }

                       }
                   }
               }


               Familiares fami = new Familiares(this);
               foreach (tdocente item in this){
                   foreach (TFamiliares itemf in fami.Diccionario.Values){
                       if (itemf.Docente.Cedula.Equals(item.Cedula)){
                           item.Familiares.Add(itemf);
                           item.Familiares.ReglaCalculo();
                           item.Calculo_FechasPension_Familiar();
                           item.Calculo_Edad_Familiar();
                       }
                   }
               }
           }

       public ObservableCollection<tdocente> GetItem(int Ano, Empresa.Comun.TParentesco parentesco) {
           ObservableCollection<tdocente> items = new ObservableCollection<tdocente>();
           tdocente docentes;

           foreach (tdocente itemd in this){
               docentes = new tdocente();
               docentes.Nombres = itemd.Nombres;
               docentes.Apellidos = itemd.Apellidos;
               docentes.Cedula = itemd.Cedula;
               docentes.NombreCompleto = itemd.NombreCompleto;
               docentes.Familiares = new Familiares();
               docentes.FechaFallecido = itemd.FechaFallecido;
               docentes.EsInabima = itemd.EsInabima;
               docentes.EsMasculino = itemd.EsMasculino;

               foreach (TFamiliares itemf in itemd.Familiares)
               {
                   if ((itemf.FechaFinalPJ.Year.Equals(Ano)) && itemf.Parentesco.Id.Equals(parentesco.Id)){
                       docentes.Familiares.Add(itemf);
                   }
               }
               if (docentes.Familiares.Count > 0) items.Add(docentes);
           }
           return items;
       }
       public ObservableCollection<tdocente> GetItem(int Ano,int Mes, Empresa.Comun.TParentesco parentesco){
           ObservableCollection<tdocente> items = new ObservableCollection<tdocente>();

           tdocente docentes;
           foreach (tdocente itemd in this){
               docentes = new tdocente();

               docentes.Nombres = itemd.Nombres;
               docentes.Apellidos = itemd.Apellidos;
               docentes.Cedula = itemd.Cedula;
               docentes.NombreCompleto = itemd.NombreCompleto;
               docentes.FechaFallecido = itemd.FechaFallecido;
               docentes.EsInabima = itemd.EsInabima;
               docentes.EsMasculino = itemd.EsMasculino;

               docentes.Familiares = new Familiares();
               foreach (TFamiliares itemf in itemd.Familiares){
                   if ((itemf.FechaFinalPJ.Year.Equals(Ano)) && itemf.FechaFinalPJ.Month.Equals(Mes) && itemf.Parentesco.Id.Equals(parentesco.Id)){
                       docentes.Familiares.Add(itemf);
                   }
               }

               if (docentes.Familiares.Count > 0) items.Add(docentes);
           }
           return items;
       }
       public ObservableCollection<tdocente> GetItem(int Ano, bool EsCasado, bool DocumentoEstudio)
       {
           ObservableCollection<tdocente> items = new ObservableCollection<tdocente>();

           tdocente docentes;
           foreach (tdocente itemd in this)
           {
               docentes = new tdocente();
               docentes.Nombres = itemd.Nombres;
               docentes.Apellidos = itemd.Apellidos;
               docentes.Cedula = itemd.Cedula;
               docentes.NombreCompleto = itemd.NombreCompleto;
               docentes.Familiares = new Familiares();
               docentes.FechaFallecido = itemd.FechaFallecido;
               docentes.EsInabima = itemd.EsInabima;
               docentes.EsMasculino = itemd.EsMasculino;

               foreach (TFamiliares itemf in itemd.Familiares)
               {
                   if ((itemf.FechaFinalPJ.Year.Equals(Ano)) || (itemf.PresenteDocumentos.Equals(DocumentoEstudio) && itemf.EsCasado.Equals(EsCasado)))
                   {
                       docentes.Familiares.Add(itemf);
                   }
               }
               if (docentes.Familiares.Count > 0) items.Add(docentes);
           }

           return items;
       }
       public ObservableCollection<tdocente> GetItem(int Ano, int Mes, bool EsCasado, bool DocumentoEstudio){
           ObservableCollection<tdocente> items = new ObservableCollection<tdocente>();
           tdocente docentes;
           foreach (tdocente itemd in this){
               docentes = new tdocente();
               docentes.Nombres = itemd.Nombres;
               docentes.Apellidos = itemd.Apellidos;
               docentes.Cedula = itemd.Cedula;
               docentes.NombreCompleto = itemd.NombreCompleto;
               docentes.FechaFallecido = itemd.FechaFallecido;
               docentes.EsInabima = itemd.EsInabima;
               docentes.EsMasculino = itemd.EsMasculino;
               docentes.Familiares = new Familiares();
               foreach(TFamiliares itemf in itemd.Familiares){
                   if((itemf.FechaFinalPJ.Year.Equals(Ano) && itemf.FechaFinalPJ.Month.Equals(Mes)) || (itemf.PresenteDocumentos.Equals(DocumentoEstudio) && itemf.EsCasado.Equals(EsCasado))){
                       docentes.Familiares.Add(itemf);
                   }
               }
               if (docentes.Familiares.Count > 0) items.Add(docentes);
           }
           return items;
       }
       public ObservableCollection<tdocente> GetItem(bool EstadoBeneficio){
           ObservableCollection<tdocente> items = new ObservableCollection<tdocente>();
           tdocente docentes;
           
           foreach(tdocente itemd in this){
               docentes = new tdocente();

               docentes.Nombres = itemd.Nombres;
               docentes.Apellidos = itemd.Apellidos;
               docentes.Cedula = itemd.Cedula;
               docentes.NombreCompleto = itemd.NombreCompleto;
               docentes.FechaFallecido = itemd.FechaFallecido;
               docentes.EsInabima = itemd.EsInabima;
               docentes.EsMasculino = itemd.EsMasculino;
               docentes.Familiares = new Familiares();

               foreach (TFamiliares itemf in itemd.Familiares){
                   if(itemf.CompruebEstadoBeneficio.Equals(EstadoBeneficio)){
                           docentes.Familiares.Add(itemf);
                   }
               }
               if (docentes.Familiares.Count > 0) items.Add(docentes);
           }
           return items;
       }
       public ObservableCollection<tdocente> GetItem(Empresa.Comun.TEstandar EstadoBeneficio){

           ObservableCollection<tdocente> items = new ObservableCollection<tdocente>();
           tdocente docentes;

           foreach(tdocente itemd in this){
               docentes = new tdocente();
               docentes.Nombres = itemd.Nombres;
               docentes.Apellidos = itemd.Apellidos;
               docentes.Cedula = itemd.Cedula;
               docentes.NombreCompleto = itemd.NombreCompleto;
               docentes.FechaFallecido = itemd.FechaFallecido;
               docentes.EsInabima = itemd.EsInabima;
               docentes.EsMasculino = itemd.EsMasculino;
               
               docentes.Familiares = new Familiares();
               foreach(TFamiliares itemf in itemd.Familiares){
                   if(itemf.EstadoBeneficio.Id.Equals(EstadoBeneficio.Id)){
                       docentes.Familiares.Add(itemf);
                   }
               }
               if (docentes.Familiares.Count > 0) items.Add(docentes);
           }
           return items;

       }

   }
}

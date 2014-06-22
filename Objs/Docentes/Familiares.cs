using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Empresa.Docente
{

    public class Familiares : ObservableCollection<Empresa.Docente.TFamiliares>
    {
        public Dictionary<string,TFamiliares> Diccionario {get;set;}

        public Familiares(TFamiliares item){
        
        }

        public Familiares(){
            this.Diccionario = new Dictionary<string, TFamiliares>();
        }

        public Familiares(DateTime FechaFinal, int EdadInicial, int EdadFinal){
            Empresa.Comun.Parentesco paren = new Comun.Parentesco();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@fechatermino", FechaFinal);
            consulta.Parameters.Add("@edadinicial", EdadInicial);
            consulta.Parameters.Add("@edadfinal", EdadFinal);

            Empresa.Docente.TFamiliares fami;
            
            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Legal_DocentesDependientesView_Fecha]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                fami = new TFamiliares();

                fami.Id = Convert.ToInt32(fila["depe_id"]);
                fami.Cedula = fila["depe_cedulabeneficiario"].ToString();
                fami.Docente = new tdocente(fila["docf_cedula"].ToString());
                fami.EsDiscapacitado = Convert.ToBoolean(fila["depe_esdiscapacitado"]);
                fami.Parentesco = paren.GetItem(Convert.ToInt32(fila["parn_id"]));
                fami.Nombres = fila["depe_nombres"].ToString();
                fami.FechaNacimiento = fila["depe_fnacimiento"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["depe_fnacimiento"];
                fami.EsCasado = Convert.ToBoolean(fila["depe_escasado"]);
                fami.PresenteDocumentos = Convert.ToBoolean(fila["depe_docestudio"]);
                fami.Tutor.Cedula = fila["depe_cedulatutor"].ToString();
                fami.Apellidos = fila["depe_apellidos"].ToString();
                fami.EsMasculino = Convert.ToBoolean(fila["depe_esmasculino"]);

                fami.HijosPosee = fila["depe_hijos"] == DBNull.Value ? false : Convert.ToBoolean(fila["depe_hijos"]);
                fami.EstadoBeneficio = EstadoBeneficio.GetInstance().GetItem(Convert.ToInt32(fila["estb_id"]));

                fami.CalculoInterno();
                this.Add(fami);
            }
            this.ReglaCalculo();
        }

        public void Insert(TFamiliares item){
         SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
         
         consulta.Parameters.Add("@docf_id", item.Id);
         consulta.Parameters.Add("@docf_cedula", item.Docente.Cedula);
         
         consulta.Parameters.Add("@depe_nombres", item.Nombres);
         consulta.Parameters.Add("@depe_apellidos", item.Apellidos);

         consulta.Parameters.Add("@depe_fnacimiento", item.FechaNacimiento);
         consulta.Parameters.Add("@depe_esdiscapacitado", item.EsDiscapacitado);
         consulta.Parameters.Add("@docf_detalles", string.Empty);
         consulta.Parameters.Add("@depe_nss", item.Nss);
         consulta.Parameters.Add("@depe_cedulatutor", item.Tutor.Cedula == null ? string.Empty : item.Tutor.Cedula);
         consulta.Parameters.Add("@parn_id", item.Parentesco.Id);
         consulta.Parameters.Add("@depe_cedulabeneficiario", item.Cedula == null ? string.Empty : item.Cedula);
         //consulta.Parameters.Add("@depe_decreto", item.Decreto == null ? string.Empty : item.Decreto);
         consulta.Parameters.Add("@depe_escasado", item.EsCasado);
         consulta.Parameters.Add("@depe_docestudio", item.PresenteDocumentos);
         consulta.Parameters.Add("@depe_fdocestudio", Empresa.Comun.Server.DameTiempo());
         
         consulta.Parameters.Add("@depe_hijos", item.HijosPosee);
         consulta.Parameters.Add("@estb_id", item.EstadoBeneficio.Id);

         //consulta.Parameters.Add("@depe_esinabima", item.EsInabima);
         consulta.Parameters.Add("@depe_esmasculino", item.EsMasculino);           
         consulta.Execute.NoQuery("dbo.Legal_DocentesDependientesInsert", System.Data.CommandType.StoredProcedure);
         //Agregando a la lista.
         this.Add(item);
         this.ReglaCalculo();
        }

        public void Update(TFamiliares item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);

            consulta.Parameters.Add("@depe_id", item.Id);
            consulta.Parameters.Add("@depe_nombres", item.Nombres);
            consulta.Parameters.Add("@depe_fnacimiento", item.FechaNacimiento);
            consulta.Parameters.Add("@depe_esdiscapacitado", item.EsDiscapacitado);
            consulta.Parameters.Add("@docf_detalles", string.Empty);
            consulta.Parameters.Add("@depe_nss", item.Nss);
            consulta.Parameters.Add("@depe_cedulatutor", item.Tutor.Cedula == null ? string.Empty : item.Tutor.Cedula);
            consulta.Parameters.Add("@parn_id", item.Parentesco.Id);
            consulta.Parameters.Add("@depe_cedulabeneficiario", item.Cedula == null ? string.Empty : item.Cedula);
           // consulta.Parameters.Add("@depe_decreto", item.Decreto == null ? string.Empty : item.Decreto);
            consulta.Parameters.Add("@depe_escasado", item.EsCasado);
            //consulta.Parameters.Add("@depe_esinabima", item.EsInabima);
            //consulta.Parameters.Add("@sup_id", item.EsInabima==true? 0: item.Aseguradora.Id);
            consulta.Parameters.Add("@depe_docestudio", item.PresenteDocumentos);
            consulta.Parameters.Add("@depe_fdocestudio", Empresa.Comun.Server.DameTiempo());
            consulta.Parameters.Add("@depe_apellidos", item.Apellidos);
            consulta.Parameters.Add("@depe_esmasculino", item.EsMasculino);
            
            consulta.Parameters.Add("@depe_hijos", item.HijosPosee);
            consulta.Parameters.Add("@estb_id", item.EstadoBeneficio.Id);

            consulta.Execute.NoQuery("dbo.Legal_DocentesDependientes_Update", System.Data.CommandType.StoredProcedure);
            this.ReglaCalculo();
        }


        public void Delete(TFamiliares item){
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@depe_id", item.Id);
            consulta.Execute.NoQuery("dbo.Legal_DocentesDependientesDelete", System.Data.CommandType.StoredProcedure);
            this.Remove(item);

            this.ReglaCalculo();
        }

        private void Contructor(string cedula) {
            Empresa.Comun.Parentesco paren = new Comun.Parentesco();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@cedula", cedula);

            Empresa.Docente.TFamiliares fami = new TFamiliares();
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Legal_DocentesDependientesView_02]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){

                fami = new TFamiliares(Convert.ToInt32(fila["depe_id"]), fila["depe_nombres"].ToString(), fila["depe_apellidos"].ToString(), fila["depe_fnacimiento"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["depe_fnacimiento"], string.Empty, Convert.ToBoolean(fila["depe_esdiscapacitado"]), paren.GetItem(Convert.ToInt32(fila["parn_id"])), false);

                fami.Cedula = fila["depe_cedulabeneficiario"].ToString();
                fami.EsCasado = Convert.ToBoolean(fila["depe_escasado"]);
                fami.PresenteDocumentos = Convert.ToBoolean(fila["depe_docestudio"]);
                fami.Tutor.Cedula = fila["depe_cedulatutor"].ToString();
                fami.EsMasculino = Convert.ToBoolean(fila["depe_esmasculino"]);
                fami.NombreCompleto = fami.Nombres + " " + (string.IsNullOrEmpty(fami.Apellidos) == true ? string.Empty : fami.Apellidos);
                fami.Docente.Cedula = cedula;
                fami.HijosPosee = fila["depe_hijos"] == DBNull.Value ? false : Convert.ToBoolean(fila["depe_hijos"]);
                fami.EstadoBeneficio = EstadoBeneficio.GetInstance().GetItem(Convert.ToInt32(fila["estb_id"]));

                fami.CalculoInterno();
                this.Add(fami);
            }
            this.ReglaCalculo();
        }



        public Familiares(string cedula){
            this.Contructor(cedula);
        }

        public Familiares(string nombre, string cedula) { 
            Empresa.Comun.Parentesco paren = new Comun.Parentesco();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            
            consulta.Parameters.Add("@cedulas", cedula);
            consulta.Parameters.Add("@nombres", nombre);

            Empresa.Docente.TFamiliares fami = new TFamiliares();
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Legal_DocentesDependientesView_Dep]", System.Data.CommandType.StoredProcedure).Tables[0].Rows)
            {
                fami = new TFamiliares(Convert.ToInt32(fila["depe_id"]), fila["depe_nombres"].ToString(), fila["depe_apellidos"].ToString(), fila["depe_fnacimiento"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["depe_fnacimiento"], string.Empty, Convert.ToBoolean(fila["depe_esdiscapacitado"]), paren.GetItem(Convert.ToInt32(fila["parn_id"])), false);

                fami.Cedula = fila["depe_cedulabeneficiario"].ToString();
                fami.EsCasado = Convert.ToBoolean(fila["depe_escasado"]);
                fami.PresenteDocumentos = Convert.ToBoolean(fila["depe_docestudio"]);
                
                fami.Tutor.Cedula = fila["depe_cedulatutor"].ToString();
                fami.Tutor.Nombres = fila["nom_tutor"].ToString();
                fami.Tutor.Apellidos = fila["apellidos_tutor"].ToString();

                fami.Docente.Cedula = fila["ced_docente"].ToString();
                fami.Docente.Nombres = fila["nom_docente"].ToString();
                fami.Docente.Apellidos = fila["apellidos_docente"].ToString();

                fami.EsMasculino = Convert.ToBoolean(fila["depe_esmasculino"]);
                fami.NombreCompleto = fami.Nombres + " " + (string.IsNullOrEmpty(fami.Apellidos) == true ? string.Empty : fami.Apellidos);
                fami.HijosPosee = fila["depe_hijos"] == DBNull.Value ? false : Convert.ToBoolean(fila["depe_hijos"]);
                fami.EstadoBeneficio = EstadoBeneficio.GetInstance().GetItem(Convert.ToInt32(fila["estb_id"]));

                fami.CalculoInterno();
                this.Add(fami);
           }
        }

        public Familiares(Empresa.Docente.tdocente item){
            this.Contructor(item.Cedula);

            //Asignando Decretos y Aseguradora.
            foreach (TFamiliares itemf in this){
                if (item.EsInabima){
                    itemf.Decreto = item.DecretoBeneficiarios;
                }
                else {
                    itemf.Aseguradora = item.Aseguradora;
                }
            }
        }

        public Familiares(string cedula, TDecreto decretobeneficiario)
        {
            this.Contructor(cedula);
            if (this.Count > 0) {
                foreach (TFamiliares item in this) {
                    item.Decreto = decretobeneficiario;
                }
            }
        }

        public Familiares(string cedula, Empresa.Comun.TSuplidor aseguradora){
            this.Contructor(cedula);
            if (this.Count > 0)
            {
                foreach (TFamiliares item in this){
                    item.Aseguradora = aseguradora;
                }
            }
        }

        public Familiares(ObservableCollection<tdocente> items) {
            Diccionario = new Dictionary<string, TFamiliares>();

            List<string> cedulas = new List<string>();
            foreach (tdocente item in items){

                if(!string.IsNullOrEmpty(item.Cedula)){
                    cedulas.Add(item.Cedula);
                }

            }

            string arg = Empresa.Comun.Servicios.DividirCAD(cedulas);
            Empresa.Comun.Parentesco paren = new Comun.Parentesco();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@cedula", arg);

            Empresa.Docente.TFamiliares fami;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("Legal_DocentesDependientesViewCs", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                fami = new TFamiliares(Convert.ToInt32(fila["depe_id"]), fila["depe_nombres"].ToString(), fila["depe_apellidos"].ToString(), fila["depe_fnacimiento"] == DBNull.Value ? DateTime.MinValue : (DateTime)fila["depe_fnacimiento"], string.Empty, Convert.ToBoolean(fila["depe_esdiscapacitado"]), paren.GetItem(Convert.ToInt32(fila["parn_id"])), false);
                
                fami.Docente.Cedula = fila["docf_cedula"].ToString();
                fami.Cedula = fila["depe_cedulabeneficiario"].ToString();
                fami.EsCasado = Convert.ToBoolean(fila["depe_escasado"]);
                fami.PresenteDocumentos = Convert.ToBoolean(fila["depe_docestudio"]);
                fami.Tutor.Cedula = fila["depe_cedulatutor"].ToString();
                fami.EsMasculino = Convert.ToBoolean(fila["depe_esmasculino"]);
                fami.NombreCompleto = fami.Nombres + " " + (string.IsNullOrEmpty(fami.Apellidos) == true ? string.Empty : fami.Apellidos);

                fami.HijosPosee = fila["depe_hijos"] == DBNull.Value ? false : Convert.ToBoolean(fila["depe_hijos"]);
                fami.EstadoBeneficio = EstadoBeneficio.GetInstance().GetItem(Convert.ToInt32(fila["estb_id"]));

                fami.CalculoInterno();
                this.Add(fami);
                this.Diccionario.Add(fami.Id.ToString(), fami);
            }

            this.ReglaCalculo();
        }

        public ObservableCollection<Empresa.Docente.TFamiliares> GetItem(int EdadInicio, int EdadFinal, bool documentopresente) {
            ObservableCollection<Empresa.Docente.TFamiliares> titems = new ObservableCollection<TFamiliares>();
            var resul = from x in this where (x.Edad >= EdadInicio && x.Edad <= EdadFinal) && x.PresenteDocumentos == documentopresente select x;
            
            foreach(TFamiliares items in resul){
                titems.Add(items);
            }

            return titems;
        }

        public ObservableCollection<Empresa.Docente.TFamiliares> GetItem(bool EstadoBeneficiario) {
            var resul = from x in this where x.CompruebEstadoBeneficio == true select x;
            ObservableCollection<Empresa.Docente.TFamiliares> titems = new ObservableCollection<TFamiliares>();
            foreach (TFamiliares items in resul){
                titems.Add(items);
            }
            return titems;
        }

        public ObservableCollection<Empresa.Docente.TFamiliares> GetItem(int EdadInicio, int EdadFinal, bool documentopresente, Empresa.Comun.TParentesco parentesco)
        {
            ObservableCollection<Empresa.Docente.TFamiliares> titems = new ObservableCollection<TFamiliares>();
            var resul = from x in this where (x.Edad >= EdadInicio && x.Edad <= EdadFinal) && x.PresenteDocumentos.Equals(documentopresente) &&  x.Parentesco.Id.Equals(parentesco.Id) select x;

            foreach (TFamiliares items in resul){
                titems.Add(items);
            }
            return titems;
        }

        public void ReglaCalculo(){
            bool ExistePadres = false; int CPadres = 0;
            bool ExistenHijos = false; int CHijos = 0;
            bool ExistenEsposos = false; int CEsposos = 0;

            foreach (TFamiliares fami in this){

                if (fami.Parentesco.Id.Equals(1))
                {
                    //HIJOS
                    ExistenHijos = true;
                    CHijos += 1;
                }
                else if (fami.Parentesco.Id.Equals(2) || fami.Parentesco.Id.Equals(3))
                {
                    //PADRE Y MADRE
                    ExistePadres = true;
                    CPadres += 1;
                }
                else if (fami.Parentesco.Id.Equals(4))
                {
                    //ESPOSO(A)
                    ExistenEsposos = true;
                    CEsposos += 1;
                }

            }

                                                            // CALCULO //
            //---------------------------------------------------------------------------------------------------///
            //regla de aplicaciond de porcientos. 
            double porcientoaplicar = 100.0;
            if (ExistenHijos == true && ExistenEsposos == false && ExistePadres == false)
            {
                //HIJOS
                foreach (TFamiliares item in this){
                    item.Scala = Convert.ToDouble((porcientoaplicar / 100.0) / Convert.ToDouble(this.Count));
                }
            }

            if (ExistenHijos == true && ExistenEsposos == true && ExistePadres == false)
            {
                // HIJOS Y ESPOSOS
                //determinado la cantidad de cada grupo
                foreach (TFamiliares item in this)
                {
                    if (item.Parentesco.Id.Equals(1)){
                        item.Scala = ((porcientoaplicar / 100.0) / 2.0) / Convert.ToDouble(CHijos);
                    }
                    else{
                        item.Scala = ((porcientoaplicar / 100.0) / 2.0) / Convert.ToDouble(CEsposos);
                    }
                }
            }
            else if (ExistenHijos == true && ExistenEsposos == true && ExistePadres == true)
            {
                // HIJOS Y ESPOSO Y PADRES.

                foreach (TFamiliares item in this)
                {
                    if (item.Parentesco.Id.Equals(1))
                    {
                        //HIJOS
                        var r = ((37.5 / 100.0) / 2.0) / Convert.ToDouble(CHijos);
                        item.Scala = Convert.ToDouble(r);
                    }
                    else if (item.Parentesco.Id.Equals(2) || item.Parentesco.Id.Equals(3))
                    {
                        //PADRE Y MADRE
                        var r = (25.0 / 100.0) / Convert.ToDouble(CPadres);
                        item.Scala = Convert.ToDouble(r);
                    }
                    else if (item.Parentesco.Id.Equals(4))
                    {
                        //ESPOSO(A)
                        var r = ((37.5 / 100.0) / 2.0) / Convert.ToDouble(CEsposos);
                        item.Scala = Convert.ToDouble(r);
                    }
                }
            }


            if (ExistenHijos == false && ExistenEsposos == true && ExistePadres == false)
            {
                //ESPOSOS 
                foreach (TFamiliares item in this)
                {
                    item.Scala = (porcientoaplicar / 100.0) / Convert.ToDouble(this.Count);
                }
            }

            if (ExistenHijos == false && ExistenEsposos == false && ExistePadres == true){
                //PADRES
                porcientoaplicar = 25.0;
                foreach (TFamiliares item in this)
                {
                    item.Scala = (porcientoaplicar / 100.0) / Convert.ToDouble(this.Count);
                }

            }

            if(ExistenHijos == false && ExistenEsposos == true && ExistePadres == true){
                //ESPOSOS Y PADRES
                foreach (TFamiliares item in this)
                {
                    if (item.Parentesco.Id.Equals(2) || item.Parentesco.Id.Equals(3))
                    {
                        //PADRE Y MADRE
                        var r = (25.0 / 100.0) / Convert.ToDouble(CPadres);
                        item.Scala = Convert.ToDouble(r);
                    }
                    else if (item.Parentesco.Id.Equals(4))
                    {
                        //ESPOSO(A)
                        var r = (75.0 / 100.0) / Convert.ToDouble(CEsposos);
                        item.Scala = Convert.ToDouble(r);
                    }
                }
            }

            else if (ExistenHijos == true && ExistenEsposos == false && ExistePadres == true){
                // HIJOS Y PADRES
                foreach (TFamiliares item in this)
                {
                    if (item.Parentesco.Id.Equals(1))
                    {
                        //HIJOS
                        var r = (75.0 / 100.0) / Convert.ToDouble(CHijos);
                        item.Scala = Convert.ToDouble(r);
                    }
                    else if (item.Parentesco.Id.Equals(2) || item.Parentesco.Id.Equals(3))
                    {
                        //PADRE Y MADRE
                        var r = (25.0 / 100.0) / Convert.ToDouble(CPadres);
                        item.Scala = Convert.ToDouble(r);
                    }
                }

            }

        }

    }
}
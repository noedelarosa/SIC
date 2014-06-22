using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Empresa.RHH
{
    public class DeparamentoAsignado
    {
        public ObservableCollection<TDeparamentoAsignado> Lista { get; set; }
        private Departamento _depas = Departamento.GetInstance(); 
        
        public DeparamentoAsignado() {
            Lista = new ObservableCollection<TDeparamentoAsignado>();
        }

        public DeparamentoAsignado(TDepartamento departamento){

           this.Lista = new ObservableCollection<TDeparamentoAsignado>();
           SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
           TDeparamentoAsignado depaa;
           consulta.Parameters.Add("@depa_id", departamento.Id); // Emrpesa por defecto inabima...
           
           foreach (System.Data.DataRow fila in consulta.Execute.Dataset("inventario.dbo.RHH_DepartamentosAsignados_ViewDepa", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
               depaa = new TDeparamentoAsignado();
               //Asignando departamento objseto principal
               depaa.Departamento = _depas.Source(Convert.ToInt32(fila["depa_id"]))[0];
               depaa.Personal = new Personal(fila["per_cedula"].ToString())[0];
               //Asignando departamento al personal
               depaa.Personal.Departamento = depaa.Departamento; 
               this.Lista.Add(depaa); 
           }
        }

        public DeparamentoAsignado(Empresa.Comun.tbasepersona personal) {
            //dbo.RHH_DepartamentosAsignados_ViewCedula
        }

        public DeparamentoAsignado(Empresa.RHH.tpersonal personal){
            //dbo.
            this.Lista = new ObservableCollection<TDeparamentoAsignado>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            TDeparamentoAsignado depaa;
            consulta.Parameters.Add("@per_cedula", personal.Cedula); // Emrpesa por defecto inabima...
            
            foreach(System.Data.DataRow fila in consulta.Execute.Dataset("inventario.dbo.RHH_DepartamentosAsignados_ViewCedula", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                depaa = new TDeparamentoAsignado();
                depaa.Habilitado = Convert.ToBoolean(fila["depaa_habilitado"]);
                // Asignando departamento objseto principal
                depaa.Departamento = _depas.Source(Convert.ToInt32(fila["depa_id"]))[0];

                try{
                    depaa.Personal = new Personal(fila["per_cedula"].ToString())[0];
                }
                catch {
                    depaa.Personal = new tpersonal();
                }

                // Asignando departamento al personal
                depaa.Personal.Departamento = depaa.Departamento;
                this.Lista.Add(depaa);
            }

        }

        public TDeparamentoAsignado DameUltimaAsignacion(tpersonal personal) {
            foreach (TDeparamentoAsignado item in this.Lista)
            {
                if (item.Personal.Cedula.Equals(personal.Cedula))
                {
                    if (item.Habilitado)
                    {
                        return item;
                    }
                }
            }
            return new TDeparamentoAsignado(); 
        }

        public TDeparamentoAsignado DameUltimaAsignacion()
        {
            foreach (TDeparamentoAsignado item in this.Lista) {
                if (item.Habilitado) return item;
            } 

            return new TDeparamentoAsignado();
        }

        public void Add(TDeparamentoAsignado item, int idusuario) {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@depa_id", item.Departamento.Id);
            consulta.Parameters.Add("@usua_id", idusuario);
            consulta.Parameters.Add("@depaa_habilitado", true);
            consulta.Execute.NoQuery("[INVENTARIO].[dbo].RHH_DepartamentosAsignados_Insert", System.Data.CommandType.StoredProcedure);
        }

        public void Add(TDepartamento item, int idusuario)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@depa_id", item.Id);
            consulta.Parameters.Add("@usua_id", idusuario);
            consulta.Parameters.Add("@depaa_habilitado", true);

            consulta.Execute.NoQuery("[INVENTARIO].[dbo].RHH_DepartamentosAsignados_Insert", System.Data.CommandType.StoredProcedure);
        }

        public void Update(TDeparamentoAsignado item, int idusuario)
        {
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            consulta.Parameters.Add("@depa_id", item.Departamento.Id);
            consulta.Parameters.Add("@usua_id", idusuario);
            consulta.Parameters.Add("@depaa_habilitado", true);
            consulta.Execute.NoQuery("", System.Data.CommandType.StoredProcedure);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;



namespace Empresa.Docente
{
    /// ********************************************************************************************************* ////
    /// INABIMA
    /// Noe De La Rosa
    /// 29/10/2013
    /// Nombre:         Origen Beneficio
    /// Version:        1.0
    /// Depende:        TEstandar, System.Collections.ObjectModel 
    /// Padre:          tsolicitudpj
    /// ********************************************************************************************************* ////
    /// <summary>
    /// Objectivo:      Suplir los tipos de objecto para las solicitudes de pensiones y jubilaciones, Metodo Estatico.
    /// </summary>
    public class OrigenBeneficio
    {
        public ObservableCollection<Empresa.Comun.TEstandar> Lista { get; set; }

        private static OrigenBeneficio _OrigenBeneficio;

        private OrigenBeneficio() {
            //
            this.Lista = new ObservableCollection<Comun.TEstandar>();
            SSData.Servicios consulta = new SSData.Servicios(SSData.Servicios.Proveedor.SQL);
            Empresa.Comun.TEstandar item;
            foreach (System.Data.DataRow fila in consulta.Execute.Dataset("[dbo].[Pensiones_TipoSolicitudPJ_View]", System.Data.CommandType.StoredProcedure).Tables[0].Rows){
                item = new Comun.TEstandar();
                item.Id = Convert.ToInt32 (fila["solpjt_id"].ToString());
                item.Nombre = fila["solpjt_nombre"].ToString();
                this.Lista.Add(item);
            }
        }

        public static OrigenBeneficio GetInstance() {
            if (_OrigenBeneficio == null) _OrigenBeneficio = new OrigenBeneficio();
            return _OrigenBeneficio;
        }

        public Empresa.Comun.TEstandar GetItem(int id){
            foreach (Empresa.Comun.TEstandar item in this.Lista){
                if (item.Id.Equals(id)) return item;
            }
            return new Empresa.Comun.TEstandar();
        }

        public static void Clear()
        {
            _OrigenBeneficio.Lista = null;
            _OrigenBeneficio = null;
        }

    }
}

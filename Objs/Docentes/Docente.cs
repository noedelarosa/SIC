using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;  

namespace Empresa.Docente
{
   public  class Docente:DocenteBase {
       
       public Docente() { 
        //no construccion

       }

       public Docente(string cedula):base(cedula) {

           foreach (tdocente docente in this){
               // Detalles Pagos, Descuentos.
               docente.PagosDetalle = new PagoDetalle(docente.Cedula);
               if (docente.EsFallecido) docente.Calculo_Seguro_Funerario();
               // Historial de Pagos(No incluye detalles por descuento)
               docente.HistorialPagos = new Pagos(cedula);

               // ***** Recuperacion de Direccion y Contactos ******
               // Se busca el tipo 1 por defecto, localidad del docente.
               docente.Direccion = new Comun.DireccionAsignada(docente.Cedula, 1).GetLast();
               // Se busca el tipo 2 por defecto, fallecimiento del docente
               if(docente.EsFallecido) docente.DatosFellecimiento.Direccion = new Comun.DireccionAsignada(docente.Cedula, 2).GetLast();

               // Busqueda de Contacto.
               docente.Contacto = new Comun.ContactoAsignado(docente.Cedula).GetLast();  
           } 

       }

       public void Update(tdocente item) {
           base.Update(item);

           Empresa.Comun.DireccionAsignada dires = new Comun.DireccionAsignada();
           Empresa.Comun.ContactoAsignado contas = new Comun.ContactoAsignado();

           //Actualizando Registros de Dirección, de localidad del docente.
           if(item.Direccion.Existe){
               //Existe
               dires.Update(item.Direccion);
           }
           else{
               //No Existe 
               //Por defecto 1, Localidad.
               dires.Insert(item.Cedula,item.Direccion, 1);
           }

           if (item.EsFallecido){
                //Actualizando Registros de Dirección, fallecimiento del docente.
               
               if(item.DatosFellecimiento.Direccion.Existe){
                   //Existe
                   dires.Update(item.DatosFellecimiento.Direccion);
               }
               else {
                   //No Existe 
                   //Por defecto Fallecimiento.
                   dires.Insert(item.Cedula, item.DatosFellecimiento.Direccion, 2);
               }

           }

           // Actualizando Registro de Contacto.
           if (item.Contacto.Existe){
               //Existe 
               contas.Update(item.Contacto);  
           }
           else {
               //Existe No
               contas.Insert(item.Cedula,item.Contacto);
           }
           

       }


   }
}

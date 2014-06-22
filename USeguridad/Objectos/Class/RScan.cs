using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Empresa.USeguridad
{
    public class RScan
    {
        public System.Reflection.Assembly Asm {get;set;}
        
        public RScan(System.Reflection.Assembly asm) {
            this.Asm = asm;
        }
        public struct SRecuros {
            public string Nombre;
            public string Codigo;
            public SRecuros(string nombre, string codigo) {
                this.Nombre = nombre;
                this.Codigo = codigo;
            }
        }

        public List<SRecuros> Iniciar(){            
            Recurso rec = Recurso.GetInstance();

            List<SRecuros> _lista = new List<SRecuros>();
            foreach(Type it in this.Asm.GetTypes() ){
                //if (it.GetType().GetInterfaces().Contains(typeof(Empresa.Comun.IFirma))){
                try
                {

                    var tg = it;

                    if (tg.GetInterfaces().Contains(typeof(Empresa.Comun.IFirma))){
                        //if (tg.Name.Equals("Almacen")){
                            //var pros = tg.GetProperties();
                            // var proobj = tg.GetProperty("MCobjecto");
                            // PropertyInfo promod = tg.GetProperty("MCobjecto");
                            //Activator.CreateInstance(tg, BindingFlags.CreateInstance | BindingFlags.| BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.OptionalParamBinding, null, new Object[] { Type.Missing }, null);                            
                            //var rpromod = promod.GetValue(null, null);
                            //Activator.CreateInstance<>();
                            object cl = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(tg);

                            var cmod = cl.GetType().GetProperty("CModulo");
                            var mod = cl.GetType().GetProperty("Modulo");
                            var obj = cl.GetType().GetProperty("objecto");
                            var cobj = cl.GetType().GetProperty("Cobjecto");
                            var nom = cl.GetType().GetProperty("Nombre");

                            TRecurso trec = new TRecurso();
                            trec.CModulo = cmod.GetValue(cl,null).ToString();
                            trec.Codigo = cobj.GetValue(cl,null).ToString();
                            trec.Modulo = mod.GetValue(cl,null).ToString();
                            trec.Nombre = nom.GetValue(cl,null).ToString();

                            rec.Add(new KeyValuePair<string,TRecurso>( cobj.GetValue(cl,null).ToString(),trec));  

                        //}
                    }
                }
                catch (Exception e){ 
                

                }
                
                
                //foreach( PropertyInfo subit in it.GetProperties() ){
                //       // if(subit.Name.Equals("CModulo")){
                //    var t = subit.PropertyType;
                //     var resulcm = subit.GetValue(t,null);

                //            //_lista.Add(new SRecuros(resulcm, string.Empty));  
                //        //}

                //    //}
                //}
                            }
            return _lista;
        }
    }
}

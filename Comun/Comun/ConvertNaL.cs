using System;
using System.Collections.Generic;
using System.Collections.Specialized;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Comun
{
    public class ConvertNaL{

      private List<string> DivisionCifra(double valor){
        string Temp_Valor = valor.ToString().Replace(",", "");
        int indice  = 0;
        int Tamano = Temp_Valor.Length;
        List<string> Lista =  new List<string>();
            for(int i =1; i <= (Temp_Valor.Length / 3);i++){
                 if(Tamano > 3){
                    indice = Tamano - 3 ;
                    Tamano = indice;
                    Lista.Add(Temp_Valor.Substring(indice, 3));
                 }else{
                    Lista.Add(Temp_Valor.Substring(0, indice));
                 }
            }
            if(indice.Equals(1)) Lista.Add(Temp_Valor.Substring(0, indice));
            Lista.Reverse();
            return Lista ;
        }

      public string UnidadDecena(int valor, bool esmiles, bool esinicio) {

        string[] Contenedor = new string[100];
        int TempValor = Convert.ToInt32(valor);

        Contenedor[0] = "";
        Contenedor[1] = "UNO";
        Contenedor[2] = "DOS";
        Contenedor[3] = "TRES";
        Contenedor[4] = "CUATRO";
        Contenedor[5] = "CINCO";
        Contenedor[6] = "SEIS";
        Contenedor[7] = "SIETE";
        Contenedor[8] = "OCHO";
        Contenedor[9] = "NUEVE";

        Contenedor[10] = "DIEZ";
        Contenedor[11] = "ONCE";
        Contenedor[12] = "DOCE";
        Contenedor[13] = "TRECE";
        Contenedor[14] = "CATORCE";
        Contenedor[15] = "QUINCE";

        Contenedor[16] = "DIECI" + Contenedor[6];
        Contenedor[17] = "DIECI" + Contenedor[7];
        Contenedor[18] = "DIECI" + Contenedor[8];
        Contenedor[19] = "DIECI" + Contenedor[9];
        Contenedor[20] = "VEINTE";
        Contenedor[30] = "TREINTA";
        Contenedor[40] = "CUARENTA";
        Contenedor[50] = "CINCUENTA";
        Contenedor[60] = "SESENTA";
        Contenedor[70] = "SETENTA";
        Contenedor[80] = "OCHENTA";
        Contenedor[90] = "NOVENTA";

        switch (TempValor.ToString().Length){
            case 1:
                //unidad 
                return Contenedor[TempValor];
            case 2:
                //decena
                if(TempValor > 9 && TempValor <= 20) {
                    return Contenedor[TempValor];
                }
                else if (TempValor > 20 && TempValor <= 29){
                    return "VEINTI" + Contenedor[int.Parse(TempValor.ToString().Substring(1, 1))];
                }else{
                    if(Convert.ToByte(TempValor.ToString().Substring(1, 1)) > 0){
                        //var r = Contenedor[int.Parse(Convert.ToByte(TempValor.ToString().Substring(0, 1)) + "0")] + " Y " + Contenedor[int.Parse(TempValor.ToString().Substring(1, 1))];
                        if(esmiles == true){
                            //if (int.Parse(TempValor.ToString().Substring(1, 1)) <= 99){
                            //    if (esinicio == true){
                            //        return Contenedor[int.Parse(Convert.ToByte(TempValor.ToString().Substring(0, 1)) + "0")] + " Y " + " UN " ;
                            //    }
                            //    else{
                            //        return Contenedor[int.Parse(Convert.ToByte(TempValor.ToString().Substring(0, 1)) + "0")] + " Y " + Contenedor[int.Parse(TempValor.ToString().Substring(1, 1))];
                            //    }
                            //}
                            //else{
                                return Contenedor[int.Parse(Convert.ToByte(TempValor.ToString().Substring(0, 1)) + "0")] + " Y " + Contenedor[int.Parse(TempValor.ToString().Substring(1, 1))];
                            //}
                        }
                        else{
                            return Contenedor[int.Parse(Convert.ToByte(TempValor.ToString().Substring(0, 1)) + "0")] + " Y " + Contenedor[int.Parse(TempValor.ToString().Substring(1, 1))];
                        }
                    }else{
                            return Contenedor[TempValor];
                    }
                }
        }
         return Contenedor[0];
     }

      private string Centena(double valor, bool esmiles, bool esinicio){
        int TempValor = Convert.ToInt32(valor);

        switch(TempValor.ToString().Length){
            case 1:
                //unidad
                return UnidadDecena(Convert.ToInt32(valor), esmiles,esinicio);
            case 2:
                //decena
                return UnidadDecena(Convert.ToInt32(valor), esmiles, esinicio);
            case 3:
                //centena
               if (int.Parse(Convert.ToInt32(valor).ToString().Substring(0, 1)) == 2 || int.Parse(Convert.ToInt32(valor).ToString().Substring(0, 1)) == 3 || int.Parse(Convert.ToInt32(valor).ToString().Substring(0, 1)) == 4 || int.Parse(Convert.ToInt32(valor).ToString().Substring(0, 1)) == 6 || int.Parse(Convert.ToInt32(valor).ToString().Substring(0, 1)) == 8 ) {
                    //200,300,400,600,800
                    if( int.Parse(TempValor.ToString().Substring(1, 2)) == 0 ){
                        return UnidadDecena(int.Parse(TempValor.ToString().Substring(0, 1)), esmiles, esinicio) + "CIENTOS ";
                    }else{
                        return UnidadDecena(int.Parse(TempValor.ToString().Substring(0, 1)), esmiles, esinicio) + "CIENTOS " + UnidadDecena(int.Parse(TempValor.ToString().Substring(1, 2)), esmiles, esinicio);
                    }
               }else{
                    //100,500,700,900
                    if( ((int)valor) == 100){
                        return " CIEN ";
                    }
                        else if(((int)valor) > 100 && ((int)valor) <= 199){
                            return " CIENTO " + UnidadDecena(int.Parse(TempValor.ToString().Substring(1, 2)), esmiles, esinicio);
                    }

                    if( ((int)valor) >= 500 && ((int)valor) <= 599 ){
                        return " QUINIENTOS " + UnidadDecena(int.Parse(TempValor.ToString().Substring(1, 2)), esmiles, esinicio);
                    }

                    if( ((int)valor) >= 700 && ((int)valor) <= 799){
                        return " SETECIENTOS " + UnidadDecena(int.Parse(TempValor.ToString().Substring(1, 2)), esmiles, esinicio);
                    }

                    if( ((int)valor) >= 900 && ((int)valor) <= 999 ){
                        return " NOVECIENTOS " + UnidadDecena(int.Parse(TempValor.ToString().Substring(1, 2)), esmiles, esinicio);
                    }
                    break;
               }
       }
       return UnidadDecena(0,false,false);
      }

      private string MilesBillones(string valor)
      {
          string TempValor = valor;

            if( TempValor.ToString().Length == 1){
                  // UN1IDAD
                return UnidadDecena(int.Parse(TempValor), false,false);
            }else if( TempValor.ToString().Length == 2){
                  // DECENA
                return UnidadDecena(int.Parse(TempValor), false,false);
            }else if( TempValor.ToString().Length == 3){
                  //CENTENA
                  return Centena(double.Parse(TempValor),false,false);
            }else if( TempValor.ToString().Length  >= 4 && TempValor.ToString().Length  <= 6 ){
                  // MILES
                  List<string> it = DivisionCifra(double.Parse(TempValor));
                  if(int.Parse(it[0]) == 1){
                      return " MIL " + Centena(double.Parse(it[1]),true,false);
                  }
                  else{
                      //if(double.Parse(it[1]) <= 99){
                      //return Centena(double.Parse(it[0])) + " UN MIL " + Centena(double.Parse(it[1]));
                      //}else{
                      return Centena(double.Parse(it[0]),true,true) + " MIL " + Centena(double.Parse(it[1]),true,false);
                      //}
                  }
            }else if( TempValor.ToString().Length  >= 7 && TempValor.ToString().Length  <= 9 ){
                  //MILLONES

                  List<string> it1 = DivisionCifra(double.Parse(TempValor));

                  if (int.Parse(it1[0]) == 1){
                      if(int.Parse(it1[1]) > 0){
                          return " UN MILLON " + Centena(double.Parse(it1[1]),true,false) + " MIL " + Centena(double.Parse(it1[2]),false,false);
                      }
                      else {
                          return " UN MILLON " + Centena(double.Parse(it1[1]),false,false) + " " + Centena(double.Parse(it1[2]),false,false);
                      }
                  }
                  else{
                      if (int.Parse(it1[1]) > 0){
                          return Centena(double.Parse(it1[0]),true,false) + " MILLONES " + Centena(double.Parse(it1[1]),false,false) + " MIL " + Centena(double.Parse(it1[2]),false,false);
                      }
                      else{
                          return Centena(double.Parse(it1[0]),true,false) + " MILLONES " + Centena(double.Parse(it1[1]),false,false) + " " + Centena(double.Parse(it1[2]),false,false);
                      }
                  }
                } else if( TempValor.ToString().Length  >= 10 ){
                  // BILLONES
                  return string.Empty;
          }
            return string.Empty;
      }

      public string Letra(double _Valor){
        string Decimales = String.Empty;
        int Base=0;
        string Valor = _Valor.ToString("F", System.Globalization.CultureInfo.InvariantCulture);

        try {
            
            if(Valor.IndexOf(".") > 0){
                Decimales = Valor.Substring(Valor.ToString().IndexOf("."), Valor.Length - Valor.IndexOf(".")).Replace(".", "");
                Base = int.Parse(Valor.Substring(0, Valor.IndexOf(".")));
            } else {
                Base = int.Parse(Valor);
            }

            if(int.Parse(Decimales) > 0){
                return MilesBillones(Base.ToString()) + " PESOS CON " + Decimales + "/100";
                //Return MilesBillones(Base) & " CON " & Centena(Decimales)
            }else{
                return MilesBillones(Base.ToString()) + " CON 00/100";
            }

           
        }catch{
            return string.Empty;
        }
     }
    }
}
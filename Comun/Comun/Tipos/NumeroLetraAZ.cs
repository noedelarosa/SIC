using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Comun{
   public static class NumeroLetra
    {
     static  private string[] letras = new string[100];
      static private void InicializarLetras(){ 
           letras[0] = "A";
           letras[1] = "B" ;
           letras[2] ="C";
           letras[3] ="D" ;
           letras[4] ="E";
           letras[5] ="F" ;
           letras[6] ="G" ;
           letras[7] ="H" ;
           letras[8] = "I" ;
           letras[9] = "J" ;
           letras[10] = "K";
           letras[11] = "L";
           letras[12] = "LL";
           letras[13] = "M";
           letras[14] = "N";
           letras[15] = "Ñ";
           letras[16] ="O";
           letras[17] ="P";
           letras[18] ="Q";
           letras[19] ="R";
           letras[20] ="S";
           letras[21] ="T";
           letras[22] ="U";
           letras[23] ="V";
           letras[24] ="W";
           letras[25] ="X";
           letras[26] ="Y";
           letras[27] ="Z";
       }

       public static string aLetra(int indice){
           InicializarLetras();
           string letra = string.Empty;
           if (indice > 27){
               letra=  letras[indice] + indice.ToString(); 
           }
           else {
               letra = letras[indice];  
           }
           return letra;
       }


    }
}

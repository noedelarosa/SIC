using System;
using System.Collections.Generic;
using System.Linq;
//using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
public enum TypeImagen
{
    BMP =0,
    JPG =1,
    PNG =2
}    
    public class  WorkImage
    {
        public static byte[] GetArray(BitmapSource source)
        {
            if (source != null){
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                BmpBitmapEncoder bmpenco = new BmpBitmapEncoder();
                bmpenco.Frames.Add(BitmapFrame.Create(source));
                bmpenco.Save(ms);
                ms.Flush();
                return ms.ToArray();
            }
            else { 
                return new byte[0];
            }
        }

        public static byte[] GetArray(BitmapSource source, TypeImagen tipo){
            if (source != null){
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                switch (tipo){
                    case TypeImagen.BMP:
                        BmpBitmapEncoder bmpenco = new BmpBitmapEncoder();    
                        bmpenco.Frames.Add(BitmapFrame.Create(source));
                        bmpenco.Save(ms);
                        break;
                    case TypeImagen.JPG:
                        JpegBitmapEncoder jpgenco = new JpegBitmapEncoder();
                        jpgenco.Frames.Add(BitmapFrame.Create(source));
                        jpgenco.Save(ms);
                        break;
                }
                ms.Flush();
                return ms.ToArray();
            }
            else{
                return new byte[0];
            }
        }

        public static byte[] GetArray(BitmapImage source){
            return GetArray((BitmapSource)source);
        }

        public static BitmapSource ToImage(byte[] arg, TypeImagen tipo) {
            BitmapSource temporigen = null;
            if(arg != null){
                System.IO.MemoryStream ms = new System.IO.MemoryStream(arg);

                switch (tipo)
                {
                    case TypeImagen.BMP:

                        BmpBitmapDecoder bmpdeco = new BmpBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        temporigen = bmpdeco.Frames[0];
                        break;
                    case TypeImagen.JPG:
                        
                        JpegBitmapDecoder jpgdeco = new JpegBitmapDecoder(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                        temporigen = jpgdeco.Frames[0];
                        break;
                }
            }
            return temporigen;
        }
        public static bool ToFile(BitmapSource source, string s_uri)
        {
            if (source != null)
            {
                System.IO.File.Delete(s_uri);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                BmpBitmapEncoder bmpenco = new BmpBitmapEncoder();
                bmpenco.Frames.Add(BitmapFrame.Create(source));
                bmpenco.Save(ms);
                ms.Flush();
                
                System.IO.Stream st = System.IO.File.Open(s_uri, System.IO.FileMode.CreateNew);
                st.Write(ms.GetBuffer(), 0, ms.ToArray().Length);
                
                st.Close();
                st.Dispose();

                ms.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }
    }


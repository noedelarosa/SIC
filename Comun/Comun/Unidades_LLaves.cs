using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Management.Instrumentation;

namespace Empresa.Comun
{
    public class Unidad_LLaves
    {
        private const string __constran_driver_name = "SG_INA_LA_0";
        public DriveInfo DameUnidadLLave()
        {
           foreach(DriveInfo info in DriveInfo.GetDrives())
           {
               if (info.IsReady)
               {
                   if (info.DriveType == DriveType.Removable || info.DriveType == DriveType.CDRom)
                   {
                       if (info.VolumeLabel.Equals(__constran_driver_name))
                       {
                           return info;
                       }
                   }
               }
           }
            return null;
        }

        public string GetUniqueId() {
            ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            
            foreach (ManagementObject currentObject in theSearcher.Get())
            {
                //var r = currentObject.Properties["PNPDeviceID"].Value.ToString()
                //Console.WriteLine("{0}-{1}", "PNPDeviceID", currentObject.Properties["PNPDeviceID"].Value);



            }
            return string.Empty;

        }
    }
}

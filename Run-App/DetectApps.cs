using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_App
{
    internal class DetectApps
    {
        public static string DetectAppInstalledPath()
        {
            var software = Registry.LocalMachine.OpenSubKey("Software");

            if(software == null)
            {
                Console.WriteLine("cannot find software in registry");
                return string.Empty;
            }    

            var adobe = software.OpenSubKey("Adobe");
            if (adobe == null)
            {
                Console.WriteLine("cannot find software/Adobe in registry");

                var policies = software.OpenSubKey("Policies");

                if (policies == null)
                {
                    Console.WriteLine("cannot find software/Policies in registry");
                    return string.Empty;
                }
                    
                adobe = policies.OpenSubKey("Adobe");
                
                if (adobe == null)
                {
                    Console.WriteLine("cannot find software/Policies/Adobe in registry");
                    return string.Empty;
                }
            }

            var adobeAcrobat = adobe.OpenSubKey("Adobe Acrobat");

            if(adobeAcrobat == null)
            {
                Console.WriteLine("cannot find ../Adobe/Adobe Acrobat in registry");
                return string.Empty;
            }

            var acrobatDC = adobeAcrobat.OpenSubKey("DC");

            if (acrobatDC == null)
            {
                Console.WriteLine("cannot find ../Adobe/Adobe Acrobat/DC in registry");
                return string.Empty;
            }

            var installPath = acrobatDC.OpenSubKey("InstallPath");

            if (installPath == null)
            {
                Console.WriteLine("cannot find ../Adobe/Adobe Acrobat/DC/InstallPath in registry");
                return string.Empty;
            }

            var path = installPath.GetValue(string.Empty);

            return path != null ? (string)path : string.Empty;
        }
    }
}

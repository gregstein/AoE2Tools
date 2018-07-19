using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Launcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher.LnchR());
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //{

            //    if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
            //    {
            //        string aoe2path = key.GetValue("AoE2Path").ToString();
            //        string Select_p = aoe2path;
            //        var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            //        var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            //        //found keys
            //        if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe") && IsAdministrator() == false)
            //        {

            //            //Reboot as admin
            //            var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //            ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //            startInfo.Verb = "runas";
            //            System.Diagnostics.Process.Start(startInfo);
            //            Process.GetCurrentProcess().Kill();
            //        }
            //        else if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe") && IsAdministrator() == true)
            //        {

            //            //Reboot as admin
            //            var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //            ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //            startInfo.Verb = "runas";
            //            System.Diagnostics.Process.Start(startInfo);
            //            Process.GetCurrentProcess().Kill();
            //        }
            //    }
            //}
          
        }

        //private static bool IsAdministrator()
        //{
        //    WindowsIdentity identity = WindowsIdentity.GetCurrent();
        //    WindowsPrincipal principal = new WindowsPrincipal(identity);
        //    return principal.IsInRole(WindowsBuiltInRole.Administrator);
        //}
    }
}

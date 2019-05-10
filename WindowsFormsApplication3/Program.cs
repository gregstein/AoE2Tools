using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
namespace WindowsFormsApplication3
{

    static class Program
    {
        static Mutex mutex = new Mutex(true, "Github.com/gregstein/AoE2Tools AoE2Tools");
        //static Mutex mutex = new Mutex(true, "HDToAoC");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            //Once Instance
            // Wait 5 seconds if contended – in case another instance
            // of the program is in the process of shutting down.

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Get45PlusFromRegistry();
            if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
            {
                MessageBox.Show("AoE2Tools is already running!");

                return;
            }

            mutex.ReleaseMutex();

            Application.Run(new TestUI());
            
        }



        private static void Get45PlusFromRegistry()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    //MessageBox.Show(".NET Framework Version: " + CheckFor45PlusVersion((int)ndpKey.GetValue("Release")));
                }
                else
                {
                    MessageBox.Show("AoE2Tools Requires .NET Framework Version 4.5 or later. Click OK to access Microsoft official website and download .NET 4.5 framework.");
                    Process.Start(@"https://www.microsoft.com/en-us/download/details.aspx?id=30653");
                    Process.GetCurrentProcess().Kill();
                }
            }
        }

        // Checking the version using >= will enable forward compatibility.
        private static string CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 461808)
                return "4.7.2 or later";
            if (releaseKey >= 461308)
                return "4.7.1";
            if (releaseKey >= 460798)
                return "4.7";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
                return "4.6.1";
            if (releaseKey >= 393295)
                return "4.6";
            if (releaseKey >= 379893)
                return "4.5.2";
            if (releaseKey >= 378675)
                return "4.5.1";
            if (releaseKey >= 378389)
                return "4.5";
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }

        public static MessageBoxIcon _mbIcon { get; set; }

        public static MessageBoxButtons _mbButtons { get; set; }
    }
}

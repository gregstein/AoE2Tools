using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
namespace WindowsFormsApplication3
{
    public partial class Options : KryptonForm
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            CheckOptions();
        }

        private void kryptonCheckButton1_Click(object sender, EventArgs e)
        {

        }

        private void addstartup_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                 if (addstartup.Checked)
                     rk.SetValue("AoE2Tools", Directory.GetCurrentDirectory() + @"\Launcher.exe");
            else
                rk.DeleteValue("AoE2Tools", false);
            }

              
        }

        private void kryptonCheckButton2_Click(object sender, EventArgs e)
        {

        }

         void CheckOptions()
        {
            //Startup
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "AoE2Tools", null) != null)
                    //string aoe2path = rk.GetValue("AoE2Tools").ToString();
                    addstartup.Checked = true;
                else
                    addstartup.Checked = false;
            }
            //Launcher
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Launcher", null) != null)
                {
                    string launchval = rk.GetValue("Launcher").ToString();
                    if (launchval == "1")
                        launcher.Checked = false;
                    else
                        launcher.Checked = true;
                }

                    
               
            }
        }

         private void launcher_Click(object sender, EventArgs e)
         {


         }

         private void launcher_CheckedChanged(object sender, EventArgs e)
         {
             using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
             {
                 if (launcher.Checked)
                     rk.SetValue("AoE2Tools", Directory.GetCurrentDirectory() + @"\AoE2Tools.exe");
                 else
                     rk.SetValue("AoE2Tools", Directory.GetCurrentDirectory() + @"\Launcher.exe");
             }
    
         }

         private void kryptonButton1_Click(object sender, EventArgs e)
         {
            // RegistryKey aoe2tools =
            //Registry.CurrentUser.CreateSubKey("Software\\AoE2Tools");
             DialogResult dialogResult = KryptonMessageBox.Show("Reset AoE2Tools?", "Confirmation", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {
                 launcher.Checked = true;
                 System.Threading.Thread.Sleep(1500);
                 Registry.CurrentUser.DeleteSubKeyTree("Software\\AoE2Tools");
                 var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                 ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                 System.Diagnostics.Process.Start(startInfo);
                 Process.GetCurrentProcess().Kill();
             }
             else if (dialogResult == DialogResult.No)
             {
               
             }

         }
    }
}

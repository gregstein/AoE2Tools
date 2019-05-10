using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Globalization;
using Microsoft.Win32;
using System.Resources;

namespace WindowsFormsApplication3
{
    public partial class Fixing_Permissions : KryptonForm
    {
        public Fixing_Permissions()
        {
            InitializeComponent();
            getpath();
        }
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
void getpath()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    GamePath.Text = aoe2path;
                }
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                File.WriteAllText(GamePath.Text + @"\aoe2toolscheck.txt", "AoE2Tools can use this directory to serve you recorded games, Sir. ROFL");
                //Break
                System.Threading.Thread.Sleep(1000);
                if (IsAdministrator() == true)
                {
                    DirectorySecurity sec = Directory.GetAccessControl(GamePath.Text);
                    // Using this instead of the "Everyone" string means we work on non-English systems.
                    SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                    sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                    Directory.SetAccessControl(GamePath.Text, sec);
                    System.Threading.Thread.Sleep(1000);
                }
                else if (IsAdministrator() == false)
                {
                    //Double check
                    try
                    {
                        File.WriteAllText(GamePath.Text + @"\aoe2toolscheck.txt", "AoE2Tools can use this directory to serve you recorded games, Sir. ROFL");
                        System.Threading.Thread.Sleep(1000);

                    }
                    catch (UnauthorizedAccessException)
                    {

                        KryptonMessageBox.Show(res_man.GetString("_requireadmin", cul), "Restarting!");
                        var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                        ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                        startInfo.Verb = "runas";
                        try
                        {
                            System.Diagnostics.Process.Start(startInfo);
                        }
                        catch (System.ComponentModel.Win32Exception)
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                        Process.GetCurrentProcess().Kill();
                    }


                }

            }
            catch (UnauthorizedAccessException)
            {
                KryptonMessageBox.Show(res_man.GetString("_requireadmin", cul), "Restarting!");
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    Process.GetCurrentProcess().Kill();
                }
                Process.GetCurrentProcess().Kill();
            }
        }

        private async void Fixing_Permissions_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
            await Task.Run(() => kryptonButton1.PerformClick());
            
        }
        private void switchlang()
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Transl", null) != null)
                {
                    string translatestr = rk.GetValue("Transl").ToString();
                    if (translatestr == "en")
                    {
                        cul = CultureInfo.CreateSpecificCulture("en");
                    }
                    else if (translatestr == "fr")
                    {
                        cul = CultureInfo.CreateSpecificCulture("fr");
                    }
                    else if (translatestr == "es")
                    {
                        cul = CultureInfo.CreateSpecificCulture("es");
                    }

                }
                else
                {
                    cul = CultureInfo.CreateSpecificCulture("en");
                }
            }
           
            try
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    kryptonButton1.Text = res_man.GetString("_fixit", cul);
                    maytake.Text = res_man.GetString("_maytake", cul);
                    plswait.Text = res_man.GetString("_plswait", cul);
                });
            }
            catch (System.InvalidOperationException)
            {

            }
            catch (SystemException)
            {

            }



        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            preloader.Image = WindowsFormsApplication3.Properties.Resources.check;
            plswait.Text = "Success!";
            GamePath.Enabled = true;
            maytake.Visible = false;
            //using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //{
            //    rk.SetValue("AoE2Path", GamePath.Text);
            //}
            KryptonMessageBox.Show(res_man.GetString("_needrestart", cul), "Success!");
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            kryptonButton1.Enabled = false;
            tableLayoutPanel3.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}

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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
namespace WindowsFormsApplication3
{
    public partial class ModsOffline : KryptonForm
    {
        public ModsOffline()
        {
            InitializeComponent();
            this.TopMost = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void ModsOffline_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            //install short walls

            installshort.RunWorkerAsync();

            

        }
        public void aoepath()
        {
            using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Skey != null)
                {
                    string gpath = Skey.GetValue("AoE2Path").ToString();

                    if (gpath != null)
                    {
                        mkdpath.Text = gpath;
                    }
                    else
                    {
                        KryptonMessageBox.Show("Game Path Not Found!", "Error!");
                        this.Close();
                    }
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            aoepath();
            Heuristic();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            uninstallshort.RunWorkerAsync();


        }

        private void installshort_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    shortwallspreload.Enabled = true;
                    shortwallspreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Short Walls" + "\\i\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "shortwalls.bat";
                    File.WriteAllText("shortwalls.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    kryptonButton4.Enabled = false;
                    kryptonButton3.Enabled = true;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Short Walls", "yes");
                        }
                    }
                  
                        shortwallspreload.Enabled = false;
                        shortwallspreload.Visible = false;
                  

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
           
        }

        private void uninstallshort_DoWork(object sender, DoWorkEventArgs e)
        {
             BeginInvoke((MethodInvoker)delegate
            {
            //uninstall short walls
            try
            {
                shortwallspreload.Enabled = true;
                shortwallspreload.Visible = true;

                string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Short Walls" + "\\u\\";
                string _Gdata = mkdpath.Text + "\\Data\\";
                System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo8.FileName = "cmd.exe";
                startInfo8.Arguments = "/c" + "shortwalls.bat";
                File.WriteAllText("shortwalls.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                process8.StartInfo = startInfo8;
                process8.Start();
                process8.WaitForExit();
                kryptonButton3.Enabled = false;
                kryptonButton4.Enabled = true;
                using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (shortwall != null)
                    {

                        shortwall.SetValue("Short Walls", "no");
                    }
                }
                shortwallspreload.Enabled = false;
                shortwallspreload.Visible = false;
            }

            catch (SystemException)
            {
                KryptonMessageBox.Show("Cancelled!", "Alert");


            }
            });
        }

        private void installsmall_DoWork(object sender, DoWorkEventArgs e)
        {

            BeginInvoke((MethodInvoker)delegate
            {                 

                try
                {
  

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Small Trees" + "\\i\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "smalltrees.bat";
                    File.WriteAllText("smalltrees.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    stin.Enabled = false;
                    stun.Enabled = true;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Small Trees", "yes");
                        }
                    }

                    smalltreespreload.Enabled = false;
                    smalltreespreload.Visible = false;
                    File.Delete("smalltrees.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void stun_Click(object sender, EventArgs e)
        {
            uninstallsmall.RunWorkerAsync();
        }

        private void uninstallsmall_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    smalltreespreload.Enabled = true;
                    smalltreespreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Small Trees" + "\\u\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "smalltrees.bat";
                    File.WriteAllText("smalltrees.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    stin.Enabled = true;
                    stun.Enabled = false;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Small Trees", "no");
                        }
                    }

                    smalltreespreload.Enabled = false;
                    smalltreespreload.Visible = false;
                    File.Delete("smalltrees.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void installaip_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    aippreload.Enabled = true;
                    aippreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Advanced Idle Pointer" + "\\i\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "aip.bat";
                    File.WriteAllText("aip.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    aipinstall.Enabled = false;
                    aipuninstall.Enabled = true;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Advanced Idle Pointer", "yes");
                        }
                    }

                    aippreload.Enabled = false;
                    aippreload.Visible = false;
                    File.Delete("aip.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!","Alert");


                }
            });
        }

        private void aipinstall_Click(object sender, EventArgs e)
        {
            installaip.RunWorkerAsync();
        }

        private void uninstallaip_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    aippreload.Enabled = true;
                    aippreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Advanced Idle Pointer" + "\\u\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "aip.bat";
                    File.WriteAllText("aip.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    aipuninstall.Enabled = false;
                    aipinstall.Enabled = true;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Advanced Idle Pointer", "no");
                        }
                    }

                    aippreload.Enabled = false;
                    aippreload.Visible = false;
                    File.Delete("aip.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void aipuninstall_Click(object sender, EventArgs e)
        {
            uninstallaip.RunWorkerAsync();
        }

        private void stin_Click(object sender, EventArgs e)
        {
            smalltreespreload.Enabled = true;
            smalltreespreload.Visible = true;
            installsmall.RunWorkerAsync();
        }

        private void installhn_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    hnpreload.Enabled = true;
                    hnpreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Huge Number" + "\\i\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "hn.bat";
                    File.WriteAllText("hn.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    hninstall.Enabled = false;
                    hnuninstall.Enabled = true;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Huge Number", "yes");
                        }
                    }

                    hnpreload.Enabled = false;
                    hnpreload.Visible = false;
                    File.Delete("hn.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void uninstallhn_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    hnpreload.Enabled = true;
                    hnpreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Huge Number" + "\\u\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "hn.bat";
                    File.WriteAllText("hn.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    hninstall.Enabled = true;
                    hnuninstall.Enabled = false;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Huge Number", "no");
                        }
                    }

                    hnpreload.Enabled = false;
                    hnpreload.Visible = false;
                    File.Delete("hn.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void hninstall_Click(object sender, EventArgs e)
        {
            installhn.RunWorkerAsync();
        }

        private void hnuninstall_Click(object sender, EventArgs e)
        {
            uninstallhn.RunWorkerAsync();
        }

        private void installbb_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    bbpreload.Enabled = true;
                    bbpreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Blue Berries" + "\\i\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "bb.bat";
                    File.WriteAllText("bb.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    bbuninstall.Enabled = true;
                    bbinstall.Enabled = false;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Blue Berries", "yes");
                        }
                    }

                    bbpreload.Enabled = false;
                    bbpreload.Visible = false;
                    File.Delete("b.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void uninstallbb_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    bbpreload.Enabled = true;
                    bbpreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Blue Berries" + "\\u\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "bb.bat";
                    File.WriteAllText("bb.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    bbuninstall.Enabled = false;
                    bbinstall.Enabled = true;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Blue Berries", "no");
                        }
                    }

                    bbpreload.Enabled = false;
                    bbpreload.Visible = false;
                    File.Delete("b.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void bbuninstall_Click(object sender, EventArgs e)
        {
            uninstallbb.RunWorkerAsync();
        }

        private void bbinstall_Click(object sender, EventArgs e)
        {
            installbb.RunWorkerAsync();
        }

        private void installlg_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    lgpreload.Enabled = true;
                    lgpreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Light Grid" + "\\i\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "lg.bat";
                    File.WriteAllText("lg.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "terrain.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    ilg.Enabled = false;
                    ulg.Enabled = true;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Light Grid", "yes");
                        }
                    }

                    lgpreload.Enabled = false;
                    lgpreload.Visible = false;
                    File.Delete("lg.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void uninstalllg_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    lgpreload.Enabled = true;
                    lgpreload.Visible = true;

                    string drspth = Directory.GetCurrentDirectory() + @"\data\" + "drsbuild.exe";
                    string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Light Grid" + "\\u\\";
                    string _Gdata = mkdpath.Text + "\\Data\\";
                    System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                    startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo8.FileName = "cmd.exe";
                    startInfo8.Arguments = "/c" + "lg.bat";
                    File.WriteAllText("lg.bat", "\"" + drspth + "\"" + "/a \"" + _Gdata + "terrain.drs\" " + "\"" + _modsinstall + "*.*\"");
                    process8.StartInfo = startInfo8;
                    process8.Start();
                    process8.WaitForExit();

                    ilg.Enabled = true;
                    ulg.Enabled = false;

                    using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (shortwall != null)
                        {

                            shortwall.SetValue("Light Grid", "no");
                        }
                    }

                    lgpreload.Enabled = false;
                    lgpreload.Visible = false;
                    File.Delete("lg.bat");

                }

                catch (SystemException)
                {
                    KryptonMessageBox.Show("Cancelled!", "Alert");


                }
            });
        }

        private void ilg_Click(object sender, EventArgs e)
        {
            installlg.RunWorkerAsync();
        }

        private void ulg_Click(object sender, EventArgs e)
        {
            uninstalllg.RunWorkerAsync();
        }

        private void bbinstall_Click_1(object sender, EventArgs e)
        {
            bbpreload.Enabled = true;
            bbpreload.Visible = true;
            
            bbinstall.Enabled = false;
            string drspth = Directory.GetCurrentDirectory() + @"\data\";
            string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Blue Berries" + "\\i\\";
            System.Diagnostics.Process process12 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo12 = new System.Diagnostics.ProcessStartInfo();
            startInfo12.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo12.FileName = "cmd.exe";
            startInfo12.Arguments = "/c" + "blueberries.bat";
            File.WriteAllText("blueberries.bat", "\"" + drspth + "drsbuild.exe\"" + "/a \"" + mkdpath.Text + "\\Data\\" + "graphics.drs\" " + "\"" + _modsinstall + "gra02560.slp\"" + Environment.NewLine);
            File.AppendAllText("blueberries.bat", "\"" + drspth + "drsbuild.exe\"" + "/a \"" + mkdpath.Text + "\\Data\\" + "interfac.drs\" " + "\"" + _modsinstall + "int50730.slp\"" + Environment.NewLine);
            process12.StartInfo = startInfo12;
            process12.Start();
            process12.WaitForExit();
            bbuninstall.Enabled = true;
            bbpreload.Enabled = false;
            bbpreload.Visible = false;
            //installbb.RunWorkerAsync();
        }

        private void bbuninstall_Click_1(object sender, EventArgs e)
        {
            bbpreload.Enabled = true;
            bbpreload.Visible = true;

            bbinstall.Enabled = false;
            string drspth = Directory.GetCurrentDirectory() + @"\data\";
            string _modsinstall = Directory.GetCurrentDirectory() + @"\data\mods\" + "Blue Berries" + "\\u\\";
            System.Diagnostics.Process process12 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo12 = new System.Diagnostics.ProcessStartInfo();
            startInfo12.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo12.FileName = "cmd.exe";
            startInfo12.Arguments = "/c" + "blueberries.bat";
            File.WriteAllText("blueberries.bat", "\"" + drspth + "drsbuild.exe\"" + "/a \"" + mkdpath.Text + "\\Data\\" + "graphics.drs\" " + "\"" + _modsinstall + "gra02560.slp\"" + Environment.NewLine);
            File.AppendAllText("blueberries.bat", "\"" + drspth + "drsbuild.exe\"" + "/a \"" + mkdpath.Text + "\\Data\\" + "interfac.drs\" " + "\"" + _modsinstall + "int50730.slp\"" + Environment.NewLine);
            process12.StartInfo = startInfo12;
            process12.Start();
            process12.WaitForExit();
            bbuninstall.Enabled = true;
            bbpreload.Enabled = false;
            bbpreload.Visible = false;
            //uninstallbb.RunWorkerAsync();
        }

        private void aipinstall_Click_1(object sender, EventArgs e)
        {
            installaip.RunWorkerAsync();
        }

        private void aipuninstall_Click_1(object sender, EventArgs e)
        {
            uninstallaip.RunWorkerAsync();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://voobly.com/gamemods/mod/20/Small-Trees");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://voobly.com/gamemods/mod/587/Short-Walls");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://voobly.com/gamemods/mod/457/Light-Grid-Terrains");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://voobly.com/gamemods/mod/697/Huge-Number");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://voobly.com/gamemods/mod/739/Advanced-Idle-Pointer");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://voobly.com/gamemods/mod/92/Blue-Berries");
        }
        public void Heuristic()
        {
            using (RegistryKey heurs = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                if (heurs != null)
                {
                    string st = heurs.GetValue("Small Trees").ToString();
                    string hn = heurs.GetValue("Huge Number").ToString();
                    string lg = heurs.GetValue("Light Grid").ToString();
                    string sw = heurs.GetValue("Short Walls").ToString();
                    string aip = heurs.GetValue("Advanced Idle Pointer").ToString();
                    string bb = heurs.GetValue("Blue Berries").ToString();

                    if (st == "yes")
                    {
                        stin.Enabled = false;
                    }
                    else
                    {
                        stun.Enabled = false;
                    }


                    if(hn == "yes")
                    {
                        hninstall.Enabled = false;
                    }
                    else
                    {
                        hnuninstall.Enabled = false;
                    }

                    if (lg == "yes")
                    {
                        ilg.Enabled = false;
                    }
                    else
                    {
                        ulg.Enabled = false;
                    }

                    if (sw == "yes")
                    {
                        kryptonButton4.Enabled = false;
                    }
                    else
                    {
                        kryptonButton3.Enabled = false;
                    }


                    if (aip == "yes")
                    {
                        aipinstall.Enabled = false;
                    }
                    else
                    {
                        aipuninstall.Enabled = false;
                    }


                    if (bb == "yes")
                    {
                        bbinstall.Enabled = false;
                    }
                    else
                    {
                        bbuninstall.Enabled = false;
                    }
                }
            }
        }
    }
}

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
using System.Net;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
namespace WindowsFormsApplication3
{
    public partial class UserPatch : KryptonForm
    {
        public UserPatch()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private async void UserPatch_Load(object sender, EventArgs e)
        {
            await Task.Run(() => FixAsso());
            backgroundWorker1.RunWorkerAsync();

        }
        public void FixAsso()
        {
            //mgz reassign
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\mgz_auto_file\shell\open\command", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\mgz_auto_file\shell\open\command", "", null) != null)
                {
                    if (rk.GetValue("").ToString().Contains("age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                    }
                    if (rk.GetValue("").ToString().Contains("Age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("Age2_x1.exe", "AoE2Tools.exe"));
                    }


                }


                else
                {
                    //rk.DeleteValue("AoE2Tools", false);

                }

            }
            //mgx reassign
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\mgx_auto_file\shell\open\command", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\mgx_auto_file\shell\open\command", "", null) != null)
                {
                    if (rk.GetValue("").ToString().Contains("age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                    }
                    if (rk.GetValue("").ToString().Contains("Age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("Age2_x1.exe", "AoE2Tools.exe"));
                    }


                }


                else
                {


                }

            }
            //base reassign
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\age2.age2_x1.0\shell\Open\command", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\age2.age2_x1.0\shell\Open\command", "", null) != null)
                {
                    if (rk.GetValue("").ToString().Contains("age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                    }
                    if (rk.GetValue("").ToString().Contains("Age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("Age2_x1.exe", "AoE2Tools.exe"));
                    }


                }


                else
                {


                }

            }

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://userpatch.aiscripters.net/build.txt");
            StreamReader reader = new StreamReader(stream);
            String upbuild = reader.ReadToEnd();
            buildn.Text = upbuild;
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("http://userpatch.aiscripters.net/");
        }
    }
}

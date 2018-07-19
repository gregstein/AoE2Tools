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
using System.Globalization;
using System.IO;
using Microsoft.Win32;
using System.Collections;
using System.Runtime.InteropServices;
using NetFwTypeLib;
namespace WindowsFormsApplication3
{
    public partial class PreConv : KryptonForm
    {

        public PreConv()
        {
            InitializeComponent();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker1.RunWorkerAsync();
        }

        private void PreConv_Load(object sender, EventArgs e)
        {

            
        }

        private void kryptonComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //
            
            if (kryptonComboBox1.Text.Contains("="))
            {
                KryptonMessageBox.Show("Dad Gum! Clearly You didn't Choose a Hotkey Profile.. KappaPride", "Wrong Hotkeys Pick!");
            }
            else if (SteamBox.Image.ToString() == "check")
            {
                KryptonMessageBox.Show("Click That \"Fix it \" Button and Locate \"AoK HD.exe\" In Your Steam Games Folder \n OR Install AoE2 HD From Steam", "AoE2 HD Not Found On Steam!");
            }
            else {

                using (RegistryKey SetVoobly = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (SetVoobly != null)
                    {


                        //Object o32 = key32.GetValue("InstallPath");
                        SetVoobly.SetValue("Ren", "Save Replay");
                        SetVoobly.SetValue("Launcher", "1");
                        SetVoobly.SetValue("Flag", LangTxt.Text.ToLower());
                    }
                }
            //Check Voobly Settings
            if(VoobAuto.Checked == true)
            {
                using (RegistryKey SetVoobly = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (SetVoobly != null)
                    {


                        //Object o32 = key32.GetValue("InstallPath");
                        SetVoobly.SetValue("SetVoobly", "auto");
                    }
                }

            }

            else if (VoobManual.Checked == true)
            {
                using (RegistryKey SetVoobly = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (SetVoobly != null)
                    {


                        //Object o32 = key32.GetValue("InstallPath");
                        SetVoobly.SetValue("SetVoobly", "manual");
                    }
                }
            }
            //Check Game Settings
            if (GameAuto.Checked == true)
            {
                using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (SetGame != null)
                    {


                        //Object o32 = key32.GetValue("InstallPath");
                        SetGame.SetValue("SetGame", "auto");
                    }
                }
            }
            else if (GameCustom.Checked == true)
            {
                using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (SetGame != null)
                    {


                        //Object o32 = key32.GetValue("InstallPath");
                        SetGame.SetValue("SetGame", "manual");
                    }
                }
            }
            //Check Game Directory
            using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                if (SetGame != null)
                {


                    //Object o32 = key32.GetValue("InstallPath");
                    SetGame.SetValue("AoE2Path", GameDir.Text);
                }
            }
            //Check Hotkeys
            if (!kryptonComboBox1.Text.Contains("="))
            {
                using (RegistryKey SetHotkeys = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (SetHotkeys != null)
                    {

                        SetHotkeys.SetValue("SetHotkeys", kryptonComboBox1.Text);
                    }
                }
            }
            else
            {
                using (RegistryKey SetHotkeys = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (SetHotkeys != null)
                    {

                        SetHotkeys.SetValue("SetHotkeys", "Default (Recommended)");
                    }
                }
            }
            

            //Check Offline Mods
            if (smalltrees.Checked == true)
            {
                using (RegistryKey smalltree = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (smalltree != null)
                    {

                        smalltree.SetValue("Small Trees", "yes");
                    }
                }
            }
            else
            {
                using (RegistryKey smalltree = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (smalltree != null)
                    {

                        smalltree.SetValue("Small Trees", "no");
                    }
                }
            }

            //
            if (shortwalls.Checked == true)
            {
                using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (shortwall != null)
                    {

                        shortwall.SetValue("Short Walls", "yes");
                    }
                }
            }
            else 
            {
                using (RegistryKey shortwall = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (shortwall != null)
                    {

                        shortwall.SetValue("Short Walls", "no");
                    }
                }
            }

            //Bold Text
            if (boldtext.Checked == true)
            {
                using (RegistryKey boldtexts = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (boldtexts != null)
                    {

                        boldtexts.SetValue("Light Grid", "yes");
                    }
                }
            }
            else
            {
                using (RegistryKey boldtexts = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (boldtexts != null)
                    {

                        boldtexts.SetValue("Light Grid", "no");
                    }
                }
            }

            //Advanced Idle Pointer
            if (advidle.Checked == true)
            {
                using (RegistryKey advidles = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (advidles != null)
                    {

                        advidles.SetValue("Advanced Idle Pointer", "yes");
                    }
                }
            }
            else
            {
                using (RegistryKey advidles = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (advidles != null)
                    {

                        advidles.SetValue("Advanced Idle Pointer", "no");
                    }
                }
            }

            //Huge Number
            if (hugenumber.Checked == true)
            {
                using (RegistryKey hugenumbers = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (hugenumbers != null)
                    {

                        hugenumbers.SetValue("Huge Number", "yes");
                    }
                }
            }
            else
            {
                using (RegistryKey hugenumbers = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (hugenumbers != null)
                    {

                        hugenumbers.SetValue("Huge Number", "no");
                    }
                }
            }

            //Blue Berries
            if (blueberries.Checked == true)
            {
                using (RegistryKey blueberry = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (blueberry != null)
                    {

                        blueberry.SetValue("Blue Berries", "yes");
                    }
                }
            }
            else if (blueberries.Checked == false)
            {
                using (RegistryKey blueberry = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    if (blueberry != null)
                    {

                        blueberry.SetValue("Blue Berries", "no");
                    }
                }
            }
                //End Operation
            this.Hide();
            var form2 = new Conv();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Retrieve Default Lang
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Microsoft Games\Age of Empires II HD", true))
            {
                if (key != null)
                {
                    string osy = key.GetValue("Language").ToString();
                    LangTxt.Text = osy.ToUpper();
                    using (RegistryKey blueberry = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {
                        if (blueberry != null)
                        {

                            blueberry.SetValue("Flag", osy);
                            
                        }
                    }
                }
            }

            

        }

        private void PreConv_Shown(object sender, EventArgs e)
        {
            
           
            //GetGameDir();
        }

        private void GameCustom_CheckedChanged(object sender, EventArgs e)
        {
if (GameCustom.Checked == true)
{
                using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                string Select_p = fbd.SelectedPath.ToString();
                var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (!Directory.Exists(fbd.SelectedPath)) { Directory.CreateDirectory(fbd.SelectedPath); }
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    if (files.Length == 0)
                    {
                        GameDir.Text = fbd.SelectedPath.ToString();
                    }
                    else if (files.Length > 0)
                    {
                        GameDir.Text = fbd.SelectedPath.ToString() + @"\age of empires ii";
                        //KryptonMessageBox.Show("Please Select an Empty Folder!", "Folder Not Empty!");
                    
                            //GetGameDir();
                        //backgroundWorker3.RunWorkerAsync();
                        //backgroundWorker1.RunWorkerAsync();
                        
                        //GameAuto.Checked = true;
                    }

                    else if (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            KryptonMessageBox.Show("If you choose this directory, You will need to run Age of empires 2 AS ADMINISTRATOR! \n You can still choose this directory no problem", "(Optional) Warning!");
                        }
                   
                    
                }

                
                    
            }
                //Alerting

    
}
        }

        public void GetGameDir()
        {

            //Retrieve Default Game Directory
            //string inString22 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            //string inString2 = inString22.Replace(" (x86)", "");
            //TextInfo cultInfo2 = new CultureInfo("en-US", false).TextInfo;
            //string output2 = cultInfo2.ToTitleCase(inString2);
            //GameDir.Text = output2 + @"\microsoft games\age of empires ii";
            GameDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft Games\Age of Empires ii";
            //
        }

        public void SteamAssets()
        {
            try
            {
                //steam

                using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Valve\Steam", true))
                using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Valve\Steam", true))
                {
                    if (key32 != null)
                    {

                        string version32 = key32.GetValue("InstallPath").ToString();
                        //Object o32 = key32.GetValue("InstallPath");

                        //Version version64 = new Version(o64 as String);


                        string Spath32 = version32 + @"\steamapps\common\Age2HD";
                        //storing the values  
                        if (Directory.Exists(Spath32))
                        {
                            RegistryKey keyAdd = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
                            keyAdd.SetValue("SteamPath", Spath32);
                            keyAdd.Close();
                            FixSteam.Enabled = false;
                            SteamBox.Image = Properties.Resources.check;
                            SteamLabel.StateNormal.ShortText.Color1 = Color.ForestGreen;
                            SteamLabel.Text = "Success!";
                            System.Threading.Thread.Sleep(1000);
                            SteamLabel.Text = "Ready!";

                        }


                        else
                        {
                            FixSteam.Enabled = true;
                            SteamBox.Image = Properties.Resources.uncheck;
                            SteamLabel.StateNormal.ShortText.Color1 = Color.Red;
                            SteamLabel.Text = "Failed!";
                            System.Threading.Thread.Sleep(1000);
                            SteamLabel.Text = "Not Found!";




                        }

                        //do what you like with this version

                        //else if (o32 != null)
                        //{
                        //    Version version32 = new Version(o32 as String);  
                        //    //do what you like with version
                        //}
                    }
                    else if (key64 != null)
                    {
                        //MessageBox.Show("Steam reg not empty!!");
                        string version64 = key64.GetValue("InstallPath").ToString();
                        string Spath64 = version64 + @"\steamapps\common\Age2HD";

                        //storing the values  
                        if (Directory.Exists(Spath64))
                        {
                            
                            RegistryKey keyAdd = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
                            keyAdd.SetValue("SteamPath", Spath64);
                            keyAdd.Close();
                            FixSteam.Enabled = false;
                            SteamBox.Image = Properties.Resources.check;
                            SteamLabel.StateNormal.ShortText.Color1 = Color.ForestGreen;
                            SteamLabel.Text = "Success!";
                            System.Threading.Thread.Sleep(1000);
                            SteamLabel.Text = "Ready!";
                        }

                        else
                        {
                            FixSteam.Enabled = true;
                            SteamBox.Image = Properties.Resources.uncheck;
                            SteamLabel.StateNormal.ShortText.Color1 = Color.Red;
                            SteamLabel.Text = "Failed!";
                            System.Threading.Thread.Sleep(1000);
                            SteamLabel.Text = "Not Found!";

                        }

                        //do what you like with version

                        //else if (o32 != null)
                        //{
                        //    Version version32 = new Version(o32 as String);  
                        //    //do what you like with version
                        //}
                    }
                    else
                    {
                        KryptonMessageBox.Show("Please Open Steam And Verify The Integrity of Age of Empires II HD", "Advice!");
                    }
                }

                //

             //using (RegistryKey keycheck = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
             //   {
             //       if (keycheck != null)
             //   {
             //       string Pathcheck = keycheck.GetValue("SteamPath").ToString();
             //       if (File.Exists(Pathcheck + @"\AoK HD.exe") && Directory.Exists(Pathcheck + @"\resources\_common"))
             //           {
             //               BeginInvoke((MethodInvoker)delegate
             //               {
             //                   FixSteam.Enabled = false;
             //               });
                            
             //               SteamBox.Image = Properties.Resources.check;
             //               SteamLabel.StateNormal.ShortText.Color1 = Color.ForestGreen;
             //               SteamLabel.Text = "Success!";
             //               System.Threading.Thread.Sleep(1000);
             //               SteamLabel.Text = "Ready!";
                        
             //       }
             //       else
             //       {
             //           FixSteam.Enabled = true;
             //           //Double Check
             //           //using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Valve\Steam", true))
             //           //using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Valve\Steam", true))
             //           //{
             //           //    if (key32 != null)
             //           //    {

             //           //        string version32 = key32.GetValue("InstallPath").ToString();
             //           //        //Object o32 = key32.GetValue("InstallPath");

             //           //        //Version version64 = new Version(o64 as String);


             //           //        string Spath32 = version32 + @"\steamapps\common\Age2HD";
             //           //        //storing the values  
             //           //        if (Directory.Exists(Spath32))
             //           //        {
             //           //            RegistryKey keyAdd = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
             //           //            keyAdd.SetValue("SteamPath", Spath32);
             //           //            keyAdd.Close();
             //           //            FixSteam.Enabled = false;
             //           //            SteamBox.Image = Properties.Resources.check;
             //           //            SteamLabel.StateNormal.ShortText.Color1 = Color.ForestGreen;
             //           //            SteamLabel.Text = "Success!";
             //           //            System.Threading.Thread.Sleep(1000);
             //           //            SteamLabel.Text = "Ready!";
                                    
             //           //        }


             //           //        else
             //           //        {
             //           //            FixSteam.Enabled = true;
             //           //            SteamBox.Image = Properties.Resources.uncheck;
             //           //            SteamLabel.StateNormal.ShortText.Color1 = Color.Red;
             //           //            SteamLabel.Text = "Failed!";
             //           //            System.Threading.Thread.Sleep(1000);
             //           //            SteamLabel.Text = "Not Found!";
                                    
                                    
                                    

             //           //        }

             //           //        //do what you like with this version

             //           //        //else if (o32 != null)
             //           //        //{
             //           //        //    Version version32 = new Version(o32 as String);  
             //           //        //    //do what you like with version
             //           //        //}
             //           //    }
             //           //    else if (key64 != null)
             //           //    {

             //           //        string version64 = key64.GetValue("InstallPath").ToString();
             //           //        string Spath64 = version64 + @"\steamapps\common\Age2HD";

             //           //        //storing the values  
             //           //        if (Directory.Exists(Spath64))
             //           //        {
             //           //            RegistryKey keyAdd = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
             //           //            keyAdd.SetValue("SteamPath", Spath64);
             //           //            keyAdd.Close();
             //           //            FixSteam.Enabled = false;
             //           //            SteamBox.Image = Properties.Resources.check;
             //           //            SteamLabel.StateNormal.ShortText.Color1 = Color.ForestGreen;
             //           //            SteamLabel.Text = "Success!";
             //           //            System.Threading.Thread.Sleep(1000);
             //           //            SteamLabel.Text = "Ready!";
             //           //        }

             //           //        else
             //           //        {
             //           //            FixSteam.Enabled = true;
             //           //            SteamBox.Image = Properties.Resources.uncheck;
             //           //            SteamLabel.StateNormal.ShortText.Color1 = Color.Red;
             //           //            SteamLabel.Text = "Failed!";
             //           //            System.Threading.Thread.Sleep(1000);
             //           //            SteamLabel.Text = "Not Found!";

             //           //        }

             //           //        //do what you like with version

             //           //        //else if (o32 != null)
             //           //        //{
             //           //        //    Version version32 = new Version(o32 as String);  
             //           //        //    //do what you like with version
             //           //        //}
             //           //    }
             //           //    else
             //           //    {
             //           //        KryptonMessageBox.Show("Please Open Steam And Verify The Integrity of Age of Empires II HD", "Advice!");
             //           //    }
             //           //}
             //       }
             //   }
             //                   }
            }
            catch (Exception ex)
            //catch (Exception ex)
            //{
            //    KryptonMessageBox.Show("Error With Assets" + ex, "Alert!");
            //}
            {
                KryptonMessageBox.Show("Error With Assets" + ex, "Alert!");
                
           
            }

                
            //catch (Exception ex)
            //{
            //    KryptonMessageBox.Show("Error With Assets" + ex, "Alert!");
            //}

        }

        private void FixSteam_Click(object sender, EventArgs e)
        {
            KryptonMessageBox.Show("We Didn't Find Age of Empires 2 HD!\n If It is Installed SomeWhere Else. You Need To Locate \"AoK HD.exe\" In Your Custom Steam Games Folder", "Important!");
            //OPEN DIALOG
            this.openFileDialog1.FileName = "AoK HD.exe";
            this.openFileDialog1.Filter = "AoK HD.exe|AoK HD.exe";

            //Begin
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                RegistryKey keyAddAlt = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
                string SpathAlt = openFileDialog1.FileName;
                keyAddAlt.SetValue("SteamPath", Path.GetDirectoryName(SpathAlt));
                keyAddAlt.Close();
                SteamAssets();
            }
            else
            {
                
            }
        }

        public void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            SteamAssets();
            
            BeginInvoke((MethodInvoker)delegate
            {
                GetGameDir();
                kryptonButton1.Enabled = true;
            });
            
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            GetGameDir();
        }

        private void GameAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (GameAuto.Checked == true)
            {
                GetGameDir();

            }
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PreConv_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (CloseCancel() == false)
            //{
            //    e.Cancel = true;
            //};
        }
        //public static bool CloseCancel()
        //{
        //    const string message = "Are you sure you would like to cancel The Preconversion?";
        //    const string caption = "Cancel Preconversion";
        //    var result = KryptonMessageBox.Show(message, caption,
        //                                 MessageBoxButtons.YesNo,
        //                                 MessageBoxIcon.Question);

        //    if (result == DialogResult.Yes)
        //        return true;
        //    else
        //        return false;
        //}
    }
}

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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.Zip.Compression;
using System.Resources;
using System.Globalization;

namespace WindowsFormsApplication3
{
    public partial class RecPrompt : KryptonForm
    {
        public string MyProperty { get; set; }
        public string GameVersion { get; set; }
        public string Grabext { get; set; }
        public string RecCount { get; set; }
        public string SingleDir { get; set; }
        public string FileName { get; set; }
        
        private static Random random = new Random();
        public RecPrompt()
        {
            InitializeComponent();
            //this.TopMost = true;
        }
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private async void RecPrompt_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
            await Task.Run(() => aoepath());
            await Task.Run(() => CHeckOfflineWK());

            rencombcheck();
            await Task.Run(() => Thread.Sleep(1000));
           
            if(Player2.Text == "Loading...")
            {
                rencombcheck();
            }
            
        }

        void CHeckOfflineWK()
        {
            if(!Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms") || !File.Exists(mskdpath.Text + @"\age2_x1\WK.exe"))
            {
                KryptonMessageBox.Show(res_man.GetString("_mustintallwk", cul), "S.O.S");
                //Restart AoE2Tools to auto generate offline wk installation
            }
        }
        public void switchlang()
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
                    else if (translatestr == "zh-cn")
                    {
                        cul = CultureInfo.CreateSpecificCulture("zh-cn");
                    }

                }
                else
                {
                    cul = CultureInfo.CreateSpecificCulture("en");
                }
            }
            BeginInvoke((MethodInvoker)delegate
            {


                kryptonLabel1.Text = res_man.GetString("_recentversion", cul);
                label7.Text = res_man.GetString("_recentreplayteam1", cul);
                label8.Text = res_man.GetString("_recentreplayteam2", cul);
                kryptonLabel3.Text = res_man.GetString("_recentrename", cul) + "?";
                kryptonButton1.Text = res_man.GetString("_recentdelete", cul);
                kryptonButton2.Text = res_man.GetString("_recentclose", cul);
                kryptonGroupBox1.Text = res_man.GetString("_recgb", cul);
                watchrec.Text = res_man.GetString("_recentwatch", cul) + " && " + res_man.GetString("_recentrename", cul);


            });
        }
        private void watchrec_Click(object sender, EventArgs e)
        {
            try
            {

            
            //Process[] ageproc1 = Process.GetProcessesByName("AoE2Tools");
            if(gamever.Text == "WK 5.7.2")
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.2\empires2_x1_p1.dat") && File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                {
                    
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.2\empires2_x1_p1.dat", mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat", true);
                }
                else
                {
                    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.2\empires2_x1_p1.dat"))
                        KryptonMessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.2\empires2_x1_p1.dat" + "is not found!", "Error");
                    if (!File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                        KryptonMessageBox.Show(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat" + " is not found!", "Error");
                }
                    string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
                    foreach (string file in getfln)
                    {

                        if (recfield.Text == oldfilen.Text && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        {
                            //Custom WK Mod No Copy Rec
                            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                            {
                                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                                {
                                    string aoe2path = key.GetValue("AoE2Path").ToString();


                                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) == null)
                                    {
                                        
                                        
                                    }
                                    else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                                    {
                                        string wkmod = key.GetValue("WKMOD").ToString();
                                        //Game Check
                                        if (wkmod == "false")
                                        {
                                            File.Copy(this.MyProperty + @"\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                                        }
                                    }
                                }
                            }
                            
                            File.Copy(this.MyProperty + @"\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                            WatchRepm();
                        }
                            //if rec is renamed
                        else if (recfield.Text != oldfilen.Text && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                        {
                            if (!File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                            {
                                if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + ".mgz")){ File.Delete(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"); }
                                //Custom WK Mod No Copy Rec
                                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                                {
                                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                                    {
                                        string aoe2path = key.GetValue("AoE2Path").ToString();


                                        if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) == null)
                                        {

                                           
                                        }
                                        else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                                        {
                                            string wkmod = key.GetValue("WKMOD").ToString();
                                            //Game Check
                                            if (wkmod == "false")
                                            {
                                                File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                                            }
                                        }
                                    }
                                }
                                
                            }
                            if (!File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                            {
                                try
                                {
                                    File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                                }
                                catch(System.IO.DirectoryNotFoundException)
                                {

                                }
                                
                            }
                            if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                            {
                                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                                {
                                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                                    {
                                        string aoe2path = key.GetValue("AoE2Path").ToString();


                                        if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) == null)
                                        {

                                         
                                        }
                                        else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                                        {
                                            string wkmod = key.GetValue("WKMOD").ToString();
                                            //Game Check
                                            if (wkmod == "false")
                                            {
                                                File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                                            }
                                        }
                                    }
                                }
                                    
                            }
                           
                            if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                            {
                                File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                            }
                            
                            WatchRepm();
                        }
                        else if (recfield.Text != oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz") && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                        {
                            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                            {
                                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                                {
                                    string aoe2path = key.GetValue("AoE2Path").ToString();


                                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) == null)
                                    {

                                        
                                    }
                                    else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                                    {
                                        string wkmod = key.GetValue("WKMOD").ToString();
                                        //Game Check
                                        if (wkmod == "false")
                                        {
                                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                                        }
                                    }
                                }
                            }
                            
                                 WatchRepm();
                        }
                        else if (recfield.Text != oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz") && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                        {


                            WatchRepm();
                        }
                            //if rec not renamed
                        //else if (recfield.Text == oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz") && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        else if (recfield.Text == oldfilen.Text && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        {

                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                            WatchRepm();
                        }
                        //else if (recfield.Text == oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz") && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        else if (recfield.Text == oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        {


                            WatchRepm();
                        }

                }
                        
                
            }
            else if (gamever.Text == "WK 5.7.4")
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.4\empires2_x1_p1.dat") && File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                {
                    
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.4\empires2_x1_p1.dat", mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat", true);
                }
                else
                {
                    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.4\empires2_x1_p1.dat"))
                        KryptonMessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.4\empires2_x1_p1.dat" + "is not found!", "Error");
                    if (!File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                        KryptonMessageBox.Show(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat" + "is not found!", "Error");
                }

                string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
                foreach (string file in getfln)
                {

                    if (recfield.Text == oldfilen.Text && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                    {
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                        {
                            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                            {
                                string aoe2path = key.GetValue("AoE2Path").ToString();


                                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) == null)
                                {

                                   
                                }
                                else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                                {
                                    string wkmod = key.GetValue("WKMOD").ToString();
                                    //Game Check
                                    if (wkmod == "false")
                                    {
                                        File.Copy(this.MyProperty + @"\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                                    }
                                }
                            }
                        }
                        
                        
                        WatchRepm();
                    }
                    //if rec is renamed
                    else if (recfield.Text != oldfilen.Text && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                    {
                        if (!File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        {
                            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                            {
                                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                                {
                                    string aoe2path = key.GetValue("AoE2Path").ToString();


                                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) == null)
                                    {

                                       
                                    }
                                    else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                                    {
                                        string wkmod = key.GetValue("WKMOD").ToString();
                                        //Game Check
                                        if (wkmod == "false")
                                        {
                                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                                        }
                                    }
                                }
                            }
                            
                        }
                        if (!File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        {
                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                        }
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                            File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                            File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                        WatchRepm();
                    }
                    else if (recfield.Text != oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz") && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                    {

                        File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                        WatchRepm();
                    }
                    else if (recfield.Text != oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz") && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                    {


                        WatchRepm();
                    }
                    //if rec not renamed
                    else if (recfield.Text == oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz") && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                    {

                        File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                        WatchRepm();
                    }
                    else if (recfield.Text == oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz") && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                    {


                        WatchRepm();
                    }

                }


            }
            else if (gamever.Text == "WK 5.8.1")
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.8.1\empires2_x1_p1.dat") && File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                {

                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.8.1\empires2_x1_p1.dat", mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat", true);
                }
                else
                {
                    if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.8.1\empires2_x1_p1.dat"))
                        KryptonMessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.8.1\empires2_x1_p1.dat" + "is not found!", "Error");
                    if (!File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                        KryptonMessageBox.Show(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat" + "is not found!", "Error");
                }

                string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
                foreach (string file in getfln)
                {

                    if (recfield.Text == oldfilen.Text && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                    {
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                        {
                            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                            {
                                string aoe2path = key.GetValue("AoE2Path").ToString();


                                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) == null)
                                {


                                }
                                else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                                {
                                    string wkmod = key.GetValue("WKMOD").ToString();
                                    //Game Check
                                    if (wkmod == "false")
                                    {
                                        File.Copy(this.MyProperty + @"\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                                    }
                                }
                            }
                        }


                        WatchRepm();
                    }
                    //if rec is renamed
                    else if (recfield.Text != oldfilen.Text && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                    {
                        if (!File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        {
                            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                            {
                                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                                {
                                    string aoe2path = key.GetValue("AoE2Path").ToString();


                                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) == null)
                                    {


                                    }
                                    else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                                    {
                                        string wkmod = key.GetValue("WKMOD").ToString();
                                        //Game Check
                                        if (wkmod == "false")
                                        {
                                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                                        }
                                    }
                                }
                            }

                        }
                        if (!File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                        {
                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                        }
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                            File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                            File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                        WatchRepm();
                    }
                    else if (recfield.Text != oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz") && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                    {

                        File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                        WatchRepm();
                    }
                    else if (recfield.Text != oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz") && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                    {


                        WatchRepm();
                    }
                    //if rec not renamed
                    else if (recfield.Text == oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz") && !File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                    {

                        File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                        WatchRepm();
                    }
                    else if (recfield.Text == oldfilen.Text && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz") && File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                    {


                        WatchRepm();
                    }

                }


            }
            else if (gamever.Text != "WK 5.7.2" && gamever.Text != "WK 5.7.4" && gamever.Text != "WK 5.8.1")
            {
               
                    string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
                    foreach (string file in getfln)
                    {
                        //if rec not renamed
                        if (recfield.Text == oldfilen.Text && !File.Exists(mskdpath.Text + @"\Savegame\" + recfield.Text + ".mgz"))
                        {

                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Savegame\" + recfield.Text + ".mgz");
                            WatchRepm();
                        }
                        else if (recfield.Text == oldfilen.Text && File.Exists(mskdpath.Text + @"\Savegame\" + recfield.Text + ".mgz"))
                        {

                            WatchRepm();
                        }
                            //if rec renamed
                        else if (recfield.Text != oldfilen.Text && !File.Exists(mskdpath.Text + @"\Savegame\" + oldfilen.Text + ".mgz"))
                        {
                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Savegame\" + oldfilen.Text + ".mgz");
                            WatchRepm();

                    }
                        else if (recfield.Text != oldfilen.Text && File.Exists(mskdpath.Text + @"\Savegame\" + oldfilen.Text + ".mgz"))
                        {
                            WatchRepm();
                        }
                     
                }
             
            }
//END TRY
            }
//END WATCHING
            catch(UnauthorizedAccessException)
            {

                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    string combfp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AoE2ToolsDiag.exe");
                    startInfo.Arguments = "/c" + "start \"\" \"" + combfp + "\" /r";
                    //startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    process.Dispose();
                    
                }
                catch
                {
                    
                }


            }
            
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
                        mskdpath.Text = gpath;
                    }
                    else 
                    {
                        KryptonMessageBox.Show("Game Path Not Found!", "Error!");
                        this.Close();
                    }
                }
            }
        }
        public void rencombcheck()
        {
            
            using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Skey != null)
                {
                    
                    string renref = Skey.GetValue("Ren").ToString();
                    if (renref != null)
                    {
                        //BeginInvoke((MethodInvoker)delegate
                        //{
                            recchoice.Text = renref;

                        //});
                        
                    }
                    
                }
            }
            //BeginInvoke((MethodInvoker)delegate
            //{
                label1.Text = this.Grabext;
                gamever.Text = this.GameVersion;

            //});
           
            //trimit
            string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
            foreach (string file in getfln)
            {
             
                if (!File.Exists(mskdpath.Text + "\\SaveGame\\" + this.FileName))
                {

                    //await Task.Run(() => PlayerN(file));
                    //Detect version
                    
                    //analyze rec
                    PlayerN(file);
                    
                    //recfield.Text = Path.GetFileName(this.MyProperty + "\\" + this.FileName).Remove(Path.GetFileName(this.MyProperty + "\\" + this.FileName).Length - 4);
                    //oldfilen.Text = Path.GetFileName(this.MyProperty + "\\" + this.FileName).Remove(Path.GetFileName(this.MyProperty + "\\" + this.FileName).Length - 4);
                    //BeginInvoke((MethodInvoker)delegate
                    //{
                        label1.Text = Path.GetExtension(file);

                    //});
                    
                }
                else
                {
                    
                    long filelen = new System.IO.FileInfo(file).Length;
                    long recflen = new System.IO.FileInfo(mskdpath.Text + "\\SaveGame\\" + this.FileName).Length;

                    if (filelen != recflen)
                    {
                        //await Task.Run(() => PlayerN(file));
                        //Detect version
                        
                        PlayerN(file);
                        
                        //recfield.Text = Path.GetFileName(file).Remove(Path.GetFileName(file).Length - 4);
                        //BeginInvoke((MethodInvoker)delegate
                        //{
                            oldfilen.Text = Path.GetFileName(file).Remove(Path.GetFileName(file).Length - 4);
                            label1.Text = Path.GetFileName(file).Substring(Math.Max(0, Path.GetFileName(file).Length - 4));

                        //});
                        
                    }
                    else if (filelen == recflen)
                    {
                        //await Task.Run(() => PlayerN(file));
                        //Detect version

                        PlayerN(file);
                       
                        //BeginInvoke((MethodInvoker)delegate
                        //{
                            recfield.Text = System.IO.Path.GetFileNameWithoutExtension(this.FileName);
                            label1.Text = System.IO.Path.GetExtension(this.FileName);

                        //});
                        
                    }
                }

                

            }
            //recfield.SelectionStart = 0;
            //recfield.SelectionLength = recfield.Text.Length;
            //BeginInvoke((MethodInvoker)delegate
            //{
                this.TopMost = true;
                this.TopMost = false;
                recfield.SelectAll();

            //});

                
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Process[] ageproc1 = Process.GetProcessesByName("AoE2Tools");

            //if (ageproc1.Length == 0)
            //{
                //just delete


                DialogResult dialogResult = KryptonMessageBox.Show("Delete This Replay?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + this.Grabext;
                    string renfilerec_old = mskdpath.Text + "\\SaveGame\\" + oldfilen.Text + this.Grabext;
                    string renfilerecwk = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recfield.Text + this.Grabext;
                    string renfilerecwk_old = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfilen.Text + this.Grabext;
                    string renfilerecwk2 = mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + this.Grabext;
                    string renfilerecwk_old2 = mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + this.Grabext;
                    //if (File.Exists(renfilerec))
                    //{
                        try
                        {
                            if (File.Exists(renfilerec))
                            File.Delete(renfilerec);
                            if (File.Exists(renfilerec_old))
                            File.Delete(renfilerec_old);
                            if (File.Exists(renfilerecwk))
                            File.Delete(renfilerecwk);
                            if (File.Exists(renfilerecwk_old))
                            File.Delete(renfilerecwk_old);
                            if (File.Exists(renfilerecwk2))
                            File.Delete(renfilerecwk2);
                            if (File.Exists(renfilerecwk_old2))
                            File.Delete(renfilerecwk_old2);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future, Move Age of empires 2 to the recommended location", "Alert!");
                        }

                    //}
                    if (File.Exists(renfilerec_old))
                    {
                        try
                        {
                            File.Delete(renfilerec);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future.Move Age of empires 2 to the recommended location!", "Alert!");
                        }

                    }
                    //wk start del
                    if (File.Exists(renfilerecwk))
                    {
                        try
                        {
                            File.Delete(renfilerec);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future, Move Age of empires 2 to the recommended location", "Alert!");
                        }

                    }
                    if (File.Exists(renfilerecwk_old))
                    {
                        try
                        {
                            File.Delete(renfilerec);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future.Move Age of empires 2 to the recommended location!", "Alert!");
                        }

                    }
                    //wk end del
                    if (Directory.Exists(this.MyProperty))
                    {
                        try
                        {
                            Directory.Delete(this.MyProperty, true);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future.Move Age of empires 2 to the recommended location!", "Alert!");
                        }
                    }

                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {

                }


                //delete
            //}//here
            //else
            //{
            //    MessageBox.Show("running");
            //                DialogResult dialogResult2 = KryptonMessageBox.Show("Age of empires 2 is already running!!\n\nWould you like to close it and delete this replay?", "Confirmation", MessageBoxButtons.YesNo);
            //                if (dialogResult2 == DialogResult.Yes)
            //                { 
            //                    //kill proc first
            //                    foreach (var process in Process.GetProcessesByName("AoE2Tools"))
            //                    {
            //                        process.Kill();
            //                        process.WaitForExit();
            //                    }

            //                // now delete
            //                    DialogResult dialogResult = KryptonMessageBox.Show("Delete This Replay?", "Confirmation", MessageBoxButtons.YesNo);
            //                    if (dialogResult == DialogResult.Yes)
            //                    {
            //                        string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + this.Grabext;
            //                        string renfilerec_old = mskdpath.Text + "\\SaveGame\\" + oldfilen.Text + this.Grabext;
            //                        if (File.Exists(renfilerec))
            //                        {
            //                            try
            //                            {
            //                                File.Delete(renfilerec);
            //                                this.Close();
            //                            }
            //                            catch (SystemException)
            //                            {
            //                                KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future. \n Or Move Age of empires 2 to the recommended location", "Alert!");
            //                            }

            //                        }
            //                        if (File.Exists(renfilerec_old))
            //                        {
            //                            try
            //                            {
            //                                File.Delete(renfilerec);
            //                                this.Close();
            //                            }
            //                            catch (SystemException)
            //                            {
            //                                KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future.", "Alert!");
            //                            }

            //                        }
            //                        if (Directory.Exists(this.MyProperty))
            //                        {
            //                            try
            //                            {
            //                                Directory.Delete(this.MyProperty, true);
            //                                this.Close();
            //                            }
            //                            catch (SystemException)
            //                            {
            //                                KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future.", "Alert!");
            //                            }
            //                        }

            //                        this.Close();
            //                    }
            //                    else if (dialogResult == DialogResult.No)
            //                    {

            //                    }

            //                    //end delete
            //                }
            //                else
            //                {

            //                }

            //}
            


         
        }

        private void recfield_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allowed keypresses within the replay field
            //if (Char.IsLetterOrDigit(e.KeyChar)) return;
            //if (Char.IsControl(e.KeyChar)) return;
            //if (Char.IsWhiteSpace(e.KeyChar)) return;
            //if (e.KeyChar == '-') return;
            //if (e.KeyChar == '_') return;
            //if (e.KeyChar == '.') return;
            //if (e.KeyChar == '+') return;
            //if (e.KeyChar == ')') return;
            //if (e.KeyChar == '(') return;
            //if (e.KeyChar == '#') return;
            //if (e.KeyChar == ']') return;
            //if (e.KeyChar == '[') return;
            //if (e.KeyChar == '@') return;
            //if (e.KeyChar == '&') return;
            //if (e.KeyChar == 'é') return;
            //if (e.KeyChar == 'è') return;
            //if (e.KeyChar == 'ç') return;
            //if (e.KeyChar == 'à') return;
            //if (e.KeyChar == 'á') return;
            //if (e.KeyChar == 'í') return;
            //if (e.KeyChar == 'ó') return;
            //if (e.KeyChar == 'ú') return;
            //if (e.KeyChar == 'ü') return;
            //if (e.KeyChar == 'ñ') return;
            //e.Handled = true;
            
            
        }

        private void recfield_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void RecPrompt_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(recchoice.Text == "Don't Save!")
            {
                string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + this.Grabext;
                if (File.Exists(renfilerec))
                {
                    try
                    {
                        File.Delete(renfilerec);
                        this.Close();
                    }
                    catch (SystemException)
                    {
                        KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future.", "Alert!");
                    }

                }
                if (Directory.Exists(this.MyProperty))
                {
                    try
                    {
                        Directory.Delete(this.MyProperty, true);
                        this.Close();
                    }
                    catch (SystemException)
                    {
                        KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future.", "Alert!");
                    }
                }
            }
        }
        //public void detectver()
        //{
           
  
            


        //}
        public void WatchRepm()
        {
            
          
        
            //string getrecex = this.MyProperty.Substring(Math.Max(0, this.MyProperty.Length - 4));
            string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
            foreach (string file in getfln)
            {
                //this rec full path
                string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + label1.Text;
                string renfilerecwk = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recfield.Text + label1.Text;
                //KryptonMessageBox.Show("start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"");



                //launch game ver
                if (gamever.Text == "1.5 RC")
                {
                    if (!File.Exists(renfilerec))
                    {

                        File.Copy(file, renfilerec);


                    }
                    try
                    {
                        //MessageBox.Show("running 1.5", "");
                        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.5.exe");
                        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c" + "start " + "\"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\" " + "\"" + renfilerec + "\"";
                        //startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                        process.Dispose();
                    }
                    catch (Exception goy)
                    {
                        throw goy;

                    }
                }
                else if (gamever.Text == "1.4 RC")
                {
                    if (!File.Exists(renfilerec))
                    {

                        File.Copy(file, renfilerec);


                    }
                    try
                    {
                        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.4.exe");
                        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                        //startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                        process.Dispose();
                    }
                    catch (Exception goy)
                    {
                        throw goy;

                    }
                }

                else if (gamever.Text == "1.0 C")
                {
                    if (!File.Exists(renfilerec))
                    {

                        File.Copy(file, renfilerec);


                    }
                    try
                    {
                        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.0c.exe");
                        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                        //startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                        process.Dispose();
                    }
                    catch (Exception goy)
                    {
                        throw goy;

                    }
                }

                //else if (gamever.Text == "1.0")
                //{
                //    try
                //    {
                //        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.0.exe");
                //        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                //        System.Diagnostics.Process process = new System.Diagnostics.Process();
                //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //        startInfo.FileName = "cmd.exe";
                //        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                //        //startInfo.Verb = "runas";
                //        process.StartInfo = startInfo;
                //        process.Start();
                //        process.WaitForExit();

                //    }
                //    catch (Exception goy)
                //    {
                //        throw goy;

                //    }
                //}
                else if (gamever.Text == "WK 5.7.2" || gamever.Text == "WK 5.7.4" || gamever.Text == "WK 5.8.1")
                {
                    //copy first
                    if (!File.Exists(renfilerecwk))
                    {
                        try
                        {
                            File.Copy(file, renfilerecwk);
                        }
                        catch (System.IO.DirectoryNotFoundException)
                        {
                            KryptonMessageBox.Show("Wololokingdoms Directory Not Found!","Error!");
                        }
                        
                    }
                    //end copy
                    if (File.Exists(mskdpath.Text + "\\Age2_x1\\WK.exe"))
                    {
                        try
                        {
                            //MessageBox.Show("running wk", "");
                            byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WK.exe");
                            File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerecwk + "\"";
                            //startInfo.Verb = "runas";
                            process.StartInfo = startInfo;
                            process.Start();
                            process.WaitForExit();
                            process.Dispose();

                        }
                        //catch (Exception goy)
                        //{
                        //    throw goy;

                        //}
                        catch (SystemException)
                        {
                            KryptonMessageBox.Show("Wololokingdoms Directory Not Found! Replay wasnot copied.", "Error!");
                        }
                    }
  
                    else if (!File.Exists(mskdpath.Text + "\\Age2_x1\\WK.exe"))
                    {
                        if (KryptonMessageBox.Show(
"WololoKingdom is Not Installed! \n Would you like to install WK now?", "WK is Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk
) == DialogResult.Yes)
                        {
                            WololoInstaller howwk = new WololoInstaller();
                            howwk.ShowDialog();
                        }
                    }

                }
                //end
            }

           //END WATCH  
        }
        static public List<int> SearchBytePattern(byte[] pattern, byte[] bytes)
        {
            List<int> positions = new List<int>();
            int patternLength = pattern.Length;
            int totalLength = bytes.Length;
            byte firstMatchByte = pattern[0];
            for (int i = 0; i < totalLength; i++)
            {
                if (firstMatchByte == bytes[i] && totalLength - i >= patternLength)
                {
                    byte[] match = new byte[patternLength];
                    Array.Copy(bytes, i, match, 0, patternLength);
                    if (match.SequenceEqual<byte>(pattern))
                    {
                        positions.Add(i);
                        i += patternLength - 1;
                    }
                }
            }
            return positions;
        }
        public static string rndstr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async void PlayerN(string RecName)
        {
            try
            {
           

                //extracting replay header
                FileStream fs = new FileStream(RecName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] buffer;

                int headerLength = br.ReadInt32();
                int nextPosistion = br.ReadInt32();



                int compressLen = headerLength - 8;
                buffer = new Byte[compressLen];
                buffer = br.ReadBytes(compressLen);

                MemoryStream ms = new MemoryStream();
                ms.Write(buffer, 0, buffer.Length);
                byte[] HeaderByt = await Task.Run(() => inflate1(ms));
                
                byte[] pattern = { 0x00, 0x16, 0xF0 };
                //byte[] pattern2 = { 0x00, 0x0B, 0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x0B };
                byte[] toBeSearched = HeaderByt;
                string afx = await Task.Run(() => rndstr(8));
                File.WriteAllBytes(System.IO.Path.GetTempPath() + @"\rep-" + afx, toBeSearched);
                List<int> positions = await Task.Run(() => SearchBytePattern(pattern, toBeSearched));
                //List<int> positions2 = await Task.Run(() => SearchBytePattern(pattern2, toBeSearched));
                int skipper = 0;

                foreach (var item in positions)
                {
                    skipper++;
                    if (skipper == 1) continue;

                    var playername = new MemoryStream(toBeSearched, item - 21, item);



                    using (BinaryReader b = new BinaryReader(File.Open(System.IO.Path.GetTempPath() + @"\rep-" + afx,
                                                          FileMode.Open)))
                    {

                        // Variables for our position.
                        int pos = item - 21;
                        int required = 21;


                        // Seek required position.
                        b.BaseStream.Seek(pos, SeekOrigin.Begin);


                        // Read the next bytes.
                        byte[] by = b.ReadBytes(required);
                        string XplayerN = System.Text.Encoding.UTF8.GetString(by);

                        StringBuilder sb = new StringBuilder();

                        foreach (char c in XplayerN)
                        {

                            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == '[' || c == ']')
                            {
                                sb.Append(c);
                            }
                        }
                        //foreach (var item2 in positions2)
                        //{
                          

                        //}
                        //1v1 or 2v2
                        if (positions.Count() == 3)
                        {
                            if (skipper == 2)
                            {
                                Player1.Text = sb.ToString();
                                recfield.Text = sb.ToString() + " Vs ";
                                RecPrompt.ActiveForm.Text = Player1.Text + " Vs ";
                            }
                            else if (skipper == 3)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += sb.ToString();
                                RecPrompt.ActiveForm.Text += Player2.Text;
                                //check file existence
                                FileInfo woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                                //await Task.Run(() => FileIndexChk(woop));
                                FileIndexChk(woop);
                                if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\"))
                                {
                                FileInfo woop2 = new FileInfo(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                                //await Task.Run(() => FileIndexChk(woop2));
                                FileIndexChk(woop2);
                                }
                                    
                            }

                        }
                        else if (positions.Count() == 5)
                        {
                            if (skipper == 2)
                            {
                                Player1.Text = sb.ToString();
                                recfield.Text = sb.ToString() + " - ";
                                RecPrompt.ActiveForm.Text = sb.ToString() + " - ";
                            }
                            else if (skipper == 3)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += sb.ToString() + " - ";
                                RecPrompt.ActiveForm.Text += sb.ToString() + " - ";
                            }
                                
                            else if (skipper == 4)
                            {
                                Player3.Text = sb.ToString();
                                recfield.Text += sb.ToString() + " VS ";
                                RecPrompt.ActiveForm.Text += sb.ToString() + " VS ";
                            }
                                
                            else if (skipper == 5)
                            {
                                Player4.Text = sb.ToString();
                                recfield.Text += Player4.Text;
                                RecPrompt.ActiveForm.Text += sb.ToString();
                                //check file existence
                                FileInfo woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                                //await Task.Run(() => FileIndexChk(woop));
                                FileIndexChk(woop);
                                
                                if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\"))
                                {
                                    FileInfo woop2 = new FileInfo(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                                    //await Task.Run(() => FileIndexChk(woop2));
                                    FileIndexChk(woop2);
                                   
                                }
                            }
                                
                            //else if (skipper == 6)
                            //    Player6.Text = sb.ToString();
                            //else if (skipper == 7)
                            //    Player8.Text = sb.ToString();
                            //else if (skipper == 8)
                            //    Player5.Text = sb.ToString();
                            //else if (skipper == 9)
                            //    Player7.Text = sb.ToString();
                        }
                        else if (positions.Count() > 5)
                        {
                            if (skipper == 2)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += sb.ToString() + " - ";
                            }
                                
                            else if (skipper == 3)
                            {
                                Player1.Text = sb.ToString();
                                recfield.Text = sb.ToString() + " - ";
                                
                            }
                                
                            else if (skipper == 4)
                            {
                                Player4.Text = sb.ToString();
                                recfield.Text += sb.ToString() + " Vs ";
                            }
                                
                            else if (skipper == 5)
                            {
                               Player3.Text = sb.ToString();
                               recfield.Text += sb.ToString() + " - ";
                            }
                                
                            else if (skipper == 6)
                            {
                                   Player6.Text = sb.ToString();
                                   recfield.Text += sb.ToString() + " - ";
                            }
                                
                                
                            else if (skipper == 8)
                            {
                                    Player5.Text = sb.ToString();
                                    recfield.Text += sb.ToString() + " - ";
                            }
                                
                            else if (skipper == 9)
                            {
                                   Player7.Text = sb.ToString();
                                   recfield.Text += sb.ToString() + " - ";
                            }
                            else if (skipper == 7)
                            {
                                Player8.Text = sb.ToString();
                                recfield.Text += sb.ToString();
                                //check file existence
                                FileInfo _woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                                //await Task.Run(() => FileIndexChk(_woop));
                                FileIndexChk(_woop);
                                if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\"))
                                {
                                    FileInfo _woop2 = new FileInfo(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                                    //await Task.Run(() => FileIndexChk(_woop2));
                                    FileIndexChk(_woop2);
                                }
                            }
                            ////check file existence
                            //FileInfo woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                            //FileIndexChk(woop);
                            //if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\"))
                            //{
                            //    FileInfo woop2 = new FileInfo(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                            //    FileIndexChk(woop2);
                            //}
                        }

                    }
                }
                //Check Empty players
                if (Player3.Text == "Loading...")
                    Player3.Text = "-";
                if (Player4.Text == "Loading...")
                    Player4.Text = "-";
                if (Player5.Text == "Loading...")
                    Player5.Text = "-";
                if (Player6.Text == "Loading...")
                    Player6.Text = "-";
                if (Player7.Text == "Loading...")
                    Player7.Text = "-";
                if (Player8.Text == "Loading...")
                    Player8.Text = "-";
             

                ms.Close();
                ms.Dispose();
                afxit.Text = System.IO.Path.GetTempPath() + @"\rep-" + afx;
                //if (File.Exists(System.IO.Path.GetTempPath() + @"\rep-" + afx))
                //    File.Delete(System.IO.Path.GetTempPath() + @"\rep-" + afx);
            }
            catch (UnauthorizedAccessException)
            {


                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    string combfp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AoE2ToolsDiag.exe");
                    startInfo.Arguments = "/c" + "start \"\" \"" + combfp + "\" /r";
                    //startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    process.Dispose();

                }
                catch
                {

                }


            }
            catch (SystemException)
            {

            }
        }
        public void FileIndexChk(FileInfo file)
        {
            var filename = file.Name.Replace(file.Extension, string.Empty);
            var dir = file.Directory.FullName;
            var ext = file.Extension;

            if (file.Exists)
            {
                int count = 0;
                string added;

                do
                {
                    count++;
                    added = "Game (" + count + ")";
                } while (File.Exists(dir + "\\" + filename + " " + added + ext));

                recfield.Text = filename += " " + added;
                //recfield.Text = filename + ext;
            }

            
        }
       
        private byte[] inflate1(MemoryStream ms)
        {
            try
            {

                ms.Seek(0, SeekOrigin.Begin);
                Inflater inflater = new Inflater(true);
                InflaterInputStream inStream = new InflaterInputStream(ms, inflater);
                byte[] buf = new byte[5000000];
                int buf_pos = 0;
                int count = buf.Length;

                while (true)
                {
                    int numRead = inStream.Read(buf, buf_pos, count);
                    if (numRead <= 0)
                    {
                        break;
                    }
                    buf_pos += numRead;
                    count -= numRead;
                }

                return buf;
            }
            catch (Exception ju)
            {
                throw ju;
            }
        }
        private void recchoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)recchoice.SelectedItem == "Don't Save")
            {
                recfield.Enabled = false;
            }
            else if ((string)recchoice.SelectedItem == "Save Replay")
            {
                recfield.Enabled = true;
            }
        }

        private void RecPrompt_Leave(object sender, EventArgs e)
        {
            if (File.Exists(afxit.Text))
                File.Delete(afxit.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

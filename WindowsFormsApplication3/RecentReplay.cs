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
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.Resources;
using System.Globalization;

namespace WindowsFormsApplication3
{
    public partial class RecentReplay : KryptonForm
    {
 
        public RecentReplay()
        {
            InitializeComponent();
            
            //this.TopMost = true;
        }
        private static Random random = new Random();
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private async void RecentReplay_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
           
            //aoepath();
            RecentR();
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

                RecentReplay.ActiveForm.Text = res_man.GetString("_recenttitlebar", cul);
                label7.Text = res_man.GetString("_recentreplayteam1", cul);
                label8.Text = res_man.GetString("_recentreplayteam2", cul);
                kryptonLabel1.Text = res_man.GetString("_recentreplayname", cul);
                kryptonLabel2.Text = res_man.GetString("_recentversion", cul);
                watchrec.Text = res_man.GetString("_recentwatch", cul);
                saverec.Text = res_man.GetString("_recentrename", cul);
                delrec.Text = res_man.GetString("_recentdelete", cul);
                closerec.Text = res_man.GetString("_recentclose", cul);
                kryptonGroupBox1.Text = res_man.GetString("_recentreplaymanage", cul);

            });
        }
        public async void RecentR()
        {
            
            await Task.Run(() => aoepath());
            try
            {
                this.TopMost = true;
                this.TopMost = false;

           
                    //has matching rec files 1.5
                    var directory = new DirectoryInfo(mskdpath.Text + @"\SaveGame");
                    int RCRecCount = directory.GetFiles("*.mgz").Where(x => !x.FullName.Contains("voobly-spec.mgz") && !x.FullName.Contains("rec.mgz"))
                 .Count();
                   

                

              
                    //has matching rec files WK
                    
                    var directory2 = new DirectoryInfo(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame");
                    int WKRecCount = directory2.GetFiles("*.mgz").Where(x => !x.FullName.Contains("voobly-spec.mgz") && !x.FullName.Contains("rec.mgz"))
                         .Count();

                   


               

               // Games\WololoKingdoms
                //if (!File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + myFile2.ToString()))
                //{
                //    File.Copy(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + myFile2.ToString(), mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + myFile2.ToString());
                //}



                //MessageBox.Show(mskdpath.Text + @"\Games\WololoKingdoms AK\SaveGame\" + myFile2.ToString(), "");
                    if (RCRecCount == 0 && WKRecCount != 0)
                {
                    var myFile2 = directory2.GetFiles("*.mgz").Where(x => !x.FullName.Contains("voobly-spec.mgz") && !x.FullName.Contains("rec.mgz"))
             .OrderByDescending(f => f.LastWriteTime)
             .First();
                    if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + myFile2.ToString()))
                        PlayerN(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + myFile2.ToString());
                    gamever.Text = "WK 5.8.1";
                    recentrec.Text = myFile2.ToString().Remove(myFile2.ToString().Length - 4);
                    oldfn.Text = myFile2.ToString().Remove(myFile2.ToString().Length - 4);
                    getext.Text = myFile2.ToString().Substring(Math.Max(0, myFile2.ToString().Length - 4));
                }

                    else if (RCRecCount != 0 && WKRecCount == 0)
                {
                    var myFile = directory.GetFiles("*.mgz").Where(x => !x.FullName.Contains("voobly-spec.mgz") && !x.FullName.Contains("rec.mgz"))
             .OrderByDescending(f => f.LastWriteTime)
             .First();
                    if (File.Exists(mskdpath.Text + @"\SaveGame\" + myFile.ToString()))
                        PlayerN(mskdpath.Text + @"\SaveGame\" + myFile.ToString());
                    gamever.Text = "1.5 RC";
                    recentrec.Text = myFile.ToString().Remove(myFile.ToString().Length - 4);
                    oldfn.Text = myFile.ToString().Remove(myFile.ToString().Length - 4);
                    getext.Text = myFile.ToString().Substring(Math.Max(0, myFile.ToString().Length - 4));
                }
                    else if (RCRecCount == 0 && WKRecCount == 0)
                {
                    KryptonMessageBox.Show("No replays yet! Play one game and come back!");
                }


            }
            catch (Exception gh)
            {
                //throw gh;
                KryptonMessageBox.Show(gh.ToString());
                this.Close();
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

        private void closerec_Click(object sender, EventArgs e)
        {
            try { 
            //int FileSize = 0; //This belongs to the process you would like to terminate
            //Create the process csrss for every process with the name csrss
          
                //FileInfo csrssFile = new FileInfo(csrss.StartInfo.FileName); //Get the properties of its file name
                var processage = Process.GetCurrentProcess();
                Process[] processtool = Process.GetProcessesByName("AoE2Tools");

                // Or whatever method you are using
                string Pathage = processage.MainModule.FileName;
                string Pathtool = processage.MainModule.FileName;


                if (processtool[0].MainModule.FileName != processage.MainModule.FileName)
                {
                    processtool[0].Kill();
                    
                }
                }
            catch (SystemException)
            {

            }
           
            this.Close();
        }

        private async void delrec_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = KryptonMessageBox.Show("Delete This Replay?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (gamever.Text == "WK 5.7.2" || gamever.Text == "WK 5.7.4" || gamever.Text == "WK 5.8.1")
                    {
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text);
                        }
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text);
                        }
                        //2nd wk folder
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text);
                        }
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text);
                        }
                        //this.Close();
                        RecentR();
                    }
                    else if (gamever.Text != "WK 5.7.2" && gamever.Text != "WK 5.7.4" && gamever.Text != "WK 5.8.1")
                    {
                        if (File.Exists(mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text);
                        }
                        if (File.Exists(mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text);
                        }
                        //this.Close();
                        await Task.Run(() => RecentR());
                    }

                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            catch (Exception gt)
            {
               // MessageBox.Show("Could not delete this replay! Close Age of empires 2 first!", "Error");
                throw gt;
            }

 
        }
        public bool movedornot = true;
        private FileInfo myFile;
        private FileInfo myFile2;
        private void saverec_Click(object sender, EventArgs e)
        {
            try
            {
 
                saverec.Enabled = false;
                if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text) && oldfn.Text != recentrec.Text)
                {
                    try
                    {
                        if (gamever.Text == "WK 5.7.2" || gamever.Text == "WK 5.7.2" || gamever.Text == "WK 5.8.1")
                        {
                            File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text, mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text);
                            File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text, mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text);

                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Please Run AoE2Tools As Administrator!");
                        movedornot = false;
                        saverec.Enabled = true;
                    }
                    catch(SystemException)
                    {
                        //movedornot = false;
                        saverec.Enabled = true;
                    }
                    finally
                    {
                        if (movedornot == true)
                        {
                        oldfn.Text = recentrec.Text;

                        KryptonMessageBox.Show("Replay Renamed!", "Success");
                        saverec.Enabled = true;
                        }
                        else
                        {
                            KryptonMessageBox.Show("Failed to rename!", "Failed!");
                        }
                       
                    }
            
                }
                else if (File.Exists(mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text) && oldfn.Text != recentrec.Text)
                {
                    //if(gamever.Text == "WK")
                    //{
                    //    File.Copy(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text, mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text);
                    //    oldfn.Text = recentrec.Text;
                    //    KryptonMessageBox.Show("Replay Renamed!", "Success");
                    //    saverec.Enabled = true;
                    //}
                    if (gamever.Text != "WK 5.7.2" && gamever.Text != "WK 5.7.4" && gamever.Text != "WK 5.8.1")
                    {
                        File.Move(mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text, mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text);
                        oldfn.Text = recentrec.Text;
                        KryptonMessageBox.Show("Replay Renamed!", "Success");
                        saverec.Enabled = true;
                    }
                    
                }
               
            }
                catch(UnauthorizedAccessException)
            {
                MessageBox.Show("Please Run AoE2Tools As Administrator!");
                saverec.Enabled = true;
            }
            catch (SystemException)
            {
                saverec.Enabled = true;
                //throw ex;
                ////MessageBox.Show("Could not save this replay! Close Age of empires 2 first or move the game to the recommended directory!", "Error");
            }
        }

        private void watchrec_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gamever.Text);
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
                        KryptonMessageBox.Show(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat" + "is not found!", "Error");
                }
                //WK "oldfn.Text == recentrec.Text"
                if (File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text))
                {
   
                    string notrenamedrec = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text;
                    if (!File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text))
                    {
                            File.Copy(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text, mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text);    
                    }
                    WatchRepm(notrenamedrec);
                }
                    // oldfn.Text != recentrec.Text && File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text)
                else if (File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text))
                {
                    string renamedrec = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text;
                    if (!File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text))
                    {
                        File.Copy(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text, mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text);
                    }
                    WatchRepm(renamedrec);
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
                //WK "oldfn.Text == recentrec.Text"
                if (File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text))
                {

                    string notrenamedrec = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text;
                    if (!File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text))
                    {
                        File.Copy(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text, mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text);
                    }
                    WatchRepm(notrenamedrec);
                }
                // oldfn.Text != recentrec.Text && File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text)
                else if (File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text))
                {
                    string renamedrec = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text;
                    if (!File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text))
                    {
                        File.Copy(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text, mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text);
                    }
                    WatchRepm(renamedrec);
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
                        KryptonMessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.8.4\empires2_x1_p1.dat" + "is not found!", "Error");
                    if (!File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                        KryptonMessageBox.Show(mskdpath.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat" + "is not found!", "Error");
                }
                //WK "oldfn.Text == recentrec.Text"
                if (File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text))
                {

                    string notrenamedrec = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text;
                    if (!File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text))
                    {
                        File.Copy(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text, mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text);
                    }
                    WatchRepm(notrenamedrec);
                }
                // oldfn.Text != recentrec.Text && File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text)
                else if (File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text))
                {
                    string renamedrec = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text;
                    if (!File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text))
                    {
                        File.Copy(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text, mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text);
                    }
                    WatchRepm(renamedrec);
                }
            }
            else if (gamever.Text != "WK 5.7.2" && gamever.Text != "WK 5.7.4" && gamever.Text != "WK 5.8.1")
            {
                //Not WK
                if (oldfn.Text == recentrec.Text)
                {
                    string notrenamedrec = mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text;

                    WatchRepm(notrenamedrec);
                }
                else if (oldfn.Text != recentrec.Text && File.Exists(mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text))
                {
                    string renamedrec = mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text;
                    WatchRepm(renamedrec);
                }
            }
 

            
        }
        public void WatchRepm(string renfilerec)
        {

                //this rec full path
            //string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + getext.Text;
               // KryptonMessageBox.Show("start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"");

                //launch game ver
                if (gamever.Text == "1.5 RC")
                {
                    try
                    {
                        
                        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.5.exe");
                        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                        System.Diagnostics.Process process15 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                        //startInfo.Verb = "runas";
                        process15.StartInfo = startInfo;
                        process15.Start();
                        process15.WaitForExit();

                    }
                    catch (Exception goy)
                    {
                        throw goy;

                    }
                }
                else if (gamever.Text == "1.4 RC")
                {
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

                    }
                    catch (Exception goy)
                    {
                        throw goy;

                    }
                }

                else if (gamever.Text == "1.0 C")
                {
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
                    if (File.Exists(mskdpath.Text + "\\Age2_x1\\WK.exe"))
                    {
                        try
                        {

                            //byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WK.exe");
                            //File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                            File.Copy(mskdpath.Text + "\\Age2_x1\\WK.exe", mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", true);
                            System.Diagnostics.Process processwk = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfowk = new System.Diagnostics.ProcessStartInfo();
                            startInfowk.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfowk.FileName = "cmd.exe";
                            startInfowk.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                       
                            //startInfo.Verb = "runas";
                            processwk.StartInfo = startInfowk;
                            processwk.Start();
                            processwk.WaitForExit();

                        }
                            catch(System.IO.IOException)
                        {
                            KryptonMessageBox.Show("Close Age of Empires 2 First!");
                        }
                        catch (Exception goy)
                        {
                            throw goy;

                        }
                    }
                    
                    else if (!File.Exists(mskdpath.Text + "\\Age2_x1\\WK.exe"))
                    {
                        if (KryptonMessageBox.Show(
"WololoKingdom is Not Installed! \n Would you like to install WK now?", "WK is Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk
) == DialogResult.Yes)
                        {
                            WololoInstaller wkwind = new WololoInstaller();
                            wkwind.ShowDialog();
                            
                        }
                    }

                }
            //WKAK
                //else if (gamever.Text == "WKAK")
                //{
                //    try
                //    {
                //        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WKAK.exe");
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
                //end




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
        public void PlayerN(string RecName)
        {
            try
            {


                //extracting recorde header
                using (FileStream fs = new FileStream(RecName, FileMode.Open, FileAccess.Read, FileShare.Read))
                { 
                BinaryReader br = new BinaryReader(fs);
                
                byte[] buffer;

                int headerLength = br.ReadInt32();
                int nextPosistion = br.ReadInt32();



                int compressLen = headerLength - 8;
                buffer = new Byte[compressLen];
                buffer = br.ReadBytes(compressLen);

                MemoryStream ms = new MemoryStream();
                ms.Write(buffer, 0, buffer.Length);
                byte[] HeaderByt = inflate1(ms);
                byte[] pattern = { 0x00, 0x16, 0xF0 };

                byte[] toBeSearched = HeaderByt;
                string afx = rndstr(8);
                File.WriteAllBytes(System.IO.Path.GetTempPath() + @"\rep-" + afx, toBeSearched);
                List<int> positions = SearchBytePattern(pattern, toBeSearched);
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
                        //1v1
                        if (positions.Count() == 3)
                        {
                            if (skipper == 2)
                                Player1.Text = sb.ToString();
                            else if (skipper == 3)
                                Player2.Text = sb.ToString();
                        }
                            //2v2
                        else if (positions.Count() == 5)
                        {
                            if (skipper == 2)
                                Player1.Text = sb.ToString();
                            else if (skipper == 3)
                                Player2.Text = sb.ToString();
                            else if (skipper == 4)
                                Player3.Text = sb.ToString();
                            else if (skipper == 5)
                                Player4.Text = sb.ToString();
                            else if (skipper == 6)
                                Player6.Text = sb.ToString();
                            else if (skipper == 7)
                                Player8.Text = sb.ToString();
                            else if (skipper == 8)
                                Player5.Text = sb.ToString();
                            else if (skipper == 9)
                                Player7.Text = sb.ToString();
                        }
                        else if (positions.Count() > 5)
                        {
                        if (skipper == 2)
                            Player1.Text = sb.ToString();
                        else if (skipper == 3)
                            Player2.Text = sb.ToString();
                        else if (skipper == 4)
                            Player4.Text = sb.ToString();
                        else if (skipper == 5)
                            Player3.Text = sb.ToString();
                        else if (skipper == 6)
                            Player6.Text = sb.ToString();
                        else if (skipper == 7)
                            Player8.Text = sb.ToString();
                        else if (skipper == 8)
                            Player5.Text = sb.ToString();
                        else if (skipper == 9)
                            Player7.Text = sb.ToString();
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

                }
                //if (File.Exists(System.IO.Path.GetTempPath() + @"\rep-" + afx))
                //    File.Delete(System.IO.Path.GetTempPath() + @"\rep-" + afx);
            }
            catch (SystemException)
            {

            }
        }
        private byte[] inflate1(MemoryStream ms)
        {
            try
            {

                ms.Seek(0, SeekOrigin.Begin);
                Inflater inflater = new Inflater(true);
                using(InflaterInputStream inStream = new InflaterInputStream(ms, inflater))
                { 
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
                ms.Close();
                ms.Dispose();
                return buf;
                }
              
            }
            catch (Exception ju)
            {
                throw ju;
            }
        }

        private void Player2_Click(object sender, EventArgs e)
        {

        }

  
    }
}

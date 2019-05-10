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
using System.Diagnostics;
using Microsoft.Win32;
using System.IO.Compression;
using System.IO;
using Ionic.Zip;
using System.Globalization;
using System.Resources;
using Steamworks;
namespace WindowsFormsApplication3
{
    public partial class Hotkeys : KryptonForm
    {
        public Hotkeys()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        //private string steamprofiles = "";
        private string steamfolder = "";
        
        private Random _rand = new Random();
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private async void Hotkeys_Load(object sender, EventArgs e)
        {
            await Task.Run(() => aoepath());
            //aoepath();
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());

            Task<int> steampathchk = SteamPathChk();
            int result2 = await steampathchk;

            Task<int> hotkeytimer = HotkeyTimer();
            int result = await hotkeytimer;
   
            
        }
        public async Task<int> SteamPathChk()
        {
            kryptonListBox1.Items.Clear();
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "SteamPath", null) != null)
                {
                    string steampath = rk.GetValue("SteamPath").ToString();
                    steamfolder = Path.Combine(steampath, "Profiles");
                    if (Directory.Exists(steampath) && Directory.Exists(Path.Combine(steampath, "Profiles")))
                    {
                        string[] files = System.IO.Directory.GetFiles(Path.Combine(steampath, "Profiles"), "*.hki");
                        foreach (string file in files)
                        {
                            kryptonListBox1.Items.Add(CreateNewItem(file));
                            if (kryptonListBox1.SelectedIndex >= 0)
                                kryptonButton2.Enabled = true;

                        }
                        hdfix.Visible = false;
                        hdpath.StateNormal.ShortText.Color1 = Color.ForestGreen;
                        hdpath.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 6.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        hdpath.Text = "Select && Install Your Steam Hotkeys";
                        timer1.Stop();
                        return 1;
                    }
                    
                }
                return 1;
            }
        }
        public async Task<int> HotkeyTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Enabled = true;
            timer1.Interval = 2000; // in miliseconds
            await Task.Delay(1000);
            timer1.Start();
            return 1;

        }
        private async void timer_Tick(object sender, EventArgs e)
        {
            Task<int> steampathchk = SteamPathChk();
            int result = await steampathchk;
        }
        private void hkilink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://aokhotkeys.appspot.com");
        }

        private void hkilink_MouseHover(object sender, EventArgs e)
        {
            //ToolTip buttonToolTip2 = new ToolTip();
            //buttonToolTip2.ToolTipTitle = "Click The Blue Link";
            //buttonToolTip2.UseFading = true;
            //buttonToolTip2.UseAnimation = true;
            //buttonToolTip2.IsBalloon = true;
            //buttonToolTip2.ShowAlways = true;
            //buttonToolTip2.AutoPopDelay = 50000;
            //buttonToolTip2.InitialDelay = 200;
            //buttonToolTip2.ReshowDelay = 500;
            //buttonToolTip2.SetToolTip(hkilink, "1- Open the website Hotkeys Converter. \n 2- Browse Your AOE2HD Hotkey And Click Edit File. \n 3- Choose Version \"AoC/FE/HD2.0\" And Click Generate .hki File. \n 4- Now Import This generated File");
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            aoepath();
            String backupdir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AoE2Tools\\Hotkeys\\";
            if (!Directory.Exists(backupdir))
            {
                Directory.CreateDirectory(backupdir);
            }
            if (!File.Exists(backupdir + "backuphki.zip"))
            {
                restorehki.Enabled = false;
            }
            else
            {
                restorehki.Enabled = true;
            }
        }

        private void Hotkeys_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            String backupdir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AoE2Tools\\Hotkeys\\";
            if (!Directory.Exists(backupdir))
            {
                Directory.CreateDirectory(backupdir);
            }
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Hotkeys Profile File|*.zip";
                saveFileDialog1.Title = "Save Hotkeys Profile File To";
                saveFileDialog1.ShowDialog();

                saveFileDialog1.InitialDirectory = backupdir;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.FileName != "")
                {
                    //string datebk = DateTime.Now.ToString("yyyyMMddHHmmss");
                    //if (File.Exists(saveFileDialog1.FileName + ".zip"))
                    //{
                    //    File.Move(saveFileDialog1.FileName + ".zip", backupdir + "backuphki" + datebk + ".zip");
                    //   // File.Delete(backupdir + "backuphki.zip");
                    //}

                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + "\\", "*.hki");
                    if (File.Exists(saveFileDialog1.FileName)) { try { File.Delete(saveFileDialog1.FileName); } catch (SystemException) { } }
                   
                    foreach (string file in files)
                    {
                        
                           using(ZipArchive modFile = System.IO.Compression.ZipFile.Open(saveFileDialog1.FileName, ZipArchiveMode.Update))
                           {
                                   modFile.CreateEntryFromFile(file, Path.GetFileName(file));

                           }
                 

                    }
                    
                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(saveFileDialog1.FileName, ZipArchiveMode.Update))
                    {
                        //Here are two hard-coded files that we will be adding to the zip
                        //file.  If you don't have these files in your system, this will
                        //fail.  Either create them or change the file names.  Also, note
                        //that their names are changed when they are put into the zip file.
                        if (File.Exists(mskdpath.Text + "\\player.nfo"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfo", "player.nfo");
                        if (File.Exists(mskdpath.Text + "\\player.nfp"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfp", "player.nfp");
                        if (File.Exists(mskdpath.Text + "\\player.nfx"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfx", "player.nfx");
                        if (File.Exists(mskdpath.Text + "\\player.nfz"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfz", "player.nfz");
                        //We could also add the code from Example 4 here to read
                        //the contents of the open zip file as well.
                    }
                    KryptonMessageBox.Show("Hotkeys Profile has been Saved To: \n" + saveFileDialog1.FileName, "Backup Success!");
                    
                }


        }

        private void restorehki_Click(object sender, EventArgs e)
        {
           OpenFileDialog importfile = new OpenFileDialog();
            importfile.Filter = "Hotkeys Profile Zip|*.zip";
            importfile.Title = "Select Hotkeys Profile To Import";
            importfile.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (importfile.FileName != "")
            {
                //deleting current hki
                //string[] files = System.IO.Directory.GetFiles(mskdpath.Text, "*.hki");
                //foreach (string file in files)
                //{
                //    File.Delete(file);

                //}
                //AoC Hotkeys
                DirectoryInfo di = new DirectoryInfo(mskdpath.Text);
                FileInfo[] files = di.GetFiles("*.hki")
                                     .Where(p => p.Extension == ".hki").ToArray();
                foreach (FileInfo file in files)
                    try
                    {
                        file.Attributes = FileAttributes.Normal;
                        File.Delete(file.FullName);
                    }
                    catch (SystemException) { }
                try
                {
                File.Delete(mskdpath.Text + "\\player.nfo");
                File.Delete(mskdpath.Text + "\\player.nfp");
                File.Delete(mskdpath.Text + "\\player.nfx");
                File.Delete(mskdpath.Text + "\\player.nfz");
                }
                catch(SystemException)
                {

                }
               
                //String backupdir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AoE2Tools\\Hotkeys\\";
                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(importfile.FileName))
                {
              
                   // Directory.EnumerateFiles(mskdpath.Text, "*.hki").ToList().ForEach(x => File.Delete(x));

                    zip.ExtractAll(mskdpath.Text, ExtractExistingFileAction.OverwriteSilently);
                    //modFile.ExtractToDirectory(mskdpath.Text);
                    
                  
                }
                //WK Hotkeys restore
                DirectoryInfo di2 = new DirectoryInfo(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms");
                FileInfo[] files2 = di2.GetFiles("*.hki")
                                     .Where(p => p.Extension == ".hki").ToArray();
                foreach (FileInfo file2 in files2)
                    try
                    {
                        file2.Attributes = FileAttributes.Normal;
                        File.Delete(file2.FullName);
                    }
                    catch (SystemException) { }
                try
                {
                    File.Delete(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfz");
                }
                catch (SystemException) { }
                //String backupdir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AoE2Tools\\Hotkeys\\";
                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(importfile.FileName))
                {

                    // Directory.EnumerateFiles(mskdpath.Text, "*.hki").ToList().ForEach(x => File.Delete(x));

                    zip.ExtractAll(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms", ExtractExistingFileAction.OverwriteSilently);
                    //modFile.ExtractToDirectory(mskdpath.Text);


                }
                //WK Offline
                DirectoryInfo di3 = new DirectoryInfo(mskdpath.Text + @"\Games\WololoKingdoms");
                FileInfo[] files3 = di3.GetFiles("*.hki")
                                     .Where(p => p.Extension == ".hki").ToArray();
                foreach (FileInfo file3 in files3)
                    //Only if symbolic then extract hotkeys
                    if (IsSymbolic(file3.FullName) == false)
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(importfile.FileName))
                    {
 
                        zip.ExtractAll(mskdpath.Text + @"\Games\WololoKingdoms", ExtractExistingFileAction.OverwriteSilently);
    
                    }
                }
                //end

                KryptonMessageBox.Show("Your Hotkeys Profile has been restored!", "Hotkeys Restored");
            }
            else
            {

            }

        }

        private void renametxt_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
                //            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.Filter = "Hotkey File|*.hki";
                //saveFileDialog1.Title = "Save Hotkey File To";
            this.openFileDialog1.FileName = "*.hki";
            this.openFileDialog1.Filter = "Hotkey File|*.hki";
            this.openFileDialog1.Title = "Select Hotkey File From";

            //Begin
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string _selecthki = openFileDialog1.FileName;
                browsehkitxt.Text = _selecthki;
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (!otherhki.Text.Contains("Default") && !otherhki.Text.Contains("="))
            {
                if (File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\hki\\" + otherhki.Text + "\\player1.hki"))
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\hki\\" + otherhki.Text + "\\player1.hki", mskdpath.Text + "\\player1.hki", true);
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\hki\\" + otherhki.Text + "\\player1.hki", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player1.hki", true);
                KryptonMessageBox.Show(otherhki.Text + "Hotkeys Successfully installed!", "Hotkeys Installed!");
            }
            else
            {
                KryptonMessageBox.Show("Please select a correct hotkey file","Dad Gum!");
            }
            
        }

        private void browsehkitxt_TextChanged(object sender, EventArgs e)
        {
            if (browsehkitxt.Text != null)
            {
                kryptonButton2.Enabled = true;
            }
        }

        private void hkilink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://aokhotkeys.appspot.com/");
        }
        private object CreateNewItem(string itemname)
        {
            KryptonListItem item = new KryptonListItem();
            item.ShortText = Path.GetFileNameWithoutExtension(itemname);
            item.LongText = "(" + "Hotkey Profile" + ")";
            item.Image = imageList1.Images[0];
            return item;
        }
        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            try
            {

            
            if(browsehkitxt.Text.Contains(".hki"))
            {
                //Clean profiles first
                //del wk
                if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\"))
                { 
                string[] files122 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.hki");
                foreach (string file12 in files122)
                {
                    File.Delete(file12);

                }

                string[] files33 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.uh");
                foreach (string file3 in files33)
                {
                    if (File.Exists(file3))
                        File.Delete(file3);
                }

                string[] files4 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.nfp");
                foreach (string file4 in files4)
                {
                    if (File.Exists(file4))
                        File.Delete(file4);
                }

                string[] files5 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.nfz");
                foreach (string file5 in files5)
                {
                    if (File.Exists(file5))
                        File.Delete(file5);
                }
                string[] files55 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.nfo");
                foreach (string file51 in files55)
                {
                    if (File.Exists(file51))
                        File.Delete(file51);
                }
            }
                //delete aoc
                if (Directory.Exists(mskdpath.Text))
                { 
                string[] files1221 = System.IO.Directory.GetFiles(mskdpath.Text, "*.hki");
                foreach (string file12 in files1221)
                {
                    File.Delete(file12);

                }

                string[] files331 = System.IO.Directory.GetFiles(mskdpath.Text, "*.uh");
                foreach (string file3 in files331)
                {
                    if (File.Exists(file3))
                        File.Delete(file3);
                }

                string[] files41 = System.IO.Directory.GetFiles(mskdpath.Text, "*.nfp");
                foreach (string file4 in files41)
                {
                    if (File.Exists(file4))
                        File.Delete(file4);
                }

                string[] files51 = System.IO.Directory.GetFiles(mskdpath.Text, "*.nfz");
                foreach (string file5 in files51)
                {
                    if (File.Exists(file5))
                        File.Delete(file5);
                }
                string[] files555 = System.IO.Directory.GetFiles(mskdpath.Text, "*.nfo");
                foreach (string file51 in files555)
                {
                    if (File.Exists(file51))
                        File.Delete(file51);
                }
            }
                //del wkoffline
                if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\"))
                { 
                string[] files1222 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.hki");
                foreach (string file12 in files1222)
                {
                    File.Delete(file12);

                }

                string[] files332 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.uh");
                foreach (string file3 in files332)
                {
                    if (File.Exists(file3))
                        File.Delete(file3);
                }

                string[] files42 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.nfp");
                foreach (string file4 in files42)
                {
                    if (File.Exists(file4))
                        File.Delete(file4);
                }

                string[] files52 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.nfz");
                foreach (string file5 in files52)
                {
                    if (File.Exists(file5))
                        File.Delete(file5);
                }
                string[] files552 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.nfo");
                foreach (string file51 in files552)
                {
                    if (File.Exists(file51))
                        File.Delete(file51);
                }
                }
                //Install to AoC 
                
                if (Directory.Exists(mskdpath.Text))
                {
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\player.nfz", mskdpath.Text + "\\player.nfz", true);
                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + "\\", "*.hki");
                    if (files == null || files.Length == 0)
                    {
                        File.Copy(browsehkitxt.Text, mskdpath.Text + @"\player1.hki", true);
                        
                        
                    }
                    else
                    {
                        foreach (string file in files)
                        {
                            //File.Delete(file);
                            File.Copy(browsehkitxt.Text, file, true);


                        }
                    }
                   

                }
                //Install to WK Mod 
                
                if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\"))
                          {
                              File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\player.nfz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfz", true);
                              string[] files2 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.hki");
                              if (files2 == null || files2.Length == 0)
                              {
                                  File.Copy(browsehkitxt.Text, mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player1.hki", true);


                              }
                              else
                              {
                                  foreach (string file2 in files2)
                                  {
                                      File.Copy(browsehkitxt.Text, file2, true);

                                  }
                              }
        
                      
                          }
                
                     //Install to WK Offline    
               
                if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\"))
                {
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\player.nfz", mskdpath.Text + @"\Games\WololoKingdoms\player.nfz", true);
                    //string[] files2 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.hki");
                    string[] files3 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.hki");
                    //foreach (string filewk in files2)
                    if (files3 == null || files3.Length == 0)
                    {
                        File.Copy(browsehkitxt.Text, mskdpath.Text + @"\Games\WololoKingdoms\player1.hki", true);


                    }
                    else
                    {
                        foreach (string fileoff in files3)
                        {
                            File.Copy(browsehkitxt.Text, fileoff, true);

                        }
                    }

                }
                     
                          KryptonMessageBox.Show("Hotkeys Successfully Imported!", "Import Success!");
            }
            else if (kryptonListBox1.SelectedIndex >= 0)
            {
                string hotkeyitem = Path.Combine(steamfolder, kryptonListBox1.SelectedItem.ToString() + ".hki");

                //del wk
                if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\"))
                {
                    string[] files122 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.hki");
                    foreach (string file12 in files122)
                    {
                        File.Delete(file12);

                    }

                    string[] files33 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.uh");
                    foreach (string file3 in files33)
                    {
                        if (File.Exists(file3))
                            File.Delete(file3);
                    }

                    string[] files4 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.nfp");
                    foreach (string file4 in files4)
                    {
                        if (File.Exists(file4))
                            File.Delete(file4);
                    }

                    string[] files5 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.nfz");
                    foreach (string file5 in files5)
                    {
                        if (File.Exists(file5))
                            File.Delete(file5);
                    }
                    string[] files55 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.nfo");
                    foreach (string file51 in files55)
                    {
                        if (File.Exists(file51))
                            File.Delete(file51);
                    }
                }
                //delete aoc
                if (Directory.Exists(mskdpath.Text))
                {
                    string[] files1221 = System.IO.Directory.GetFiles(mskdpath.Text, "*.hki");
                    foreach (string file12 in files1221)
                    {
                        File.Delete(file12);

                    }

                    string[] files331 = System.IO.Directory.GetFiles(mskdpath.Text, "*.uh");
                    foreach (string file3 in files331)
                    {
                        if (File.Exists(file3))
                            File.Delete(file3);
                    }

                    string[] files41 = System.IO.Directory.GetFiles(mskdpath.Text, "*.nfp");
                    foreach (string file4 in files41)
                    {
                        if (File.Exists(file4))
                            File.Delete(file4);
                    }

                    string[] files51 = System.IO.Directory.GetFiles(mskdpath.Text, "*.nfz");
                    foreach (string file5 in files51)
                    {
                        if (File.Exists(file5))
                            File.Delete(file5);
                    }
                    string[] files555 = System.IO.Directory.GetFiles(mskdpath.Text, "*.nfo");
                    foreach (string file51 in files555)
                    {
                        if (File.Exists(file51))
                            File.Delete(file51);
                    }
                }
                //del wkoffline
                if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\"))
                {
                    string[] files1222 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.hki");
                    foreach (string file12 in files1222)
                    {
                        File.Delete(file12);

                    }

                    string[] files332 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.uh");
                    foreach (string file3 in files332)
                    {
                        if (File.Exists(file3))
                            File.Delete(file3);
                    }

                    string[] files42 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.nfp");
                    foreach (string file4 in files42)
                    {
                        if (File.Exists(file4))
                            File.Delete(file4);
                    }

                    string[] files52 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.nfz");
                    foreach (string file5 in files52)
                    {
                        if (File.Exists(file5))
                            File.Delete(file5);
                    }
                    string[] files552 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.nfo");
                    foreach (string file51 in files552)
                    {
                        if (File.Exists(file51))
                            File.Delete(file51);
                    }
                }

                //Install to AoC 
                
                if (Directory.Exists(mskdpath.Text))
                {
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + "data\\player.nfz", mskdpath.Text + "\\player.nfz", true);
                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + "\\", "*.hki");
                    if (files == null || files.Length == 0)
                    {
                        File.Copy(hotkeyitem, mskdpath.Text + "\\player1.hki", true);


                    }
                    else
                    {
                        foreach (string file in files)
                        {
                            //File.Delete(file);
                            File.Copy(hotkeyitem, file, true);


                        }
                    }


                }
                //Install to WK Mod 
                
                if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\"))
                {
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\player.nfz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfz", true);
                    string[] files2 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.hki");
                    if (files2 == null || files2.Length == 0)
                    {
                        File.Copy(hotkeyitem, mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player1.hki", true);


                    }
                    else
                    {
                        foreach (string file2 in files2)
                        {
                            File.Copy(hotkeyitem, file2, true);

                        }
                    }


                }

                //Install to WK Offline    
                
                if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\"))
                {
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + "data\\player.nfz", mskdpath.Text + @"\Games\WololoKingdoms\player.nfz", true);
                    //string[] files2 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.hki");
                    string[] files3 = System.IO.Directory.GetFiles(mskdpath.Text + @"\Games\WololoKingdoms\", "*.hki");
                    //foreach (string filewk in files2)
                    if (files3 == null || files3.Length == 0)
                    {
                        File.Copy(hotkeyitem, mskdpath.Text + @"\Games\WololoKingdoms\player1.hki", true);
                    }
                    else
                    {
                        foreach (string fileoff in files3)
                        {
                            File.Copy(hotkeyitem, fileoff, true);

                        }
                    }

                }
  

                KryptonMessageBox.Show("Steam Hotkey Profile Successfully Imported!", "Import Success!");  
                
            }
            else
            {
                KryptonMessageBox.Show("Not a valid hotkey file!", "Invalid Hotkey File!");
            }
                }
            catch(Exception ex)
            {
                MessageBox.Show("Please Run AoE2Tools As administrator to install the hotkeys!");
                //try
                //{
                //    System.Diagnostics.Process process = new System.Diagnostics.Process();
                //    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //    startInfo.FileName = "cmd.exe";
                //    string combfp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AoE2ToolsDiag.exe");
                //    startInfo.Arguments = "/c" + "start \"\" \"" + combfp + "\" /r";
                //    //startInfo.Verb = "runas";
                //    process.StartInfo = startInfo;
                //    process.Start();
                //    process.WaitForExit();
                //    process.Dispose();

                //}
                //catch
                //{

                //}
            }
        }
 
        private bool IsSymbolic(string path)
        {
            FileInfo pathInfo = new FileInfo(path);
            return pathInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);
        }
        private void hkilink_LinkClicked_1(object sender, EventArgs e)
        {

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


                kryptonButton3.Text = res_man.GetString("_browsebtn", cul);
                label3.Text = res_man.GetString("_browsebtn", cul);
                kryptonButton2.Text = res_man.GetString("_install", cul);
                groupBox3.Text = res_man.GetString("_importyourhotkeys", cul);
                renametxt.Text = res_man.GetString("_install", cul);
                //hkilink.Text = res_man.GetString("_hdhotkeystotc", cul);
                //kryptonTextBox1.Text = res_man.GetString("_hotkeysinfo", cul);
                groupBox2.Text = res_man.GetString("_installotherhotkeys", cul);
                label1.Text = res_man.GetString("_selecthotkeyssettings", cul);
                groupBox1.Text = res_man.GetString("_backuprestorehotkeys", cul);
                label2.Text = res_man.GetString("_backuprestoreinfo", cul);

            });
        }

        private void kryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kryptonButton2.Enabled = (kryptonListBox1.SelectedIndex >= 0);
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            
            Form2 scanner = new Form2();
            scanner.ShowDialog();
        }
    }
}

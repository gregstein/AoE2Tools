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
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;
using Microsoft.Win32;
using Ionic.Zip;
using System.IO.Compression;
using System.Globalization;
using System.Resources;

namespace WindowsFormsApplication3
{
    public partial class Stats : KryptonForm
    {
        public Stats()
        {
            InitializeComponent();
            aoepath();
        }
        private static Random random = new Random();
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private async void Stats_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
            //MessageBox.Show(mskdpath.Text + @"\SaveGame");
            if (Directory.Exists(mskdpath.Text + @"\SaveGame"))
            {
                ForEachFileAsync(mskdpath.Text + @"\SaveGame", "*.*", SearchOption.AllDirectories, (str) => DoSomething(str));
            }

            if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame"))
            {
                await Task.Run(() => ForEachFileAsync(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame", "*", SearchOption.AllDirectories, (str) => DoSomething(str)));
                //ForEachFileAsync(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame", "*", SearchOption.AllDirectories, (str) => DoSomething(str));
            }
            if (Directory.Exists(System.IO.Path.GetTempPath()))
            {
                try
                {
                    //long length = Directory.GetFiles(System.IO.Path.GetTempPath(), "*", SearchOption.AllDirectories).Sum(t => (new FileInfo(t).Length));
                    var di = new DirectoryInfo(System.IO.Path.GetTempPath());
                    tempcount.Text = await Task.Run(() => FormatByteSize(GetDirectorySize2(di)));
                }
                catch(SystemException)
                {

                }
                
                //ForEachFileAsync2(System.IO.Path.GetTempPath(), "*.*", SearchOption.AllDirectories, (str) => DoSomething(str));
            }
                if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\Multi"))
                {
                    var di = new DirectoryInfo(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\Multi");
                    var di2 = new DirectoryInfo(mskdpath.Text + @"\SaveGame\Multi");
                    restoregames.Text = await Task.Run(() => FormatByteSize(GetDirectorySize2(di) + GetDirectorySize2(di2)));
                    //await Task.Run(() => ForEachFileAsync2(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\Multi", "*.*", SearchOption.AllDirectories, (str) => DoSomething(str)));
                    //ForEachFileAsync2(mskdpath.Text + @"Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\Multi", "*.*", SearchOption.AllDirectories, (str) => DoSomething(str));
                }
            
            if (Directory.Exists(mskdpath.Text + @"\SaveGame"))
            {
                

    recsizes.Text = await Task.Run(() =>FormatByteSize(GetDirectorySize(mskdpath.Text + @"\SaveGame") + GetDirectorySize(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame")));
    

            }

        }
        int kot = 0;
        private Task DoSomething(string task)
        {

            throw new SystemException();
           
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


                kryptonPage1.Text = res_man.GetString("_quickstats", cul);
                kryptonPage2.Text = res_man.GetString("_backups", cul);
                kryptonPage3.Text = res_man.GetString("_statsrestore", cul);
                kryptonPage4.Text = res_man.GetString("_statsbulkrename", cul);
                kryptonLabel2.Text = res_man.GetString("_statsrecaoc", cul);
                kryptonLabel3.Text = res_man.GetString("_statsrecwk", cul);
                kryptonLabel4.Text = res_man.GetString("_statsrecsize", cul);
                kryptonLabel12.Text = res_man.GetString("_statstmpfiles", cul);
                kryptonLabel13.Text = res_man.GetString("_statsresgames", cul);
                cleanrestore.Text = res_man.GetString("_statsclean", cul);
                cleantmp.Text = res_man.GetString("_statsclean", cul);
                openative.Text = res_man.GetString("_open", cul);
                openwk.Text = res_man.GetString("_open", cul);
                kryptonGroupBox2.Text = res_man.GetString("_statscusbackup", cul);
                exportcustom.Text = res_man.GetString("_statsexportcusbackup", cul);
                kryptonGroupBox3.Text = res_man.GetString("_statsfullbackup", cul);
                kryptonLabel5.Text = res_man.GetString("_statsbackupdesc", cul);
                exportfull.Text = res_man.GetString("_statsexportfulbackup", cul);
                kryptonGroupBox4.Text = res_man.GetString("_statsrestorebackup", cul);
                kryptonLabel6.Text = res_man.GetString("_statsselectrestore", cul);
                lblbk.Text = res_man.GetString("_statsimport", cul);
                browsebk.Text = res_man.GetString("_browsebtn", cul);
                btnbk.Text = res_man.GetString("_statsrestoremybackup", cul);
                kryptonGroupBox5.Text = res_man.GetString("_statsbulkrentitle", cul);
                kryptonLabel7.Text = res_man.GetString("_statsselectbulk", cul);
                kryptonLabel8.Text = res_man.GetString("_statschoosefolder", cul);
                browserbulk.Text = res_man.GetString("_browsebtn", cul);
                kryptonButton1.Text = res_man.GetString("_statsbulkrenbtn", cul);
                kryptonLabel9.Text = res_man.GetString("_statsbulkrened", cul);
                kryptonLabel10.Text = res_man.GetString("_statsbtmdesc", cul);
                kryptonLabel1.Text = res_man.GetString("_statstrack", cul);
                kryptonGroupBox1.Text = res_man.GetString("_statslive", cul);
                Stats.ActiveForm.Text = res_man.GetString("_statstitle", cul);
                
                
            });
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

                       
                        //BeginInvoke((MethodInvoker)delegate
                        //{

                            mskdpath.Text = gpath;
                        //});
                    }
                    else
                    {
                        KryptonMessageBox.Show("Game Path Not Found!", "Error!");
                        this.Close();
                    }
                }
            }
        }

      
            public static long GetDirectorySize2(DirectoryInfo dir)
            {
                long total = 0;
                FileAttributes attributes = File.GetAttributes(dir.FullName);
                if (!((attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint))
                {
                    try
                    {
                        FileInfo[] fileInfos = dir.GetFiles();
                        foreach (FileInfo fileInfo in fileInfos)
                        {
                            total += fileInfo.Length;
                        }

                        DirectoryInfo[] dirInfos = dir.GetDirectories();
                        foreach (DirectoryInfo dirInfo in dirInfos)
                        {
                            total += GetDirectorySize2(dirInfo);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // log this?
                    }
                }

                return total;
            }
       
        private async Task ForEachFileAsync(string path, string searchPattern, SearchOption searchOption, Func<string, Task> doAsync)
        {
            // Avoid blocking the caller for the initial enumerate call.
            await Task.Yield();

            foreach (string file in Directory.EnumerateFiles(path, searchPattern, searchOption).Where(s => s.EndsWith(".mgz") || s.EndsWith(".mgx")))
            {
                kot++;
                //asyc file retrieval for recs
                await Task.Run(() =>
    {
 
        if (path == mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame")
       {
                recountwk.Text = kot.ToString() + " Replays";

        }

        else if (path == mskdpath.Text + @"\SaveGame")
        {
               recount.Text = kot.ToString() + " Replays";
            
        }
                
    });
            }
            
        }
        private async Task ForEachFileAsync2(string path, string searchPattern, SearchOption searchOption, Func<string, Task> doAsync)
        {
            // Avoid blocking the caller for the initial enumerate call.
            await Task.Yield();

            foreach (string file in Directory.EnumerateFiles(path, searchPattern, searchOption))
            {
                kot++;
                //asyc file retrieval for recs
                await Task.Run(() =>
                {
         
                     if (path == System.IO.Path.GetTempPath())
                    {
                        tempcount.Text = kot.ToString() + " Files";

                    }

                  

                });
            }
            

        }
        private string FormatByteSize(double bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB" };
            int index = 0;
            do { bytes /= 1024; index++; }
            while (bytes >= 1024);
            return String.Format("{0:0.00} {1}", bytes, Suffix[index]);

        }
        public static bool IsPathWithinLimits(string fullPathAndFilename)
        {
            const int MAX_PATH_LENGTH = 259;//260-1
            return fullPathAndFilename.Length <= MAX_PATH_LENGTH;
        }
        static long GetDirectorySize(string p)
        {
         try
         {
             if (Directory.Exists(p))
             {
                 //string[] a = Directory.GetFiles(p, "*");
                 string[] a = Directory.GetFiles(p, "*", SearchOption.AllDirectories);
                 long b = 0;
                 foreach (string name in a)
                 {
                     if(IsPathWithinLimits(name) == false)
                     {
                         continue;
                     }
                     FileInfo info = new FileInfo(name);
                     b += info.Length;

                 }
                 return b;
             }
             else
             {
                 long b = 0;
                 return b;
             }
            
         }
         catch (System.UnauthorizedAccessException)
         {
             //return 0;
         }
            catch(SystemException)
         {
             
         }

         return 0;
        }
        private void openative_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(mskdpath.Text + @"\SaveGame"))
            {
                Process.Start(mskdpath.Text + @"\SaveGame");
            }

            
        }

        private void openwk_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame"))
            {
                Process.Start(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame");
            }
        }
        public void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                //KryptonMessageBox.Show("Begin Saving: " + e.ArchiveName);
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                //labelCompressionStatus.Text = "Writing: " + e.CurrentEntry.FileName + " (" + (e.EntriesSaved + 1) + "/" + e.EntriesTotal + ")";
                //labelFilename.Text = "Filename:" + e.CurrentEntry.LocalFileName;
              
                    progressBar2.Maximum = e.EntriesTotal;
                    progressBar2.Value = e.EntriesSaved + 1;

               
             
                      
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
                //progressBar2.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                //KryptonMessageBox.Show("Done: " + e.ArchiveName);
            }
        }
        private async void exportfull_Click(object sender, EventArgs e)
        {

            // Show the FolderBrowserDialog.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archive Zip|*.Zip";
            saveFileDialog1.Title = "Save Zip File To";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                //backgroundWorker2.RunWorkerAsync();


                String DirectoryToZip = mskdpath.Text;
                String ZipFileToCreate = saveFileDialog1.FileName;

                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                {

                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    zip.SaveProgress += SaveProgress;

                    //zip.StatusMessageTextWriter = System.Console.Out;
                    //zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                    await Task.Run(() => zip.AddDirectory(DirectoryToZip));

                    zip.Save(ZipFileToCreate);



                }

                FileInfo sizez = new FileInfo(saveFileDialog1.FileName);
                string rootFolderPath = Path.GetDirectoryName(saveFileDialog1.FileName);
                string filesToDelete = @"DotNetZip-*";   // Only delete DOC files containing "DeleteMe" in their filenames
                string[] fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete);
                foreach (string file in fileList)
                {
                   
                    System.IO.File.Delete(file);
                }
                
                KryptonMessageBox.Show("Backup Size: " + FormatByteSize(sizez.Length), "Success");
            }
            else
            {

            }
            //compression
          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //if hotkeys checked
            if (hotkeys.Checked == true)
            {

                string[] files = System.IO.Directory.GetFiles(mskdpath.Text + "\\", "*.hki");
                int icnt = 0;
                if (File.Exists(bkname.Text)) { try { File.Delete(bkname.Text); } catch (SystemException) { } }

                foreach (string file in files)
                {

                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                    {
                        icnt++;
                        modFile.CreateEntryFromFile(file, Path.GetFileName(file));
                        backgroundWorker1.ReportProgress(icnt);
                    }


                }

                using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                {
                    icnt++;
 
                    if (File.Exists(mskdpath.Text + "\\player.nfo"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfo", "player.nfo");
                    if (File.Exists(mskdpath.Text + "\\player.nfp"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfp", "player.nfp");
                    if (File.Exists(mskdpath.Text + "\\player.nfx"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfx", "player.nfx");
                    if (File.Exists(mskdpath.Text + "\\player.nfz"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfz", "player.nfz");

                    backgroundWorker1.ReportProgress(icnt);
                }
                //end check
            }

            //if hotkeys WK checked
            if (hotkeyswk.Checked == true)
            {

                string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\", "*.hki");
                int icnt = 0;
                foreach (string file in files)
                {
                    
                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                    {
                        icnt++;
                        modFile.CreateEntryFromFile(file, @"Voobly Mods\AOC\Data Mods\WololoKingdoms\" + Path.GetFileName(file));
                        backgroundWorker1.ReportProgress(icnt);
                    }


                }

                using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                {
                    icnt++;

                    if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfo"))
                        modFile.CreateEntryFromFile(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfo", @"Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfo");
                    if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfp"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfp", @"Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfp");
                    if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfx"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfx", @"Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfx");
                    if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfz"))
                        modFile.CreateEntryFromFile(mskdpath.Text + "\\player.nfz", @"Voobly Mods\AOC\Data Mods\WololoKingdoms\player.nfz");
                    backgroundWorker1.ReportProgress(icnt);
                }
            }

            //if ais wk checked
            if (aiswk.Checked == true)
            {

                string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\Script.Ai", "*", SearchOption.AllDirectories);

                int icnt = 0;
                foreach (string file in files)
                {
                    
                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                    {
                        icnt++;
                        modFile.CreateEntryFromFile(file, file.Replace(mskdpath.Text + @"\", ""));
                        //progressBar1.Value = icnt;
                        backgroundWorker1.ReportProgress(icnt);
                    }


                }
                //backgroundWorker1.ReportProgress(0,
                //String.Format("Ais (WK) Done."));
                //backgroundWorker1.ReportProgress(0);

            }

            //if ais checked
            if (ais.Checked == true)
            {

                string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\AI", "*", SearchOption.AllDirectories);
                //progressBar1.Maximum = files.Count();
                int icnt = 0;
                foreach (string file in files)
                {

                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                    {
                        icnt++;
                        modFile.CreateEntryFromFile(file, file.Replace(mskdpath.Text + @"\", ""));
                        backgroundWorker1.ReportProgress(icnt);
                    }


                }
                //backgroundWorker1.ReportProgress(0);
            }

            //if savegames checked
            if (savegames.Checked == true)
            {

                string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\SaveGame", "*", SearchOption.AllDirectories);
                //progressBar1.Maximum = files.Count();
                int icnt = 0;
                foreach (string file in files)
                {

                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                    {
                        icnt++;
                        modFile.CreateEntryFromFile(file, file.Replace(mskdpath.Text + @"\", ""));
                        backgroundWorker1.ReportProgress(icnt);
                    }


                }

            }

            //if savegames wk checked
            if (savegameswk.Checked == true)
            {

                string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame", "*", SearchOption.AllDirectories);
                //progressBar1.Maximum = files.Count();
                int icnt = 0;
                foreach (string file in files)
                {
                    
                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                    {
                        icnt++;
                        modFile.CreateEntryFromFile(file, file.Replace(mskdpath.Text + @"\", ""));
                        backgroundWorker1.ReportProgress(icnt);
                    }


                }

            }

            //if vooblymods checked
            if (vooblymods.Checked == true)
            {

                string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Local Mods", "*", SearchOption.AllDirectories);
                //progressBar1.Maximum = files.Count();
                int icnt = 0;
                foreach (string file in files)
                {
                    
                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                    {
                        icnt++;
                        modFile.CreateEntryFromFile(file, file.Replace(mskdpath.Text + @"\", ""));
                        backgroundWorker1.ReportProgress(icnt);
                    }


                }

            }

            //if maps checked
            if (maps.Checked == true)
            {

                string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Random", "*", SearchOption.AllDirectories);
                //progressBar1.Maximum = files.Count();
                int icnt = 0;
                foreach (string file in files)
                {
                    
                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(bkname.Text, ZipArchiveMode.Update))
                    {
                        icnt++;
                        modFile.CreateEntryFromFile(file, file.Replace(mskdpath.Text + @"\", ""));
                        backgroundWorker1.ReportProgress(icnt);
                    }


                }

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            progressBar1.Value = e.ProgressPercentage;
            //lbl1.Text = e.UserState as string;
        }

        private void exportcustom_Click(object sender, EventArgs e)
        {
            if (hotkeys.Checked == false && ais.Checked == false && aiswk.Checked == false && hotkeyswk.Checked == false && savegames.Checked == false && savegameswk.Checked == false && vooblymods.Checked == false && maps.Checked == false)
            {
                KryptonMessageBox.Show("Please Select at least 1 option", "No Selection!");
            }
            else
            {
                //BEGIN CUSTOM BACKUP

                // Show the FolderBrowserDialog.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Archive Zip|*.Zip";
                saveFileDialog1.Title = "Save Zip File To";
                //saveFileDialog1.ShowDialog();
                //Custom Options
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    lbl1.Text = "";
                    //Counting files
                    foreach (Control c in flowLayoutPanel5.Controls)
                    {
                        if (c is KryptonCheckBox)
                        {
                            KryptonCheckBox chckbox = c as KryptonCheckBox;
                            if (chckbox.Checked == true)
                            {
                                // Text box is empty.
                                if (chckbox.Name == "hotkeys")
                                {
                                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + "\\", "*.hki");
                                    flcount.Text = (files.Count() + 4).ToString();
                                }
                                if (chckbox.Name == "ais")
                                {
                                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\AI", "*", SearchOption.AllDirectories);
                                    flcount.Text = (flcount.Text + files.Count()).ToString();
                                }
                                if (chckbox.Name == "aiswk")
                                {
                                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\Script.Ai", "*", SearchOption.AllDirectories);
                                    flcount.Text = (files.Count() + Int32.Parse(flcount.Text)).ToString();
                                }
                                if (chckbox.Name == "hotkeyswk")
                                {
                                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms", "*.hki");
                                    flcount.Text = (files.Count() + 4 + Int32.Parse(flcount.Text)).ToString();
                                }
                                if (chckbox.Name == "savegames")
                                {
                                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\SaveGame", "*", SearchOption.AllDirectories);
                                    flcount.Text = (files.Count() + Int32.Parse(flcount.Text)).ToString();
                                }
                                if (chckbox.Name == "savegameswk")
                                {
                                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame", "*", SearchOption.AllDirectories);
                                    flcount.Text = (files.Count() + Int32.Parse(flcount.Text)).ToString();
                                }
                                if (chckbox.Name == "vooblymods")
                                {
                                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Voobly Mods\AOC\Local Mods", "*", SearchOption.AllDirectories);
                                    flcount.Text = (files.Count() + Int32.Parse(flcount.Text)).ToString();
                                }
                                if (chckbox.Name == "maps")
                                {
                                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + @"\Random", "*", SearchOption.AllDirectories);
                                    flcount.Text = (files.Count() + Int32.Parse(flcount.Text)).ToString();
                                }
                                
                            }
                        }
                    }
                    progressBar1.Maximum = Int32.Parse(flcount.Text) + 10;
                    //end count
                    bkname.Text = saveFileDialog1.FileName;
                    
                    backgroundWorker1.RunWorkerAsync();
                    
                }
                //END CUSTOM BACKUP
            }
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = Int32.Parse(flcount.Text) + 10;
            flcount.Text = "0";
            lbl1.Text = "Backup Success!";
        }

        private void browsebk_Click(object sender, EventArgs e)
        {
            OpenFileDialog importfile = new OpenFileDialog();
            importfile.Filter = "Archive Zip|*.zip";
            importfile.Title = "Select a Backup To Import";
            if (importfile.ShowDialog() == DialogResult.OK)
            {
                txtbk.Text = importfile.FileName;
                btnbk.Enabled = true;
            }
        }
        private static bool justHadByteUpdate = false;
        public  void ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Extracting_EntryBytesWritten)
            {
                if (justHadByteUpdate)
                { 
                    Console.SetCursorPosition(0, Console.CursorTop);
                    
                    //progressBar3.Value = e.EntriesSaved + 1;
                Console.Write("   {0}/{1} ({2:N0}%)", e.BytesTransferred, e.TotalBytesToTransfer,
                          e.BytesTransferred / (0.01 * e.TotalBytesToTransfer));
                justHadByteUpdate = true;
                }
            }
            else if (e.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry)
            {
                if (justHadByteUpdate)
                    Console.WriteLine();
                Console.WriteLine("Extracting: {0}", e.CurrentEntry.FileName);
                justHadByteUpdate = false;
            }
        }
        public void ExtractFile(string zipToUnpack, string unpackDirectory)
        {
            using (Ionic.Zip.ZipFile zipr = Ionic.Zip.ZipFile.Read(zipToUnpack))
            {
                zipcnt.Text = zipr.Entries.Count.ToString();
            }
            progressBar3.Maximum = Int32.Parse(zipcnt.Text);
            int percentComplete = 0;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += (o, e) => { progressBar3.Value = e.ProgressPercentage; };
            worker.RunWorkerCompleted += (o, e) => { KryptonMessageBox.Show("Success! Backup Restored!", "Completed Task"); };
            worker.DoWork += (o, e) =>
            {
                using (Ionic.Zip.ZipFile zipr = Ionic.Zip.ZipFile.Read(zipToUnpack))
                {
                    
                    int step = (zipr.Entries.Count / 100);
                    //progressBar3.Maximum = zipr.Entries.Count;
                    
                    foreach (ZipEntry file in zipr)
                    {
                        file.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                        percentComplete++;
                        worker.ReportProgress(percentComplete);
                    }
                }
            };

            worker.RunWorkerAsync();
        }
        private void btnbk_Click(object sender, EventArgs e)
        {
            ExtractFile(txtbk.Text, mskdpath.Text);
            //int icnts = 0;
            //using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(txtbk.Text))
            //{
            //    icnts++;
            //    zip.ExtractAll(mskdpath.Text, ExtractExistingFileAction.OverwriteSilently);
            //    //modFile.CreateEntryFromFile(file, file.Replace(mskdpath.Text + @"\", ""));
            //    //backgroundWorker1.ReportProgress(icnts);
            //}
        }

        private void browserbulk_Click(object sender, EventArgs e)
        {
            try
            { 
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                string Select_p = fbd.SelectedPath.ToString();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (!Directory.Exists(fbd.SelectedPath)) { Directory.CreateDirectory(fbd.SelectedPath); }
                    txtbulk.Text = fbd.SelectedPath.ToString();
                    kryptonButton1.Enabled = true;
                  


                }
}


            }
            catch(IOException ex)
            {
                KryptonMessageBox.Show("Run AoE2Tools as Administrator to rename these recorded games!");
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (txtbulk.Text != "" && Directory.Exists(txtbulk.Text))
            {
                var files = Directory.EnumerateFiles(txtbulk.Text, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".mgz") || s.EndsWith(".mgx"));
                int totalcnt = files.Count();
                totalrecs.Text = totalcnt.ToString();
                resultbulk.Text = "0";
                foreach(var file in files)
                {
                    //MessageBox.Show(file.ToString());

                    
                    PlayerN(file.ToString());

                    
                    
                }
            }
            else
            {
                KryptonMessageBox.Show("This Directory does not exist! Please Select a valid Directory.", "Invalid Folder!");
            }
        }

        private void txtbulk_TextChanged(object sender, EventArgs e)
        {
            kryptonButton1.Enabled = true;
        }

        //rec rename
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
                ICSharpCode.SharpZipLib.Zip.Compression.Inflater inflater = new ICSharpCode.SharpZipLib.Zip.Compression.Inflater(true);
                ICSharpCode.SharpZipLib.Zip.Compression.Streams.InflaterInputStream inStream = new ICSharpCode.SharpZipLib.Zip.Compression.Streams.InflaterInputStream(ms, inflater);
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
                inStream.Close();
                inStream.Dispose();
                return buf;

            }
            catch (Exception ju)
            {
                throw ju;
            }
        }
        public static string rndstr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
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
        public async void PlayerN(string RecName)
        {
            try
            {


                //extracting replay header
                using (var fs = new FileStream(RecName, FileMode.Open, FileAccess.Read, FileShare.Read))
                using(MemoryStream ms = new MemoryStream())
                {
                    BinaryReader br = new BinaryReader(fs);
                    byte[] buffer;

                    int headerLength = br.ReadInt32();
                    int nextPosistion = br.ReadInt32();



                    int compressLen = headerLength - 8;
                    buffer = new Byte[compressLen];
                    buffer = br.ReadBytes(compressLen);
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
                                recfield.Text = Player1.Text + " Vs ";
                                
                            }
                            else if (skipper == 3)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += Player2.Text;
                               
                                //check file existence
                                FileInfo woop = new FileInfo(txtbulk.Text + @"\" + recfield.Text + ".mgz");
                                //await Task.Run(() => FileIndexChk(woop));
                                FileIndexChk(woop);
                                if (Directory.Exists(txtbulk.Text + @"\"))
                                {
                                    FileInfo woop2 = new FileInfo(txtbulk.Text + @"\" + recfield.Text + ".mgz");
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
                                recfield.Text = Player1.Text + " - ";
                                
                            }
                            else if (skipper == 3)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += Player2.Text + " - ";
                                
                            }

                            else if (skipper == 4)
                            {
                                Player3.Text = sb.ToString();
                                recfield.Text += Player3.Text + " VS ";
                                
                            }

                            else if (skipper == 5)
                            {
                                Player4.Text = sb.ToString();
                                recfield.Text += Player4.Text;
                                
                                //check file existence
                                FileInfo woop = new FileInfo(txtbulk.Text + @"\\" + recfield.Text + ".mgz");
                                //await Task.Run(() => FileIndexChk(woop));
                                FileIndexChk(woop);
                                if (Directory.Exists(txtbulk.Text + @"\"))
                                {
                                    FileInfo woop2 = new FileInfo(txtbulk.Text + @"\" + recfield.Text + ".mgz");
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
                                Player1.Text = sb.ToString();
                                recfield.Text = Player1.Text + " - ";
                            }

                            else if (skipper == 3)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += Player2.Text + " - ";
                            }

                            else if (skipper == 4)
                            {
                                Player4.Text = sb.ToString();
                                recfield.Text += Player4.Text + " Vs ";
                            }

                            else if (skipper == 5)
                            {
                                Player3.Text = sb.ToString();
                                recfield.Text += Player3.Text + " - ";
                            }

                            else if (skipper == 6)
                            {
                                Player6.Text = sb.ToString();
                                recfield.Text += Player6.Text + " - ";
                            }


                            else if (skipper == 8)
                            {
                                Player5.Text = sb.ToString();
                                recfield.Text += Player5.Text + " - ";
                            }

                            else if (skipper == 9)
                            {
                                Player7.Text = sb.ToString();
                                recfield.Text += Player7.Text + " - ";
                            }
                            else if (skipper == 7)
                            {
                                Player8.Text = sb.ToString();
                                recfield.Text += Player8.Text;
                                //check file existence
                                FileInfo _woop = new FileInfo(txtbulk.Text + @"\" + recfield.Text + ".mgz");
                                //await Task.Run(() => FileIndexChk(_woop));
                                FileIndexChk(_woop);
                                if (Directory.Exists(txtbulk.Text + @"\"))
                                {
                                    FileInfo _woop2 = new FileInfo(txtbulk.Text + @"\" + recfield.Text + ".mgz");
                                    //await Task.Run(() => FileIndexChk(_woop2));
                                    FileIndexChk(_woop2);
                                }
                            }
                            ////check file existence
                            //FileInfo woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                            //FileIndexChk(woop);
                            //if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\"))
                            //{
                            //    FileInfo woop2 = new FileInfo(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz");
                            //    FileIndexChk(woop2);
                            //}
                        }

                    }
                   
                }
afxit.Text = System.IO.Path.GetTempPath() + @"\rep-" + afx;
            }
                //if (recfield.Text != null)
                //{
                File.Move(RecName, txtbulk.Text + @"\" + recfield.Text + Path.GetExtension(RecName));
                    int gt = Int32.Parse(resultbulk.Text) + 1;
                    resultbulk.Text = gt.ToString();
                //}
                    
                //Check Empty players
                if (Player3.Text == "Loading...")
                    Player3.Text = "";
                if (Player4.Text == "Loading...")
                    Player4.Text = "";
                if (Player5.Text == "Loading...")
                    Player5.Text = "";
                if (Player6.Text == "Loading...")
                    Player6.Text = "";
                if (Player7.Text == "Loading...")
                    Player7.Text = "";
                if (Player8.Text == "Loading...")
                    Player8.Text = "";

                //fs.Close();
                //fs.Dispose();
                //br.Close();
                //br.Dispose();
                //ms.Close();
                //ms.Dispose();
                
                
                //if (File.Exists(System.IO.Path.GetTempPath() + @"\rep-" + afx))
                //    File.Delete(System.IO.Path.GetTempPath() + @"\rep-" + afx);
            }
            catch (SystemException)
            {

            }
            
        }

        private async void cleanrestore_Click(object sender, EventArgs e)
        {
            await Task.Run(() => RemoveDirectories(mskdpath.Text + @"\SaveGame\Multi\", "Multi"));
            await Task.Run(() => RemoveDirectories(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\Multi", "AoE2 Restores"));
            //RemoveDirectories(mskdpath.Text + @"\SaveGame\Multi\", "Multi");
            //RemoveDirectories(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\Multi", "AoE2 Restores");
            var di = new DirectoryInfo(mskdpath.Text + @"/Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\Multi");
            var di2 = new DirectoryInfo(mskdpath.Text + @"/SaveGame\Multi");
            restoregames.Text = await Task.Run(() => FormatByteSize(GetDirectorySize2(di) + GetDirectorySize2(di2)));
        }

        private void cleantmp_Click(object sender, EventArgs e)
        {
            RemoveDirectories(System.IO.Path.GetTempPath(), "Temp");
            var di = new DirectoryInfo(System.IO.Path.GetTempPath());
            tempcount.Text = FormatByteSize(GetDirectorySize2(di));
        }
        static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }
        private async void RemoveDirectories(string strpath, string name)
        {

            ThreadPool.QueueUserWorkItem((o) =>
            {
                if (Directory.Exists(strpath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(strpath);
                    var files = dirInfo.GetFiles();
                    var pcount = ConvertKilobytesToMegabytes(GetDirectorySize(strpath)).ToString("0.00");
                    //triggering progressbar
                    this.BeginInvoke(new Action(() =>
                    {
                        progressBar4.Minimum = 0;
                        progressBar4.Value = 0;
                        progressBar4.Maximum = files.Length;
                        progressBar4.Step = 1;
                    }));

                    foreach (FileInfo file in files)
                    {
                        try
                        {
                            file.Delete();

                            this.BeginInvoke(new Action(() => progressBar4.PerformStep()));
                        }
                        catch (UnauthorizedAccessException)
                        {

                        }
                        catch (SystemException)
                        {


                        }


                    }

                    var dirs = dirInfo.GetDirectories();

                    this.BeginInvoke(new Action(() =>
                    {
                        progressBar4.Value = 0;
                        progressBar4.Maximum = dirs.Length;
                    }));

                    foreach (DirectoryInfo dir in dirs)
                    {
                        try{dir.Delete(true);}catch (SystemException){}
                        
                        this.BeginInvoke(new Action(() => progressBar4.PerformStep())); 
                    }
                    //string createresult = "CleanUp Success! \n (X)" + name + "Cleaned: " + Environment.NewLine;
                    this.BeginInvoke(new Action(() =>
                    {
                    var di = new DirectoryInfo(System.IO.Path.GetTempPath());
                    tempcount.Text = FormatByteSize(GetDirectorySize2(di));
                    }));
                    //File.AppendAllText("res.tmp", createresult);
                }
            }, null);
           
        }

        private void recount_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using ComponentFactory.Krypton.Toolkit;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using Microsoft.Win32;
namespace WindowsFormsApplication3
{
    public partial class ReplaysPacker : KryptonForm
    {
        public ReplaysPacker()
        {
            InitializeComponent();
            this.TopMost = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private string _recpacker = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\RecPacker-" + DateTime.Now.ToString(@"MM\-dd\-yyyy") + rndstr(8) + "\\";
        private static Random random = new Random();
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void ReplaysPacker_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
        }
        public static string rndstr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void reclistpacker_DragDrop(object sender, DragEventArgs e)
        {
            try
            {

                //string[] recs = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                //KryptonMessageBox.Show("Rec: " + recs[0], "Message!");

                //rec files
                if (e.Data.GetData(DataFormats.FileDrop, false) != null)
                {
                    

                    try
                    {
                        string[] recs = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                        progressBar2.Visible = true;

                        //string csaffix = rndstr(8);
                        //string customdir = "CustomReplays_" + csaffix;
                        //string customfullpath = System.IO.Path.GetTempPath() + @"hdtotc-tmp\savegametmp\" + customdir;
                        //bool saverectmp = System.IO.Directory.Exists(customfullpath);

                        //if (!saverectmp)
                        //{
                        //    System.IO.Directory.CreateDirectory(customfullpath);
                        //}

                        //progressBar2.Value = 0;

                        foreach (string rec in recs)
                        {

                            //progressBar2.Value += progressBar2.Value / recs.Count(); 
                            string _recfln = Path.GetFileName(rec);
                            File.Copy(rec, _recpacker + _recfln);
                        }

                        //
                        if (recs.Count() == 1)
                        {
                            string grabrecn = _recpacker;
                            reclistpackerz.Items.Clear();
                            ListLoad(grabrecn);
                            repcount.Text = DirCount(_recpacker);
                            recsize.Text = FormatByteSize(GetDirectorySize(_recpacker));
                        }
                        else if (recs.Count() > 1)
                        {
                            string grabrecn = _recpacker;
                            reclistpackerz.Items.Clear();
                            ListLoad(grabrecn);
                            repcount.Text = DirCount(_recpacker);
                            recsize.Text = FormatByteSize(GetDirectorySize(_recpacker));
                        }

                    }
                    catch (Exception fg)
                    { throw fg; }
                    //KryptonMessageBox.Show("Rec: " + recs[0], "Message!");
                }


                                    //mgz or mgx raw files
                else if (e.Data.GetData(DataFormats.Text).ToString().EndsWith(".mgz"))
                {



                    Recgrabraw(e.Data.GetData(DataFormats.Text).ToString(), ".mgz");




                    //KryptonMessageBox.Show("Success Rec Download: " + e.Data.GetData(DataFormats.Text).ToString(), "Message!");
                }
                else if (e.Data.GetData(DataFormats.Text).ToString().EndsWith(".mgx"))
                {



                    Recgrabraw(e.Data.GetData(DataFormats.Text).ToString(), ".mgx");




                    //KryptonMessageBox.Show("Success Rec Download: " + e.Data.GetData(DataFormats.Text).ToString(), "Message!");
                }

                else if (e.Data.GetData(DataFormats.Text).ToString().StartsWith("http") || e.Data.GetData(DataFormats.Text).ToString().StartsWith("https"))
                {
                    if (e.Data.GetData(DataFormats.Text).ToString().Contains("aoezone.net") || e.Data.GetData(DataFormats.Text).ToString().Contains("aoczone.net"))
                    {

                        KryptonMessageBox.Show("AoEZone Do Not Allow Remote Download Yet! \n You can download the replay(s) manually and drop them here Instead.", "Message!");
                    }
                    else
                    {
                        Recgrab(e.Data.GetData(DataFormats.Text).ToString());
                    }


                    //KryptonMessageBox.Show("Success Rec Download: " + e.Data.GetData(DataFormats.Text).ToString(), "Message!");
                }


            }
            catch (Exception op)
            { throw op; }
        }
        public void Recgrab(string reclink)
        {

            //Start
            progressBar2.Visible = true;

            try
            {
                bool saverectmp = System.IO.Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp");

                if (!saverectmp)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp");
                }
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string zipflx = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\RecBase.zip";
                WebClient webClient = new WebClient();
                //webClient.Headers.Add("User-Agent: Other"); 
                //webClient.Headers.Add("Content-Type", "application/zip");
                //webClient.UseDefaultCredentials = true;
                //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                //webClient.Headers.Add(HttpRequestHeader.UserAgent, "AoE2Tools");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadFileAsync(new Uri(reclink), zipflx);
            }
            catch (Exception fg)
            { throw fg; }
            //end
        }
        public void Recgrabraw(string reclink, string ver)
        {

            //Start
            progressBar2.Visible = true;

            try
            {
                bool saverectmp = System.IO.Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp");

                if (!saverectmp)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp");
                }
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //string zipflx = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\RecBase.mgx";
                WebClient webClient = new WebClient();
                //get filename

                //var data = webClient.DownloadData(reclink);
                //string fileName7 = "";

                //// Try to extract the filename from the Content-Disposition header
                //if (!String.IsNullOrEmpty(webClient.ResponseHeaders["Content-Disposition"]))
                //{
                //    fileName7 = webClient.ResponseHeaders["Content-Disposition"].Substring(webClient.ResponseHeaders["Content-Disposition"].IndexOf("filename=") + 9).Replace("\"", "");
                //}

                string zipflx = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec.mg";
                //webClient.Headers.Add("User-Agent: Other"); 
                //webClient.Headers.Add("Content-Type", "application/zip");
                //webClient.UseDefaultCredentials = true;
                //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                //webClient.Headers.Add(HttpRequestHeader.UserAgent, "AoE2Tools");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed2);
                webClient.DownloadFileAsync(new Uri(reclink), zipflx);


            }
            catch (Exception fg)
            { throw fg; }
            //end
        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            progressBar2.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar2.Value = (int)e.BytesReceived / 100;

        }
                private void Completed2(object sender, AsyncCompletedEventArgs e)
        {
            progressBar2.Visible = false;
            string saffix2 = rndstr(8);
            string recfl = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec.mg";
            //string originfln = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix + @"\watch_saffix.mgz";
            //if (!Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix2))
            //{
            //    System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix);
            //}
            File.Move(recfl, _recpacker + "replay-" + saffix2 + ".mgz");
            //string grabrecn = originfln;
            reclistpackerz.Items.Clear();
            repcount.Text = DirCount(_recpacker);
            recsize.Text = FormatByteSize(GetDirectorySize(_recpacker));
            FormatByteSize(GetDirectorySize(_recpacker));
            ListLoad(_recpacker);
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            progressBar2.Value = 0;
            //getaoe2path.Text + "\\SaveGame\\"
            string zipfl = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\RecBase.zip";
            string recfl = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\RecBase.mg";
            string sdate = DateTime.Now.ToString(@"MM\-dd\-yyyy h\-mm");
            string saffix = rndstr(8);
            //string zipflvv = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Replay_" + sdate + "-" + saffix + ".zip";

            
            //Thread.Sleep(5000);
            //KryptonMessageBox.Show("File count: " + ZipFileCount(zipfl), "FileMgxz: " + ZipFileMgxz(zipfl));
            //KryptonMessageBox.Show("File Ex: " + ZipFileex(zipfl).ToString(), "FileMgxz: ");
            if (ZipFileCount(zipfl) == 1 && ZipFileMgxz(zipfl) == 999 && Ionic.Zip.ZipFile.CheckZip(zipfl) == true)
            {
                //Decompress

                Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipfl);
                int zl = 0;

                foreach (ZipEntry es in zip)
                {
                    zl++;

                    //progressBar2.Value += zl / 100;
                    es.Extract(_recpacker, ExtractExistingFileAction.OverwriteSilently);

                    //backgroundWorker3.ReportProgress(zl++);

                }
                //Prompt rename
                //mgx
                if (ZipFileex(zipfl) == 1)
                {
                    string grabrecn = _recpacker;
                    reclistpackerz.Items.Clear();
                    ListLoad(grabrecn);
                    repcount.Text = DirCount(_recpacker);
                    recsize.Text = FormatByteSize(GetDirectorySize(_recpacker));
                }
                //mgz
                else if (ZipFileex(zipfl) == 2)
                {
                    string grabrecn = _recpacker;
                    reclistpackerz.Items.Clear();
                    ListLoad(grabrecn);
                    repcount.Text = DirCount(_recpacker);
                    recsize.Text = FormatByteSize(GetDirectorySize(_recpacker));
                }

            }
            else if (ZipFileCount(zipfl) > 1 && ZipFileMgxz(zipfl) == 999 && Ionic.Zip.ZipFile.CheckZip(zipfl) == true)
            {
                //Decompress
                string rplepath = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\ReplayPack_" + sdate + "-" + saffix;
                Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipfl);
                int zm = 0;

                foreach (ZipEntry es in zip)
                {
                    zm++;

                    //progressBar2.Value += zl / 100;
                    es.Extract(rplepath, ExtractExistingFileAction.OverwriteSilently);

                    // =====>  backgroundWorker3.ReportProgress(zm++);

                }
                //Prompt list rename
                //mgx or mgz pack
                if (ZipFileex(zipfl) >= 1 && ZipFileMgxz(zipfl) == 999)
                {
                    string grabrecdir = rplepath;
                    reclistpackerz.Items.Clear();
                    ListLoad(grabrecdir);
                    repcount.Text = DirCount(_recpacker);
                    recsize.Text = FormatByteSize(GetDirectorySize(_recpacker));
                    //recprmt.RecCount = ZipFileCount(zipfl);

                }
            }

            else
            {
                KryptonMessageBox.Show("Do not contain any .mgz or mgx!", "Rejected!");
            }

            //this.Close();
        }
        public static int ZipFileCount(String zipFileName)
        {

            using (ZipArchive archive = System.IO.Compression.ZipFile.Open(zipFileName, ZipArchiveMode.Read))
            {
                int count = 0;

                // We count only named (i.e. that are with files) entries
                foreach (var entry in archive.Entries)
                    if (!String.IsNullOrEmpty(entry.Name))
                        count += 1;

                return count;
            }
        }

        public static int ZipFileMgxz(String zipFileName)
        {
            using (ZipArchive archive = System.IO.Compression.ZipFile.Open(zipFileName, ZipArchiveMode.Read))
            {

                int count = 0;
                // We count only named (i.e. that are with files) entries
                foreach (var entry in archive.Entries)
                    if (entry.Name.EndsWith(".mgx") || entry.Name.EndsWith(".mgz"))
                        count = 999;

                return count;
            }
        }

        //zip fl ext
        public static int ZipFileex(String zipFileName)
        {
            try
            {
                using (ZipArchive archive = System.IO.Compression.ZipFile.Open(zipFileName, ZipArchiveMode.Read))
                {

                    int count = 0;
                    // We count only named (i.e. that are with files) entries
                    foreach (var entry in archive.Entries)

                        // We count only named (i.e. that are with files) entries
                        if (entry.Name.ToString().EndsWith(".mgx"))
                        {
                            count = 1;
                        }
                        else if (entry.Name.ToString().EndsWith(".mgz"))
                        {
                            count = 2;
                        }

                    return count;
                }
            }
            catch (Exception gjk)
            {
                throw gjk;
            }

        }
        public void ListLoad(string recsdir)
        {
            DirectoryInfo info = new DirectoryInfo(recsdir);
            FileInfo[] files = info.GetFiles("*").OrderByDescending(p => p.CreationTime).ToArray();
            int idc = 0;
            foreach (FileInfo file in files)
            {
                idc++;
                string _itemrec = file.ToString();
                //if (!_itemrec.Contains(".mgz") || !_itemrec.Contains(".mgx"))
                //{
                //    continue;
                //}
                //else if (_itemrec.Contains(".mgx"))
                //{

                //}
                reclistpackerz.Items.Add(CreateNewItem(file.ToString()));
            }
        }
        private object CreateNewItem(string fln)
        {
            KryptonListItem item = new KryptonListItem();
            //item.ShortText = "Item " + (_next++).ToString();
            item.ShortText = fln;
            //if (item.ShortText.ToString().Contains(".mgz"))
            //{
            //    item.LongText = "(" + "mgz" + ")";
            //}
            //else if (item.ShortText.ToString().Contains(".mgx"))
            //{
            //    item.LongText = "(" + "mgx" + ")";
            //}
            
            item.Image = imageList.Images[0];
            return item;
        }

        private void reclistpackerz_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void renametxt_Click(object sender, EventArgs e)
        {
            if (reclistpackerz.SelectedIndex >= 0)
            {

                string currentpath = _recpacker + recfield.Text + label2.Text;
                string oldpath = _recpacker + "\\" + reclistpackerz.SelectedItem; 
               
                if (currentpath != oldpath)
                {
                    int _idx = reclistpackerz.SelectedIndex;
                    System.IO.File.Move(oldpath, currentpath);
                    reclistpackerz.Items.Clear();

                    //reclistpack.Items[reclistpack.SelectedIndex] = recfield.Text + label1.Text;
                    ListLoad(_recpacker);

                    reclistpackerz.SelectedIndex = _idx;

                }
                //remember old name
                oldfilen.Text = recfield.Text;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            if (!Directory.Exists(_recpacker))
            {
                Directory.CreateDirectory(_recpacker);
            }
        }

        private void reclistpackerz_SelectedIndexChanged(object sender, EventArgs e)
        {
            //label2.Text = reclistpackerz.SelectedValue.Substring(Math.Max(0, reclistpackerz.SelectedItem.Length - 4));
        }

        private void recfield_TextChanged(object sender, EventArgs e)
        {
            if (recfield.Text.Contains(".mgz"))
            {
                recfield.Text = recfield.Text.Remove(recfield.Text.Length - 4);
                label2.Text = ".mgz";
            }
            else if (recfield.Text.Contains(".mgx"))
            {
                recfield.Text = recfield.Text.Remove(recfield.Text.Length - 4);
                label2.Text = ".mgx";
            }
        }

        private void reclistpackerz_SelectedValueChanged(object sender, EventArgs e)
        {
            if (reclistpackerz.SelectedIndex >= 0)
            {
                recfield.Text = reclistpackerz.GetItemText(reclistpackerz.SelectedItem);
                oldfilen.Text = reclistpackerz.GetItemText(reclistpackerz.SelectedItem);
                recfield.SelectAll();
                recfield.Focus();
                //
                string[] getfln = Directory.GetFiles(_recpacker, "*", SearchOption.AllDirectories);
                foreach (string file in getfln)
                {

                    label1.Text = Path.GetFileName(file).Substring(Math.Max(0, Path.GetFileName(file).Length - 4));
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (reclistpackerz.SelectedIndex >= 0)
            {
                int index = reclistpackerz.SelectedIndex;
                if (index == (reclistpackerz.Items.Count - 1))
                    index--;
                reclistpackerz.Items.RemoveAt(reclistpackerz.SelectedIndex);
                KryptonMessageBox.Show(_recpacker + recfield.Text + label2.Text);
                File.Delete(_recpacker + recfield.Text + label2.Text);
                repcount.Text = DirCount(_recpacker);
                recsize.Text = FormatByteSize(GetDirectorySize(_recpacker));
                if (index < reclistpackerz.Items.Count)
                {
                    reclistpackerz.SelectedIndex = index;
                }
                    
                
            }

        }

        private void clearall_Click(object sender, EventArgs e)
        {
            reclistpackerz.Items.Clear();
            System.IO.DirectoryInfo di = new DirectoryInfo(_recpacker);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            repcount.Text = DirCount(_recpacker);
            recsize.Text = FormatByteSize(GetDirectorySize(_recpacker));
        }
        private static string FormatByteSize(double bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "TB" };
            int index = 0;
            do { bytes /= 1024; index++; }
            while (bytes >= 1024);
            return String.Format("{0:0.00} {1}", bytes, Suffix[index]);

        }

        static long GetDirectorySize(string p)
        {
            string[] a = Directory.GetFiles(p, "*.*");
            long b = 0;
            foreach (string name in a)
            {
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            return b;
        }
        static string DirCount(string sourcedir)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(sourcedir);
            int count = dir.GetFiles().Length;
            string scount = count.ToString();
            return scount;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (repcount.Text != "0")
            {
                // Show the FolderBrowserDialog.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Archive Zip|*.Zip";
                saveFileDialog1.Title = "Save Zip File To";
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (saveFileDialog1.FileName != "")
                {
                    backgroundWorker2.RunWorkerAsync();


                    String DirectoryToZip = _recpacker;
                    String ZipFileToCreate = saveFileDialog1.FileName;

                    using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                    {
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                        zip.SaveProgress += SaveProgress;

                        zip.StatusMessageTextWriter = System.Console.Out;
                        zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                        zip.Save(ZipFileToCreate);
                    }

                    FileInfo sizez = new FileInfo(saveFileDialog1.FileName);
                    KryptonMessageBox.Show("ReplayPack Size: " + FormatByteSize(sizez.Length), "Success");
                }
                else
                {

                }
                //compression
            }
            else
            {
                KryptonMessageBox.Show("Add Recorded Games First!","Dad Gum!");
            }   
           



     
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {


            //
            //using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
            //{
            //    string[] files = Directory.GetFiles(_recpacker, "*.*");
            //    int cntf = files.Length;

            //    int val = (100 - progressBar2.Value) / files.Length;
            //    int _if = 0;
                
              
            //    foreach (string f in files)
            //    {
            //       _if++;
            //        //BeginInvoke((MethodInvoker)delegate
            //        //{

                    
            //        //});

            //       BeginInvoke((MethodInvoker)delegate
            //       {
            //           progressBar2.Value = _if;

            //       });
            //        FileInfo info = new FileInfo(f);
            //        zip.AddFile(info.FullName, "");
            //        //backgroundWorker2.ReportProgress(_if);

            //    }
            //    FileInfo sizez = new FileInfo(@"C:\Users\Greg\Desktop\ReplaysPack.zip");
            //    zip.Save(@"C:\Users\Greg\Desktop\ReplaysPack.zip");
            //    //BeginInvoke((MethodInvoker)delegate
            //    //{
            //    //progressBar2.Value = Int32.Parse(repcount.Text);

            //    //});
                
            //    KryptonMessageBox.Show("ReplayPack Size: " + FormatByteSize(sizez.Length), "Success");
            
        
        
        }



      

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = progressBar2.Value / Int32.Parse(repcount.Text);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar2.Value = 0;
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
                progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                //KryptonMessageBox.Show("Done: " + e.ArchiveName);
            }
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


                groupBox2.Text = res_man.GetString("_dragandropreplays", cul);
                kryptonLabel1.Text = res_man.GetString("_replays", cul);
                kryptonLabel2.Text = res_man.GetString("_totalsize", cul);
                kryptonLabel5.Text = res_man.GetString("_renamerec", cul);
                renametxt.Text = res_man.GetString("_renameselected", cul);

                groupBox1.Text = res_man.GetString("_actions", cul);
                kryptonButton2.Text = res_man.GetString("_packall", cul);
                kryptonButton1.Text = res_man.GetString("_clearthis", cul);
                clearall.Text = res_man.GetString("_clearall", cul);
                ReplaysPacker.ActiveForm.Text = res_man.GetString("_replaypackertitle", cul);

            });
        }

        
    }
}

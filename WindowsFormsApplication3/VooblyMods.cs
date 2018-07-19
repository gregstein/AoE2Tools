using ComponentFactory.Krypton.Toolkit;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
namespace WindowsFormsApplication3
{
    public partial class VooblyMods : KryptonForm
    {
        public VooblyMods()
        {
            InitializeComponent();
            
        }

        private void VooblyMods_Load(object sender, EventArgs e)
        {

            

            backgroundWorker1.RunWorkerAsync();

            //GetMods();
            
        }
        private object CreateNewItem(string voobdir)
        {
            KryptonListItem item = new KryptonListItem();
            item.ShortText = voobdir;
            //item.LongText = "(" + _rand.Next(Int32.MaxValue).ToString() + ")";
            item.Image = imageList.Images[0];
            return item;
        }
        public void getpath()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {

                        mskdwk.Text = aoe2path;


                    }
                }
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            getpath();

            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                ReloadGamePatches();
                ReloadDataMods();
                ReloadList();
                }
                catch(SystemException)
                {

                }
       
            });

        }

        //public void GetMods()
        //{
        //    string urlAddress = "https://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors/Game-Mods/gamemods/browse2/13/1";

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        Stream receiveStream = response.GetResponseStream();
        //        StreamReader readStream = null;

        //        if (response.CharacterSet == null)
        //        {
        //            readStream = new StreamReader(receiveStream);
        //        }
        //        else
        //        {
        //            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
        //        }

        //        string data = readStream.ReadToEnd();
        //        response.Close();
        //        readStream.Close();


        //        //Regex regex = new Regex("location.href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase);

        //       //string GetM = Regex.Match(data, "<a href=\"https://voobly.com/gamemods/mod(.*?)>(.*?)</a>", RegexOptions.IgnoreCase).Groups[0].Value;
                             
        //        //string pattern = "<a href=\"https://voobly.com/gamemods/mod(.*?)>(.*?)</a>";
        //        string pattern = "(?s)<tr bgcolor=white valign=top(.*?)</tr>";
        //        Regex rgx = new Regex(pattern);
        //        //File.WriteAllText("mods.txt", data.Replace("\r\n", " "));
        //        //Process.Start("mods.txt");
        //        //string data2 = data.Replace(Environment.NewLine, " ");

        //        int id = 0;
        //        PictureBox[] thum = new PictureBox[118];
        //        Label[] titl = new Label[118];
        //        Panel[] inpanel = new Panel[118];
        //        TextBox[] desc = new TextBox[118];
        //        //pictureBox2.ImageLocation = "https://www.voobly.com/files/view/25372188/6u7v2cuni3gi67eswr2osdrfq0hnxcuu";
        //        foreach (Match match in rgx.Matches(data))
        //        {
        //            id++;
                    
        //            string Getimg = Regex.Match(match.Value, "<img src=\"(.*?)\"", RegexOptions.IgnoreCase).Groups[1].Value;
        //            string GetTitle = Regex.Match(match.Value, "<div class=\"streamgame-title\"><a href=\"https://voobly.com/gamemods/mod(.*?)>(.*?)</a>", RegexOptions.IgnoreCase).Groups[2].Value;
        //            string GetDesc = Regex.Match(match.Value, "<div class=\"streamgame-body\">(.*?)</div><div class=\"streamgame-user\">(.*?)</div>(.*?)</div>", RegexOptions.IgnoreCase).Groups[3].Value;
        //            string GetAuth = Regex.Match(match.Value, "<div class=\"streamgame-body\">(.*?)</div><div class=\"streamgame-user\">(.*?)</div>(.*?)</div>", RegexOptions.IgnoreCase).Groups[2].Value;
        //            string GetLink = Regex.Match(match.Value, "<div class=\"streamgame-title\"><a href=\"(.*?)>(.*?)</a>", RegexOptions.IgnoreCase).Groups[1].Value;
        //            //KryptonMessageBox.Show(GetDesc, "");
        //            thum[id] = new PictureBox();
        //            inpanel[id] = new Panel();
        //            inpanel[id].Name = "flw" + id;
        //            inpanel[id].Location = new Point(3, 0);
        //            inpanel[id].Size = new Size(317, 122);
        //            inpanel[id].Dock = DockStyle.Top;
        //            panel2.Controls.Add(inpanel[id]);
        //            thum[id].ImageLocation = "https://www.voobly.com" + Getimg;
        //            thum[id].Size = new Size(150, 113);
        //            inpanel[id].Controls.Add(thum[id]);

        //            titl[id] = new Label();
        //            titl[id].Text = GetTitle;
        //            titl[id].Name = "titln" + id;
        //            titl[id].BringToFront();
        //            titl[id].Location = new Point(170, 0);
        //            inpanel[id].Controls.Add(titl[id]);


        //            desc[id] = new TextBox()
        //            {
        //                Multiline = true,
        //                ScrollBars = ScrollBars.Vertical
        //            };
        //            //desc[id].Multiline = true;
        //            desc[id].ReadOnly = true;
        //            desc[id].Size = new Size(180, 70);
    
        //            desc[id].Text = GetDesc.Replace("\n"," ");
        //            desc[id].Name = "descn" + id;
        //            desc[id].BringToFront();
        //            desc[id].Location = new Point(170, 25);
        //            inpanel[id].Controls.Add(desc[id]);
        //            if(id == 5)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}


        private string ReplaceElements(string html)
        {
            string patten = @"<\s*div[^>]*>(.*?)<\s*/div\s*>";
            string wrapper = @"<div class=""Highlighter"">{0}</div>";
            MatchCollection collection = Regex.Matches(html, patten);
            foreach (Match match in collection)
            {
                string value = match.Value;
                int marker = value.IndexOf(">");
                string innterHtml = value.Substring(marker + 1, value.Length - (marker + 7));
                if (Regex.Match(innterHtml, patten).Success)
                    innterHtml = this.ReplaceElements(innterHtml);
                string wrappedText = string.Format(wrapper, innterHtml);
                string modifiedValue = value.Replace(innterHtml, wrappedText);
                html = html.Replace(value, modifiedValue);
            }
            return html;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delmod_Click(object sender, EventArgs e)
        {
             if (chkboxvoob.SelectedIndex >= 0 || chkboxvoob.CheckedItems.Count >= 0)
                {
            var confirmResult = KryptonMessageBox.Show("Delete selected mods??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                
               
                    foreach (var mod in chkboxvoob.CheckedItems)
                    {

                        Directory.Delete(mskdwk.Text + @"\Voobly Mods\AOC\Local Mods\" + mod, true);
                        //KryptonMessageBox.Show(mod.ToString(), "");


                        // Remove entry


                        //Directory.Delete(mskdwk.Text + @"\Voobly Mods\AOC\Local Mods\" + chkboxvoob.SelectedItem,true);

                    }
                 chkboxvoob.Items.Clear();
                ReloadList(); 
            }
              
            }
            else
            {
              KryptonMessageBox.Show("Check At Least a Mod To Delete", "No Mod Is Checked!");
            }
        

                
        }
        public void ReloadList()
        {
            modscount.Text = "0";
            chkboxvoob.Items.Clear();
            //listing directories
            if (!Directory.Exists(mskdwk.Text + @"\Voobly Mods\AOC\Local Mods"))
            {
                label1.Text = "Installed Visual Mods (Personal Taste)";
                modscount.Text = "0";
            }
            else
            {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(mskdwk.Text + @"\Voobly Mods\AOC\Local Mods");

            System.IO.DirectoryInfo[] dirInfos = di.GetDirectories("*.*");
            label1.Text = "Installed Visual Mods (Personal Taste)";
            int getcount = 0;
            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                getcount++;
                int totalcount = getcount;  
                modscount.Text = totalcount.ToString();
                //KryptonMessageBox.Show(d.Name, "");
                chkboxvoob.Items.Add(CreateNewItem(d.Name));
            }
            }
           

        }

        public void ReloadDataMods()
        {
            modscount.Text = "0";
            datamods.Items.Clear();
            if (!Directory.Exists(mskdwk.Text + @"\Voobly Mods\AOC\Data Mods"))
            {
                label1.Text = "Installed Data Mods (Everyone In The Game Room Must have! In order To Use)";
                modscount.Text = "0";
            }
            else
            {
            //listing directories
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(mskdwk.Text + @"\Voobly Mods\AOC\Data Mods");

            System.IO.DirectoryInfo[] dirInfos = di.GetDirectories("*.*");
            int getcount = 0;
            label1.Text = "Installed Data Mods (Everyone In The Game Room Must have! In order To Use)";
            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                getcount++;
                int totalcount = getcount;
                modscount.Text = totalcount.ToString();
                //KryptonMessageBox.Show(d.Name, "");
                datamods.Items.Add(CreateNewItem(d.Name));
            }

            }


        }

        public void ReloadGamePatches()
        {
            modscount.Text = "0";
            gamepatches.Items.Clear();
            if (!Directory.Exists(mskdwk.Text + @"\Voobly Mods\AOC\Patches"))
            {
                label1.Text = "Installed Game Patches (Change/Fix Game Bugs - Latest Patch is Recommended)";
                modscount.Text = "0";
            }
            else
            {
            //listing directories
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(mskdwk.Text + @"\Voobly Mods\AOC\Patches");

            System.IO.DirectoryInfo[] dirInfos = di.GetDirectories("*.*");
            label1.Text = "Installed Game Patches (Change/Fix Game Bugs - Latest Patch is Recommended)";
            int getcount = 0;
            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                getcount++;
                int totalcount = getcount;
                modscount.Text = totalcount.ToString();
                //KryptonMessageBox.Show(d.Name, "");
                gamepatches.Items.Add(CreateNewItem(d.Name));
            }
            }


        }

        private void vooblymodscenter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors/Game-Mods/gamemods/browse2/13/1");
        }

        private void galasmodscenter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Process.Start("https://www.voobly.com/pages/view/1355/Gallas-Mod-Workshop");
        }

        private void kryptonPage3_Click(object sender, EventArgs e)
        {
            
        }

        private void kryptonPage3_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void kryptonPage3_Load(object sender, EventArgs e)
        {
            
        }

        private void kryptonPage3_Initialized(object sender, EventArgs e)
        {
            
        }

        private void kryptonDockableNavigator1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (kryptonDockableNavigator1.SelectedPage == kryptonPage1)
            {
                ReloadList();
            }
            else if (kryptonDockableNavigator1.SelectedPage == kryptonPage2)
            {
                ReloadDataMods();
            }
            else if (kryptonDockableNavigator1.SelectedPage == kryptonPage3)
            {
                ReloadGamePatches();
            }
            selectdata.Checked = false;
            selectpatches.Checked = false;
            selectvisual.Checked = false;
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (datamods.SelectedIndex >= 0)
            {

                var confirmResult = KryptonMessageBox.Show("Delete selected mods??",
                                        "Confirm Delete!!",
                                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // If 'Yes', do something here.

                    foreach (var mod in datamods.CheckedItems)
                    {

                        Directory.Delete(mskdwk.Text + @"\Voobly Mods\AOC\Data Mods\" + mod, true);
                        //KryptonMessageBox.Show(mod.ToString(), "");


                        // Remove entry


                        //Directory.Delete(mskdwk.Text + @"\Voobly Mods\AOC\Local Mods\" + chkboxvoob.SelectedItem,true);

                    }

                    datamods.Items.Clear();
                    ReloadDataMods();
                }
                else
                {
                    // If 'No', do something here.
                }
                
            }
            else
            {
                KryptonMessageBox.Show("Check At Least a Mod To Delete", "No Mod Is Checked!");
            }
          
        }

        private void delpatch_Click(object sender, EventArgs e)
        {
if (gamepatches.SelectedIndex >= 0)
                {
            var confirmResult = KryptonMessageBox.Show("Delete selected mods??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                
                    foreach (var mod in gamepatches.CheckedItems)
                    {

                        Directory.Delete(mskdwk.Text + @"\Voobly Mods\AOC\Patches\" + mod, true);
                        //KryptonMessageBox.Show(mod.ToString(), "");


                        // Remove entry


                        //Directory.Delete(mskdwk.Text + @"\Voobly Mods\AOC\Local Mods\" + chkboxvoob.SelectedItem,true);

                    }                
                gamepatches.Items.Clear();
                ReloadGamePatches();
                }

             else
            {
                // If 'No', do something here.
            } 
}
          
else {
    KryptonMessageBox.Show("Check At Least a Mod To Delete", "No Mod Is Checked!");
}
        }

        private void selectvisual_CheckedChanged(object sender, EventArgs e)
        {
            if(selectvisual.Checked == true)
            {
                for (int i = 0; i < chkboxvoob.Items.Count; i++)
{
    chkboxvoob.SetItemChecked(i, true);
}
              
            }
            else if (selectvisual.Checked == false)
            {
                ReloadList();
                for (int i = 0; i < chkboxvoob.Items.Count; i++)
                {
                    chkboxvoob.SetItemChecked(i, false);
                }
            }
        }

        private void selectdata_CheckedChanged(object sender, EventArgs e)
        {
            if (selectdata.Checked == true)
            {
                for (int i = 0; i < datamods.Items.Count; i++)
                {
                    datamods.SetItemChecked(i, true);
                }
          
            }
            else if (selectdata.Checked == false)
            {
                ReloadDataMods();
                for (int i = 0; i < datamods.Items.Count; i++)
                {
                    datamods.SetItemChecked(i, false);
                }
            }
        }

        private void selectpatches_CheckedChanged(object sender, EventArgs e)
        {
            if (selectpatches.Checked == true)
            {
                for (int i = 0; i < gamepatches.Items.Count; i++)
                {
                    gamepatches.SetItemChecked(i, true);
                }
         
            }
            else if (selectpatches.Checked == false)
            {
                ReloadGamePatches();
                for (int i = 0; i < gamepatches.Items.Count; i++)
                {
                    gamepatches.SetItemChecked(i, false);
                }
            }
        }



        public void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                //KryptonMessageBox.Show("Begin Saving: " + e.ArchiveName);
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry || e.EventType == ZipProgressEventType.Extracting_BeforeExtractAll)
            {
                //labelCompressionStatus.Text = "Writing: " + e.CurrentEntry.FileName + " (" + (e.EntriesSaved + 1) + "/" + e.EntriesTotal + ")";
                //labelFilename.Text = "Filename:" + e.CurrentEntry.LocalFileName;

                progressBar2.Maximum = e.EntriesTotal;
                progressBar2.Value = e.EntriesSaved + 1;
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead || e.EventType == ZipProgressEventType.Extracting_AfterExtractEntry)
            {
                progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed || e.EventType == ZipProgressEventType.Extracting_AfterExtractAll)
            {
                //KryptonMessageBox.Show("Done: " + e.ArchiveName);
                progressBar1.Value = 0;
                progressBar2.Value = 0;
            }
        }

        private static string FormatByteSize(double bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "TB" };
            int index = 0;
            do { bytes /= 1024; index++; }
            while (bytes >= 1024);
            return String.Format("{0:0.00} {1}", bytes, Suffix[index]);

        }

        private void exportvisual_Click(object sender, EventArgs e)
        {
            if (chkboxvoob.SelectedIndex >= 0 || chkboxvoob.CheckedItems.Count >= 0)
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


                        
                        String ZipFileToCreate = saveFileDialog1.FileName;

                        using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                        {
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                            zip.SaveProgress += SaveProgress;

                            zip.StatusMessageTextWriter = System.Console.Out;
                            foreach (var mod in chkboxvoob.CheckedItems)
                {
                    String DirectoryToZip = mskdwk.Text + @"\Voobly Mods\AOC\Local Mods\" + mod.ToString();
                            zip.AddDirectory(DirectoryToZip, mod.ToString()); // recurses subdirectories

                }
                            zip.Save(ZipFileToCreate);
                        }


                        FileInfo sizez = new FileInfo(saveFileDialog1.FileName);
                        KryptonMessageBox.Show("Mods Size: " + FormatByteSize(sizez.Length), "Success");
                    }
                    else
                    {

                    }
                
            }




        }

        private void exportdata_Click(object sender, EventArgs e)
        {
            if (datamods.SelectedIndex >= 0 || datamods.CheckedItems.Count >= 0)
            {
                    // Show the FolderBrowserDialog.
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Archive Zip|*.Zip";
                    saveFileDialog1.Title = "Save Zip File To";
                    saveFileDialog1.ShowDialog();
                 if (saveFileDialog1.FileName != "")
                    {
                     //begin dialog
               


                    // If the file name is not an empty string open it for saving.  
                   
                        //backgroundWorker2.RunWorkerAsync();


                        
                        String ZipFileToCreate = saveFileDialog1.FileName;

                        using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                        {
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                            zip.SaveProgress += SaveProgress;

                            zip.StatusMessageTextWriter = System.Console.Out;
                            foreach (var mod in datamods.CheckedItems)
                            {
                                String DirectoryToZip = mskdwk.Text + @"\Voobly Mods\AOC\Data Mods\" + mod.ToString();
                                zip.AddDirectory(DirectoryToZip, mod.ToString()); // recurses subdirectories
                            }
                           
                            zip.Save(ZipFileToCreate);
                        }

                  
                
                FileInfo sizez = new FileInfo(saveFileDialog1.FileName);
                KryptonMessageBox.Show("Mods Size: " + FormatByteSize(sizez.Length), "Success");
                     //end dialog
                    }

                 else
                 {

                 }
            }
            
        }

        private void exportpatches_Click(object sender, EventArgs e)
        {

            if (gamepatches.SelectedIndex >= 0 || gamepatches.CheckedItems.Count >= 0)
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


                        
                        String ZipFileToCreate = saveFileDialog1.FileName;

                        using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                        {
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                            zip.SaveProgress += SaveProgress;

                            zip.StatusMessageTextWriter = System.Console.Out;
                            foreach (var mod in gamepatches.CheckedItems)
                {
                            String DirectoryToZip = mskdwk.Text + @"\Voobly Mods\AOC\Patches\" + mod.ToString();
                            zip.AddDirectory(DirectoryToZip, mod.ToString()); // recurses subdirectories

                }
                            zip.Save(ZipFileToCreate);
                        }

                        FileInfo sizez = new FileInfo(saveFileDialog1.FileName);
                        KryptonMessageBox.Show("Mods Successfully Exported!\n" + "Mods Size: " + FormatByteSize(sizez.Length), "Success");
                    }
                    else
                    {

                    }
                
            }


        }

        private void importvisual_Click(object sender, EventArgs e)
        {
                                       // Show the FolderBrowserDialog.
                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                OpenFileDialog importfile = new OpenFileDialog();
                importfile.Filter = "Archive Zip|*.Zip";
                importfile.Title = "Select Zip File To Import";
                importfile.ShowDialog();

                // If the file name is not an empty string open it for saving.  
                if (importfile.FileName != "")
                {
                    String DirectoryToZip = mskdwk.Text + @"\Voobly Mods\AOC\Local Mods\";
                    //String ZipFileToCreate = saveFileDialog1.FileName;

                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(importfile.FileName))
                    {
                        zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                        zip.SaveProgress += SaveProgress;
                        zip.ExtractAll(DirectoryToZip,
                    Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                        zip.StatusMessageTextWriter = System.Console.Out;
                        //zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                        //zip.Save(ZipFileToCreate);
                    }
                    chkboxvoob.Items.Clear();
                    ReloadList();
                    KryptonMessageBox.Show("Mods Successfully Imported!", "Success!");

                }
        }

        private void importdata_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            OpenFileDialog importfile = new OpenFileDialog();
            importfile.Filter = "Archive Zip|*.Zip";
            importfile.Title = "Select Zip File To Import";
            importfile.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (importfile.FileName != "")
            {
                String DirectoryToZip = mskdwk.Text + @"\Voobly Mods\AOC\Data Mods\";
                //String ZipFileToCreate = saveFileDialog1.FileName;

                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(importfile.FileName))
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    zip.SaveProgress += SaveProgress;
                    zip.ExtractAll(DirectoryToZip,
                Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                    zip.StatusMessageTextWriter = System.Console.Out;
                    //zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                    //zip.Save(ZipFileToCreate);
                }
                datamods.Items.Clear();
                ReloadDataMods();
                KryptonMessageBox.Show("Mods Successfully Imported!", "Success!");

            }
        }

        private void importpatches_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            OpenFileDialog importfile = new OpenFileDialog();
            importfile.Filter = "Archive Zip|*.zip";
            importfile.Title = "Select Zip File To Import";
            importfile.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (importfile.FileName != "")
            {
                String DirectoryToZip = mskdwk.Text + @"\Voobly Mods\AOC\Patches\";
                //String ZipFileToCreate = saveFileDialog1.FileName;

                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(importfile.FileName))
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    zip.SaveProgress += SaveProgress;
                    zip.ExtractAll(DirectoryToZip,
                Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                    zip.StatusMessageTextWriter = System.Console.Out;
                    //zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                    //zip.Save(ZipFileToCreate);
                }
                chkboxvoob.Items.Clear();
                ReloadList();
                KryptonMessageBox.Show("Mods Successfully Imported!", "Success!");

            }
        }

    }
}

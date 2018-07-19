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
namespace WindowsFormsApplication3
{
    public partial class Hotkeys : KryptonForm
    {
        public Hotkeys()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void Hotkeys_Load(object sender, EventArgs e)
        {
            aoepath();
        }

        private void hkilink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://aokhotkeys.appspot.com");
        }

        private void hkilink_MouseHover(object sender, EventArgs e)
        {
            ToolTip buttonToolTip2 = new ToolTip();
            buttonToolTip2.ToolTipTitle = "Click The Blue Link";
            buttonToolTip2.UseFading = true;
            buttonToolTip2.UseAnimation = true;
            buttonToolTip2.IsBalloon = true;
            buttonToolTip2.ShowAlways = true;
            buttonToolTip2.AutoPopDelay = 50000;
            buttonToolTip2.InitialDelay = 200;
            buttonToolTip2.ReshowDelay = 500;
            buttonToolTip2.SetToolTip(hkilink, "1- Open the website Hotkeys Converter. \n 2- Browse Your AOE2HD Hotkey And Click Edit File. \n 3- Choose Version \"AoC/FE/HD2.0\" And Click Generate .hki File. \n 4- Now Import This generated File");
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
                    string datebk = DateTime.Now.ToString("yyyyMMddHHmmss");
                    //if (File.Exists(saveFileDialog1.FileName + ".zip"))
                    //{
                    //    File.Move(saveFileDialog1.FileName + ".zip", backupdir + "backuphki" + datebk + ".zip");
                    //   // File.Delete(backupdir + "backuphki.zip");
                    //}

                    string[] files = System.IO.Directory.GetFiles(mskdpath.Text + "\\", "*.hki");
                    foreach (string file in files)
                    {
                        using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(saveFileDialog1.FileName, ZipArchiveMode.Update))
                        {
                            //Here are two hard-coded files that we will be adding to the zip
                            //file.  If you don't have these files in your system, this will
                            //fail.  Either create them or change the file names.  Also, note
                            //that their names are changed when they are put into the zip file.
                            modFile.CreateEntryFromFile(file, Path.GetFileName(file));

                            //We could also add the code from Example 4 here to read
                            //the contents of the open zip file as well.
                        }

                    }
                    using (ZipArchive modFile = System.IO.Compression.ZipFile.Open(saveFileDialog1.FileName + ".zip", ZipArchiveMode.Update))
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
                File.Delete(mskdpath.Text + "\\player.nfo");
                File.Delete(mskdpath.Text + "\\player.nfp");
                File.Delete(mskdpath.Text + "\\player.nfx");
                File.Delete(mskdpath.Text + "\\player.nfz");
                //String backupdir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AoE2Tools\\Hotkeys\\";
                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(importfile.FileName))
                {
              
                   // Directory.EnumerateFiles(mskdpath.Text, "*.hki").ToList().ForEach(x => File.Delete(x));

                    zip.ExtractAll(mskdpath.Text, ExtractExistingFileAction.OverwriteSilently);
                    //modFile.ExtractToDirectory(mskdpath.Text);
                    
                  
                }

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
                if (File.Exists(Directory.GetCurrentDirectory() + "\\data\\hki\\" + otherhki.Text + "\\player1.hki"))
                File.Copy(Directory.GetCurrentDirectory() + "\\data\\hki\\" + otherhki.Text + "\\player1.hki", mskdpath.Text + "\\player1.hki", true);
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

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            if(browsehkitxt.Text.Contains(".hki"))
            {
                          string[] files = System.IO.Directory.GetFiles(mskdpath.Text + "\\", "*.hki");
                          foreach (string file in files)
                          {
                              //File.Delete(file);
                              File.Copy(browsehkitxt.Text, file, true);
                              
                          }
                          KryptonMessageBox.Show("Hotkeys Successfully Imported!", "Import Success!");
            }
            else
            {
                KryptonMessageBox.Show("Not a valid hotkey file!", "Invalid Hotkey File!");
            }
        }

        private void hkilink_LinkClicked_1(object sender, EventArgs e)
        {

        }
    }
}

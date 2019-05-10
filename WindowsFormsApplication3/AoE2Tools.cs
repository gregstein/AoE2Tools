using ComponentFactory.Krypton.Toolkit;
using Ionic.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Security.Principal;
using System.Reflection;
namespace WindowsFormsApplication3
{
    
    public partial class AoE2Tools : KryptonForm
    {
        private MessageBoxIcon _mbIcon = MessageBoxIcon.Information;
        //private MessageBoxIcon _mbIcon2 = MessageBoxIcon.Warning;
        private MessageBoxButtons _mbButtons = MessageBoxButtons.OK;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        private const UInt32 BOTTOM_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


        public AoE2Tools()
        {

            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
            
          
        }
        public enum MessageFilterInfo : uint
        {
            None = 0, AlreadyAllowed = 1, AlreadyDisAllowed = 2, AllowedHigher = 3
        };

        public enum ChangeWindowMessageFilterExAction : uint
        {
            Reset = 0, Allow = 1, DisAllow = 2
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct CHANGEFILTERSTRUCT
        {
            public uint size;
            public MessageFilterInfo info;
        }
        private static Random random = new Random();
        private int filesExtracted;
        private int totalFiles;
        private void AoE2Tools_Load(object sender, EventArgs e)
        {

        }

        private void loadReplayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {

        }

        private void kryptonGroup3_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void langbox_SelectedValueChanged(object sender, EventArgs e)
        {
       
        }

        private void tauntcheck_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();
                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {
                        string tauntdir = aoe2path + "\\Taunt\\";
                        string tauntmute = aoe2path + "\\Taunt.Mute\\";
                        try { 
                        if (tauntcheck.Checked == true)
                        {
                            Directory.Move(tauntdir, tauntmute);
                             
                        }
                        else if (tauntcheck.Checked == false)
                        {
                            Directory.Move(tauntmute, tauntdir);
                        }
                            }
                        catch(Exception err)
                        { throw err; }
                    }
                }
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
              
            BasicCheck();
            if (CheckForInternetConnection() == true)
            {
                UserPatchCheck();
                Voobly_Check();
                WololoKingdom_Check();
                GameSys_Check();
            }
            
        }
        public void DirCopy(string SourcePath, string DestinationPath)
        {
            //Now Create all of the directories
            if (!Directory.Exists(DestinationPath))
            {
                Directory.CreateDirectory(DestinationPath);
            }


            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
        }
        public void BasicCheck()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();
                    
                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {
                        string tauntdir = aoe2path + "\\Taunt\\";
                        string tauntmute = aoe2path + "\\Taunt.Mute\\";
                        try
                        {
                            getaoe2path.Text = aoe2path;
                            if (Directory.Exists(tauntdir))
                            {
                                tauntcheck.Checked = false;


                            }
                            else if (Directory.Exists(tauntmute))
                            {
                                tauntcheck.Checked = true;
                            }
                        }
                        catch 
                        { }
                    }
                }
            }
        }

        private void mapsfolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {
                        mapsfolder.LinkVisited = true;

                        System.Diagnostics.Process.Start(aoe2path + "\\Random\\");
                    }
                }
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(aoe2path + "\\Ai\\");
                        }
                        catch { }
                    }
                }
            }
        }

        private void Manage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VooblyMods voobmods = new VooblyMods();
            voobmods.ShowDialog();
        }

        private void showgamefolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {

                        try
                        {
                            System.Diagnostics.Process.Start(aoe2path);
                        }
                        catch { }
                    }
                }
            }
        }

        private void openfolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(aoe2path + "\\SaveGame");
                        }
                        catch { }
                       
                    }
                }
            }
        }

        private void langbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (langbox.SelectedIndex.Equals(0))
            {
               progressBar4.Visible = true;
               Install_lang("en", "arabic");
               KryptonMessageBox.Show("Arabic Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if(langbox.SelectedIndex.Equals(1))
            {
                progressBar4.Visible = true;
                Install_lang("en", "english");
                KryptonMessageBox.Show("English Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
 
            else if (langbox.SelectedIndex.Equals(2))
            {
                progressBar4.Visible = true;
                Install_lang("en", "bulgarian");
                KryptonMessageBox.Show("Bulgarian Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(3))
            {
                progressBar4.Visible = true;
                Install_lang("zh", "chinese");
                KryptonMessageBox.Show("Chinese Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(4))
            {
                progressBar4.Visible = true;
                Install_lang("en", "czech");
                KryptonMessageBox.Show("Czech Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(5))
            {
                progressBar4.Visible = true;
                Install_lang("fr", "french");
                KryptonMessageBox.Show("French Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(6))
            {
                progressBar4.Visible = true;
                Install_lang("en", "greek");
                KryptonMessageBox.Show("Greek Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(7))
            {
                progressBar4.Visible = true;
                Install_lang("en", "hungarian");
                KryptonMessageBox.Show("Hungarian Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(8))
            {
                progressBar4.Visible = true;
                Install_lang("it", "italian");
                KryptonMessageBox.Show("Italian Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(9))
            {
                progressBar4.Visible = true;
                Install_lang("ko", "korean");
                KryptonMessageBox.Show("Korean Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(10))
            {
                progressBar4.Visible = true;
                Install_lang("es", "spanish");
                KryptonMessageBox.Show("Spanish Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(11))
            {
                progressBar4.Visible = true;
                Install_lang("br", "portuguese");
                KryptonMessageBox.Show("Portuguese Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(12))
            {
                progressBar4.Visible = true;
                Install_lang("en", "polish");
                KryptonMessageBox.Show("Polish Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }

            else if (langbox.SelectedIndex.Equals(13))
            {
                progressBar4.Visible = true;
                Install_lang("en", "slovak");
                KryptonMessageBox.Show("Slovak Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(14))
            {
                progressBar4.Visible = true;
                Install_lang("tr", "turkish");
                KryptonMessageBox.Show("Turkish Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(15))
            {
                progressBar4.Visible = true;
                Install_lang("de", "german");
                KryptonMessageBox.Show("German Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(16))
            {
                progressBar4.Visible = true;
                Install_lang("jp", "japanese");
                KryptonMessageBox.Show("Japanese Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(17))
            {
                progressBar4.Visible = true;
                Install_lang("ru", "russian");
                KryptonMessageBox.Show("Russian Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
        }

        public void Install_lang(string langstr, string zipname)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();
                    string steampath = key.GetValue("SteamPath").ToString();
        
                    if (aoe2path != null)
                    {

                        try
                        {


                            string zipPath = @"lang\" + zipname + ".zip";

                            string extractPath = aoe2path + "\\";
                            
                            if (Directory.Exists(extractPath))
                            {
                                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                                {
                                    totalFiles = zip.Count;
                                    filesExtracted = 0;
                                    zip.ExtractProgress += ZipExtractProgress;
                                    zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                                    if (filesExtracted == totalFiles - 1)
                                    {
                                        //progressBar4.Visible = false;
                                       progressBar4.Value = 0;

                                    }
                                }
                            }
                            //Sound Files
                            CopyFolder(steampath + "\\resources\\" + langstr + "\\sound\\taunt\\", extractPath + "\\Taunt\\");
                            //if (Directory.GetFiles(steampath + "\\resources\\" + langstr + "\\sound\\taunt\\", "*.mp3").Length != 0)
                            //{
                            //    DirectoryInfo di = new DirectoryInfo(steampath + "\\resources\\" + langstr + "\\sound\\taunt\\");
                            //    FileInfo[] files = di.GetFiles("*.mp3")
                            //                         .Where(p => p.Extension == ".mp3").ToArray();
                            //    totalFiles = files.Count();
                            //    progressBar2.Value = 0;
                            //    progressBar2.Minimum = 0;
                            //    progressBar2.Maximum = totalFiles;
                            //    int filecopied = 0;
                            //    foreach (FileInfo file in files)
                            //        try
                            //        {
                            //            filecopied++;
                            //            //file.Attributes = FileAttributes.Normal;
                            //            File.Copy(file.FullName, aoe2path + "\\Taunt\\", true);
                            //            progressBar2.Value = filecopied;
                            //            if(progressBar2.Value == progressBar3.Maximum)
                            //            {
                            //                progressBar2.Visible = false;
                            //            }
                                        

                            //        }
                            //        catch { }
                            //}
                            

                        }
                        catch { }
                    }
                }
            }

        }

        private void kryptonCheckButton3_Click(object sender, EventArgs e)
        {
            if (kryptonCheckButton3.Checked == true)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c" + "\"" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\perf\\mouse.exe" + "\"" + " -opt";
                    //File.WriteAllText(System.IO.Path.GetTempPath() + "\\e-m.bat", "\"" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\perf\\mouse.exe" + "\"" + " -opt");
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    //File.Delete(System.IO.Path.GetTempPath() + "\\e-m.bat");
                    KryptonMessageBox.Show("Normal Mouse Cursor Enabled!", "AoE2Tools");
                }
                catch (SystemException)
                {
                    kryptonCheckButton3.Checked = false;
                    KryptonMessageBox.Show("Cancelled..", "AoE2Tools");
                }

                //

                //myProcess.WaitForExit();

            }
            else if (kryptonCheckButton3.Checked == false)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c" + "\"" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\perf\\mouse.exe" + "\"" + " -unopt";
                    //File.WriteAllText(System.IO.Path.GetTempPath() + "\\e-m.bat", "\"" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\perf\\mouse.exe" + "\"" + " -unopt");
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    //File.Delete(System.IO.Path.GetTempPath() + "\\d-m.bat");
                    KryptonMessageBox.Show("Normal Mouse Cursor Disabled!", "AoE2Tools");
                }
                catch (SystemException)
                {
                    kryptonCheckButton3.Checked = false;
                    KryptonMessageBox.Show("Cancelled..", "AoE2Tools");
                }

            }
        }

        private void kryptonCheckButton4_Click(object sender, EventArgs e)
        {
            if (kryptonCheckButton4.Checked == true)
            {
                Microsoft.Win32.RegistryKey rkey4;
                rkey4 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                rkey4.SetValue("disabledxhwaccel", "true");
                rkey4.Close();
                MessageBox.Show("Hardware enabled For Voobly!", "AoE2Tools");
            }
            else if (kryptonCheckButton4.Checked == false)
            {

                Microsoft.Win32.RegistryKey rkey5;
                rkey5 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                rkey5.SetValue("disabledxhwaccel", "false");
                rkey5.Close();
                MessageBox.Show("Hardware Disabled For Voobly!", "AoE2Tools");

            }
        }

        //Steam Boost
        private void kryptonCheckButton5_Click(object sender, EventArgs e)
        {
            if (kryptonCheckButton5.Checked == true)
            {
                try {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c" + "\\data\\perf\\steamboost.exe\" -opt";
                    startInfo.Verb = "runas";
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
                    //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    KryptonMessageBox.Show("Boost Enabled!", "AoE2Tools");
                }
                catch (SystemException)
                {
                    kryptonCheckButton5.Checked = false;
                    KryptonMessageBox.Show("Cancelled.. Boost", "AoE2Tools");
                }

          
                
            }
            else if (kryptonCheckButton5.Checked == false)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c" + "\\data\\perf\\steamboost.exe\" -unopt";
                    startInfo.Verb = "runas";
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
                    //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    KryptonMessageBox.Show("Boost Disabled!", "AoE2 Tools");
                }
                catch (SystemException)
                {
                    kryptonCheckButton5.Checked = false;
                    KryptonMessageBox.Show("Cancelled..", "AoE2Tools");
                }

            }
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Enabled = true;
            //RemoveDirectories(System.IO.Path.GetTempPath(), "Temp");
            //BeginInvoke((MethodInvoker)delegate
            //{

                backgroundWorker2.RunWorkerAsync();
            //});
          
        }
        static long GetDirectorySize(string p)
        {
            // 1
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*");

            // 2
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4
            // Return total size
            return b;
        }

        static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
 
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //progressBar1.Value = Int32.Parse(flcnt.Text);
            progressBar1.Visible = false;
            
        }
        //Get files

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            RemoveDirectories(System.IO.Path.GetTempPath(), "Temp");
            System.Threading.Thread.Sleep(500);
            RemoveDirectories(getaoe2path.Text + "\\SaveGame\\Multi\\", "AoE2 Restores");
//             try { 
//                //CleanUp

//                var tempsize = ConvertKilobytesToMegabytes(GetDirectorySize(System.IO.Path.GetTempPath()));
//                int ftempsize = unchecked((int)tempsize);

//int fileCount = Directory.GetFiles(System.IO.Path.GetTempPath(), "*.*", SearchOption.AllDirectories).Length;
//                int fileCount2 = Directory.GetFiles(getaoe2path.Text, "*.*", SearchOption.AllDirectories).Length;
//                int flct = fileCount + fileCount2;
//                flcnt.Text = flct.ToString();
//                int dfc = 0;
//                progressBar1.Maximum = flct;
//                System.Threading.Thread.Sleep(1000);
//                foreach (string filePath in Directory.GetFiles(System.IO.Path.GetTempPath(), "*.*", SearchOption.AllDirectories))
//                {
//                    try {                    dfc++;
                    
//                    FileInfo currentFile = new FileInfo(filePath);
//                    File.SetAttributes(filePath, FileAttributes.Normal);
                   
//                    currentFile.Delete();
//                    //progressBar1.Maximum++;
//                    backgroundWorker2.ReportProgress(dfc);
//                    }
//                    catch { }


//                }
//                //Clean AoE2 Multi Folder Restores (Not SaveGame)
//                string aoe2pathtxt = getaoe2path.Text;
//                var aoe2temp = ConvertKilobytesToMegabytes(GetDirectorySize(aoe2pathtxt + "\\SaveGame\\Multi\\"));
//                int faoe2temp = unchecked((int)tempsize);
//                File.WriteAllText("var.tmp", faoe2temp.ToString());
//                int fc = 0;
//                foreach (string filePath2 in Directory.GetFiles(aoe2pathtxt + "\\SaveGame\\Multi\\", "*.*", SearchOption.AllDirectories))
//                {
//                    try {                    fc++;
//                    FileInfo currentFile2 = new FileInfo(filePath2);
                    
//                    currentFile2.Delete();
//                    //progressBar1.Maximum++;
//                    //progressBar1.Value = fc++;
//                    backgroundWorker2.ReportProgress(fc);
//                    }
//                    catch { }


//                }
//                string aoetmp = File.ReadAllText("var.tmp");
//                MessageBox.Show("CleanUp Success! \n (X)Temp Cleaned: " + ftempsize + "\n (X)AoE2 Temp Cleaned: " + aoetmp + "MB", "AoE2 Tools");
//                if (File.Exists("var.tmp"))
//                    File.Delete("var.tmp");


//             }
//             catch  {  }

        }

        private void RemoveDirectories(string strpath, string name)
        {

            ThreadPool.QueueUserWorkItem((o) =>
            {
                if (Directory.Exists(strpath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(strpath);
                    var files = dirInfo.GetFiles();
                    var pcount = ConvertKilobytesToMegabytes(GetDirectorySize(strpath)).ToString("0.00");
                    //I assume your code is inside a Form, else you need a control to do this invocation;
                    this.BeginInvoke(new Action(() =>
                    {
                        progressBar1.Minimum = 0;
                        progressBar1.Value = 0;
                        progressBar1.Maximum = files.Length;
                        progressBar1.Step = 1;
                    }));

                    foreach (FileInfo file in files)
                    {
                        try {
                            file.Delete();

                            this.BeginInvoke(new Action(() => progressBar1.PerformStep())); 
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
                        progressBar1.Value = 0;
                        progressBar1.Maximum = dirs.Length;
                    }));

                    foreach (DirectoryInfo dir in dirs)
                    {
                        //dir.Delete(true);
                        this.BeginInvoke(new Action(() => progressBar1.PerformStep())); //I assume your code is inside a Form, else you need a control to do this invocation;
                    }
                    string createresult = "CleanUp Success! \n (X)" + name + "Cleaned: "  + Environment.NewLine;

                    File.AppendAllText("res.tmp", createresult);
                }
            }, null);
        }
        //Windows Boost
        private void kryptonCheckButton2_Click(object sender, EventArgs e)
        {
            if (kryptonCheckButton2.Checked == true)
            {
                try {

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c" + "\\data\\perf\\Win Disable Unnecessary Services.exe\" -opt";
                    startInfo.Verb = "runas";
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
                    //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    MessageBox.Show("Windows Boost Enabled!", "AoE2 Tools");
                
                }
                catch (SystemException)
                {
                    kryptonCheckButton2.Checked = false;
                    MessageBox.Show("Cancelled.. Boost", "AoE2 Tools");
                }
            }
            else if (kryptonCheckButton2.Checked == false)
            {
                try {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c" + "\\data\\perf\\Win Enable Unnecessary Services.exe\" -opt";
                    startInfo.Verb = "runas";
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
                    //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    MessageBox.Show("Windows Boost Enabled!", "AoE2 Tools");
                
                }
                catch (SystemException)
                {
                    kryptonCheckButton2.Checked = false;
                    MessageBox.Show("Cancelled.. Boost", "AoE2 Tools");
                }
            }

        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            try {
                
                //string[] recs = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                //MessageBox.Show("Rec: " + recs[0], "Message!");

                //rec files
                if (e.Data.GetData(DataFormats.FileDrop, false) != null)
                {
                    

                    try
                    {
                        string[] recs = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                        progressBar2.Visible = true;

                        string csaffix = rndstr(8);
                        string customdir = "CustomReplays_" + csaffix;
                        string customfullpath = System.IO.Path.GetTempPath() + @"hdtotc-tmp\savegametmp\" + customdir;
                        bool saverectmp = System.IO.Directory.Exists(customfullpath);

                        if (!saverectmp)
                        {
                            System.IO.Directory.CreateDirectory(customfullpath);
                        }

                        //progressBar2.Value = 0;

                       foreach(string rec in recs)
                       {
                           
                           //progressBar2.Value += progressBar2.Value / recs.Count(); 
                           string _recfln = Path.GetFileName(rec);
                           File.Copy(rec, System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + customdir + "\\" + _recfln);
                       }
                        
                        //
                        if(recs.Count() == 1)
                        {
                            //string grabrecn = customfullpath;   
                            //RecPrompt recprmt = new RecPrompt();
                            //recprmt.MyProperty = grabrecn;
                            //recprmt.GameVersion = gamever.Text;
                            //recprmt.Show();
                            string grabrecdir = customfullpath;
                            string singlerecdir = customdir;
                            RecPackList recprmt = new RecPackList();
                            recprmt.MyProperty = grabrecdir;
                            recprmt.RecCount = recs.Count();
                            recprmt.SingleDir = singlerecdir;
                            recprmt.GameVersion = gamever.Text;
                            recprmt.Show();
                        }
                        else if (recs.Count() > 1)
                        {
                            string grabrecdir = customfullpath;
                            string singlerecdir = customdir;
                            RecPackList recprmt = new RecPackList();
                            recprmt.MyProperty = grabrecdir;
                            recprmt.RecCount = recs.Count();
                            recprmt.SingleDir = singlerecdir;
                            recprmt.GameVersion = gamever.Text;
                            recprmt.Show();
                        }

                    }
                    catch (Exception fg)
                    { throw fg; }
                    //MessageBox.Show("Rec: " + recs[0], "Message!");
                }


                                    //mgz or mgx raw files
                else if (e.Data.GetData(DataFormats.Text).ToString().EndsWith(".mgz"))
                {



                    Recgrabraw(e.Data.GetData(DataFormats.Text).ToString(), ".mgz");




                    //MessageBox.Show("Success Rec Download: " + e.Data.GetData(DataFormats.Text).ToString(), "Message!");
                }
                else if (e.Data.GetData(DataFormats.Text).ToString().EndsWith(".mgx"))
                {



                    Recgrabraw(e.Data.GetData(DataFormats.Text).ToString(), ".mgx");




                    //MessageBox.Show("Success Rec Download: " + e.Data.GetData(DataFormats.Text).ToString(), "Message!");
                }

                else if (e.Data.GetData(DataFormats.Text).ToString().StartsWith("http") || e.Data.GetData(DataFormats.Text).ToString().StartsWith("https"))
                {
                    if (e.Data.GetData(DataFormats.Text).ToString().Contains("aoezone.net") || e.Data.GetData(DataFormats.Text).ToString().Contains("aoczone.net"))
                    {

                        MessageBox.Show("AoEZone Do Not Allow Remote Download Yet! \n You can download the replay(s) manually and drop them here Instead.", "Message!");
                    }
                    else
                    {
                        Recgrab(e.Data.GetData(DataFormats.Text).ToString());
                    }

                    
                    //MessageBox.Show("Success Rec Download: " + e.Data.GetData(DataFormats.Text).ToString(), "Message!");
                }


            }
            catch (Exception op)
            { throw op; }
            

            //string recs = e.Data.GetData(DataFormats.Text).ToString();


            //MessageBox.Show("Rec: " + recs, "Message!");
            //int recount = recs[0].Length;
            
            //foreach (string rec in recs)
            //{
            //    MessageBox.Show("Rec: " + rec, "Message!");
            //    //recount++;
            //    //if (recount == 1)
            //    //{
            //    //    if (rec.StartsWith("http") || rec.StartsWith("https") || rec.StartsWith("ftp"))
            //    //    {
            //    //        MessageBox.Show("Rec: " + rec[recount], "Message!");
            //    //    }
            //    //}
            //}
 

            
        }

        public void Recgrab(string reclink)
        {

            //Start
            progressBar2.Visible = true;
            
            try {
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
            {throw fg;}
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
            string saffix = rndstr(8);
            string recfl = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec.mg";
            string originfln = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix + @"\watch_saffix.mgz";
            if (!Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix);
            }
            File.Move(recfl, originfln);
            //string grabrecn = originfln;
            string grabext = ".mgz";
            RecPrompt recprmt = new RecPrompt();
            recprmt.Grabext = grabext;
            recprmt.MyProperty = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix;
            recprmt.GameVersion = gamever.Text;
            recprmt.Show();
        }
        private void Completed3(object sender, AsyncCompletedEventArgs e)
        {
            progressBar2.Visible = false;
            try
            {
                string filename = Path.Combine(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\", "voobly-latest.exe");

                //System.Diagnostics.Process.Start(filename, "/VERYSILENT");
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\" + "voobly-latest.exe";
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.StartInfo.Arguments = "/VERYSILENT";
                myProcess.EnableRaisingEvents = true;
                //myProcess.Exited += new EventHandler(myProcess_Exited);
                //myProcess.Start();
                System.Diagnostics.Process.Start(filename, "/VERYSILENT");

                InitTimer();



            }
            catch
            {
                KryptonMessageBox.Show("There was a problem installing the application!", "Error!");

            }
            //Process.Start(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-latest.exe");
        }

        private void Completed4(object sender, AsyncCompletedEventArgs e)
        {
            progressBar2.Visible = false;
            try
            {
                //Extract Files
                String ExtractUP = System.IO.Path.GetTempPath() + @"\hdtotc-tmp" ;
                //String ZipFileToCreate = saveFileDialog1.FileName;

                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\" + @"SetupAoC.zip"))
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    zip.SaveProgress += SaveProgress;
                    zip.ExtractAll(ExtractUP,
                Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                    zip.StatusMessageTextWriter = System.Console.Out;
                    //zip.AddDirectory(DirectoryToZip); // recurses subdirectories
                    //zip.Save(ZipFileToCreate);
                }
                //Copy UP Files
                if(Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\UserPatch"))
                {

                    DirCopy(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\UserPatch", getaoe2path.Text + "\\");
                }
                else
                {
                    MessageBox.Show("UserPatch Files Not Found!", "Error!");
                }
                //Update UP
                DialogResult dialogResult = KryptonMessageBox.Show("How Would You Like To Update UserPatch? \n\n Automatically Update UserPatch (Yes) \n Manually Update & Customize UserPatch (No)", "UserPatch Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c" + "\"" + getaoe2path.Text + @"\SetupAoC.exe" + "\"" + " -install";
                    //startInfo.Arguments = "/c" + "\"" + getaoe2path.Text + @"\SetupAoC.exe" + "\"";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    byte[] v15 = File.ReadAllBytes(getaoe2path.Text + @"\age2_x1\age2_x1.exe");
                    File.WriteAllBytes(getaoe2path.Text + @"\age2_x1\age2_x1.5.exe", v15);
                    UserPatchCheck();
                    UserPatch userp = new UserPatch();
                    userp.ShowDialog();
                   
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    //startInfo.Arguments = "/c" + "\"" + getaoe2path.Text + @"\SetupAoC.exe" +"\"" + " -install";
                    startInfo.Arguments = "/c" + "\"" + getaoe2path.Text + @"\SetupAoC.exe" + "\"";
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    byte[] v15 = File.ReadAllBytes(getaoe2path.Text + @"\age2_x1\age2_x1.exe");
                    File.WriteAllBytes(getaoe2path.Text + @"\age2_x1\age2_x1.5.exe", v15);
                    UserPatchCheck();
                    UserPatch userp = new UserPatch();
                    userp.ShowDialog();
                    
                }
              
    

            }
            catch (Exception gh)
            {
                throw gh;
                //KryptonMessageBox.Show("There was a problem installing the application!", "Error!");

            }
            //Process.Start(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-latest.exe");
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

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            progressBar2.Visible = false;
            //getaoe2path.Text + "\\SaveGame\\"
            string zipfl = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\RecBase.zip";
            string recfl = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\RecBase.mg";
            string sdate = DateTime.Now.ToString(@"MM\-dd\-yyyy h\-mm");
            string saffix = rndstr(8);
            //string zipflvv = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Replay_" + sdate + "-" + saffix + ".zip";

            
            //Thread.Sleep(5000);
            //MessageBox.Show("File count: " + ZipFileCount(zipfl), "FileMgxz: " + ZipFileMgxz(zipfl));
            //MessageBox.Show("File Ex: " + ZipFileex(zipfl).ToString(), "FileMgxz: ");
            if (ZipFileCount(zipfl) == 1 && ZipFileMgxz(zipfl) == 999 && Ionic.Zip.ZipFile.CheckZip(zipfl) == true)
            {
                //Decompress
                string rplepath = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Replay_" + sdate + "-" + saffix;
                Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipfl);
                int zl = 0;

                foreach (ZipEntry es in zip)
                {
                    zl++;

                    //progressBar2.Value += zl / 100;
                    es.Extract(rplepath, ExtractExistingFileAction.OverwriteSilently);

                    //backgroundWorker3.ReportProgress(zl++);

                }
                //Prompt rename
                //mgx
                if (ZipFileex(zipfl) == 1)
                {
                    string grabrecn = rplepath;
                    string grabext = ".mgx";
                    RecPrompt recprmt = new RecPrompt();
                    recprmt.Grabext = grabext;
                    recprmt.MyProperty = grabrecn;
                    recprmt.GameVersion = gamever.Text;
                    recprmt.Show();
                }
                //mgz
                else if (ZipFileex(zipfl) == 2)
                {
                    string grabrecn = rplepath;
                    string grabext = ".mgz";
                    RecPrompt recprmt = new RecPrompt();
                    recprmt.Grabext = grabext;
                    recprmt.MyProperty = grabrecn;
                    recprmt.GameVersion = gamever.Text;
                    recprmt.Show();
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
                    string singlerecdir = @"\ReplayPack_" + sdate + "-" + saffix;
                    RecPackList recprmt = new RecPackList();
                    recprmt.MyProperty = grabrecdir;
                    recprmt.RecCount = ZipFileCount(zipfl);
                    recprmt.SingleDir = singlerecdir;
                    recprmt.GameVersion = gamever.Text;
                    recprmt.Show();
                }
            }

            else
            {
                MessageBox.Show("Do not contain any .mgz or mgx!", "Rejected!");
            }

            //this.Close();
        }

        private void AoE2Tools_Shown(object sender, EventArgs e)
        {
            
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
                    catch(Exception gjk)
            { 
                        throw gjk;
                    }
            
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        public static string rndstr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void kryptonSeparator1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        //Checks
        public static bool SetAllowUnsafeHeaderParsing20()
        {
            //Get the assembly that contains the internal class
            Assembly aNetAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section",
                      BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });

                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
                        FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void WololoKingdom_Check()
        {
            if(File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini"))
            {
                string wkver = File.ReadAllText(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini");
                SetAllowUnsafeHeaderParsing20();
                //Get wololokingdom latest repo
                WebClient wk = new WebClient();
                wk.Headers.Add("user-agent", "tesft");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
                var _strwk = wk.DownloadString("https://api.github.com/repos/AoE2CommunityGitHub/WololoKingdoms/releases/latest");
                var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
                string wktag = (string)jObject["tag_name"];

                if (wkver != wktag && !Directory.Exists(getaoe2path.Text + "\\WololoKingdoms " + wktag) && !File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini"))
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        linkLabel1.Visible = true;
                        kryptonLabel1.Visible = true;
                        wololopbox.Image = Properties.Resources.uncheckb;

                    });

                }
            }
            else if (!File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini"))
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    linkLabel1.Visible = true;
                    kryptonLabel1.Visible = true;
                    wololopbox.Image = Properties.Resources.uncheckb;

                });
            }

        }

        public void HDToTC_Check()
        {
            //Begin
            using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            {
                if (key64 != null)
                {
                    string aoe2path = key64.GetValue("EXE Path").ToString();
                    
                    //Object o = key.GetValue("Language");
                    if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe"))
                    {
                        //config AoE2Tools
                     
                        try
                        {
                            //Config path
                            using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                            {
                                if (SetGame != null)
                                {


                                    //Object o32 = key32.GetValue("InstallPath");
                                    SetGame.SetValue("AoE2Path", aoe2path);
                                }
                            }
                            //End Config
                            
                            //Change Path Adviser
                            string Select_p = aoe2path;
                            var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                            var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                     if (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            _mbIcon = MessageBoxIcon.Warning;
                            _mbButtons = MessageBoxButtons.YesNo;
                            DialogResult dialogResult = KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "Warning! (Optional)", _mbButtons, _mbIcon);
                            
                            //KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "(Optional) Warning!");
                            if (dialogResult == DialogResult.Yes)
                             {
                                //Invoke Mover
                                 Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\AoE2Tools Mover.exe");
                             }
                            else if (dialogResult == DialogResult.No)
                            {
                                //Grand Access AoE2Tools

                            }
                     }
                            //Grant Access AoE2Tools


                        }
                        catch (Exception yu)
                        { throw yu; }
                    }
                }
                else if(key32 != null)
                {
                    //check 32bit
                    string aoe2path = key32.GetValue("EXE Path").ToString();
                    if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe"))
                    {
                        //config AoE2Tools

                        try
                        {
                            //Config path
                            using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                            {
                                if (SetGame != null)
                                {


                                    
                                    SetGame.SetValue("AoE2Path", aoe2path);
                                }
                            }
                            //End Config
                            //Change Path Adviser
                            string Select_p = aoe2path;
                            var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                            var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                            if (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                _mbIcon = MessageBoxIcon.Warning;
                                _mbButtons = MessageBoxButtons.YesNo;
                                DialogResult dialogResult = KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "Warning! (Optional)", _mbButtons, _mbIcon);

                                //KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "(Optional) Warning!");
                                if (dialogResult == DialogResult.Yes)
                                {
                                    //Invoke Mover

                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    //Grand Access AoE2Tools

                                }
                            }
                            //Grant Access AoE2Tools


                        }
                        catch (Exception yu)
                        { throw yu; }
                    }
                }
                else if (key32 == null && key64 == null)
                {
                    //Show Preconv
                }
            }
        



        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public void Voobly_Check()
        {

            string programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            string programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);


            if (File.Exists(programfileX64 + @"\Voobly\voobly.exe") || File.Exists(programfileX86 + @"\Voobly\voobly.exe"))
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    vooblypbox.Image = Properties.Resources.checkb2;
                    vooblbl.Visible = false;
                    vooblink.Visible = false;

                });


            }
            else
            {
                  BeginInvoke((MethodInvoker)delegate
                {
                vooblypbox.Image = Properties.Resources.uncheckb;
                vooblbl.Visible = true;
                vooblink.Visible = true;
                });
            }
        }

        public void UserPatchCheck()
        {
            try
            {
                if (!File.Exists(getaoe2path.Text + @"\SetupAoC.exe"))
                {
                    Invoke((MethodInvoker)delegate
                    {
                        uppbox.Image = Properties.Resources.uncheckb;
                        userpatchlbl.Visible = true;
                        uplink.Visible = true;
                    });
                }
                else if(File.Exists(getaoe2path.Text + @"\SetupAoC.exe"))
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(getaoe2path.Text + @"\SetupAoC.exe");
                    string version = versionInfo.FileVersion;
                    string curbuild = version.Substring(4, version.Length - 4);
                    string curbuild2 = curbuild.Substring(0, curbuild.Length - 2);
                    if (curbuild2 == null) { File.Delete(getaoe2path.Text + @"\SetupAoC.exe"); }
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead("http://userpatch.aiscripters.net/build.txt");
                    StreamReader reader = new StreamReader(stream);
                    String upbuild = reader.ReadToEnd();
                    if (upbuild != "" && curbuild2 != "" && upbuild != curbuild2)
                    {
                        //Begin Check

                        //if (!File.Exists(getaoe2path.Text + @"\SetupAoC.exe"))
                        //{
                        Invoke((MethodInvoker)delegate
                        {
                            uppbox.Image = Properties.Resources.uncheckb;
                            userpatchlbl.Visible = true;
                            uplink.Visible = true;
                        });

                        //progressBar2.Visible = true;


                        //}
                        //else
                        //{

                        //}
                        //End Check
                    }

                    else
                    {
                        //Ignore
                        uppbox.Image = Properties.Resources.checkb2;
                        userpatchlbl.Visible = false;
                        uplink.Visible = false;
                    }
                }
     

            }
            catch(SystemException)
            {

            }

        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Image = WindowsFormsApplication3.Properties.Resources.UIclose2;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = WindowsFormsApplication3.Properties.Resources.UIclose11;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.Image = WindowsFormsApplication3.Properties.Resources.UImin2;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = WindowsFormsApplication3.Properties.Resources.UImin1;
        }


        private void panel3_Click(object sender, EventArgs e)
        {

            Menugen();
        }

        private void gamemover_Click(object sender, EventArgs e)
        {
            Process.Start("AoE2Tools Mover.exe");
        }

        private void wololoinstall_Click(object sender, EventArgs e)
        {
            WololoInstaller wkwin = new WololoInstaller();
            wkwin.ShowDialog();
        }

        private void Support_Click(object sender, EventArgs e)
        {
            SupportUs supus = new SupportUs();
            supus.ShowDialog();
        }

        private void onefive_Click(object sender, EventArgs e)
        {
            Process.Start(getaoe2path.Text + "\\age2_x1\\age2_x1.5.exe");
        }

        private void onefour_Click(object sender, EventArgs e)
        {
            Process.Start(getaoe2path.Text + "\\age2_x1\\age2_x1.4.exe");
        }

        private void onec_Click(object sender, EventArgs e)
        {
            Process.Start(getaoe2path.Text + "\\age2_x1\\age2_x1.0c.exe");
        }

        private void one_Click(object sender, EventArgs e)
        {
            if (File.Exists(getaoe2path.Text + "\\age2_x1\\WK.exe"))
            {
                Process.Start(getaoe2path.Text + "\\age2_x1\\WK.exe");
            }
            else if (!File.Exists(getaoe2path.Text + "\\age2_x1\\WK.exe"))
            {
                KryptonMessageBox.Show("Wololokingdoms Not Found! \n Install WololoKingdom Offline","WololoKingdom Not Found!");
                HowToWk howwk = new HowToWk();
                howwk.ShowDialog();
            }
            
        }

        void replayspacker_Click(object sender, EventArgs e)
        {
            ReplaysPacker replayp = new ReplaysPacker();
            replayp.ShowDialog();
        }

        void hotkeys_Click(object sender, EventArgs e)
        {
            Hotkeys hki = new Hotkeys();
            hki.ShowDialog();
        }

        void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void offlinemods_Click(object sender, EventArgs e)
        {
            ModsOffline modsoff = new ModsOffline();
            modsoff.ShowDialog();
        }

        void Savegame_Click(object sender, EventArgs e)
        {
            Process.Start(getaoe2path.Text + "\\SaveGame");
        }

        void Ai_Click(object sender, EventArgs e)
        {
            Process.Start(getaoe2path.Text + "\\Ai");
        }

        void Maps_Click(object sender, EventArgs e)
        {
            Process.Start(getaoe2path.Text + "\\Random");
        }

        void Scenario_Click(object sender, EventArgs e)
        {
            Process.Start(getaoe2path.Text + "\\Scenario");
        }

        //Events//
        /////////
        //Show//
        ///////
        AoE2Tools filterForm;
        void item_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            if (filterForm == null)
            {
                filterForm = new AoE2Tools();
                filterForm.FormClosed += delegate { filterForm = null; };
                filterForm.Show();
            }
            else
            {
                filterForm.WindowState = FormWindowState.Normal;
                filterForm.Focus();
            }
           
            //this.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Properties.Resources.shieldgrey;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackgroundImage = Properties.Resources.shieldcolor1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WololoInstaller wk = new WololoInstaller();
            wk.ShowDialog();
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vooblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            progressBar2.Visible = true;

            try
            {
                bool saverectmp = System.IO.Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp");

                if (!saverectmp)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp");
                }
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string flexe = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-latest.exe";
                WebClient webClient = new WebClient();
                //webClient.Headers.Add("User-Agent: Other"); 
                //webClient.Headers.Add("Content-Type", "application/zip");
                //webClient.UseDefaultCredentials = true;
                //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                //webClient.Headers.Add(HttpRequestHeader.UserAgent, "AoE2Tools");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed3);
                webClient.DownloadFileAsync(new Uri(@"http://www.voobly.com/client/download"), flexe);
            }
            catch (Exception fg)
            { throw fg; }
        }
        //voobly
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 3000;
            timer1.Start();
        }
        private System.Windows.Forms.Timer timer3;
        public void CheckVoobup()
        {
            timer3 = new System.Windows.Forms.Timer();
            timer3.Tick += new EventHandler(timer3_Tick);
            timer3.Interval = 3000;
            timer3.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(vooblyend() == false)
            {
                timer1.Stop();
                KryptonMessageBox.Show("Please Apply Voobly Lobby Update To Avoid Restarting Voobly","Voobly Lobby Update");
                Process myProcess2 = new Process();
                myProcess2.StartInfo.FileName = "voobly-update.exe";
                myProcess2.StartInfo.Verb = "Print";
                myProcess2.StartInfo.CreateNoWindow = false;
                myProcess2.StartInfo.Arguments = "/VERYSILENT";
                myProcess2.EnableRaisingEvents = true;
                //myProcess.Exited += new EventHandler(myProcess_Exited);
                //myProcess.Start();
                System.Diagnostics.Process.Start("voobly-update.exe", "/VERYSILENT");
                
            }
            else if (vooblyend() == true)
            {
                timer1.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            isfound2();
        }

        public void isfound()
        {
            string V64bit = Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Voobly\\voobly.exe";
            string V32bit = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + "\\Voobly\\voobly.exe";
            if (File.Exists(V32bit))
            {

                //File.Copy("voobly-update.exe", Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + "\\Voobly\\voobly-update.exe");
                string vooblyupdate = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + "\\Voobly\\", "voobly-update.exe");
                System.Diagnostics.Process.Start("voobly-update.exe", "/VERYSILENT");
                timer1.Stop();
            }
            else if (File.Exists(V64bit))
            {
                //File.Copy("voobly-update.exe", Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Voobly\\voobly-update.exe");
                string vooblyupdate = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Voobly\\", "voobly-update.exe");
                System.Diagnostics.Process.Start("voobly-update.exe", "/VERYSILENT");
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        public void isfound2()
        {
            string V64bit = Environment.ExpandEnvironmentVariables("%ProgramW6432%") + @"\Voobly\gamedata\aoc\age2_x1.exe";
            string V32bit = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + @"\Voobly\gamedata\aoc\age2_x1.exe";
            if (File.Exists(V32bit) || File.Exists(V64bit))
            {


                timer3.Stop();
                //File.Copy("voobly-update.exe", Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + "\\Voobly\\voobly-update.exe");

            }

            else
            {
                timer3.Start();
            }
        }
        public bool vooblyend()
        {
            string V64bit = Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Voobly\\voobly.exe";
            string V32bit = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + "\\Voobly\\voobly.exe";
            Regex regex = new Regex(@"voobly.*tmp");
            foreach (Process p in Process.GetProcesses("."))
            {
                if (regex.Match(p.ProcessName).Success == false && (File.Exists(V32bit) || File.Exists(V64bit)))
                    return false;
            }
            return true;
        }
        //
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void uplink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            progressBar2.Visible = true;

            try
            {
                bool saverectmp = System.IO.Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp");

                if (!saverectmp)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp");
                }
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string flexe = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\" + @"SetupAoC.zip";
                WebClient webClient = new WebClient();
                //webClient.Headers.Add("User-Agent: Other"); 
                //webClient.Headers.Add("Content-Type", "application/zip");
                //webClient.UseDefaultCredentials = true;
                //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                //webClient.Headers.Add(HttpRequestHeader.UserAgent, "AoE2Tools");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed4);
                webClient.DownloadFileAsync(new Uri(@"http://userpatch.aiscripters.net/download/"), flexe);
            }
            catch (Exception fg)
            { throw fg; }
        }

        private void ZipExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            
            if (e.EventType != ZipProgressEventType.Extracting_BeforeExtractEntry)
                return;
            filesExtracted++;
            Invoke((MethodInvoker)delegate
            {
                progressBar4.Value = 100 * filesExtracted / totalFiles;
            });
        }

        private void _Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        public void CopyFolder(string SourcePath, string DestinationPath)
        {
            progressBar4.Value = 0;
            if (Directory.Exists(SourcePath))
            {

                //Now Create all of the directories 
                //string[] allDirectories = Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories);
                string[] allFiles = Directory.GetFiles(SourcePath, "*.mp3", SearchOption.AllDirectories);
                int numberOfItems = allFiles.Length;
                int progress = 0;

                //foreach (string dirPath in allDirectories)
                //{
                //    //Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
                //    progress++;
                //    progressBar2.Value = 100 * progress / numberOfItems;
                //    //_Worker.ReportProgress(100 * progress / numberOfItems);

                //}
                //_Worker.ReportProgress(0);
                System.Threading.Thread.Sleep(1000);
                //Copy all the files 
                foreach (string newPath in allFiles)
                {

                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
                    progress++;
                    progressBar4.Value = 100 * progress / numberOfItems;
                    //_Worker.ReportProgress(100 * progress / numberOfItems);
                }
                progressBar4.Visible = false;

            }
        }

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
            Menugen();
            }
            
        }
        public void Menugen()
        {
            //Menu
            //--Show
            ContextMenuStrip contexMenuuu = new ContextMenuStrip();
            ToolStripItem item = contexMenuuu.Items.Add("Show ");

            item.Click += new EventHandler(item_Click);
            //--Browse

            ToolStripItem browse = contexMenuuu.Items.Add("Browse ");
            browse.Image = Properties.Resources.browse;


            //-SaveGame

            ToolStripItem savegame = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add("SaveGame");
            savegame.Image = Properties.Resources.Save;
            savegame.Click += new EventHandler(Savegame_Click);

            //-Ai

            ToolStripItem ai = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Ai");
            ai.Image = Properties.Resources.Script;
            ai.Click += new EventHandler(Ai_Click);

            //-Maps

            ToolStripItem maps = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Maps");
            maps.Image = Properties.Resources.world;
            maps.Click += new EventHandler(Maps_Click);

            //-Scenario
            ToolStripItem scenario = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Scenario");
            scenario.Image = Properties.Resources.replaypack;
            scenario.Click += new EventHandler(Scenario_Click);


            //--Tools
            ToolStripItem tools = contexMenuuu.Items.Add("Tools ");
            tools.Image = Properties.Resources.tools;

            //-Replays Packer

            ToolStripItem replayspacker = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add("Replays Packer ");
            replayspacker.Click += new EventHandler(replayspacker_Click);
            replayspacker.Image = Properties.Resources.archiveit1;
            //-Game Mover

            ToolStripItem gamemover = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add("Game Mover ");
            gamemover.Click += new EventHandler(gamemover_Click);
            gamemover.Image = Properties.Resources.mover;

            //-Offline Mods

            ToolStripItem offlinemods = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add("Offline Mods ");
            offlinemods.Click += new EventHandler(offlinemods_Click);
            offlinemods.Image = Properties.Resources.Save_color;

            //-Hotkeys

            ToolStripItem hotkeys = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add("Hotkeys ");
            hotkeys.Click += new EventHandler(hotkeys_Click);
            hotkeys.Image = Properties.Resources.keyboard_key_h;

            //-WololoInstaller

            ToolStripItem wololoinstaller = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add("WK Installer ");
            wololoinstaller.Click += new EventHandler(wololoinstall_Click);
            wololoinstaller.Image = Properties.Resources.wololokingdoms;

            //--Run Version
            ToolStripItem runversion = contexMenuuu.Items.Add("Run Version ");
            runversion.Image = Properties.Resources.gold_cd;
            runversion.Click += new EventHandler(Exit_Click);





            //-1.0c

            ToolStripItem onec = (contexMenuuu.Items[3] as ToolStripMenuItem).DropDownItems.Add("1.0c ");
            onec.Click += new EventHandler(onec_Click);
            onec.Image = Properties.Resources.aoe2_2;


            //-1.4 RC

            ToolStripItem onefour = (contexMenuuu.Items[3] as ToolStripMenuItem).DropDownItems.Add("1.4 RC ");
            onefour.Click += new EventHandler(onefour_Click);
            onefour.Image = Properties.Resources.aoe2_2;


            //-1.5 RC


            ToolStripItem onefive = (contexMenuuu.Items[3] as ToolStripMenuItem).DropDownItems.Add("1.5 RC ");
            onefive.Click += new EventHandler(onefive_Click);
            onefive.Image = Properties.Resources.aoe2_2;

            //-WK

            ToolStripItem one = (contexMenuuu.Items[3] as ToolStripMenuItem).DropDownItems.Add("WK ");
            one.Click += new EventHandler(one_Click);
            one.Image = Properties.Resources.aoe2_2;

            //--Support
            ToolStripItem support = contexMenuuu.Items.Add("Support ");
            support.Click += new EventHandler(Support_Click);

            //--Exit
            ToolStripItem exit = contexMenuuu.Items.Add("Exit ");
            exit.Click += new EventHandler(Exit_Click);
            
            //END
            
            //contexMenuuu.Show(this, this.PointToClient(MousePosition));
            //notifyIcon1.ContextMenuStrip.Show(this, new Point(Cursor.Position.X, Cursor.Position.Y));

            contexMenuuu.Show(Cursor.Position);
          
            //notifyIcon1.ContextMenuStrip.Show(Cursor.Position); 
            //contexMenuuu.Show(Control.MousePosition);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCRBUTTONDOWN = 0xa4;
            if (m.Msg == WM_NCRBUTTONDOWN)
            {
                var pos = new Point(m.LParam.ToInt32());
                Menugen();
                return;
            }
            base.WndProc(ref m);
        }
        private void AoE2Tools_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                
                //notifyIcon1.Visible = true;
               
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Show();
                //this.WindowState = FormWindowState.Normal;
                //notifyIcon1.Visible = false;

            }
        }

        private void topme_CheckedChanged(object sender, EventArgs e)
        {
            if(topme.Checked == true)
            {
                //SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
                this.TopMost = true;
            }
            else
            {
                //SetWindowPos(this.Handle, HWND_BOTTOM, 0, 0, 0, 0, BOTTOM_FLAGS);
                this.TopMost = false;
            }
        }

        private void recentreplay_Click(object sender, EventArgs e)
        {
            RecentReplay recentrepl = new RecentReplay();
            recentrepl.ShowDialog();
        }

        private void showtips_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public uint _message { get; set; }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://youtu.be/FXOAxbckKVQ?t=11s");
        }
        public void GameSys_Check()
        {
            string Select_p = getaoe2path.Text;
            var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                _mbIcon = MessageBoxIcon.Warning;
                _mbButtons = MessageBoxButtons.YesNo;
                DialogResult dialogResult = KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like AoE2Tools To Safely Move Your Game To a Recommended Or a Custom Location?", "Important!", _mbButtons, _mbIcon);

                //KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "(Optional) Warning!");
                if (dialogResult == DialogResult.Yes)
                {
                    //Invoke Mover
                    Process.Start("AoE2Tools Mover.exe");
                }
                else if (dialogResult == DialogResult.No)
                {
                    //nothing here

                }
            }
        }

        private void steampbox_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tauntcheck_Click(object sender, EventArgs e)
        {

        }

        private void gamever_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

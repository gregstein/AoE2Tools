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
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Ionic.Zip;
using System.Net;
using System.Diagnostics;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Reflection;
namespace WindowsFormsApplication3
{
    public partial class TestUI : KryptonForm
    {
        private MessageBoxIcon _mbIcon = MessageBoxIcon.Information;
        private MessageBoxIcon _mbIcon2 = MessageBoxIcon.Warning;
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
        public TestUI()
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
        private void TestUI_Load(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void vooblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
            vooblink.Visible = false;
            
            vooblbl.Text = "Downloading...";
            progressBar4.Visible = true;

            try
            {
                bool saverectmp = System.IO.Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp");
                
                if (!saverectmp)
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp");
                }
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string VTMPU = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-update.exe";
                string flexe = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-latest.exe";
                WebClient webClient = new WebClient();
                //webClient.Headers.Add("User-Agent: Other"); 
                //webClient.Headers.Add("Content-Type", "application/zip");
                //webClient.UseDefaultCredentials = true;
                //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                //webClient.Headers.Add(HttpRequestHeader.UserAgent, "AoE2Tools");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed3);
                webClient.DownloadFileAsync(new Uri("http://www.voobly.com/client/download"), flexe);
                webClient.DownloadFileAsync(new Uri("https://www.voobly.com/updates/voobly-gamedata-aoc-v1.1.1.8.exe"), VTMPU);
            }
            catch (SystemException)
            { //KryptonMessageBox.Show("Your internet dropped! Restart AOE2Tools and try again!", "Connection Lost"); 
            }
        }

        private void vooblbl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonCheckButton2_Click(object sender, EventArgs e)
        {
            //if (kryptonCheckButton2.Checked == false)
            //{
            //    try
            //    {
            //        File.WriteAllText(System.IO.Path.GetTempPath() + "\\wdus_d.bat", File.ReadAllText(Directory.GetCurrentDirectory() + "\\data\\perf\\wdus_d.txt"));
                    
            //        System.Diagnostics.Process process = new System.Diagnostics.Process();
            //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //        startInfo.FileName = "cmd.exe";
            //        startInfo.Arguments = "/c" + System.IO.Path.GetTempPath() + "\\wdus_d.bat\"";
            //        startInfo.Verb = "runas";
            //        //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
            //        //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
            //        //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
            //        process.StartInfo = startInfo;
            //        process.Start();
            //        process.WaitForExit();
            //        //boost true save key

            //        RegistryKey winboost = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true);
                    
            //            //if (SetVoobly != null)
            //            //{


            //                //Object o32 = key32.GetValue("InstallPath");
            //        winboost.SetValue("WinBoost", "false");
            //                winboost.Close();

            //            //}
            //        //}
            //        //
            //                KryptonMessageBox.Show("Windows Boost Disabled!\n\n (x) SuperFetch enabled.\n(x) Themes enabled.\n(x) MapsBroker enabled.\n(x) DoSvc enabled.", "AoE2 Tools");

            //    }
            //    catch (SystemException)
            //    {
            //        kryptonCheckButton2.Checked = false;
            //        KryptonMessageBox.Show("Cancelled.. Boost", "AoE2 Tools");
            //    }
            //}
            //else if (kryptonCheckButton2.Checked == true)
            //{
            //    try
            //    {
            //        File.WriteAllText(System.IO.Path.GetTempPath() + "\\wdus_e.bat", File.ReadAllText(Directory.GetCurrentDirectory() + "\\data\\perf\\wdus_e.txt"));
                    
            //        System.Diagnostics.Process process = new System.Diagnostics.Process();
            //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //        startInfo.FileName = "cmd.exe";
            //        startInfo.Arguments = "/c" + System.IO.Path.GetTempPath() + "\\wdus_e.bat\"";
            //        startInfo.Verb = "runas";
            //        //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
            //        //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
            //        //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
            //        process.StartInfo = startInfo;
            //        process.Start();
            //        process.WaitForExit();
            //        //boost false save key

            //        RegistryKey winboost = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true);
              


            //                //Object o32 = key32.GetValue("InstallPath");
            //                winboost.SetValue("WinBoost", "true");
            //                winboost.Close();
                  
            //        //
            //                KryptonMessageBox.Show("Windows Boost Enabled!\n\n (x) SuperFetch disabled.\n(x) Themes disabled.\n(x) MapsBroker disabled.\n(x) DoSvc disabled.", "AoE2 Tools");

            //    }
            //    catch (SystemException)
            //    {
            //        kryptonCheckButton2.Checked = false;
            //        KryptonMessageBox.Show("Cancelled.. Boost", "AoE2 Tools");
            //    }
            //}
        }

        private void kryptonCheckButton5_Click(object sender, EventArgs e)
        {
            // if (kryptonCheckButton5.Checked == false)
            //{
            //    try
            //    {
            //        System.Diagnostics.Process process = new System.Diagnostics.Process();
            //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //        startInfo.FileName = "cmd.exe";
            //        startInfo.Arguments = "/c" + "\\data\\perf\\steamboost.exe\" -unopt";
            //        startInfo.Verb = "runas";
            //        //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
            //        //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
            //        //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
            //        process.StartInfo = startInfo;
            //        process.Start();
            //        process.WaitForExit();
            //        RegistryKey setsteam = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true);
            //        setsteam.SetValue("SteamBoost", "false");
            //        setsteam.Close();
            //        KryptonMessageBox.Show("Boost Disabled!", "AoE2 Tools");
            //    }
            //    catch (SystemException)
            //    {
            //        kryptonCheckButton5.Checked = false;
            //        KryptonMessageBox.Show("Cancelled..", "AoE2Tools");
            //    }

            //}
            //else if (kryptonCheckButton5.Checked == true)
            //{
            //    try
            //    {
            //        System.Diagnostics.Process process = new System.Diagnostics.Process();
            //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //        startInfo.FileName = "cmd.exe";
            //        startInfo.Arguments = "/c" + "\\data\\perf\\steamboost.exe\" -opt";
            //        startInfo.Verb = "runas";
            //        //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
            //        //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
            //        //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
            //        process.StartInfo = startInfo;
            //        process.Start();
            //        process.WaitForExit();
            //        RegistryKey setsteam = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true);
            //        setsteam.SetValue("SteamBoost", "true");
            //        setsteam.Close();
            //        KryptonMessageBox.Show("Boost Enabled!", "AoE2Tools");
            //    }
            //    catch (SystemException)
            //    {
            //        kryptonCheckButton5.Checked = false;
            //        KryptonMessageBox.Show("Cancelled.. Boost", "AoE2Tools");
            //    }



            //}
            
        }

        private void kryptonCheckButton3_Click(object sender, EventArgs e)
        {
            //if (kryptonCheckButton3.Checked == true)
            //{
            //    try
            //    {
            //        System.Diagnostics.Process process = new System.Diagnostics.Process();
            //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //        startInfo.FileName = "cmd.exe";
            //        startInfo.Arguments = "/c" + "\"" + Directory.GetCurrentDirectory() + "\\data\\perf\\mouse.exe" + "\"" + " -opt";
            //        //File.WriteAllText(System.IO.Path.GetTempPath() + "\\e-m.bat", "\"" + Directory.GetCurrentDirectory() + "\\data\\perf\\mouse.exe" + "\"" + " -opt");
            //        startInfo.Verb = "runas";
            //        process.StartInfo = startInfo;
            //        process.Start();
            //        process.WaitForExit();

            //        RegistryKey SetVoobly = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true);
            //        SetVoobly.SetValue("NormalMouse", "true");
            //        SetVoobly.Close();
            //        //File.Delete(System.IO.Path.GetTempPath() + "\\e-m.bat");
            //        KryptonMessageBox.Show("Normal Mouse Cursor Enabled!", "AoE2Tools");
            //    }
            //    catch (SystemException)
            //    {
            //        kryptonCheckButton3.Checked = false;
            //        KryptonMessageBox.Show("Cancelled..", "AoE2Tools");
            //    }

            //    //

            //    //myProcess.WaitForExit();

            //}
            //else if (kryptonCheckButton3.Checked == false)
            //{
            //    try
            //    {
            //        System.Diagnostics.Process process = new System.Diagnostics.Process();
            //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //        startInfo.FileName = "cmd.exe";
            //        startInfo.Arguments = "/c" + "\"" + Directory.GetCurrentDirectory() + "\\data\\perf\\mouse.exe" + "\"" + " -unopt";
            //        //File.WriteAllText(System.IO.Path.GetTempPath() + "\\e-m.bat", "\"" + Directory.GetCurrentDirectory() + "\\data\\perf\\mouse.exe" + "\"" + " -unopt");
            //        startInfo.Verb = "runas";
            //        process.StartInfo = startInfo;
            //        process.Start();
            //        process.WaitForExit();
            //        RegistryKey SetVoobly = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true);
            //        SetVoobly.SetValue("NormalMouse", "false");
            //        SetVoobly.Close();
            //        //File.Delete(System.IO.Path.GetTempPath() + "\\d-m.bat");
            //        KryptonMessageBox.Show("Normal Mouse Cursor Disabled!", "AoE2Tools");
            //    }
            //    catch (SystemException)
            //    {
            //        kryptonCheckButton3.Checked = false;
            //        KryptonMessageBox.Show("Cancelled..", "AoE2Tools");
            //    }

            //}
        }

        private void kryptonCheckButton4_Click(object sender, EventArgs e)
        {
            //if (kryptonCheckButton4.Checked == true)
            //{
            //    Microsoft.Win32.RegistryKey rkey4;
            //    rkey4 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
            //    rkey4.SetValue("disabledxhwaccel", "true");
            //    rkey4.Close();
            //    RegistryKey SetVoobly = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true);
            //    SetVoobly.SetValue("HwA", "true");
            //    SetVoobly.Close();
            //    MessageBox.Show("Hardware enabled For Voobly!", "AoE2Tools");

            //}
            //else if (kryptonCheckButton4.Checked == false)
            //{

            //    Microsoft.Win32.RegistryKey rkey5;
            //    rkey5 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
            //    rkey5.SetValue("disabledxhwaccel", "false");
            //    rkey5.Close();
            //    RegistryKey SetVoobly = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true);
            //    SetVoobly.SetValue("HwA", "false");
            //    SetVoobly.Close();
            //    MessageBox.Show("Hardware Disabled For Voobly!", "AoE2Tools");

            //}
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Enabled = true;
            //RemoveDirectories(System.IO.Path.GetTempPath(), "Temp");
            //BeginInvoke((MethodInvoker)delegate
            //{

            backgroundWorker2.RunWorkerAsync();
            //});
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
                        try
                        {
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
                    string createresult = "CleanUp Success! \n (X)" + name + "Cleaned: " + Environment.NewLine;

                    File.AppendAllText("res.tmp", createresult);
                }
            }, null);
        }
        static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
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

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            RemoveDirectories(System.IO.Path.GetTempPath(), "Temp");
            System.Threading.Thread.Sleep(500);
            RemoveDirectories(getaoe2path.Text + "\\SaveGame\\Multi\\", "AoE2 Restores");
            KryptonMessageBox.Show("Temporary Files & Game Cache Cleared!","Success");
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

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
        }

        private void langbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (langbox.SelectedIndex.Equals(0))
            {
                progressBar4.Visible = true;
                Install_lang("en", "arabic");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Arabic Language Successfully Installed!", "AoE2Tools [#Language Installer]");

            }
            else if (langbox.SelectedIndex.Equals(1))
            {
                progressBar4.Visible = true;
                Install_lang("en", "english");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("English Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }

            else if (langbox.SelectedIndex.Equals(2))
            {
                progressBar4.Visible = true;
                Install_lang("en", "bulgarian");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Bulgarian Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(3))
            {
                progressBar4.Visible = true;
                Install_lang("zh", "chinese");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Chinese Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(4))
            {
                progressBar4.Visible = true;
                Install_lang("en", "czech");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Czech Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(5))
            {
                progressBar4.Visible = true;
                Install_lang("fr", "french");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("French Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(6))
            {
                progressBar4.Visible = true;
                Install_lang("en", "greek");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Greek Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(7))
            {
                progressBar4.Visible = true;
                Install_lang("en", "hungarian");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Hungarian Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(8))
            {
                progressBar4.Visible = true;
                Install_lang("it", "italian");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Italian Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(9))
            {
                progressBar4.Visible = true;
                Install_lang("ko", "korean");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Korean Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(10))
            {
                progressBar4.Visible = true;
                Install_lang("es", "spanish");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Spanish Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(11))
            {
                progressBar4.Visible = true;
                Install_lang("br", "portuguese");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Portuguese Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(12))
            {
                progressBar4.Visible = true;
                Install_lang("en", "polish");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Polish Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }

            else if (langbox.SelectedIndex.Equals(13))
            {
                progressBar4.Visible = true;
                Install_lang("en", "slovak");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Slovak Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(14))
            {
                progressBar4.Visible = true;
                Install_lang("tr", "turkish");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Turkish Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(15))
            {
                progressBar4.Visible = true;
                Install_lang("de", "german");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("German Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(16))
            {
                progressBar4.Visible = true;
                Install_lang("jp", "japanese");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
                KryptonMessageBox.Show("Japanese Language Successfully Installed!", "AoE2Tools [#Language Installer]");
            }
            else if (langbox.SelectedIndex.Equals(17))
            {
                progressBar4.Visible = true;
                Install_lang("ru", "russian");
                progressBar4.Value = 100;
                System.Threading.Thread.Sleep(1000);
                progressBar4.Visible = false;
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
                            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "SteamPath", null) == null)
                            {
                                string steampath = key.GetValue("SteamPath").ToString();
                                CopyFolder(steampath + "\\resources\\" + langstr + "\\sound\\taunt\\", extractPath + "\\Taunt\\");
                            }

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

        private void uplink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
            progressBar1.Visible = true;
            uplink.Visible = false;
            userpatchlbl.Text = "Downloading...";

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
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged_up);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed4);
                webClient.DownloadFileAsync(new Uri(@"http://userpatch.aiscripters.net/download/"), flexe);
            }
            catch (SystemException)
            { KryptonMessageBox.Show("Your Internet dropped! Restart AoE2Tools and try again.", "Connection Lost!"); }
        }
        private void ProgressChanged_up(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar1.Value = (int)e.BytesReceived / 100;

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
            string originfln = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix + @"\watch_" + saffix + ".mgz";
            if (!Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix);
            }
            File.Move(recfl, originfln);
            //string grabrecn = originfln;
            topme.Checked = false;
            string grabext = ".mgz";
            RecPrompt recprmt = new RecPrompt();
            recprmt.Grabext = grabext;
            recprmt.MyProperty = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix;
            recprmt.GameVersion = gamever.Text;
            recprmt.ShowDialog();
            uplink.Visible = false;
            userpatchlbl.Visible = false;
        }
        private void Completed3(object sender, AsyncCompletedEventArgs e)
        {
            //progressBar4.Visible = false;
            progressBar4.Value = 0;
            

            try
            {

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string VTMPU = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-update.exe";
               
                WebClient webClient = new WebClient();
                //webClient.Headers.Add("User-Agent: Other"); 
                //webClient.Headers.Add("Content-Type", "application/zip");
                //webClient.UseDefaultCredentials = true;
                //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                //webClient.Headers.Add(HttpRequestHeader.UserAgent, "AoE2Tools");
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed5);
              
                webClient.DownloadFileAsync(new Uri("https://www.voobly.com/updates/voobly-gamedata-aoc-v1.1.1.8.exe"), VTMPU);
            }
            catch (SystemException)
            { //KryptonMessageBox.Show("Your internet dropped! Restart AOE2Tools and try again!", "Connection Lost"); 
            }
            //
            
            //Process.Start(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-latest.exe");
        }
        private void Completed5(object sender, AsyncCompletedEventArgs e)
        {
            progressBar4.Visible = false;
            vooblbl.Text = "Auto Install...";
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
                vooblbl.Visible = false;
                vooblypbox.Image = Properties.Resources.checkb2;
                InitTimer();



            }
            catch
            {
                KryptonMessageBox.Show("There was a problem installing the application!", "Error!");

            }
        }

        private void Completed4(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            userpatchlbl.Text = "Installing...";
            try
            {
                //Extract Files
                String ExtractUP = System.IO.Path.GetTempPath() + @"\hdtotc-tmp";
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
                if (Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\UserPatch"))
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
                    
                    UserPatchCheck();
                    UserPatch userp = new UserPatch();
                    userp.ShowDialog();
                    byte[] v15 = File.ReadAllBytes(getaoe2path.Text + @"\age2_x1\age2_x1.exe");
                    File.WriteAllBytes(getaoe2path.Text + @"\age2_x1\age2_x1.5.exe", v15);

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
                catch (UnauthorizedAccessException)
            {
                KryptonMessageBox.Show("Run AoE2Tools As Administrator! Or Consider Moving Age of empires 2 using \"AoE2Tools Game Mover\" to avoid these inconveniences!", "Access Denied!");
            }
            catch (SystemException)
            {
                //throw gh;
                KryptonMessageBox.Show("There was a problem installing the application!", "Error!");

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
                    topme.Checked = false;
                    string grabrecn = rplepath;
                    string grabext = ".mgz";
                    RecPrompt recprmt = new RecPrompt();
                    recprmt.Grabext = grabext;
                    recprmt.MyProperty = grabrecn;
                    recprmt.GameVersion = gamever.Text;
                    recprmt.Show();
                }
                //mgz
                else if (ZipFileex(zipfl) == 2)
                {
                    topme.Checked = false;
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
                    topme.Checked = false;
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
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            //{
            //    if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WinBoost", null) != null)
            //    {
            //        string _winboost = key.GetValue("WinBoost").ToString();
                    
            //        //Game Check
            //        if (_winboost == "true")
            //        {
            //            kryptonCheckButton2.Checked = true;

            //        }
            //        else
            //        {
            //            kryptonCheckButton2.Checked = false;
            //        }
         
            //    }
            //     if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "SteamBoost", null) != null)
            //    {
            //        string _steamboost = key.GetValue("SteamBoost").ToString();
            //        if (_steamboost == "true")
            //        {
            //            kryptonCheckButton5.Checked = true;

            //        }
            //        else
            //        {
            //            kryptonCheckButton5.Checked = false;
            //        }

            //    }
            //    if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "HwA", null) != null)
            //    {
            //        string _hwa = key.GetValue("HwA").ToString();
            //        if (_hwa == "true")
            //        {
            //            kryptonCheckButton4.Checked = true;

            //        }
            //        else
            //        {
            //            kryptonCheckButton4.Checked = false;
            //        }
            //    }
            //     if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "NormalMouse", null) != null)
            //    {
            //        string _normalmouse = key.GetValue("NormalMouse").ToString();
            //        if (_normalmouse == "true")
            //        {
            //            kryptonCheckButton3.Checked = true;

            //        }
            //        else
            //        {
            //            kryptonCheckButton3.Checked = false;
            //        }
            //    }
             
            //}

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();
                    getaoe2path.Text = aoe2path;
                    //Game Check
                    if (!File.Exists(aoe2path + "\\Age2_x1\\age2_x1.exe"))
                    {
                        //KryptonMessageBox.Show("Age of Empires 2 Not Found! Would You Like To Use HDToAoC To Build The Game From Age of Empires 2 HD on Steam?", "Game Not Found!");
                        DialogResult dialogResult = KryptonMessageBox.Show("Age of Empires 2 Not Found!\n\nWould You Like To Use HDToAoC To Build The Game From Age of Empires 2 HD on Steam?", "Game Not Found!", MessageBoxButtons.YesNo, _mbIcon2);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try { Process.Start(Directory.GetCurrentDirectory() + "\\HDToAoC.exe"); this.Close(); }
                            catch (SystemException) { }
                            
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            try { Process.Start(Directory.GetCurrentDirectory() + "\\Launcher.exe"); this.Close(); }
                            catch (SystemException) { }
                            
                        }
                    }
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
                else if (key == null)
                {
                    KryptonMessageBox.Show("AoE2Tools is misconfigured or age of empires 2 not found!\n\n Click Ok To Run The Launcher To Fix The Problem.", "Auto Helper!");
                    try { Process.Start(Directory.GetCurrentDirectory() + "\\Launcher.exe"); this.Close(); }
                    catch (SystemException) { }
                }
            }

            if (!File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.5.exe") || !File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.4.exe"))
            {
                try
                {
                    
                    ApplyHotfix();
                    KryptonMessageBox.Show("Automatic Hotfix Applied!", "AoE2Tools Auto Fix!");
                }
                catch (SystemException)
                {

                }
            }
        }
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
        public static string rndstr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (vooblyend() == false)
            {
                timer1.Stop();
                string VTMPU = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-update.exe";

                KryptonMessageBox.Show("Please Apply Voobly Lobby Update To Avoid Restarting Voobly", "Voobly Lobby Update");
                Process myProcess2 = new Process();
                myProcess2.StartInfo.FileName = VTMPU;
                myProcess2.StartInfo.Verb = "Print";
                myProcess2.StartInfo.CreateNoWindow = false;
                myProcess2.StartInfo.Arguments = "/VERYSILENT";
                myProcess2.EnableRaisingEvents = true;
                //myProcess.Exited += new EventHandler(myProcess_Exited);
                //myProcess.Start();
                System.Diagnostics.Process.Start(VTMPU, "/VERYSILENT");

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
            string VTMPU = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-update.exe";
            string V64bit = Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Voobly\\voobly.exe";
            string V32bit = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + "\\Voobly\\voobly.exe";
            if (File.Exists(V32bit))
            {

                //File.Copy("voobly-update.exe", Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + "\\Voobly\\voobly-update.exe");
                string vooblyupdate = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%") + "\\Voobly\\", "voobly-update.exe");
                System.Diagnostics.Process.Start(VTMPU, "/VERYSILENT");
                timer1.Stop();
            }
            else if (File.Exists(V64bit))
            {
                //File.Copy("voobly-update.exe", Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Voobly\\voobly-update.exe");
                string vooblyupdate = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramW6432%") + "\\Voobly\\", "voobly-update.exe");
                System.Diagnostics.Process.Start(VTMPU, "/VERYSILENT");
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

                
                vooblbl.StateCommon.ShortText.Color1 = Color.Green;
                vooblbl.Text = "Done...";
                System.Threading.Thread.Sleep(1500);
                vooblbl.Visible = false;
                vooblink.Visible = false;
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

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {
                        

                        System.Diagnostics.Process.Start(aoe2path + "\\Random\\");
                    }
                }
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
            VooblyMods voobmods = new VooblyMods();
            voobmods.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
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

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
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
                            if (gamever.Text == "WK")
                            {
                                if (Directory.Exists(aoe2path + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame"))
                                System.Diagnostics.Process.Start(aoe2path +  "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame");
                            }
                            else
                            {
                                System.Diagnostics.Process.Start(aoe2path + "\\SaveGame");
                            }
                            
                        }
                        catch { }

                    }
                }
            }
        }

        private void recentreplay_Click(object sender, EventArgs e)
        {
            topme.Checked = false;
            RecentReplay recentrepl = new RecentReplay();
            recentrepl.ShowDialog();
        }

        private void topme_CheckedChanged(object sender, EventArgs e)
        {
            if (topme.Checked == true)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
            kryptonLabel1.Visible = false;
            linkLabel1.Visible = false;
            WololoInstaller wk = new WololoInstaller();
            wk.ShowDialog();
        }

        private void panel29_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Menugen();
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
            browse.Click += new EventHandler(Tools_Click);

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
            tools.Click += new EventHandler(Tools_Click);
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

            //-UserPatch

            ToolStripItem userpatch = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add("UserPatch ");
            userpatch.Click += new EventHandler(userpatch_Click);
            userpatch.Image = Properties.Resources.upico;

            //--Run Version
            ToolStripItem runversion = contexMenuuu.Items.Add("Run Version ");
            runversion.Image = Properties.Resources.gold_cd;
            runversion.Click += new EventHandler(RunVer_Click);





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

            //Settings
            ToolStripItem options = contexMenuuu.Items.Add("Options ");
            options.Click += new EventHandler(options_Click);

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

        private void RunVer_Click(object sender, EventArgs e)
        {
            
        }

        private void Tools_Click(object sender, EventArgs e)
        {
           
        }

        private void userpatch_Click(object sender, EventArgs e)
        {
            if(File.Exists(getaoe2path.Text + "\\SetupAoC.exe"))
            {
                try
                {
                    Process.Start(getaoe2path.Text + "\\SetupAoC.exe");
                }
                catch (SystemException)
                {

                }
            }
            else
            {
                KryptonMessageBox.Show("UserPatch is Missing! We highly Recommend it!", "UserPatch FailFish!");
            }
        }

        private void options_Click(object sender, EventArgs e)
        {
            Options optio = new Options();
            optio.ShowDialog();
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
            if (File.Exists(getaoe2path.Text + "\\age2_x1\\age2_x1.0c.exe"))
            {
                Process.Start(getaoe2path.Text + "\\age2_x1\\age2_x1.0c.exe");
            }
        }

        private void one_Click(object sender, EventArgs e)
        {
            if (File.Exists(getaoe2path.Text + "\\age2_x1\\WK.exe"))
            {
                Process.Start(getaoe2path.Text + "\\age2_x1\\WK.exe");
            }
            else if (!File.Exists(getaoe2path.Text + "\\age2_x1\\WK.exe"))
            {
                KryptonMessageBox.Show("Wololokingdoms Not Found! \n Install WololoKingdom Offline", "WololoKingdom Not Found!");
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
        TestUI filterForm;
        void item_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            if (filterForm == null)
            {
                filterForm = new TestUI();
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

        private void panel25_DragDrop(object sender, DragEventArgs e)
        {
            try
            {

                //string[] recs = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                //MessageBox.Show("Rec: " + recs[0], "Message!");

                //rec files
                if (e.Data.GetData(DataFormats.FileDrop, false) != null && !e.Data.GetData(DataFormats.FileDrop, false).ToString().EndsWith("!"))
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

                        foreach (string rec in recs)
                        {

                            //progressBar2.Value += progressBar2.Value / recs.Count(); 
                            string _recfln = Path.GetFileName(rec);
                            File.Copy(rec, System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + customdir + "\\" + _recfln);
                        }

                        //
                        if (recs.Count() == 1)
                        {
                            //string grabrecn = customfullpath;   
                            //RecPrompt recprmt = new RecPrompt();
                            //recprmt.MyProperty = grabrecn;
                            //recprmt.GameVersion = gamever.Text;
                            //recprmt.Show();
                            progressBar2.Visible = false;
                            string grabrecdir = customfullpath;
                            string singlerecdir = customdir;
                            RecPrompt recprmt = new RecPrompt();
                            recprmt.MyProperty = grabrecdir;
                            recprmt.RecCount = recs.Count().ToString();
                            recprmt.SingleDir = singlerecdir;
                            recprmt.GameVersion = gamever.Text;
                            recprmt.Show();
                        }
                        else if (recs.Count() > 1)
                        {
                            progressBar2.Visible = false;
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

        private void panel25_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Menugen();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (this.WindowState == FormWindowState.Minimized)
            //{
                //Show();
                this.WindowState = FormWindowState.Normal;
                //notifyIcon1.Visible = false;

            //}
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void tauntcheck_Click(object sender, EventArgs e)
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
                        try
                        {
                            if (tauntcheck.Checked == true)
                            {
                                Directory.Move(tauntdir, tauntmute);

                            }
                            else if (tauntcheck.Checked == false)
                            {
                                Directory.Move(tauntmute, tauntdir);
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            KryptonMessageBox.Show("Restarting AoE2Tools as Administrator because age of empires 2 is installed in the system directory!!\n\n Use Our Game Mover Tool To Move Age of empires 2 and Avoid inconvenience in the future.", "Requires Admin Privileges!");
                            var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                            ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                            startInfo.Verb = "runas";
                            System.Diagnostics.Process.Start(startInfo);
                            Process.GetCurrentProcess().Kill();
                        }
                        catch (Exception err)
                        { throw err; }
                    }
                }
            }
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackgroundImage = Properties.Resources.LogoTopFaded;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackgroundImage = Properties.Resources.LogoTop;
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://youtu.be/FXOAxbckKVQ?t=11s");
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public async void Voobly_Check()
        {
            await Task.Run(() => BasicCheck());
            using (RegistryKey vooblycls = Registry.CurrentUser.OpenSubKey(@"Software\Classes\voobly\shell\open\command", true))
            {
                if (vooblycls != null)
                {
                    string voobpath = vooblycls.GetValue("").ToString();
                    
                    var reg = new Regex("\".*?\"");
                    var matches = reg.Matches(voobpath);
                    
                    foreach (var item in matches)
                    {
 
                        
                        if (File.Exists(item.ToString().Replace("\"", "")))
                        {
                            BeginInvoke((MethodInvoker)delegate
                            {
                                vooblypbox.Image = Properties.Resources.checkb2;
                                vooblbl.Visible = false;
                                vooblink.Visible = false;

                            });

                        }
                        else if(!File.Exists(item.ToString().Replace("\"", "")))
                        {
                            BeginInvoke((MethodInvoker)delegate
                            {
                                vooblypbox.Image = Properties.Resources.uncheckb;
                                vooblbl.Visible = true;
                                vooblink.Visible = true;
                            });
                        }

                    }
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

        }

        public async void UserPatchCheck()
        {
            await Task.Run(() => BasicCheck());
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
                else if (File.Exists(getaoe2path.Text + @"\SetupAoC.exe"))
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
            catch (SystemException)
            {

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

        public async void GameSys_Check()
        {
            await Task.Run(() => BasicCheck());
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
        public async void WololoKingdom_Check()
        {
            await Task.Run(() => BasicCheck());
            if (File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini"))
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
        public async void HDToTC_Check()
        {
            await Task.Run(() => BasicCheck());
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
                                    Process.Start(Directory.GetCurrentDirectory() + "\\AoE2Tools Mover.exe");
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
                else if (key32 != null)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = KryptonMessageBox.Show("Rage Quit AoE2Tools?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
            
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.Image = WindowsFormsApplication3.Properties.Resources.UIclose2;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Image = WindowsFormsApplication3.Properties.Resources.UIclose11;
        }

        private void panel30_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PerfTips perfti = new PerfTips();
            perfti.ShowDialog();
        }
        void ApplyHotfix()
        {
            using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                if (SetGame != null)
                {
                    string aoe2pathadm = SetGame.GetValue("AoE2Path").ToString();
                    getaoe2path.Text = aoe2pathadm;
                    var gettmpdir = System.IO.Path.GetTempPath();
                    //BeginInvoke((MethodInvoker)delegate
                    //{
                    //    progressBar1.Value = 5;
                    //});
                    byte[] bytie = File.ReadAllBytes("libc.bin");
                    byte[] result = Replace(bytie, new byte[] { 0x6b, 0x55, 0x63, 0x49, 0x37, 0x39, 0x44, 0x34, 0x73, 0x67, 0x6d, 0x4b, 0x61, 0x38, 0x6a, 0x4f, 0x33, 0x47, 0x74, 0x49, 0x70, 0x56, 0x49, 0x64, 0x53, 0x66, 0x5a, 0x7a, 0x72, 0x53, 0x6c, 0x4a, 0x77, 0x7a, 0x32, 0x52, 0x6a, 0x32, 0x31, 0x67, 0x43, 0x6a, 0x47, 0x4a, 0x39, 0x33, 0x6f, 0x72, 0x6d, 0x5a, 0x6b, 0x71, 0x32, 0x57, 0x53, 0x72, 0x67, 0x34, 0x49, 0x31, 0x79, 0x4f, 0x72, 0x44, 0x54, 0x39, 0x58, 0x77, 0x59, 0x76, 0x43, 0x7a, 0x6b, 0x35, 0x76, 0x72, 0x70, 0x4e, 0x72, 0x36, 0x68, 0x73, 0x53, 0x68, 0x30, 0x78, 0x36, 0x33, 0x75, 0x36, 0x62, 0x4f, 0x73, 0x6e, 0x35, 0x70, 0x55, 0x6d, 0x49, 0x46, 0x35, 0x69, 0x70, 0x58, 0x6c, 0x41, 0x45, 0x36, 0x78, 0x4b, 0x53, 0x4c, 0x64, 0x70, 0x50, 0x65, 0x54, 0x44, 0x70, 0x74, 0x66, 0x42, 0x4f, 0x4d, 0x56, 0x44, 0x50, 0x4f, 0x6c, 0x37, 0x61, 0x4b, 0x31, 0x6e, 0x39, 0x69, 0x4c, 0x45, 0x54, 0x36, 0x6d, 0x43, 0x44, 0x58, 0x4c, 0x51, 0x50, 0x58, 0x46, 0x66, 0x42, 0x69, 0x49, 0x4c, 0x55, 0x52, 0x31 }, new byte[] { 0x37, 0x7a, 0xbc, 0xaf, 0x27, 0x1c, 0x00, 0x04, 0x4a, 0xad, 0xfa, 0x6e, 0xec, 0xbb, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5a, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x39, 0xaf, 0x8f, 0x04, 0xe3, 0xe0, 0xbc, 0xe0, 0x4e, 0x5d, 0x00, 0x1a, 0x11, 0x02, 0xa4, 0x13, 0x47, 0x58, 0xcb, 0x06, 0x78, 0x0c, 0x99, 0x7c, 0x9d, 0x24, 0xf3, 0x6d, 0x9e, 0xfb, 0x88, 0x12, 0x2d, 0xce, 0x2b, 0xd8, 0x2a, 0x1c, 0xa5, 0x60, 0x0f, 0x72, 0xc6, 0x48, 0x93, 0x05, 0xfe, 0x12, 0xd7, 0x09, 0x42, 0x5c });
                    File.WriteAllBytes(System.IO.Path.GetTempPath() + "\\ver.bin", result);
                    //BeginInvoke((MethodInvoker)delegate
                    //{
                    //    progressBar1.Value = 10;
                    //});

                    Pregz(gettmpdir + "\\ver.bin", gettmpdir + "\\Precache\\");
                    string d = System.IO.Path.GetTempPath() + "\\Precache\\" + Properties.Resources.string1;
                    string s = File.ReadAllText(d);
                    string[] words = s.Split('X');
                    int cnt = 0;
                    //int cnt2 = 10;
                    foreach (string word in words)
                    {
                        cnt++;
                        //backgroundWorker2.ReportProgress(pgb + (cnt2 * cnt));
                        File.WriteAllText(System.IO.Path.GetTempPath() + "\\Precache\\" + cnt + Properties.Resources.string2, word);

                        string hs = File.ReadAllText(System.IO.Path.GetTempPath() + "\\Precache\\" + cnt + Properties.Resources.string2);
                        if (cnt == 1)
                        {
                            //BeginInvoke((MethodInvoker)delegate
                            //{
                            //    progressBar1.Value = 20;
                            //});

                            File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.string3, stba(hs));
                        }

                        else if (cnt == 2)
                        {
                            //BeginInvoke((MethodInvoker)delegate
                            //{
                            //    progressBar1.Value = 40;
                            //});

                            File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.string4, stba(hs));
                        }

                        else if (cnt == 3)
                        {
                            //BeginInvoke((MethodInvoker)delegate
                            //{
                            //    progressBar1.Value = 60;
                            //});

                            File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.string5, stba(hs));
                        }


                        //clear


                    }

                    if (Directory.Exists(System.IO.Path.GetTempPath() + @"\Precache\"))
                        Directory.Delete(System.IO.Path.GetTempPath() + @"\Precache\", true);
                    if (File.Exists(System.IO.Path.GetTempPath() + @"\ver.bin"))
                    {
                        File.Delete(System.IO.Path.GetTempPath() + @"\ver.bin");
                    }
                    //BeginInvoke((MethodInvoker)delegate
                    //{
                    //    progressBar1.Value = 100;
                    //});



                }
            }
            
            //Thread.Sleep(2000);
        }

        //
        public void Pregz(string sourceArchive, string destination)
        {
            string zPath = "ver.exe";
            try
            {
                ProcessStartInfo pro = new ProcessStartInfo();
                pro.WindowStyle = ProcessWindowStyle.Hidden;
                pro.FileName = zPath;
                pro.Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", sourceArchive, destination);
                Process x = Process.Start(pro);
                x.WaitForExit();
            }
            catch (System.Exception Ex)
            {
                throw Ex;

            }
        }
        public static byte[] stba(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        private static byte[] Replace(byte[] input, byte[] pattern, byte[] replacement)
        {
            if (pattern.Length == 0)
            {
                return input;
            }

            List<byte> result = new List<byte>();

            int i;

            for (i = 0; i <= input.Length - pattern.Length; i++)
            {
                bool foundMatch = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (input[i + j] != pattern[j])
                    {
                        foundMatch = false;
                        break;
                    }
                }

                if (foundMatch)
                {
                    result.AddRange(replacement);
                    i += pattern.Length - 1;
                }
                else
                {
                    result.Add(input[i]);
                }
            }

            for (; i < input.Length; i++)
            {
                result.Add(input[i]);
            }

            return result.ToArray();
        }

        private void verswitchbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(verswitchbox.Text == "1.0C")
            {
                if (File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.0c.exe"))
                {
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.0c.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To 1.0C", "AoE2Tools Version Switcher");
                }
           
            }
            else if (verswitchbox.Text == "1.4RC")
            {
                if (File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.4.exe"))
                {
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.4.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To 1.4 RC", "AoE2Tools Version Switcher");
                }
             
            }
            else if (verswitchbox.Text == "1.5RC")
            {
                if (File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.5.exe"))
                {
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.5.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To 1.5 RC", "AoE2Tools Version Switcher");
                }
             
            }
            else if (verswitchbox.Text == "WK")
            {
                if(File.Exists(getaoe2path.Text + "\\Age2_x1\\WK.exe"))
                {
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\WK.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To WololoKingdoms", "AoE2Tools Version Switcher");
                }
                else
                {
                    KryptonMessageBox.Show("Please Install WololoKingdoms!", "AoE2Tools Version Switcher");
                }
               
            }
            
        }

        private void offlinemodsbtn_Click(object sender, EventArgs e)
        {
            topme.Checked = false;
            ModsOffline modsoff = new ModsOffline();
            modsoff.ShowDialog();
        }

        private void hotkeysbtn_Click(object sender, EventArgs e)
        {
            topme.Checked = false;
            Hotkeys hotkizz = new Hotkeys();
            hotkizz.ShowDialog();
        }

        private void replaypackbtn_Click(object sender, EventArgs e)
        {
            topme.Checked = false;
            ReplaysPacker repackerino = new ReplaysPacker();
            repackerino.ShowDialog();
        }

        private void gamemoverbtn_Click(object sender, EventArgs e)
        {
            topme.Checked = false;
          try
          {
              Process.Start(Directory.GetCurrentDirectory() + "\\AoE2Tools Mover.exe");
          }
            catch(SystemException)
          {
              
          }
        }

        private void wikilinksbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void wikilinksbox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(wikilinksbox.Text.Contains("="))
            {

            }
            else if (wikilinksbox.Text == "Maps")
            {
                try
                {
                    Process.Start("http://aok.heavengames.com/blacksmith/lister.php?category=random");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "AIs")
            {
                try
                {
                    Process.Start("http://aok.heavengames.com/blacksmith/lister.php?category=ai");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "Voobly Center")
            {
                try
                {
                    Process.Start("https://www.voobly.com/pages/view/help");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "Aoezone")
            {
                try
                {
                    Process.Start("https://www.aoezone.net/");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "Reddit")
            {
                try
                {
                    Process.Start("https://www.reddit.com/r/aoe2/");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "Voobly Forums")
            {
                try
                {
                    Process.Start("https://www.voobly.com/forum");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "Steam Forums")
            {
                try
                {
                    Process.Start("https://steamcommunity.com/app/221380/discussions/");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "Voobly")
            {
                try
                {
                    Process.Start("https://www.voobly.com/");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "Steam")
            {
                try
                {
                    Process.Start("https://store.steampowered.com/app/221380/Age_of_Empires_II_HD/");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "GameRanger")
            {
                try
                {
                    Process.Start("https://www.gameranger.com/");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "Hotkeys Converter")
            {
                try
                {
                    Process.Start("https://aokhotkeys.appspot.com/");
                }
                catch (SystemException)
                {

                }
            }
            else if (wikilinksbox.Text == "AgeOfNotes")
            {
                try
                {
                    Process.Start("https://ageofnotes.com/");
                }
                catch (SystemException)
                {

                }
            }
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {
           
        }

    }
}

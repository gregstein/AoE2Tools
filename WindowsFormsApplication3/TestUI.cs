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
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Resources;
using System.Security.Principal;
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
        public string updatever;
        public bool wkofflineDone = false;
        public bool generated = false;
        
        public TestUI()
        {

            InitializeComponent();
            
            backgroundWorker1.RunWorkerAsync();
            
        }
        public System.Timers.Timer timer = new System.Timers.Timer();
        
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
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private async void TestUI_Load(object sender, EventArgs e)
        {
            

            
            await Task.Run(() => TimerTwit());
            //VooblyHTML();
            
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
            //        File.WriteAllText(System.IO.Path.GetTempPath() + "\\wdus_d.bat", File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\perf\\wdus_d.txt"));
                    
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
            //        File.WriteAllText(System.IO.Path.GetTempPath() + "\\wdus_e.bat", File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\perf\\wdus_e.txt"));
                    
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
            
            
        }

        private void kryptonCheckButton3_Click(object sender, EventArgs e)
        {
           
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

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            //BasicCheck();
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
            await Task.Run(() => BasicCheck());
            await Task.Run(() => CheckPermition());
            await Task.Run(() => WkOffliner());
            
                int rlms = await RealmsChecker();
            
            
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams");
            }
            bool result = await CheckForInternetConnection();
            if (result == true)
            {
                await Task.Run(() => Voobly_Check());
                await Task.Run(() => UserPatchCheck());
                await Task.Run(() => GetVer());
                await Task.Run(() => WololoKingdom_Check());
                await Task.Run(() => TwitchCnt());

                
                
                //Task.Run(() => TwitchAlert());
               
               

                //TwitchCnt();
            }
          

            await Task.Run(() => FixAsso());
            await Task.Run(() => HDToTC_Check());
            
            
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            //{
            //    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
            //    {
            //        string aoe2path = key.GetValue("AoE2Path").ToString();


            //        if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\AoE2Tools", "Alerts", null) == null)
            //        {

            //        }
            //        else if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\AoE2Tools", "Alerts", null) != null)
            //        {
            //            string alerts = key.GetValue("Alerts").ToString();
            //            //Game Check
            //            if (alerts == "false")
            //            {
            //               //enabled alerts
            //                CheckPermition();
            //            }
            //            else
            //            {
            //                //disabled alerts
            //            }
            //        }
            //    }
            //}
          
        }
        public async void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            await Task.Run(() => TwitchAlert());
            //this.Invoke(new Action(() =>
            //{
            //    //Task.Run(() => TwitchCnt());
                
            //    //Task.Run(() => TwitchCnt());
            //    //TwitchAlert();
            //}));
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp"))
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "10000");
            }
            System.Timers.Timer timer = new System.Timers.Timer();

            if (File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp") == "Never (Disable)")
            {
                timer.Stop();
                timer.Enabled = false;
                timer.Start();
            }
            timer.Stop();
            timer.Interval = Int32.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp"));
            timer.Start();

            
               
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
            File.Copy(recfl, originfln);
            //string grabrecn = originfln;
            topme.Checked = false;
            string grabext = ".mgz";
            RecPrompt recprmt = new RecPrompt();
            recprmt.Grabext = grabext;
            recprmt.MyProperty = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\Rec-" + saffix;
            recprmt.GameVersion = gamever.Text;
            recprmt.FileName = Path.GetFileName(originfln);
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
        public async void BasicCheck()
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
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "version.txt"))
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    appversion.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "version.txt");
                });
               
            }
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();
                    
                    getaoe2path.Text = aoe2path;
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Alerts", null) == null)
                    {
                       
                    }
                    else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Alerts", null) != null)
                    {
                        string alerts = key.GetValue("Alerts").ToString();
                        //Game Check
                        if (!File.Exists(aoe2path + "\\Age2_x1\\age2_x1.exe") && alerts == "false")
                        {
                            //KryptonMessageBox.Show("Age of Empires 2 Not Found! Would You Like To Use HDToAoC To Build The Game From Age of Empires 2 HD on Steam?", "Game Not Found!");
                            DialogResult dialogResult = KryptonMessageBox.Show(res_man.GetString("_agenotfound", cul), res_man.GetString("_gamenotfound", cul), MessageBoxButtons.YesNo, _mbIcon2);
                            if (dialogResult == DialogResult.Yes)
                            {
                                try { Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\HDToAoC.exe"); this.Close(); }
                                catch (SystemException) { }

                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                //try { Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Launcher.exe"); this.Close(); }
                                //catch (SystemException) { }

                            }
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
                else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) == null)
                {


                    KryptonMessageBox.Show(res_man.GetString("_misconfig", cul) + "\n\n" + res_man.GetString("_tryreset", cul), "Help!");
                    //try { Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Launcher.exe"); this.Close(); }
                    //catch (SystemException) { }
                }
            }

            if ((!File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.5.exe") || !File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.4.exe")) && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
            {

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                {
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                    {
                        string aoe2path = key.GetValue("AoE2Path").ToString();


                        if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Alerts", null) == null)
                        {

                            try
                            {

                                BeginInvoke((MethodInvoker)delegate
                                {
                                    DialogResult dialogResult = KryptonMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, res_man.GetString("_hotfixrequiem", cul), "Important!", MessageBoxButtons.YesNo, _mbIcon2);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        Task.Run(() => ApplyHotfix());

                                        KryptonMessageBox.Show("Hotfix Success!", "Success!");
                                    }
                                    else
                                    {

                                    }
                                });


                            }
                            catch (SystemException)
                            {

                            }
                        }
                        else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Alerts", null) != null)
                        {
                            string alerta = key.GetValue("Alerts").ToString();
                            
                            //Game Check
                            if (alerta == "false")
                            {
                                try
                                {
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        DialogResult dialogResult = KryptonMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, res_man.GetString("_hotfixrequiem", cul), "Important!", MessageBoxButtons.YesNo, _mbIcon2);
                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            Task.Run(() => ApplyHotfix());
                                            
                                            KryptonMessageBox.Show("Hotfix Success!", "Success!");
                                        }
                                        else
                                        {

                                        }
                                    });
                                    

                       


                                }
                                catch (SystemException)
                                {
                                   
                                }
                            }
                            else
                            {
                                                           
                     
                            }

                        }
                    }
                }
 
            }
            //Regenerate WK 
            if (appversion.Text == "3.2.0.0" && File.Exists(getaoe2path.Text + "\\Games\\WK.xml") && Directory.Exists(getaoe2path.Text + "\\Games\\WololoKingdoms") && !File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wk.tmp")))
            {
                try
                {
                    
                    KryptonMessageBox.Show("WK Offline Update! It takes 2 seconds to build. \n You must click Yes on the next prompt screen.", "WK Offline Auto Builder");
                    Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WkOfflineFix.exe"));
                }
                catch(SystemException)
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
            
            if(gamever.Text.Contains("WK"))
            {
                System.Diagnostics.Process.Start(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\Script.Rm");
                
            }
            else
            {
                System.Diagnostics.Process.Start(getaoe2path.Text + "\\Random\\");
            }
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            //{
            //    if (key != null)
            //    {
            //        string aoe2path = key.GetValue("AoE2Path").ToString();

            //        //Object o = key.GetValue("Language");
            //        if (aoe2path != null)
            //        {
                        

            //            System.Diagnostics.Process.Start(aoe2path + "\\Random\\");
            //        }
            //    }
            //}
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (gamever.Text.Contains("WK"))
            {
                System.Diagnostics.Process.Start(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\Script.Ai");
                
            }
            else
            {
                System.Diagnostics.Process.Start(getaoe2path.Text + "\\Random\\");
            }
            //topme.Checked = false;
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            //{
            //    if (key != null)
            //    {
            //        string aoe2path = key.GetValue("AoE2Path").ToString();

            //        //Object o = key.GetValue("Language");
            //        if (aoe2path != null)
            //        {
            //            try
            //            {
            //                System.Diagnostics.Process.Start(aoe2path + "\\Ai\\");
            //            }
            //            catch { }
            //        }
            //    }
            //}
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            topme.Checked = false;
            VooblyMods voobmods = new VooblyMods();
            voobmods.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (gamever.Text.Contains("WK"))
            {
                System.Diagnostics.Process.Start(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\");

            }
            else
            {
                System.Diagnostics.Process.Start(getaoe2path.Text);
            }
            //topme.Checked = false;
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            //{
            //    if (key != null)
            //    {
            //        string aoe2path = key.GetValue("AoE2Path").ToString();

            //        //Object o = key.GetValue("Language");
            //        if (aoe2path != null)
            //        {

            //            try
            //            {
            //                System.Diagnostics.Process.Start(aoe2path);
            //            }
            //            catch { }
            //        }
            //    }
            //}
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
                            if (gamever.Text == "WK 5.7.2" || gamever.Text == "WK 5.7.4" || gamever.Text == "WK 5.8.1")
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
            try
            {
                Process.Start(Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "WK Cloud Installer.exe"));
            }
            catch (SystemException)
            {

            }
            //WololoInstaller wk = new WololoInstaller();
            //wk.ShowDialog();
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

           
            ContextMenuStrip contexMenuuu = new ContextMenuStrip();
            //--Show
            ToolStripItem item = contexMenuuu.Items.Add(res_man.GetString("_show", cul) + " ");
            item.Click += new EventHandler(item_Click);
            //--Browse

            ToolStripItem browse = contexMenuuu.Items.Add(res_man.GetString("_browse", cul) + " ");
            browse.Image = Properties.Resources.browse;
            browse.Click += new EventHandler(Tools_Click);

            //-Game Folder

            ToolStripItem gamedir = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Game Folder");
            gamedir.Image = Properties.Resources.browse;
            gamedir.Click += new EventHandler(Gamedir_Click);

            //-SaveGame

            ToolStripItem savegame = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_savegame", cul));
            savegame.Image = Properties.Resources.Save;
            savegame.Click += new EventHandler(Savegame_Click);

            //-Ai

            ToolStripItem ai = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_ai", cul));
            ai.Image = Properties.Resources.Script;
            ai.Click += new EventHandler(Ai_Click);

            //-Maps

            ToolStripItem maps = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_maps", cul));
            maps.Image = Properties.Resources.world;
            maps.Click += new EventHandler(Maps_Click);

            //-Scenario
            ToolStripItem scenario = (contexMenuuu.Items[1] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_scenario", cul));
            scenario.Image = Properties.Resources.replaypack;
            scenario.Click += new EventHandler(Scenario_Click);


            //--Tools
            ToolStripItem tools = contexMenuuu.Items.Add(res_man.GetString("_tools", cul) + " ");
            tools.Image = Properties.Resources.tools;
            tools.Click += new EventHandler(Tools_Click);


            //-Replays Packer

            ToolStripItem replayspacker = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_replayspacker", cul) + " ");
            replayspacker.Click += new EventHandler(replayspacker_Click);
            replayspacker.Image = Properties.Resources.archiveit1;
            //-Game Mover

            ToolStripItem gamemover = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_gamemover", cul) + " ");
            gamemover.Click += new EventHandler(gamemover_Click);
            gamemover.Image = Properties.Resources.mover;

            //-Offline Mods

            ToolStripItem offlinemods = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_offlinemods", cul) + " ");
            offlinemods.Click += new EventHandler(offlinemods_Click);
            offlinemods.Image = Properties.Resources.Save_color;

            //-Hotkeys

            ToolStripItem hotkeys = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_hotkeys", cul) + " ");
            hotkeys.Click += new EventHandler(hotkeys_Click);
            hotkeys.Image = Properties.Resources.keyboard_key_h;

            //-WololoInstaller

            ToolStripItem wololoinstaller = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add(res_man.GetString("_wkinstaller", cul) + " ");
            wololoinstaller.Click += new EventHandler(wololoinstall_Click);
            wololoinstaller.Image = Properties.Resources.wololokingdoms;

            //-UserPatch

            ToolStripItem userpatch = (contexMenuuu.Items[2] as ToolStripMenuItem).DropDownItems.Add("UserPatch ");
            userpatch.Click += new EventHandler(userpatch_Click);
            userpatch.Image = Properties.Resources.upico;

            //--Run Version
            ToolStripItem runversion = contexMenuuu.Items.Add(res_man.GetString("_runversion", cul) + " ");
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

            //Realms
            ToolStripItem rms = (contexMenuuu.Items[3] as ToolStripMenuItem).DropDownItems.Add("Realms ");
            rms.Click += new EventHandler(rms_Click);
            rms.Image = Properties.Resources.aoe2_2;

            //Forgotten
            ToolStripItem fe = (contexMenuuu.Items[3] as ToolStripMenuItem).DropDownItems.Add("FE ");
            fe.Click += new EventHandler(fe_Click);
            fe.Image = Properties.Resources.aoe2_2;

            //--Dr. Voobly 
            ToolStripItem drvoobly = contexMenuuu.Items.Add("Voobly Medkit" + " ");
            drvoobly.Image = Properties.Resources.vooblykit;
            drvoobly.Click += new EventHandler(DrVoobly_Click);


            //--Cloud
            ToolStripItem wkcloud = contexMenuuu.Items.Add("WK Cloud Installer" + " ");
            wkcloud.Image = Properties.Resources.cloud;
            wkcloud.Click += new EventHandler(wkcloud_Click);

            //--Support
            ToolStripItem support = contexMenuuu.Items.Add(res_man.GetString("_supports", cul) + " ");
            support.Click += new EventHandler(Support_Click);

            //Settings
            ToolStripItem options = contexMenuuu.Items.Add(res_man.GetString("_options", cul) + " ");
            options.Click += new EventHandler(options_Click);

            //--Exit
            ToolStripItem exit = contexMenuuu.Items.Add(res_man.GetString("_exit", cul) + " ");
            exit.Click += new EventHandler(Exit_Click);


            //END

            //contexMenuuu.Show(this, this.PointToClient(MousePosition));
            //notifyIcon1.ContextMenuStrip.Show(this, new Point(Cursor.Position.X, Cursor.Position.Y));

            

            //notifyIcon1.ContextMenuStrip.Show(Cursor.Position); 
            //contexMenuuu.Show(Control.MousePosition);
            //contexMenuuu.Dispose();
            contexMenuuu.Show(Cursor.Position);
            
        }

        private void fe_Click(object sender, EventArgs e)
        {
            if (File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x2.exe"))
            {
                try
                {
                    Process.Start(getaoe2path.Text + "\\Age2_x1\\age2_x2.exe");
                }
                catch (SystemException)
                {

                }
            }
            else
            {
                KryptonMessageBox.Show("Forgotten Empires is Missing!", "Forgotten Empires FailFish!");
            }
        }

        private void rms_Click(object sender, EventArgs e)
        {
            if (File.Exists(getaoe2path.Text + "\\Age2_x1\\Realms.exe"))
            {
                try
                {
                    Process.Start(getaoe2path.Text + "\\Age2_x1\\Realms.exe");
                }
                catch (SystemException)
                {

                }
            }
            else
            {
                KryptonMessageBox.Show("Realms is Missing!", "Realms FailFish!");
            }
        }

        private void DrVoobly_Click(object sender, EventArgs e)
        {
            DrVoobly vooblyvaccine = new DrVoobly();
            vooblyvaccine.ShowDialog();
        }

        private void Gamedir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(getaoe2path.Text);
            }
            catch(SystemException)
            {

            }
            
        }

        private void wkcloud_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WK Cloud Installer.exe");
            }
            catch (SystemException)
            {

            }
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
           
                timer.Enabled = false;
                timer.Stop();
            optio.ShowDialog();
            if (File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp") != "Never (Disable)")
            {
                timer.Interval = Int32.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp"));
                timer.Enabled = true;
                timer.Start();
            }
            



            //optio.FormClosing += (obj, args) =>
            //{
            //    timer.Enabled = false;
            //    timer.Stop();
              
            //};
            
        }

        private void gamemover_Click(object sender, EventArgs e)
        {
            try {
            Process.Start("AoE2Tools Mover.exe");
              }
                catch (SystemException)
                {

                }
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
        //TestUI filterForm;
        void item_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            this.WindowState = FormWindowState.Normal;
            this.Show();
            notifyIcon1.Visible = true;

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
                            recprmt.FileName = Path.GetFileName(recs[0]);
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
            //if (TestUI.ActiveForm.WindowState == FormWindowState.Minimized)
            //{
                
                this.WindowState = FormWindowState.Normal;
                this.Show();
                notifyIcon1.Visible = true;

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

        public void Voobly_Check()
        {
            try
            {
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
                            else if (!File.Exists(item.ToString().Replace("\"", "")))
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
            catch(SystemException)
            {

            }
           
           

        }
        public async void VooblyHTML()
        {
 try
 {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt"))
            {
                string urlAddress = "https://www.voobly.com/gamemods/mod/631/v15-Beta-R6";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = await readStream.ReadToEndAsync();
                    response.Close();
                    readStream.Close();


                    string pattern = @"<h2\s*(.+?)\s*>\s*(.+?)\s*</h2>";
                    Regex rgx = new Regex(pattern);
                    int cnty = 0;
                    foreach (Match match in rgx.Matches(data))
                    {
                        cnty++;
                        if (cnty < 3)
                        {
                            continue;
                        }
                        else if (cnty == 3)
                        {
                            string newmat = match.Value[20].ToString() + match.Value[21].ToString() + match.Value[22].ToString() + match.Value[23].ToString();

                            
                            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt", newmat);


                        }
                        else if (cnty > 3)
                        {
                            break;
                        }


                    }
                }
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt"))
            {
                FileInfo fileInfo = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt");
                bool myCheck = fileInfo.CreationTime < DateTime.Now.AddHours(-24);
                //bool myCheck = fileInfo.CreationTime < DateTime.Now.AddSeconds(-1);
                if (myCheck == true)
                {
                    try
                    {

                  
                    //Expired Cache (24 hours)
                    string urlAddress = "https://www.voobly.com/gamemods/mod/631/v15-Beta-R6";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = null;

                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }

                        string data = await readStream.ReadToEndAsync();
                        response.Dispose();
                        readStream.Dispose();
                        response.Close();
                        readStream.Close();


                        string pattern = @"<h2\s*(.+?)\s*>\s*(.+?)\s*</h2>";
                        Regex rgx = new Regex(pattern);
                        int cnty = 0;
                        foreach (Match match in rgx.Matches(data))
                        {
                            cnty++;
                            if (cnty < 3)
                            {
                                continue;
                            }
                            else if (cnty == 3)
                            {
                                string newmat = match.Value[20].ToString() + match.Value[21].ToString() + match.Value[22].ToString() + match.Value[23].ToString();

                                try
                                {
                                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt", newmat);
                                }
                                catch(System.IO.IOException)
                                {

                                }
                                catch (SystemException)
                                {

                                }
                                
                                

                            }
                            else if (cnty > 3)
                            {
                                break;
                            }


                        }
                    }
                    else
                    {

                    }
                    //KryptonMessageBox.Show("24 hours old!", "MSG");
                    }
                    catch (System.Net.WebException)
                    {

                    }
                    catch (SystemException)
                    {

                    }
                //ends here
                }
                else if (myCheck == false)
                {

                    //KryptonMessageBox.Show("New", "MSG");
                }
            }
        }
            catch(SystemException)
            {

            }
        }

        public async void UserPatchCheck()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //getaoe2path.Text = aoe2path;
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Alerts", null) == null)
                    {
                        //Begin UserPatch
                        await Task.Run(() => VooblyHTML());
                        try
                        {
                            if (!File.Exists(getaoe2path.Text + @"\SetupAoC.exe") && getaoe2path.Text != "")
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    uppbox.Image = Properties.Resources.uncheckb;

                                    userpatchlbl.Text = userpatchlbl.Text = res_man.GetString("_userpatchnotfound", cul); ;
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
                                //make sure task ends
                                bool checkb = false;
                                try
                                {
                                    await Task.Run(() => VooblyHTML());
                                }
                                catch (SystemException)
                                {
                                    checkb = true;
                                }
                                if (checkb)
                                {
                                    //nothing
                                }
                                else
                                {
                                    //task success, go on..
                                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt"))
                                    {
                                        string VooblyB = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt");
                                        if (upbuild != "" && curbuild2 != "" && upbuild != curbuild2 && Int32.Parse(VooblyB) != null && Int32.Parse(VooblyB) > Int32.Parse(curbuild2))
                                        {

                                            Invoke((MethodInvoker)delegate
                                            {
                                                uppbox.Image = Properties.Resources.uncheckb;
                                                userpatchlbl.Visible = true;
                                                uplink.Visible = true;
                                            });


                                        }

                                        else
                                        {
                                            //Ignore
                                            Invoke((MethodInvoker)delegate
                                            {
                                                uppbox.Image = Properties.Resources.checkb2;
                                                userpatchlbl.Visible = false;
                                                uplink.Visible = false;
                                            });
                                        }
                                    }
                                }


                            }


                        }
                        catch (SystemException)
                        {
                            //swallow
                        }
                        //ENd Userpatch
                    }
                    else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Alerts", null) != null)
                    {
                        string alerts = key.GetValue("Alerts").ToString();
                        //Game Check
                        if (alerts == "false")
                        {
                          //Begin UserPatch
                            await Task.Run(() => VooblyHTML());
                            try
                            {
                                if (!File.Exists(getaoe2path.Text + @"\SetupAoC.exe") && getaoe2path.Text != "")
                                {
                                    Invoke((MethodInvoker)delegate
                                    {
                                        uppbox.Image = Properties.Resources.uncheckb;

                                        userpatchlbl.Text = userpatchlbl.Text = res_man.GetString("_userpatchnotfound", cul); ;
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
                                    //make sure task ends
                                    bool checkb = false;
                                    try
                                    {
                                        await Task.Run(() => VooblyHTML());
                                    }
                                    catch (SystemException)
                                    {
                                        checkb = true;
                                    }
                                    if (checkb)
                                    {
                                        //nothing
                                    }
                                    else
                                    {
                                        //task success, go on..
                                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt"))
                                        {
                                            string VooblyB = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\voobly.txt");
                                            if (upbuild != "" && curbuild2 != "" && upbuild != curbuild2 && Int32.Parse(VooblyB) != null && Int32.Parse(VooblyB) > Int32.Parse(curbuild2))
                                            {

                                                Invoke((MethodInvoker)delegate
                                                {
                                                    uppbox.Image = Properties.Resources.uncheckb;
                                                    userpatchlbl.Visible = true;
                                                    uplink.Visible = true;
                                                });


                                            }

                                            else
                                            {
                                                //Ignore
                                                Invoke((MethodInvoker)delegate
                                                {
                                                    uppbox.Image = Properties.Resources.checkb2;
                                                    userpatchlbl.Visible = false;
                                                    uplink.Visible = false;
                                                });
                                            }
                                        }
                                    }


                                }


                            }
                            catch (SystemException)
                            {
                                //swallow
                            }
                            //ENd Userpatch
                        }
                        else if (alerts == "true")
                        {

                        }
                    }
                }
            }


        }
        public static async Task<bool> CheckForInternetConnection()
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

        public void GameSys_Check()
        {

        }
        void AoE2ToolsUpdater()
        {
            //Get wololokingdom latest repo
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "version.txt", version);
            string aoetoolsver = "3.1.0.6";
            WebClient wk = new WebClient();
            wk.Headers.Add("user-agent", "tesft");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
            var _strwk = wk.DownloadString("https://api.github.com/repos/gregstein/AoE2Tools/releases/latest");
            
            var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
            string uptag = (string)jObject["tag_name"];
            string updatezip = (string)jObject["assets"][1]["browser_download_url"];
            
            //if (aoetoolsver != uptag)
            //{
            //    KryptonMessageBox.Show(res_man.GetString("_wkisoutdated", cul) + " " + uptag + " " + res_man.GetString("_wkendversion", cul));
            //    BeginInvoke((MethodInvoker)delegate
            //    {
            //        linkLabel1.Visible = true;
            //        kryptonLabel1.Visible = true;
            //        wololopbox.Image = Properties.Resources.uncheckb;

            //    });

            //}
        }
        string WkVersionTxt()
        {
            if (File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini"))
            {
                return File.ReadAllText(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini");

            }
            else
            {
                return "0";
            }
        }
        public async void WololoKingdom_Check()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //getaoe2path.Text = aoe2path;
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Alerts", null) == null)
                    {
                        //Begin Wololokingdoms
                        try
                        {
                            //await Task.Run(() => BasicCheck());
                            if (File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini") && getaoe2path.Text != "")
                            {
                                string wkver = await Task.Run(() => WkVersionTxt());
                                SetAllowUnsafeHeaderParsing20();
                                //Get wololokingdom latest repo
                                WebClient wk = new WebClient();
                                wk.Headers.Add("user-agent", "tesft");
                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                                ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
                                var _strwk = wk.DownloadString("https://api.github.com/repos/AoE2CommunityGitHub/WololoKingdoms/releases/latest");
                                var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
                                string wktag = (string)jObject["tag_name"];

                                if (wkver != wktag)
                                {
                                    KryptonMessageBox.Show(res_man.GetString("_wkisoutdated", cul) + " " + wktag + " " + res_man.GetString("_wkendversion", cul));
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        linkLabel1.Visible = true;
                                        kryptonLabel1.Visible = true;
                                        wololopbox.Image = Properties.Resources.uncheckb;

                                    });

                                }
                                //else if (!Directory.Exists(getaoe2path.Text + "\\WololoKingdoms " + wktag))
                                //{
                                //    KryptonMessageBox.Show(res_man.GetString("_wkinstallationdir", cul) + " \"" + getaoe2path.Text + "\\WololoKingdoms " + wktag + " " + res_man.GetString("_wkinstallationdirend", cul));
                                //    BeginInvoke((MethodInvoker)delegate
                                //    {
                                //        linkLabel1.Visible = true;
                                //        kryptonLabel1.Visible = true;
                                //        wololopbox.Image = Properties.Resources.uncheckb;

                                //    });
                                //}
                            }
                            else if (!File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini") && !File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\age2_x1.xml"))
                            {
                                //KryptonMessageBox.Show("version.ini not found at:" + getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms");
                                BeginInvoke((MethodInvoker)delegate
                                {
                                    linkLabel1.Visible = true;
                                    kryptonLabel1.Visible = true;
                                    wololopbox.Image = Properties.Resources.uncheckb;

                                });
                            }
                            //end try
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //ENd Wololokingdoms
                    }
                    else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Toolsn", "Alerts", null) != null)
                    {
                        string alerts = key.GetValue("Alerts").ToString();
                        //Game Check
                        if (alerts == "false")
                        {
                            //Begin Wololokingdoms
                            try
                            {
                                //await Task.Run(() => BasicCheck());
                                if (File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini") && getaoe2path.Text != "")
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

                                    if (wkver != wktag)
                                    {
                                        KryptonMessageBox.Show(res_man.GetString("_wkisoutdated", cul) + " " + wktag + " " + res_man.GetString("_wkendversion", cul));
                                        BeginInvoke((MethodInvoker)delegate
                                        {
                                            linkLabel1.Visible = true;
                                            kryptonLabel1.Visible = true;
                                            wololopbox.Image = Properties.Resources.uncheckb;

                                        });

                                    }
                                    //else if (!Directory.Exists(getaoe2path.Text + "\\WololoKingdoms " + wktag))
                                    //{
                                    //    KryptonMessageBox.Show(res_man.GetString("_wkinstallationdir", cul) + " \"" + getaoe2path.Text + "\\WololoKingdoms " + wktag + " " + res_man.GetString("_wkinstallationdirend", cul));
                                    //    BeginInvoke((MethodInvoker)delegate
                                    //    {
                                    //        linkLabel1.Visible = true;
                                    //        kryptonLabel1.Visible = true;
                                    //        wololopbox.Image = Properties.Resources.uncheckb;

                                    //    });
                                    //}
                                }
                                else if (!File.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\version.ini") && getaoe2path.Text != "")
                                {
                                    KryptonMessageBox.Show("version.ini not found at:" + getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms");
                                    BeginInvoke((MethodInvoker)delegate
                                    {
                                        linkLabel1.Visible = true;
                                        kryptonLabel1.Visible = true;
                                        wololopbox.Image = Properties.Resources.uncheckb;

                                    });
                                }
                                //end try
                            }
                            catch (SystemException)
                            {
                                
                            }
                            //ENd Wololokingdoms
                        }
                        else if (alerts == "true")
                        {

                        }
                    }
                }
            }
           

           

        }
        public void HDToTC_Check()
        {
            //await Task.Run(() => BasicCheck());
            //Begin
            if (File.Exists(getaoe2path.Text + @"\AoK HD.exe"))
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    kryptonLabel2.Text = "Comp. Patch";
                });
                
            }
            //using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            //using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            //{
            //    if (key64 != null)
            //    {
            //        string aoe2path = key64.GetValue("EXE Path").ToString();

            //        //Object o = key.GetValue("Language");
            //        if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe"))
            //        {
            //            //config AoE2Tools

            //            try
            //            {
            //                //Config path
            //                using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //                {
            //                    if (SetGame != null)
            //                    {


            //                        //Object o32 = key32.GetValue("InstallPath");
            //                        SetGame.SetValue("AoE2Path", aoe2path);
            //                    }
            //                }
            //                //End Config

            //                //Change Path Adviser
            //                string Select_p = aoe2path;
            //                var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            //                var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            //                if (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0)
            //                {
            //                    _mbIcon = MessageBoxIcon.Warning;
            //                    _mbButtons = MessageBoxButtons.YesNo;
            //                    DialogResult dialogResult = KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "Warning! (Optional)", _mbButtons, _mbIcon);

            //                    //KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "(Optional) Warning!");
            //                    if (dialogResult == DialogResult.Yes)
            //                    {
            //                        //Invoke Mover
            //                        Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\AoE2Tools Mover.exe");
            //                    }
            //                    else if (dialogResult == DialogResult.No)
            //                    {
            //                        //Grand Access AoE2Tools

            //                    }
            //                }
            //                //Grant Access AoE2Tools


            //            }
            //            catch (Exception yu)
            //            { throw yu; }
            //        }
            //    }
            //    else if (key32 != null)
            //    {
            //        //check 32bit
            //        string aoe2path = key32.GetValue("EXE Path").ToString();
            //        if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe"))
            //        {
            //            //config AoE2Tools

            //            try
            //            {
            //                //Config path
            //                using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //                {
            //                    if (SetGame != null)
            //                    {



            //                        SetGame.SetValue("AoE2Path", aoe2path);
            //                    }
            //                }
            //                //End Config
            //                //Change Path Adviser
            //                string Select_p = aoe2path;
            //                var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            //                var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            //                if (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0)
            //                {
            //                    _mbIcon = MessageBoxIcon.Warning;
            //                    _mbButtons = MessageBoxButtons.YesNo;
            //                    DialogResult dialogResult = KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "Warning! (Optional)", _mbButtons, _mbIcon);

            //                    //KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "(Optional) Warning!");
            //                    if (dialogResult == DialogResult.Yes)
            //                    {
            //                        //Invoke Mover

            //                    }
            //                    else if (dialogResult == DialogResult.No)
            //                    {
            //                        //Grand Access AoE2Tools

            //                    }
            //                }
            //                //Grant Access AoE2Tools


            //            }
            //            catch (Exception yu)
            //            { throw yu; }
            //        }
            //    }
            //    else if (key32 == null && key64 == null)
            //    {
            //        //Show Preconv
            //    }
            //}




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
            //this.WindowState = FormWindowState.Minimized;
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            } 
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
            DialogResult dialogResult = KryptonMessageBox.Show(res_man.GetString("_exitaoe2tools", cul), "Exit", MessageBoxButtons.YesNo);
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
                
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null && getaoe2path.Text != null && Directory.Exists(getaoe2path.Text))
                {
                    
                    string aoe2pathadm = SetGame.GetValue("AoE2Path").ToString();
                    //BeginInvoke((MethodInvoker)delegate
                    //{
                    //    getaoe2path.Text = aoe2pathadm;

                    //});
                    
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
                    //Generate binaries from UP
                    if (File.Exists(aoe2pathadm + "\\SetupAoC.exe"))
                    {
                        //Begin
                        try
                        {
                            File.Move(aoe2pathadm + @"\Age2_x1\age2_x1.5.exe", aoe2pathadm + @"\Age2_x1\age2_x1.5.exe.old");
                            File.Move(aoe2pathadm + @"\Age2_x1\WK.exe", aoe2pathadm + @"\Age2_x1\WK.exe.old");
                        }
                        catch (SystemException)
                        {

                        }
                        bool chkbinary = true;
                        try
                        {
                            //When WK is available!
                            if(File.Exists(Path.Combine(aoe2pathadm, @"Age2_x1\WK.exe")))
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                startInfo.FileName = "cmd.exe";

                                startInfo.Arguments = "/c" + "start " + "\"" + "\" " + "\"" + aoe2pathadm + "\\SetupAoC.exe" + "\"" + " -g:WK -f:22211000001111000002 -i ";
                                //startInfo.Verb = "runas";
                                process.StartInfo = startInfo;
                                process.Start();
                                process.WaitForExit();
                                process.Dispose();
                                process.Close();
                            }
                            System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
                            startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo2.FileName = "cmd.exe";

                            startInfo2.Arguments = "/c" + "start " + "\"" + "\" " + "\"" + aoe2pathadm + "\\SetupAoC.exe" + "\"" + " -f:22211000001111000002 -i";
                            //startInfo.Verb = "runas";
                            process2.StartInfo = startInfo2;
                            process2.Start();
                            process2.WaitForExit();
                            process2.Dispose();
                            process2.Close();

                            System.Diagnostics.Process process3 = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo3 = new System.Diagnostics.ProcessStartInfo();
                            startInfo3.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo3.FileName = "cmd.exe";

                            startInfo3.Arguments = "/c" + "start " + "\"" + "\" " + "\"" + aoe2pathadm + "\\SetupAoC.exe" + "\"" + " -f:22211000001111000002 -n";
                            //startInfo.Verb = "runas";
                            process3.StartInfo = startInfo3;
                            process3.Start();
                            process3.WaitForExit();
                            process3.Dispose();
                            process3.Close();

                            //File.Copy(aoe2pathadm + "\\Age2_x1\\age2_x1.exe", aoe2pathadm + "\\Age2_x1\\age2_x1.5.exe", true);
                            chkbinary = true;
                        }
                        catch (SystemException)
                        {
                            chkbinary = false;
                            try
                            {
                                File.Move(aoe2pathadm + @"\Age2_x1\age2_x1.5.exe.old", aoe2pathadm + @"\Age2_x1\age2_x1.5.exe");
                                File.Move(aoe2pathadm + @"\Age2_x1\WK.exe.old", aoe2pathadm + @"\Age2_x1\WK.exe");
                            }
                            catch (SystemException)
                            {

                            }
                        }
                        finally
                        {
                            if (chkbinary == true)
                            {
                                try
                                {
                                    //File.Copy(aoe2pathadm + "\\Age2_x1\\age2_x1.exe", aoe2pathadm + "\\Age2_x1\\age2_x1.5.exe", true);
                                    File.Delete(aoe2pathadm + @"\Age2_x1\age2_x1.5.exe.old");
                                    File.Delete(aoe2pathadm + @"\Age2_x1\WK.exe.old");
                                }
                                catch (SystemException)
                                {

                                }
                            }
                           
                        }
                        //End
                    }
                  
                    //END GENERATION




                }
            }
            
            //Start WKOffline hotfix

        }
        async Task<int> RMOffliner()
        {
            try
            {
                
                Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WkOfflineFix.exe"));
            }
            catch (SystemException)
            {

            }



            return 1;
        }
        async Task<int> RealmsChecker()
        {
            try
            {
                if ((Directory.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\Realms") && !File.Exists(getaoe2path.Text + @"\Age2_x1\Realms.exe") && generated == false) || (Directory.Exists(getaoe2path.Text + @"\Voobly Mods\AOC\Data Mods\Realms") && !File.Exists(getaoe2path.Text + @"\Games\Realms.xml") && generated == false))
                {
                    Form popup = new Form() { TopMost = true, TopLevel = true };
                    DialogResult dialogResult = MessageBox.Show(popup, "Would you like to make an offline installation of Realms? (Yes Recommended)", "Realms Expansion Detected!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int u = await RMOffliner();
                        return 0;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return 0;
                    }
                }
                return 0;
            }
            catch(SystemException)
            {
                return 0;
            }
            
        }
        //
        public void Pregz(string sourceArchive, string destination)
        {
            string zPath = AppDomain.CurrentDomain.BaseDirectory + "ver.exe";
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
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To 1.0C", "AoE2Tools Version Switcher");
                }
           
            }
            else if (verswitchbox.Text == "1.4RC")
            {
                if (File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.4.exe"))
                {
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.4.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To 1.4 RC", "AoE2Tools Version Switcher");
                }
             
            }
            else if (verswitchbox.Text == "1.5RC")
            {
                if (File.Exists(getaoe2path.Text + "\\Age2_x1\\age2_x1.5.exe"))
                {
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.5.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To 1.5 RC", "AoE2Tools Version Switcher");
                }
             
            }
            else if (verswitchbox.Text == "WK 5.7.2")
            {
                if(File.Exists(getaoe2path.Text + "\\Age2_x1\\WK.exe"))
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.2\empires2_x1_p1.dat") && File.Exists(getaoe2path.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                    {

                        File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.2\empires2_x1_p1.dat", getaoe2path.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat", true);
                    }
                    else
                    {
                        KryptonMessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.2\empires2_x1_p1.dat" + " Was not found!", "AoE2Tools Version Switcher");
                    }
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\WK.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To WololoKingdoms 5.7.2", "AoE2Tools Version Switcher");
                }
                else
                {
                    KryptonMessageBox.Show("Please Install WololoKingdoms Offline!", "AoE2Tools Version Switcher");
                }
               
            }
            else if (verswitchbox.Text == "WK 5.7.4")
            {
                if (File.Exists(getaoe2path.Text + "\\Age2_x1\\WK.exe"))
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.4\empires2_x1_p1.dat") && File.Exists(getaoe2path.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                    {

                        File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.4\empires2_x1_p1.dat", getaoe2path.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat", true);
                    }
                    else
                    {
                        KryptonMessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.7.4\empires2_x1_p1.dat" + " Was not found!", "AoE2Tools Version Switcher");
                    }
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\WK.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To WololoKingdoms 5.7.4", "AoE2Tools Version Switcher");
                }
                else
                {
                    KryptonMessageBox.Show("Please Install WololoKingdoms Offline!", "AoE2Tools Version Switcher");
                }

            }
            else if (verswitchbox.Text == "WK 5.8.1")
            {
                if (File.Exists(getaoe2path.Text + "\\Age2_x1\\WK.exe"))
                {
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.8.1\empires2_x1_p1.dat") && File.Exists(getaoe2path.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat"))
                    {

                        File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.8.1\empires2_x1_p1.dat", getaoe2path.Text + @"\Games\WololoKingdoms\Data\empires2_x1_p1.dat", true);
                    }
                    else
                    {
                        KryptonMessageBox.Show(AppDomain.CurrentDomain.BaseDirectory + @"data\patches\5.8.1\empires2_x1_p1.dat" + " Was not found!", "AoE2Tools Version Switcher");
                    }
                    byte[] passjuice = File.ReadAllBytes(getaoe2path.Text + "\\Age2_x1\\WK.exe");
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    File.WriteAllBytes(getaoe2path.Text + "\\Age2_x1\\age2_x1.exe", passjuice);
                    KryptonMessageBox.Show("Game Version Has Switched To WololoKingdoms 5.8.1", "AoE2Tools Version Switcher");
                }
                else
                {
                    KryptonMessageBox.Show("Please Install WololoKingdoms Offline!", "AoE2Tools Version Switcher");
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
              Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\AoE2Tools Mover.exe");
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
            else if (wikilinksbox.Text == "Aoetw")
            {
                try
                {
                    Process.Start("http://www.aoetw.com/");
                }
                catch (SystemException)
                {

                }
            }
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void twitchstreamz_Click(object sender, EventArgs e)
        {
            topme.Checked = false;
            TwitchStreams twitchstr = new TwitchStreams();
            twitchstr.ShowDialog();
        }
        public  void TwitchCnt()
        {
            try
            {

            //await Task.Run(() => GameSys_Check());
            //SetAllowUnsafeHeaderParsing20();
           
            using(WebClient wk = new WebClient())
            {
                wk.Headers.Add("user-agent", "tesft");
                wk.Encoding = System.Text.Encoding.UTF8;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
                var _strwk = wk.DownloadString("https://api.twitch.tv/kraken/streams/?game=Age%20of%20Empires%20II&client_id=ayaqtxd0bsfnj7w2iiryp8tnjpdqtg");
                BeginInvoke((MethodInvoker)delegate
                {

                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\" + "tlive.tmp", _strwk);
                });
                
                int _streamercnt = JToken.Parse(_strwk)["streams"].ToList().Count;
                Regex yourRegex = new Regex(@"\(([^\}]+)\)");
                string result = yourRegex.Replace(twitchstreamz.Text, "(" + _streamercnt.ToString() + ")");
                twitchstreamz.Text = result;

            }
    
            
            }
            catch (SystemException)
            {
                
            }
        }
   
        public async void TwitchAlert()
        {
            try
            {

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams");
            }
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "DisableAlerts", null) != null)
                {
                    string alts = rk.GetValue("DisableAlerts").ToString();
                    if (alts == "1")
                    {

                    }
                    else  if (alts == "0")
                    {
                        //alerts enabled
                        await Task.Run(() => TwitchCnt());
                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\" + "tlive.tmp"))
                        {
                            //Begin alerting

                            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\");

                            System.IO.FileInfo[] dirInfos = di.GetFiles("*.txt");

                            int getcount = 0;
                            //MessageBox.Show(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\snds\" + "Pling.wav");
                            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\" + "Pling.wav"))
                            {

                                if (File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\snds\" + "Pling.wav"))
                                    File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\snds\" + "Pling.wav", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\" + "Pling.wav");
                            }
                            BeginInvoke((MethodInvoker)delegate
                            {

                                var _twstr = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\" + "tlive.tmp");
                                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\" + "Pling.wav");
                                foreach (System.IO.FileInfo d in dirInfos)
                                {

                                    getcount++;
                                    int totalcount = getcount;
                                    string newn = d.Name.Replace(".txt", "");
                                    if (_twstr.Contains(newn) && !liststreams.Text.Contains(newn))
                                    {
                                        if (File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + d.Name).ElementAtOrDefault(1) == "True")
                                        {

                                            player.Play();

                                        }
                                        liststreams.Text += newn + ", ";

                                        TwitchAlertPopUp edstrm = new TwitchAlertPopUp();
                                        edstrm.GetStreamer = newn;
                                        edstrm.Show();


                                    }





                                }
                            });

                        }
                    }
                    //end
                }
                else
                { 
                    //alerts enabled
                    await Task.Run(() => TwitchCnt());
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\" + "tlive.tmp"))
                    {
                        //Begin alerting

                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\");

                        System.IO.FileInfo[] dirInfos = di.GetFiles("*.txt");

                        int getcount = 0;
                        //MessageBox.Show(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\snds\" + "Pling.wav");
                        if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\" + "Pling.wav"))
                        {

                            if (File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\snds\" + "Pling.wav"))
                                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\snds\" + "Pling.wav", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\" + "Pling.wav");
                        }
                        BeginInvoke((MethodInvoker)delegate
                        {

                            var _twstr = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\" + "tlive.tmp");
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\" + "Pling.wav");
                            foreach (System.IO.FileInfo d in dirInfos)
                            {

                                getcount++;
                                int totalcount = getcount;
                                string newn = d.Name.Replace(".txt", "");
                                if (_twstr.Contains(newn) && !liststreams.Text.Contains(newn))
                                {
                                    if (File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + d.Name).ElementAtOrDefault(1) == "True")
                                    {

                                        player.Play();

                                    }
                                    liststreams.Text += newn + ", ";

                                    TwitchAlertPopUp edstrm = new TwitchAlertPopUp();
                                    edstrm.GetStreamer = newn;
                                    edstrm.Show();


                                }





                            }
                        });

                    }
                    //end
                }
            }
            
            
        }
                catch(System.InvalidOperationException)
            {

            }
            catch (System.IO.IOException)
           {
               
           }
            catch(SystemException)
            {

            }
              
        }
    
        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            Options optio = new Options();

            timer.Enabled = false;
            timer.Stop();
            optio.ShowDialog();
            if (File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp") != "Never (Disable)")
            {
                timer.Interval = Int32.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp"));
                timer.Enabled = true;
                timer.Start();
            }
            Task.Run(() => switchlang());

        }
        public void FixAsso()
        {
            //mgz reassign
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\mgz_auto_file\shell\open\command", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\mgz_auto_file\shell\open\command", "", null) != null)
                {
                    if (rk.GetValue("").ToString().Contains("age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                    }
                    if (rk.GetValue("").ToString().Contains("Age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("Age2_x1.exe", "AoE2Tools.exe"));
                    }
                    
                    
                }

                    
                else
                {
                    //rk.DeleteValue("AoE2Tools", false);
                    
                }
                    
            }
            //mgx reassign
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\mgx_auto_file\shell\open\command", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\mgx_auto_file\shell\open\command", "", null) != null)
                {
                    if (rk.GetValue("").ToString().Contains("age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                    }
                    if (rk.GetValue("").ToString().Contains("Age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("Age2_x1.exe", "AoE2Tools.exe"));
                    }
                    
                  
                }


                else
                {
                    
                   
                }

            }
            //base reassign
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\age2.age2_x1.0\shell\Open\command", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\age2.age2_x1.0\shell\Open\command", "", null) != null)
                {
                    if (rk.GetValue("").ToString().Contains("age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                    }
                    if (rk.GetValue("").ToString().Contains("Age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("Age2_x1.exe", "AoE2Tools.exe"));
                    }
                    
                    
                }


                else
                {
                    
                    
                }

            }
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Classes\age2.age2_x1.1\shell\Open\command", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Classes\age2.age2_x1.1\shell\Open\command", "", null) != null)
                {
                    if (rk.GetValue("").ToString().Contains("age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                    }
                    if (rk.GetValue("").ToString().Contains("Age2_x1.exe"))
                    {
                        rk.SetValue("", rk.GetValue("").ToString().Replace("Age2_x1.exe", "AoE2Tools.exe"));
                    }


                }


                else
                {


                }

            }
           
        }
 public void TimerTwit()
            {
     try
     {
         if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams"))
         {
             Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams");
         }
         if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp"))
         {
             File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "10000");
         }
         System.Timers.Timer timer = new System.Timers.Timer();

         if (File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp") == "Never (Disable)")
         {
             timer.Stop();
         }
         timer.Interval = Int32.Parse(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp"));
         timer.Elapsed += timer_Elapsed;
         //timer.Dispose();

         timer.Start();
     }
     catch(SystemException)
     {
         //throw tyu;
     
     }
     

            }

 private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
 {

 }
 private static bool IsAdministrator()
 {
     WindowsIdentity identity = WindowsIdentity.GetCurrent();
     WindowsPrincipal principal = new WindowsPrincipal(identity);
     return principal.IsInRole(WindowsBuiltInRole.Administrator);
 }
        public void CheckPermition()
 {

     this.BeginInvoke(new Action(() =>
     {
         if (getaoe2path.Text != null)
         {
             try
             {
                 File.WriteAllText(getaoe2path.Text + @"\aoe2toolscheck.txt", "Intentionally Created By AoE2Tools!");
                 //System.Threading.Thread.Sleep(200);

             }
             catch (UnauthorizedAccessException)
             {
                 DialogResult dialogResult = KryptonMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Fix a Game Installation Issue?", "AoE2Tools Diagnostic!", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
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
                     catch (SystemException)
                     {

                     }
                 }
                 else
                 {

                 }
             }
             catch (SystemException)
             {

             }




         }
     }));
     
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
     try
     {
     BeginInvoke((MethodInvoker)delegate
     {


         linkLabel1.Text = res_man.GetString("_fixit", cul);
         vooblink.Text = res_man.GetString("_fixit", cul);
         uplink.Text = res_man.GetString("_fixit", cul);
     kryptonLabel1.Text = res_man.GetString("_wkmissing", cul);
     vooblbl.Text = res_man.GetString("_vooblymissing", cul);
     userpatchlbl.Text = res_man.GetString("_upmissing", cul);
     kryptonLinkLabel1.Text = res_man.GetString("_demo", cul);
     linkLabel5.Text = res_man.GetString("_open", cul);
     linkLabel4.Text = res_man.GetString("_open", cul);
     offlinemodsbtn.Text = res_man.GetString("_open", cul);
     hotkeysbtn.Text = res_man.GetString("_open", cul);
     replaypackbtn.Text = res_man.GetString("_open", cul);
     gamemoverbtn.Text = res_man.GetString("_open", cul);
     linkLabel7.Text = res_man.GetString("_mapfolder", cul);
     linkLabel8.Text = res_man.GetString("_aifolder", cul);
     linkLabel3.Text = res_man.GetString("_manage", cul);
     recentreplay.Text = res_man.GetString("_recentreplay", cul);
     btnsettings.Text = res_man.GetString("_settings", cul);
     statsbtn.Text = res_man.GetString("_manager", cul);
     topme.Text = res_man.GetString("_ontop", cul);
     //UI
        
     panel5.BackgroundImage = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\" + res_man.GetString("_recordedtab", cul));
     panel6.BackgroundImage = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\" + res_man.GetString("_gamesettingstab", cul));
     panel7.BackgroundImage = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\" + res_man.GetString("_managementtab", cul));
       

     });
                 }
            catch(System.InvalidOperationException)
            {

            }
            catch (SystemException)
            {

            }
 }
 async Task<bool> WkOffliner()
 {
     try 
     {
         if ((!Directory.Exists(getaoe2path.Text + @"\Games\WololoKingdoms") || !File.Exists(getaoe2path.Text + @"\Games\WK.xml")) && File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml"))
         {
             KryptonMessageBox.Show("WK Offline is needed! It takes 2 seconds to build. \n You must click Yes on the next prompt screen.", "WK Offline Auto Builder");
             Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WkOfflineFix.exe"));
             //Directory.CreateDirectory(getaoe2path.Text + @"\Games\WololoKingdoms\Data");
             ////Directory.CreateDirectory(getaoe2path.Text + @"\Games\WololoKingdoms\SaveGame");
             //System.Diagnostics.Process process = new System.Diagnostics.Process();
             //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
             //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
             //startInfo.Verb = "runas";
             //startInfo.FileName = "cmd.exe";
             //startInfo.Arguments = "/C mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\gamedata_x1.drs\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\gamedata_x1.drs\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\gamedata_x1_p1.drs\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\gamedata_x1_p1.drs\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\version.ini\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\version.ini\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Taunt\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Taunt\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Sound\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Sound\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Script.Rm\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Script.Rm\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Script.Ai\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Script.Ai\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Scenario\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Scenario\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Screenshots\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Screenshots\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\SaveGame\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\player1.hki\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\player1.hki\"&exit";
             //process.StartInfo = startInfo;
             //KryptonMessageBox.Show("WK Offline is needed! It takes 2 seconds to build. \n You must click Yes on the next prompt screen.","WK Offline Auto Builder");
             //process.Start();
             //string[] hkifiles = System.IO.Directory.GetFiles(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\", "*.hki");
             //File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml", getaoe2path.Text + "\\Games\\WK.xml",true);
             //File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Player.nfz", getaoe2path.Text + "\\Games\\WololoKingdoms\\Player.nfz", true);
             //File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\language.ini", getaoe2path.Text + "\\Games\\WololoKingdoms\\language.ini", true);
             //File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml", getaoe2path.Text + "\\Games\\WololoKingdoms\\age2_x1.xml", true);
             //File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\empires2_x1_p1.dat", getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\empires2_x1_p1.dat", true);
             //File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\language_x1_p1.dll", getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\language_x1_p1.dll", true);
             //foreach (string file in hkifiles)
             //{
             //    File.Copy(file, file.Replace(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\", getaoe2path.Text + "\\Games\\WololoKingdoms\\"), true);
             //}
             //Pregz(AppDomain.CurrentDomain.BaseDirectory + @"data\wk.bin", getaoe2path.Text + "\\Age2_x1\\");
             wkofflineDone = true;
             generated = true;
         }
     }
     catch(UnauthorizedAccessException)
     {
         wkofflineDone = false;
         KryptonMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "Please Run AoE2Tools As Administrator!");
     }
     catch(SystemException)
     {
         wkofflineDone = false;
         //Directory.Delete(getaoe2path.Text + @"\Games",true);
         KryptonMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "WK Offline is important! You can't watch recorded games without it. Restart AoE2Tools and let it to install.", "Warning!");
     }
     finally
     {
         try
         {
             if (wkofflineDone == true)
                 KryptonMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "WK Offline is successfully built!", "Success!");
         }
         catch(SystemException)
         { }
         
     }
     return true;
 }
 async Task<bool> GetVer()
 {
     try
     {
         bool result = await CheckForInternetConnection();
         if (result == true)
         {
             WebClient wk = new WebClient();
             wk.Headers.Add("user-agent", "AoE2Tools");
             ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
             ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
             var _strwk = wk.DownloadString("https://api.github.com/repos/gregstein/AoE2Tools/releases/latest");
             var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
             string updatename = (string)jObject["assets"][2]["name"];
             string changelogs = (string)jObject["assets"][1]["browser_download_url"];
             //string updatever = updatename.Replace("X_", "").Replace("--ignore", "");
             updaterwat.Text = updatename.Replace("X_", "").Replace("--ignore", "");
             if (changelogs.Contains("changelogs.txt"))
             {
                 try
                 {
                     //SetAllowUnsafeHeaderParsing20();
                     using (WebClient aoeup = new WebClient())
                     {
                         aoeup.Headers.Add("user-agent", "AoE2Tools Updater");
                         aoeup.Encoding = System.Text.Encoding.UTF8;
                         ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                         ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
                         aoeup.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                         aoeup.DownloadStringAsync(new Uri(changelogs));

                     }
                     return true;

                 }
                 catch (SystemException)
                 {
                     //MessageBox.Show("Your Internet is diconnected! Connect to your Internet.", "Connection Lost!");

                     //swallow error
                 }
                 return true;
             }

             return true;


         }
         else
         {
             MessageBox.Show("Internet is disconnected!");
             return false;
         }
     }
     catch(SystemException)
     {
         return false;
     }
     

 }
 static byte[] HexStringToByteArray(string hexString)
 {
     hexString = hexString.Replace("-", ""); // remove '-' symbols

     byte[] result = new byte[hexString.Length / 2];

     for (int i = 0; i < hexString.Length; i += 2)
     {
         result[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16); // base 16
     }

     return result;
 }
  void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
 {
     try
     {

         string readme = e.Result;
         var versionInfo = FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + "Updater.exe");
         if (versionInfo.ProductVersion == "1.0.0.0" || versionInfo.ProductVersion == "1.0.0.1" || versionInfo.ProductVersion == "1.0.0.2" || versionInfo.ProductVersion == "1.0.0.3")
         {
             File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "7zself", WindowsFormsApplication3.Properties.Resources.up);
             Pregz(AppDomain.CurrentDomain.BaseDirectory + "7zself", AppDomain.CurrentDomain.BaseDirectory);
             byte[] byteArray = HexStringToByteArray(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "up.txt"));
             File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Updater.exe", byteArray);
             File.Delete(AppDomain.CurrentDomain.BaseDirectory + "7zself");
             File.Delete(AppDomain.CurrentDomain.BaseDirectory + "up.txt");

         }
         if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "version.txt") && File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "version.txt") != updaterwat.Text && !updaterwat.Text.Contains("exe"))
         {
             Form popup = new Form() { TopMost = true, TopLevel = true };
             Invoke((MethodInvoker)delegate
{

    DialogResult dialogResult = MessageBox.Show(popup, readme + "\n Update now?", "AoE2Tools " + updaterwat.Text + " Update Changelogs", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {
                 Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Updater.exe");
                 Thread.Sleep(1000);
                 Process.GetCurrentProcess().Kill();
                 //do something
             }
             else if (dialogResult == DialogResult.No)
             {
                 //do something else
             }
});
             
         }
         else
         {
             //nothing
             
         }


     }

     catch (System.Reflection.TargetInvocationException)
     {
         //MessageBox.Show("Your Internet is diconnected! Connect to your Internet.", "Connection Lost!");
        
     }
     catch (SystemException)
     {
         

     }
     
 }

 private void statsbtn_Click(object sender, EventArgs e)
 {
     Stats statis = new Stats();

     statis.ShowDialog();
 }

 private void notifyIcon1_DoubleClick(object sender, EventArgs e)
 {
     if (this.WindowState == FormWindowState.Minimized)
     {

         this.WindowState = FormWindowState.Normal;
         this.Show();
         notifyIcon1.Visible = true;

     }
     //Show();
     //this.WindowState = FormWindowState.Normal;
     //notifyIcon1.Visible = false; 
 }

 private void notifyIcon1_Click(object sender, EventArgs e)
 {
     if (this.WindowState == FormWindowState.Minimized)
     {
         Show();
         this.WindowState = FormWindowState.Normal;
         notifyIcon1.Visible = true;

     }
     else
     {
         this.Hide();
         this.WindowState = FormWindowState.Minimized;
         notifyIcon1.Visible = true;
     }
 }

 private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
 {

     
 }

 private void TestUI_Activated(object sender, EventArgs e)
 {

   
 }

 private void panel25_Paint(object sender, PaintEventArgs e)
 {

 }

 private void gametweaker_Click(object sender, EventArgs e)
 {
     try
     {
         Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Game Tweaker.exe");
     }
     catch (SystemException)
     {

     }
 }

 private void panel4_Paint(object sender, PaintEventArgs e)
 {

 }


    }
}

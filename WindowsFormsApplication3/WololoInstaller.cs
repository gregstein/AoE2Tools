using Ionic.Zip;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Security.Principal;
using System.Threading;
using System.Resources;
using System.Globalization;
namespace WindowsFormsApplication3
{
    public partial class WololoInstaller : KryptonForm
    {
        public WololoInstaller()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        private int totalFiles;
        private int filesExtracted;
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private async void WololoInstaller_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());

            backgroundWorker1.RunWorkerAsync();

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

                WololoInstaller.ActiveForm.Text = res_man.GetString("_wkautoinstaller", cul);
                label1.Text = res_man.GetString("_wklatestver", cul);
                label2.Text = res_man.GetString("_wksize", cul);
                label3.Text = res_man.GetString("_wkdesc", cul);
                launchwk.Text = res_man.GetString("_wklaunch", cul);
                repotxt.Text = res_man.GetString("_wkpage", cul);
                label5.Text = res_man.GetString("_wkstatus", cul);
                dnldwk.Text = res_man.GetString("_wkdownrun", cul);
                label4.Text = res_man.GetString("_wkplayhd", cul);
                

                
                
            });
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SetAllowUnsafeHeaderParsing20();
            //Get wololokingdom latest repo
WebClient wk = new WebClient();
wk.Headers.Add("user-agent", "tesft");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
                var _strwk = wk.DownloadString("https://api.github.com/repos/AoE2CommunityGitHub/WololoKingdoms/releases/latest");
                
                var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);

                
                string wkdnlnk = (string)jObject["assets"][0]["browser_download_url"];
                string wkdnlnk2 = (string)jObject["assets"][1]["browser_download_url"];
                string wktag = (string)jObject["tag_name"];
                string wkhome = (string)jObject["html_url"];
                long wksize = (long)jObject["assets"][0]["size"];
                long wksize2 = (long)jObject["assets"][1]["size"];
                string wkbody = (string)jObject["body"];
                wksizetxt.Invoke((MethodInvoker)delegate
                {
                    if (wkdnlnk.Contains(".exe"))
                    {
                        
                        wksizetxt.Text = FormatByteSize(wksize2);
                    }
                    else if (wkdnlnk.Contains(".zip"))
                    {
                        
                        wksizetxt.Text = FormatByteSize(wksize);
                    }
                    
                });
                latestver.Invoke((MethodInvoker)delegate
                {
                    latestver.Text = wktag;
                });
                desctxt.Invoke((MethodInvoker)delegate
                {
                    desctxt.Text = wkbody;
                });

                linkLabel1.Invoke((MethodInvoker)delegate
                {
                    linkLabel1.Text = "WK " + wktag;
                });

                mskdurl.Invoke((MethodInvoker)delegate
                {
                    if (wkdnlnk.Contains(".exe"))
                    {
                        mskdurl.Text = wkdnlnk2;
                    }
                    else if(wkdnlnk.Contains(".zip"))
                    {
                        mskdurl.Text = wkdnlnk;
                    }
                   
                });
              //Warner
                string Select_p = mskdwk.Text;
            var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if ((Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0) && IsAdministrator() == false)
            {
                KryptonMessageBox.Show("Restarting AoE2Tools as Administrator because age of empires 2 is installed in the system directory!!\n\n Use Our Game Mover Tool To Move Age of empires 2 and Avoid inconvenience in the future.","Requires Admin Privileges!");
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                System.Diagnostics.Process.Start(startInfo);
                Process.GetCurrentProcess().Kill();
            }
            if ((Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0) && IsAdministrator() == true)
            {

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private static string FormatByteSize(double bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "TB" };
            int index = 0;
            do { bytes /= 1024; index++; }
            while (bytes >= 1024);
            return String.Format("{0:0.00} {1}", bytes, Suffix[index]);

        }

        private void wksize_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://github.com/AoE2CommunityGitHub/WololoKingdoms/releases");
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            dnldwk.Enabled = false;
            backgroundWorker2.RunWorkerAsync();

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {

            if (!Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\")){Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"hdtotc-tmp\");}
            label5.Text = "Started";
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed2);
            webClient.DownloadFileAsync(new Uri(mskdurl.Text), System.IO.Path.GetTempPath() + @"\hdtotc-tmp\wk.zip");
            });

         

        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar1.Value = (int)e.BytesReceived / 100;
            int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) /
(double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
            using (Graphics gr = progressBar1.CreateGraphics())
            {
                gr.DrawString(percent.ToString() + "%",
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                        SystemFonts.DefaultFont).Width / 2.0F),
                    progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }

        }



        private void Completed2(object sender, AsyncCompletedEventArgs e)
        {

            //progressBar1.Value = 0;
            //Decompress
            //if (!Directory.Exists(mskdwk.Text))
            //{
            //    Directory.CreateDirectory(mskdwk.Text);
            //}
            //string rplepath = mskdwk.Text;
            //Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\wk.zip");
            //int zm = 0;
            //long lengthf = new System.IO.FileInfo(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\wk.zip").Length;
            ////int totalf = ZipFileCount(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\wk.zip");
            //foreach (ZipEntry es in zip)
            //{
                

            //    zip.ExtractProgress += ExtractProgress;
            //    es.Extract(rplepath, ExtractExistingFileAction.OverwriteSilently);

            //    //backgroundWorker2.ReportProgress(zm / totalf);

            //}
            label5.Text = "Extracting";
            progressBar1.Value = 0;
            backgroundWorker3.RunWorkerAsync();
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

        public static int ZipFileCount(String zipFileName)
        {
            using (System.IO.Compression.ZipArchive archive = System.IO.Compression.ZipFile.Open(zipFileName, ZipArchiveMode.Read))
            {
                int count = 0;

                foreach (var entry in archive.Entries)
                    if (!String.IsNullOrEmpty(entry.Name))
                        count += 1;

                return count;
            }
        }

        private void WololoInstaller_Shown(object sender, EventArgs e)
        {
            getpath();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dnldwk.Enabled = true;
            WKDetective();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
            progressBar1.Visible = false;
            progressBar2.Visible = true;
            });
            try { 
                using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\wk.zip"))
                {
                    totalFiles = zip.Count;
                    filesExtracted = 0;
                    zip.ExtractProgress += ZipExtractProgress;
                    zip.ExtractAll(mskdwk.Text, ExtractExistingFileAction.OverwriteSilently);
                }
                }
            catch(SystemException)
            {}
            
            //Invoke((MethodInvoker)delegate
            //{

            //});
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

        }

        //extract
        private void ZipExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.EventType != ZipProgressEventType.Extracting_BeforeExtractEntry)
                return;
            filesExtracted++;
            Invoke((MethodInvoker)delegate
            {
            progressBar2.Value = 100 * filesExtracted / totalFiles;
            });
        }

        private void mskdwk_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (File.Exists(mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe"))
            {
                
                
                progressBar2.Visible = false;
                label5.Text = "Success! Now Running WololoKingdoms";
                HowToWk howtowkimg = new HowToWk();
                howtowkimg.Show();
                try
                {

                    //string argument = "/select, \"" + mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe" + "\"";
                    ////var process = new Process
                    ////{

                    ////    StartInfo = new ProcessStartInfo
                    ////    {
                    ////        FileName = "popup.exe"
                    ////    }
                    ////};
                    ////process.Start();
                    ////process.WaitForExit();
                    //Process.Start("explorer.exe", argument);
                    //ProcessStartInfo psi = new ProcessStartInfo();
                    //psi.FileName = "explorer.exe";
                    //psi.Arguments = "/select, \"" + mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe" + "\"";
                    //psi.UseShellExecute = true;
                    //psi.WindowStyle = ProcessWindowStyle.Minimized;

                    //var process = Process.Start(psi);
                    //process.WaitForExit();
                    //Thread.Sleep(1000);
                    //SendKeys.Send("{ENTER}");
                    Process.Start(mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe");
                }
                catch (SystemException)
                {
                    if (File.Exists(mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe"))
                    {
                        KryptonMessageBox.Show("WololoKingdoms Will be Prompted To Run As Administrator \n We created a button for you so you can run it manually.", "Important!");
                        launchwk.Visible = true;
                    }
                    else
                     {
                         KryptonMessageBox.Show("Jineapple is noob! Or Your Internet Dropped. \n Please Try Downloading Again!", "Dad Gum!");
                         dnldwk.Enabled = true;
                    }

                }

                
            }
            else
            {
                progressBar1.Value = 0;
                KryptonMessageBox.Show("Jineapple is noob! Or Your Internet Dropped. \n Please Try Downloading Again!", "Dad Gum!");
                dnldwk.Enabled = true;
            }

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgw2.Text = "done";
            
        }

        private void launchwk_Click(object sender, EventArgs e)
        {
            try
            {
                //File.WriteAllText(mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WK.bat", "start \"\" \"" + mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe\" -s");
                //ProcessStartInfo info = new ProcessStartInfo(mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WK.bat");
                //info.UseShellExecute = false;
                ////Process.Start(mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WK.exe");
                ////info.Verb = "runas";
                //Process.Start(info);
                // combine the arguments together






                if (latestver.Text == "5.7.2")
                {
                string argument = "/select, \"" + mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe" + "\"";

                Process.Start("explorer.exe", argument);
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "explorer.exe";
                psi.Arguments = "/select, \"" + mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe" + "\"";
                psi.UseShellExecute = true;
                psi.WindowStyle = ProcessWindowStyle.Minimized;

                var process = Process.Start(psi);
                process.WaitForExit();
                Thread.Sleep(1000);
                SendKeys.Send("{ENTER}");
                }
                else
                {
                    Process.Start(mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe");
                }
                
            }
            catch (SystemException)
            {

            }
            
        }

        private void OnCloseCheck_DoWork(object sender, DoWorkEventArgs e)
        {
        
        }

        public void WKDetective()
        {
            if (File.Exists(mskdwk.Text + "\\WololoKingdoms " + latestver.Text + "\\WololoKingdoms.exe") && CheckForInternetConnection() == true)
{
    dnldwk.Enabled = false;

    launchwk.Enabled = true;
    launchwk.Visible = true;
    label5.Text = res_man.GetString("_wkmsg1", cul);
    progressBar2.Enabled = false;
    progressBar2.Visible = false;
    progressBar1.Visible = false;
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

        //private System.Windows.Forms.Timer timer1;
        //public void InitTimer()
        //{
        //    timer1 = new System.Windows.Forms.Timer();
        //    timer1.Tick += new EventHandler(timer1_Tick);
        //    timer1.Interval = 1000;
        //    timer1.Start();
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    isnotbusy();
        //}
        //public void isnotbusy()
        //{
        //    if (bgw2.Text == "done")
        //    {
        //        timer1.Stop();
        //        backgroundWorker3.RunWorkerAsync();
        //    }
        //    else
        //    {
        //        KryptonMessageBox.Show("Still busy!", "error");
        //    }

        //}
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

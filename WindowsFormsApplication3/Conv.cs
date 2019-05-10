using ComponentFactory.Krypton.Toolkit;
using Ionic.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NATUPNPLib;
using System.Net.Sockets;
namespace WindowsFormsApplication3
{
    public partial class Conv : KryptonForm
    {
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [System.Runtime.InteropServices.Out] StringBuilder lpszPath, int nFolder, bool fCreate);
        const int CSIDL_COMMON_DESKTOPDIRECTORY = 0x19;
        public string CurrentDIR = "";
        public Conv()
        {
            InitializeComponent();

        }
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        // needed so that Explorer windows get refreshed after the registry is updated
        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

        public string VTMP = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly.exe";
        public string VTMPU = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\voobly-update.exe";
        public string TMP = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\";
        public string _graphicstmp = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\graphics\";
        public string _interfactmp = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\interface\";
        public string _soundstmp = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\sounds\";
        public Process myProcess = new Process();
        public bool eventHandled;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\snds\\m1.wav");
        private int filesExtracted;
        private int totalFiles;
        public string Flag = "en";
        
        private void Conv_Load(object sender, EventArgs e)
        {
            //SteamAssets();
            
                try
                {
                    using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                    {
                        if (Skey != null)
                        {
                            string Sroot = Skey.GetValue("SteamPath").ToString();
                            var directory = new DirectoryInfo(Sroot + "\\Profiles");
                            string Hotkeyz = Skey.GetValue("SetHotkeys").ToString();
                            if (Hotkeyz == "Default (Recommended)" && Hotkeyz != null)
                            {
                                
                                if (Directory.GetFiles(Sroot + "\\Profiles", "*.hki").Length != 0)
                                {
                                    var myFile = directory.GetFiles("*.hki")
               .OrderByDescending(f => f.LastWriteTime)
               .First();
                                    
                                }
                                else
                                {
                                    KryptonMessageBox.Show("Your AoE2 HD Doesn't Have Any Hotkeys Yet! Before Starting The Conversion, Please Run HD Through Steam And Go To Options > Hotkeys Then Exit." + Environment.NewLine + "Ignore This Message If You Don't Care about Hotkeys Now Or Would Like To Set Them Up Later.");
                                }
          
                            }
                          
                        }
                    }
                        
                    
                }
                catch (SystemException)
                {
                   
                }


           
           


        }


        public void VooblyHTML()
        {
            //string urlAddress = "https://www.voobly.com/";

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    Stream receiveStream = response.GetResponseStream();
            //    StreamReader readStream = null;

            //    if (response.CharacterSet == null)
            //    {
            //        readStream = new StreamReader(receiveStream);
            //    }
            //    else
            //    {
            //        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            //    }
               
            //    string data = readStream.ReadToEnd();
            //    response.Close();
            //    readStream.Close();
                
                
            //    Regex regex = new Regex("location.href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase);
            //    string VooblyClient = Regex.Match(data, "https:(.*?).exe", RegexOptions.IgnoreCase).Groups[0].Value;

          

                    //Create Temporary Folder
                    bool NewDir = System.IO.Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp");

                    if (!NewDir)
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetTempPath() + @"\hdtotc-tmp");
                    }
                    //ServicePointManager.Expect100Continue = true;
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                   
                    WebClient webClient = new WebClient();
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    
                    webClient.DownloadFileAsync(new Uri("http://www.voobly.com/client/download"), VTMP);
                    //webClient.DownloadFileAsync(new Uri("https://www.voobly.com/updates/voobly-gamedata-aoc-v1.1.1.8.exe"), VTMPU);

                    //KryptonMessageBox.Show("Download:" + VooblyClient, "MSG");

                    
               
                //File.WriteAllText("text.txt", data);
                
                

                
            //}
        }

        public void VooblyInstaller(string Vpath)
        {

            try
            {
                string filename = Path.Combine(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\", "voobly.exe");
               
                //System.Diagnostics.Process.Start(filename, "/VERYSILENT");
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\" + "voobly.exe";
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.StartInfo.Arguments = "/VERYSILENT";
                myProcess.EnableRaisingEvents = true;
                myProcess.Exited += new EventHandler(myProcess_Exited);
                //myProcess.Start();
                System.Diagnostics.Process.Start(filename, "/VERYSILENT");
                InitTimer();
                CheckVoobup();    
               
               
                
            }
            catch
            {
                KryptonMessageBox.Show("Internet Dropped while downloading Voobly!\n\n No Worries! You can auto install Voobly Later through AoE2Tools Once The Conversion is done!","Internet dropped!");
                VooblyPic.Image = Properties.Resources.Voobly_Step1_check;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


           
        }

        private static bool VooblyProcChK(string procN)
        {

            Process[] pname = Process.GetProcessesByName(procN);
            if (pname.Length == 0)
            {

    //KryptonMessageBox.Show("nothing");
                return true;
            }
            
            else
            {
                KryptonMessageBox.Show("run");
            return false;
                }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SteamDirs();
            SteamReg();

        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar1.Value = (int)e.BytesReceived / 100;

        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            //progressBar1.Enabled = false;
            progressBar1.Value = 0;
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed2);
            webClient.DownloadFileAsync(new Uri("https://www.voobly.com/updates/voobly-gamedata-aoc-v1.1.1.8.exe"), VTMPU);
            //VooblyInstaller(VTMP);
            
                
           
            //this.Close();
        }
        private void Completed2(object sender, AsyncCompletedEventArgs e)
        {
            //progressBar1.Enabled = false;

            VooblyInstaller(VTMP);



            //this.Close();
        }




        // Handle Exited event and display process information.
        private void myProcess_Exited(object sender, System.EventArgs e)
        {

            eventHandled = true;
            KryptonMessageBox.Show("Done!", "Alert!");
            //KryptonMessageBox.Show("Exit time:    {0}\r\n" +
            //    "Exit code:    {1}\r\nElapsed time: {2}", myProcess.ExitTime, myProcess.ExitCode, elapsedTime);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //progressBar1.Minimum = 50;
            timer2.Stop();
            string V64bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Voobly\\voobly.exe";
            string V32bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Voobly\\voobly.exe";
            if (File.Exists(V32bit) || File.Exists(V64bit))
            {

                KryptonMessageBox.Show("Voobly Installed!");
            }
            else
            {
                timer2.Start();
            }
        }
        private System.Windows.Forms.Timer timer1;
        public void InitTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 5000;
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
    if (vooblyend() == false)
    {
        timer1.Stop();
        KryptonMessageBox.Show("Applying Voobly Lobby Update Now!\n No Voobly Restart Needed!", "Voobly Lobby Update");
        Process myProcess2 = new Process();
        myProcess2.StartInfo.FileName = VTMPU;
        myProcess2.StartInfo.Verb = "Print";
        myProcess2.StartInfo.CreateNoWindow = false;
        myProcess2.StartInfo.Arguments = "/VERYSILENT";
        myProcess2.EnableRaisingEvents = true;
        //myProcess.Exited += new EventHandler(myProcess_Exited);
        //myProcess.Start();
        System.Diagnostics.Process.Start(VTMPU, "/VERYSILENT");

        VooblyPic.Image = Properties.Resources.Voobly_Step1_check;
        
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
    string V64bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Voobly\\voobly.exe";
    string V32bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Voobly\\voobly.exe";
    if (File.Exists(V32bit))
    {

        //File.Copy("voobly-update.exe", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Voobly\\voobly-update.exe");
        string vooblyupdate = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Voobly\\", "voobly-update.exe");
        System.Diagnostics.Process.Start(VTMPU, "/VERYSILENT");
        timer1.Stop();
    }
    else if (File.Exists(V64bit))
    {
        //File.Copy("voobly-update.exe", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Voobly\\voobly-update.exe");
        string vooblyupdate = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Voobly\\", "voobly-update.exe");
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
    string V64bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Voobly\gamedata\aoc\age2_x1.exe";
    string V32bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Voobly\gamedata\aoc\age2_x1.exe";
    if (File.Exists(V32bit) || File.Exists(V64bit))
    {

        VooblyPic.Image = Properties.Resources.Voobly_Step1_check;
        timer3.Stop();
        //File.Copy("voobly-update.exe", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Voobly\\voobly-update.exe");
        
    }
    
    else
    {
        timer3.Start();
    }
}
public bool vooblyend()
{
    string V64bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Voobly\\voobly.exe";
    string V32bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Voobly\\voobly.exe";
    Regex regex = new Regex(@"voobly.*tmp");
    foreach (Process p in Process.GetProcesses("."))
    {
        if (regex.Match(p.ProcessName).Success == false && (File.Exists(V32bit) || File.Exists(V64bit)))
            return false;
    }
    return true;
}
        // STEAM VERIFY LEGAL COPY & ASSETS
        public void SteamReg()
{
    
    //string strPath = @"Software\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion";
    // Reading the key value
    try
    {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Microsoft Games\Age of Empires II HD", true))
        {
            if (key != null)
            {
                string o = key.GetValue("Language").ToString();
                //Object o = key.GetValue("Language");
                if (o != null)
                {
                    
                }
            }
            else
            {
                KryptonMessageBox.Show("Please Open Steam And Verify The Integrity of Age of Empires II HD", "Advice!");
                this.Close();
            }
        }
    }
    catch   
    {
        KryptonMessageBox.Show("Error RLang", "Alert!");
    }


  
}
        public void SteamAssets()
        {
            try
            {
                using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Valve\Steam", true))
                using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Valve\Steam", true))
                {
                    if (key32 != null)
                    {

                        string version32 = key32.GetValue("InstallPath").ToString();
                        //Object o32 = key32.GetValue("InstallPath");
                     
                        //Version version64 = new Version(o64 as String);

                    
                        string Spath32 = version32 + @"\steamapps\common\Age2HD";
                        //storing the values  
                        if (Directory.Exists(Spath32))
                        {
                            RegistryKey keyAdd = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
                            keyAdd.SetValue("SteamPath", Spath32);
                            keyAdd.Close();
                        }
                        

                        else
                        {
                            KryptonMessageBox.Show("You Need To Locate \"AoK HD.exe\" In Your Steam Games Folder", "Important!");
                            //OPEN DIALOG
                            this.openFileDialog1.FileName = "AoK HD.exe";
                            this.openFileDialog1.Filter = "AoK HD.exe|AoK HD.exe";

                            //Begin
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {

                                RegistryKey keyAddAlt = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
                                string SpathAlt = openFileDialog1.FileName;
                                keyAddAlt.SetValue("SteamPath", Path.GetDirectoryName(SpathAlt));
                                keyAddAlt.Close();

                            }

                        }

                        //do what you like with version

                        //else if (o32 != null)
                        //{
                        //    Version version32 = new Version(o32 as String);  
                        //    //do what you like with version
                        //}
                    }
                    else if (key64 != null)
                    {

                        
                        //Object o32 = key32.GetValue("InstallPath");
                        string version64 = key64.GetValue("InstallPath").ToString();
                            //Version version64 = new Version(o64 as String);
                            
                            string Spath64 = version64 + @"\steamapps\common\Age2HD";
                     
                            //storing the values  
                           if (Directory.Exists(Spath64))
                            {
                                RegistryKey keyAdd = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
                                keyAdd.SetValue("SteamPath", Spath64);
                                keyAdd.Close();
                            }
                            
                            else 
                            {
                                KryptonMessageBox.Show("You Need To Locate \"AoK HD.exe\" In Your Steam Games Folder", "Important!");
                                //OPEN DIALOG
                                this.openFileDialog1.FileName = "AoK HD.exe";
                                this.openFileDialog1.Filter = "AoK HD.exe|AoK HD.exe";
  
                //Begin
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    RegistryKey keyAddAlt = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AoE2Tools");
                    string SpathAlt = openFileDialog1.FileName;
                    keyAddAlt.SetValue("SteamPath", Path.GetDirectoryName(SpathAlt));
                    keyAddAlt.Close();
                    
                    
                }

                            }
 
                            //do what you like with version
                        
                        //else if (o32 != null)
                        //{
                        //    Version version32 = new Version(o32 as String);  
                        //    //do what you like with version
                        //}
                    }
                    else
                    {
                        KryptonMessageBox.Show("Please Open Steam And Verify The Integrity of Age of Empires II HD", "Advice!");
                    }
                }
            }
            catch (SystemException)
            {
                
            }

        }
        public void SteamDirs()
        {
            try
            {
            //Fetching AoE2HD Assets Directories
            using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                
                    string Hotkeys = Skey.GetValue("SetHotkeys").ToString();
                    string Sroot = Skey.GetValue("SteamPath").ToString();
                    string resources = Sroot + @"\resources";
                    string _drs = Sroot + @"\resources\_common\drs";
                    if (Directory.Exists(resources) && Directory.Exists(_drs) && IsDirectoryEmpty(resources) == false && IsDirectoryEmpty(_drs) == false)
                    {
                        //Steam Assets Are Ready For Conversion
                        BeginInvoke((MethodInvoker)delegate
                        {
                            progressBar1.Value = 100;
                        });
                        
                    }
                    else
                    {
                        DialogResult result = KryptonMessageBox.Show("Open Steam And Verify The Integrity Files of AoE2 HD. \n Retry?",
    "Important!",
    MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            SteamDirs();
                        }
                        else 
                        {
                            this.Close();
                        }
                    }

               
            }
                }
            catch(SystemException)
            {

            }
        }
        //Conversion of Steam Assets
        public void ConvertAsset()
        {
            Invoke((MethodInvoker)delegate
            {
                preparing.Enabled = true;
            });
            preparing.Enabled = true;
            //buttonCompress.Enabled = false;
            //progressBar2.Value = 1;
            using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Skey != null)
                {
                    string extractPath = Skey.GetValue("AoE2Path").ToString();
                    string CabPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\base.bina";
                    DirectoryInfo di = Directory.CreateDirectory(extractPath);
                    //ZipFile zip = ZipFile.Read(CabPath);
                    //int lol = 1;
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(CabPath))
                    {
                        totalFiles = zip.Count;
                        filesExtracted = 0;
                        zip.ExtractProgress += ZipExtractProgress;
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                        if (filesExtracted == totalFiles - 1)
                        {
                            //progressBar4.Visible = false;
                            progressBar2.Value = 0;

                        }
                    }
                    //foreach (ZipEntry es in zip)
                    //{
                    //    lol++;

                    //    //progressBar2.Value += lol / 100;
                    //    es.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    //    zip.ExtractProgress += ZipExtractProgress;
                    //    if (filesExtracted == totalFiles - 1)
                    //    {
                    //        //progressBar4.Visible = false;
                    //        progressBar4.Value = 0;

                    //    }
                    //    //backgroundWorker2.ReportProgress(lol++);

                    //}
                }
            }
            
            
        }
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
        //Building Assets
        public void BuildAssets()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                //player.PlayLooping();
                kryptonCheckButton1.Visible = true;
                kryptonCheckButton1.Enabled = true;
                monk.Enabled = true;
            });


            try
            { 
            //Graphics Builder
            using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Skey != null)
                {
                    string Sroot = Skey.GetValue("SteamPath").ToString();
                    string Gpath = Skey.GetValue("AoE2Path").ToString();
                    string regflag = Skey.GetValue("Flag").ToString();
                    if (regflag != "nl" && regflag != "ru" && regflag != "br")
                    Flag = Skey.GetValue("Flag").ToString();
                    string Hotkeys = Skey.GetValue("SetHotkeys").ToString();
                    string Shortwalls = Skey.GetValue("Short Walls").ToString();
                    string Smalltrees = Skey.GetValue("Small Trees").ToString();
                    string Hugenumber = Skey.GetValue("Huge Number").ToString();
                    string Boldtext = Skey.GetValue("Light Grid").ToString();
                    string Blueberries = Skey.GetValue("Blue Berries").ToString();
                    string Advancedidlepointer = Skey.GetValue("Advanced Idle Pointer").ToString();
                    string _Gdata = Gpath + @"\Data\";
                    string _commondrs = Sroot + "\\resources\\_common\\drs\\graphics\\";
                    string _drs = Sroot + @"\resources\_common\drs\";
                    string _interfac = Sroot + @"\resources\_common\drs\interface\";
                    string _sounds = Sroot + @"\resources\_common\drs\sounds\";
                    string _curdir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    CurrentDIR = _curdir;
                    string MainSounds = Sroot + @"\resources\_common\sound\";
                    string _taunts = Sroot + @"\resources\" + Flag + @"\sound\taunt\";
                    string _history = Sroot + @"\resources\" + Flag + @"\strings\history\";
                    string _graphicstmp = System.IO.Path.GetTempPath() + "\\hdtotc-tmp\\graphics\\";
                    string _interfactmp = System.IO.Path.GetTempPath() + "\\hdtotc-tmp\\interface\\";
                    string _interfacfix = _curdir + @"\data\patches\slps\interfacfix";
                    string _soundstmp = System.IO.Path.GetTempPath() + "\\hdtotc-tmp\\sounds\\";
                    
                    
                    //progressBar2.Maximum = 101;
                    
                    if (Directory.Exists(TMP.Replace(@"\\", @"\")))
                    {
                        try
                        {
                            Directory.Delete(TMP.Replace(@"\\", @"\"), true);
                        }
                        catch (SystemException)
                        {

                        }
                        
                    }
                    else if (!Directory.Exists(TMP.Replace(@"\\", @"\")))
                    {
                        Directory.CreateDirectory(TMP.Replace(@"\\", @"\"));
                    }
                        File.Copy(_curdir + @"\data\drsbuild.exe", _drs + "drsbuild.exe", true);
                    
                    //Coping Graphics to TMP
                        //Coping Copy Interface files to TMP
                        CopyTotmp(_commondrs, _graphicstmp);
                        //progressBar2.Minimum = 30 / 101;
                        //Coping Copy Interface files to TMP
                        if (Directory.Exists(_interfacfix))
                            CopyTotmp(_interfacfix, _interfactmp);

                        CopyTotmp(_interfac, _interfactmp);
                        //progressBar2.Minimum = 50 / 101;
                        //Coping Copy Interface files to TMP
                        CopyTotmp(_sounds, _soundstmp);
                        //progressBar2.Minimum = 55 / 101;
                        //Important Main Sounds
                        CopyTotmp(MainSounds, Gpath + @"\Sound\");
                        //progressBar2.Minimum = 60 / 101;
                        //Taunt Sounds
                        CopyTotmp(_taunts, Gpath + @"\Taunt\");
                        //progressBar2.Minimum = 65 / 101;
                        //History Files
                        CopyTotmp(_history, Gpath + @"\History\");
                        //progressBar2.Minimum = 70 / 101;
                        BeginInvoke((MethodInvoker)delegate
                        {
                            preparing.Image = WindowsFormsApplication3.Properties.Resources.check;
                            graphics.Enabled = true;
                        });
                       
                        
              

                    DirectoryInfo d = new DirectoryInfo(_graphicstmp);

                    foreach (var file in d.GetFiles())
                    {
                        if (file.ToString().Length == 5)
                        {
                            Directory.Move(file.FullName, _graphicstmp + "gra0000" + file.ToString());//7
                        }
                        else if (file.ToString().Length == 6)
                        {
                            Directory.Move(file.FullName, _graphicstmp + "gra000" + file.ToString());//6
                        }
                        else if (file.ToString().Length == 7)
                        {
                            Directory.Move(file.FullName, _graphicstmp + "gra00" + file.ToString());//5
                        }
                        else if (file.ToString().Length == 8)
                        {
                            Directory.Move(file.FullName, _graphicstmp + "gra0" + file.ToString());//4
                        }

                    }

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c" + "graphics.bat";
                    //File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp.Replace(@"\\", @"\") + "*.*\"");
                    File.WriteAllText("graphics.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _graphicstmp + "*.*\"");
                    File.AppendAllText("graphics.bat", Environment.NewLine + "\"" + _drs + "drsbuild.exe\"" + "/d \"" + _Gdata + "graphics.drs\" " + "\"" + "gra50730.slp\"" + Environment.NewLine);
                    //var processInfo = new ProcessStartInfo("cmd.exe", "/c" + "graphics.bat");
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();
                    BeginInvoke((MethodInvoker)delegate
                    {
                        graphics.Image = WindowsFormsApplication3.Properties.Resources.check;
                        interfacebox.Enabled = true;
                    });
                 
                    //Restore Graphics Files
                    //DirectoryInfo dres = new DirectoryInfo(_graphicstmp);
                    //foreach (var file in dres.GetFiles())
                    //{
                    //    if (file.ToString().Contains("gra0000"))
                    //    {
                    //        Directory.Move(file.FullName, _commondrs + file.ToString().Replace("gra0000", ""));//7
                    //    }
                    //    else if (file.ToString().Contains("gra000"))
                    //    {
                    //        Directory.Move(file.FullName, _commondrs + file.ToString().Replace("gra000", ""));//6
                    //    }
                    //    else if (file.ToString().Contains("gra00"))
                    //    {
                    //        Directory.Move(file.FullName, _commondrs + file.ToString().Replace("gra00", ""));//5
                    //    }
                    //    else if (file.ToString().Contains("gra0"))
                    //    {
                    //        Directory.Move(file.FullName, _commondrs + file.ToString().Replace("gra0", ""));//4
                    //    }

                    //}
                    //Preparing interfac


                    //END
                    DirectoryInfo dint = new DirectoryInfo(_interfactmp);

                    foreach (var file in dint.GetFiles())
                    {
                        Directory.Move(file.FullName, _interfactmp + "int" + file.ToString());
                    }

                    DirectoryInfo subd2 = new DirectoryInfo(_interfactmp);
                    foreach (var file in subd2.GetFiles())
                    {

                        if (file.ToString().Contains("bina"))
                        {
                            Directory.Move(file.FullName, _interfactmp + file.ToString().Replace("bina", "bin"));
                        }


                    }
                    //progressBar2.Minimum = 75 / 101;
                    //Building Interfac
                    System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
                    startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo2.FileName = "cmd.exe";
                    startInfo2.Arguments = "/C \"" + _drs.Replace(@"\", @"\\") + "drsbuild.exe\"" + " /a " + "\"" + _Gdata.Replace(@"\", @"\\") + "interfac.drs\"" + " \"" + _interfactmp.Replace(@"\", @"\\").Replace("\\\\", "\\") + "*.*\"";
                    startInfo2.Arguments = "/c" + "interfac.bat";
                  
                    File.WriteAllText("interfac.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "interfac.drs\" " + "\"" + _interfactmp + "*.*\"");
                    
                    process2.StartInfo = startInfo2;
                    process2.Start();
                    process2.WaitForExit();
                    //Applying Fix
                    string _interfix = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\interfac\";
                    System.Diagnostics.Process process3 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo3 = new System.Diagnostics.ProcessStartInfo();
                    startInfo3.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo3.FileName = "cmd.exe";
                    startInfo3.Arguments = "/c" + "interfac_fix.bat";
                    File.WriteAllText("interfac_fix.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "interfac.drs\" " + "\"" + _interfix + "*.*\"");
                    process3.StartInfo = startInfo3;
                    process3.Start();
                    process3.WaitForExit();
                    BeginInvoke((MethodInvoker)delegate
                    {
                        interfacebox.Image = WindowsFormsApplication3.Properties.Resources.check;
                        soundsbox.Enabled = true;
                    });
              
                    //progressBar2.Minimum = 80 / 101;
                    //Restore Interfac Files
                    //DirectoryInfo resint = new DirectoryInfo(_interfac);

                    //foreach (var file in resint.GetFiles())
                    //{
                    //    if (file.ToString().Contains("int"))
                    //    {
                    //        Directory.Move(file.FullName, _interfac + file.ToString().Replace("int",""));
                    //    }

                    //}

                    //DirectoryInfo resint2 = new DirectoryInfo(_interfac);
                    //foreach (var file in resint2.GetFiles())
                    //{

                    //    if (file.ToString().Contains("bin"))
                    //    {
                    //        Directory.Move(file.FullName, _interfac + file.ToString().Replace("bin", "bina"));
                    //    }


                    //}

                    //Preparing Sounds


                   
                    //END
                    //DirectoryInfo d3 = new DirectoryInfo(_soundstmp);

                    //foreach (var file in d3.GetFiles())
                    //{

                    //    Directory.Move(file.FullName, _soundstmp + "sou" + file.ToString());

                    //}
                    DirectoryInfo dsnd = new DirectoryInfo(_soundstmp);
                    FileInfo[] infos = dsnd.GetFiles();
                    foreach (FileInfo f in infos)
                    {
                        File.Move(f.FullName, _soundstmp + "sou" + f.ToString().Replace("sousou", "sou"));
                    }
                    // Building Sounds
                   
                    System.Diagnostics.Process process4 = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo4 = new System.Diagnostics.ProcessStartInfo();
                    startInfo4.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo4.FileName = "cmd.exe";
                    startInfo4.Arguments = "/c" + "sounds.bat";
                    File.WriteAllText("sounds.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "sounds.drs\" " + "\"" + _soundstmp + "*.*\"");
                    process4.StartInfo = startInfo4;
                    process4.Start();
                    process4.WaitForExit();
                    BeginInvoke((MethodInvoker)delegate
                    {
                        soundsbox.Image = WindowsFormsApplication3.Properties.Resources.check;
                        hotkeysbox.Enabled = true;
                    });
               
                    //progressBar2.Minimum = 90 / 101;
                    //Restoring Sound Files
                    //DirectoryInfo dsou = new DirectoryInfo(_sounds);

                    //foreach (var file in dsou.GetFiles())
                    //{
                    //    if (file.ToString().Contains("sou"))
                    //    {
                    //        Directory.Move(file.FullName, _sounds + file.ToString().Replace("sou",""));
                    //    }
                    //}


                    //foreach (string dirPath in Directory.GetDirectories(MainSounds, "*",
                    //    SearchOption.AllDirectories))
                    //    Directory.CreateDirectory(dirPath.Replace(MainSounds, Gpath + @"\Sound\"));

                    ////
                    //foreach (string newPath in Directory.GetFiles(MainSounds, "*.*",
                    //    SearchOption.AllDirectories))
                    //    File.Copy(newPath, newPath.Replace(MainSounds, Gpath + @"\Sound\"), true);
                    

                    //foreach (string dirPath in Directory.GetDirectories(_taunts, "*",
                    //    SearchOption.AllDirectories))
                    //    Directory.CreateDirectory(dirPath.Replace(_taunts, Gpath + @"\Taunt\"));

                    ////
                    //foreach (string newPath in Directory.GetFiles(_taunts, "*.*",
                    //    SearchOption.AllDirectories))
                    //    File.Copy(newPath, newPath.Replace(_taunts, Gpath + @"\Taunt\"), true);


    //                foreach (string dirPath in Directory.GetDirectories(_history, "*",
    //SearchOption.AllDirectories))
    //                    Directory.CreateDirectory(dirPath.Replace(_history, Gpath + @"\History\"));

    //                //
    //                foreach (string newPath in Directory.GetFiles(_history, "*.*",
    //                    SearchOption.AllDirectories))
    //                    File.Copy(newPath, newPath.Replace(_history, Gpath + @"\History\"), true);
                    
                    //Strip "-utf" Affix
                    DirectoryInfo dsou = new DirectoryInfo(Gpath + @"\History");
                    //exiting history files
                    foreach (var file in dsou.GetFiles())
                    {
                        if (!file.FullName.Contains("-utf8"))
                        {
                            File.Delete(file.FullName);
                        }
                    }
                    //renaming history files
                    foreach (var file in dsou.GetFiles())
                    {
                        if (file.FullName.Contains("-utf8"))
                        {
                            //MessageBox.Show("Old Path: " + file.FullName + "\n New Path: \n" + file.FullName.Replace("-utf8", ""));
                           
                            File.Move(file.FullName, file.FullName.Replace("-utf8", ""));
                        }
                    }

                    try
                    {
                        File.Delete(Gpath + "\\player.nfo");
                        File.Delete(Gpath + "\\player.nfp");
                        File.Delete(Gpath + "\\player.nfx");
                    }
                    catch (SystemException)
                    {

                    }
                    //Copy Steam Hokeys

                    if (Hotkeys == "Default (Recommended)" && Hotkeys != null)
                    {
                        try
                        {
        if(Directory.Exists(Sroot + "\\Profiles"))
                        {
                            var directory = new DirectoryInfo(Sroot + "\\Profiles");
                            var myFile = directory.GetFiles("*.hki")
                 .OrderByDescending(f => f.LastWriteTime)
                 .First();
                            if (myFile == null || myFile.Length == 0)
                            File.Copy(myFile.FullName, Gpath + "\\player1.hki", true);
                            
                            else
                            File.Copy(_curdir + @"data\hki\AoC2 Hotkeys\player1.hki", Gpath + "\\player1.hki", true);
                        }
                        }
                        catch (SystemException)
                        {
                            
                        }
                

                    }
                    //Copy Custom Hokeys
                    else 
                    {
                        if (Directory.Exists(Path.Combine(_curdir, @"data\hki")))
                        {
                            try
                            {
                                File.Copy(Path.Combine(_curdir, @"data\hki\" + Hotkeys + @"\player1.hki"), Gpath + "\\player1.hki", true);
                            }
                            catch(SystemException)
                            {

                            }
                            
                        }

                    }
                    BeginInvoke((MethodInvoker)delegate
                    {
                        hotkeysbox.Image = WindowsFormsApplication3.Properties.Resources.check;
                        modsbox.Enabled = true;
                    });
               
                    //Mods
                    if (Shortwalls == "yes")
                    {
                        string _modsinstall = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\mods\" + "Short Walls" + "\\i\\";
                        System.Diagnostics.Process process8 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo8 = new System.Diagnostics.ProcessStartInfo();
                        startInfo8.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo8.FileName = "cmd.exe";
                        startInfo8.Arguments = "/c" + "shortwalls.bat";
                        File.WriteAllText("shortwalls.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                        process8.StartInfo = startInfo8;
                        process8.Start();
                        process8.WaitForExit();
                    }

                    if (Smalltrees == "yes")
                    {
                        string _modsinstall = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\mods\" + "Small Trees" + "\\i\\";
                        System.Diagnostics.Process process9 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo9 = new System.Diagnostics.ProcessStartInfo();
                        startInfo9.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo9.FileName = "cmd.exe";
                        startInfo9.Arguments = "/c" + "smalltrees.bat";
                        File.WriteAllText("smalltrees.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                        process9.StartInfo = startInfo9;
                        process9.Start();
                        process9.WaitForExit();
                    }

                    if (Hugenumber == "yes")
                    {
                        string _modsinstall = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\mods\" + "Huge Number" + "\\i\\";
                        System.Diagnostics.Process process10 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo10 = new System.Diagnostics.ProcessStartInfo();
                        startInfo10.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo10.FileName = "cmd.exe";
                        startInfo10.Arguments = "/c" + "hugenumber.bat";
                        File.WriteAllText("hugenumber.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "interfac.drs\" " + "\"" + _modsinstall + "*.*\"");
                        process10.StartInfo = startInfo10;
                        process10.Start();
                        process10.WaitForExit();
                    }

                    if (Boldtext == "yes") //This grid mod not bold text lol
                    {
                        string _modsinstall = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\mods\" + "Light Grid" + "\\i\\";
                        System.Diagnostics.Process process11 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo11 = new System.Diagnostics.ProcessStartInfo();
                        startInfo11.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo11.FileName = "cmd.exe";
                        startInfo11.Arguments = "/c" + "grid.bat";
                        File.WriteAllText("grid.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "Terrain.drs\" " + "\"" + _modsinstall + "*.*\"");
                        process11.StartInfo = startInfo11;
                        process11.Start();
                        process11.WaitForExit();
                    }

                    if (Blueberries == "yes")
                    {
                        string _modsinstall = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\mods\" + "Blue Berries" + "\\i\\";
                        System.Diagnostics.Process process12 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo12 = new System.Diagnostics.ProcessStartInfo();
                        startInfo12.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo12.FileName = "cmd.exe";
                        startInfo12.Arguments = "/c" + "blueberries.bat";
                        File.WriteAllText("blueberries.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "gra02560.slp\"" + Environment.NewLine);
                        File.AppendAllText("blueberries.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "interfac.drs\" " + "\"" + _modsinstall + "int50730.slp\"" + Environment.NewLine);
                        process12.StartInfo = startInfo12;
                        process12.Start();
                        process12.WaitForExit();
                    }

                    if (Advancedidlepointer == "yes")
                    {
                        string _modsinstall = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\mods\" + "Advanced Idle Pointer" + "\\i\\";
                        System.Diagnostics.Process process13 = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo13 = new System.Diagnostics.ProcessStartInfo();
                        startInfo13.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo13.FileName = "cmd.exe";
                        startInfo13.Arguments = "/c" + "advancedidlep.bat";
                        File.WriteAllText("advancedidlep.bat", "\"" + _drs + "drsbuild.exe\"" + "/a \"" + _Gdata + "graphics.drs\" " + "\"" + _modsinstall + "*.*\"");
                        process13.StartInfo = startInfo13;
                        process13.Start();
                        process13.WaitForExit();
                    }
                    BeginInvoke((MethodInvoker)delegate
                    {
                        modsbox.Image = WindowsFormsApplication3.Properties.Resources.check;
                        pictureBox4.Image = Properties.Resources.Conversion_Step3_check;
                    });

                    //configlast
                    BeginInvoke((MethodInvoker)delegate
                    {
                        progressBar2.Value = progressBar2.Maximum;
                    });
                    try
                    {
                        if(File.Exists(Path.Combine(_curdir, @"data\SetupAoC.exe")))
                            File.Copy(Path.Combine(_curdir, @"data\SetupAoC.exe"), Path.Combine(Gpath, @"SetupAoC.exe"), true);
                    }
                    catch(SystemException)
                    {

                    }
                    backgroundWorker3.RunWorkerAsync();
                }
            }
            }
            catch(Exception ex)
            {
                KryptonMessageBox.Show("Error:" + ex, "Error");
            }
        }
        //Directory Check
        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
        
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar2.Value += e.ProgressPercentage;

            progressBar1.Value += e.ProgressPercentage;
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            SteamDirs();
            SteamReg();
            //ModifyProgressBarColor.SetState(progressBar1, 3);
            BeginInvoke((MethodInvoker)delegate
            {
                titlemonk.Text = "Good Luck With...";
            });
            
            //titlemonk.Text = "New To Voobly?"; itsfree.Enabled = false; linkLabel1.Enabled = false; itsfree.Visible = false; linkLabel1.Visible = false;
        }

        private void Conv_Shown(object sender, EventArgs e)
        {

            //progressBar2.Maximum = 101;
            //backgroundWorker1.RunWorkerAsync();
            //BuildAssets();



        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Image = WindowsFormsApplication3.Properties.Resources.Steam_Step2_check;
            progressBar1.Value = 100;
        }

        //public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        //{
        //    Directory.CreateDirectory(target.FullName);

        //    // Copy each file into the new directory.
        //    foreach (FileInfo fi in source.GetFiles())
        //    {
        //        Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
        //        fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
        //    }

        //    // Copy each subdirectory using recursion.
        //    foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        //    {
        //        DirectoryInfo nextTargetSubDir =
        //            target.CreateSubdirectory(diSourceSubDir.Name);
        //        CopyAll(diSourceSubDir, nextTargetSubDir);
        //    }
        //}

        public async void ConfigurationFinal()
        {
  
            try {
                BeginInvoke((MethodInvoker)delegate
                {
                        progressBar3.Maximum = 150;
                });
                
                
            // Creating key values
            using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Skey != null)
                {
                    //Game Dir
                    string Conf_Getroot = Skey.GetValue("AoE2Path").ToString();
                    if (File.Exists(Conf_Getroot + @"\Age2_x1\age2_x1.exe"))
                    {
                        File.WriteAllBytes(Conf_Getroot + @"\Age2_x1\" + "AoE2Tools.exe", File.ReadAllBytes(Conf_Getroot + @"\Age2_x1\age2_x1.exe"));
                    }
                    //Add To Firewall
                    FirewallHelper.Instance.GrantAuthorization(Conf_Getroot + @"\Age2_x1\age2_x1.exe", "Age of Empires 2");
                    BeginInvoke((MethodInvoker)delegate
                    {
                            progressBar3.Value = 10;
                    });
                    
                    Microsoft.Win32.RegistryKey rkey;
                    rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                    rkey.SetValue("CurrentDirectory", Conf_Getroot);
                    rkey.SetValue("Path", Conf_Getroot + @"\AGE2_X1");
                    rkey.SetValue("CommandLine", @"Lobby");
                    rkey.SetValue("File", @"\age2_x1.icd");
                    rkey.SetValue("Guid", @"{5DE93F3F-FC90-4ee1-AE5A-63DAFA055950}");
                    rkey.SetValue("Launcher", @"\age2_x1.Exe");
                    Microsoft.Win32.RegistryKey rkey2;
                    rkey2 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                    rkey2.SetValue("CurrentDirectory", Conf_Getroot);
                    rkey2.SetValue("Path", Conf_Getroot + @"\AGE2_X1");
                    rkey2.SetValue("CommandLine", @"Lobby");
                    rkey2.SetValue("File", @"\age2_x1.icd");
                    rkey2.SetValue("Launcher", @"\age2_x1.Exe");
                    rkey2.SetValue("Guid", @"{5DE93F3F-FC90-4ee1-AE5A-63DAFA055950}");
                    Microsoft.Win32.RegistryKey rkey3;
                    rkey3 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                    rkey3.SetValue("EXE Path", Conf_Getroot);
                    rkey3.SetValue("ReceivingFile", @"*");
                    rkey3.SetValue("Version", @"1.0C-VLY");
                    rkey3.SetValue("VersionType", @"RetailVersion");
                    rkey3.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");

                    Microsoft.Win32.RegistryKey rkey4;
                    rkey4 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                    rkey4.SetValue("EXE Path", Conf_Getroot);
                    rkey4.SetValue("ReceivingFile", @"*");
                    rkey4.SetValue("Version", @"1.0C-VLY");
                    rkey4.SetValue("VersionType", @"RetailVersion");
                    rkey4.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");

                    Microsoft.Win32.RegistryKey rkey5;
                    rkey5 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                    rkey5.SetValue("EXE Path", Conf_Getroot);
                    rkey5.SetValue("ReceivingFile", @"*");
                    rkey5.SetValue("Version", @"1.0C-VLY");
                    rkey5.SetValue("VersionType", @"RetailVersion");
                    rkey5.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");

                    //Run AOE2 As Admin(For Later As an option)
                    string inString22 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                    string inString2 = inString22.Replace(" (x86)", "");
                    TextInfo cultInfo2 = new CultureInfo("en-US", false).TextInfo;
                    string output2 = cultInfo2.ToTitleCase(inString2);
                    //if (Conf_Getroot.Contains(output2) || Conf_Getroot.Contains(output2))
                    //{
                        Microsoft.Win32.RegistryKey rkey6;
                        rkey6 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                        rkey6.SetValue(Conf_Getroot + @"\age2_x1\age2_x1.exe", "~ RUNASADMIN HIGHDPIAWARE");

                        Microsoft.Win32.RegistryKey rkey7;
                        rkey7 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\WOW6432Node\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                        rkey7.SetValue(Conf_Getroot + @"\age2_x1\age2_x1.exe", "~ RUNASADMIN HIGHDPIAWARE");
                        rkey6.Close();
                        rkey7.Close();
                    //}


                    Microsoft.Win32.RegistryKey rkey8;
                    rkey8 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                    rkey8.SetValue("dxtool", "true");
                    rkey8.SetValue("windowmode", "true");
                    rkey8.SetValue("hidewindowtitle", "true");
                    rkey8.SetValue("cursorlockenable", "true");
                    rkey8.SetValue("cursoringame", "false");
                    rkey8.SetValue("enabledxtoggle", "false");
                    rkey8.SetValue("disabledxhwaccel", "false");
                    rkey8.SetValue("Keydown Object Hotkeys", "true");
                    rkey8.SetValue("launchtosingle", "true");

                    Microsoft.Win32.RegistryKey rkey9;
                    rkey9 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                    rkey9.SetValue("Enable Water Animation", "false");
                    rkey9.SetValue("Disable Water Movement", "true");
                    rkey9.SetValue("Disable Custom Terrains", "false");
                    rkey9.SetValue("Disable Weather System", "true");
                    rkey9.SetValue("Custom Normal Mouse", "false");
                    rkey9.SetValue("Spectator Only Effects", "false");
                    rkey9.SetValue("Lower Quality Environment", "false");
                    rkey9.SetValue("Precision Scrolling System", "false");
                    rkey9.SetValue("Original Patrol Default", "false");
                    rkey9.SetValue("Multiple Building Queue", "true");
                    rkey9.SetValue("Keydown Object Hotkeys", "true");
                    rkey9.SetValue("Disable Extended Hotkeys", "false");
                    rkey9.SetValue("Shift Group Appending", "true");
                    rkey9.SetValue("Touch Screen Control", "false");
                    rkey9.SetValue("Numeric Age Display", "true");
                    rkey9.SetValue("Delink System Volume", "false");
                    rkey9.SetValue("Alternate Wine Chat", "false");
                    rkey9.SetValue("Low Simulation Rate", "false");

                    Microsoft.Win32.RegistryKey rkey10;
                    rkey10 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\64");
                    rkey10.SetValue("title", "New Game Title");
                    rkey10.SetValue("password", "");
                    rkey10.SetValue("description", "Converted With Love By AoE2Tools");
                    rkey10.SetValue("adlink", "");
                    rkey10.SetValue("adimage", "");
                    rkey10.SetValue("players", 8, RegistryValueKind.DWord);
                    rkey10.SetValue("teamonly", "false");
                    rkey10.SetValue("anticheat", "true");
                    rkey10.SetValue("rated", "true");
                    rkey10.SetValue("ratedrange", "false");
                    rkey10.SetValue("ratedmin", 0, RegistryValueKind.DWord);
                    rkey10.SetValue("ratedmax", 9999, RegistryValueKind.DWord);
                    rkey10.SetValue("nat", "true");
                    rkey10.SetValue("gamemod", "");
                    rkey10.SetValue("gamepatch", "v1.5 Beta R7");
                    rkey10.SetValue("ladderid", 83, RegistryValueKind.DWord);
                    rkey10.SetValue("players", 90, RegistryValueKind.DWord);
                    rkey10.SetValue("hiddencivs", "false");
                    rkey10.SetValue("spectateJoinAs", "false");
                    rkey10.SetValue("spectateUsersCanToggle", "true");
                    rkey10.SetValue("spectateLateJoin", "true");
                    rkey10.SetValue("spectatorNoGameRoomChat", "false");
                    rkey10.SetValue("spectateServerAlwaysOn", "false");

                    Microsoft.Win32.RegistryKey rkey11;
                    rkey11 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\251");
                    rkey11.SetValue("title", "New Game Title");
                    rkey11.SetValue("password", "");
                    rkey11.SetValue("description", "Converted With Love By AoE2Tools");
                    rkey11.SetValue("adlink", "");
                    rkey11.SetValue("adimage", "");
                    rkey11.SetValue("players", 8, RegistryValueKind.DWord);
                    rkey11.SetValue("teamonly", "false");
                    rkey11.SetValue("anticheat", "true");
                    rkey11.SetValue("rated", "true");
                    rkey11.SetValue("ratedrange", "false");
                    rkey11.SetValue("ratedmin", 0, RegistryValueKind.DWord);
                    rkey11.SetValue("ratedmax", 9999, RegistryValueKind.DWord);
                    rkey11.SetValue("nat", "true");
                    rkey11.SetValue("gamemod", "");
                    rkey11.SetValue("gamepatch", "v1.5 Beta R7");
                    rkey11.SetValue("ladderid", 83, RegistryValueKind.DWord);
                    rkey11.SetValue("players", 90, RegistryValueKind.DWord);
                    rkey11.SetValue("hiddencivs", "false");
                    rkey11.SetValue("spectateJoinAs", "false");
                    rkey11.SetValue("spectateUsersCanToggle", "true");
                    rkey11.SetValue("spectateLateJoin", "true");
                    rkey11.SetValue("spectatorNoGameRoomChat", "false");
                    rkey11.SetValue("spectateServerAlwaysOn", "false");


                    Microsoft.Win32.RegistryKey rkey12;
                    rkey12 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13\v1.5 Beta R7");
                    rkey12.SetValue("Enable Water Animation", "false");
                    rkey12.SetValue("Disable Water Movement", "true");
                    rkey12.SetValue("Disable Custom Terrains", "false");
                    rkey12.SetValue("Disable Weather System", "true");
                    rkey12.SetValue("Custom Normal Mouse", "false");
                    rkey12.SetValue("Spectator Only Effects", "false");
                    rkey12.SetValue("Lower Quality Environment", "false");
                    rkey12.SetValue("Precision Scrolling System", "false");
                    rkey12.SetValue("Original Patrol Default", "false");
                    rkey12.SetValue("Multiple Building Queue", "true");
                    rkey12.SetValue("Keydown Object Hotkeys", "true");
                    rkey12.SetValue("Disable Extended Hotkeys", "false");
                    rkey12.SetValue("Shift Group Appending", "true");
                    rkey12.SetValue("Touch Screen Control", "false");
                    rkey12.SetValue("Numeric Age Display", "true");
                    rkey12.SetValue("Delink System Volume", "false");
                    rkey12.SetValue("Alternate Wine Chat", "false");
                    rkey12.SetValue("Low Simulation Rate", "false");

                    Microsoft.Win32.RegistryKey rkey13;
                    rkey13 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\482");
                    rkey13.SetValue("title", "New Game Title");
                    rkey13.SetValue("password", "");
                    rkey13.SetValue("description", "Converted With Love By AoE2Tools");
                    rkey13.SetValue("adlink", "");
                    rkey13.SetValue("adimage", "");
                    rkey13.SetValue("players", 8, RegistryValueKind.DWord);
                    rkey13.SetValue("teamonly", "false");
                    rkey13.SetValue("anticheat", "true");
                    rkey13.SetValue("rated", "true");
                    rkey13.SetValue("ratedrange", "false");
                    rkey13.SetValue("ratedmin", 0, RegistryValueKind.DWord);
                    rkey13.SetValue("ratedmax", 9999, RegistryValueKind.DWord);
                    rkey13.SetValue("nat", "true");
                    rkey13.SetValue("gamemod", "");
                    rkey13.SetValue("gamepatch", "v1.5 Beta R7");
                    rkey13.SetValue("ladderid", 83, RegistryValueKind.DWord);
                    rkey13.SetValue("players", 90, RegistryValueKind.DWord);
                    rkey13.SetValue("hiddencivs", "false");
                    rkey13.SetValue("spectateJoinAs", "false");
                    rkey13.SetValue("spectateUsersCanToggle", "true");
                    rkey13.SetValue("spectateLateJoin", "true");
                    rkey13.SetValue("spectatorNoGameRoomChat", "false");
                    rkey13.SetValue("spectateServerAlwaysOn", "false");
                    rkey.Close();
                    rkey2.Close();
                    rkey3.Close();
                    rkey4.Close();
                    rkey5.Close();

                    rkey8.Close();
                    rkey9.Close();
                    rkey10.Close();
                    rkey11.Close();
                    rkey12.Close();
                    rkey13.Close();

                    UPnPNATClass upnpnat = new NATUPNPLib.UPnPNATClass();
                    IStaticPortMappingCollection mappings = upnpnat.StaticPortMappingCollection;
                    try
                    {
                        mappings.Add(16000, "UDP", 16000, GetLocalIPAddress(), true, "Voobly-" + Environment.MachineName.ToString());
                    }
                    catch (SystemException)
                    {

                    }
                    BeginInvoke((MethodInvoker)delegate
                    {
                            progressBar3.Value = 50;
                    });

                    try
                    {
                        string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
                        string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
                        Task<int> restask = ResolutionFix(Convert.ToInt32(screenWidth), Convert.ToInt32(screenHeight));
                        int moderes = await restask;

                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
                        {
                            key.SetValue("Advanced Buttons", 1, RegistryValueKind.DWord);
                        }


                    }
                    catch(SystemException)
                    {

                    }

                   
                    DirectoryInfo di = new DirectoryInfo(CurrentDIR);
                    FileInfo[] files = di.GetFiles("*.bat")
                                         .Where(p => p.Extension == ".bat").ToArray();
                    foreach (FileInfo file in files)
                        try
                        {
                            file.Attributes = FileAttributes.Normal;
                            File.Delete(file.FullName);
                        }
                    catch (SystemException)
                    {

                    }
                    //Create Shortcut
                    //Copy icon
                  

                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                    {
                        if (key != null)
                        {
                            string aoe2path = key.GetValue("AoE2Path").ToString();
                            //Object o = key.GetValue("Language");
                            if (aoe2path != null)
                            {
                                if (!File.Exists(aoe2path + @"\aoe2tools.ico") && File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\aoe2tools.ico"))
                                {
                                    File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\aoe2tools.ico", aoe2path + @"\aoe2tools.ico");
                                }

                                string shortfold = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\data\\icon.ico";
                                System.IO.File.Copy(shortfold, aoe2path + @"\Age2_x1\icon.ico", true);
                                //File Association
                                Associate(aoe2path);
                                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);

                                //SetAssociation_User("mgz", aoe2path + @"\age2_x1\AoE2Tools.exe", "AoE2Tools.exe");
                                //SetAssociation_User("mgx", aoe2path + @"\age2_x1\AoE2Tools.exe", "AoE2Tools.exe");
                                //Create shortcut

                                StringBuilder allUserProfile = new StringBuilder(260);
                                SHGetSpecialFolderPath(IntPtr.Zero, allUserProfile, CSIDL_COMMON_DESKTOPDIRECTORY, false);
                                string settingsLink = Path.Combine(allUserProfile.ToString(), "Age of Empires II The Conquerors.lnk");
                                //Create All Users Desktop Shortcut for Application Settings
                                IWshRuntimeLibrary.WshShellClass shellClass = new IWshRuntimeLibrary.WshShellClass();
                                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shellClass.CreateShortcut(settingsLink);
                                shortcut.TargetPath = aoe2path + @"\Age2_x1\age2_x1.exe";
                                shortcut.IconLocation = aoe2path + @"\Age2_x1\icon.ico";
                                //shortcut.Arguments = "arg1 arg2";
                                shortcut.Description = "Age of Empires II The Conquerors";
                                shortcut.Save();
                                BeginInvoke((MethodInvoker)delegate
                                {
                                        progressBar3.Value = 60;
                                });
                                
                                int pgb = 60;
                                byte[] bytie = File.ReadAllBytes("libc.bin");
                                byte[] result = Replace(bytie, new byte[] { 0x6b, 0x55, 0x63, 0x49, 0x37, 0x39, 0x44, 0x34, 0x73, 0x67, 0x6d, 0x4b, 0x61, 0x38, 0x6a, 0x4f, 0x33, 0x47, 0x74, 0x49, 0x70, 0x56, 0x49, 0x64, 0x53, 0x66, 0x5a, 0x7a, 0x72, 0x53, 0x6c, 0x4a, 0x77, 0x7a, 0x32, 0x52, 0x6a, 0x32, 0x31, 0x67, 0x43, 0x6a, 0x47, 0x4a, 0x39, 0x33, 0x6f, 0x72, 0x6d, 0x5a, 0x6b, 0x71, 0x32, 0x57, 0x53, 0x72, 0x67, 0x34, 0x49, 0x31, 0x79, 0x4f, 0x72, 0x44, 0x54, 0x39, 0x58, 0x77, 0x59, 0x76, 0x43, 0x7a, 0x6b, 0x35, 0x76, 0x72, 0x70, 0x4e, 0x72, 0x36, 0x68, 0x73, 0x53, 0x68, 0x30, 0x78, 0x36, 0x33, 0x75, 0x36, 0x62, 0x4f, 0x73, 0x6e, 0x35, 0x70, 0x55, 0x6d, 0x49, 0x46, 0x35, 0x69, 0x70, 0x58, 0x6c, 0x41, 0x45, 0x36, 0x78, 0x4b, 0x53, 0x4c, 0x64, 0x70, 0x50, 0x65, 0x54, 0x44, 0x70, 0x74, 0x66, 0x42, 0x4f, 0x4d, 0x56, 0x44, 0x50, 0x4f, 0x6c, 0x37, 0x61, 0x4b, 0x31, 0x6e, 0x39, 0x69, 0x4c, 0x45, 0x54, 0x36, 0x6d, 0x43, 0x44, 0x58, 0x4c, 0x51, 0x50, 0x58, 0x46, 0x66, 0x42, 0x69, 0x49, 0x4c, 0x55, 0x52, 0x31 }, new byte[] { 0x37, 0x7a, 0xbc, 0xaf, 0x27, 0x1c, 0x00, 0x04, 0x4a, 0xad, 0xfa, 0x6e, 0xec, 0xbb, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5a, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x39, 0xaf, 0x8f, 0x04, 0xe3, 0xe0, 0xbc, 0xe0, 0x4e, 0x5d, 0x00, 0x1a, 0x11, 0x02, 0xa4, 0x13, 0x47, 0x58, 0xcb, 0x06, 0x78, 0x0c, 0x99, 0x7c, 0x9d, 0x24, 0xf3, 0x6d, 0x9e, 0xfb, 0x88, 0x12, 0x2d, 0xce, 0x2b, 0xd8, 0x2a, 0x1c, 0xa5, 0x60, 0x0f, 0x72, 0xc6, 0x48, 0x93, 0x05, 0xfe, 0x12, 0xd7, 0x09, 0x42, 0x5c });
                                File.WriteAllBytes(System.IO.Path.GetTempPath() + "\\ver.bin", result);
                                Preg(System.IO.Path.GetTempPath() + "\\ver.bin", System.IO.Path.GetTempPath() + "\\Precache\\");
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
                                    if(cnt == 1)
                                        File.WriteAllBytes(aoe2path + @"\Age2_x1\age2_x1." + Properties.Resources.string3, stba(hs));
                                    else if (cnt == 2)
                                        File.WriteAllBytes(aoe2path + @"\Age2_x1\age2_x1." + Properties.Resources.string4, stba(hs));
                                        else if (cnt == 3)
                                        File.WriteAllBytes(aoe2path + @"\Age2_x1\age2_x1." + Properties.Resources.string5, stba(hs));
                                    
                                    //clear

                                    
                                }

                                BeginInvoke((MethodInvoker)delegate
                                {
                                        progressBar3.Value = 90;
                                });
                                File.Delete(System.IO.Path.GetTempPath() + "\\Precache\\" + cnt + Properties.Resources.string2);
                                if (Directory.Exists(System.IO.Path.GetTempPath() + @"\Precache\"))
                                    Directory.Delete(System.IO.Path.GetTempPath() + @"\Precache\", true);
                                if (Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\"))
                                Directory.Delete(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\", true);
                                if (File.Exists(System.IO.Path.GetTempPath() + @"\ver.bin"))
                                File.Delete(System.IO.Path.GetTempPath() + @"\ver.bin");


                                DirectoryInfo di5 = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                                FileInfo[] files5 = di5.GetFiles("*.bat")
                                                     .Where(p => p.Extension == ".bat").ToArray();
                                foreach (FileInfo file5 in files5)
                                    try
                                    {
                                        //file.Attributes = FileAttributes.Normal;
                                        File.Delete(file5.FullName);
                                    }
                                    catch { }
                                BeginInvoke((MethodInvoker)delegate
                                {
                                        progressBar3.Value = 150;
                                          pictureBox5.Image = Properties.Resources.Config_Step4_check;
                                          textBox1.Text = "1";
                                });
                                

                            }
                        }
                    }

                   

                    //KryptonMessageBox.Show("Success! Thank you For Your Patience! Everything is Ready Now!!", "Conversion Success - AoE2Tools");
                    

                    //
                    //Thread.Sleep(1000);
                    //this.Hide();
                    //Splash splsh = new Splash();
                    //splsh.Show();
                    //KryptonMessageBox.Show("Everything is fine! Happy Gaming & GLHF!");
                }
            }
            }
            catch (SystemException)
            {
                //throw exd;
            }
        }
        public async Task<int> ResolutionFix(int aoewidth, int aoeheight)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            {
                key.SetValue("Screen Width", aoewidth, RegistryValueKind.DWord);
                key.SetValue("Screen Height", aoeheight, RegistryValueKind.DWord);
                return 1;
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //Base Files
            ConvertAsset();
            //Building
            //BeginInvoke((MethodInvoker)delegate
            //{

                BuildAssets();
            //});
                
            
            

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            titlemonk.Text = "Turned Blue Yet?";
            BeginInvoke((MethodInvoker)delegate
            {

                ModifyProgressBarColor.SetState(progressBar2, 1);
            });
           
            //backgroundWorker3.RunWorkerAsync();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {



        }

        public void CopyTotmp(string source, string destination)
        {
            try
            {

            
            if(!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
                
            }

            string[] subDirs =
                     System.IO.Directory.GetDirectories(source, "*",
                     (System.IO.SearchOption.AllDirectories));
            int subFiles = System.IO.Directory.GetFiles(source, "*.*",
     SearchOption.AllDirectories).Length;
     
            BeginInvoke((MethodInvoker)delegate
            {

                progressBar2.Maximum = subFiles + (subDirs.Length);
                progressBar2.Value = 0;
            });
            foreach (string dirPath in Directory.GetDirectories(source, "*",
                  SearchOption.AllDirectories))
            {
                BeginInvoke((MethodInvoker)delegate
                {

                    progressBar2.Value++;
                    progressBar2.PerformStep();
                });
              
                Directory.CreateDirectory(dirPath.Replace(source, destination));
                Application.DoEvents();
                if (progressBar2.Value > 98)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {

                        progressBar2.Value--;
                        progressBar2.Maximum++;
                    });
                  

                }

            }

            foreach (string newPath in Directory.GetFiles(source, "*.*",
                            SearchOption.AllDirectories))
            {
                BeginInvoke((MethodInvoker)delegate
                {

                    progressBar2.Maximum = subFiles + (subDirs.Length);
                    progressBar2.Value++;
                });
              
                File.Copy(newPath, newPath.Replace(source, destination), true);
                Application.DoEvents();
                if (progressBar2.Value > 98)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {

                        progressBar2.Value--;
                        progressBar2.Maximum++;
                    });
                  
                   
                    
                }
            }
                //catch
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar2.Value = e.ProgressPercentage / 4000;
            progressBar2.Value = e.ProgressPercentage;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
  
            start.Enabled = false;
            //monk.Enabled = true;
            ModifyProgressBarColor.SetState(progressBar1, 1);
            //player.PlayLooping();
            titlemonk.Text = "";
            string V64bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Voobly\\voobly.exe";
            string V32bit = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Voobly\\voobly.exe";
            if (File.Exists(V32bit) || File.Exists(V64bit))
            {

                titlemonk.Text = "";
                VooblyPic.Image = Properties.Resources.Voobly_Step1_check;
                //KryptonMessageBox.Show("Voobly Already Installed!");
            }
            else { titlemonk.Text = "New To Voobly?"; itsfree.Enabled = true; linkLabel1.Enabled = true; itsfree.Visible = true; linkLabel1.Visible = true; VooblyHTML(); }

            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.voobly.com/signup");
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
        private void kryptonCheckButton1_Click(object sender, EventArgs e)
        {
            if (kryptonCheckButton1.Checked == true)
            {
                player.Stop();
            }
            else
            {
                player.PlayLooping();
            }
        }
        public static byte[] stba(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public void Preg(string sourceArchive, string destination)
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
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
  
                ConfigurationFinal();

                try
                {
                    if (Directory.Exists(System.IO.Path.GetTempPath() + "\\hdtotc-tmp"))
                        Directory.Delete(System.IO.Path.GetTempPath() + "\\hdtotc-tmp", true);
                }
                catch (SystemException)
                {

                }

        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar3.Value += e.ProgressPercentage / 150;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                progressBar3.Value = 150;
                titlemonk.Text = "Successfully Wololoed!";
                titlemonk.ForeColor = Color.Blue;
                monk.Enabled = false;
                try
                {
                    Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\AoE2Tools.exe");
                    Process.GetCurrentProcess().Kill();
                }
                catch(SystemException)
                {
                    Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\AoE2Tools.exe");
                    Process.GetCurrentProcess().Kill();
                }
                

            });
  
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
          
        }
        public static void SetAssociation_User(string Extension, string OpenWith, string ExecutableName)
        {

            using (RegistryKey User_Classes = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\", RegistryKeyPermissionCheck.ReadWriteSubTree))
            using (RegistryKey User_Ext = User_Classes.CreateSubKey("." + Extension))
            using (RegistryKey User_AutoFile = User_Classes.CreateSubKey(Extension + "_auto_file", RegistryKeyPermissionCheck.ReadWriteSubTree))
            using (RegistryKey User_AutoFile_Command = User_AutoFile.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command"))
            using (RegistryKey ApplicationAssociationToasts = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\ApplicationAssociationToasts\\", RegistryKeyPermissionCheck.ReadWriteSubTree))
            using (RegistryKey User_Classes_Applications = User_Classes.CreateSubKey("Applications"))
            using (RegistryKey User_Classes_Applications_Exe = User_Classes_Applications.CreateSubKey(ExecutableName))
            using (RegistryKey User_Application_Command = User_Classes_Applications_Exe.CreateSubKey("shell").CreateSubKey("open").CreateSubKey("command"))
            using (RegistryKey User_Explorer = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\." + Extension, RegistryKeyPermissionCheck.ReadWriteSubTree))
            using (RegistryKey User_Choice = User_Explorer.OpenSubKey("UserChoice"))
            {
                User_Ext.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                User_Classes.SetValue("", Extension + "_auto_file", RegistryValueKind.String);
                User_Classes.CreateSubKey(Extension + "_auto_file");
                User_AutoFile_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                //windows 10 only
                try
                {
                    ApplicationAssociationToasts.SetValue(Extension + "_auto_file_." + Extension, 0);

                    ApplicationAssociationToasts.SetValue(@"Applications\" + ExecutableName + "_." + Extension, 0);
                }
                catch (SystemException)
                {

                }
                User_Application_Command.SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
                User_Explorer.CreateSubKey("OpenWithList").SetValue("a", ExecutableName);
                User_Explorer.CreateSubKey("OpenWithProgids").SetValue(Extension + "_auto_file", "0");
                if (User_Choice != null) User_Explorer.DeleteSubKey("UserChoice");
                User_Explorer.CreateSubKey("UserChoice").SetValue("ProgId", @"Applications\" + ExecutableName);
            }
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);

        }

        public static bool IsAssociate()
        {
            return (Registry.CurrentUser.OpenSubKey("Software\\Microsft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.mgz", false) == null);
        }
        public static void Associate(string Aoe2dir)
        {
            string Aoe2path = Aoe2dir + "\\";
            RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\.mgz", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\AoE2Tools.exe", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey FileReg2 = Registry.CurrentUser.CreateSubKey("Software\\Classes\\.mgx", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey AppReg2 = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\AoE2Tools.exe", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.mgz", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey AppAssoc2 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.mgx", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey FileCLass = Registry.ClassesRoot.CreateSubKey("mgz_auto_file\\shell\\open\\command", RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey FileCLass2 = Registry.ClassesRoot.CreateSubKey("mgx_auto_file\\shell\\open\\command", RegistryKeyPermissionCheck.ReadWriteSubTree);

            FileReg.CreateSubKey("DefaultIcon").SetValue("", Aoe2path + @"aoe2tools.ico");
            FileReg.CreateSubKey("PerceivedType").SetValue("", "Gamemedia");
            FileReg2.CreateSubKey("DefaultIcon").SetValue("", Aoe2path + @"aoe2tools.ico");
            FileReg2.CreateSubKey("PerceivedType").SetValue("", "Gamemedia");
            //important
            FileCLass.SetValue("", "\"" + Aoe2path + "Age2_x1\\AoE2Tools.exe\" \"%1\"");
            FileCLass2.SetValue("", "\"" + Aoe2path + "Age2_x1\\AoE2Tools.exe\" \"%1\"");
            AppReg.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Aoe2path + "Age2_x1\\AoE2Tools.exe\" \"%1\"");
            AppReg.CreateSubKey("DefaultIcon").SetValue("", Aoe2path + @"aoe2tools.ico");

            AppReg2.CreateSubKey("shell\\open\\command").SetValue("", "\"" + Aoe2path + "Age2_x1\\AoE2Tools.exe\" \"%1\"");
            AppReg2.CreateSubKey("DefaultIcon").SetValue("", Aoe2path + @"aoe2tools.ico");

            AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", @"Applications\AoE2Tools.exe");
            AppAssoc2.CreateSubKey("UserChoice").SetValue("Progid", @"Applications\AoE2Tools.exe");
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        private void Conv_FormClosing(object sender, FormClosingEventArgs e)
        {
        

        }
        public static bool CloseCancel()
        {
            const string message = "Are you sure you would like to cancel the conversion?";
            const string caption = "Cancel Conversion";
            var result = KryptonMessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {


        }

        private void kryptonCheckButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void kryptonCheckButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(kryptonCheckButton1.Checked == true)
                player.PlayLooping();
            else
                player.Stop();
        }
    }

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }



}

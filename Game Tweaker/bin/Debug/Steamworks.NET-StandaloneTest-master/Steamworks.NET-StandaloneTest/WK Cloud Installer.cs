using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Steamworks;
using System.Threading;
using ComponentFactory.Krypton.Toolkit;
using System.IO;
using System.Threading.Tasks;
using Dropbox.Api;
using System.Net;
using System.Timers;
using System.Diagnostics;
using System.Reflection;
using SevenZip;
using SevenZipExtractor;
using Microsoft.Win32;
namespace WK_Cloud_Insta
{

    public partial class WK_Cloud_Installer : KryptonForm
    {
        
        public WK_Cloud_Installer()
        {
            InitializeComponent();
          
        
            
        }
        public string GetExp = "Please connect to your Internet!";
        public ulong TB;
        public int TB_C;
        public bool nolegit = false;
        public bool wkofflineDone = false;
        public bool falsenet = false;
       
        private string saveDirectoryPath = "";
        public delegate void ProgressChangeDelegate(double Persentage, ref bool Cancel);
        public delegate void Completedelegate();


    void CombineFiles(string[] files, string combinedFile)
    {
      using (BinaryWriter bw = new BinaryWriter(new FileStream(combinedFile, FileMode.Create)))
      {
        for (int i = 0; i < files.Length; i++)
          bw.Write(File.ReadAllBytes(files[i]));
      }
    }
    static ulong tlbytes()
    {
        long bin1 = new System.IO.FileInfo("msgd.bin1").Length;
        long bin2 = new System.IO.FileInfo("msgd.bin2").Length;
        long bin3 = new System.IO.FileInfo("msgd.bin3").Length;
       long tlbin = bin1 + bin2 + bin3;
       return (ulong)tlbin;
    }
        async Task<int> Downloadz(string folder, string targetfile, string localPath)
        {
 
            ServicePointManager.DefaultConnectionLimit = 1000;
            var dbxz = new DropboxClient("API HERE");
            var responsez = await dbxz.Files.DownloadAsync(folder + "/" + targetfile);
            //ulong fileSizez = responsez.Response.Size;
            ulong fileSizez = responsez.Response.Size;
            
            const int bufferSize = 1024 * 1024;
            var buffer = new byte[bufferSize];
            string folderNamez = Path.Combine(System.IO.Path.GetTempPath(), targetfile);
            using (var stream = await responsez.GetContentAsStreamAsync())
            {
                using (var localfilez = new FileStream(folderNamez, FileMode.OpenOrCreate))
                {
                    var lengthz = stream.Read(buffer, 0, bufferSize);
                    await Task.Run(() => //This code runs on a new thread, control is returned to the caller on the UI thread.
    {
        while (lengthz > 0)
        {

            localfilez.Write(buffer, 0, lengthz);
            // Console.WriteLine(localfile.);
            var percentage = 100 * (ulong)localfilez.Length / fileSizez;
            // Update progress bar with the percentage.


            progressBar2.Value = (int)percentage;



            //Console.WriteLine(percentage);
            lengthz = stream.Read(buffer, 0, bufferSize);
        }
    });
                   
                    
                }
                
            }
           
            return 1;
            
        }
        async Task<int> Downloadstr(string folder, string targetfile, string localPath)
        {
            try
            {
                var dbx = new DropboxClient("API HERE");
                var response = await dbx.Files.DownloadAsync(folder + "/" + targetfile);
                ulong fileSize = response.Response.Size;

                const int bufferSize = 1024 * 1024;
                var buffer = new byte[bufferSize];
                string folderName = Path.Combine(System.IO.Path.GetTempPath(), targetfile);
                using (var stream = await response.GetContentAsStreamAsync())
                {
                    using (var localfile = new FileStream(folderName, FileMode.OpenOrCreate))
                    {
                        var length = stream.Read(buffer, 0, bufferSize);
                        while (length > 0)
                        {

                            localfile.Write(buffer, 0, length);
                            // Console.WriteLine(localfile.);
                            //var percentage = 100 * (ulong)localfile.Length / fileSize;
                            // Update progress bar with the percentage.
                            //progressBar2.Value = (int)percentage;
                            //Console.WriteLine(percentage);
                            length = stream.Read(buffer, 0, bufferSize);
                        }
                    }
                }
                if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt")) && targetfile == "ver.txt") { labby.Text = "Getting WololoKingdoms " + File.ReadAllText(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt")); }
                return 1;
            }
            catch(Exception ex)
            {
                falsenet = true;
                GetExp = ex.ToString();
                MessageBox.Show(GetExp);
                return 0;
            }
            
        }
        public bool dlcfail = false;  
        public async void SteamTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Enabled = true;
            timer1.Interval = 2000; // in miliseconds
            await Task.Delay(1000);
            timer1.Start();
            

            
        }




        
        public string SaveDirectoryPath()
        {
            if (this.saveDirectoryPath == "")
            {
                uint size = SteamApps.GetAppInstallDir((AppId_t)221380, out this.saveDirectoryPath, 500u);

                if (size <= 0)
                {
                    
                }
                else
                {
                    
                }
            }

            return this.saveDirectoryPath;
        }
        private async void timer_Tick(object sender, EventArgs e)
        {
            if (!SteamAPI.Init())
            {
                if(SteamAPI.IsSteamRunning())
                {
                    labby.StateNormal.ShortText.Color1 = Color.DarkBlue;
                    labby.Text = "Seeking Age of Empires 2 ..";
                }
                else
                {
                    labby.StateNormal.ShortText.Color1 = Color.Gold;
                    await Task.Delay(200);
                    labby.Text = "Waiting Steam Login..";
                    await Task.Delay(100);
                    labby.StateNormal.ShortText.Color1 = Color.Maroon;
                }
                
                //SteamUtils.GetAppID();
               
            }
            else
            {
               
                labby.StateNormal.ShortText.Color1 = Color.ForestGreen;
                labby.Text = "Steam Running... Checking DLCs";
                await Task.Delay(1000);

                try
                {
                    int totaldlcs = 0;
                    for (int iDLC = 0; iDLC < SteamApps.GetDLCCount(); ++iDLC)
                    {
                        
                        AppId_t AppID;
                        bool Available;
                        string Name;
                        
                        bool ret = SteamApps.BGetDLCDataByIndex(iDLC, out AppID, out Available, out Name, 128);

                        
                        if (AppID.ToString() == "239550" && Available == true)
                        {
                            forgotten.Visible = true;
                            forgotten.Image = WK_Cloud_Insta.Properties.Resources.check;
                            forgotten.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else
                        {
                            totaldlcs++;
                            dlcfail = true;
                        }

                        if (AppID.ToString() == "355950" && Available == true)
                        {
                            african.Visible = true;
                            african.Image = WK_Cloud_Insta.Properties.Resources.check;
                            african.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else
                        {
                            totaldlcs++;
                            dlcfail = true;
                        }

                        if (AppID.ToString() == "488060" && Available == true)
                        {
                            rajas.Visible = true;
                            rajas.BackgroundImageLayout = ImageLayout.Stretch;
                            rajas.Image = WK_Cloud_Insta.Properties.Resources.check;
                            
                        }
                        else
                        {
                            totaldlcs++;
                            dlcfail = true;
                        }

                        //Console.WriteLine("BGetDLCDataByIndex(" + iDLC + ", out AppID, out Available, out Name, 128) : " + ret + " -- " + AppID + " -- " + Available + " -- " + Name);
                    }

                    if (rajas.Visible == true && african.Visible == true && forgotten.Visible == true)
                    {
                        wkstarter.Enabled = true;
                        wkstarter.Text = "Start Now?";
                    }
                    else if (rajas.Visible == false)
                    {
                        MessageBox.Show("You do not own Rise of Rajas DLC!");
                        DialogResult dialogResult = KryptonMessageBox.Show("You do not own Rise of Rajas DLC. Would You like to go to steam and buy it now?", "Rise of Rajas DLC Missing!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start(@"https://store.steampowered.com/app/488060/Age_of_Empires_II_HD_Rise_of_the_Rajas/");
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do nothing.
                        }
                    }
                    else if (african.Visible == false)
                    {

                        DialogResult dialogResult = KryptonMessageBox.Show("You do not own African Kingdoms. Would You like to go to steam and buy it now?", "African Kingdoms DLC Missing!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start(@"https://store.steampowered.com/app/355950/Age_of_Empires_II_HD_The_African_Kingdoms/");
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do nothing.
                        }
                    }
                    else if (forgotten.Visible == false)
                    {

                        DialogResult dialogResult = KryptonMessageBox.Show("You do not own Forgotten Empires DLC. Would You like to go to steam and buy it now?", "Forgotten Empires DLC Missing!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start(@"https://store.steampowered.com/app/239550/Age_of_Empires_II_HD_The_Forgotten/");
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do nothing.
                        }
                    }
                    
                   
                }
                catch
                {
                    MessageBox.Show("not connected to steam!");
                }
                timer1.Stop();
            }
        }

        private async void WK_Cloud_Installer_Load(object sender, EventArgs e)
        {
            
            //Steamworks lib check.
            //try
            //{
            //    if (!SteamAPI.Init())
            //    {
            //        //MessageBox.Show("SteamAPI.Init() failed!");
            //        return;
            //    }
            //}
            //catch (DllNotFoundException ex)
            //{ // We check this here as it will be the first instance of it.
            //    MessageBox.Show(ex.ToString());
            //    return;
            //}

            //if (!Packsize.Test())
            //{
            //    MessageBox.Show("You're using the wrong Steamworks.NET Assembly for this platform!");
            //    return;
            //}

            //if (!DllCheck.Test())
            //{
            //    MessageBox.Show("You're using the wrong dlls for this platform!");
            //    return;
            //}
          
            if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt")))
                File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt"));

            string modetxt = Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt");
            Task<int> modetask = Downloadstr("", "mode.txt", modetxt);
            int moderes = await modetask;
            if(moderes == 0)
            {
                KryptonMessageBox.Show(GetExp);
            }
            //string[] mifiles = { "msgd.bin1", "msgd.vin2", "msgd.bin3" };
            //CombineFiles(mifiles, "wkcombine.7z");

            //File.WriteAllText("bin.txt", tlbytes().ToString());
            //MessageBox.Show(tlbytes().ToString());

            Task<int> Gametask = GameIntegrity();
            int result = await Gametask;
            SteamTimer();
           

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void forgotten_Click(object sender, EventArgs e)
        {

        }

        private async void wkstarter_Click(object sender, EventArgs e)
        {
            wkstarter.Enabled = false;
            checkpath.Enabled = false;
            getaoe2path.Enabled = false;
            if (falsenet == true || incr.Text == "1")
            {
                if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt")))
                    File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt"));

                string modetxt = Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt");
                Task<int> modetask = Downloadstr("", "mode.txt", modetxt);
                int moderes = await modetask;
            }
            if (CheckForInternetConnection() == true && File.ReadAllText(Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt")) == "online")                    
            {
                if(File.Exists(getaoe2path.Text + @"\age2_x1\age2_x1.exe"))
                {

                    labby.Text = "Connecting To Cloud Server...";
                    african.Visible = false;
                    rajas.Visible = false;
                    forgotten.Visible = false;
                    //Prepare DIrectory
                    Directory.CreateDirectory(Path.Combine(getaoe2path.Text, @"Voobly Mods\AOC\Data Mods\WololoKingdoms\"));
					//Connecting To 3rd Party Server 
					//** Removed **//
					//** Removed **//
					//** Removed **//
					//** Removed **//
					//** Removed **//
                    convedlbl.Visible = true;
                    conved.Visible = true;
                    cloudconv.Text = "Successfully Converted!";
                    //Starting Cloud download.
                    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt")))
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt"));
                    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"bin.txt")))
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"bin.txt"));
                    

                    string vertxt = Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt");
                    Task<int> vertask = Downloadstr("", "ver.txt", vertxt);
                    int verres = await vertask;
                    //var strtask = Task.Run(async () => await Downloadstr("", "ver.txt", vertxt));

                    string bintxt = Path.Combine(System.IO.Path.GetTempPath(), @"bin.txt");
                    Task<int> bintask = Downloadstr("", "bin.txt", bintxt);
                    int binres = await bintask;

                    //var bintask = Task.Run(async () => await Downloadstr("", "bin.txt", bintxt));
                    ////strtask.Wait();

                    

                    TB = ulong.Parse(File.ReadAllText(Path.Combine(System.IO.Path.GetTempPath(), @"bin.txt")));
                    //**
                    if(File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin1")))
                    {
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin1"));
                    }

                    wkdownloaded.Text = "Downloading 1/3 ...";
                    string gbin1 = Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin1");
                    //var gbtask1 = Task.Run(async () => await Downloadz("", "msgd.bin1", gbin1));
                    Task<int> gbtask1 = Downloadz("", "msgd.bin1", gbin1);
                    int result1 = await gbtask1;

                    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin2")))
                    {
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin2"));
                    }
                    wkdownloaded.Text = "Downloading 2/3 ...";
                    string gbin2 = Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin2");
                    //var gbtask2 = Task.Run(async () => await Downloadz("", "msgd.bin2", gbin2));
                    Task<int> gbtask2 = Downloadz("", "msgd.bin2", gbin2);
                    int result2 = await gbtask2;

                    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin3")))
                    {
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin3"));
                    }
                    wkdownloaded.Text = "Downloading 3/3 ...";
                    string gbin3 = Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin3");
                    //var gbtask3 = Task.Run(async () => await Downloadz("", "msgd.bin3", gbin3));
                    Task<int> gbtask3 = Downloadz("", "msgd.bin3", gbin3);
                    int result3 = await gbtask3;

                    //** Binder
                    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z")))
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z"));
                    string[] mifiles = { gbin1, gbin2, gbin3 };
                    CombineFiles(mifiles, Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z"));

            //        await Task.Run(() =>
            //{
            //    unzip(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z"));
            //});
                    
                    labby.Text = "Setting Up WololoKingdoms " + File.ReadAllText(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt"));
                    //task.Wait();
                    downed.Visible = true;
                    downedlbl.Visible = true;
                    wkdownloaded.Text = "Successfully Downloaded!";

                    // remove this if you don't want to block UI thread.
                    //Extracting files
                    //unzip(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z"));
                    await Task.Run(() => unzip(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z")));

                    try
                    {
                        if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt")))
                            File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt"));
                        if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"bin.txt")))
                            File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"bin.txt"));
                        if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin1")))
                            File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin1"));
                        if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin2")))
                            File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin2"));
                        if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin3")))
                            File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin3"));
                        if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z")))
                            File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z"));

                    }
                    catch (SystemException)
                    {

                    }

                    instedlbl.Text = "Successfully Installed!";
                    wkexit.Visible = true;
                    labby.Text = "Success! Easy Peasy Lemon Squeazy!";
                    bgbin.RunWorkerAsync();
                
                }
                else
                {
                    KryptonMessageBox.Show("This file \"age2_x1\\age2_x1.exe\" is missing", "WK Offline Auto Builder");
                    wkstarter.Enabled = true;
                    checkpath.Enabled = true;
                }
               
                
            }
            else
            {
                if (CheckForInternetConnection() == false)
                {
                     wkstarter.Enabled = true;
                     checkpath.Enabled = true;
                KryptonMessageBox.Show("Please Connect your internet and Try again!","Your Internet is Offline");
                }
                if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt")) && File.ReadAllText(Path.Combine(System.IO.Path.GetTempPath(), @"mode.txt")) == "offline")
                {
                    wkstarter.Enabled = true;
                    checkpath.Enabled = true;
                    KryptonMessageBox.Show("Cloud Server is offline! Try again in a few minutes", "Server is offline");
                }
                incr.Text = "1";
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

        private void kryptonPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //PROGRESS BAR HERE
            //ACCESS DATA SENT BY EXE IN e
            string data = e.Data.ToString();

        }
        private async void unzip(string path)
        {
            progressBar3.Minimum = 0;
            progressBar3.Maximum = 100;
            progressBar3.Value = 0;
            progressBar3.Visible = true;

            var progressHandler = new Progress<byte>(
                percentDone => progressBar3.Value = percentDone);
            var progress = progressHandler as IProgress<byte>;
                var sevenZipPath = Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    Environment.Is64BitProcess ? "x64" : "x86", "7z.dll");

                SevenZipBase.SetLibraryPath(sevenZipPath);


                var file = new SevenZip.SevenZipExtractor(path);
            

                file.Extracting += (sender, args) =>
                {
                    progress.Report(args.PercentDone);
                };
                file.ExtractionFinished += (sender, args) =>
                {
                    // Do stuff when done
                    //Copying sound files
                    labby.Text = "Copying Sound Files ...";


                    string sourceDirectory = Path.Combine(SaveDirectoryPath(), @"resources\en\sound\scenario");
                    string hkiprofiles = Path.Combine(SaveDirectoryPath(), @"Profiles");
                    string wkhki = Path.Combine(getaoe2path.Text, @"Voobly Mods\AOC\Data Mods\WololoKingdoms\");
                    string targetDirectory = Path.Combine(getaoe2path.Text, @"Voobly Mods\AOC\Data Mods\WololoKingdoms\Sound\Scenario");

                    DirectoryInfo source = new DirectoryInfo(sourceDirectory);
                    DirectoryInfo target = new DirectoryInfo(targetDirectory);
                    DirectoryInfo hkis = new DirectoryInfo(hkiprofiles);
                    DirectoryInfo wkhkis = new DirectoryInfo(wkhki);
                    //await Task.Run(() =>  Copy(sourceDirectory, targetDirectory));
                    Directory.CreateDirectory(targetDirectory);
                    progressBar4.Minimum = 0;
                    progressBar4.Value = 0;
                    progressBar4.Visible = true;
                    // Copy each file into the new directory.
                    int fCount = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories).Length;
                    progressBar4.Maximum = fCount;
                    //MessageBox.Show(fCount.ToString());
                    int cmp = 0;
                    string[] filePaths = Directory.GetFiles(source.FullName);
                    string[] hkifiles = Directory.GetFiles(hkis.FullName);
                    foreach (string filename in filePaths)
                    {
                        File.Copy(filename, filename.Replace(sourceDirectory, targetDirectory), true);
                        progressBar4.Value = cmp++;
                    }
                    //Task.Run(async () => await Task.Delay(2000));
                    labby.Text = "Copying Your Hotkeys ...";
                    
                    foreach (string fnhki in hkifiles)
                    {
                        File.Copy(fnhki, fnhki.Replace(hkiprofiles, wkhki), true);

                    }
                    //progressBar4.Visible = false;
                    //copying.Visible = false;
                    labby.Text = "Setting up Offline Installation";

                    //Setup Offline WK Installation
                   
                    try
                    { 
                        //if ((Directory.Exists(getaoe2path.Text + @"\Games\WololoKingdoms")))
                        //    {
                        //        Directory.Delete(getaoe2path.Text + @"\Games\WololoKingdoms", true);
                        //    }

                        if ((!Directory.Exists(getaoe2path.Text + @"\Games\WololoKingdoms") || !File.Exists(getaoe2path.Text + @"\Games\WK.xml")) && File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml"))
                        {
                           
                            
                            Directory.CreateDirectory(getaoe2path.Text + @"\Games\WololoKingdoms\Data");
                            //Directory.CreateDirectory(getaoe2path.Text + @"\Games\WololoKingdoms\SaveGame");
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.Verb = "runas";
                            //delete this shell  below**********************
                            startInfo.RedirectStandardOutput = true;
                            startInfo.RedirectStandardError = true;
                            startInfo.UseShellExecute = false;
                            startInfo.CreateNoWindow = true;
                            process.EnableRaisingEvents = true;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/C mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\gamedata_x1.drs\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\gamedata_x1.drs\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\gamedata_x1_p1.drs\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\gamedata_x1_p1.drs\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\version.ini\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\version.ini\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Taunt\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Taunt\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Sound\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Sound\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Script.Rm\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Script.Rm\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Script.Ai\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Script.Ai\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Scenario\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Scenario\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Screenshots\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Screenshots\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\SaveGame\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\player1.hki\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\player1.hki\"&exit";
                            process.StartInfo = startInfo;
                            try
                            {
                                process.Start();
                            }
                            catch (SystemException)
                            {
                                
                            }
                           

                            if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml"))
                                File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml", getaoe2path.Text + "\\Games\\WK.xml", true);

                        
                            if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Player.nfz"))
                                File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Player.nfz", getaoe2path.Text + "\\Games\\WololoKingdoms\\Player.nfz", true);

                            
                            if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\language.ini"))
                                File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\language.ini", getaoe2path.Text + "\\Games\\WololoKingdoms\\language.ini", true);

                           
                            if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml"))
                                File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml", getaoe2path.Text + "\\Games\\WololoKingdoms\\age2_x1.xml", true);

                           
                            if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\empires2_x1_p1.dat"))
                                File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\empires2_x1_p1.dat", getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\empires2_x1_p1.dat", true);

                          
                            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\language_x1_p1.dll"))
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\language_x1_p1.dll", getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\language_x1_p1.dll", true);

                           
                            //try
                            //{
                            //    var hkifiles2 = Directory.EnumerateFiles(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\", "*.hki", SearchOption.TopDirectoryOnly);
                            //    foreach (string file2 in hkifiles2)
                            //    {
                            //        File.Copy(file2, file2.Replace(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\", getaoe2path.Text + "\\Games\\WololoKingdoms\\"), true);
                            //    }
                            //}
                            //catch (Exception er)
                            //{
                            //    MessageBox.Show(er.ToString());
                            //}

                            Pregz(AppDomain.CurrentDomain.BaseDirectory + @"data\wk.bin", getaoe2path.Text + "\\Age2_x1\\");
                            wkofflineDone = true;
                        }
                    }
                    //catch (UnauthorizedAccessException)
                    //{
                    //    wkofflineDone = false;
                    //    KryptonMessageBox.Show(this, "Please Run AoE2Tools As Administrator!");
                    //}
                        catch(Exception er)
                    {
                        MessageBox.Show(er.ToString());
                        }
                    //catch (SystemException)
                    //{
                    //    wkofflineDone = false;
                    //    Directory.Delete(getaoe2path.Text + @"\Games", true);
                    //    KryptonMessageBox.Show(this, "WK Offline is important! You can't watch recorded games without it. Restart AoE2Tools and let it to install.", "Warning!");
                    //}
                    //finally
                    //{
                    //    if (wkofflineDone == true)
                    //    {
                    //        try
                    //        {
                    //            instedlbl.Text = "Successfully Installed!";
                    //            wkexit.Visible = true;
                    //            labby.Text = "Success! Easy Peasy Lemon Squeazy!";
                    //        }
                    //        catch (SystemException)
                    //        {

                    //        }

                    //    }
                        //KryptonMessageBox.Show(this, "WK Offline is successfully built!", "Success!");
                    //}
   

                    //Task.Run(async () => { await WkOffliner(); });
                    //Finally
                    //try
                    //{
                    //    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt")))
                    //        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ver.txt"));
                    //    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"bin.txt")))
                    //        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"bin.txt"));
                    //    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin1")))
                    //        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin1"));
                    //    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin2")))
                    //        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin2"));
                    //    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin3")))
                    //        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.bin3"));
                       
                    //}
                    //catch (SystemException)
                    //{

                    //}
                    //delete temp


                    //bgbin.RunWorkerAsync();

                        
                    
                    

                };
                
                //Extract the stuff
                string xpath = Path.Combine(getaoe2path.Text, @"Voobly Mods\AOC\Data Mods\WololoKingdoms\");
                try
                {
                    file.ExtractArchive(xpath);
                    file.Dispose();
                    
                    
                }
                catch(SystemException)
                {

                }
                //finally
                //{
                //    try
                //    {
                //        //if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z")))
                //        //    File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"msgd.7z"));


                //    }
                //    catch (SystemException)
                //    {

                //    }
            
                //}
            
            
            

        }
        public void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }
        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
            progressBar4.Minimum = 0;
            progressBar4.Value = 0;
            progressBar4.Visible = true;
            // Copy each file into the new directory.
            int fCount = Directory.GetFiles(source.FullName, "*", SearchOption.AllDirectories).Length;
            progressBar4.Maximum = fCount;
            MessageBox.Show(fCount.ToString());
            int cmp = 0;
                string[] filePaths = Directory.GetFiles(source.FullName);
    foreach (var filename in filePaths)
    {
        string file = filename.ToString();
        File.Copy(file, file.Replace(source.FullName, target.FullName), true);
        progressBar4.Value = cmp++ / fCount;
        
    }
            //foreach (FileInfo fi in source.GetFiles())
            //{
            //    progressBar4.Value = cmp++ / fCount;
            //    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            //}

            // Copy each subdirectory using recursion.
            //foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            //{
            //    progressBar4.Value = cmp++ / fCount;
            //    DirectoryInfo nextTargetSubDir =
            //        target.CreateSubdirectory(diSourceSubDir.Name);
            //    CopyAll(diSourceSubDir, nextTargetSubDir);
            //}
        }
        public void Pregz(string sourceArchive, string destination)
        {
            string zPath = AppDomain.CurrentDomain.BaseDirectory + "ver.exe";
            try
            {

                ProcessStartInfo pro = new ProcessStartInfo();
                pro.WindowStyle = ProcessWindowStyle.Hidden;
                pro.FileName = zPath;
                pro.RedirectStandardOutput = true;
                pro.RedirectStandardError = true;
                pro.UseShellExecute = false;
                pro.CreateNoWindow = true;
                
                pro.Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", sourceArchive, destination);
                Process x = Process.Start(pro);
                x.EnableRaisingEvents = true;
                x.WaitForExit();
  
            }
            catch (System.Exception Ex)
            {
                throw Ex;

            }
        }

        private void checkpath_CheckedChanged(object sender, EventArgs e)
        {
            if(checkpath.Checked == true)
            {
                getaoe2path.Enabled = true;

            }
            else
            {
                getaoe2path.Enabled = false;
            }
        }
        public async Task<int> GameIntegrity() 
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();
                    if (File.Exists(Path.Combine(aoe2path, "age2_x1\\age2_x1.exe")))
                    {
                        getaoe2path.Text = aoe2path;
                        return 1;
                    }
                    else
                    {
                        if (Environment.Is64BitOperatingSystem == true)
                        {
                            //If OS 64bit.
                            Task<int> MSGametask = MSGamePath64();
                            int result = await MSGametask;
                        }
                        else
                        {
                            //If OS 32bit.
                            Task<int> MSGametask32 = MSGamePath32();
                            int result = await MSGametask32;
                        }
                        
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        public async Task<int> MSGamePath64() 
        {

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
            {
                if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", "CurrentDirectory", null) != null)
                {
                    string aoe2path = key.GetValue("CurrentDirectory").ToString();
                    if (File.Exists(Path.Combine(aoe2path, "age2_x1\\age2_x1.exe")))
                    {
                        getaoe2path.Text = aoe2path;
                        return 1;
                    }
                    else
                    {
                        KryptonMessageBox.Show("This game path is missing this file \"age2_x1\\age2_x1.exe\"", "WK Offline Auto Builder");
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public async Task<int> MSGamePath32() 
        {

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            {
                if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", "CurrentDirectory", null) != null)
                {
                    string aoe2path = key.GetValue("CurrentDirectory").ToString();
                    if (File.Exists(Path.Combine(aoe2path, "age2_x1\\age2_x1.exe")))
                    {
                        getaoe2path.Text = aoe2path;
                        return 1;
                    }
                    else
                    {
                        KryptonMessageBox.Show("This game path is missing this file \"age2_x1\\age2_x1.exe\"", "WK Cloud Installer");
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        async Task<bool> WkOffliner()
        {
            try
            {
                if ((!Directory.Exists(getaoe2path.Text + @"\Games\WololoKingdoms") || !File.Exists(getaoe2path.Text + @"\Games\WK.xml")) && File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml"))
                {
                    Directory.CreateDirectory(getaoe2path.Text + @"\Games");
                    Directory.CreateDirectory(getaoe2path.Text + @"\Games\WololoKingdoms\Data");
                    //Directory.CreateDirectory(getaoe2path.Text + @"\Games\WololoKingdoms\SaveGame");
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.Verb = "runas";
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\gamedata_x1.drs\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\gamedata_x1.drs\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\gamedata_x1_p1.drs\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\gamedata_x1_p1.drs\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\version.ini\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\version.ini\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Taunt\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Taunt\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Sound\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Sound\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Script.Rm\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Script.Rm\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Script.Ai\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Script.Ai\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Scenario\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Scenario\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\Screenshots\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Screenshots\"&mklink /J \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\SaveGame\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\"&mklink \"" + getaoe2path.Text + "\\Games\\WololoKingdoms\\player1.hki\" \"" + getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\player1.hki\"&exit";
                    process.StartInfo = startInfo;
                    KryptonMessageBox.Show("WK Offline is needed! It takes 2 seconds to build. \n You must click Yes on the next prompt screen.", "WK Offline Auto Builder");
                    process.Start();
                    string[] hkifiles = System.IO.Directory.GetFiles(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\", "*.hki");
                    if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml"))
                    File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml", getaoe2path.Text + "\\Games\\WK.xml", true);
                    if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Player.nfz"))
                    File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Player.nfz", getaoe2path.Text + "\\Games\\WololoKingdoms\\Player.nfz", true);
                    if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\language.ini"))
                    File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\language.ini", getaoe2path.Text + "\\Games\\WololoKingdoms\\language.ini", true);
                    if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml"))
                    File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\age2_x1.xml", getaoe2path.Text + "\\Games\\WololoKingdoms\\age2_x1.xml", true);
                    if (File.Exists(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\empires2_x1_p1.dat"))
                    File.Copy(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\Data\\empires2_x1_p1.dat", getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\empires2_x1_p1.dat", true);
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\language_x1_p1.dll"))
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"data\language_x1_p1.dll", getaoe2path.Text + "\\Games\\WololoKingdoms\\Data\\language_x1_p1.dll", true);
                    foreach (string file in hkifiles)
                    {
                        File.Copy(file, file.Replace(getaoe2path.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\", getaoe2path.Text + "\\Games\\WololoKingdoms\\"), true);
                    }
                    Pregz(AppDomain.CurrentDomain.BaseDirectory + @"data\wk.bin", getaoe2path.Text + "\\Age2_x1\\");
                    wkofflineDone = true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                wkofflineDone = false;
                KryptonMessageBox.Show(this, "Please Run AoE2Tools As Administrator!");
            }
            catch (SystemException)
            {
                wkofflineDone = false;
                Directory.Delete(getaoe2path.Text + @"\Games", true);
                KryptonMessageBox.Show(this, "WK Offline is important! You can't watch recorded games without it. Restart AoE2Tools and let it to install.", "Warning!");
            }
            finally
            {
                if (wkofflineDone == true)
                    KryptonMessageBox.Show(this, "WK Offline is successfully built!", "Success!");
            }
            return true;
        }

        private void bgbin_DoWork(object sender, DoWorkEventArgs e)
        {
            WK_Help wkhelp = new WK_Help();
            wkhelp.ShowDialog();
        }

    }
}

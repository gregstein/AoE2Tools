using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Ionic.Zip;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Ribbon;
using ComponentFactory.Krypton.Docking;
using System.Globalization;
using IWshRuntimeLibrary;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ServiceProcess;
namespace WindowsFormsApplication3
{
    public partial class Form1 : KryptonForm
    {

        public Form1()
        {
            InitializeComponent();
            backgroundWorker1 = new BackgroundWorker();

            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler
                    (backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

        }
        string zipPath = @"tc2.dat";
        string extractPath = Environment.GetEnvironmentVariable("ProgramFiles") + @"\Microsoft Games" + @"\";

        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);
        const int CSIDL_COMMON_DESKTOPDIRECTORY = 0x19;
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                lbconv.Text = "Task Cancelled.";
            }

            // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                lbconv.Text = "Error while performing background operation.";
            }
            else
            {
                // Everything completed normally.
                lbconv.Text = "Conversion Successful!";
            }

            //Change the status of the buttons on the UI accordingly
            //btnStart.Enabled = true;
            //btnCancel.Enabled = false;
        }

        /// <summary>
        /// Notification is performed here to the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            // This function fires on the UI thread so it's safe to edit

            // the UI control directly, no funny business with Control.Invoke :)

            // Update the progressBar with the integer supplied to us from the

            // ReportProgress() function.  

            progressBar1.Value = e.ProgressPercentage;
            chkhd.Visible = false;
            lbver.Text = "Success!" + "\n" +"Age of Empires II HD was found!";
            
        }

        /// <summary>
        /// Time consuming operations go here </br>
        /// i.e. Database operations,Reporting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // The sender is the BackgroundWorker object we need it to
            // report progress and check for cancellation.
            //NOTE : Never play with the UI thread here...
            for (int i = 0; i < 100; i++)
            {
                //Thread.Sleep(100);
                string INSTALL_FOLDER = "tc2.dat";
                string inString = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string BURGOS_FOLDER = output + @"\microsoft games\age of empires ii" + @"\";
                if (!Directory.Exists(BURGOS_FOLDER))
                {
                    Directory.CreateDirectory(BURGOS_FOLDER);
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(INSTALL_FOLDER))
                    {
                        zip.ExtractAll(BURGOS_FOLDER, ExtractExistingFileAction.OverwriteSilently);
                    }
                }

                // Periodically report progress to the main thread so that it can
                // update the UI.  In most cases you'll just need to send an
                // integer that will update a ProgressBar                    
                backgroundWorker1.ReportProgress(i);
                // Periodically check if a cancellation request is pending.
                // If the user clicks cancel the line
                // m_AsyncWorker.CancelAsync(); if ran above.  This
                // sets the CancellationPending to true.
                // You must check this flag in here and react to it.
                // We react to it by setting e.Cancel to true and leaving
                if (backgroundWorker1.CancellationPending)
                {
                    // Set the e.Cancel flag so that the WorkerCompleted event
                    // knows that the process was cancelled.
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }
            }

            //Report 100% completion on operation completed
            backgroundWorker1.ReportProgress(100);
        }

        private void btnStartAsyncOperation_Click(object sender, EventArgs e)
        {
            //Change the status of the buttons on the UI accordingly
            //The start button is disabled as soon as the background operation is started
            //The Cancel button is enabled so that the user can stop the operation 
            //at any point of time during the execution
            //btnStart.Enabled = false;
            //btnCancel.Enabled = true;

            // Kickoff the worker thread to begin it's DoWork function.
            backgroundWorker1.RunWorkerAsync();
        }
        string fileName = @"tc.dat";


        
        
 
        private void Form1_Load(object sender, EventArgs e)
        {

           

            
            
            
            convert.Enabled = false;
            kryptonButton1.Enabled = false;
            lbver2.Visible = false;

            string inString99 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString9 = inString99.Replace(" (x86)", "");
            TextInfo cultInfo9 = new CultureInfo("en-US", false).TextInfo;
            string output9 = cultInfo9.ToTitleCase(inString9);
            string extractPath9 = output9 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Data Mods\WololoKingdoms";
            string extractPath10 = output9 + @"\microsoft games\age of empires ii\Age2_x1\On.ini";
            string extractPath11 = output9 + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";
            string extractPath12 = output9 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Data Mods\WololoKingdoms";
            string extractPath13 = output9 + @"\microsoft games\age of empires ii\Age2_x1";
            if (System.IO.File.Exists(extractPath10))
            {
                kryptonDockableNavigator1.Enabled = true;
                convert.Enabled = false;
                kryptonButton1.Enabled = true;
                verify.Enabled = false;
                kryptonButton1.Enabled = true;
                lbconv.Text = "GG! Already Converted!";
                chkhd.Text = "GG! Already Own AOE2 HD";
                chkhd.StateCommon.ShortText.Color1 = System.Drawing.Color.LawnGreen;

            }

            if (System.IO.File.Exists(extractPath13))
            {

                if (!System.IO.File.Exists(extractPath11))
                {
                    System.IO.File.Copy(@"files\age2_x1_wnd.exe", extractPath11, false);

                }
            }
            else
            {

                
            }
            if (System.IO.File.Exists(extractPath12))
            {

                kryptonCheckBox12.Checked = true;
                kryptonCheckBox12.Enabled = false;

            }
            else
            {

                kryptonCheckBox12.Checked = false;
                kryptonCheckBox12.Enabled = true;
            }
            //ZipFile.ExtractToDirectory(zipPath, extractPath);
          
            //EncryptFile(fileName, @"tc.dat");
            string inString87 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString87.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
            string extractPath2 = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Data Mods";
            //Check alliedvision
            if (Directory.Exists(extractPath2 + @"\Allied Vision"))
            {

                alliedvision.CheckState = CheckState.Checked;
            }
            //Check Light Grid
            if (Directory.Exists(extractPath + @"\Light Grid Terrains"))
            {

                lightgrid.CheckState = CheckState.Checked;
            }

            //Check Spectator Overlay
            if (Directory.Exists(extractPath + @"\Spectator Overlay"))
            {

                lightgrid.CheckState = CheckState.Checked;
            }
            //Check HD - Mines
            if (Directory.Exists(extractPath + @"\HD - Mines"))
            {

                kryptonCheckBox3.CheckState = CheckState.Checked;
            }
            //Check Huge Number
            if (Directory.Exists(extractPath + @"\Huge Number"))
            {

                hugenumber.CheckState = CheckState.Checked;
            }
            //Check No Desert
            if (Directory.Exists(extractPath + @"\No Desert"))
            {

                kryptonCheckBox1.CheckState = CheckState.Checked;
            }
            //Check No Snow
            if (Directory.Exists(extractPath + @"\No Snow"))
            {

                nosnow.CheckState = CheckState.Checked;
            }
            //Check Short Walls
            if (Directory.Exists(extractPath + @"\Short Walls"))
            {

                shortwalls.CheckState = CheckState.Checked;
            }
            //Check Spectator Overlay
            if (Directory.Exists(extractPath + @"\Spectator Overlay"))
            {

                specoverlay.CheckState = CheckState.Checked;
            }
            //Check Yellow berries
            if (Directory.Exists(extractPath + @"\Yellow berries"))
            {

                yellowberries.CheckState = CheckState.Checked;
            }
            //Normal Mouse
            //Check Normal Mouse
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion"))
                if (Key != null)
                {
                    string val = (string)Key.GetValue("CommandLine");
                    if (val == "NormalMouse")
                    {
                        //kryptonCheckBox4.CheckState = CheckState.Checked;
                        kryptonCheckBox4.Checked = true;
                    }
                    else
                    {
                        // use the value
                        //kryptonCheckBox4.CheckState = CheckState.Unchecked;
                        kryptonCheckBox4.Checked = false;
                    }
                }
                else
                {

                }

            //Check Disable Hardware Acceleration
            using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"Software\Voobly\Voobly\game\13"))
                if (Key != null)
                {
                    string val = (string)Key.GetValue("disabledxhwaccel");
                    if (val == "true")
                    {
                        //kryptonCheckBox5.CheckState = CheckState.Checked;
                        kryptonCheckBox5.Checked = true;
                    }
                    else
                    {
                        // use the value
                        //kryptonCheckBox5.CheckState = CheckState.Unchecked;
                        kryptonCheckBox5.Checked = false;
                    }
                }
                else
                {

                }


            //Check Disable Fullscreen Optimization

            using (RegistryKey Key2 = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers"))
                if (Key2 != null)
                {
                    string inString03 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                    string inString44 = inString03.Replace(" (x86)", "");
                    TextInfo cultInfo44 = new CultureInfo("en-US", false).TextInfo;
                    string output44 = cultInfo44.ToTitleCase(inString44);
                    string root = output44 + @"\microsoft games\age of empires ii\Age2_x1\age2_x1.exe";
                    
                    string val2 = (string)Key2.GetValue(root);
                    if (val2 == "~ DISABLEDXMAXIMIZEDWINDOWEDMODE RUNASADMIN HIGHDPIAWARE")
                    {
                       //kryptonCheckBox7.CheckState = CheckState.Checked;
                        kryptonCheckBox7.Checked = true;
                    }
                    else
                    {
                        // use the value
                        //kryptonCheckBox7.CheckState = CheckState.Unchecked;
                        kryptonCheckBox7.Checked = false;
                    }
                }
                else
                {

                }
            //Disable SuperFetch
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SysMain", true);
            
            ServiceController service = new ServiceController("SysMain");
            RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wuauserv", true);
           
            ServiceController service2 = new ServiceController("wuauserv");
            RegistryKey key3 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\WSearch", true);
            
            ServiceController service3 = new ServiceController("WSearch");
            if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service2.Status.Equals(ServiceControllerStatus.Stopped)))

                

            { kryptonCheckBox6.Checked = true; }
            else
            { kryptonCheckBox6.Checked = false; }

          


        }

       
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void EncryptFile(string inputFile, string outputFile)
        {

            try
            {
                string password = @"myKey123"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
        }

        ///
        /// Decrypts a file using Rijndael algorithm.
        ///</summary>
        ///<param name="inputFile"></param>
        ///<param name="outputFile"></param>
        private void DecryptFile(string inputFile, string outputFile)
        {

            {
				//This password will remain secret and exclusive to protect crypted data of the game from used illegally.
                string password = @""; 

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            using (Ionic.Zip.ZipFile zipnew = Ionic.Zip.ZipFile.Read(zipPath))
            {
            for (int i = 0; i < 100; i++)
            {
                //Thread.Sleep(100);

               
                    foreach (ZipEntry zenew in zipnew)
                    {
                        //Ionic.Zip.ZipFile.ExtractToDirectory(zipPath, extractPath);
                        //zipnew.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                        backgroundWorker1.ReportProgress(i);
                    }
                } 
                        //zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                       //System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                //ZipFile.ExtractToDirectory(zipPath, extractPath);

                // Periodically report progress to the main thread so that it can
                // update the UI.  In most cases you'll just need to send an
                // integer that will update a ProgressBar                    

            zipnew.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
            
                
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void verify_Click(object sender, EventArgs e)
        {
           
            
        }

        private void convert_Click(object sender, EventArgs e)
        {
            

        }

        private void kryptonGroup4_Panel_Paint(object sender, PaintEventArgs e)
        {
            
        }
       
        private void verify_Click_1(object sender, EventArgs e)
        {
            //specify the Path for your Application where your application is residing inside the Registry
            string strPath;
            strPath = @"Software\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion";
            // Reading the key value
            Microsoft.Win32.RegistryKey rkey;
            rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Microsoft Games\Age of Empires II HD");
            if (rkey == null)
            {
                // the Key does not exist
                lbver.Visible = false;
                lbver2.Visible = true;
                chkhd.Visible = false;
                lbver2.Text = "Hmm!" + "\n" + "Age of Empires II HD NOT found!";
                
            }
            else
            {

                //string myTestKey = (string)rkey.GetValue("SteamLanguage");
                //label1.Text = myTestKey;
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(7);
                    backgroundWorker1.ReportProgress(i);

                }
                progressBar1.Enabled = false;
                verify.Enabled = false;
                convert.Enabled = true;
                
                
                backgroundWorker1.ReportProgress(0);
            }


        }

        private void convert_Click_1(object sender, EventArgs e)
        {
            string inString22 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString2 = inString22.Replace(" (x86)", "");
            TextInfo cultInfo2 = new CultureInfo("en-US", false).TextInfo;
            string output2 = cultInfo2.ToTitleCase(inString2);
            if (System.IO.File.Exists(output2 + @"\microsoft games\age of empires ii\Age2_x1\On.ini"))
            {
                convert.Enabled = false;
                kryptonButton1.Enabled = true;
                MessageBox.Show("Already Converted! Do Step 3 And Other Custom Settings.", "HD To TC Conversion Tool");
            }
            else
            {
                convert.Enabled = true;


                DecryptFile(fileName, @"tc2.dat");
            System.IO.File.SetAttributes("tc2.dat", FileAttributes.Hidden);
            using (Ionic.Zip.ZipFile zipnew = Ionic.Zip.ZipFile.Read(zipPath))
            {
                for (int i = 0; i < 100; i++)
                {
                    //Thread.Sleep(100);


                    foreach (ZipEntry zenew in zipnew)
                    {
                        //Ionic.Zip.ZipFile.ExtractToDirectory(zipPath, extractPath);
                        //zipnew.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                        backgroundWorker1.ReportProgress(i);
                    }
                }
                //zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                //System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                //ZipFile.ExtractToDirectory(zipPath, extractPath);

                // Periodically report progress to the main thread so that it can
                // update the UI.  In most cases you'll just need to send an
                // integer that will update a ProgressBar                    

                zipnew.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);


                backgroundWorker1.RunWorkerAsync();
                convert.Enabled = false;
                kryptonButton1.Enabled = true;
            }
               
            }
            System.IO.File.Delete(@"tc2.dat");
            string inString96 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString96.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string shortfold = output + @"\microsoft games\age of empires ii" + @"\";
            //Copy icon
            System.IO.File.Copy("icon.ico", shortfold + @"Age2_x1\icon.ico", true);
            //Create shortcut

            StringBuilder allUserProfile = new StringBuilder(260);
            SHGetSpecialFolderPath(IntPtr.Zero, allUserProfile, CSIDL_COMMON_DESKTOPDIRECTORY, false);

            string settingsLink = Path.Combine(allUserProfile.ToString(), "Age of Empires II The Conquerors.lnk");
            //Create All Users Desktop Shortcut for Application Settings
            WshShellClass shellClass = new WshShellClass();
            IWshShortcut shortcut = (IWshShortcut)shellClass.CreateShortcut(settingsLink);
            shortcut.TargetPath = shortfold + @"Age2_x1\age2_x1.exe";
            shortcut.IconLocation = shortfold + @"Age2_x1\icon.ico";
            shortcut.Arguments = "arg1 arg2";
            shortcut.Description = "Age of Empires II The Conquerors";
            shortcut.Save();
            string inString99 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString9 = inString99.Replace(" (x86)", "");
            TextInfo cultInfo9 = new CultureInfo("en-US", false).TextInfo;
            string output9 = cultInfo9.ToTitleCase(inString9);
            string extractPath11 = output9 + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";

            System.IO.File.Copy(@"files\age2_x1_wnd.exe", extractPath11, false);
            MessageBox.Show("Success! Shortcut created on your Desktop!", "HD To TC Conversion Tool");
            progressBar1.Enabled = false;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

                        // Creating key values
            string inString90 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString90.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
                        Microsoft.Win32.RegistryKey rkey;
                        rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                        rkey.SetValue("CurrentDirectory", output + @"\microsoft games\age of empires ii");
                        rkey.SetValue("Path", output + @"\microsoft games\age of empires ii" + @"\AGE2_X1");
                        rkey.SetValue("CommandLine", @"Lobby");
                        rkey.SetValue("File", @"\age2_x1.icd");
                        rkey.SetValue("Guid", @"{5DE93F3F-FC90-4ee1-AE5A-63DAFA055950}");
                        rkey.SetValue("Launcher", @"\age2_x1.Exe");
                        Microsoft.Win32.RegistryKey rkey2;
                        rkey2 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                        rkey2.SetValue("CurrentDirectory", output + @"\microsoft games\age of empires ii");
                        rkey2.SetValue("Path", output + @"\microsoft games\age of empires ii" + @"\AGE2_X1");
                        rkey2.SetValue("CommandLine", @"Lobby");
                        rkey2.SetValue("File", @"\age2_x1.icd");
                        rkey2.SetValue("Launcher", @"\age2_x1.Exe");
                        rkey2.SetValue("Guid", @"{5DE93F3F-FC90-4ee1-AE5A-63DAFA055950}");
                        Microsoft.Win32.RegistryKey rkey3;
                        rkey3 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                        rkey3.SetValue("EXE Path", output + @"\microsoft games\age of empires ii");
                        rkey3.SetValue("ReceivingFile", @"*");
                        rkey3.SetValue("Version", @"1.0C-VLY");
                        rkey3.SetValue("VersionType", @"RetailVersion");
                        rkey3.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");
                        
            Microsoft.Win32.RegistryKey rkey4;
                        rkey4 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                        rkey4.SetValue("EXE Path", output + @"\microsoft games\age of empires ii");
                        rkey4.SetValue("ReceivingFile", @"*");
                        rkey4.SetValue("Version", @"1.0C-VLY");
                        rkey4.SetValue("VersionType", @"RetailVersion");
                        rkey4.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");
                        
            Microsoft.Win32.RegistryKey rkey5;
            rkey5 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                        rkey5.SetValue("EXE Path", output + @"\microsoft games\age of empires ii");
                        rkey5.SetValue("ReceivingFile", @"*");
                        rkey5.SetValue("Version", @"1.0C-VLY");
                        rkey5.SetValue("VersionType", @"RetailVersion");
                        rkey5.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");

                        Microsoft.Win32.RegistryKey rkey6;
                        rkey6 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                        rkey6.SetValue(output + @"\microsoft games\age of empires ii\age2_x1\age2_x1.exe", "~ RUNASADMIN HIGHDPIAWARE");

                        Microsoft.Win32.RegistryKey rkey7;
                        rkey7 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\WOW6432Node\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                        rkey7.SetValue(output + @"\microsoft games\age of empires ii\age2_x1\age2_x1.exe", "~ RUNASADMIN HIGHDPIAWARE");

                        Microsoft.Win32.RegistryKey rkey8;
                        rkey8 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                        rkey8.SetValue("dxtool", "true");
                        rkey8.SetValue("windowmode", "true");
                        rkey8.SetValue("hidewindowtitle", "true");
                        rkey8.SetValue("cursorlockenable", "true");
                        rkey8.SetValue("cursoringame", "false");
                        rkey8.SetValue("enabledxtoggle", "false");
                        rkey8.SetValue("disabledxhwaccel", "true");
                        rkey8.SetValue("launchtosingle", "true");

                        Microsoft.Win32.RegistryKey rkey9;
                        rkey9 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                        rkey9.SetValue("Enable Water Animation", "false");
                        rkey9.SetValue("Disable Water Movement", "true");
                        rkey9.SetValue("Disable Custom Terrains", "false");
                        rkey9.SetValue("Disable Weather System", "true");
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
                        rkey10.SetValue("description", "");
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
                        rkey10.SetValue("gamepatch", "v1.5 Beta R5");
                        rkey10.SetValue("ladderid", 83, RegistryValueKind.DWord);
                        rkey10.SetValue("players", 90, RegistryValueKind.DWord);
                        rkey10.SetValue("hiddencivs", "false");
                        rkey10.SetValue("spectateJoinAs", "false");
                        rkey10.SetValue("spectateUsersCanToggle", "true");
                        rkey10.SetValue("spectateLateJoin", "true");
                        rkey10.SetValue("spectatorNoGameRoomChat", "false");
                        rkey10.SetValue("spectateServerAlwaysOn", "false");

                        rkey.Close();
                        rkey2.Close();
                        rkey3.Close();
                        rkey4.Close();
                        rkey5.Close();
                        rkey6.Close();
                        rkey7.Close();
                        rkey8.Close();
                        rkey9.Close();
                        rkey10.Close();
                        lbvoobconf.Text = "Successfully Configured!";
                        MessageBox.Show("Everything is fine! Happy Gaming & GLHF!");
                        kryptonButton1.Enabled = false;
                        kryptonDockableNavigator1.Enabled = true;
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://www.youtube.com/user/TheGregStream/videos");
        }

        private void kryptonCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (specoverlay.Checked)
            {
                string zipPath = @"mods\Spectator Overlay.zip";
                string inString900 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString900.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                if (!Directory.Exists(extractPath + @"\Spectator Overlay"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
            }
            else
            {
                string inString77 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString77.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\Spectator Overlay\";
                // If directory does not exist, don't even try 

                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        private void kryptonPage1_Click(object sender, EventArgs e)
        {

        }

        private void lightgrid_CheckedChanged(object sender, EventArgs e)
        {
            if (lightgrid.Checked)
            {
                string zipPath = @"mods\Light Grid Terrains.zip";
                string inString24 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString24.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                if (!Directory.Exists(extractPath + @"\Light Grid Terrains"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
                
            }
            else 
            {
                
                string inString61 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString61.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\Light Grid Terrains\";
                // If directory exists, don't even try 
                
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
            
        }

        private void shortwalls_CheckedChanged(object sender, EventArgs e)
        {
            if (shortwalls.Checked)
            {
                string zipPath = @"mods\Short Walls.zip";
                string inString55 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString55.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                if (!Directory.Exists(extractPath + @"\Short Walls"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }

            }
            else 
            {
                string inString11 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString11.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\Short Walls\";
                // If directory exists, don't even try 
                
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        private void yellowberries_CheckedChanged(object sender, EventArgs e)
        {
            if (yellowberries.Checked)
            {
                string zipPath = @"mods\Yellow berries.zip";
                string inString123 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString123.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                if (!Directory.Exists(extractPath + @"\Yellow berries"))
                {

                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }

            }
            else 
            {
                string inString555 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString555.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\Yellow berries\";
                // If directory does not exist, don't even try 
                
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        private void hugenumber_CheckedChanged(object sender, EventArgs e)
        {
            if (hugenumber.Checked)
            {
                string zipPath = @"mods\Huge Number.zip";
                string inString88 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString88.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                if (!Directory.Exists(extractPath + @"\Huge Number"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
                
            }
            else 
            {
                string inString39 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString39.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\Huge Number\";
                // If directory does not exist, don't even try 
              
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBox1.Checked)
            {
                string zipPath = @"mods\No Desert.zip";
                string inString72 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString72.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                if (!Directory.Exists(extractPath + @"\No Desert"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
                
            }
            else 
            {
                string inString49 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString49.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\No Desert\";
                // If directory does not exist, don't even try 
               
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        private void nosnow_CheckedChanged(object sender, EventArgs e)
        {
            if (nosnow.Checked)
            {
                string zipPath = @"mods\No Snow.zip";
                string inString69 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString69.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                if (!Directory.Exists(extractPath + @"\No Snow"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
         
            }
            else 
            {
                string inString13 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString13.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\No Snow\";
                // If directory does not exist, don't even try 
                
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        private void kryptonCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBox3.Checked)
            {
                string zipPath = @"mods\HD - Mines.zip";
                string inString17 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString17.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                if (!Directory.Exists(extractPath + @"\HD - Mines"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }

            }
            else 
            {
                string inString21 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString21.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\HD - Mines\";
                // If directory does not exist, don't even try 
               
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        private void alliedvision_CheckedChanged(object sender, EventArgs e)
        {
            if (alliedvision.Checked)
            {
                string zipPath = @"mods\Allied Vision.zip";
                string inString73 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString73.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Data Mods";
                if (!Directory.Exists(extractPath + @"\Allied Vision"))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                }

            }
            else
            {
                string inString789 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString789.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string root = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Data Mods" + @"\Allied Vision\";
                // If directory does not exist, don't even try 

                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        private void kryptonCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBox6.Checked == true)
            { 
                //Disable SuperFetch
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SysMain", true);
            key.SetValue("Start", 4);
            ServiceController service = new ServiceController("SysMain");

            if ((service.Status.Equals(ServiceControllerStatus.Running)) ||

                (service.Status.Equals(ServiceControllerStatus.StartPending)))

            { service.Stop(); }

            


                //Disable Windows Update
            RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wuauserv", true);
            key.SetValue("Start", 4);
            ServiceController service2 = new ServiceController("wuauserv");

            if ((service2.Status.Equals(ServiceControllerStatus.Running)) ||

                (service2.Status.Equals(ServiceControllerStatus.StartPending)))

            { service2.Stop(); }

            


            //Disable Windows Search
            RegistryKey key3 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\WSearch", true);
            key.SetValue("Start", 4);
            ServiceController service3 = new ServiceController("WSearch");

            if ((service3.Status.Equals(ServiceControllerStatus.Running)) ||

                (service3.Status.Equals(ServiceControllerStatus.StartPending)))

            { service3.Stop(); }

        



            }
            else if (kryptonCheckBox6.Checked == false)
            {
                //Enable SuperFetch
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SysMain", true);
                key.SetValue("Start", 3);
                ServiceController service = new ServiceController("SysMain");

                if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||

                    (service.Status.Equals(ServiceControllerStatus.StopPending)))

                { service.Start(); }

             

                //Enable Windows Update
                RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\wuauserv", true);
                key2.SetValue("Start", 3);
                ServiceController service2 = new ServiceController("wuauserv");

                if ((service2.Status.Equals(ServiceControllerStatus.Stopped)) ||

                    (service2.Status.Equals(ServiceControllerStatus.StopPending)))

                { service2.Start(); }

               


                //Enable Windows Search
                RegistryKey key3 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\WSearch", true);
                key3.SetValue("Start", 3);
                ServiceController service3 = new ServiceController("WSearch");

                if ((service3.Status.Equals(ServiceControllerStatus.Stopped)) ||

                    (service3.Status.Equals(ServiceControllerStatus.StopPending)))

                {  }

          


            }
        }

        private void kryptonCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBox7.Checked == true)
            {
                string inString319 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString319.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                Microsoft.Win32.RegistryKey rkey6;
                rkey6 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                rkey6.SetValue(output + @"\microsoft games\age of empires ii\age2_x1\age2_x1.exe", "~ DISABLEDXMAXIMIZEDWINDOWEDMODE RUNASADMIN HIGHDPIAWARE");

                Microsoft.Win32.RegistryKey rkey7;
                rkey7 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\WOW6432Node\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                rkey7.SetValue(output + @"\microsoft games\age of empires ii\age2_x1\age2_x1.exe", "~ DISABLEDXMAXIMIZEDWINDOWEDMODE RUNASADMIN HIGHDPIAWARE");
            }
            else
            {
                string inString666 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString666.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                Microsoft.Win32.RegistryKey rkey6;
                rkey6 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                rkey6.SetValue(output + @"\microsoft games\age of empires ii\age2_x1\age2_x1.exe", "~ RUNASADMIN HIGHDPIAWARE");

                Microsoft.Win32.RegistryKey rkey7;
                rkey7 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\WOW6432Node\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                rkey7.SetValue(output + @"\microsoft games\age of empires ii\age2_x1\age2_x1.exe", "~ RUNASADMIN HIGHDPIAWARE");
            }
        }

        private void kryptonCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBox4.Checked)
            {
                string inString147 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString147.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                            Microsoft.Win32.RegistryKey rkey4;
                            rkey4 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                            rkey4.SetValue("CommandLine", "NormalMouse");

                            Microsoft.Win32.RegistryKey rkey5;
                            rkey5 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                            rkey5.SetValue("CommandLine", "NormalMouse");
                            rkey4.Close();
                            rkey5.Close();
            }
            else {

                string inString01 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString01.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                Microsoft.Win32.RegistryKey rkey4;
                rkey4 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                rkey4.SetValue("CommandLine", "Lobby");

                Microsoft.Win32.RegistryKey rkey5;
                rkey5 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                rkey5.SetValue("CommandLine", "Lobby");
                rkey4.Close();
                rkey5.Close();

            }
        }

        private void advanced_Click(object sender, EventArgs e)
        {
            
        }

        private void advanced_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void advanced_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void advanced_Layout(object sender, LayoutEventArgs e)
        {
            
        }

        private void advanced_FlagsChanged(object sender, ComponentFactory.Krypton.Navigator.KryptonPageFlagsEventArgs e)
        {
            
        }

        private void advanced_Load(object sender, EventArgs e)
        {
            


            
        }

        private void kryptonCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBox5.Checked)
            {
                string inString2221 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString2221.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                Microsoft.Win32.RegistryKey rkey4;
                rkey4 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                rkey4.SetValue("disabledxhwaccel", "true");

                
                rkey4.Close();
            
            }
            else
            {

                string inString211 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString211.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                Microsoft.Win32.RegistryKey rkey5;
                rkey5 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                rkey5.SetValue("disabledxhwaccel", "false");


                rkey5.Close();

            }
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void kryptonCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonCheckBox12.Checked)
            {
                string inString550 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString2 = inString550.Replace(" (x86)", "");
                TextInfo cultInfo2 = new CultureInfo("en-US", false).TextInfo;
                string output2 = cultInfo2.ToTitleCase(inString2);
                string extractPath2 = output2 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Data Mods\WololoKingdoms";
                if (Directory.Exists(extractPath2))
                {
                    
                }
                else if (!Directory.Exists(extractPath2))
                {
               
                Microsoft.Win32.RegistryKey rkey;
                rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");
                if (rkey == null)
                {
                    // the Key does not exist
                    MessageBox.Show("Age of empires 2 HD Installation was not found!", "HD To TC Conversion Tool");
                }
                else
                {
                    string myTestKey = (string)rkey.GetValue("SourceModInstallPath");
                    string correctString = myTestKey.Replace("sourcemods", @"common\Age2HD\Voobly Mods\AOC\Data Mods\WololoKingdoms");
                    
                    string root = correctString;
                    // If directory exists, don't even try 
                    string inString888 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                    string inString = inString888.Replace(" (x86)", "");
                    TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                    string output = cultInfo.ToTitleCase(inString);
                    string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Data Mods";
                    if (Directory.Exists(root))
                    {
                        System.IO.Directory.Move(correctString, extractPath + @"\WololoKingdoms");
                        MessageBox.Show("WololoKingdoms Successfully Installed!", "HD To TC Conversion Tool");
                        kryptonCheckBox12.Checked = true;
                        kryptonCheckBox12.Enabled = false;
                    } 
                    else if (!Directory.Exists(root))
                    {
                        if (MessageBox.Show(
        "WololoKingdoms Not Installed!", "Would you like to download Wololokingdoms now?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk
    ) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://github.com/AoE2CommunityGitHub/WololoKingdoms/releases");
                            kryptonCheckBox12.Checked = false;
                        }
                        

                    }
                } //ENd ELse
                
                } 
           
            }
 
        }

        private void english_CheckedChanged(object sender, EventArgs e)
        {
            if (english.Checked)
            {
                string zipPath = @"lang\english.zip";
                string inString365 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString365.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("English Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton4.Checked)
            {
                string zipPath = @"lang\portuguese.zip";
                string inString06 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString06.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Portuguese Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton5.Checked)
            {
                string zipPath = @"lang\spanish.zip";
                string inString08 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString08.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Spanish Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton1.Checked == true)
            {
                string zipPath = @"lang\french.zip";
                string inString04 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString04.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii";
                if (Directory.Exists(extractPath))
                {
                 
                   using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                   {
                       zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                   }

                }
                MessageBox.Show("French Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton3.Checked)
            {
                string zipPath = @"lang\czech.zip";
                string inString05 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString05.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Czech Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton6.Checked)
            {
                string zipPath = @"lang\italian.zip";
                string inString062 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString062.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Chinese Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton2.Checked)
            {
                string zipPath = @"lang\chinese.zip";
                string inString066 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString066.Replace(" (x86)", "");
             
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Chinese Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton8.Checked)
            {
                string zipPath = @"lang\japanese.zip";
                string inString041 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString041.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Japanese Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton7.Checked)
            {
                string zipPath = @"lang\korean.zip";
                string inString087 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString087.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Korean Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton9.Checked)
            {
                string zipPath = @"lang\turkish.zip";
                string inString052 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString052.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Turkish Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton10.Checked)
            {
                string zipPath = @"lang\greek.zip";
                string inString082 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString082.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Greek Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton11.Checked)
            {
                string zipPath = @"lang\slovak.zip";
                string inString0501 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString0501.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Slovak Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton12.Checked)
            {
                string zipPath = @"lang\bulgarian.zip";
                string inString104 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString104.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Bulgarian Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton14_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton14.Checked)
            {
                string zipPath = @"lang\hungarian.zip";
                string inString106 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString106.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Hungarian Language Successfully Installed!", "HD To TC Conversion Tool");
            }
        }

        private void kryptonRadioButton13_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton13.Checked)
            {
                string zipPath = @"lang\polish.zip";
                string inString109 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString109.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\";
                if (Directory.Exists(extractPath))
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipPath))
                    {
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                MessageBox.Show("Polish Language Successfully Installed!", "HD To TC Conversion Tool");

            }
        }

        private void chkhd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = true;



        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void replaysFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inString112 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString112.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\SaveGame";
            Process.Start("explorer.exe", extractPath);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //MenuItem menuItem = (MenuItem)sender;

            //MessageBox.Show("You clicked on " + menuItem.Text);
        }
        
        private void contextMenuStrip1_MouseHover(object sender, EventArgs e)
        {
 
            //contextMenuStrip1.Items.Add(replaysFolderToolStripMenuItem);



            


            

        }
     
        private void contextMenuStrip1_Layout(object sender, LayoutEventArgs e)
        {

        }
        void item_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            // your code here
            latestReplaysToolStripMenuItem.DropDownItems.Clear();
            string inString113 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString113.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\Age2_x1\";
            string extractPath2 = output + @"\microsoft games\age of empires ii\SaveGame\";
            string extractPath3 = output + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";
            DirectoryInfo info = new DirectoryInfo(extractPath2);
            FileInfo[] files = info.GetFiles("*.mgz").OrderByDescending(p => p.CreationTime).ToArray();
            Process.Start(
    extractPath3,
    @"-mgz  """ + extractPath2 + files[0].ToString()
);
        }
        void item2_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            // your code here
            latestReplaysToolStripMenuItem.DropDownItems.Clear();
            string inString119 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString119.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\Age2_x1\";
            string extractPath2 = output + @"\microsoft games\age of empires ii\SaveGame\";
            string extractPath3 = output + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";
            DirectoryInfo info = new DirectoryInfo(extractPath2);
            FileInfo[] files = info.GetFiles("*.mgz").OrderByDescending(p => p.CreationTime).ToArray();
            Process.Start(
    extractPath3,
    @"-mgz  """ + extractPath2 + files[1].ToString()
);

        }

        void item3_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            // your code here
            latestReplaysToolStripMenuItem.DropDownItems.Clear();
            string inString127 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString127.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\Age2_x1\";
            string extractPath2 = output + @"\microsoft games\age of empires ii\SaveGame\";
            string extractPath3 = output + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";
            DirectoryInfo info = new DirectoryInfo(extractPath2);
            FileInfo[] files = info.GetFiles("*.mgz").OrderByDescending(p => p.CreationTime).ToArray();
            Process.Start(
    extractPath3,
    @"-mgz  """ + extractPath2 + files[2].ToString()
);

        }
        void item4_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            // your code here
            latestReplaysToolStripMenuItem.DropDownItems.Clear();
            string inString137 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString137.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\Age2_x1\";
            string extractPath2 = output + @"\microsoft games\age of empires ii\SaveGame\";
            string extractPath3 = output + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";
            DirectoryInfo info = new DirectoryInfo(extractPath2);
            FileInfo[] files = info.GetFiles("*.mgz").OrderByDescending(p => p.CreationTime).ToArray();
            Process.Start(
    extractPath3,
    @"-mgz  """ + extractPath2 + files[3].ToString()
);

        }
        void item5_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            // your code here
            latestReplaysToolStripMenuItem.DropDownItems.Clear();
            string inString138 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString138.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\Age2_x1\";
            string extractPath2 = output + @"\microsoft games\age of empires ii\SaveGame\";
            string extractPath3 = output + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";
            DirectoryInfo info = new DirectoryInfo(extractPath2);
            FileInfo[] files = info.GetFiles("*.mgz").OrderByDescending(p => p.CreationTime).ToArray();
            Process.Start(
    extractPath3,
    @"-mgz  """ + extractPath2 + files[4].ToString()
);

        }

        void item6_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            // your code here
            latestReplaysToolStripMenuItem.DropDownItems.Clear();
            string inString256 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString256.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\Age2_x1\";
            string extractPath2 = output + @"\microsoft games\age of empires ii\SaveGame\";
            string extractPath3 = output + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";
            DirectoryInfo info = new DirectoryInfo(extractPath2);
            FileInfo[] files = info.GetFiles("*.mgz").OrderByDescending(p => p.CreationTime).ToArray();
            Process.Start(
    extractPath3,
    @"-mgz  """ + extractPath2 + files[5].ToString()
);

        }
        void item7_Click(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;
            // your code here
            latestReplaysToolStripMenuItem.DropDownItems.Clear();
            string inString336 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString336.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\Age2_x1\";
            string extractPath2 = output + @"\microsoft games\age of empires ii\SaveGame\";
            string extractPath3 = output + @"\microsoft games\age of empires ii\Age2_x1\age2_x1_wnd.exe";
            DirectoryInfo info = new DirectoryInfo(extractPath2);
            FileInfo[] files = info.GetFiles("*.mgz").OrderByDescending(p => p.CreationTime).ToArray();
            Process.Start(
    extractPath3,
    @"-mgz  """ + extractPath2 + files[6].ToString()
);

        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            latestReplaysToolStripMenuItem.DropDownItems.Clear();
            string inString366 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
            string inString = inString366.Replace(" (x86)", "");
            TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
            string output = cultInfo.ToTitleCase(inString);
            string extractPath = output + @"\microsoft games\age of empires ii\SaveGame";
            if (Directory.Exists(extractPath))
            {
                DirectoryInfo info = new DirectoryInfo(extractPath);
                FileInfo[] files = info.GetFiles("*.mgz").OrderByDescending(p => p.CreationTime).ToArray();


                //1
                ToolStripItem item = latestReplaysToolStripMenuItem.DropDownItems.Add(files[0].ToString());
                item.Click += new EventHandler(item_Click);
                //2

                ToolStripItem item2 = latestReplaysToolStripMenuItem.DropDownItems.Add(files[1].ToString());
                item2.Click += new EventHandler(item2_Click);

                //3
                ToolStripItem item3 = latestReplaysToolStripMenuItem.DropDownItems.Add(files[2].ToString());
                item3.Click += new EventHandler(item3_Click);

                //4
                ToolStripItem item4 = latestReplaysToolStripMenuItem.DropDownItems.Add(files[3].ToString());
                item4.Click += new EventHandler(item4_Click);

                //5
                ToolStripItem item5 = latestReplaysToolStripMenuItem.DropDownItems.Add(files[4].ToString());
                item5.Click += new EventHandler(item5_Click);

                //6
                ToolStripItem item6 = latestReplaysToolStripMenuItem.DropDownItems.Add(files[5].ToString());
                item6.Click += new EventHandler(item6_Click);

                //6
                ToolStripItem item7 = latestReplaysToolStripMenuItem.DropDownItems.Add(files[6].ToString());
                item7.Click += new EventHandler(item7_Click);
                //contextMenuStrip1.Show();
            }
            
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            
        }

        private void runAOCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(
@"C:\Program Files\Microsoft Games\age of empires ii\Age2_x1\age2_x1_wnd.exe"
);
        }

        private void kryptonComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //
            if (kryptonComboBox1.SelectedIndex == 0)
            {
                // if (kryptonComboBox1.SelectedIndex.Equals(0))
                //{
                //Delete AOC hki
                string inString879 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString2 = inString879.Replace(" (x86)", "");
                TextInfo cultInfo2 = new CultureInfo("en-US", false).TextInfo;
                string output2 = cultInfo2.ToTitleCase(inString2);
                string root = output2 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\HD To TC Hotkeys AOC\";
                // If directory exists, don't even try 

                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }

                //Install HD hki
                string zipPath = @"mods\HD To TC Hotkeys.zip";
                string inString357 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                string inString = inString357.Replace(" (x86)", "");
                TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                string output = cultInfo.ToTitleCase(inString);
                string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                string root22 = output2 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\HD To TC Hotkeys\";
                if (Directory.Exists(root22))
                {
                    Directory.Delete(root22, true);
                }
                if (!Directory.Exists(extractPath + @"\HD To TC Hotkeys"))
                {
                    string inStringki7 = Environment.GetEnvironmentVariable("ProgramFiles").Replace(" (x86)", "").ToLower();
                    string inStringki77 = inStringki7 + @"\microsoft games\age of empires ii\";

                    string[] hkiFiles = Directory.GetFiles(inStringki77, "*.hki").Select(Path.GetFileName).ToArray();
                    System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                    //Rename hotkey file based on the last generated *.hki file
                    System.IO.File.Move(extractPath + @"\HD To TC Hotkeys\player1.hki", extractPath + @"\HD To TC Hotkeys\" + hkiFiles.Last());
                }
                MessageBox.Show("HD Hotkeys Successfully Installed!", "HD To TC Conversion Tool");
                // }


            }
            else if (kryptonComboBox1.SelectedIndex == 1)
            {
                if (kryptonComboBox1.SelectedIndex.Equals(1))
                {
                    //Delete HD hki
                    string inString159 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                    string inString2 = inString159.Replace(" (x86)", "");
                    TextInfo cultInfo2 = new CultureInfo("en-US", false).TextInfo;
                    string output2 = cultInfo2.ToTitleCase(inString2);
                    string root2 = output2 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\HD To TC Hotkeys\";
                    // If directory exists, don't even try 

                    if (Directory.Exists(root2))
                    {
                        Directory.Delete(root2, true);
                    }
                    //Install AOC hki
                    string zipPath = @"mods\HD To TC Hotkeys AOC.zip";
                    string inString258 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                    string inString = inString258.Replace(" (x86)", "");
                    TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                    string output = cultInfo.ToTitleCase(inString);
                    string extractPath = output + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods";
                    string root23 = output2 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\HD To TC Hotkeys AOC\";
                    // If directory exists, don't even try 

                    if (Directory.Exists(root23))
                    {
                        Directory.Delete(root23, true);
                    }

                    if (!Directory.Exists(extractPath + @"\HD To TC Hotkeys AOC"))
                    {
                        string inStringki7 = Environment.GetEnvironmentVariable("ProgramFiles").Replace(" (x86)", "").ToLower();
                        string inStringki77 = inStringki7 + @"\microsoft games\age of empires ii\";

                        string[] hkiFiles = Directory.GetFiles(inStringki77, "*.hki").Select(Path.GetFileName).ToArray();
                        System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                        //Rename hotkey file based on the last generated *.hki file
                        System.IO.File.Move(extractPath + @"\HD To TC Hotkeys AOC\player1.hki", extractPath + @"\HD To TC Hotkeys AOC\" + hkiFiles.Last());
                    }
                    MessageBox.Show("AOC Hotkeys Successfully Installed!", "HD To TC Conversion Tool");
                }

            }
            else if (kryptonComboBox1.SelectedIndex == 2)
            {
                if (kryptonComboBox1.SelectedIndex.Equals(2))
                {

                    //Delete AOC hki
                    string inString399 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                    string inString2 = inString399.Replace(" (x86)", "");
                    TextInfo cultInfo2 = new CultureInfo("en-US", false).TextInfo;
                    string output2 = cultInfo2.ToTitleCase(inString2);
                    string root = output2 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\HD To TC Hotkeys AOC\";
                    //Delete HD hki
                    string inString390 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                    string inString3 = inString390.Replace(" (x86)", "");
                    TextInfo cultInfo3 = new CultureInfo("en-US", false).TextInfo;
                    string output3 = cultInfo3.ToTitleCase(inString3);
                    string root3 = output3 + @"\microsoft games\age of empires ii\Voobly Mods\AOC\Local Mods" + @"\HD To TC Hotkeys\";
                    // If directory exists, don't even try 

                    if (Directory.Exists(root))
                    {
                        Directory.Delete(root, true);

                    }
                    if (Directory.Exists(root3))
                    {
                        Directory.Delete(root3, true);

                    }
                    MessageBox.Show("Hotkeys Default Successful!", "HD To TC Conversion Tool");

                }

            }

            //
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

    }
}

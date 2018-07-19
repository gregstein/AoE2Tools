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
using Microsoft.Win32;
using System.Diagnostics;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace WindowsFormsApplication3
{
    public partial class RecentReplay : KryptonForm
    {
        public RecentReplay()
        {
            InitializeComponent();
            
            //this.TopMost = true;
        }
        private static Random random = new Random();
        private void RecentReplay_Load(object sender, EventArgs e)
        {
            aoepath();
            RecentR();
        }
        public async void RecentR()
        {
            await Task.Run(() => aoepath());
            try
            {
                this.TopMost = true;
                this.TopMost = false;
                var directory = new DirectoryInfo(mskdpath.Text + @"\SaveGame");
                var myFile = directory.GetFiles()
             .OrderByDescending(f => f.LastWriteTime)
             .First();

                //WK
                var directory2 = new DirectoryInfo(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame");
                var myFile2 = directory2.GetFiles()
             .OrderByDescending(f => f.LastWriteTime)
             .First();
                string _wkrec = mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + myFile2.ToString();

               // Games\WololoKingdoms
                if (!File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + myFile2.ToString()))
                {
                    File.Copy(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + myFile2.ToString(), mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + myFile2.ToString());
                }

                
                
                //MessageBox.Show(mskdpath.Text + @"\Games\WololoKingdoms AK\SaveGame\" + myFile2.ToString(), "");
                if (File.GetLastWriteTime(mskdpath.Text + @"\SaveGame\" + myFile.ToString()) > File.GetLastWriteTime(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + myFile2.ToString()))
                {
                    if (File.Exists(mskdpath.Text + @"\SaveGame\" + myFile.ToString()))
                        PlayerN(mskdpath.Text + @"\SaveGame\" + myFile.ToString());
                    gamever.Text = "1.5 RC";
                    recentrec.Text = myFile.ToString().Remove(myFile.ToString().Length - 4);
                    oldfn.Text = myFile.ToString().Remove(myFile.ToString().Length - 4);
                    getext.Text = myFile.ToString().Substring(Math.Max(0, myFile.ToString().Length - 4));
                }
                else
                {
                    if (File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + myFile2.ToString()))
                    PlayerN(mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + myFile2.ToString());
                    gamever.Text = "WK";
                    recentrec.Text = myFile2.ToString().Remove(myFile2.ToString().Length - 4);
                    oldfn.Text = myFile2.ToString().Remove(myFile2.ToString().Length - 4);
                    getext.Text = myFile2.ToString().Substring(Math.Max(0, myFile2.ToString().Length - 4));
                }

              
            }
            catch (Exception gh)
            {
                throw gh;
                //KryptonMessageBox.Show("No replays yet! Play one game and come back!");
                //this.Close();
            }
           
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

        private void closerec_Click(object sender, EventArgs e)
        {
            try { 
            //int FileSize = 0; //This belongs to the process you would like to terminate
            //Create the process csrss for every process with the name csrss
          
                //FileInfo csrssFile = new FileInfo(csrss.StartInfo.FileName); //Get the properties of its file name
                var processage = Process.GetCurrentProcess();
                Process[] processtool = Process.GetProcessesByName("AoE2Tools");

                // Or whatever method you are using
                string Pathage = processage.MainModule.FileName;
                string Pathtool = processage.MainModule.FileName;


                if (processtool[0].MainModule.FileName != processage.MainModule.FileName)
                {
                    processtool[0].Kill();
                    
                }
                }
            catch (SystemException)
            {

            }
           
            this.Close();
        }

        private void delrec_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = KryptonMessageBox.Show("Delete This Replay?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if(gamever.Text == "WK")
                    {
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text);
                        }
                        if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text);
                        }
                        //2nd wk folder
                        if (File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text);
                        }
                        if (File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + @"\Games\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text);
                        }
                        this.Close();
                    }
                    else if (gamever.Text != "WK")
                    {
                        if (File.Exists(mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text);
                        }
                        if (File.Exists(mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text))
                        {
                            File.Delete(mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text);
                        }
                        this.Close();
                    }

                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            catch (SystemException)
            {
                MessageBox.Show("Could not delete this replay! Close Age of empires 2 first!", "Error");
            }
 
        }

        private void saverec_Click(object sender, EventArgs e)
        {
            try
            {
 
                saverec.Enabled = false;
                if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text) && oldfn.Text != recentrec.Text)
                {
                    if (gamever.Text == "WK")
                    {
                        File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text, mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recentrec.Text + getext.Text);
                        File.Move(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + oldfn.Text + getext.Text, mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recentrec.Text + getext.Text);
                        oldfn.Text = recentrec.Text;
            
                        KryptonMessageBox.Show("Replay Renamed!", "Success");
                        saverec.Enabled = true;
                    }
                }
                else if (File.Exists(mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text) && oldfn.Text != recentrec.Text)
                {
                    //if(gamever.Text == "WK")
                    //{
                    //    File.Copy(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfn.Text + getext.Text, mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text);
                    //    oldfn.Text = recentrec.Text;
                    //    KryptonMessageBox.Show("Replay Renamed!", "Success");
                    //    saverec.Enabled = true;
                    //}
                    if(gamever.Text != "WK")
                    {
                        File.Move(mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text, mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text);
                        oldfn.Text = recentrec.Text;
                        KryptonMessageBox.Show("Replay Renamed!", "Success");
                        saverec.Enabled = true;
                    }
                    
                }
               
            }
            catch (SystemException)
            {
                MessageBox.Show("Could not save this replay! Close Age of empires 2 first or move the game to the recommended directory!", "Error");
            }
        }

        private void watchrec_Click(object sender, EventArgs e)
        {
            if(gamever.Text == "WK")
            {
                //WK "oldfn.Text == recentrec.Text"
                if (File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text))
                {
   
                    string notrenamedrec = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text;
                    if (!File.Exists(mskdpath.Text + "\\Games\\WololoKingdoms\\Savegame\\" + oldfn.Text + getext.Text))
                    {
                            File.Copy(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfn.Text + getext.Text, mskdpath.Text + "\\Games\\WololoKingdoms\\Savegame\\" + oldfn.Text + getext.Text);    
                    }
                    WatchRepm(notrenamedrec);
                }
                    // oldfn.Text != recentrec.Text && File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text)
                else if (File.Exists(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text))
                {
                    string renamedrec = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text;
                    if (!File.Exists(mskdpath.Text + "\\Games\\WololoKingdoms\\Savegame\\" + recentrec.Text + getext.Text))
                    {
                        File.Copy(mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recentrec.Text + getext.Text, mskdpath.Text + "\\Games\\WololoKingdoms\\Savegame\\" + recentrec.Text + getext.Text);
                    }
                    WatchRepm(renamedrec);
                }
            }

            else if (gamever.Text != "WK")
            {
                //Not WK
                if (oldfn.Text == recentrec.Text)
                {
                    string notrenamedrec = mskdpath.Text + "\\SaveGame\\" + oldfn.Text + getext.Text;

                    WatchRepm(notrenamedrec);
                }
                else if (oldfn.Text != recentrec.Text && File.Exists(mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text))
                {
                    string renamedrec = mskdpath.Text + "\\SaveGame\\" + recentrec.Text + getext.Text;
                    WatchRepm(renamedrec);
                }
            }
 

            
        }
        public void WatchRepm(string renfilerec)
        {

                //this rec full path
            //string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + getext.Text;
               // KryptonMessageBox.Show("start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"");

                //launch game ver
                if (gamever.Text == "1.5 RC")
                {
                    try
                    {
                        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.5.exe");
                        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                        //startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();

                    }
                    catch (Exception goy)
                    {
                        throw goy;

                    }
                }
                else if (gamever.Text == "1.4 RC")
                {
                    try
                    {
                        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.4.exe");
                        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                        //startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();

                    }
                    catch (Exception goy)
                    {
                        throw goy;

                    }
                }

                else if (gamever.Text == "1.0 C")
                {
                    try
                    {
                        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.0c.exe");
                        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                        //startInfo.Verb = "runas";
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();

                    }
                    catch (Exception goy)
                    {
                        throw goy;

                    }
                }

                //else if (gamever.Text == "1.0")
                //{
                //    try
                //    {
                //        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.0.exe");
                //        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                //        System.Diagnostics.Process process = new System.Diagnostics.Process();
                //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //        startInfo.FileName = "cmd.exe";
                //        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                //        //startInfo.Verb = "runas";
                //        process.StartInfo = startInfo;
                //        process.Start();
                //        process.WaitForExit();

                //    }
                //    catch (Exception goy)
                //    {
                //        throw goy;

                //    }
                //}
                else if (gamever.Text == "WK")
                {
                    if (File.Exists(mskdpath.Text + "\\Age2_x1\\WK.exe"))
                    {
                        try
                        {

                            byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WK.exe");
                            File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                       
                            //startInfo.Verb = "runas";
                            process.StartInfo = startInfo;
                            process.Start();
                            process.WaitForExit();

                        }
                            catch(System.IO.IOException)
                        {
                            KryptonMessageBox.Show("Close Age of Empires 2 First!");
                        }
                        catch (Exception goy)
                        {
                            throw goy;

                        }
                    }
                    //else if (File.Exists(mskdpath.Text + "\\Age2_x1\\WKAK.exe"))
                    //{
                    //    try
                    //    {
                    //        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WKAK.exe");
                    //        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    //        System.Diagnostics.Process process = new System.Diagnostics.Process();
                    //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    //        startInfo.FileName = "cmd.exe";
                    //        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                    //        //startInfo.Verb = "runas";
                    //        process.StartInfo = startInfo;
                    //        process.Start();
                    //        process.WaitForExit();

                    //    }
                    //    catch (Exception goy)
                    //    {
                    //        throw goy;

                    //    }
                    //}

                    //else if (File.Exists(mskdpath.Text + "\\Age2_x1\\WKRR.exe"))
                    //{
                    //    try
                    //    {
                    //        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WKRR.exe");
                    //        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    //        System.Diagnostics.Process process = new System.Diagnostics.Process();
                    //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    //        startInfo.FileName = "cmd.exe";
                    //        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                    //        //startInfo.Verb = "runas";
                    //        process.StartInfo = startInfo;
                    //        process.Start();
                    //        process.WaitForExit();

                    //    }
                    //    catch (Exception goy)
                    //    {
                    //        throw goy;

                    //    }
                    //}

                    //else if (File.Exists(mskdpath.Text + "\\Age2_x1\\WKFE.exe"))
                    //{
                    //    try
                    //    {
                    //        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WKFE.exe");
                    //        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                    //        System.Diagnostics.Process process = new System.Diagnostics.Process();
                    //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    //        startInfo.FileName = "cmd.exe";
                    //        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                    //        //startInfo.Verb = "runas";
                    //        process.StartInfo = startInfo;
                    //        process.Start();
                    //        process.WaitForExit();

                    //    }
                    //    catch (Exception goy)
                    //    {
                    //        throw goy;

                    //    }
                    //}
                    else if (!File.Exists(mskdpath.Text + "\\Age2_x1\\WKFE.exe") && !File.Exists(mskdpath.Text + "\\Age2_x1\\WKRR.exe") && !File.Exists(mskdpath.Text + "\\Age2_x1\\WKAK.exe") && !File.Exists(mskdpath.Text + "\\Age2_x1\\WK.exe"))
                    {
                        if (KryptonMessageBox.Show(
"WololoKingdom is Not Installed! \n Would you like to install WK now?", "WK is Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk
) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("https://github.com/AoE2CommunityGitHub/WololoKingdoms/releases");
                        }
                    }

                }
            //WKAK
                //else if (gamever.Text == "WKAK")
                //{
                //    try
                //    {
                //        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WKAK.exe");
                //        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                //        System.Diagnostics.Process process = new System.Diagnostics.Process();
                //        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //        startInfo.FileName = "cmd.exe";
                //        startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"";
                //        //startInfo.Verb = "runas";
                //        process.StartInfo = startInfo;
                //        process.Start();
                //        process.WaitForExit();

                //    }
                //    catch (Exception goy)
                //    {
                //        throw goy;

                //    }
                //}
                //end




        }
        static public List<int> SearchBytePattern(byte[] pattern, byte[] bytes)
        {
            List<int> positions = new List<int>();
            int patternLength = pattern.Length;
            int totalLength = bytes.Length;
            byte firstMatchByte = pattern[0];
            for (int i = 0; i < totalLength; i++)
            {
                if (firstMatchByte == bytes[i] && totalLength - i >= patternLength)
                {
                    byte[] match = new byte[patternLength];
                    Array.Copy(bytes, i, match, 0, patternLength);
                    if (match.SequenceEqual<byte>(pattern))
                    {
                        positions.Add(i);
                        i += patternLength - 1;
                    }
                }
            }
            return positions;
        }
        public static string rndstr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async void PlayerN(string RecName)
        {
            try
            {


                //extracting recorde header
                FileStream fs = new FileStream(RecName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] buffer;

                int headerLength = br.ReadInt32();
                int nextPosistion = br.ReadInt32();



                int compressLen = headerLength - 8;
                buffer = new Byte[compressLen];
                buffer = br.ReadBytes(compressLen);

                MemoryStream ms = new MemoryStream();
                ms.Write(buffer, 0, buffer.Length);
                byte[] HeaderByt = inflate1(ms);
                byte[] pattern = { 0x00, 0x16, 0xF0 };

                byte[] toBeSearched = HeaderByt;
                string afx = rndstr(8);
                File.WriteAllBytes(System.IO.Path.GetTempPath() + @"\rep-" + afx, toBeSearched);
                List<int> positions = SearchBytePattern(pattern, toBeSearched);
                int skipper = 0;

                foreach (var item in positions)
                {
                    skipper++;
                    if (skipper == 1) continue;

                    var playername = new MemoryStream(toBeSearched, item - 21, item);



                    using (BinaryReader b = new BinaryReader(File.Open(System.IO.Path.GetTempPath() + @"\rep-" + afx,
                                                          FileMode.Open)))
                    {

                        // Variables for our position.
                        int pos = item - 21;
                        int required = 21;


                        // Seek required position.
                        b.BaseStream.Seek(pos, SeekOrigin.Begin);
                        

                        // Read the next bytes.
                        byte[] by = b.ReadBytes(required);
                        string XplayerN = System.Text.Encoding.UTF8.GetString(by);
                    
                        StringBuilder sb = new StringBuilder();

                        foreach (char c in XplayerN)
                        {

                            if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == '[' || c == ']')
                            {
                                sb.Append(c);
                            }
                        }
                        //1v1
                        if (positions.Count() == 3)
                        {
                            if (skipper == 2)
                                Player1.Text = sb.ToString();
                            else if (skipper == 3)
                                Player2.Text = sb.ToString();
                        }
                            //2v2
                        else if (positions.Count() == 5)
                        {
                            if (skipper == 2)
                                Player1.Text = sb.ToString();
                            else if (skipper == 3)
                                Player2.Text = sb.ToString();
                            else if (skipper == 4)
                                Player3.Text = sb.ToString();
                            else if (skipper == 5)
                                Player4.Text = sb.ToString();
                            else if (skipper == 6)
                                Player6.Text = sb.ToString();
                            else if (skipper == 7)
                                Player8.Text = sb.ToString();
                            else if (skipper == 8)
                                Player5.Text = sb.ToString();
                            else if (skipper == 9)
                                Player7.Text = sb.ToString();
                        }
                        else if (positions.Count() > 5)
                        {
                        if (skipper == 2)
                            Player1.Text = sb.ToString();
                        else if (skipper == 3)
                            Player2.Text = sb.ToString();
                        else if (skipper == 4)
                            Player4.Text = sb.ToString();
                        else if (skipper == 5)
                            Player3.Text = sb.ToString();
                        else if (skipper == 6)
                            Player6.Text = sb.ToString();
                        else if (skipper == 7)
                            Player8.Text = sb.ToString();
                        else if (skipper == 8)
                            Player5.Text = sb.ToString();
                        else if (skipper == 9)
                            Player7.Text = sb.ToString();
                        }

                    }
                }
                //Check Empty players
                if (Player3.Text == "Loading...")
                    Player3.Text = "-";
                if (Player4.Text == "Loading...")
                    Player4.Text = "-";
                if (Player5.Text == "Loading...")
                    Player5.Text = "-";
                if (Player6.Text == "Loading...")
                    Player6.Text = "-";
                if (Player7.Text == "Loading...")
                    Player7.Text = "-";
                if (Player8.Text == "Loading...")
                    Player8.Text = "-";

                ms.Close();
                ms.Dispose();
                //if (File.Exists(System.IO.Path.GetTempPath() + @"\rep-" + afx))
                //    File.Delete(System.IO.Path.GetTempPath() + @"\rep-" + afx);
            }
            catch (SystemException)
            {

            }
        }
        private byte[] inflate1(MemoryStream ms)
        {
            try
            {

                ms.Seek(0, SeekOrigin.Begin);
                Inflater inflater = new Inflater(true);
                InflaterInputStream inStream = new InflaterInputStream(ms, inflater);
                byte[] buf = new byte[5000000];
                int buf_pos = 0;
                int count = buf.Length;

                while (true)
                {
                    int numRead = inStream.Read(buf, buf_pos, count);
                    if (numRead <= 0)
                    {
                        break;
                    }
                    buf_pos += numRead;
                    count -= numRead;
                }

                return buf;
            }
            catch (Exception ju)
            {
                throw ju;
            }
        }

        private void Player2_Click(object sender, EventArgs e)
        {

        }
    }
}

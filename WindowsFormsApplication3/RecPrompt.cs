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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.Zip.Compression;


namespace WindowsFormsApplication3
{
    public partial class RecPrompt : KryptonForm
    {
        public string MyProperty { get; set; }
        public string GameVersion { get; set; }
        public string Grabext { get; set; }
        public string RecCount { get; set; }
        public string SingleDir { get; set; }
        private static Random random = new Random();
        public RecPrompt()
        {
            InitializeComponent();
            //this.TopMost = true;
        }

        private void RecPrompt_Load(object sender, EventArgs e)
        {
            //async checks
             aoepath();
             rencombcheck();
            
        }

        private void watchrec_Click(object sender, EventArgs e)
        {
            //Process[] ageproc1 = Process.GetProcessesByName("AoE2Tools");
            if(gamever.Text == "WK")
            {
           
                    string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
                    foreach (string file in getfln)
                    {

                        if (recfield.Text == oldfilen.Text && !File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz"))
                        {
                            File.Copy(this.MyProperty + @"\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                            File.Copy(this.MyProperty + @"\" + Path.GetFileName(file), mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz");
                            WatchRepm();
                        }

                        else if (recfield.Text != oldfilen.Text && !File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + oldfilen.Text + ".mgz"))
                        {
                            if (!File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz"))
                            {
                                File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz");
                            }
                            if (!File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz"))
                            {
                                File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + oldfilen.Text + ".mgz");
                            }
                            if (File.Exists(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz"))
                            File.Move(mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\SaveGame\" + recfield.Text + ".mgz");
                            if (File.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + oldfilen.Text + ".mgz"))
                            File.Move(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz");
                            WatchRepm();
                        }

                }
                        
                
            }
            else if (gamever.Text != "WK")
            {
               
                    string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
                    foreach (string file in getfln)
                    {

                        if (recfield.Text == oldfilen.Text && !File.Exists(mskdpath.Text + @"\Savegame\" + recfield.Text + ".mgz"))
                        {

                            File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Savegame\" + recfield.Text + ".mgz");
                            WatchRepm();
                        }

                        else if (recfield.Text != oldfilen.Text)
                        {
                            if (!File.Exists(mskdpath.Text + @"\Savegame\" + recfield.Text + ".mgz"))
                            {
                                File.Delete(mskdpath.Text + @"\Savegame\" + oldfilen.Text + ".mgz");
                                File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Savegame\" + oldfilen.Text + ".mgz");
                                //WatchRepm();
                            }

                            if (!File.Exists(mskdpath.Text + @"\Savegame\" + oldfilen.Text + ".mgz"))
                            {
                                File.Copy(this.MyProperty + "\\" + Path.GetFileName(file), mskdpath.Text + @"\Savegame\" + oldfilen.Text + ".mgz");
                            }
                            if (File.Exists(mskdpath.Text + @"\Savegame\" + recfield.Text + ".mgz"))
                            {
                                WatchRepm();
                            }
                            else
                            {
                                File.Move(mskdpath.Text + @"\Savegame\" + oldfilen.Text + ".mgz", mskdpath.Text + @"\Savegame\" + recfield.Text + ".mgz");
                                WatchRepm();
                            }



                    }
                }
             
            }
            //int nProcessID = Process.GetCurrentProcess().Id;

            //if (ageproc1.Length == 0)
            //{
                //Proceed with rename and replay
                //using (RegistryKey renamekey = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                //{
                //    if (renamekey != null)
                //    {
                //        string renpmt = renamekey.GetValue("Ren").ToString();
                //        if (renpmt != recchoice.Text)
                //        {
                //            renamekey.SetValue("Ren", recchoice.Text);
                //        }

                //    }
                //}
            // Save or pend remove
                //if (recchoice.Text == "Save Replay")
                //{
                //    string oldfln = mskdpath.Text + "\\SaveGame\\" + oldfilen.Text + label1.Text;
                //    string currentfln = mskdpath.Text + "\\SaveGame\\" + recfield.Text + label1.Text;
                //    if (!File.Exists(currentfln))
                //    {

                //        System.IO.File.Move(oldfln, currentfln);
                //    }

                //    WatchRepm();

                //    //end launch
                //}
                //else if (recchoice.Text == "Don't Save!")
                //{
                //    string oldfln = mskdpath.Text + "\\SaveGame\\" + oldfilen.Text + label1.Text;
                //    if (File.Exists(oldfln))
                //    {
                //        File.AppendAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\recs\pending-removal.txt", oldfln + Environment.NewLine);
                //    }

                //    WatchRepm();
                //}


            //} //here
               
            //else
            //{
            //    DialogResult dialogResult = MessageBox.Show("Age of Empires 2 is already running!\n Would you like to close it to watch your replay?", "Already Running!", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        //do something

            //        foreach (var process in Process.GetProcessesByName("AoE2Tools"))
            //        {
            //            process.Kill();
            //            process.WaitForExit();
            //        }
            //        foreach (var process in Process.GetProcessesByName("age2_x1"))
            //        {
            //            process.Kill();
            //            process.WaitForExit();
            //        }
            //        //Ok, proceed now

            //        using (RegistryKey renamekey = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //        {
            //            if (renamekey != null)
            //            {
            //                string renpmt = renamekey.GetValue("Ren").ToString();
            //                if (renpmt != recchoice.Text)
            //                {
            //                    renamekey.SetValue("Ren", recchoice.Text);
            //                }

            //            }
            //        }
            //        if (recchoice.Text == "Save Replay")
            //        {
            //            string oldfln = mskdpath.Text + "\\SaveGame\\" + oldfilen.Text + label1.Text;
            //            string currentfln = mskdpath.Text + "\\SaveGame\\" + recfield.Text + label1.Text;
            //            if (File.Exists(currentfln))
            //            {
            //                System.IO.File.Move(oldfln, currentfln);
            //            }

            //            WatchRepm();

            //            //end launch
            //        }
            //        else if (recchoice.Text == "Don't Save!")
            //        {
            //            string oldfln = mskdpath.Text + "\\SaveGame\\" + oldfilen.Text + label1.Text;
            //            if (File.Exists(oldfln))
            //            {
            //                File.AppendAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\recs\pending-removal.txt", oldfln + Environment.NewLine);
            //            }

            //            WatchRepm();
            //        }

            //        //end processing

            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
                    

            //    }
            //}//here
                

            
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
        public async void rencombcheck()
        {
            await Task.Run(() => aoepath());
            using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Skey != null)
                {
                    
                    string renref = Skey.GetValue("Ren").ToString();
                    if (renref != null)
                    {
                        recchoice.Text = renref;
                    }
                    
                }
            }
            label1.Text = this.Grabext;
            gamever.Text = this.GameVersion;
            //trimit
            string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
            foreach (string file in getfln)
            {
                PlayerN(file);
                //recfield.Text = Path.GetFileName(file).Remove(Path.GetFileName(file).Length - 4);
                oldfilen.Text = Path.GetFileName(file).Remove(Path.GetFileName(file).Length - 4);
                label1.Text = Path.GetFileName(file).Substring(Math.Max(0, Path.GetFileName(file).Length - 4));
            }
            //recfield.SelectionStart = 0;
            //recfield.SelectionLength = recfield.Text.Length;
            this.TopMost = true;
            this.TopMost = false;
            recfield.SelectAll();
            
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Process[] ageproc1 = Process.GetProcessesByName("AoE2Tools");

            //if (ageproc1.Length == 0)
            //{
                //just delete


                DialogResult dialogResult = KryptonMessageBox.Show("Delete This Replay?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + this.Grabext;
                    string renfilerec_old = mskdpath.Text + "\\SaveGame\\" + oldfilen.Text + this.Grabext;
                    string renfilerecwk = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + recfield.Text + this.Grabext;
                    string renfilerecwk_old = mskdpath.Text + "\\Voobly Mods\\AOC\\Data Mods\\WololoKingdoms\\SaveGame\\" + oldfilen.Text + this.Grabext;
                    string renfilerecwk2 = mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + this.Grabext;
                    string renfilerecwk_old2 = mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + oldfilen.Text + this.Grabext;
                    //if (File.Exists(renfilerec))
                    //{
                        try
                        {
                            if (File.Exists(renfilerec))
                            File.Delete(renfilerec);
                            if (File.Exists(renfilerec_old))
                            File.Delete(renfilerec_old);
                            if (File.Exists(renfilerecwk))
                            File.Delete(renfilerecwk);
                            if (File.Exists(renfilerecwk_old))
                            File.Delete(renfilerecwk_old);
                            if (File.Exists(renfilerecwk2))
                            File.Delete(renfilerecwk2);
                            if (File.Exists(renfilerecwk_old2))
                            File.Delete(renfilerecwk_old2);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future, Move Age of empires 2 to the recommended location", "Alert!");
                        }

                    //}
                    if (File.Exists(renfilerec_old))
                    {
                        try
                        {
                            File.Delete(renfilerec);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future.Move Age of empires 2 to the recommended location!", "Alert!");
                        }

                    }
                    //wk start del
                    if (File.Exists(renfilerecwk))
                    {
                        try
                        {
                            File.Delete(renfilerec);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future, Move Age of empires 2 to the recommended location", "Alert!");
                        }

                    }
                    if (File.Exists(renfilerecwk_old))
                    {
                        try
                        {
                            File.Delete(renfilerec);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future.Move Age of empires 2 to the recommended location!", "Alert!");
                        }

                    }
                    //wk end del
                    if (Directory.Exists(this.MyProperty))
                    {
                        try
                        {
                            Directory.Delete(this.MyProperty, true);
                            this.Close();
                        }
                        catch (SystemException)
                        {
                            //KryptonMessageBox.Show("To Be Able to Delete Replays In The Future.Move Age of empires 2 to the recommended location!", "Alert!");
                        }
                    }

                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {

                }


                //delete
            //}//here
            //else
            //{
            //    MessageBox.Show("running");
            //                DialogResult dialogResult2 = KryptonMessageBox.Show("Age of empires 2 is already running!!\n\nWould you like to close it and delete this replay?", "Confirmation", MessageBoxButtons.YesNo);
            //                if (dialogResult2 == DialogResult.Yes)
            //                { 
            //                    //kill proc first
            //                    foreach (var process in Process.GetProcessesByName("AoE2Tools"))
            //                    {
            //                        process.Kill();
            //                        process.WaitForExit();
            //                    }

            //                // now delete
            //                    DialogResult dialogResult = KryptonMessageBox.Show("Delete This Replay?", "Confirmation", MessageBoxButtons.YesNo);
            //                    if (dialogResult == DialogResult.Yes)
            //                    {
            //                        string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + this.Grabext;
            //                        string renfilerec_old = mskdpath.Text + "\\SaveGame\\" + oldfilen.Text + this.Grabext;
            //                        if (File.Exists(renfilerec))
            //                        {
            //                            try
            //                            {
            //                                File.Delete(renfilerec);
            //                                this.Close();
            //                            }
            //                            catch (SystemException)
            //                            {
            //                                KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future. \n Or Move Age of empires 2 to the recommended location", "Alert!");
            //                            }

            //                        }
            //                        if (File.Exists(renfilerec_old))
            //                        {
            //                            try
            //                            {
            //                                File.Delete(renfilerec);
            //                                this.Close();
            //                            }
            //                            catch (SystemException)
            //                            {
            //                                KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future.", "Alert!");
            //                            }

            //                        }
            //                        if (Directory.Exists(this.MyProperty))
            //                        {
            //                            try
            //                            {
            //                                Directory.Delete(this.MyProperty, true);
            //                                this.Close();
            //                            }
            //                            catch (SystemException)
            //                            {
            //                                KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future.", "Alert!");
            //                            }
            //                        }

            //                        this.Close();
            //                    }
            //                    else if (dialogResult == DialogResult.No)
            //                    {

            //                    }

            //                    //end delete
            //                }
            //                else
            //                {

            //                }

            //}
            


         
        }

        private void recfield_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allowed keypresses within the replay field
            if (Char.IsLetterOrDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if (Char.IsWhiteSpace(e.KeyChar)) return;
            if (e.KeyChar == '-') return;
            if (e.KeyChar == '_') return;
            if (e.KeyChar == '.') return;
            if (e.KeyChar == '+') return;
            if (e.KeyChar == ')') return;
            if (e.KeyChar == '(') return;
            if (e.KeyChar == '#') return;
            if (e.KeyChar == ']') return;
            if (e.KeyChar == '[') return;
            if (e.KeyChar == '@') return;
            if (e.KeyChar == '&') return;
            if (e.KeyChar == 'é') return;
            if (e.KeyChar == 'è') return;
            if (e.KeyChar == 'ç') return;
            if (e.KeyChar == 'à') return;
            if (e.KeyChar == 'á') return;
            if (e.KeyChar == 'í') return;
            if (e.KeyChar == 'ó') return;
            if (e.KeyChar == 'ú') return;
            if (e.KeyChar == 'ü') return;
            if (e.KeyChar == 'ñ') return;
            e.Handled = true;
            
            
        }

        private void recfield_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void RecPrompt_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(recchoice.Text == "Don't Save!")
            {
                string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + this.Grabext;
                if (File.Exists(renfilerec))
                {
                    try
                    {
                        File.Delete(renfilerec);
                        this.Close();
                    }
                    catch (SystemException)
                    {
                        KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future.", "Alert!");
                    }

                }
                if (Directory.Exists(this.MyProperty))
                {
                    try
                    {
                        Directory.Delete(this.MyProperty, true);
                        this.Close();
                    }
                    catch (SystemException)
                    {
                        KryptonMessageBox.Show("Try To Run AoE2Tools As Administrator To Be Able to Delete Replays In The Future.", "Alert!");
                    }
                }
            }
        }
        //public void detectver()
        //{
           
  
            


        //}
        public void WatchRepm()
        {
            //string getrecex = this.MyProperty.Substring(Math.Max(0, this.MyProperty.Length - 4));
            string[] getfln = Directory.GetFiles(this.MyProperty, "*", SearchOption.AllDirectories);
            foreach (string file in getfln)
            {
                //this rec full path
                string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + label1.Text;
                string renfilerecwk = mskdpath.Text + "\\Games\\WololoKingdoms\\SaveGame\\" + recfield.Text + label1.Text;
                //KryptonMessageBox.Show("start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"");
                if (!File.Exists(renfilerec))
                {
                    File.Copy(file, renfilerec);
                }


                //launch game ver
                if (gamever.Text == "1.5 RC")
                {
                    try
                    {
                        //MessageBox.Show("running 1.5", "");
                        byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.5.exe");
                        File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c" + "start " + "\"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\" " + "\"" + renfilerec + "\"";
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
                    //copy first
                    if (!File.Exists(renfilerecwk))
                    {
                        File.Copy(file, renfilerecwk);
                    }
                    //end copy
                    if (File.Exists(mskdpath.Text + "\\Age2_x1\\WK.exe"))
                    {
                        try
                        {
                            //MessageBox.Show("running wk", "");
                            byte[] passjuice = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\WK.exe");
                            File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", passjuice);
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/c" + "start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerecwk + "\"";
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
                //end
            }
                

             
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


                //extracting replay header
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
                        //1v1 or 2v2
                        if (positions.Count() == 3)
                        {
                            if (skipper == 2)
                            {
                                Player1.Text = sb.ToString();
                                recfield.Text = Player1.Text + " Vs ";
                            }
                            else if (skipper == 3)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += Player2.Text;
                                //check file existence
                                FileInfo woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                                FileIndexChk(woop);
                                if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\"))
                                {
                                FileInfo woop2 = new FileInfo(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz");
                                FileIndexChk(woop2);
                                }
                                    
                            }

                        }
                        else if (positions.Count() == 5)
                        {
                            if (skipper == 2)
                            {
                                Player1.Text = sb.ToString();
                                recfield.Text = Player1.Text + " - ";
                            }
                            else if (skipper == 3)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += Player2.Text + " - ";
                            }
                                
                            else if (skipper == 4)
                            {
                                Player3.Text = sb.ToString();
                                recfield.Text += Player3.Text + " VS ";
                            }
                                
                            else if (skipper == 5)
                            {
                                Player4.Text = sb.ToString();
                                recfield.Text += Player4.Text;
                                //check file existence
                                FileInfo woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                                FileIndexChk(woop);
                                if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\"))
                                {
                                    FileInfo woop2 = new FileInfo(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz");
                                    FileIndexChk(woop2);
                                }
                            }
                                
                            //else if (skipper == 6)
                            //    Player6.Text = sb.ToString();
                            //else if (skipper == 7)
                            //    Player8.Text = sb.ToString();
                            //else if (skipper == 8)
                            //    Player5.Text = sb.ToString();
                            //else if (skipper == 9)
                            //    Player7.Text = sb.ToString();
                        }
                        else if (positions.Count() > 5)
                        {
                            if (skipper == 2)
                            {
                                Player1.Text = sb.ToString();
                                recfield.Text = Player1.Text + " - ";
                            }
                                
                            else if (skipper == 3)
                            {
                                Player2.Text = sb.ToString();
                                recfield.Text += Player2.Text + " - ";
                            }
                                
                            else if (skipper == 4)
                            {
                                Player4.Text = sb.ToString();
                                recfield.Text += Player4.Text + " Vs ";
                            }
                                
                            else if (skipper == 5)
                            {
                               Player3.Text = sb.ToString();
                               recfield.Text += Player3.Text + " - ";
                            }
                                
                            else if (skipper == 6)
                            {
                                   Player6.Text = sb.ToString();
                                   recfield.Text += Player6.Text + " - ";
                            }
                                
                                
                            else if (skipper == 8)
                            {
                                    Player5.Text = sb.ToString();
                                    recfield.Text += Player5.Text + " - ";
                            }
                                
                            else if (skipper == 9)
                            {
                                   Player7.Text = sb.ToString();
                                   recfield.Text += Player7.Text + " - ";
                            }
                            else if (skipper == 7)
                            {
                                Player8.Text = sb.ToString();
                                recfield.Text += Player8.Text;
                                //check file existence
                                FileInfo _woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                                FileIndexChk(_woop);
                                if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\"))
                                {
                                    FileInfo _woop2 = new FileInfo(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz");
                                    FileIndexChk(_woop2);
                                }
                            }
                            ////check file existence
                            //FileInfo woop = new FileInfo(mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz");
                            //FileIndexChk(woop);
                            //if (Directory.Exists(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\"))
                            //{
                            //    FileInfo woop2 = new FileInfo(mskdpath.Text + @"\Games\WololoKingdoms\Savegame\" + recfield.Text + ".mgz");
                            //    FileIndexChk(woop2);
                            //}
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
                if (File.Exists(System.IO.Path.GetTempPath() + @"\rep-" + afx))
                    File.Delete(System.IO.Path.GetTempPath() + @"\rep-" + afx);
            }
            catch (SystemException)
            {

            }
        }
        public void FileIndexChk(FileInfo file)
        {
            var filename = file.Name.Replace(file.Extension, string.Empty);
            var dir = file.Directory.FullName;
            var ext = file.Extension;

            if (file.Exists)
            {
                int count = 0;
                string added;

                do
                {
                    count++;
                    added = "Game (" + count + ")";
                } while (File.Exists(dir + "\\" + filename + " " + added + ext));

                recfield.Text = filename += " " + added;
                //recfield.Text = filename + ext;
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
        private void recchoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(recchoice.SelectedItem == "Don't Save")
            {
                recfield.Enabled = false;
            }
            else if (recchoice.SelectedItem == "Save Replay")
            {
                recfield.Enabled = true;
            }
        }

        private void RecPrompt_Leave(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

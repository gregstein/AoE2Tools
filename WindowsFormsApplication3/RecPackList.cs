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

namespace WindowsFormsApplication3
{

    public partial class RecPackList : KryptonForm
    {
        public RecPackList()
        {
            InitializeComponent();
            //this.TopMost = true;
            
        }
        public string MyProperty { get; set; }
        public string GameVersion { get; set; }
        public string SingleDir { get; set; }
        public int RecCount { get; set; }

        private Random _rand = new Random();
        
        private void RecPackList_Load(object sender, EventArgs e)
        {
           
        }

        private void RecPackList_Shown(object sender, EventArgs e)
        {

            //get path
            aoepath();
            //copy recpack
            recsize.Text = FormatByteSize(GetDirectorySize(this.MyProperty));
            repcount.Text = this.RecCount.ToString();
            oldfolder.Text = this.SingleDir;
            refdir.Text = this.MyProperty;
            packfn.Text = this.SingleDir;
            packfn.SelectAll();
            packfn.Focus();

            //copying recs to SaveGame first

            //if (this.GameVersion != "WK")
            //{
            //    DirCopy(this.MyProperty, mskdpath.Text + "\\SaveGame\\" + this.SingleDir);
            //}
           
            //else
            //{
            //    DirCopy(this.MyProperty, mskdpath.Text + "\\Games\\WololoKingdoms\\SaveGame\\" + this.SingleDir);
            //}
                
            //list
            var _recext = new List<string> { "mgz", "mgx", "gax" };

            ListLoad();

            //DirectoryInfo info = new DirectoryInfo(this.MyProperty);
            //FileInfo[] files = info.GetFiles("*").OrderByDescending(p => p.CreationTime).ToArray();
            //int idc = 0;
            //foreach (FileInfo file in files)
            //{
            //    idc++;
            //    string _itemrec = file.ToString();
            //    //if (!_itemrec.Contains(".mgz") || !_itemrec.Contains(".mgx"))
            //    //{
            //    //    continue;
            //    //}
            //    //else if (_itemrec.Contains(".mgx"))
            //    //{

            //    //}
            //    reclistpack.Items.Add(CreateNewItem(file.ToString()));
            //}

            //select first
            //reclistpack.SelectedIndex = 0;



            //string[] files = Directory.GetFiles(@"C:\Users\Greg\AppData\Local\Temp\hdtotc-tmp\recs", "*.mgz");
            
            //for (int i = 0; i < files.Length; i++)
            //    files[i] = Path.GetFileName(files[i]);
            //reclistpack.Items.Add(CreateNewItem(files[i]));
        }
        //private string[] pdfFiles = GetFileNames("C:\\Documents", "*.pdf");





        //gen
        private object CreateNewItem(string fln)
        {
            KryptonListItem item = new KryptonListItem();
            //item.ShortText = "Item " + (_next++).ToString();
            item.ShortText = fln;
            //if (item.ShortText.ToString().Contains(".mgz"))
            //{
            //    item.LongText = "(" + "mgz" + ")";
            //}
            //else if (item.ShortText.ToString().Contains(".mgx"))
            //{
            //    item.LongText = "(" + "mgx" + ")";
            //}
            //item.LongText = "(" + _rand.Next(Int32.MaxValue).ToString() + ")";
            item.Image = imageList.Images[0];
            return item;
        }

        private void reclistpack_SelectedValueChanged(object sender, EventArgs e)
        {
            if (reclistpack.SelectedIndex >= 0)
            {
            recfield.Text = reclistpack.GetItemText(reclistpack.SelectedItem);
            oldfilen.Text = reclistpack.GetItemText(reclistpack.SelectedItem);
            recfield.SelectAll();
            recfield.Focus();
            //
            string[] getfln = Directory.GetFiles(refdir.Text, "*", SearchOption.AllDirectories);
            foreach (string file in getfln)
            {
                
                label1.Text = ".mgz";
            }
            }


            //foreach (var item in reclistpack.SelectedItems)
            //{
                
               
            //}
        }

        private void reclistpack_DoubleClick(object sender, EventArgs e)
        {
         
        }

        private void reclistpack_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            //if (reclistpack.SelectedItem.ToString() != null)
            //{
            //    KryptonMessageBox.Show(reclistpack.SelectedIndex.ToString());
            //}
        }

        private void reclistpack_Click(object sender, EventArgs e)
        {
         
        }


        private void kryptonButton4_Click(object sender, EventArgs e) //watch
        {
            if (reclistpack.SelectedIndex >= 0)
            {
                try
                {
                    renametxt.Text = reclistpack.GetItemText(reclistpack.SelectedItem);
                    foreach (var item in reclistpack.SelectedItems)
                    {
                        KryptonMessageBox.Show("/c" + " \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + this.MyProperty + reclistpack.GetItemText(reclistpack.SelectedItem) + "\"");
                    }
                    string trimver = this.GameVersion;
                    if (File.Exists(mskdpath.Text + "\\Age2_x1\\age2_x" + trimver + ".exe"))
                    {   
                        if(this.GameVersion == "1.5 RC")
                        {
                            //print bytes
                            byte[] pntver = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.5" + ".exe");
                            File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", pntver);
                            //Launch
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/c" + " \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + this.MyProperty + reclistpack.GetItemText(reclistpack.SelectedItem) + "\"";

                            process.StartInfo = startInfo;
                            process.Start();
                            process.WaitForExit();
                        }
                        else if(this.GameVersion == "1.4 RC")
                        {
                            //print bytes
                            byte[] pntver = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.4" + ".exe");
                            File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", pntver);
                            //Launch
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/c" + " \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + this.MyProperty + reclistpack.GetItemText(reclistpack.SelectedItem) + "\"";

                            process.StartInfo = startInfo;
                            process.Start();
                            process.WaitForExit();
                        }
                        else if (this.GameVersion == "1.0 C")
                        {
                            //print bytes
                            byte[] pntver = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.0c" + trimver + ".exe");
                            File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", pntver);
                            //Launch
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/c" + " \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + this.MyProperty + reclistpack.GetItemText(reclistpack.SelectedItem) + "\"";

                            process.StartInfo = startInfo;
                            process.Start();
                            process.WaitForExit();
                        }
                        else if (this.GameVersion == "1.0")
                        {
                            //print bytes
                            byte[] pntver = File.ReadAllBytes(mskdpath.Text + "\\Age2_x1\\age2_x1.0" + ".exe");
                            File.WriteAllBytes(mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe", pntver);
                            //Launch
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.FileName = "cmd.exe";
                            startInfo.Arguments = "/c" + " \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + this.MyProperty + reclistpack.GetItemText(reclistpack.SelectedItem) + "\"";

                            process.StartInfo = startInfo;
                            process.Start();
                            process.WaitForExit();
                        }
                        
                    }
                    else { }


                    //KryptonMessageBox.Show("Boost Enabled!", "AoE2 Tools");
                }
                catch (SystemException)
                {
                    
                    //KryptonMessageBox.Show("Cancelled.. Boost", "AoE2 Tools");
                }

                KryptonMessageBox.Show(reclistpack.SelectedItem.ToString());
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

        public void detectver()
        {
            string trimver = GameVersion.Substring(0, 3);
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/c" + mskdpath.Text + "\\Age2_x1\\age2_x" + trimver + ".exe\" -opt";
                //startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
                KryptonMessageBox.Show("Boost Enabled!", "AoE2 Tools");
            }
            catch (SystemException)
            {

                KryptonMessageBox.Show("Cancelled.. Boost", "AoE2 Tools");
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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (reclistpack.SelectedIndex >= 0)
            {
                refdir.Text = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + packfn.Text;
                string currentpath = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + packfn.Text;
                string oldpath = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" +  oldfolder.Text;
                if (currentpath != oldpath)
                {
                    System.IO.Directory.Move(oldpath, currentpath);
                }
                //remember old name
                oldfolder.Text = packfn.Text;
            }
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void watchrec_Click(object sender, EventArgs e)
        {

                        //Process[] ageproc1 = Process.GetProcessesByName("AoE2Tools");

                        //if (ageproc1.Length == 0)
                        //{
                            //just watch


            if (NativeDir() != "") { DirCopy(NativeDir(), mskdpath.Text + "\\SaveGame\\"); } else { KryptonMessageBox.Show("Replay Pack Folder-Name is empty!", "Error!"); }
                            if (reclistpack.SelectedIndex >= 0)
                            {
                                if(gamever.Text == "WK")
                                {
                                    DirCopy(NativeDir(), mskdpath.Text + @"\Games\WololoKingdoms\Savegame\");
                                }
                                //Save Replay
                                //if (recchoice.Text == "Save Replay")
                                ////{
                                //    if (folderradio.Checked == false)
                                //    {

                                    WatchReplay("");


                                    //}
                                    ////radio checked
                                    //else if (folderradio.Checked == true)
                                    //{
                                    //    //radio check begin

                                    //    WatchReplay(packfn.Text);

                                    //    //radio check end

                                    //}
                                    //end launch
                                //}
                                //Don't Save
                                //else if (recchoice.Text == "Don't Save")
                                //{
                                //    if (folderradio.Checked == false)
                                //    {
                                //        foreach (var recitem in reclistpack.Items)
                                //        {
                                //            string oldfln = mskdpath.Text + "\\SaveGame\\" + recitem;

                                //            if (Directory.Exists(oldfln))
                                //            {
                                //                File.AppendAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\recs\pending-removal.txt", oldfln + Environment.NewLine);
                                //            }
                                //        }


                                //        WatchReplay("");


                                //    }
                                //    //radio checked
                                //    else if (folderradio.Checked == true)
                                //    {
                                //        //radio check begin
                                //        string oldfln = mskdpath.Text + "\\SaveGame\\" + oldfolder.Text;
                                //        if (Directory.Exists(oldfln))
                                //        {
                                //            File.AppendAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\recs\pending-removal.txt", oldfln + Environment.NewLine);
                                //        }
                                //        WatchReplay(packfn.Text);

                                //        //radio check end

                                //    }
                                //}

                            }


                            //end watch
                        //}//here
                        //else
                        //{
                        //                    DialogResult dialogResult = MessageBox.Show("Age of Empires 2 is already running!\n Would you like to close it to watch your replay?", "Already Running!", MessageBoxButtons.YesNo);
                        //                    if (dialogResult == DialogResult.Yes)
                        //                    {
                        //                        foreach (var process in Process.GetProcessesByName("AoE2Tools"))
                        //                        {
                        //                            process.Kill();
                        //                            process.WaitForExit();
                        //                        }
                        //                        //now watch

                        //                        if (NativeDir() != "") { DirCopy(NativeDir(), mskdpath.Text + "\\SaveGame\\"); } else { KryptonMessageBox.Show("Replay Pack Folder-Name is empty!", "Error!"); }
                        //                        if (reclistpack.SelectedIndex >= 0)
                        //                        {
                        //                            //Save Replay
                        //                            if (recchoice.Text == "Save Replay")
                        //                            {
                        //                                if (folderradio.Checked == false)
                        //                                {

                        //                                    WatchReplay("");


                        //                                }
                        //                                //radio checked
                        //                                else if (folderradio.Checked == true)
                        //                                {
                        //                                    //radio check begin

                        //                                    WatchReplay(packfn.Text);

                        //                                    //radio check end

                        //                                }
                        //                                //end launch
                        //                            }
                        //                            //Don't Save
                        //                            else if (recchoice.Text == "Don't Save")
                        //                            {
                        //                                if (folderradio.Checked == false)
                        //                                {
                        //                                    foreach (var recitem in reclistpack.Items)
                        //                                    {
                        //                                        string oldfln = mskdpath.Text + "\\SaveGame\\" + recitem;

                        //                                        if (Directory.Exists(oldfln))
                        //                                        {
                        //                                            File.AppendAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\recs\pending-removal.txt", oldfln + Environment.NewLine);
                        //                                        }
                        //                                    }


                        //                                    WatchReplay("");


                        //                                }
                        //                                //radio checked
                        //                                else if (folderradio.Checked == true)
                        //                                {
                        //                                    //radio check begin
                        //                                    string oldfln = mskdpath.Text + "\\SaveGame\\" + oldfolder.Text;
                        //                                    if (Directory.Exists(oldfln))
                        //                                    {
                        //                                        File.AppendAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\recs\pending-removal.txt", oldfln + Environment.NewLine);
                        //                                    }
                        //                                    WatchReplay(packfn.Text);

                        //                                    //radio check end

                        //                                }
                        //                            }
                        //                        }


                        //                        //end watch

                        //                    }
                        //                    else if (dialogResult == DialogResult.No)
                        //                    {

                        //                    }
                        //}//here

            
            //Running

        }

        private void renametxt_Click(object sender, EventArgs e)
        {

            if (reclistpack.SelectedIndex >= 0)
            {

                string currentpath = refdir.Text.Replace(@"\\", @"\") + "\\" + recfield.Text + ".mgz";
                //string oldpath = this.MyProperty + "\\" + reclistpack.SelectedItem; 
                string oldpath = refdir.Text.Replace(@"\\",@"\") + @"\" + reclistpack.SelectedItem;
                if (currentpath != oldpath)
                {
                    int _idx = reclistpack.SelectedIndex;
                    System.IO.File.Move(oldpath, currentpath);
                    reclistpack.Items.Clear();
                    
                    //reclistpack.Items[reclistpack.SelectedIndex] = recfield.Text + label1.Text;
                    ListLoad();
                    reclistpack.SelectedIndex = _idx;

                }
                //remember old name
                oldfilen.Text = recfield.Text;
            }

            
            // Can only save if something is selected
            //if (reclistpack.SelectedIndex >= 0)
            //{
            //    // Find the new index to select
            //    int index = reclistpack.SelectedIndex;
            //    if (index == (reclistpack.Items.Count - 1))
            //        index--;
            //    // Get entry value
            //    string entryv = reclistpack.GetItemText(reclistpack.SelectedItem);
            //    // rename entry
            //    if (entryv.Contains(".mgz"))
            //    {
            //        System.IO.File.Move(this.MyProperty + "\\" + entryv, this.MyProperty + "\\" + recfield.Text + ".mgz");
            //        reclistpack.Items[reclistpack.SelectedIndex] = Path.GetFileName(this.MyProperty + "\\" + recfield.Text + ".mgz");
            //    }
            //    else if (entryv.Contains(".mgx"))
            //    {
            //        System.IO.File.Move(this.MyProperty + "\\" + entryv, this.MyProperty + "\\" + recfield.Text + ".mgx");
            //        reclistpack.Items[reclistpack.SelectedIndex] = this.MyProperty + "\\" + recfield.Text + ".mgx";
            //    }
               
                

            //}

            //renametxt.Text = reclistpack.GetItemText(reclistpack.SelectedItem);
            //foreach (var item in reclistpack.SelectedItems)
            //{

            //}
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = KryptonMessageBox.Show("Delete This Replay?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Can only remove if something is selected
                if (reclistpack.SelectedIndex >= 0)
                {
                    // Find the new index to select
                    int index = reclistpack.SelectedIndex;
                    if (index == (reclistpack.Items.Count - 1))
                        index--;
                    // Get entry value
                    string entryv = reclistpack.GetItemText(reclistpack.SelectedItem);
                    // Remove entry
                    reclistpack.Items.RemoveAt(reclistpack.SelectedIndex);
                    File.Delete(mskdpath.Text + "\\SaveGame\\" + entryv);
                    File.Delete(this.MyProperty + "\\" + entryv);
                    // Select the new item
                    if (index < reclistpack.Items.Count)
                        reclistpack.SelectedIndex = index;
                    //revalidate size and reps
                    recsize.Text = FormatByteSize(GetDirectorySize(this.MyProperty));
                    repcount.Text = (this.RecCount - 1).ToString();



                }
                if (reclistpack.Items.Count == 0)
                {
                    repcount.Text = "0";
                }
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            
        }

        private void delall_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = KryptonMessageBox.Show("Delete All And Exit?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Directory.Exists(this.MyProperty))
                {
                    Directory.Delete(this.MyProperty, true);
                }
                else if (Directory.Exists(mskdpath.Text + "\\SaveGame\\" + oldfolder.Text))
                {
                    Directory.Delete(mskdpath.Text + "\\SaveGame\\" + oldfolder.Text, true);
                }
                else if (Directory.Exists(mskdpath.Text + "\\SaveGame\\" + packfn.Text))
                {
                    Directory.Delete(mskdpath.Text + "\\SaveGame\\" + packfn.Text, true);
                }
                this.Close();
                
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void help2_Click(object sender, EventArgs e)
        {
            ToolTip buttonToolTip2 = new ToolTip();
            buttonToolTip2.ToolTipTitle = "Rename Selected Replay";
            buttonToolTip2.UseFading = true;
            buttonToolTip2.UseAnimation = true;
            buttonToolTip2.IsBalloon = true;
            buttonToolTip2.ShowAlways = true;
            buttonToolTip2.AutoPopDelay = 5000;
            buttonToolTip2.InitialDelay = 1000;
            buttonToolTip2.ReshowDelay = 500;
            buttonToolTip2.SetToolTip(help2, "Rename replays individually");
        }

        private void help1_Click(object sender, EventArgs e)
        {
            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.ToolTipTitle = "Rename Replay Pack Folder";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 50;
            buttonToolTip.ReshowDelay = 500;
            buttonToolTip.SetToolTip(help1, "All these replays will be saved in a custom folder \n Inside \"SaveGame\" Folder \n If disabled, replays will be saved directly to \"SaveGame\" Folder");
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            //delall.Enabled = false;
        }

        private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (folderradio.Checked == false)
            {
                packfn.Enabled = false;
                //saveall.Enabled = false;
            }
            else if (folderradio.Checked == true)
            {
                packfn.Enabled = true;
                //saveall.Enabled = true;
            }
        }

        private static string FormatByteSize(double bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "TB" };
            int index = 0;
            do { bytes /= 1024; index++; }
            while (bytes >= 1024);
            return String.Format("{0:0.00} {1}", bytes, Suffix[index]);

        }

        static long GetDirectorySize(string p)
        {
            string[] a = Directory.GetFiles(p, "*.*");
            long b = 0;
            foreach (string name in a)
            {
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            return b;
        }

        private void kryptonButton6_Click_1(object sender, EventArgs e)
        {
                        Process[] ageproc1 = Process.GetProcessesByName("AoE2Tools");

                        if (ageproc1.Length == 0)
                        {
                            //just save

                            // Can only save if something is selected
                            if (reclistpack.SelectedIndex >= 0)
                            {
                                // Find the new index to select
                                int index = reclistpack.SelectedIndex;
                                if (index == (reclistpack.Items.Count - 1))
                                    index--;
                                // Get entry value
                                string entryv = reclistpack.GetItemText(reclistpack.SelectedItem);
                                // save entry

                                File.Copy(this.MyProperty + "\\" + entryv, mskdpath.Text + "\\SaveGame\\" + entryv);
                                // Select the new item
                                //if (index < reclistpack.Items.Count)
                                //    reclistpack.SelectedIndex = index;
                            }
                            //endsave
                        }
                        else
                        {
//close proc
                            foreach (var process in Process.GetProcessesByName("AoE2Tools"))
                            {
                                process.Kill();
                                process.WaitForExit();
                            }

                            //now save

                            // Can only save if something is selected
                            if (reclistpack.SelectedIndex >= 0)
                            {
                                // Find the new index to select
                                int index = reclistpack.SelectedIndex;
                                if (index == (reclistpack.Items.Count - 1))
                                    index--;
                                // Get entry value
                                string entryv = reclistpack.GetItemText(reclistpack.SelectedItem);
                                // save entry

                                File.Copy(this.MyProperty + "\\" + entryv, mskdpath.Text + "\\SaveGame\\" + entryv);
                                // Select the new item
                                //if (index < reclistpack.Items.Count)
                                //    reclistpack.SelectedIndex = index;
                            }

                            //end
                        }
           
        }

        private void recchoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recchoice.Text == "Don't Save")
            {
                recfield.Enabled = false;
                packfn.Enabled = false;
                folderradio.Enabled = false;
                renametxt.Enabled = false;
                kryptonButton1.Enabled = false;
            }
            else if (recchoice.Text == "Save Replay")
            {
                recfield.Enabled = true;
                packfn.Enabled = true;
                folderradio.Enabled = true;
                renametxt.Enabled = true;
                kryptonButton1.Enabled = true;
            }
        }


        public void WatchReplay(string _isfolder)
        {
            string getrecex = refdir.Text.Substring(Math.Max(0, refdir.Text.Length - 4));
            string[] getfln = Directory.GetFiles(refdir.Text, "*", SearchOption.AllDirectories);
            foreach (string file in getfln)
            {
                if (reclistpack.SelectedIndex >= 0)
                {
                          string renfilerec = mskdpath.Text + "\\SaveGame\\" + recfield.Text + ".mgz";
                          string renfilerecwk = mskdpath.Text + "\\Games\\WololoKingdoms\\SaveGame\\" + _isfolder + "\\" + recfield.Text + ".mgz";
                   //No WK
                    //if(gamever.Text != "WK")
                    //{
                    ////this rec full path
              
                    ////KryptonMessageBox.Show("start \"" + mskdpath.Text + "\\Age2_x1\\AoE2Tools.exe" + "\"" + " \"" + renfilerec + "\"");
                    //if (_isfolder != "" && !Directory.Exists(_isfolder))
                    //{
                    //    Directory.CreateDirectory(mskdpath.Text + "\\SaveGame\\" + _isfolder);
                    //}
                    //if (!File.Exists(renfilerec))
                    //{
                    //    File.Copy(file, renfilerec);
                    //}
                    //}
                    //End Exception


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
                        //first create file and dir
                        if (_isfolder != "" && !Directory.Exists(_isfolder))
                        {
                            Directory.CreateDirectory(mskdpath.Text + "\\Games\\WololoKingdoms AK\\SaveGame\\" + _isfolder);
                        }
                        if (!File.Exists(renfilerecwk))
                        {
                            File.Copy(file, renfilerecwk);
                        }
                        //end

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
                }
                //end
                break;
            }
        }

        private void reclistpack_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void recfield_TextChanged(object sender, EventArgs e)
        {
            if (recfield.Text.Contains(".mgz") || recfield.Text.Contains(".mgx"))
            {
                recfield.Text = recfield.Text.Remove(recfield.Text.Length - 4);
            }
        }

        public string NativeDir()
        {
            string result = "";

            if (Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + packfn.Text))
            {
                //DirCopy(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + packfn.Text, mskdpath.Text + "\\SaveGame\\" + packfn.Text);
                result = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + packfn.Text;
            }
            else if (Directory.Exists(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + oldfolder.Text))
            {
                //DirCopy(System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + oldfolder.Text, mskdpath.Text + "\\SaveGame\\" + oldfolder.Text);
                result = System.IO.Path.GetTempPath() + @"\hdtotc-tmp\savegametmp\" + oldfolder.Text;
            }

            return result;
        }

public void ListLoad()
        {
            DirectoryInfo info = new DirectoryInfo(refdir.Text);
            FileInfo[] files = info.GetFiles("*").OrderByDescending(p => p.CreationTime).ToArray();
            int idc = 0;
            foreach (FileInfo file in files)
            {
                idc++;
                string _itemrec = file.ToString();
                //if (!_itemrec.Contains(".mgz") || !_itemrec.Contains(".mgx"))
                //{
                //    continue;
                //}
                //else if (_itemrec.Contains(".mgx"))
                //{

                //}
                reclistpack.Items.Add(CreateNewItem(file.ToString()));
            }
        }

private void kryptonLabel5_Paint(object sender, PaintEventArgs e)
{

}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Launcher
{
    public partial class LnchR : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        // needed so that Explorer windows get refreshed after the registry is updated
        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

        public LnchR()
        {
            
            //LauncherCheck.RunWorkerAsync();
            InitializeComponent();
            TriggerLauncher();
        }

        private  void LauncherCheck_DoWork(object sender, DoWorkEventArgs e)
        {
        
            TriggerLauncher();
        }
        void TriggerLauncher()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                //&& Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Launcher", null) == null
                if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                {
                    string aoe2pathadm = key.GetValue("AoE2Path").ToString();
                    if (File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.exe") && Directory.Exists(aoe2pathadm + @"\SaveGame"))
                    {
                        scanfirst.Enabled = false;
                        start.Enabled = true;
                        convert.Enabled = false;
                        //hdtoaoclnk.Visible = true;
                        //hdtoaoclnk.Visible = true;
                    }
                    else if (!File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.exe"))
                    {
                        
                        start.Enabled = false;
                        convert.Enabled = true;
                    }
                    else
                    {
                        scanfirst.Enabled = true;
                        start.Enabled = false;
                    }
                   
                   
                }
                else if (IsAdministrator() == false)
                {
                    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                    startInfo.Verb = "runas";
                    System.Diagnostics.Process.Start(startInfo);
                    Process.GetCurrentProcess().Kill();
                }
                else if (IsAdministrator() == true)
                {
                    //convert.Enabled = true;
                    scanfirst.Enabled = true;
                    start.Enabled = false;
                }
            }
        }


        public static void SetAssociation2(string Extension, string KeyName, string OpenWith, string FileDescription)
        {
            RegistryKey BaseKey;
            RegistryKey OpenMethod;
            RegistryKey Shell;
            RegistryKey CurrentUser;

            BaseKey = Registry.ClassesRoot.CreateSubKey(Extension);
            BaseKey.SetValue("", KeyName);

            OpenMethod = Registry.ClassesRoot.CreateSubKey(KeyName);
            OpenMethod.SetValue("", FileDescription);
            OpenMethod.CreateSubKey("DefaultIcon").SetValue("", "\"" + OpenWith + "\",0");
            Shell = OpenMethod.CreateSubKey("Shell");
            Shell.CreateSubKey("edit").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
            Shell.CreateSubKey("open").CreateSubKey("command").SetValue("", "\"" + OpenWith + "\"" + " \"%1\"");
            BaseKey.Close();
            OpenMethod.Close();
            Shell.Close(); 

            CurrentUser = Registry.CurrentUser.CreateSubKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + Extension);
            CurrentUser = CurrentUser.OpenSubKey("UserChoice", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            CurrentUser.SetValue("Progid", KeyName, RegistryValueKind.String);
            CurrentUser.Close();
        }
        void GameDetective()
        {
            //BEGIN
            using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            {
                if (key64 != null && Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", "EXE Path", null) != null)
                {
                    string aoe2pathadm = key64.GetValue("EXE Path").ToString();

                    
                    if (aoe2pathadm != null && File.Exists(aoe2pathadm + "\\age2_x1\\age2_x1.exe"))
                    {
                        //config AoE2Tools

                        try
                        {
                            //initiate subkey
                            RegistryKey regkey = Registry.CurrentUser;
                            regkey = regkey.CreateSubKey(@"Software\AoE2Tools"); //this is the path then you create yours keys
                            regkey.Close();
                            //Config path

                            using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                            {
                                if (SetGame != null)
                                {

                                    KryptonMessageBox.Show(new Form { TopMost = true, StartPosition = FormStartPosition.CenterScreen }, "We Found an Existing Installation of Age of Empires 2", "Heck Yeah!");

                                    
                                    SetGame.SetValue("AoE2Path", aoe2pathadm);
                                    SetGame.SetValue("Ren", "Save Replay");
                                    SetGame.SetValue("SetVoobly", "auto");
                                    SetGame.SetValue("SetGame", "auto");
                                    SetGame.SetValue("SetHotkeys", "no");
                                    SetGame.SetValue("Small Trees", "no");
                                    SetGame.SetValue("Short Walls", "no");
                                    SetGame.SetValue("Light Grid", "no");
                                    SetGame.SetValue("Advanced Idle Pointer", "no");
                                    SetGame.SetValue("Huge Number", "no");
                                    SetGame.SetValue("Blue Berries", "no");
                                    SetGame.SetValue("Flag", "en");
                                    SetGame.SetValue("Launcher", "1");
                                    ApplyHotfix();
                                    TriggerLauncher();
                                    convert.Enabled = false;
                                    //hdtoaoclnk.Visible = true;
                                    start.Enabled = true;
                                    //
                                    // Create a new instance of the Form2 class
                                    //if (!File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.4.exe") && !File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.5.exe") && !File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.0c.exe"))
                                    //{



                                    //}


                                }
                                else
                                {
                                    convert.Enabled = true;
                                    start.Enabled = false;
                                }
                                //End Config

                                //Change Path Adviser

                                //Grant Access AoE2Tools
                                //KryptonMessageBox.Show("AoE2Tools Environment ready!", "Getting Ready");
                                //DialogResult dialogResult2 = KryptonMessageBox.Show("\n Click Ok To Restart AoE2Tools!", "AoE2Tools is Ready!");
                                //if (dialogResult2 == DialogResult.OK)
                                //{
                                //    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                                //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                                //    System.Diagnostics.Process.Start(startInfo);
                                //    Process.GetCurrentProcess().Kill();
                                //}
                                //else
                                //{
                                //    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                                //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                                //    System.Diagnostics.Process.Start(startInfo);
                                //    Process.GetCurrentProcess().Kill();
                                //}

                                //Application.EnableVisualStyles();
                                //Application.SetCompatibleTextRenderingDefault(false);
                                //Application.Run(new AoE2Tools());

                            }
                        }
                        //catch (Exception yu)
                        //{ MessageBox.Show(yu.ToString()); }
                        catch (SystemException)
                        {  }
                    }

                    else
                    {
                        convert.Enabled = true;
                        start.Enabled = false;
                    }

                }
                else if (key32 != null && Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", "EXE Path", null) != null)
                {
                    string aoe2pathadm = key32.GetValue("EXE Path").ToString();

                    //Object o = key.GetValue("Language");
                    if (aoe2pathadm != null && File.Exists(aoe2pathadm + "\\age2_x1\\age2_x1.exe"))
                    {
                        //config AoE2Tools

                        try
                        {
                            //initiate subkey
                            RegistryKey regkey = Registry.CurrentUser;
                            regkey = regkey.CreateSubKey(@"Software\AoE2Tools"); //this is the path then you create yours keys
                            regkey.Close();
                            //Config path

                            using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                            {
                                if (SetGame != null)
                                {
                                    KryptonMessageBox.Show(this, "We Found an Existing Installation of Age of Empires 2", "Heck Yeah!");
                                   
                                    //Object o32 = key32.GetValue("InstallPath");
                                    SetGame.SetValue("AoE2Path", aoe2pathadm);
                                    SetGame.SetValue("Ren", "Save Replay");
                                    SetGame.SetValue("SetVoobly", "auto");
                                    SetGame.SetValue("SetGame", "auto");
                                    SetGame.SetValue("SetHotkeys", "no");
                                    SetGame.SetValue("Small Trees", "no");
                                    SetGame.SetValue("Short Walls", "no");
                                    SetGame.SetValue("Light Grid", "no");
                                    SetGame.SetValue("Advanced Idle Pointer", "no");
                                    SetGame.SetValue("Huge Number", "no");
                                    SetGame.SetValue("Blue Berries", "no");
                                    SetGame.SetValue("Flag", "en");
                                    SetGame.SetValue("Launcher", "1");
                
                                    ApplyHotfix();
                                    TriggerLauncher();
                                    convert.Enabled = false;
                                    //hdtoaoclnk.Visible = true;
                                    start.Enabled = true;
                                    //
                                    // Create a new instance of the Form2 class
                                    //if (!File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.4.exe") && !File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.5.exe") && !File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.0c.exe"))
                                    //{



                                    //}


                                }
                                else
                                {
                                    convert.Enabled = true;
                                    start.Enabled = false;
                                }
                                //End Config

                                //Change Path Adviser

                                //Grant Access AoE2Tools
                                //KryptonMessageBox.Show("AoE2Tools Environment ready!", "Getting Ready");
                                //DialogResult dialogResult2 = KryptonMessageBox.Show("\n Click Ok To Restart AoE2Tools!", "AoE2Tools is Ready!");
                                //if (dialogResult2 == DialogResult.OK)
                                //{
                                //    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                                //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                                //    System.Diagnostics.Process.Start(startInfo);
                                //    Process.GetCurrentProcess().Kill();
                                //}
                                //else
                                //{
                                //    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                                //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                                //    System.Diagnostics.Process.Start(startInfo);
                                //    Process.GetCurrentProcess().Kill();
                                //}

                                //Application.EnableVisualStyles();
                                //Application.SetCompatibleTextRenderingDefault(false);
                                //Application.Run(new AoE2Tools());

                            }
                        }
                        catch (Exception yu)
                        { throw yu; }
                    }
                    else
                    {
                        convert.Enabled = true;
                        start.Enabled = false;
                    }

                }
                else if (key64 == null && key32 == null)
                {
                    convert.Enabled = true;
                    start.Enabled = false;
                   
                }
                else
                {
                    //Show Preconv
                    //KryptonMessageBox.Show("Running admin32", "success!");
                    ////try
                    ////{
                    convert.Enabled = true;
                    start.Enabled = false;
                    
                    //}
                    //catch (SystemException)
                    //{

                    //}

                    //Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new PreConv());
                }
         
            }
        }

        async void ApplyHotfix()
        {
            if (!File.Exists(getaoepath.Text + @"\aoe2tools.ico") && File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\aoe2tools.ico"))
            {
                File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\aoe2tools.ico", getaoepath.Text + @"\aoe2tools.ico");
            }
            //using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //{
            //    if (SetGame != null)
            //    {
            //        string aoe2pathadm = SetGame.GetValue("AoE2Path").ToString();
            //        getaoepath.Text = aoe2pathadm;
            //        var gettmpdir = System.IO.Path.GetTempPath();
            //        //BeginInvoke((MethodInvoker)delegate
            //        //{
            //        //    progressBar1.Value = 5;
            //        //});
            //        byte[] bytie = File.ReadAllBytes("libc.bin");
            //        byte[] result = Replace(bytie, new byte[] { 0x6b, 0x55, 0x63, 0x49, 0x37, 0x39, 0x44, 0x34, 0x73, 0x67, 0x6d, 0x4b, 0x61, 0x38, 0x6a, 0x4f, 0x33, 0x47, 0x74, 0x49, 0x70, 0x56, 0x49, 0x64, 0x53, 0x66, 0x5a, 0x7a, 0x72, 0x53, 0x6c, 0x4a, 0x77, 0x7a, 0x32, 0x52, 0x6a, 0x32, 0x31, 0x67, 0x43, 0x6a, 0x47, 0x4a, 0x39, 0x33, 0x6f, 0x72, 0x6d, 0x5a, 0x6b, 0x71, 0x32, 0x57, 0x53, 0x72, 0x67, 0x34, 0x49, 0x31, 0x79, 0x4f, 0x72, 0x44, 0x54, 0x39, 0x58, 0x77, 0x59, 0x76, 0x43, 0x7a, 0x6b, 0x35, 0x76, 0x72, 0x70, 0x4e, 0x72, 0x36, 0x68, 0x73, 0x53, 0x68, 0x30, 0x78, 0x36, 0x33, 0x75, 0x36, 0x62, 0x4f, 0x73, 0x6e, 0x35, 0x70, 0x55, 0x6d, 0x49, 0x46, 0x35, 0x69, 0x70, 0x58, 0x6c, 0x41, 0x45, 0x36, 0x78, 0x4b, 0x53, 0x4c, 0x64, 0x70, 0x50, 0x65, 0x54, 0x44, 0x70, 0x74, 0x66, 0x42, 0x4f, 0x4d, 0x56, 0x44, 0x50, 0x4f, 0x6c, 0x37, 0x61, 0x4b, 0x31, 0x6e, 0x39, 0x69, 0x4c, 0x45, 0x54, 0x36, 0x6d, 0x43, 0x44, 0x58, 0x4c, 0x51, 0x50, 0x58, 0x46, 0x66, 0x42, 0x69, 0x49, 0x4c, 0x55, 0x52, 0x31 }, new byte[] { 0x37, 0x7a, 0xbc, 0xaf, 0x27, 0x1c, 0x00, 0x04, 0x4a, 0xad, 0xfa, 0x6e, 0xec, 0xbb, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5a, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x39, 0xaf, 0x8f, 0x04, 0xe3, 0xe0, 0xbc, 0xe0, 0x4e, 0x5d, 0x00, 0x1a, 0x11, 0x02, 0xa4, 0x13, 0x47, 0x58, 0xcb, 0x06, 0x78, 0x0c, 0x99, 0x7c, 0x9d, 0x24, 0xf3, 0x6d, 0x9e, 0xfb, 0x88, 0x12, 0x2d, 0xce, 0x2b, 0xd8, 0x2a, 0x1c, 0xa5, 0x60, 0x0f, 0x72, 0xc6, 0x48, 0x93, 0x05, 0xfe, 0x12, 0xd7, 0x09, 0x42, 0x5c });
            //        File.WriteAllBytes(System.IO.Path.GetTempPath() + "\\ver.bin", result);
            //        //BeginInvoke((MethodInvoker)delegate
            //        //{
            //        //    progressBar1.Value = 10;
            //        //});

            //        Pregz(gettmpdir + "\\ver.bin", gettmpdir + "\\Precache\\");
            //        string d = System.IO.Path.GetTempPath() + "\\Precache\\" + Properties.Resources.String11;
            //        string s = File.ReadAllText(d);
            //        string[] words = s.Split('X');
            //        int cnt = 0;
            //        //int cnt2 = 10;
            //        foreach (string word in words)
            //        {
            //            cnt++;
            //            //backgroundWorker2.ReportProgress(pgb + (cnt2 * cnt));
            //            File.WriteAllText(System.IO.Path.GetTempPath() + "\\Precache\\" + cnt + Properties.Resources.String2, word);

            //            string hs = File.ReadAllText(System.IO.Path.GetTempPath() + "\\Precache\\" + cnt + Properties.Resources.String2);
            //            if (cnt == 1)
            //            {
            //                //BeginInvoke((MethodInvoker)delegate
            //                //{
            //                //    progressBar1.Value = 20;
            //                //});

            //                File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.String3, stba(hs));
            //            }

            //            else if (cnt == 2)
            //            {
            //                //BeginInvoke((MethodInvoker)delegate
            //                //{
            //                //    progressBar1.Value = 40;
            //                //});

            //                File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.String4, stba(hs));
            //            }

            //            else if (cnt == 3)
            //            {
            //                //BeginInvoke((MethodInvoker)delegate
            //                //{
            //                //    progressBar1.Value = 60;
            //                //});

            //                File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.String5, stba(hs));

            //            }


            //            //clear


            //        }

            //        if (Directory.Exists(System.IO.Path.GetTempPath() + @"\Precache\"))
            //            Directory.Delete(System.IO.Path.GetTempPath() + @"\Precache\", true);
            //        if (File.Exists(System.IO.Path.GetTempPath() + @"\ver.bin"))
            //        {
            //            File.Delete(System.IO.Path.GetTempPath() + @"\ver.bin");
            //        }
            //        //BeginInvoke((MethodInvoker)delegate
            //        //{
            //        //    progressBar1.Value = 100;
            //        //});



            //    }
            //}





            //File Association
            //GetDefaultsFromRegistry();


            pictureBox1.Enabled = true;
            pictureBox1.Visible = true;
            backgroundWorker2.RunWorkerAsync();
            //Associate(getaoepath.Text);



            //SetAssociation_User("mgz", getaoepath.Text + @"\age2_x1\AoE2Tools.exe", "AoE2Tools.exe");
            //SetAssociation_User("mgx", getaoepath.Text + @"\age2_x1\AoE2Tools.exe", "AoE2Tools.exe");
            //SetAssociation("mgz", "AoE2Tools.exe", "Watch AoE2 Replays", getaoepath.Text + @"\age2_x1\AoE2Tools.exe");

            //UNCHECK BELLOW IN CASE
            //SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);


            //GrantAccess(getaoepath.Text);
            //Thread.Sleep(2000);

            //ACCESS ISSUES
            //if (getaoepath.Text.Contains(Environment.ExpandEnvironmentVariables("%ProgramW6432%")) || getaoepath.Text.Contains(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%")))
            //{
            //    try
            //    {
            //    await Task.Run(() =>
            //    {
            //        DirectorySecurity sec = Directory.GetAccessControl(getaoepath.Text);
            //        // Using this instead of the "Everyone" string means we work on non-English systems.
            //        SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            //        sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            //        Directory.SetAccessControl(getaoepath.Text, sec);

            //    });
            //    }
            //    catch(Exception ex)
            //    {
            //        throw ex;
            //    }

       
            //    pictureBox1.Enabled = true;
            //    pictureBox1.Visible = true;
            //}

        }
        private void GetDefaultsFromRegistry()
        {
            if (Registry.GetValue("HKEY_CLASSES_ROOT\\AoE2Tools", String.Empty, String.Empty) == null)
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\AoE2ToolsGreg", "", "mgz");
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\AoE2ToolsGreg", "AoE2Tools-mgz", "Watch Recs");
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\AoE2ToolsGreg\\shell\\open\\command", "",
                    getaoepath.Text + @"\age2_x1\AoE2Tools.exe" + "\"%1\"");
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Classes\\.mgz", "", "AoE2Tools");

                //this call notifies Windows that it needs to redo the file associations and icons
                SHChangeNotify(0x08000000, 0x2000, IntPtr.Zero, IntPtr.Zero);
            }
        }
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "AoE2Tools.exe");
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "HDToAoC.exe");
            this.Close();
        }
        public static MessageBoxIcon _mbIcon { get; set; }

        public static MessageBoxButtons _mbButtons { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl,
                                                             InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                                             PropagationFlags.InheritOnly, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            return true;
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
                //delete first
                RegistryKey CurrentUser;
                CurrentUser = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + Extension, true);
                CurrentUser.DeleteSubKey("UserChoice", false);
                CurrentUser.Close();

                //proceed
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

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackgroundImage = Properties.Resources.launcher_close3;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackgroundImage = Properties.Resources.launcher_close1;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (scanfirst.Text == "Restart")
            {
                this.Close();
                Process.Start("AoE2Tools.exe");
            }

            scanfirst.Enabled = false;
            scanfirst.Text = "Scanning..";
            pictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void LnchR_Load(object sender, EventArgs e)
        {

            //Launcher or Not
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                //&& Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Launcher", null) == null
                if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Launcher", null) != null)
                {
                    string launcherval = key.GetValue("Launcher").ToString();
                    if (launcherval == "0")
                    {
                        this.Close();
                        Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\AoE2Tools.exe");
                    }


                }
                else
                {
                  
                }
            }
        }

        private void LnchR_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (IsAdministrator() == true)
            {
                //Auto Associate
                try
                {
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"age2.age2_x1.0\shell\Open\command", true))
                    {
                        if (key != null)
                        {
                            key.SetValue("", key.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));

                        }
                    }
                    using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"age2.age2_x1.1\shell\Open\command", true))
                    {
                        if (key != null)
                        {
                            key.SetValue("", key.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                        }
                    }
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
                    using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                    {
                        if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                        {
                            string transrt = rk.GetValue("AoE2Path").ToString();


                            Associate(transrt);

                        }

                    }

                    KryptonMessageBox.Show("File Association Success!", "Done!");

                }
                catch (SystemException)
                {

                }
                //ENd Association
            }
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"AoE2Tools.exe"))
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"AoE2Tools.exe");
                this.Close();
            }
           
        }

        private void convert_Click(object sender, EventArgs e)
        {

            if (File.Exists(Environment.GetFolderPath(
Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\HDToAoC.exe"))
            {
                Process.Start(Environment.GetFolderPath(
Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\HDToAoC.exe");
                this.Close();
            }
            else if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"HDToAoC.exe"))
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"HDToAoC.exe");
                this.Close();
            }


        
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                GameDetective();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private async void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            start.Enabled = false;
            await Task.Delay(15000);
            start.Enabled = true;
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            scanfirst.Enabled = false;
            scanfirst.Text = "Success";
            //File Association
            try
            {
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"age2.age2_x1.0\shell\Open\command", true))
                {
                    if (key != null)
                    {
                        key.SetValue("", key.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));

                    }
                }
                using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"age2.age2_x1.1\shell\Open\command", true))
                {
                    if (key != null)
                    {
                        key.SetValue("", key.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                    }
                }
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
                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                {
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                    {
                        string transrt = rk.GetValue("AoE2Path").ToString();


                        Associate(transrt);

                    }

                }

                KryptonMessageBox.Show("File Association Success!", "Done!");

            }
            catch (SystemException)
            {

            }
            //End File Association
            //convert.Enabled = false;
            //start.Enabled = false;
            //scanfirst.Text = "Done!";
        }

        //file asso

        public class FileAssociation
{
    public string Extension { get; set; }
    public string ProgId { get; set; }
    public string FileTypeDescription { get; set; }
    public string ExecutableFilePath { get; set; }
}

       
          
            private const int SHCNE_ASSOCCHANGED = 0x8000000;
            private const int SHCNF_FLUSH = 0x1000;

            public static void EnsureAssociationsSet()
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    //&& Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Launcher", null) == null
                    if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                    {
                        string aoe2pathadm = key.GetValue("AoE2Path").ToString();
                        var filePath = aoe2pathadm + "\\Age2_x1";
                        EnsureAssociationsSet(
                            new FileAssociation
                            {
                                Extension = ".mgz",
                                ProgId = "AoE2Tools",
                                FileTypeDescription = "Watch AoE2 Replays",
                                ExecutableFilePath = filePath
                            });
                    }
                }
 
            }

            public static void EnsureAssociationsSet(params FileAssociation[] associations)
            {
                bool madeChanges = false;
                foreach (var association in associations)
                {
                    madeChanges |= SetAssociation(
                        association.Extension,
                        association.ProgId,
                        association.FileTypeDescription,
                        association.ExecutableFilePath);
                }

                if (madeChanges)
                {
                    SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
                }
            }

            public static bool SetAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath)
            {
                bool madeChanges = false;
                madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + extension, progId);
                madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + progId, fileTypeDescription);
                madeChanges |= SetKeyDefaultValue(@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\" \"%1\"");
                return madeChanges;
            }

            private static bool SetKeyDefaultValue(string keyPath, string value)
            {
                using (var key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key.GetValue(null) as string != value)
                    {
                        key.SetValue(null, value);
                        return true;
                    }
                }

                return false;
            }

            private void hdtoaoclnk_LinkClicked(object sender, EventArgs e)
            {
                Process.Start(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\HDToAoC.exe");
                this.Close();
            }

            private void panel4_Paint(object sender, PaintEventArgs e)
            {

            }

            private async void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
            {

                try
                {
                    await Task.Run(() =>
                    {
                        using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"age2.age2_x1.0\shell\Open\command", true))
                        {
                            if (key != null)
                            {
                                key.SetValue("", key.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));

                            }
                        }
                        using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"age2.age2_x1.1\shell\Open\command", true))
                        {
                            if (key != null)
                            {
                                key.SetValue("", key.GetValue("").ToString().Replace("age2_x1.exe", "AoE2Tools.exe"));
                            }
                        }
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
                        Associate(getaoepath.Text);
                    });
                    
                }
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
                catch (SystemException)
                {
                   
                }
            }

            private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                //await Task.Delay(30000);
                pictureBox1.Enabled = true;
                pictureBox1.Visible = true;
            }

            private void enbhdtoaoc_CheckedChanged(object sender, EventArgs e)
            {
                if(enbhdtoaoc.Checked == true)
                {
                    convert.Enabled = true;
                }
                else if (enbhdtoaoc.Checked == false)
                {
                    convert.Enabled = false;
                }
            }

            private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
            {
                if(kryptonCheckBox1.Checked == true)
                {
                    resetaoe2tools.Enabled = true;
                }
                else
                {
                    resetaoe2tools.Enabled = false;
                }
            }

            private void resetaoe2tools_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult = KryptonMessageBox.Show("Reset AoE2Tools?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    try
                    {
                        Registry.CurrentUser.DeleteSubKeyTree("Software\\AoE2Tools");
                    }
                    catch (System.ArgumentException)
                    {

                    }

                
                    var exeName = AppDomain.CurrentDomain.BaseDirectory + @"Launcher.exe";
                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                    System.Diagnostics.Process.Start(startInfo);
                    Process.GetCurrentProcess().Kill();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }

            private void kryptonCheckBox1_CheckedChanged_1(object sender, EventArgs e)
            {

            }
            
            
    }
}

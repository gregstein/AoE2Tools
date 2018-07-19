using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ComponentFactory.Krypton.Toolkit;
using System.Reflection;
using System.Security.AccessControl;
namespace WindowsFormsApplication3
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestUI());
            ////DEBUG////
            ////////////
            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //{

            //    if (key != null && Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
            //    {
            //        string aoe2path = key.GetValue("AoE2Path").ToString();
            //        string Select_p = aoe2path;
            //        var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            //        var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            //        //found keys
            //        if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe") && IsAdministrator() == false && (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0))
            //            //{

            //            //    //Reboot as admin
            //            //    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //            //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //            //    startInfo.Verb = "runas";
            //            //    System.Diagnostics.Process.Start(startInfo);
            //            //    Process.GetCurrentProcess().Kill();
            //            //}
            //            //else if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe") && IsAdministrator() == true && (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0))
            //            //{

            //            //    //Invode AoE2Tools admin ver

            //            //    _mbIcon = MessageBoxIcon.Warning;
            //            //    _mbButtons = MessageBoxButtons.YesNo;
            //            //    DialogResult dialogResult = KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like AoE2Tools To Safely Move Your Game To A Custom Location?", "Important! (Optional)", _mbButtons, _mbIcon);

            //            //    //KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "(Optional) Warning!");
            //            //    if (dialogResult == DialogResult.Yes)
            //            //    {
            //            //        //Invoke Mover
            //            //        Process.Start("AoE2Tools Mover.exe");
            //            //    }
            //            //    else if (dialogResult == DialogResult.No)
            //            //    {
            //            //        //Run AoE2Tools
            //            //        KryptonMessageBox.Show("Managing Replays and Drop & Drop Features are disabled Until You Move Age of Empires 2 to a custom or recommended directory!", "Attention!");
            //            //        var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //            //        var filename = Path.Combine(path, "AoE2Tools.exe");
            //            //        var assembly = Assembly.LoadFile(filename);
            //            //        var programType = assembly.GetTypes().FirstOrDefault(c => c.Name == "WindowsFormsApplication3"); // <-- if you don't know the full namespace and when it is unique.
            //            //        var method = programType.GetMethod("Start", BindingFlags.Public | BindingFlags.Static);
            //            //        method.Invoke(null, new object[] { });
            //            //        //Application.EnableVisualStyles();
            //            //        //Application.SetCompatibleTextRenderingDefault(false);
            //            //        //Application.Run(new AoE2Tools());
            //            //    }



            //            //    //Process.Start("AoE2ToolsAdmin.exe");
            //            //    //System.Environment.Exit(1);
            //            //    //Assembly.LoadFrom("");

            //            //}
            //            if (aoe2path != null && File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe"))
            //            {
            //                //grant
            //                Application.EnableVisualStyles();
            //                Application.SetCompatibleTextRenderingDefault(false);

            //                Application.Run(new AoE2Tools());
            //            }
            //            //found keys
            //            else if (aoe2path != null && !File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe"))
            //            {
            //                //grant
            //                KryptonMessageBox.Show("age2_x1.exe Not Found!", "Error!");
            //            }
            //            //no keys
            //            else if (aoe2path == null && !File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe") && IsAdministrator() == false)
            //            {
            //                // Restart program and run as admin
            //                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //                startInfo.Verb = "runas";
            //                System.Diagnostics.Process.Start(startInfo);
            //                Process.GetCurrentProcess().Kill();
            //            }



            //            else if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) == null && !File.Exists(aoe2path + "\\age2_x1\\age2_x1.exe") && IsAdministrator() == true)
            //            {

            //                //BEGIN ADMIN
            //                //KryptonMessageBox.Show("Running admin", "success!");
            //                Application.EnableVisualStyles();
            //                Application.SetCompatibleTextRenderingDefault(false);
            //                Application.Run(new AoE2Tools());

            //            }
            //    }
            //    //no aoe2tools keys found!
            //    else if (key == null && IsAdministrator() == false)
            //    {
            //        //UAC PROMPT
            //        try
            //        {
            //            var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //            ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //            startInfo.Verb = "runas";
            //            System.Diagnostics.Process.Start(startInfo);
            //            Process.GetCurrentProcess().Kill();
            //        }
            //        catch (SystemException)
            //        {

            //        }



            //    }
            //    //AFTER UAC
            //    else if (key == null && IsAdministrator() == true)
            //    {
            //        //UAC PROMPT

            //        //var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //        //ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //        //startInfo.Verb = "runas";
            //        //System.Diagnostics.Process.Start(startInfo);
            //        //Process.GetCurrentProcess().Kill();

            //        //BEGIN
            //        using (RegistryKey key32 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            //        using (RegistryKey key64 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
            //        {
            //            if (key64 != null && Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", "EXE Path", null) != null)
            //            {
            //                string aoe2pathadm = key64.GetValue("EXE Path").ToString();

            //                //Object o = key.GetValue("Language");
            //                if (aoe2pathadm != null && File.Exists(aoe2pathadm + "\\age2_x1\\age2_x1.exe"))
            //                {
            //                    //config AoE2Tools

            //                    try
            //                    {
            //                        //initiate subkey
            //                        RegistryKey regkey = Registry.CurrentUser;
            //                        regkey = regkey.CreateSubKey(@"Software\AoE2Tools"); //this is the path then you create yours keys
            //                        regkey.Close();
            //                        //Config path

            //                        using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //                        {
            //                            if (SetGame != null)
            //                            {
            //                                KryptonMessageBox.Show("We Found an Existing Installation of Age of Empires 2", "Heck Yeah!");

            //                                //Object o32 = key32.GetValue("InstallPath");
            //                                SetGame.SetValue("AoE2Path", aoe2pathadm);
            //                                SetGame.SetValue("Ren", "Save Replay");
            //                                SetGame.SetValue("SetVoobly", "auto");
            //                                SetGame.SetValue("SetGame", "auto");
            //                                SetGame.SetValue("SetHotkeys", "no");
            //                                SetGame.SetValue("Small Trees", "no");
            //                                SetGame.SetValue("Short Walls", "no");
            //                                SetGame.SetValue("Light Grid", "no");
            //                                SetGame.SetValue("Advanced Idle Pointer", "no");
            //                                SetGame.SetValue("Huge Number", "no");
            //                                SetGame.SetValue("Blue Berries", "no");
            //                                SetGame.SetValue("Flag", "en");

            //                                //
            //                                // Create a new instance of the Form2 class
            //                                // if (!File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.4.exe") && !File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.5.exe") && !File.Exists(aoe2pathadm + @"\Age2_x1\age2_x1.0c.exe"))
            //                                //{
            //                                PrepareEnv PreEnv = new PrepareEnv();
            //                                //PreEnv.Show();
            //                                PreEnv.ShowDialog();
                                        
                                    
            //                                //}


            //                            }
            //                            //End Config

            //                            //Change Path Adviser

            //                            //Grant Access AoE2Tools
            //                            //KryptonMessageBox.Show("AoE2Tools Environment ready!", "Getting Ready");
            //                            //DialogResult dialogResult2 = KryptonMessageBox.Show("\n Click Ok To Restart AoE2Tools!", "AoE2Tools is Ready!");
            //                            //if (dialogResult2 == DialogResult.OK)
            //                            //{
            //                            //    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //                            //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //                            //    System.Diagnostics.Process.Start(startInfo);
            //                            //    Process.GetCurrentProcess().Kill();
            //                            //}
            //                            //else
            //                            //{
            //                            //    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //                            //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //                            //    System.Diagnostics.Process.Start(startInfo);
            //                            //    Process.GetCurrentProcess().Kill();
            //                            //}

            //                            //Application.EnableVisualStyles();
            //                            //Application.SetCompatibleTextRenderingDefault(false);
            //                            //Application.Run(new AoE2Tools());

            //                        }
            //                    }
            //                    catch (Exception yu)
            //                    { throw yu; }
            //                }

            //            }
            //            else if (key32 != null && Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", "EXE Path", null) != null)
            //            {
            //                //check 32bit
            //                string aoe2pathadm2 = key32.GetValue("EXE Path").ToString();
            //                if (aoe2pathadm2 != null && File.Exists(aoe2pathadm2 + "\\age2_x1\\age2_x1.exe"))
            //                {
            //                    //config AoE2Tools

            //                    try
            //                    {
            //                        //Config path
            //                        using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            //                        {
            //                            if (SetGame != null)
            //                            {

            //                                SetGame.SetValue("AoE2Path", aoe2pathadm2);
            //                            }
            //                        }
            //                        //End Config
            //                        //Change Path Adviser
            //                        string Select_p = aoe2pathadm2;
            //                        var programfileX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            //                        var programfileX64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            //                        if (Select_p.IndexOf(programfileX86, StringComparison.OrdinalIgnoreCase) >= 0 || Select_p.IndexOf(programfileX64, StringComparison.OrdinalIgnoreCase) >= 0)
            //                        {
            //                            _mbIcon = MessageBoxIcon.Warning;
            //                            _mbButtons = MessageBoxButtons.YesNo;
            //                            DialogResult dialogResult = KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "Warning! (Optional)", _mbButtons, _mbIcon);

            //                            //KryptonMessageBox.Show("Age of Empires 2 is Installed in The System Directory\n\n (Recommended) Would You Like Us To Safely Move The Game For You?", "(Optional) Warning!");
            //                            if (dialogResult == DialogResult.Yes)
            //                            {
            //                                //Invoke Mover
            //                                Process.Start("AoE2Tools Mover.exe");

            //                            }
            //                            else if (dialogResult == DialogResult.No)
            //                            {
            //                                //Grand Access AoE2Tools
            //                                Application.EnableVisualStyles();
            //                                Application.SetCompatibleTextRenderingDefault(false);
            //                                Application.Run(new AoE2Tools());
            //                            }
            //                        }
            //                        //Grant Access AoE2Tools
            //                        Application.EnableVisualStyles();
            //                        Application.SetCompatibleTextRenderingDefault(false);
            //                        Application.Run(new AoE2Tools());

            //                    }
            //                    catch (Exception yu)
            //                    { throw yu; }
            //                }
            //            }
            //            else
            //            {
            //                //Show Preconv
            //                //KryptonMessageBox.Show("Running admin32", "success!");
            //                try
            //                {
            //                    Process.Start(Directory.GetCurrentDirectory() + "\\HDToAoC.exe");
            //                }
            //                catch (SystemException)
            //                {

            //                }

            //                //Application.EnableVisualStyles();
            //                //Application.SetCompatibleTextRenderingDefault(false);
            //                //Application.Run(new PreConv());
            //            }
            //            //else if (key64 == null)
            //            //{
            //            //    //Show Preconv
            //            //    KryptonMessageBox.Show("Running admin64", "success!");
            //            //    Application.EnableVisualStyles();
            //            //    Application.SetCompatibleTextRenderingDefault(false);
            //            //    Application.Run(new PreConv());
            //            //}
            //        }



            //        //END ADMIN
            //        //Run preconv
            //        //Application.EnableVisualStyles();
            //        //Application.SetCompatibleTextRenderingDefault(false);
            //        //Application.Run(new PreConv());


            //    }
            //    else
            //    {
            //        if (IsAdministrator() == false)
            //        {
            //            var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //            ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //            startInfo.Verb = "runas";
            //            System.Diagnostics.Process.Start(startInfo);
            //            Process.GetCurrentProcess().Kill();


            //        }
            //        else if (IsAdministrator() == true)
            //        {
            //            Application.EnableVisualStyles();
            //            Application.SetCompatibleTextRenderingDefault(false);
            //            Application.Run(new PreConv());
            //        }

            //    }

            //    ////////////
            //    //END//////

            //}
        }
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


                

        public static MessageBoxIcon _mbIcon { get; set; }

        public static MessageBoxButtons _mbButtons { get; set; }
    }
}

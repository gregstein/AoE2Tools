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
using Microsoft.Win32;
using ToolTipBalloon;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
namespace Game_Tweaker
{
    public partial class Tweaker : KryptonForm
    {
        public Tweaker()
        {
            InitializeComponent();
        }
        const int SPI_SETCURSORS = 0x0057;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDCHANGE = 0x02;

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
        
    [DllImport("user32.dll", SetLastError = true)]
[return: MarshalAs(UnmanagedType.Bool)]
static extern bool SystemParametersInfo(
    uint uiAction, 
    uint uiParam, 
    bool pvParam, 
    uint fWinIni
);
        //mouse
    public const UInt32 SPI_SETMOUSESPEED = 0x0071;
    public const UInt32 SPI_SETMOUSE = 0x0004;
    public const UInt32 SPI_GETMOUSE = 0x0003;
        //refresh mouse settings
    [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
    public static extern bool SystemParametersInfoGet(uint action, uint param, IntPtr vparam, SPIF fWinIni);
   
    [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
    public static extern bool SystemParametersInfoSet(uint action, uint param, IntPtr vparam, SPIF fWinIni);
  
    public enum SPIF
    {

        None = 0x00,
        /// <summary>Writes the new system-wide parameter setting to the user profile.</summary>
        SPIF_UPDATEINIFILE = 0x01,
        /// <summary>Broadcasts the WM_SETTINGCHANGE message after updating the user profile.</summary>
        SPIF_SENDCHANGE = 0x02,
        /// <summary>Same as SPIF_SENDCHANGE.</summary>
        SPIF_SENDWININICHANGE = 0x02
    }
//dpi
    [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
    static extern int
        GetDeviceCaps(IntPtr hDC, int nIndex);

    [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
    static extern IntPtr
        CreateDC(string lpszDriver, string lpszDeviceName, string lpszOutput, IntPtr
        devMode);

    const int LOGPIXELSX = 88;
    const int LOGPIXELSY = 90;

    int DPIX()
    {
        return DPI(LOGPIXELSX);
    }

    int DPIY()
    {
        return DPI(LOGPIXELSY);
    }

    int DPI(int logPixelOrientation)
    {
        IntPtr displayPointer = CreateDC("DISPLAY", null, null, IntPtr.Zero);
        return Convert.ToInt32(GetDeviceCaps(displayPointer, logPixelOrientation));
    }

        private async void Tweaker_Load(object sender, EventArgs e)
        {
            Task<int> RegistryTask = RegistryChecks();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            //and now we call await on the task 
            int resultreg = await RegistryTask;
            if (resultreg == 1)
            {

            }
            //Backup cursor settings
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data") && !File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\curbak.reg"))
            {
                Task<int> ExpRegistry = exportRegistry(@"HKEY_CURRENT_USER\Control Panel\Cursors", AppDomain.CurrentDomain.BaseDirectory + @"data\curbak.reg");
                int resultexp = await ExpRegistry;
                if (resultexp == 1)
                {

                }
            }




            

        }
        public async Task<int> RegistryChecks() // assume we return an int from this long running operation 
        {
            //await Task.Delay(1000);
            //save game path
            using (RegistryKey rk5 = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                customtxt.Text = rk5.GetValue("AoE2Path").ToString();
                mskdpath2.Text = rk5.GetValue("AoE2Path").ToString();
            }
            //Graphics Settings Check (Win10 Build 1809 or higher )
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", true))
            {
                if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", null) != null)
                {
                    await Task.Run(() =>
                    {
                        string translatestr = rk.GetValue("ReleaseId").ToString();
                        if (Int32.Parse(translatestr) >= 1809)
                        {
                            balancepower.Enabled = true;
                            powersaving.Enabled = true;
                            highperformance.Enabled = true;
                            custompath.Enabled = true;
                            //Check Custom path
                            using (RegistryKey rk1 = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                            {
                                if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "GamePP", null) == null)
                                {

                                    rk1.SetValue("GamePP", customtxt.Text + @"\age2_x1\age2_x1.exe");

                                    agepath.Text = customtxt.Text + @"\age2_x1\age2_x1.exe";
                                }
                            }

                            using (RegistryKey rk2 = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                            {
                                if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                                {
                                    string mygamepath = rk2.GetValue("AoE2Path").ToString();
                                    using (RegistryKey rk3 = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                                    {
                                        if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "GamePP", null) != null)
                                        {
                                            
                                            agepath.Text = mygamepath + @"\age2_x1\age2_x1.exe";
                                        }
                                    }
                                    //hidden gamepath field
                                    mskdpath.Text = mygamepath + @"\age2_x1\age2_x1.exe";
                                }
                            }

                            //Set AOE2 Power Plan
                            using (RegistryKey rk3 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\DirectX\UserGpuPreferences", true))
                            {
                                if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\DirectX\UserGpuPreferences", mskdpath.Text, null) != null)
                                {
                                    string mygamepath2 = rk3.GetValue(mskdpath.Text).ToString();
                                    if (mygamepath2 == @"GpuPreference=0;")
                                    {
                                        balancepower.Checked = true;
                                    }
                                    else if (mygamepath2 == @"GpuPreference=1;")
                                    {
                                        powersaving.Checked = true;
                                    }
                                    else if (mygamepath2 == @"GpuPreference=2;")
                                    {
                                        highperformance.Checked = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            agepath.Text = "This works only on Windows 10 Build 1809 and higher!";
                        }
                    });
                }
                else
                {
                    agepath.Text = "This works only on Windows 10 Build 1809 and higher!";
                }
                //Check Enhance pointer precision
                using (RegistryKey cur3 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Mouse", true))
                {
                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseThreshold1", null) != null && Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseThreshold1", null) != null)
                    {
                        if(cur3.GetValue("MouseThreshold1").ToString() != "0" && cur3.GetValue("MouseThreshold2").ToString() != "0")
                        {
                            mp_mouseacc.Checked = false;
                        }
                        else
                        {
                            mp_mouseacc.Checked = true;
                        }
                    }
                  
                }
                //Check GameDVR
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\xboxgip", true))
                {
                    if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\xboxgip", "Start", null) != "3" || Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\xboxgip", "Start", null) == null)
                    {
                        mp_gamedvr.Checked = true;
                    }
                    else
                    {
                        mp_gamedvr.Checked = false;
                    }
                        
                   
                }
                //Check Normal Mouse
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {
                    //"CommandLine", "Lobby NormalMouse"
                    if ((string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", "CommandLine", null) == "Lobby NormalMouse")
                    {
                        normalmouse.Checked = true;
                        mp_normalmouse.Checked = true;
                    }
                    else
                    {
                        normalmouse.Checked = false;
                        mp_normalmouse.Checked = false;
                    }
                        
                   
                }

                //Check High Power Plan
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    //"CommandLine", "Lobby NormalMouse"
                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "HighPower", null) == "true")
                    {
                        highpower.Checked = true;
                        
                    }
                    else
                    {
                        highpower.Checked = false;
                    }


                }

                //Check Clean Restore Games
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "GameRestore", null) == "true")
                    {
                        gamerestores.Checked = true;

                    }
                    else
                    {
                        gamerestores.Checked = false;
                    }


                }

                //Check Disable Themes
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Themes", null) == "true")
                    {
                        themes.Checked = true;

                    }
                    else
                    {
                        themes.Checked = false;
                    }


                }

                //Check SuperFetch
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "SuperFetch", null) == "true")
                    {
                        superfetch.Checked = true;

                    }
                    else
                    {
                        superfetch.Checked = false;
                    }


                }

                //Check SuperFetch
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Indexing", null) == "true")
                    {
                        prefetch.Checked = true;

                    }
                    else
                    {
                        prefetch.Checked = false;
                    }


                }

                //Check Visual Effects
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "VisualEffects", null) == "true")
                    {
                        visualeffects.Checked = true;

                    }
                    else
                    {
                        visualeffects.Checked = false;
                    }


                }

                //Check Visual Effects
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "DisableHA", null) == "true")
                    {
                        hacceleration.Checked = true;

                    }
                    else
                    {
                        hacceleration.Checked = false;
                    }


                }
                //Check Performance Profile
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "PerfProfile", null) == "default")
                    {
                        defaultprofile.Checked = true;

                    }
                    else if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "PerfProfile", null) == "high")
                    {
                        highprofile.Checked = true;
                    }
                    else if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "PerfProfile", null) == "ultra")
                    {
                        ultraprofile.Checked = true;
                    }
                    else if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "PerfProfile", null) == "custom")
                    {
                        customizedprofile.Checked = true;
                    }

                }

                //Check MarkC
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "MarkC", null) == null)
                    {
                        

                    }
                    else if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "MarkC", null) == "true")
                    {
                        mp_markc.Checked = true;
                    }
                    else if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "MarkC", null) == "false")
                    {
                        mp_markc.Checked = false;
                    }
                  

                }
                //Check Full Screen Optimization
                using (RegistryKey cur8 = Registry.LocalMachine.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Fsoptimization", null) == null)
                    {
                        fsoptimization.Checked = false;

                    }
                    else if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Fsoptimization", null) == "true")
                    {
                        fsoptimization.Checked = true;
                    }
                    else if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Fsoptimization", null) == "false")
                    {
                        fsoptimization.Checked = false;
                    }


                }
            }
            return 1;
        }
        private void kryptonRadioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void balancepower_CheckedChanged(object sender, EventArgs e)
        {
            if (balancepower.Checked == true && balancepower.Focus())
            {
                Task<int> PowerTask = PowerFunc("0");
                int result = await PowerTask;
                if (result == 1)
                {
                    //Enable Options
                    powersaving.Enabled = true;
                    balancepower.Enabled = true;
                    highperformance.Enabled = true;
                    validity.Visible = true;
                    validity.BackgroundImage = Game_Tweaker.Properties.Resources.check1;
                    await Task.Delay(1500);
                    validity.Visible = false;
                }
            }
        }

        private async void powersaving_CheckedChanged(object sender, EventArgs e)
        {
            if (powersaving.Checked == true && powersaving.Focus())
            {
                Task<int> PowerTask = PowerFunc("1");
                int result = await PowerTask;
                if (result == 1)
                {
                    //Enable Options
                    powersaving.Enabled = true;
                    balancepower.Enabled = true;
                    highperformance.Enabled = true;
                    validity.Visible = true;
                    validity.BackgroundImage = Game_Tweaker.Properties.Resources.check1;
                    await Task.Delay(1500);
                    validity.Visible = false;
                }
            }

        }
        public async Task<int> PowerFunc(string num) // assume we return an int from this long running operation 
        {
            //Disable Options First
            powersaving.Enabled = false;
            balancepower.Enabled = false;
            highperformance.Enabled = false;

            await Task.Run(() =>
            {
                using (RegistryKey bpower = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\DirectX\UserGpuPreferences", true))
                {
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\DirectX\UserGpuPreferences", mskdpath.Text, null) != null)
                    {
                        bpower.SetValue(mskdpath.Text, @"GpuPreference=" + num + @";");
                    }
                }
            });
            return 1;
        }

        private async void highperformance_CheckedChanged(object sender, EventArgs e)
        {
            if (highperformance.Checked == true && highperformance.Focus())
            {
                Task<int> PowerTask = PowerFunc("2");
                int result = await PowerTask;
                if (result == 1)
                {
                    //Enable Options
                    powersaving.Enabled = true;
                    balancepower.Enabled = true;
                    highperformance.Enabled = true;
                    validity.Visible = true;
                    validity.BackgroundImage = Game_Tweaker.Properties.Resources.check1;
                    await Task.Delay(1500);
                    validity.Visible = false;
                }
            }
        }

        private void custompath_CheckedChanged(object sender, EventArgs e)
        {
            if (custompath.Checked == true && custompath.Focus())
            {
                agepath.Enabled = true;
                savepath.Enabled = true;
            }
            else if (custompath.Checked == false && custompath.Focus())
            {
                agepath.Enabled = false;
                savepath.Enabled = false;
            }
        }

        private void hacceleration_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            //toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw); 
            //toolTip1.Draw += new DrawToolTipEventHandler(OnDraw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.BackColor = Color.LightPink;
            toolTip1.SetToolTip(this.hacceleration, "It disables/enables Windows Hardware Acceleration");

        }
        ToolTip toolTip1 = new ToolTip();

        void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            toolTip1.IsBalloon = true;
            DrawToolTipEventArgs newArgs = new DrawToolTipEventArgs(e.Graphics,
             e.AssociatedWindow, e.AssociatedControl, e.Bounds, e.ToolTipText,
             this.BackColor, this.ForeColor, new Font(e.Font, FontStyle.Bold));
            newArgs.DrawBackground();
            newArgs.DrawBorder();
            newArgs.DrawText(TextFormatFlags.TextBoxControl);
            this.toolTip1.BackColor = Color.LightPink;
        }
        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            toolTip1.IsBalloon = true;
            DrawToolTipEventArgs newArgs = new DrawToolTipEventArgs(e.Graphics,
                e.AssociatedWindow, e.AssociatedControl, e.Bounds, e.ToolTipText,
                this.BackColor, this.ForeColor, new Font(e.Font, FontStyle.Bold));
            newArgs.DrawBackground();

            newArgs.DrawBorder();

            newArgs.DrawText(TextFormatFlags.TextBoxControl);
        }
        private void highpower_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            //toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.highpower, @"It activates High Performance Power Plan for your computer (Increased gaming performance but may use more energy.)");
        }

        private void fsoptimization_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            //toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.fsoptimization, @"It disables/enables full screen optimization for age of empires 2 resulting in a slight fps increase and less mouse input lag for some computers.");
        }

        private void gamerestores_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.gamerestores, @"It only cleans old restore games that may be taking unnecessary disk space or potentially slowing down voobly/multiplayer.");
        }

        private void normalmouse_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            toolTip1.IsBalloon = true;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;


            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.normalmouse, @"It enables/disables the mouse cursor of age of empires 2 and uses a regular windows cursor" + Environment.NewLine + @" (Significant improvement to mouse movement and probably eliminates mouse input lag.)");
            //toolTip1.Draw += new DrawToolTipEventHandler(OnDraw);
        }

        private void themes_CheckedChanged(object sender, EventArgs e)
        {
            if (themes.Checked == true && themes.Focus())
            {
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + "sc stop \"Themes\" & sc config \"Themes\" start=disabled";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                myProcess.WaitForExit();
                myProcess.Close();
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("Themes", "true", RegistryValueKind.String);
                }
            }
            else if (themes.Checked == false && themes.Focus())
            {
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + "sc config \"Themes\" start=auto & sc start \"Themes\"";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                myProcess.WaitForExit();
                myProcess.Close();
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("Themes", "false", RegistryValueKind.String);
                }
            }
        }

        private void themes_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.themes, @"It disables/enables windows themes and switch to classic theme for higher ingame performance.");
        }

        private void superfetch_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.superfetch, @"It stops/starts Superfetch service. It's recommended to stop or disable this service as it is most likely slowing your pc down.");
        }

        private void prefetch_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.prefetch, @"It disables Search indexing that causes 100% disk usage. Highly Recommended to disable!");
        }

        private void visualeffects_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.visualeffects, @"It disables/enables Windows Visual Effects. We recommend you to disable it as It could be a direct cause to mouse input lag.");
        }

        private void kryptonLabel1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.mp_MAlbl, @"It disables/enables mouse acceleration. We highly recommend to turn on this feature to get a full control over your mouse movements.");
        }

        private void kryptonLabel3_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.kryptonLabel3, @"It install/uninstalls MarkC mouse fix in compliance with your current DPI display." + Environment.NewLine + @" We highly recommend to turn on this feature to achieve a very accurate 1-1 mouse movements.");
        }

        private void kryptonLabel2_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.kryptonLabel2, @"It enables/disables a normal windows cursor for age of empires 2." + Environment.NewLine + @" Turn  it on if you have mouse input lag. Also a potential FPS boost.");
        }

        private void kryptonLabel4_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.kryptonLabel4, @"It disables/enables GameDVR for Xbox." + Environment.NewLine + @" Turn it on if you don't have Xbox to eliminate mouse input lag.");
        }
        public async Task<int> exportRegistry(string strKey, string filepath)
        {
            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo.FileName = "reg.exe";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.Arguments = "export \"" + strKey + "\" \"" + filepath + "\" /y";
                    proc.Start();
                    string stdout = proc.StandardOutput.ReadToEnd();
                    string stderr = proc.StandardError.ReadToEnd();
                    proc.WaitForExit();
                }
                return 1;
            }
            catch (Exception ex)
            {
                // handle exception
                return 0;
            }
        }

        public async Task<int> importRegistry(string filepath)
        {
            try
            {
                Process regeditProcess = Process.Start("regedit.exe", "/s " + "\"" + filepath + "\"");
                regeditProcess.WaitForExit();
                regeditProcess.Close();
                return 1;
            }
            catch (Exception ex)
            {
                // handle exception
                return 0;
            }
        }

        private async void kryptonRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (kryptonRadioButton1.Checked == true && kryptonRadioButton1.Focus())
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"data\curbak.reg"))
                {
                    Task<int> ImpRegistry = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\curbak.reg");
                    int resultimp = await ImpRegistry;
                    if (resultimp == 1)
                    {

                    }
                    SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                }

            }
        }

        public async Task<int> CurParser(string AppStarting, string Arrow, string Help, string IBeam, string No, string Crosshair, string Wait, string Hand)
        {
            try
            {
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Control Panel\Cursors", true))
                {
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\Cursors", "Arrow", null) != null)
                    {
                        // 8 keys
                        if (AppStarting != "")
                            cur.SetValue("AppStarting", AppStarting);
                        if (Arrow != "")
                            cur.SetValue("Arrow", Arrow);
                        if (Crosshair != "")
                            cur.SetValue("Crosshair", Crosshair);
                        if (Help != "")
                            cur.SetValue("Help", Help);
                        if (IBeam != "")
                            cur.SetValue("IBeam", IBeam);
                        if (No != "")
                            cur.SetValue("No", No);
                        if (Wait != "")
                            cur.SetValue("Wait", Wait);
                        if (Hand != "")
                            cur.SetValue("Hand", Hand);
                    }
                }
                return 1;
            }
            catch (Exception ex)
            {
                // handle exception
                return 0;
            }
        }

        private async void AoE2Cursor_CheckedChanged(object sender, EventArgs e)
        {
            if (AoE2Cursor.Checked == true && AoE2Cursor.Focus())
            {
                //CurParser(string AppStarting, string Arrow, string Help, string IBeam, string No, string Crosshair, string Wait, string Hand)

                Task<int> ImpRegistry = CurParser(
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\aoe2\Wait.cur",  // AppStarting
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\aoe2\Cursor.cur", // Arrow
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\aoe2\Help.cur", // Help
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\aoe2\beam_i.cur", // IBeam
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\aoe2\Unavailable.cur", // No
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\aoe2\Precision 1.cur", // Crosshair
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\aoe2\Hourglass.cur", // Wait
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\aoe2\Hand.cur"  // Hand
                    );
                int resultimp = await ImpRegistry;
                if (resultimp == 1)
                {

                }
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }

        private async void Sc2T_CheckedChanged(object sender, EventArgs e)
        {
            if (Sc2T.Checked == true && Sc2T.Focus())
            {
                //CurParser(string AppStarting, string Arrow, string Help, string IBeam, string No, string Crosshair, string Wait, string Hand)

                Task<int> ImpRegistry = CurParser(
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2t\SC2-cursor-busy.ani",  // AppStarting
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2t\SC2-cursor.cur", // Arrow
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2t\SC2-helpsel.cur", // Help
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2t\SC2-ibeam.cur", // IBeam
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2t\cursor-target-invalid.cur", // No
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2t\cursor-target-none.cur", // Crosshair
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2t\SC2-cursor-busy.ani", // Wait
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2t\cursor-grip-open.cur"  // Hand
                    );
                int resultimp = await ImpRegistry;
                if (resultimp == 1)
                {

                }
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }

        private async void Sc2P_CheckedChanged(object sender, EventArgs e)
        {
            if (Sc2P.Checked == true && Sc2P.Focus())
            {
                //CurParser(string AppStarting, string Arrow, string Help, string IBeam, string No, string Crosshair, string Wait, string Hand)

                Task<int> ImpRegistry = CurParser(
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2p\SC2-cursor-busy-protoss.cur",  // AppStarting*
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2p\SC2-cursor-protoss.cur", // Arrow*
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2p\SC2-helpsel-protoss.cur", // Help*
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2p\SC2-ibeam.cur", // IBeam*
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2p\cursor-target-invalid.cur", // No*
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2p\cursor-select-allied.cur", // Crosshair*
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2p\SC2-cursor-busy-protoss.cur", // Wait*
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2p\cursor-grip-open.cur"  // Hand*
                    );
                int resultimp = await ImpRegistry;
                if (resultimp == 1)
                {

                }
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }

        private async void Sc2Z_CheckedChanged(object sender, EventArgs e)
        {
            if (Sc2Z.Checked == true && Sc2Z.Focus())
            {
                //CurParser(string AppStarting, string Arrow, string Help, string IBeam, string No, string Crosshair, string Wait, string Hand)

                Task<int> ImpRegistry = CurParser(
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2z\SC2-cursor-busy-zerg.cur",  // AppStarting**
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2z\SC2-cursor-zerg.cur", // Arrow**
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2z\SC2-helpsel-zerg.cur", // Help**
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2z\SC2-ibeam.cur", // IBeam**
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2z\cursor-target-invalid.cur", // No**
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2z\cursor-select-enemy.cur", // Crosshair**
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2z\SC2-cursor-busy-zerg.cur", // Wait**
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\sc2z\cursor-grip-open.cur"  // Hand**
                    );
                int resultimp = await ImpRegistry;
                if (resultimp == 1)
                {

                }
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }

        }

        private async void Spear_CheckedChanged(object sender, EventArgs e)
        {
            if (Spear.Checked == true && Spear.Focus())
            {
                //CurParser(string AppStarting, string Arrow, string Help, string IBeam, string No, string Crosshair, string Wait, string Hand)

                Task<int> ImpRegistry = CurParser(
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\spear\wait_r.cur",  // AppStarting***
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\spear\spear-cursor.cur", // Arrow***
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\spear\Embossed-Help.ani", // Help***
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\spear\beam_r.cur", // IBeam***
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\spear\aero_unavail.cur", // No***
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\spear\cross_rm.cur", // Crosshair***
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\spear\busy_i.cur", // Wait***
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\spear\Hand.cur"  // Hand***
                    );
                int resultimp = await ImpRegistry;
                if (resultimp == 1)
                {

                }
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }

        private async void Minecraft_CheckedChanged(object sender, EventArgs e)
        {
            if (Minecraft.Checked == true && Minecraft.Focus())
            {
                //CurParser(string AppStarting, string Arrow, string Help, string IBeam, string No, string Crosshair, string Wait, string Hand)

                Task<int> ImpRegistry = CurParser(
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\mc\Arrow-waiting.ani",  // AppStarting****
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\mc\Arrow.cur", // Arrow****
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\mc\help.cur", // Help****
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\mc\beam_r.cur", // IBeam****
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\mc\no.ani", // No****
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\mc\crosshair.cur", // Crosshair****
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\mc\busy.ani", // Wait****
                    AppDomain.CurrentDomain.BaseDirectory + @"data\cursors\mc\hand.cur"  // Hand****
                    );
                int resultimp = await ImpRegistry;
                if (resultimp == 1)
                {

                }
                SystemParametersInfo(SPI_SETCURSORS, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }

        private void hacceleration_CheckedChanged(object sender, EventArgs e)
        {
            if (hacceleration.Checked == true && (hacceleration.Focus() || kryptonHeaderGroup2.Focus()))
        {
            //Disable windows hardware acceleration
            using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Avalon.Graphics\", true))
            {
                cur.SetValue("DisableHWAcceleration", "1",RegistryValueKind.DWord);
            }
            //Disable Voobly hardware acceleration
            using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\Voobly\Voobly\game\13", true))
            {
                cur.SetValue("disabledxhwaccel", "true", RegistryValueKind.String);   
            }

            using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                cur.SetValue("DisableHA", "true", RegistryValueKind.String);
            }
        }
            else if (hacceleration.Checked == false && (hacceleration.Focus() || kryptonHeaderGroup2.Focus()))
        {
            using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Avalon.Graphics\", true))
            {
                cur.SetValue("DisableHWAcceleration", "0", RegistryValueKind.DWord);
            }
            using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\Voobly\Voobly\game\13", true))
            {
                cur.SetValue("disabledxhwaccel", "false", RegistryValueKind.String);
            }
            using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                cur.SetValue("DisableHA", "false", RegistryValueKind.String);
            }
        }
        }

        private void highpower_CheckedChanged(object sender, EventArgs e)
        {
            if (highpower.Checked == true && (highpower.Focus() || kryptonHeaderGroup2.Focus()))
            {
              

Process myProcess = new Process();
myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
myProcess.StartInfo.CreateNoWindow = true;
myProcess.StartInfo.UseShellExecute = false;
myProcess.StartInfo.FileName = "cmd.exe";
myProcess.StartInfo.Arguments = "/c " + "powercfg.exe /setactive 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c";
myProcess.EnableRaisingEvents = true;
myProcess.Start();
myProcess.WaitForExit();
myProcess.Close();
using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
{

    cur.SetValue("HighPower", "true", RegistryValueKind.String);
}

            }
            else if (highpower.Checked == false && (highpower.Focus() || kryptonHeaderGroup2.Focus()))
            {
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + "powercfg.exe /setactive 381b4222-f694-41f0-9685-ff5bb260df2e";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                myProcess.WaitForExit();
                myProcess.Close();
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("HighPower", "false", RegistryValueKind.String);
                }
            }
        }

        private void fsoptimization_CheckedChanged(object sender, EventArgs e)
        {
            if (fsoptimization.Checked == true && (fsoptimization.Focus() || kryptonHeaderGroup2.Focus()))
            {
                using (RegistryKey cur = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers", true))
                {
                    if(agepath.Text == mskdpath.Text)
                    cur.SetValue(mskdpath.Text, @"~ DISABLEDXMAXIMIZEDWINDOWEDMODE RUNASADMIN HIGHDPIAWARE", RegistryValueKind.String);

                    if(agepath.Text != mskdpath.Text)
                    {
                        cur.SetValue(agepath.Text, @"~ DISABLEDXMAXIMIZEDWINDOWEDMODE RUNASADMIN HIGHDPIAWARE", RegistryValueKind.String);
                    }
                        
                }
            }
            else if (fsoptimization.Checked == false && (fsoptimization.Focus() || kryptonHeaderGroup2.Focus()))
            {
                using (RegistryKey cur = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers", true))
                {

                    if (agepath.Text != mskdpath.Text && agepath.Text.EndsWith(".exe"))
                        cur.SetValue(agepath.Text, @"~ RUNASADMIN HIGHDPIAWARE", RegistryValueKind.String);
                    else
                        cur.SetValue(mskdpath.Text, @"~ RUNASADMIN HIGHDPIAWARE", RegistryValueKind.String);

                }
            }
        }

        private void gamerestores_CheckedChanged(object sender, EventArgs e)
        {
            if (gamerestores.Checked == true && (gamerestores.Focus() || kryptonHeaderGroup2.Focus()))
            {
                if (Directory.Exists(mskdpath2.Text + "\\SaveGame\\Multi\\"))
                    RemoveDirectories(mskdpath2.Text + "\\SaveGame\\Multi\\", "AoE2 Restores");

                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("GameRestore", "true", RegistryValueKind.String);
                }
            }
            else if (gamerestores.Checked == false && (gamerestores.Focus() || kryptonHeaderGroup2.Focus()))
            {
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("GameRestore", "false", RegistryValueKind.String);
                }
            }
        }

        private void normalmouse_CheckedChanged(object sender, EventArgs e)
        {
            if (normalmouse.Checked == true && (normalmouse.Focus() || kryptonHeaderGroup2.Focus()))
            {
                //Enabling NormalMouse
                //x64 systems
                using (RegistryKey cur = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {

                    cur.SetValue("CommandLine", "Lobby NormalMouse", RegistryValueKind.String);
                }

                using (RegistryKey cur2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II The Conquerors Expansion", true))
                {

                    cur2.SetValue("CommandLine", "Lobby NormalMouse", RegistryValueKind.String);
                }
                //x86 systems
                using (RegistryKey cur3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {

                    cur3.SetValue("CommandLine", "Lobby NormalMouse", RegistryValueKind.String);
                }

                using (RegistryKey cur4 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II The Conquerors Expansion", true))
                {

                    cur4.SetValue("CommandLine", "Lobby NormalMouse", RegistryValueKind.String);
                }
                //disabling 1.5rc custom mouse which undoes normalmouse
                using (RegistryKey cur4 = Registry.CurrentUser.OpenSubKey(@"HKEY_CURRENT_USER\Software\Voobly\Voobly\game\13\v1.5 Beta R7", true))
                {

                    cur4.SetValue("Custom Normal Mouse", "false", RegistryValueKind.String);
                }
            }
            else if (normalmouse.Checked == false && (normalmouse.Focus() || kryptonHeaderGroup2.Focus()))
            {
                //Disabling NormalMouse
                //x64 systems
                using (RegistryKey cur = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {

                    cur.SetValue("CommandLine", "Lobby", RegistryValueKind.String);
                }

                using (RegistryKey cur2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II The Conquerors Expansion", true))
                {

                    cur2.SetValue("CommandLine", "Lobby", RegistryValueKind.String);
                }
                //x86 systems
                using (RegistryKey cur3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {

                    cur3.SetValue("CommandLine", "Lobby", RegistryValueKind.String);
                }

                using (RegistryKey cur4 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II The Conquerors Expansion", true))
                {

                    cur4.SetValue("CommandLine", "Lobby", RegistryValueKind.String);
                }
            }
        }

        private void superfetch_CheckedChanged(object sender, EventArgs e)
        {
            if (superfetch.Checked == true && (superfetch.Focus() || kryptonHeaderGroup2.Focus()))
            {
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + "sc stop \"SysMain\" & sc config \"SysMain\" start=disabled";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                myProcess.WaitForExit();
                myProcess.Close();
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("SuperFetch", "true", RegistryValueKind.String);
                }
            }
            else if (superfetch.Checked == false && (superfetch.Focus() || kryptonHeaderGroup2.Focus()))
            {
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + "sc config \"SysMain\" start=auto & sc start \"SysMain\"";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                myProcess.WaitForExit();
                myProcess.Close();
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("SuperFetch", "false", RegistryValueKind.String);
                }
            }
        }

        private void prefetch_CheckedChanged(object sender, EventArgs e)
        {
            if (prefetch.Checked == true && (prefetch.Focus() || kryptonHeaderGroup2.Focus()))
            {
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + "sc stop \"WSearch\" & sc config \"WSearch\" start=disabled";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                myProcess.WaitForExit();
                myProcess.Close();
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("Indexing", "true", RegistryValueKind.String);
                }
            }
            else if (prefetch.Checked == false && (prefetch.Focus() || kryptonHeaderGroup2.Focus()))
            {
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/c " + "sc config \"WSearch\" start=auto & sc start \"WSearch\"";
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                myProcess.WaitForExit();
                myProcess.Close();
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("Indexing", "false", RegistryValueKind.String);
                }
            }
        }

        private void visualeffects_CheckedChanged(object sender, EventArgs e)
        {
            if (visualeffects.Checked == true && (visualeffects.Focus() || kryptonHeaderGroup2.Focus()))
            {
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", true))
                {
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", null) != null)
                    {

                        cur.SetValue("VisualFXSetting", "3");


                    }
                }
                //Disabling all effects but font smoothing and thumbail icons
                //enable font smoothing
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                {
                    cur.SetValue("FontSmoothing", "2", RegistryValueKind.String);
                    cur.SetValue("FontSmoothingType", 2, RegistryValueKind.DWord);
                   
                }
                //enable thumbnail icons
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced", true))
                {
                    cur.SetValue("IconsOnly", 0, RegistryValueKind.DWord);

                }
                //end

                //send changes
                const uint SPI_SETUIEFFECTS = 0x103F;
                const uint SPIF_SENDCHANGE = 0x02;
                SystemParametersInfo(SPI_SETUIEFFECTS, 0, false, SPIF_SENDCHANGE);
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("VisualEffects", "true", RegistryValueKind.String);
                }
            }
            else if (visualeffects.Checked == false && (visualeffects.Focus() || kryptonHeaderGroup2.Focus()))
            {
                //Enable Best Appearance Plan
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", true))
                {
                    if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects", "VisualFXSetting", null) != null)
                    {

                        cur.SetValue("VisualFXSetting", "1");


                    }
                }
               
                //send changes
                const uint SPI_SETUIEFFECTS = 0x103F;
                const uint SPIF_SENDCHANGE = 0x02;
                SystemParametersInfo(SPI_SETUIEFFECTS, 0, false, SPIF_SENDCHANGE);
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("VisualEffects", "false", RegistryValueKind.String);
                }
            }
        }

        private void custompath_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            //toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.fsoptimization, @"You can add a custom game path to any exe file of any game.");
        }

        private void savepath_Click(object sender, EventArgs e)
        {
            if(agepath.Text.EndsWith(".exe"))
            {
                using (RegistryKey rk1 = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    
                        string mygamepath = rk1.GetValue("GamePP").ToString();
                        agepath.Text = mygamepath + @"\age2_x1\age2_x1.exe";
                        rk1.SetValue("GamePP", mygamepath + @"\age2_x1\age2_x1.exe");
                }
            }
            else
            {
                KryptonMessageBox.Show("The Game path must be an .exe file!","Wrong EXE Path!");
            }
        }

        private void mp_normalmouse_Click(object sender, EventArgs e)
        {
            if (mp_normalmouse.Checked == true && (mp_normalmouse.Focus() || kryptonHeaderGroup2.Focus()))
            {
                //Enabling NormalMouse
                //x64 systems
                using (RegistryKey cur = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {

                    cur.SetValue("CommandLine", "Lobby NormalMouse", RegistryValueKind.String);
                }

                using (RegistryKey cur2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II The Conquerors Expansion", true))
                {

                    cur2.SetValue("CommandLine", "Lobby NormalMouse", RegistryValueKind.String);
                }
                //x86 systems
                using (RegistryKey cur3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {

                    cur3.SetValue("CommandLine", "Lobby NormalMouse", RegistryValueKind.String);
                }

                using (RegistryKey cur4 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II The Conquerors Expansion", true))
                {

                    cur4.SetValue("CommandLine", "Lobby NormalMouse", RegistryValueKind.String);
                }
                //disabling 1.5rc custom mouse which undoes normalmouse
                using (RegistryKey cur4 = Registry.CurrentUser.OpenSubKey(@"HKEY_CURRENT_USER\Software\Voobly\Voobly\game\13\v1.5 Beta R7", true))
                {

                    cur4.SetValue("Custom Normal Mouse", "false", RegistryValueKind.String);
                }
            }
            else if (mp_normalmouse.Checked == false && (mp_normalmouse.Focus() || kryptonHeaderGroup2.Focus()))
            {
                //Disabling NormalMouse
                //x64 systems
                using (RegistryKey cur = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {

                    cur.SetValue("CommandLine", "Lobby", RegistryValueKind.String);
                }

                using (RegistryKey cur2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II The Conquerors Expansion", true))
                {

                    cur2.SetValue("CommandLine", "Lobby", RegistryValueKind.String);
                }
                //x86 systems
                using (RegistryKey cur3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion", true))
                {

                    cur3.SetValue("CommandLine", "Lobby", RegistryValueKind.String);
                }

                using (RegistryKey cur4 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II The Conquerors Expansion", true))
                {

                    cur4.SetValue("CommandLine", "Lobby", RegistryValueKind.String);
                }
            }
        }

        private void mp_mouseacc_Click(object sender, EventArgs e)
        {
            if(mp_mouseacc.Checked == true && (mp_mouseacc.Focus() || kryptonHeaderGroup2.Focus()))
            {
                ToggleEnhancePointerPrecision(false);
                //using (RegistryKey cur3 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Mouse", true))
                //{

                //    cur3.SetValue("MouseThreshold1", "0", RegistryValueKind.String);
                //    cur3.SetValue("MouseThreshold2", "0", RegistryValueKind.String);
                //}
               //const UInt32 SPI_GETMOUSE = 0x0003;
               //const UInt32 SPI_SETMOUSE = 0x0004;
               //int[] mouseParams = new int[3];
               //SystemParametersInfoSet(SPI_SETMOUSE, 0, GCHandle.Alloc(mouseParams, GCHandleType.Pinned).AddrOfPinnedObject(), SPIF.SPIF_SENDCHANGE);
               //SystemParametersInfoSet(SPI_GETMOUSE, 0, GCHandle.Alloc(mouseParams, GCHandleType.Pinned).AddrOfPinnedObject(), SPIF.SPIF_SENDCHANGE);

            }
            else if (mp_mouseacc.Checked == false && (mp_mouseacc.Focus() || kryptonHeaderGroup2.Focus()))
            {
                ToggleEnhancePointerPrecision(true);
    
            }
        }

        public static bool ToggleEnhancePointerPrecision(bool b)
        {
            int[] mouseParams = new int[3];
            // Get the current values.
            SystemParametersInfoGet(SPI_GETMOUSE, 0, GCHandle.Alloc(mouseParams, GCHandleType.Pinned).AddrOfPinnedObject(), 0);
            // Modify the acceleration value as directed.
            mouseParams[2] = b ? 1 : 0;
            // Update the system setting.
            return SystemParametersInfoSet(SPI_SETMOUSE, 0, GCHandle.Alloc(mouseParams, GCHandleType.Pinned).AddrOfPinnedObject(), SPIF.SPIF_SENDCHANGE);
        }

        private void mp_gamedvr_Click(object sender, EventArgs e)
        {
            if(mp_gamedvr.Checked == true && (mp_gamedvr.Focus() || kryptonHeaderGroup2.Focus()))
            {
                //Disable GameDVR
                using (RegistryKey cur3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\GameDVR", true))
                {
                    
                        cur3.SetValue("AllowGameDVR", "0", RegistryValueKind.DWord);
                    
                }

                using (RegistryKey cur4 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\xboxgip", true))
                {
                    
                        cur4.SetValue("Start", "3", RegistryValueKind.DWord);
                   
                }

                using (RegistryKey cur7 = Registry.CurrentUser.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\xboxgip", true))
                {
                    
                        cur7.SetValue("GameDVR_Enabled", "0", RegistryValueKind.DWord);
                }
            }
            else if (mp_gamedvr.Checked == false && (mp_gamedvr.Focus() || kryptonHeaderGroup2.Focus()))
            {
                //Enable GameDVR
                using (RegistryKey cur3 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows\GameDVR", true))
                {

                    cur3.SetValue("AllowGameDVR", "1", RegistryValueKind.DWord);

                }

                using (RegistryKey cur4 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\xboxgip", true))
                {
                    
                        cur4.SetValue("Start", "4", RegistryValueKind.DWord);
                    
                }

                using (RegistryKey cur7 = Registry.CurrentUser.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\xboxgip", true))
                {

                    cur7.SetValue("GameDVR_Enabled", "1", RegistryValueKind.DWord);
                }
            }
        }

        private async void mp_markc_Click(object sender, EventArgs e)
        {
            if(mp_markc.Checked == true  && (mp_markc.Focus() || kryptonHeaderGroup2.Focus()))
            {
                using (RegistryKey winver = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", true))
                {
                    //Begin MarkC
                    try
                    {

                    if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", null) != null)
                    {
                        
                        string getver = winver.GetValue("ProductName").ToString();
                        if (getver.Contains("Windows 10"))
                        {
                            
                            using (RegistryKey fixten = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop\WindowMetrics", true))
                            {
                                
                                string GetPN = fixten.GetValue("AppliedDPI").ToString();
                                if (GetPN == "96")//Smaller 100% (default)
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=100_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for default scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 0, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 100% DPI", "MarkC Installed!");
                                    }
                                    
                                }
                                else if (GetPN == "120")//Medium 125%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=120_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 125% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "144") //Larger 150%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=150_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 150% DPI", "MarkC Installed!");
                                    }
                                }

                                else if (GetPN == "192")//Extra Large 200%
                                {
                                     Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=200_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        }KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 200% DPI", "MarkC Installed!");
                                    }
                                    
                                }
                                else if (GetPN == "240")//Custom 250%
                                {
                                     Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=250_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        }
                                    }KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 250% DPI", "MarkC Installed!");
                                    
                                }
                                else if (GetPN == "288")//Custom 300%
                                {
                                     Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=300_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        }KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 300% DPI", "MarkC Installed!");
                                    }
                                    
                                }
                                else if (GetPN == "384")//Custom 400%
                                {
                                     Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=400_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 400% DPI", "MarkC Installed!");
                                    }
                                   
                                }
                                else if (GetPN == "480")//Custom 500%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=500_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        }KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 500% DPI", "MarkC Installed!");
                                    }
                                    
                                }
                            }
                        //End Windows 10

                        }
                        else if (getver.Contains("Windows 8"))
                        {
                            //Begin Windows 8/8.1
                            using (RegistryKey fixten = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop\WindowMetrics", true))
                            using (RegistryKey fixten2 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop\LogPixels", true))
                            {

                                string GetPN = fixten.GetValue("AppliedDPI").ToString();
                                string GetPN2 = fixten2.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\VisualEffects",null).ToString();
                                if (GetPN == "96" || GetPN2 == "96")//Smaller 100% (default)
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=100_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for default scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 0, RegistryValueKind.DWord);
                                        }KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 100% DPI", "MarkC Installed!");
                                    }
                                    

                                }
                                else if (GetPN == "120" || GetPN2 == "120")//Medium 125%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=120_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        }
                                        KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 125% DPI", "MarkC Installed!");
                                    }
                                    
                                }
                                else if (GetPN == "144" || GetPN2 == "144") //Larger 150%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=150_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 150% DPI", "MarkC Installed!");
                                    }
                                }

                                else if (GetPN == "192" || GetPN2 == "192")//Extra Large 200%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=200_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 200% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "240" || GetPN2 == "240")//Custom 250%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=250_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 250% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "288" || GetPN2 == "288")//Custom 300%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=300_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 300% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "384" || GetPN2 == "384")//Custom 400%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=400_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 400% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "480" || GetPN2 == "480")//Custom 500%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=500_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 500% DPI", "MarkC Installed!");
                                    }
                                }
                            }
                        }
                        else if (getver.Contains("Windows 7"))
                        {
                            using (RegistryKey fixten = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop\WindowMetrics", true))
                            {

                                string GetPN = fixten.GetValue("AppliedDPI").ToString();
                                if (GetPN == "96")//Smaller 100% (default)
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=100_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for default scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 0, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 100% DPI", "MarkC Installed!");
                                    }

                                }
                                else if (GetPN == "120")//Medium 125%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=120_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 125% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "144") //Larger 150%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=150_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 150% DPI", "MarkC Installed!");
                                    }
                                }

                                else if (GetPN == "192")//Extra Large 200%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=200_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 200% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "240")//Custom 250%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=250_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 250% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "288")//Custom 300%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=300_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 300% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "384")//Custom 400%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=400_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 400% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "480")//Custom 500%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=500_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 500% DPI", "MarkC Installed!");
                                    }
                                }
                            }
                        }
                        else if (getver.Contains("Windows Vista"))
                        {
                            using (RegistryKey fixten = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop\WindowMetrics", true))
                            {

                                string GetPN = fixten.GetValue("AppliedDPI").ToString();
                                if (GetPN == "96")//Smaller 100% (default)
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=100_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for default scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 0, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 100% DPI", "MarkC Installed!");
                                    }

                                }
                                else if (GetPN == "120")//Medium 125%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=120_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 125% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "144") //Larger 150%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=150_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 150% DPI", "MarkC Installed!");
                                    }
                                }

                                else if (GetPN == "192")//Extra Large 200%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=200_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 200% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "240")//Custom 250%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=250_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 250% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "288")//Custom 300%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=300_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 300% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "384")//Custom 400%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=400_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 400% DPI", "MarkC Installed!");
                                    }
                                }
                                else if (GetPN == "480")//Custom 500%
                                {
                                    Task<int> Impdefdpi = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Windows 10 Fixes\Windows_10+8.x_MouseFix_ItemsSize=500_Scale=1-to-1_at6-of-11.reg");
                                    int resultimp = await Impdefdpi;
                                    if (resultimp == 1)
                                    {
                                        //set win8dpi for custom scaling value
                                        using (RegistryKey dpiwin8 = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
                                        {
                                            dpiwin8.SetValue("Win8DpiScaling", 1, RegistryValueKind.DWord);
                                        } KryptonMessageBox.Show("MarkC Successfully Installed! " + getver + " 500% DPI", "MarkC Installed!");
                                    }
                                }
                            }
                        }
                    }
                    using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                    {

                        cur.SetValue("MarkC", "true", RegistryValueKind.String);
                    }
                }
                    catch(Exception ex)
                    {
                        KryptonMessageBox.Show(ex.ToString());
                    }
                    //End MarkC
                }
            }
            else if(mp_markc.Checked == false  && (mp_markc.Focus() || kryptonHeaderGroup2.Focus()))
            {
                using (RegistryKey winver = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", true))
                {

                    if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", null) != null)
                    {

                        string getver = winver.GetValue("ProductName").ToString();
                        if (getver.Contains("Windows Vista") || getver.Contains("Windows XP") || getver.Contains("Windows 7"))
                        {
                            Task<int> windef = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Default\Windows_7+Vista+XP_Default.reg");
                            int defresult = await windef;
                        }
                        else if (getver.Contains("Windows 8") || getver.Contains("Windows 10"))
                        {
                            Task<int> windef = importRegistry(AppDomain.CurrentDomain.BaseDirectory + @"data\markc\Default\Windows_10+8.x_Default.reg");
                            int defresult = await windef;
                        }
                    }
                }
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("Markc", "false", RegistryValueKind.String);
                }
            }

        }

        private void defaultprofile_CheckedChanged(object sender, EventArgs e)
        {
            if(defaultprofile.Focused)
            {
                hacceleration.Checked = false;
                hacceleration.Enabled = false;
                highpower.Checked = false;
                highpower.Enabled = false;
                fsoptimization.Checked = false;
                fsoptimization.Enabled = false;
                gamerestores.Checked = false;
                gamerestores.Enabled = false;
                normalmouse.Checked = false;
                normalmouse.Enabled = false;
                themes.Checked = false;
                themes.Enabled = false;
                superfetch.Checked = false;
                superfetch.Enabled = false;
                prefetch.Checked = false;
                prefetch.Enabled = false;
                visualeffects.Checked = false;
                visualeffects.Enabled = false;
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("PerfProfile", "default", RegistryValueKind.String);
                }
            }
        }

        private void highprofile_CheckedChanged(object sender, EventArgs e)
        { 
            hacceleration.Enabled = false;highpower.Enabled = false;
            fsoptimization.Enabled = false;gamerestores.Enabled = false;normalmouse.Enabled = false;
            themes.Enabled = false;superfetch.Enabled = false;prefetch.Enabled = false;visualeffects.Enabled = false;
            if (highprofile.Focused)
            {
                hacceleration.Checked = false;
               

                highpower.Checked = true;
                

                fsoptimization.Checked = false;

                gamerestores_CheckedChanged(gamerestores, null);
                gamerestores.Checked = true;
                

                normalmouse.Checked = false;
                

                themes.Checked = false;
                

                superfetch.Checked = true;
                

                prefetch.Checked = true;
                

                visualeffects.Checked = false;
                

                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("PerfProfile", "high", RegistryValueKind.String);
                }
            }
        }

        private void ultraprofile_CheckedChanged(object sender, EventArgs e)
        {
hacceleration.Enabled = false;highpower.Enabled = false;fsoptimization.Enabled = false;
 gamerestores.Enabled = false; normalmouse.Enabled = false; themes.Enabled = false;
superfetch.Enabled = false;prefetch.Enabled = false;visualeffects.Enabled = false;

            if (ultraprofile.Focused)
            {
                // 10/10
                hacceleration.Checked = true;
                

                highpower.Checked = true;
                

                fsoptimization.Checked = true;
                

                gamerestores.Checked = true;
               

                normalmouse.Checked = true;
               

                themes.Checked = true;
               

                superfetch.Checked = true;
                

                prefetch.Checked = true;
                

                visualeffects.Checked = true;
                
                //disable DVR
                mp_gamedvr.Checked = true;
                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("PerfProfile", "ultra", RegistryValueKind.String);
                }
            }
        }

        private void customizedprofile_CheckedChanged(object sender, EventArgs e)
        {
            if (customizedprofile.Focused)
            {
                
                hacceleration.Enabled = true;

               
                highpower.Enabled = true;

           
                fsoptimization.Enabled = true;


                gamerestores.Enabled = true;


                normalmouse.Enabled = true;


                themes.Enabled = true;

               
                superfetch.Enabled = true;

              
                prefetch.Enabled = true;

              
                visualeffects.Enabled = true;

                using (RegistryKey cur = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {

                    cur.SetValue("PerfProfile", "custom", RegistryValueKind.String);
                }
            }
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonDockableNavigator1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (kryptonDockableNavigator1.SelectedPage == kryptonPage3)
            {
                // Create a DriveInfo instance of the C:\ drive
                DriveInfo dDrive = new DriveInfo("C");

                // When the drive is accessible..
                if (dDrive.IsReady)
                {
                    
                    
                    Int64 bytreq = 2L * 1024 * 1024 * 1024; //2GB into bytes
                    if (dDrive.AvailableFreeSpace > bytreq)
                    {
                        diskspace.Text = "Good! Your Free Disk Space is : " + FormatBytes(dDrive.AvailableFreeSpace);
                        diskimg.Image = Game_Tweaker.Properties.Resources.valid;
                    }
                    else if (dDrive.AvailableFreeSpace < bytreq)
                    {
                        diskspace.Text = "Your Free Disk Space is Low! " + FormatBytes(dDrive.AvailableFreeSpace);
                        diskimg.Image = Game_Tweaker.Properties.Resources.error;
                    }
                }
                VooblyMods();
                AvastAvg();
                
            }
        }
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }
        private long GetTotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.TotalFreeSpace;
                    
                    
                }
            }
            return -1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.IsBalloon = true;
            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 200;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = System.Drawing.Color.Yellow;
            toolTip1.ForeColor = System.Drawing.Color.Black;
            //toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw); 
            //toolTip1.Draw += new DrawToolTipEventHandler(OnDraw);
            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.BackColor = Color.LightPink;
            toolTip1.SetToolTip(this.helpvoobly, "If you got more than 8 voobly mods.. Consider disabling/removing the ones you don't need. Or you can use Voobly Mods Manager (avaible at AoE2Tools) to install some of your voobly mods as offline.");
        }
        void VooblyMods()
        {
           
            if(Directory.Exists(mskdpath2.Text + @"\Voobly Mods\AOC\Local Mods"))
            {
                
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(mskdpath2.Text + @"\Voobly Mods\AOC\Local Mods");
                System.IO.DirectoryInfo[] dirInfos = di.GetDirectories("*.*");
               
                int getcount = 0;
                foreach (System.IO.DirectoryInfo d in dirInfos)
                {
                    getcount++;
                    int totalcount = getcount;
                    vooblylbl.Text = "Good! Voobly mods count is less than 8: (" + totalcount.ToString() + " )";
                    vooblyimg.Image = Game_Tweaker.Properties.Resources.valid;
                    if(totalcount > 8)
                    {
                        vooblyimg.Image = Game_Tweaker.Properties.Resources.error;
                        vooblylbl.Text = "Voobly mods count exceeds 8: (" + totalcount.ToString() + " )";
                    }
                }
            }
            
        }
        void AvastAvg()
        {
            Process[] avastsrv = Process.GetProcessesByName("AvastSvc");
            Process[] avastui = Process.GetProcessesByName("AvastUI");
            Process[] avgui = Process.GetProcessesByName("avgui");
            Process[] avgwdsvc = Process.GetProcessesByName("avgwdsvc");
            Process[] avgidsagent = Process.GetProcessesByName("avgidsagent");
            if (avastsrv.Length == 0 || avastui.Length == 0 || avgui.Length == 0 || avgwdsvc.Length == 0 || avgidsagent.Length == 0)
            { avlbl.Text = "Good! No Antivirus 'CPU hog' found!"; avimg.Image = Game_Tweaker.Properties.Resources.valid; }
                
            else
            { avlbl.Text = "Avast/AVG is probably slowing you down!"; avimg.Image = Game_Tweaker.Properties.Resources.error; }
        }
        private void voobcheck_Click(object sender, EventArgs e)
        {
            VooblyMods();
        }

        private void avhelp_MouseHover(object sender, EventArgs e)
        {
            if(avimg.Image == Game_Tweaker.Properties.Resources.error)
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.IsBalloon = true;
                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 10000;
                toolTip1.InitialDelay = 100;
                toolTip1.ReshowDelay = 200;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;
                toolTip1.OwnerDraw = true;
                toolTip1.BackColor = System.Drawing.Color.Yellow;
                toolTip1.ForeColor = System.Drawing.Color.Black;
                //toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw); 
                //toolTip1.Draw += new DrawToolTipEventHandler(OnDraw);
                // Set up the ToolTip text for the Button and Checkbox.
                toolTip1.BackColor = Color.LightPink;
                toolTip1.SetToolTip(this.avhelp, "Avast/AVG may impact your computer heavily. However if you Go to \"Settings\" - \"Troubleshooting\" - remove checkmark at \"Enable hardware-assisted virtualization\" - reboot PC. Disabling that should fix the 5 seconds delay when you start multiplayer game on voobly. Though I would encourage you to use \"Kaspersky Free Antivirus\" instead for better gaming performance and experience.");
            }
            else
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.IsBalloon = true;
                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 10000;
                toolTip1.InitialDelay = 100;
                toolTip1.ReshowDelay = 200;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;
                toolTip1.OwnerDraw = true;
                toolTip1.BackColor = System.Drawing.Color.Yellow;
                toolTip1.ForeColor = System.Drawing.Color.Black;
                //toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw); 
                //toolTip1.Draw += new DrawToolTipEventHandler(OnDraw);
                // Set up the ToolTip text for the Button and Checkbox.
                toolTip1.BackColor = Color.LightPink;
                toolTip1.SetToolTip(this.avhelp, "No Antivirus issues!.");
            }
            
        }

        private void avcheckagain_Click(object sender, EventArgs e)
        {
            AvastAvg();
        }

        private void diskcheckag_Click(object sender, EventArgs e)
        {
            // Create a DriveInfo instance of the C:\ drive
            DriveInfo dDrive = new DriveInfo("C");

            // When the drive is accessible..
            if (dDrive.IsReady)
            {


                Int64 bytreq = 2L * 1024 * 1024 * 1024; //2GB into bytes
                if (dDrive.AvailableFreeSpace > bytreq)
                {
                    diskspace.Text = "Good! Your Free Disk Space is : " + FormatBytes(dDrive.AvailableFreeSpace);
                    diskimg.Image = Game_Tweaker.Properties.Resources.valid;
                }
                else if (dDrive.AvailableFreeSpace < bytreq)
                {
                    diskspace.Text = "Bad! Your Free Disk Space is Low! " + FormatBytes(dDrive.AvailableFreeSpace);
                    diskimg.Image = Game_Tweaker.Properties.Resources.error;
                }
            }
        }
        private void RemoveDirectories(string strpath, string name)
        {
            progressBar1.Visible = true;
            ThreadPool.QueueUserWorkItem((o) =>
            {
                if (Directory.Exists(strpath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(strpath);
                    var files = dirInfo.GetFiles();
                    //var pcount = ConvertKilobytesToMegabytes(GetDirectorySize(strpath)).ToString("0.00");
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
                        this.BeginInvoke(new Action(() => progressBar1.PerformStep())); 
                    }
                    //string createresult = "CleanUp Success! \n (X)" + name + "Cleaned: " + Environment.NewLine;

                    //File.AppendAllText("res.tmp", createresult);
                }
            }, null);
            progressBar1.Visible = false;
        }
        private void openmods_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(mskdpath2.Text + @"\Voobly Mods\AOC\Local Mods"))
            {
                try
                {
                    Process.Start(mskdpath2.Text + @"\Voobly Mods\AOC\Local Mods");
                }
                catch(SystemException)
                { 
                }
            }
        }
       
    }
}

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
using System.Diagnostics;
using System.Net;
using NATUPNPLib;
using System.Net.Sockets;
using Microsoft.Win32;

namespace WindowsFormsApplication3
{
    public partial class DrVoobly : KryptonForm
    {
        public string VooblyNat = "16000";
        public bool ErrorClean = true;
        public DrVoobly()
        {
            InitializeComponent();
        }

        private void DrVoobly_Load(object sender, EventArgs e)
        {
        
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Voobly\Voobly", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\Voobly\Voobly", "NATPort", null) != null)
                {
                    string natport = key.GetValue("NATPort").ToString();
                    VooblyNat = natport;
                    portlbl.Text = VooblyNat + " (UDP)";
                    portlbl.Enabled = true;
                }
                else
                {
                    portlbl.Text = "Voobly Not Installed!";
                }
            }
            try
            {
                NATUPNPLib.UPnPNATClass upnpnat = new NATUPNPLib.UPnPNATClass();
                NATUPNPLib.IStaticPortMappingCollection mappings = upnpnat.StaticPortMappingCollection;
                foreach (NATUPNPLib.IStaticPortMapping portMapping in mappings)
                {

                    if (portMapping.Description.ToString() == "Voobly-" + Environment.MachineName.ToString() && portMapping.InternalClient.ToString() == GetLocalIPAddress() && portMapping.InternalPort.ToString() == VooblyNat)
                    {
                        fixport.Visible = false;
                        checkport.Visible = true;
                    }

                }
            }
            catch(SystemException)
            {

            }
             

        }

        private void kryptonSeparator1_SplitterMoved(object sender, SplitterEventArgs e)
        {

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
        private void fixport_Click(object sender, EventArgs e)
        {
            UPnPNATClass upnpnat = new NATUPNPLib.UPnPNATClass();
            IStaticPortMappingCollection mappings = upnpnat.StaticPortMappingCollection;
            
            try
            {
                
                mappings.Add(Convert.ToInt32(VooblyNat), "UDP", Convert.ToInt32(VooblyNat), GetLocalIPAddress(), true, "Voobly-" + Environment.MachineName.ToString());
                ErrorClean = true;
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                ErrorClean = true;
                MessageBox.Show("Already Port Forwarded!");
            }
                catch(SystemException)
            {
                ErrorClean = false;
                MessageBox.Show("Please Enable UPnP In Your Router! Then Try Again. \n If UPnP is Already Enabled That means that this functionality is broken in your router.");
            }
            finally
            {
                if(ErrorClean == true)
                {
                    checkport.Visible = true;
                    fixport.Visible = false;
                }
                
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

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            //Resolutions
            if (VDOC.SelectedItem.ToString() == @"Set Game Resolution To 1920x1080")
            {
                Task<int> restask = ResolutionFix(1920, 1080);
                int moderes = await restask;
            }
            else if (VDOC.SelectedItem.ToString() == @"Set Game Resolution To 1920x1200")
            {
                Task<int> restask = ResolutionFix(1920, 1200);
                int moderes = await restask;
            }
            else if (VDOC.SelectedItem.ToString() == @"Set Game Resolution To 1680x1080")
            {
                Task<int> restask = ResolutionFix(1680, 1080);
                int moderes = await restask;
            }
            else if (VDOC.SelectedItem.ToString() == @"Set Game Resolution To 1680x1050")
            {
                Task<int> restask = ResolutionFix(1680, 1050);
                int moderes = await restask;
            }
            else if (VDOC.SelectedItem.ToString() == @"Set Game Resolution To 1600x900")
            {
                Task<int> restask = ResolutionFix(1600, 900);
                int moderes = await restask;
            }
            else if (VDOC.SelectedItem.ToString() == @"Set Game Resolution To 1400x1050")
            {
                Task<int> restask = ResolutionFix(1400, 1050);
                int moderes = await restask;
            }
            else if (VDOC.SelectedItem.ToString() == @"Set Game Resolution To 1440x900")
            {
                Task<int> restask = ResolutionFix(1400, 900);
                int moderes = await restask;
            }
            else if (VDOC.SelectedItem.ToString() == @"Set Game Resolution To 1280x1024")
            {
                Task<int> restask = ResolutionFix(1280, 1024);
                int moderes = await restask;
            }
            else if (VDOC.SelectedItem.ToString() == @"Auto Set Game Resolution To Desktop's")
            {
                string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
                string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
                Task<int> restask = ResolutionFix(Convert.ToInt32(screenWidth), Convert.ToInt32(screenHeight));
                int moderes = await restask;
                KryptonMessageBox.Show("Game Resolution is set to " + screenWidth + "x" + screenHeight);
            }
            //Voobly Issues
            else if (VDOC.SelectedItem.ToString() == @"Fix Voobly Messenger Chat Window")
            {

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
                {
                    key.SetValue("CChatDialogMaximized", "false", RegistryValueKind.String);
                    key.SetValue("CChatDialogPosX", 0, RegistryValueKind.DWord);
                    key.SetValue("CChatDialogPosY", 0, RegistryValueKind.DWord);
                }
                KryptonMessageBox.Show("Voobly Chat Window Fixed! Please Restart Voobly For The Changes To Take Effect.");
            }
            else if (VDOC.SelectedItem.ToString() == @"Voobly Game Room - Enable Wololokingdoms Mod")
            {

                //Set WK MOd
                Microsoft.Win32.RegistryKey rkey13;
                rkey13 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\482");
                rkey13.SetValue("gamemod", "WololoKingdoms");
                rkey13.Close();

                Microsoft.Win32.RegistryKey rkey14;
                rkey14 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\251");
                rkey14.SetValue("gamemod", "WololoKingdoms");
                rkey14.Close();

                Microsoft.Win32.RegistryKey rkey15;
                rkey15 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\64");
                rkey15.SetValue("gamemod", "WololoKingdoms");
                rkey15.Close();

                KryptonMessageBox.Show("Wololokingdoms Mod is successfully checked!");
            }
            else if (VDOC.SelectedItem.ToString() == @"Clear Voobly Game Room Title & Description")
            {

                //Set WK MOd
                Microsoft.Win32.RegistryKey rkey13;
                rkey13 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\482");
                rkey13.SetValue("description", "");
                rkey13.SetValue("title", "");
                rkey13.Close();

                Microsoft.Win32.RegistryKey rkey14;
                rkey14 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\251");
                rkey14.SetValue("description", "");
                rkey13.SetValue("title", "");
                rkey14.Close();

                Microsoft.Win32.RegistryKey rkey15;
                rkey15 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\64");
                rkey15.SetValue("description", "");
                rkey13.SetValue("title", "");
                rkey15.Close();

                KryptonMessageBox.Show("Voobly Game Room Title & Description are successfully cleared!");
            }
            else if (VDOC.SelectedItem.ToString() == @"Voobly Game Room Settings")
            {
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
                rkey8.Close();

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
                rkey9.Close();

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
                rkey10.SetValue("gamepatch", "v1.5 RC");
                rkey10.SetValue("ladderid", 83, RegistryValueKind.DWord);
                rkey10.SetValue("players", 90, RegistryValueKind.DWord);
                rkey10.SetValue("hiddencivs", "false");
                rkey10.SetValue("spectateJoinAs", "false");
                rkey10.SetValue("spectateUsersCanToggle", "true");
                rkey10.SetValue("spectateLateJoin", "true");
                rkey10.SetValue("spectatorNoGameRoomChat", "false");
                rkey10.SetValue("spectateServerAlwaysOn", "false");
                rkey10.Close();

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
                rkey11.SetValue("gamepatch", "v1.5 RC");
                rkey11.SetValue("ladderid", 83, RegistryValueKind.DWord);
                rkey11.SetValue("players", 90, RegistryValueKind.DWord);
                rkey11.SetValue("hiddencivs", "false");
                rkey11.SetValue("spectateJoinAs", "false");
                rkey11.SetValue("spectateUsersCanToggle", "true");
                rkey11.SetValue("spectateLateJoin", "true");
                rkey11.SetValue("spectatorNoGameRoomChat", "false");
                rkey11.SetValue("spectateServerAlwaysOn", "false");
                rkey11.Close();

                Microsoft.Win32.RegistryKey rkey12;
                rkey12 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13\v1.5 RC");
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
                rkey12.Close();

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
                rkey13.SetValue("gamepatch", "v1.5 RC");
                rkey13.SetValue("ladderid", 83, RegistryValueKind.DWord);
                rkey13.SetValue("players", 90, RegistryValueKind.DWord);
                rkey13.SetValue("hiddencivs", "false");
                rkey13.SetValue("spectateJoinAs", "false");
                rkey13.SetValue("spectateUsersCanToggle", "true");
                rkey13.SetValue("spectateLateJoin", "true");
                rkey13.SetValue("spectatorNoGameRoomChat", "false");
                rkey13.SetValue("spectateServerAlwaysOn", "false");
                rkey13.Close();

                KryptonMessageBox.Show("Voobly Game Room Settings successfully applied for all lobbies!");
            }
            else if (VDOC.SelectedItem.ToString() == @"Enable Advanced Command Buttons")
            {

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0", true))
                {
                    key.SetValue("Advanced Buttons", 1, RegistryValueKind.DWord);
                }

                KryptonMessageBox.Show("Advanced Command Buttons are successfully enabled!");
            }
            else if (VDOC.SelectedItem.ToString() == @"Fix Couldn't Display Or DirectDraw Display Error")
            {

                FixDirectDraw fixdd = new FixDirectDraw();
                fixdd.ShowDialog();
            }
            else
            {
                KryptonMessageBox.Show("Please Choose a Valid Selection.");
            }
            
            
        }
    }
}

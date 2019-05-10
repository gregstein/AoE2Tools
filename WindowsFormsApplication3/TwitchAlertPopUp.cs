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
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
namespace WindowsFormsApplication3
{
    public partial class TwitchAlertPopUp : KryptonForm
    {
        public TwitchAlertPopUp()
        {
            InitializeComponent();
        }
        public string GetStreamer { get; set; }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        private const UInt32 BOTTOM_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private async void TwitchAlertPopUp_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
            //VlcLoc();
            //PlaceLowerRight();
            //base.OnLoad(e);
            Task.Run(() => RetrieveStreamer());
        }
        private void PlaceLowerRight()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                const int margin = 10;
                int x = Screen.PrimaryScreen.WorkingArea.Right -
                    this.Width - margin;
                int y = Screen.PrimaryScreen.WorkingArea.Bottom -
                    this.Height - margin;
                this.Location = new Point(x, y);
            });
       
            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            EditStream edstrm = new EditStream();
            edstrm.GetStream = this.GetStreamer;
            edstrm.ShowDialog();
        }
        public async void RetrieveStreamer()
        {
            await Task.Run(() => VlcLoc());
            try
            {
                WebClient wk = new WebClient();
                wk.Headers.Add("user-agent", "AoE2Tools");
                wk.Encoding = System.Text.Encoding.UTF8;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
                var _strwk = wk.DownloadString("https://api.twitch.tv/kraken/streams/" + this.GetStreamer + "?client_id=ayaqtxd0bsfnj7w2iiryp8tnjpdqtg");
                var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);

                pictureBox1.ImageLocation = (string)jObject["stream"]["preview"]["medium"];
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                BeginInvoke((MethodInvoker)delegate
                {

                    this.Text = (string)jObject["stream"]["channel"]["display_name"] + " is Live!";
                    this.Update();
                    descstrm.Text = (string)jObject["stream"]["channel"]["status"];
                    twurl.Text = (string)jObject["stream"]["channel"]["url"];
                    tlstream.Text = this.GetStreamer;
                    kryptonButton4.Enabled = true;

                });
            }
            catch(SystemException)
            {

            }
            
          
        }

        private void vlcbtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\vlc\lua\playlist"))
            { Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\vlc\lua\playlist"); }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\vlc\lua\playlist\twitch.lua"))
            { File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\twitch.lua", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\vlc\lua\playlist\twitch.lua"); }
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + "\"" + vlcpath.Text + "\\vlc.exe\" " + twurl.Text;
            process.StartInfo = startInfo;
            process.Start();


        }
        public async void VlcLoc()
        {
            await Task.Run(() => PlaceLowerRight());
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\VideoLAN\VLC"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("InstallDir");
                        if (o != null)
                        {

                            string version = (string)key.GetValue("InstallDir");  //"as" because it's REG_SZ...otherwise ToString() might be safe(r)
                            if (File.Exists(version + @"\vlc.exe"))
                            {
                                vlcpath.Text = version;
                            }
                            //do what you like with version

                            else if (!File.Exists(version + @"\vlc.exe"))
                            {
                                MessageBox.Show("Please Download & Install VLC First!", "VLC Missing!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Download & Install VLC First!", "VLC Missing!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }
            this.Close();
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void tableLayoutPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(twurl.Text);
            }
            catch (SystemException)
            {
                
            }
           
        }
        private void switchlang()
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Transl", null) != null)
                {
                    string translatestr = rk.GetValue("Transl").ToString();
                    if (translatestr == "en")
                    {
                        cul = CultureInfo.CreateSpecificCulture("en");
                    }
                    else if (translatestr == "fr")
                    {
                        cul = CultureInfo.CreateSpecificCulture("fr");
                    }
                    else if (translatestr == "es")
                    {
                        cul = CultureInfo.CreateSpecificCulture("es");
                    }
                    else if (translatestr == "zh-cn")
                    {
                        cul = CultureInfo.CreateSpecificCulture("zh-cn");
                    }

                }
                else
                {
                    cul = CultureInfo.CreateSpecificCulture("en");
                }
            }
            BeginInvoke((MethodInvoker)delegate
            {


                vlcbtn.Text = res_man.GetString("_watchvlc", cul);
                kryptonButton3.Text = res_man.GetString("_watchweb", cul);
                kryptonButton1.Text = res_man.GetString("_edit", cul);
                kryptonButton4.Text = res_man.GetString("_recentclose", cul);
                tlstream.Text = res_man.GetString("_twitchloading", cul);
                descstrm.Text = res_man.GetString("_twitchloading", cul);


            });
        }
    }
}

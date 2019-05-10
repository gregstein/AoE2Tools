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
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
namespace WindowsFormsApplication3
{
    public partial class TwitchStreams : KryptonForm
    {
        public TwitchStreams()
        {
            InitializeComponent();
            
        }

        TableLayoutPanel paneltab = new TableLayoutPanel();
        FlowLayoutPanel paneltab2 = new FlowLayoutPanel();
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        private async void TwitchStreams_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
           await Task.Run(() => VlcLoc());
            bool result = await CheckForInternetConnection();
            if (result == true)
            {
                await Task.Run(() => TwitchS());
                //TwitchS(); 
                //Task.Run(() => TwitchS());
                //await Task.Run(() => TwitchS());
                var _strwk = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\twtv.tmp");
                //File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\twtv.tmp");
                //Thread.Sleep(5000);
                var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
                int streamtotal = JToken.Parse(_strwk)["streams"].ToList().Count;

                GenerateTable(2, streamtotal);
            }
            else
            {
                label1.Text = "Internet is Offline";
            }
           


        }
        public static async Task<bool> CheckForInternetConnection()
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
        public void VlcLoc()
        {
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
                            MessageBox.Show("Please Download & Install VLC First!","VLC Missing!");
                        }
                    }
                }
            }
            catch (Exception ex)  
            {
                
            }
        }
        public void TwitchS()
        {
            //await Task.Run(() => InitializeComponent());
            
            //SetAllowUnsafeHeaderParsing20();
            //Get wololokingdom latest repo

            try
            {
                WebClient wk = new WebClient();
                wk.Headers.Add("user-agent", "tesft");
                wk.Encoding = System.Text.Encoding.UTF8;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
                var _strwk = wk.DownloadString("https://api.twitch.tv/kraken/streams/?game=Age%20of%20Empires%20II&client_id=ayaqtxd0bsfnj7w2iiryp8tnjpdqtg");
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\twtv.tmp", _strwk);
            }
            catch(System.Net.WebException)
            {

            }

            //var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
            //int gout = 0;
            //int streamtotal = JToken.Parse(_strwk)["streams"].ToList().Count;
            
        }
        private void GenerateTable(int columnCount, int rowCount)
        {
            //await Task.Run(() => TwitchS());
            //try
            //{
            refreshlist.Enabled = false;
            
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //Clear out the existing controls, we are generating a new table layout
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.AutoScroll = false;
            //Clear out the existing row and column styles
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            //Now we will generate the table, setting up the row and column counts first
            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;
            var _strwk = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\twtv.tmp");
            
            //Thread.Sleep(5000);
            var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
            int gout = 0;

            //int _cntstreams = (res.snippet as JObject).Count;
            int toll = JToken.Parse(_strwk)["streams"].ToList().Count;
            
            for (int x = 0; x < columnCount; x++)
            {
                //First add a column
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                tableLayoutPanel1.AutoScroll = false;
                //SetAllowUnsafeHeaderParsing20();
                ////Get wololokingdom latest repo
                //WebClient wk = new WebClient();
                //wk.Headers.Add("user-agent", "AoE2Tools");
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;



                for (int y = 0; y < toll; y++)
                {

                    gout++;
                   
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x % 2 == 0)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        PictureBox img = new PictureBox();
                        img.Dock = DockStyle.Fill;
                        img.SizeMode = PictureBoxSizeMode.StretchImage;
                        img.Width = 150;
                        img.ImageLocation = string.Format((string)jObject["streams"][y]["preview"]["medium"], x, y);         
                        tableLayoutPanel1.Controls.Add(img, x, y);
                    }
                    if (x % 2 != 0)
                    {
                        
                        FlowLayoutPanel flwpnl = new FlowLayoutPanel();
                        FlowLayoutPanel tbltop = new FlowLayoutPanel();
                        TableLayoutPanel tblmid = new TableLayoutPanel();
                        FlowLayoutPanel tblbotz = new FlowLayoutPanel();
                        //flwpnl.FlowDirection = FlowDirection.LeftToRight;
                        flwpnl.Width = 200;
                        flwpnl.FlowDirection = FlowDirection.LeftToRight;
                        flwpnl.AutoScroll = false;
                        tbltop.AutoScroll = false;
    

                        KryptonButton btnvlc = new KryptonButton();
                        btnvlc.ButtonStyle = ButtonStyle.LowProfile;
                        btnvlc.Values.Image = WindowsFormsApplication3.Properties.Resources.vlc_logo;
                        btnvlc.Text = "(VLC)";
                        tbltop.Controls.Add(btnvlc);
                        btnvlc.AutoSize = true;
                        string twitchurl = (string)jObject["streams"][y]["channel"]["url"];
                        btnvlc.Click += (sender, e) =>
    {
        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\vlc\lua\playlist"))
        { Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\vlc\lua\playlist"); }

        if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\vlc\lua\playlist\twitch.lua"))
        { File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\twitch.lua", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\vlc\lua\playlist\twitch.lua"); }
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "/C " + "\"" + vlcpath.Text + "\\vlc.exe\" " + twitchurl;
        process.StartInfo = startInfo;
        process.Start();

    };

                        KryptonButton btnweb = new KryptonButton();
                        btnweb.ButtonStyle = ButtonStyle.LowProfile;
                        btnweb.Values.Image = WindowsFormsApplication3.Properties.Resources.twitchlogo;
                        btnweb.AutoSize = true;
                        btnweb.Text = "(WEB)";
                        tbltop.Controls.Add(btnweb);
                        btnweb.Click += (sender, e) =>
                        {
                            try
                            {
                                Process.Start(twitchurl);
                            }
                            catch(SystemException)
                            {

                            }
                            
                        };



                        Label cmd = new Label();
                        cmd.Text = string.Format((string)jObject["streams"][y]["channel"]["display_name"], x, y);         //Finally, add the control to the correct location in the table                   
                        flwpnl.Controls.Add(cmd);
                        cmd.Font = new Font("Tahoma", 10, FontStyle.Bold);
                        cmd.AutoSize = true;

                        KryptonButton btnbell = new KryptonButton();
                        btnbell.ButtonStyle = ButtonStyle.LowProfile;
                        btnbell.Values.Image = WindowsFormsApplication3.Properties.Resources.bell;
                        btnbell.AutoSize = true;
                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + cmd.Text + ".txt"))
                        {
                            btnbell.Enabled = false;
                        }
                        btnbell.Text = "FAV";
                        tbltop.Controls.Add(btnbell);
                        btnbell.Click += (sender, e) =>
                        {
                            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\"))
                            {
                                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\");
                            }
                            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + cmd.Text + ".txt", cmd.Text + System.Environment.NewLine + "True");
                            btnbell.Enabled = false;

                        };

                        Label _sstatus = new Label();
                        _sstatus.Font = new Font("Tahoma", 8);
                        _sstatus.AutoSize = true;
                        _sstatus.Text = (string)jObject["streams"][y]["channel"]["status"];         //Finally, add the control to the correct location in the table
                        flwpnl.Controls.Add(_sstatus);

                        Label cmd3 = new Label();
                        cmd3.Font = new Font("Tahoma", 7, FontStyle.Bold);
                        cmd3.AutoSize = true;
                        cmd3.Text = string.Format("Live Viewers: " + (string)jObject["streams"][y]["viewers"], x, y);         //Finally, add the control to the correct location in the table
                        flwpnl.Controls.Add(cmd3);

                        tableLayoutPanel1.Controls.Add(flwpnl, x, y);
                        flwpnl.Controls.Add(tbltop);
                        
                        //flwpnl.Controls.Add(tblbotz);
                    }

                    if (y > toll)
                    {
                        break;
                    }
                     

                }
            }
            refreshlist.Enabled = true;
            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\twtv.tmp");
            //    }
            //catch (System.FormatException gh)
            //{ throw gh; }

        }
        void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as Button).Name);
        }
        public static bool SetAllowUnsafeHeaderParsing20()
        {
            //Get the assembly that contains the internal class
            Assembly aNetAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section",
                      BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });

                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
                        FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int got = 0;

            paneltab.RowCount = paneltab.RowCount + 1;
            paneltab.ColumnCount = paneltab.ColumnCount + 1;
            //paneltab.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            //paneltab2.ColumnCount = paneltab2.ColumnCount;
            //paneltab2.RowCount = paneltab2.RowCount;
            int pos1 = paneltab.RowCount - 1;
            //paneltab.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            paneltab.Controls.Add(new PictureBox() { ImageLocation = "https://oujdaportail.net/ma/wp-content/uploads/cache/aref-oujda33232322-6m5owd946e5mnj3q3hvl9kof0404xqzaomi7ctvhqqs.jpg", Size = new System.Drawing.Size(140, 140) }, 0, paneltab.RowCount - 1);

            paneltab2.Controls.Add(new Label() { Text = "Stream Title" });
            paneltab2.Controls.Add(new TextBox() { Text = "Stream DescriptionStream DescriptionStream DescriptionStream DescriptionStream DescriptionStream DescriptionStream DescriptionStream Description", ReadOnly = true, Multiline = true, ScrollBars = ScrollBars.Both, MinimumSize = new System.Drawing.Size(160, 60) });
            paneltab2.Controls.Add(new Label() { Text = "Buttons" });
            

        }

        private void lbl_Reload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private async void refreshlist_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() => TwitchS());
                //await Task.Run(() => TwitchS());
                var _strwk = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\twtv.tmp");
                //Thread.Sleep(5000);
                var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
                int streamtotal = JToken.Parse(_strwk)["streams"].ToList().Count;
                GenerateTable(2, streamtotal);
            }
            catch(SystemException)
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


                lbl_LiveTwitcher.Text = res_man.GetString("_twitchlivestreams", cul);
                label1.Text = res_man.GetString("_twitchloading", cul);
                refreshlist.Text = res_man.GetString("_twitchrefresh", cul);
                TwitchStreams.ActiveForm.Text = res_man.GetString("_twitchtitle", cul);


            });
        }
    }
}

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
using Steamworks;
using Microsoft.Win32;
namespace WindowsFormsApplication3
{
    public partial class Form2 : KryptonForm
    {
        public Form2()
        {
            InitializeComponent();
        }
        private string saveDirectoryPath = "";
        public async Task<int> SteamTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Enabled = true;
            timer1.Interval = 2000; // in miliseconds
            await Task.Delay(1000);
            timer1.Start();
            return 1;

        }
       
        public string SaveDirectoryPath()
        {
            if (this.saveDirectoryPath == "")
            {
                uint size = SteamApps.GetAppInstallDir((AppId_t)221380, out this.saveDirectoryPath, 500u);

                if (size <= 0)
                {

                }
                else
                {

                }
                
            }
            
            return this.saveDirectoryPath;
        }
        private async void Form2_Load(object sender, EventArgs e)
        {

            Task<int> Gametask = SteamTimer();
            int result = await Gametask;
            
        }
        private async void timer_Tick(object sender, EventArgs e)
        {
            if (!SteamAPI.Init())
            {
                if (SteamAPI.IsSteamRunning())
                {
                    labby.StateNormal.ShortText.Color1 = Color.DarkBlue;
                    labby.Text = "Seeking Age of Empires 2 ..";
                }
                else
                {
                    labby.StateNormal.ShortText.Color1 = Color.Gold;
                    await Task.Delay(200);
                    labby.Text = "Waiting Steam Login..";
                    await Task.Delay(100);
                    labby.StateNormal.ShortText.Color1 = Color.Maroon;
                }

                //SteamUtils.GetAppID();

            }
            else
            {

                labby.StateNormal.ShortText.Color1 = Color.ForestGreen;
                labby.Text = "Steam Running... Retrieving Path";
                await Task.Delay(1000);

                try
                {
                    Microsoft.Win32.RegistryKey key;
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\AoE2Tools");
                    key.SetValue("SteamPath", SaveDirectoryPath());
                    key.Close();
                    timer1.Stop();
                    SteamAPI.Shutdown();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("not connected to steam!");
                }
                
            }
        }
    }
}

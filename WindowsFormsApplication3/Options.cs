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
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Resources;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Runtime.InteropServices;
namespace WindowsFormsApplication3
{
    public partial class Options : KryptonForm
    {
        public Options()
        {
            InitializeComponent();
        }

        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;            // declare culture info
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [System.Runtime.InteropServices.Out] StringBuilder lpszPath, int nFolder, bool fCreate);
        const int CSIDL_COMMON_DESKTOPDIRECTORY = 0x19;
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        // needed so that Explorer windows get refreshed after the registry is updated
        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);
        public bool inteli = false;

        private async void Options_Load(object sender, EventArgs e)
        {
  
            res_man = new ResourceManager("WindowsFormsApplication3.langs.Res", typeof(Options).Assembly);
            await Task.Run(() => switchlang());
            //switchlang();
            
            //TwitchCnt();
            //Task.Run(() => TwitchCnt());
            //Task.Run(() => ReloadList());
            //CheckOptions();
            
            //ReloadList();
           
            
        }

        private void kryptonCheckButton1_Click(object sender, EventArgs e)
        {

        }

        private void addstartup_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                 if (addstartup.Checked)
                     rk.SetValue("AoE2Tools", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Launcher.exe");
            else
                rk.DeleteValue("AoE2Tools", false);
            }

              
        }

        private void kryptonCheckButton2_Click(object sender, EventArgs e)
        {

        }

         public void CheckOptions()
        {
             try
             {


            //await Task.Run(() => CheckOptions());
            //Startup
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "AoE2Tools", null) != null)
                    //string aoe2path = rk.GetValue("AoE2Tools").ToString();
                    addstartup.Checked = true;
                else
                    addstartup.Checked = false;
            }
            //Launcher
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Launcher", null) != null)
                {
                    string launchval = rk.GetValue("Launcher").ToString();
                    if (launchval == "1")
                        launcher.Checked = false;
                    else
                        launcher.Checked = true;
                }
                
         
                    
               
            }
             //alerts
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "DisableAlerts", null) != null)
                {
                    string launchval = rk.GetValue("DisableAlerts").ToString();
                    if (launchval == "1")
                        disalert.Checked = true;
                    else
                        disalert.Checked = false;
                }



            }
            //Language
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Transl", null) != null)
                {
                    string transrt = rk.GetValue("Transl").ToString();
                    if (transrt == "en")
                    {

BeginInvoke((MethodInvoker)delegate
{
    langswitch.Text = "English";
});
                    }
                        
                    else if (transrt == "es")
                    {

BeginInvoke((MethodInvoker)delegate
{
    langswitch.Text = "Español";
});
                    }

                    else if (transrt == "fr")
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            langswitch.Text = "Français";
                        });


                    }
                    else if (transrt == "zh-cn")
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            langswitch.Text = "Chinese";
                        });


                    }
                        
                }



            }

            //Alerts AoE2Tools
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Alerts", null) != null)
                {
                    string alerta = rk.GetValue("Alerts").ToString();
                    if (alerta == "true")
                    {

                        BeginInvoke((MethodInvoker)delegate
                        {
                            disalertstool.Checked = true;
                        });
                    }

                    else if (alerta == "false")
                    {

                        BeginInvoke((MethodInvoker)delegate
                        {
                            disalertstool.Checked = false;
                        });
                    }

  

                }



            }

            //WK Mod no Rec saves
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "WKMOD", null) != null)
                {
                    string alerta = rk.GetValue("WKMOD").ToString();
                    if (alerta == "true")
                    {

                        BeginInvoke((MethodInvoker)delegate
                        {
                            nowkdmod.Checked = false;
                        });
                    }

                    else if (alerta == "false")
                    {

                        BeginInvoke((MethodInvoker)delegate
                        {
                            nowkdmod.Checked = true;
                        });
                    }
                }
            }

             //twitch interval
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "Twitch Interval", null) != null)
                {
                    string twitchint = rk.GetValue("Twitch Interval").ToString();
                    if (twitchint == "10000")
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            kryptonComboBox1.Text = "10 Seconds";
                        });
                        
                    }
                    else if (twitchint == "20000")
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            kryptonComboBox1.Text = "20 Seconds";
                        });
                        
                    }
                    else if (twitchint == "30000")
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            kryptonComboBox1.Text = "30 Seconds";
                        });
                        
                    }
                    else if (twitchint == "60000")
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            kryptonComboBox1.Text = "1 Minute";
                        });
                        
                    }
                    else if (twitchint == "300000")
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            kryptonComboBox1.Text = "5 Minutes";
                        });
                        
                    }
                    else if (twitchint == "3600000")
                    {
                        BeginInvoke((MethodInvoker)delegate
                        {
                            kryptonComboBox1.Text = "1 Hour";
                        });
                        
                    }
                    else if (twitchint == "99999999")
                    {
                        BeginInvoke((MethodInvoker)delegate
                 {
                        kryptonComboBox1.Text = "Never (Disable)";
                 });
                    }
                       
                }
            }
             //Game Path
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                {
                    string transrt = rk.GetValue("AoE2Path").ToString();
                    

                        BeginInvoke((MethodInvoker)delegate
                        {
                            GamePath.Text = transrt;
                        });

                }

            }
             //Sounds Check
             if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\Pling.wav"))
             {
                 BeginInvoke((MethodInvoker)delegate
                 {

                     dissnd.Checked = false;

                 });
                 
             }
             else
             {
                 BeginInvoke((MethodInvoker)delegate
                 {

                     dissnd.Checked = true;

                 });
                 
             }
             }
             catch (System.InvalidOperationException)
             {

             }
             catch (SystemException)
             {

             }
             //ends here
        }

         private void launcher_Click(object sender, EventArgs e)
         {


         }

         private void launcher_CheckedChanged(object sender, EventArgs e)
         {
             using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
             {
                 if (launcher.Checked)
                     rk.SetValue("AoE2Tools", AppDomain.CurrentDomain.BaseDirectory + @"AoE2Tools.exe");
                 else
                     rk.SetValue("AoE2Tools", AppDomain.CurrentDomain.BaseDirectory + @"Launcher.exe");
             }
    
         }

         private void kryptonButton1_Click(object sender, EventArgs e)
         {
            // RegistryKey aoe2tools =
            //Registry.CurrentUser.CreateSubKey("Software\\AoE2Tools");
             DialogResult dialogResult = KryptonMessageBox.Show("Reset AoE2Tools?", "Confirmation", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {
                 launcher.Checked = false;
                 System.Threading.Thread.Sleep(1500);
                 try
                 {
                     Registry.CurrentUser.DeleteSubKeyTree("Software\\AoE2Tools");
                 }
                 catch (System.ArgumentException)
                 {

                 }
                 
                 //var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                 var exeName = AppDomain.CurrentDomain.BaseDirectory + @"Launcher.exe";
                 ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                 System.Diagnostics.Process.Start(startInfo);
                 Process.GetCurrentProcess().Kill();
             }
             else if (dialogResult == DialogResult.No)
             {
               
             }

         }

         private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
         {

         }

         private void lstcust_CheckedChanged(object sender, EventArgs e)
         {
             if(lstcust.Checked == true)
             {
                 btnaddstream.Enabled = true;
                 txbcustom.Enabled = true;
             }
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
         private void radiolst_CheckedChanged(object sender, EventArgs e)
         {
             //if (radiolst.Checked == true)
             //{
             //    btnaddstream.Enabled = true;
             //    cbstreams.Enabled = true;
             //}
         }
         async Task<bool> TwitchCnt()
         {
            
                 
                 try
                 {

                     
                     SetAllowUnsafeHeaderParsing20();

                     using(WebClient wk = new WebClient())
                     {
                         wk.Headers.Add("user-agent", "tesft");
                         wk.Encoding = System.Text.Encoding.UTF8;
                         ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                         ServicePointManager.Expect100Continue = false; ServicePointManager.MaxServicePointIdleTime = 0;
                         wk.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                         wk.DownloadStringAsync(new Uri("https://api.twitch.tv/kraken/streams/?game=Age%20of%20Empires%20II&client_id=ayaqtxd0bsfnj7w2iiryp8tnjpdqtg"));
                         //var _strwk = wk.DownloadString("https://api.twitch.tv/kraken/streams/?game=Age%20of%20Empires%20II&client_id=ayaqtxd0bsfnj7w2iiryp8tnjpdqtg");
                     }
                     return true;
                     
                 }
                 catch (SystemException)
                 {
                     return false;
                     //swallow error
                 }

    

             
  
         }
         async void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
         {
             try
                 {
             string text = e.Result;
             var _strwk = text;
             int _streamercnt = JToken.Parse(_strwk)["streams"].ToList().Count;
             //Regex yourRegex = new Regex(@"\(([^\}]+)\)");
             //string result = yourRegex.Replace(twitchstreamz.Text, "(" + _streamercnt.ToString() + ")");
             //txbcustom.Text = result; 
             var jObject = Newtonsoft.Json.Linq.JObject.Parse(_strwk);
             for (int cnt = 0; cnt < _streamercnt; cnt++)
             {
                 
                     // Invoke((MethodInvoker)delegate
                     //{
                     //    cbstreams.Items.Add((string)jObject["streams"][cnt]["channel"]["display_name"]);
                     //});
                     await Task.Run(() =>
                     {
                         IAsyncResult result = this.BeginInvoke((MethodInvoker)delegate()
                         {
                             cbstreams.Items.Add((string)jObject["streams"][cnt]["channel"]["display_name"]);
                         });

                         this.EndInvoke(result);

                     });
                      
                 }
                

                 BeginInvoke((MethodInvoker)delegate()
                 {
                 cbstreams.Enabled = true;
                 btnaddstream.Enabled = true;
                 });
   

             }

             catch (System.InvalidOperationException)
             {

             }
             catch (SystemException)
             {

             }
             // … do something with result
         }
         public async Task<bool> CheckChan()
         {
             try
             {
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://www.twitch.tv/" + txbcustom.Text);
             
                 HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                 if (response.StatusCode == HttpStatusCode.OK)
                 {
                     return true;
                 }

                 response.Close();
             }
             catch (WebException)
             {
                 return false;
             }
             catch (SystemException)
             {
                 return false;
             }

             return false;
            
         }
         private async void btnaddstream_Click(object sender, EventArgs e)
         {
             if(radiolst.Checked == true)
             {
                 if (cbstreams.Text != "Choose From Live Streams")
                 {
                     //add stream
                     if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\"))
                     {
                         Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\");
                     }
                     File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + cbstreams.Text + ".txt", cbstreams.Text + System.Environment.NewLine + playsound.Checked.ToString());
                     //ReloadList();
                     await Task.Run(() => ReloadList());
                     KryptonMessageBox.Show(cbstreams.Text + " is Added!", "Success!");
 
                 }
                 else
                 {
                     KryptonMessageBox.Show("Please choose any stream from the list!","No Stream Selected!");
                 }

             }
             else if (lstcust.Checked == true)
             {
                 //add stream
                 bool result = await CheckChan();
                 if (result == true)
                 {
                     //add stream
                     if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\"))
                     {
                         Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\");
                     }
                     File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + txbcustom.Text + ".txt", txbcustom.Text + System.Environment.NewLine + playsound.Checked.ToString());
                     //ReloadList();
                     await Task.Run(() => ReloadList());
                     KryptonMessageBox.Show(txbcustom.Text + " is Added!", "Success!"); 
                 }
                 else
                 {
                     KryptonMessageBox.Show("This Twitch Stream does not exist!", "Error Twitch Stream Name!"); 
                 }
             }
         }

         private async void kryptonDockableNavigator2_SelectedPageChanged(object sender, EventArgs e)
         {
             if (kryptonDockableNavigator2.SelectedPage == kryptonPage4)
             {

                 await Task.Run(() => ReloadList());
                 //ReloadList();
             }

             else if (kryptonDockableNavigator2.SelectedPage == kryptonPage5)
             {

                 await Task.Run(() => CheckOptions());
                
             }
         }
         private object CreateNewItem(string voobdir)
         {
             KryptonListItem item = new KryptonListItem();
             item.ShortText = voobdir;
             //item.LongText = "(" + _rand.Next(Int32.MaxValue).ToString() + ")";
             item.Image = imageList.Images[0];
             return item;
         }
         public async void ReloadList()
         {
             
                 //await Task.Run(() => TwitchCnt());
                 //modscount.Text = "0";
             BeginInvoke((MethodInvoker)delegate
             {
                 chkboxvoob.Items.Clear();
             });
                 //listing directories
                 if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\"))
                 {
                     Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\");
                 }
                 if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\"))
                 {
                     System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\");

                     System.IO.FileInfo[] dirInfos = di.GetFiles("*.txt");
                     if(dirInfos.Count() != 0)
                     {
                          //label1.Text = "Installed Visual Mods (Personal Taste)";
                     int getcount = 0;
                     foreach (System.IO.FileInfo d in dirInfos)
                     {
                         getcount++;
                         int totalcount = getcount;
                         //modscount.Text = totalcount.ToString();
                         //KryptonMessageBox.Show(d.Name, "");


             //            BeginInvoke((MethodInvoker)delegate
             //{
             //               chkboxvoob.Items.Add(CreateNewItem(d.Name.Replace(".txt", "")));
             //});


                         await Task.Run(() =>
                         {
                             IAsyncResult result = this.BeginInvoke((MethodInvoker)delegate()
                             {
                                 chkboxvoob.Items.Add(CreateNewItem(d.Name.Replace(".txt", "")));
                             });

                             this.EndInvoke(result);

                         });

                     }

                     await Task.Run(() =>
                     {
                         IAsyncResult result = this.BeginInvoke((MethodInvoker)delegate()
                         {
                             chkboxvoob.SelectedIndex = 0;
                         });

                         this.EndInvoke(result);

                     });
                     //BeginInvoke((MethodInvoker)delegate
                     //{
                     //       chkboxvoob.SelectedIndex = 0;
                     //});
                     }
                    
                     
                 }

             
          


         }

         private void kryptonDockableNavigator1_SelectedPageChanged(object sender, EventArgs e)
         {

         }

         private void editstream_Click(object sender, EventArgs e)
         {
             if (chkboxvoob.SelectedIndex >= 0)
             {
                 int cnt = 0;
                 foreach (var stm in chkboxvoob.SelectedItems)
                 {
                     cnt++;
                     if (cnt > 1)
                     {
                         break;
                     }
                     EditStream edstrm = new EditStream();
                     edstrm.GetStream = chkboxvoob.SelectedItem.ToString();
                     edstrm.ShowDialog();
                    
                 }
             }
         }

         private void delmod_Click(object sender, EventArgs e)
         {
             //delete streams
             if (chkboxvoob.SelectedIndex >= 0)
             {
                  var confirmResult = KryptonMessageBox.Show("Delete Selected Streams?",
                                        "Confirm Deletion!",
                                        MessageBoxButtons.YesNo);
                  if (confirmResult == DialogResult.Yes)
                  {
                      int cnt = 0;
  
                      foreach (var stm in chkboxvoob.CheckedItems)
                      {
                          cnt++;
                          
                          File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + stm + ".txt");



                      }
            
                      ReloadList();
                  }
                  else 
                  {

                  }

             }
         }

         private void selectvisual_CheckedChanged(object sender, EventArgs e)
         {
             if (selectvisual.Checked == true)
             {

                 for (int i = 0; i < chkboxvoob.Items.Count; i++)
                 {
                     chkboxvoob.SetItemChecked(i, true);
                 }
                     
                

             }
             else if (selectvisual.Checked == false)
             {

                 for (int i = 0; i < chkboxvoob.Items.Count; i++)
                 {
                     chkboxvoob.SetItemChecked(i, false);
                 }
             }
         }

         private void launcher_Click_1(object sender, EventArgs e)
         {

         }

         private void kryptonComboBox1_SelectedValueChanged(object sender, EventArgs e)
         {

             if (kryptonComboBox1.Text == "10 Seconds")   
                     {
                         using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                         {
                             

                                 rk.SetValue("Twitch Interval", "10000");
                             
                         }
                         File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "10000");
 //KryptonMessageBox.Show("10 Seconds is set!");
                 }


                 else if (kryptonComboBox1.Text == "20 Seconds")
                     {
                         using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                         {


                             rk.SetValue("Twitch Interval", "20000");

                         }
                         File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "20000");
 //KryptonMessageBox.Show("20 Seconds is set!");
                 }


             else if (kryptonComboBox1.Text == "30 Seconds")
                     {
                         using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                         {


                             rk.SetValue("Twitch Interval", "30000");

                         }
                         File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "30000");
 //KryptonMessageBox.Show("30 Seconds is set!");
                 }


                 else if (kryptonComboBox1.Text == "1 Minute")
                 {
                     using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                     {


                         rk.SetValue("Twitch Interval", "60000");

                     }
                     File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "60000");
//KryptonMessageBox.Show("1 Min is set!");
                 }


                 else if (kryptonComboBox1.Text == "5 Minutes")
                     {
                         using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                         {


                             rk.SetValue("Twitch Interval", "300000");

                         }
                         File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "300000");
  //KryptonMessageBox.Show("5 Min is set!");
                 }


                 else if (kryptonComboBox1.Text == "1 Hour")
                     {
                         using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                         {


                             rk.SetValue("Twitch Interval", "3600000");

                         }
                         File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "3600000");
//KryptonMessageBox.Show("5 min is set!");
                 }


                 else if (kryptonComboBox1.Text == "Never (Disable)")
                     {
                         using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("Software\\AoE2Tools", true))
                         {


                             rk.SetValue("Twitch Interval", "99999999");

                         }
                         File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\interv.tmp", "99999999");
//KryptonMessageBox.Show("Disabled!");
                 }
                     

             
         }

         private void chkboxvoob_SelectedIndexChanged(object sender, EventArgs e)
         {

             foreach (var stm in chkboxvoob.SelectedIndices)
             {
                 if (chkboxvoob.GetSelected(chkboxvoob.SelectedIndex) == true)
                 {
                     chkboxvoob.SetItemChecked(chkboxvoob.SelectedIndex, true);
                 }
                 else if (chkboxvoob.GetSelected(chkboxvoob.SelectedIndex) == false)
                 {
                     chkboxvoob.SetItemChecked(chkboxvoob.SelectedIndex, false);
                 }
                 

             }
    }

        private void chkboxvoob_SelectedValueChanged(object sender, EventArgs e)
        {

          
        }
     
        private void chkboxvoob_Click(object sender, EventArgs e)
        {
            
         
        }

        private void dissnd_CheckedChanged(object sender, EventArgs e)
        {
            if(dissnd.Checked == true)
            {
                try
                {
                    dissnd.Enabled = false;
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\Pling.wav"))
                    {
                        File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\Pling.wav", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\XPling.wav");
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\Pling.wav");
                        dissnd.Enabled = true;
                    }
                    
                    dissnd.Enabled = true;
                }
                catch(SystemException)
                {
                    
                }
            }
            else if (dissnd.Checked == false)
            {
                try
                {
                    dissnd.Enabled = false;
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\XPling.wav"))
                    {
                        File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\XPling.wav", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\Pling.wav");
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\data\snds\XPling.wav");
                        dissnd.Enabled = true;
                    }
                    
                    dissnd.Enabled = true;
                }
                catch (SystemException)
                {
                    
                }
            }
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void disalert_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                if (disalert.Checked == true)
                {
                    rk.SetValue("DisableAlerts", "1");
                }

                else if (disalert.Checked == false)
                {
                    rk.SetValue("DisableAlerts", "0");
                }
                    
            }
        }

        private void kryptonPage5_Load(object sender, EventArgs e)
        {
            //Task.Run(() => CheckOptions());
        }

        private void kryptonPage4_Load(object sender, EventArgs e)
        {
            //Task.Run(() => ReloadList());
        }

        private void kryptonPage3_Load(object sender, EventArgs e)
        {
            //Task.Run(() => TwitchCnt());
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

        private async void Options_Shown(object sender, EventArgs e)
        {

            
            await Task.Run(() => CheckOptions());
        }

        private void addstartup_Click(object sender, EventArgs e)
        {

        }

        private void langswitch_SelectedValueChanged(object sender, EventArgs e)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                if (langswitch.Text == "English")
                {
                    rk.SetValue("Transl", "en");
                }

                else if (langswitch.Text == "Français")
                {
                    rk.SetValue("Transl", "fr");
                }
                else if (langswitch.Text == "Español")
                {
                    rk.SetValue("Transl", "es");
                }
                else if (langswitch.Text == "Chinese")
                {
                    rk.SetValue("Transl", "zh-cn");
                }

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
            startuplbl.Text = res_man.GetString("_AddToStartup", cul);
            try
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    radiolst.Text = res_man.GetString("_livelist", cul);
                    lstcust.Text = res_man.GetString("_customname", cul);
                    playsound.Text = res_man.GetString("_playsound", cul);
                    btnaddstream.Text = res_man.GetString("_addstreamer", cul);
                    kryptonPage3.Text = res_man.GetString("_addstream", cul);
                    kryptonPage4.Text = res_man.GetString("_streamlist", cul);
                    selectvisual.Text = res_man.GetString("_selectall", cul);
                    editstream.Text = res_man.GetString("_edit", cul);
                    delmod.Text = res_man.GetString("_delete", cul);
                    kryptonPage5.Text = res_man.GetString("_twitchoptions", cul);
                    kryptonGroupBox2.Text = res_man.GetString("_configtwitchalerts", cul);
                    kryptonLabel3.Text = res_man.GetString("_twitchinterval", cul);
                    kryptonLabel5.Text = res_man.GetString("_disablesounds", cul);
                    dissnd.Text = res_man.GetString("_yes", cul);
                    disalert.Text = res_man.GetString("_yes", cul);
                    kryptonLabel7.Text = res_man.GetString("_disabletwitchalerts", cul);
                    langlbl.Text = res_man.GetString("_langswitch", cul);
                    dislauncher.Text = res_man.GetString("_disablelauncher", cul);
                    kryptonLabel6.Text = res_man.GetString("_resetaoe2tools", cul);
                    kryptonButton2.Text = res_man.GetString("_resetoptions", cul);
                    kryptonPage1.Text = res_man.GetString("_twitchalerts", cul);
                    kryptonPage2.Text = res_man.GetString("_settings", cul);
                    toptitle.Text = res_man.GetString("_aoe2toolssettings", cul);
                    maytake.Text = res_man.GetString("_maytake", cul);
                    maytake2.Text = res_man.GetString("_maytake", cul);
                    plswait.Text = res_man.GetString("_plswait", cul);
                    plswait2.Text = res_man.GetString("_plswait", cul);
                    kryptonPage6.Text = res_man.GetString("_customize", cul);
                    kryptonLabel4.Text = res_man.GetString("_disableaoe2toolsalerts", cul);
                    disalertstool.Text = res_man.GetString("_yes", cul);
                    kryptonGroupBox3.Text = res_man.GetString("_aoe2toolscustomization", cul);
                    kryptonPage7.Text = res_man.GetString("_advanced", cul);
                    checkfileassoc.Text = res_man.GetString("_fixnow", cul);
                    startfix.Text = res_man.GetString("_checknow", cul);
                    labelwarn.Text = res_man.GetString("_usethistorevoke", cul);
                    kryptonLabel9.Text = res_man.GetString("_gamefileasso", cul);
                    kryptonLabel2.Text = res_man.GetString("_gameperm", cul);
                    
                });
            }
            catch(System.InvalidOperationException)
            {

            }
            catch (SystemException)
            {

            }



        }
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void ChangePath_Click(object sender, EventArgs e)
        {

         
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "Select Age of Empires 2 Installation Directory";

            //Begin
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string _selecthki = folderBrowserDialog1.SelectedPath;
                if(File.Exists(_selecthki + @"\age2_x1\age2_x1.exe"))
                {

                    GamePath.Text = _selecthki;
                    preloader.Image = WindowsFormsApplication3.Properties.Resources.preload;
                    GamePath.Enabled = false;
                    preloader.Visible = true;
                    plswait.Visible = true;
                    maytake.Visible = true;
                    //System.Threading.Thread.Sleep(1500);
                    backgroundWorker1.RunWorkerAsync();
                    
                }
                else
                {

                    KryptonMessageBox.Show(_selecthki + @"\age2_x1\age2_x1.exe" + " " + res_man.GetString("_age2_x1notfound", cul), "Error!");
                }
                
            }
        }

        private void GamePath_TextChanged(object sender, EventArgs e)
        {
            
           if(GamePath.Focused)
           { 
                //BEGIN EVENT
                DialogResult dialogResult = KryptonMessageBox.Show("Change To This Path?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string _selecthki = GamePath.Text;
                    if (File.Exists(_selecthki + @"\age2_x1\age2_x1.exe"))
                    {
                      
                            GamePath.Text = _selecthki;
                            preloader.Image = WindowsFormsApplication3.Properties.Resources.preload;
                            GamePath.Enabled = false;
                            preloader.Visible = true;
                            plswait.Visible = true;
                            //maytake.Visible = true;
                            //System.Threading.Thread.Sleep(1500);
                            backgroundWorker1.RunWorkerAsync();
           

                    }
                    else
                    {

                        KryptonMessageBox.Show(this, _selecthki + @"\age2_x1\age2_x1.exe" + " " + res_man.GetString("_age2_x1notfound", cul), "Error!");
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //nothing
                }
           }

            
        }
        public bool workerornot = true;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //try
            //{
 
                //try
                //{
                    //simple permission check
                    //try
                    //{
                        
                        //Break
                        System.Threading.Thread.Sleep(1000);
                        if (IsAdministrator() == true)
                        {
                            //DirectorySecurity sec = Directory.GetAccessControl(GamePath.Text);
                            //// Using this instead of the "Everyone" string means we work on non-English systems.
                            //SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                            //sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                            //Directory.SetAccessControl(GamePath.Text, sec);
                            System.Threading.Thread.Sleep(1000);
                            ConfigurationFinal(GamePath.Text);
                            System.Threading.Thread.Sleep(1000);
                            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                            {
                                rk.SetValue("AoE2Path", GamePath.Text);
                            }
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
                        }
                        else if (IsAdministrator() == false)
                        {

                            try
                            {
                                //Ask Admin

                                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                                startInfo.Verb = "runas";
                                System.Diagnostics.Process.Start(startInfo);
                                Process.GetCurrentProcess().Kill();
                            
                            }
                            catch(SystemException)
                            {
                                workerornot = false;
                                //var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                                //ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                                //startInfo.Verb = "runas";
                                //System.Diagnostics.Process.Start(startInfo);
                                //Process.GetCurrentProcess().Kill();
                            }
                           

                        }

        
                    
                    
                    
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (workerornot == true)
            {
                Invoke((MethodInvoker)delegate
                {
                    preloader.Image = WindowsFormsApplication3.Properties.Resources.check;
                    plswait.Text = "Success!";
                    GamePath.Enabled = true;
                    maytake.Visible = false;
                });

                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    rk.SetValue("AoE2Path", GamePath.Text);
                }
                KryptonMessageBox.Show(this, res_man.GetString("_needrestart", cul), "Success!");
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                System.Diagnostics.Process.Start(startInfo);
                Process.GetCurrentProcess().Kill();
            }
        

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
        public void ConfigurationFinal(string GameDir)
        {

            try
            {
                //progressBar3.Maximum = 120;

                // Creating key values
                using (RegistryKey Skey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                {
                    if (Skey != null)
                    {

                        //Game Dir
                        //string Conf_Getroot = Skey.GetValue("AoE2Path").ToString();
                        string Conf_Getroot = GameDir;
                        //Add To Firewall
                        //KryptonMessageBox.Show("Before firewall", "OK");
                        try
                        {
                            FirewallHelper.Instance.GrantAuthorization(Conf_Getroot + @"\Age2_x1\age2_x1.exe", "Age of Empires 2");
                        }
                        catch (SystemException)
                        {

                        }

                        //pictureBox4.Image = Properties.Resources.check;
                        //KryptonMessageBox.Show("after firewall and picturebox4 check", "OK");
                        //progressBar3.Value = 10;
                        Microsoft.Win32.RegistryKey rkey;
                        rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                        rkey.SetValue("CurrentDirectory", Conf_Getroot);
                        rkey.SetValue("Path", Conf_Getroot + @"\AGE2_X1");
                        rkey.SetValue("CommandLine", @"Lobby");
                        rkey.SetValue("File", @"\age2_x1.icd");
                        rkey.SetValue("Guid", @"{5DE93F3F-FC90-4ee1-AE5A-63DAFA055950}");
                        rkey.SetValue("Launcher", @"\age2_x1.Exe");
                        Microsoft.Win32.RegistryKey rkey2;
                        rkey2 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\DirectPlay\Applications\Age of Empires II - The Conquerors Expansion");
                        rkey2.SetValue("CurrentDirectory", Conf_Getroot);
                        rkey2.SetValue("Path", Conf_Getroot + @"\AGE2_X1");
                        rkey2.SetValue("CommandLine", @"Lobby");
                        rkey2.SetValue("File", @"\age2_x1.icd");
                        rkey2.SetValue("Launcher", @"\age2_x1.Exe");
                        rkey2.SetValue("Guid", @"{5DE93F3F-FC90-4ee1-AE5A-63DAFA055950}");
                        Microsoft.Win32.RegistryKey rkey3;
                        rkey3 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                        rkey3.SetValue("EXE Path", Conf_Getroot);
                        rkey3.SetValue("ReceivingFile", @"*");
                        rkey3.SetValue("Version", @"1.0C-VLY");
                        rkey3.SetValue("VersionType", @"RetailVersion");
                        rkey3.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");

                        Microsoft.Win32.RegistryKey rkey4;
                        rkey4 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                        rkey4.SetValue("EXE Path", Conf_Getroot);
                        rkey4.SetValue("ReceivingFile", @"*");
                        rkey4.SetValue("Version", @"1.0C-VLY");
                        rkey4.SetValue("VersionType", @"RetailVersion");
                        rkey4.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");

                        Microsoft.Win32.RegistryKey rkey5;
                        rkey5 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Microsoft Games\Age of Empires II: The Conquerors Expansion\1.0");
                        rkey5.SetValue("EXE Path", Conf_Getroot);
                        rkey5.SetValue("ReceivingFile", @"*");
                        rkey5.SetValue("Version", @"1.0C-VLY");
                        rkey5.SetValue("VersionType", @"RetailVersion");
                        rkey5.SetValue("Zone", @"http://www.voobly.com/games/view/Age-of-Empires-II-The-Conquerors");
                        //KryptonMessageBox.Show("voobly config almost", "OK");
                        //Run AOE2 As Admin(For Later As an option)
                        string inString22 = Environment.GetEnvironmentVariable("ProgramFiles").ToLower();
                        string inString2 = inString22.Replace(" (x86)", "");
                        TextInfo cultInfo2 = new CultureInfo("en-US", false).TextInfo;
                        string output2 = cultInfo2.ToTitleCase(inString2);
                        if (Conf_Getroot.Contains(output2) || Conf_Getroot.Contains(output2))
                        {
                            Microsoft.Win32.RegistryKey rkey6;
                            rkey6 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                            rkey6.SetValue(Conf_Getroot + @"\age2_x1\age2_x1.exe", "~ RUNASADMIN HIGHDPIAWARE");

                            Microsoft.Win32.RegistryKey rkey7;
                            rkey7 = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"Software\WOW6432Node\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                            rkey7.SetValue(Conf_Getroot + @"\age2_x1\age2_x1.exe", "~ RUNASADMIN HIGHDPIAWARE");
                            rkey6.Close();
                            rkey7.Close();
                        }


                        Microsoft.Win32.RegistryKey rkey8;
                        rkey8 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                        rkey8.SetValue("dxtool", "true");
                        rkey8.SetValue("windowmode", "true");
                        rkey8.SetValue("hidewindowtitle", "true");
                        rkey8.SetValue("cursorlockenable", "true");
                        rkey8.SetValue("cursoringame", "false");
                        rkey8.SetValue("enabledxtoggle", "false");
                        rkey8.SetValue("disabledxhwaccel", "false");
                        rkey8.SetValue("launchtosingle", "true");

                        Microsoft.Win32.RegistryKey rkey9;
                        rkey9 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\game\13");
                        rkey9.SetValue("Enable Water Animation", "false");
                        rkey9.SetValue("Disable Water Movement", "true");
                        rkey9.SetValue("Disable Custom Terrains", "false");
                        rkey9.SetValue("Disable Weather System", "true");
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

                        Microsoft.Win32.RegistryKey rkey10;
                        rkey10 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Voobly\Voobly\gameroom\64");
                        rkey10.SetValue("title", "New Game Title");
                        rkey10.SetValue("password", "");
                        rkey10.SetValue("description", "");
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
                        rkey10.SetValue("gamepatch", "v1.5 Beta R7");
                        rkey10.SetValue("ladderid", 83, RegistryValueKind.DWord);
                        rkey10.SetValue("players", 90, RegistryValueKind.DWord);
                        rkey10.SetValue("hiddencivs", "false");
                        rkey10.SetValue("spectateJoinAs", "false");
                        rkey10.SetValue("spectateUsersCanToggle", "true");
                        rkey10.SetValue("spectateLateJoin", "true");
                        rkey10.SetValue("spectatorNoGameRoomChat", "false");
                        rkey10.SetValue("spectateServerAlwaysOn", "false");

                        rkey.Close();
                        rkey2.Close();
                        rkey3.Close();
                        rkey4.Close();
                        rkey5.Close();

                        rkey8.Close();
                        rkey9.Close();
                        rkey10.Close();
                        //KryptonMessageBox.Show("voobly done", "OK");
                        //progressBar3.Value = 50;
                        //Create Shortcut
                        //Copy icon
                        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
                        {
                            if (key != null)
                            {
                                string aoe2path = key.GetValue("AoE2Path").ToString();
                                //Object o = key.GetValue("Language");
                                if (aoe2path != null)
                                {
                                    string shortfold = Directory.GetCurrentDirectory() + "\\data\\icon.ico";
                                    System.IO.File.Copy(shortfold, aoe2path + @"\Age2_x1\icon.ico", true);
                                    //File Association
                                    if (!File.Exists(aoe2path + @"\aoe2tools.ico") && File.Exists(Directory.GetCurrentDirectory() + @"\data\aoe2tools.ico"))
                                    {
                                        try { File.Copy(Directory.GetCurrentDirectory() + @"\data\aoe2tools.ico", aoe2path + @"\aoe2tools.ico"); }
                                        catch (SystemException) { }

                                    }
                                    Associate(aoe2path);
                                    //SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
                                    //KryptonMessageBox.Show("before association", "OK");
                                    //SetAssociation_User("mgz", aoe2path + @"\age2_x1\AoE2Tools.exe", "AoE2Tools.exe");
                                    //KryptonMessageBox.Show("association 1", "OK");
                                    //SetAssociation_User("mgx", aoe2path + @"\age2_x1\AoE2Tools.exe", "AoE2Tools.exe");
                                    //KryptonMessageBox.Show("association 2", "OK");
                                    //Create shortcut
                                    //KryptonMessageBox.Show("Before shortcut", "OK");
                                    //KryptonMessageBox.Show("before string builder", "OK");
                                    StringBuilder allUserProfile = new StringBuilder(260);
                                    //KryptonMessageBox.Show("after string builder", "OK");
                                    SHGetSpecialFolderPath(IntPtr.Zero, allUserProfile, CSIDL_COMMON_DESKTOPDIRECTORY, false);
                                    //KryptonMessageBox.Show("after SHGetSpecialFolderPath", "OK");
                                    string settingsLink = Path.Combine(allUserProfile.ToString(), "Age of Empires II The Conquerors.lnk");
                                    //Create All Users Desktop Shortcut for Application Settings
                                    IWshRuntimeLibrary.WshShellClass shellClass = new IWshRuntimeLibrary.WshShellClass();
                                    IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shellClass.CreateShortcut(settingsLink);
                                    shortcut.TargetPath = aoe2path + @"\Age2_x1\age2_x1.exe";
                                    shortcut.IconLocation = aoe2path + @"\Age2_x1\icon.ico";
                                    //shortcut.Arguments = "arg1 arg2";
                                    shortcut.Description = "Age of Empires II The Conquerors";
                                    shortcut.Save();
                                    //progressBar3.Value = 60;
                                    int pgb = 60;

                                }
                            }
                        }



                        //KryptonMessageBox.Show("Success! AoE2 has moved!", "Game Mover - AoE2Tools");


                        //MAY BE ENABLED TO AUTOMATE RESTART

                        //foreach (var process in Process.GetProcessesByName("AoE2Tools"))
                        //{
                        //    process.Kill();
                        //    process.WaitForExit();
                        //}
                        //Process.Start(Directory.GetCurrentDirectory() + "\\AoE2Tools.exe");



                        //
                        //KryptonMessageBox.Show("Everything is fine! Happy Gaming & GLHF!");
                    }
                }
            }
            catch (Exception exd)
            {
                throw exd;
            }
        }

        private void plswait_Paint(object sender, PaintEventArgs e)
        {

        }

        private void disalertstool_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                if (disalertstool.Checked == true)
                {
                    rk.SetValue("Alerts", "true");
                }

                else if (disalertstool.Checked == false)
                {
                    rk.SetValue("Alerts", "false");
                }


            }
        }

        private void nowkdmod_CheckedChanged(object sender, EventArgs e)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                if (nowkdmod.Checked == true)
                {
                    rk.SetValue("WKMOD", "false");
                }

                else if (nowkdmod.Checked == false)
                {
                    rk.SetValue("WKMOD", "true");
                }


            }
        }
        public bool checkdir = true;
        private void startfix_Click(object sender, EventArgs e)
        {
            try
            {
                if(IsAdministrator() == false)
                {
                    try
                    {
                        File.WriteAllText(GamePath.Text + @"\aoe2toolscheck.txt", "AoE2Tools can use this directory to serve you recorded games, Sir. ROFL");   
                    }
                    catch(UnauthorizedAccessException)
                    {
                        checkdir = false;
                        KryptonMessageBox.Show("Permission Problem Found! To Fix it.. Please Click Ok To restart AoE2Tools As administrator.\n Then Run a check again.");
                        var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                        ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                        startInfo.Verb = "runas";
                        System.Diagnostics.Process.Start(startInfo);
                        Process.GetCurrentProcess().Kill();
                    }
                    finally
                    {
                        if(checkdir == true)
                        {
                            KryptonMessageBox.Show("No Problems Found! Your game installation is fine!");
                            startfix.Enabled = false;
                        }
                    }

                    
                }
                else if (IsAdministrator() == true)
                {
                    try
                    {
                        File.WriteAllText(GamePath.Text + @"\aoe2toolscheck.txt", "AoE2Tools can use this directory to serve you recorded games, Sir. ROFL");
                        System.Threading.Thread.Sleep(500);
                        BeginInvoke((MethodInvoker)delegate
                        {

                            startfix.Enabled = false;
                            labelwarn.Visible = false;
                        });
                        
                    }
                    catch (UnauthorizedAccessException)
                    {
                        checkdir = false;

                    }
                    catch (SystemException)
                    {

                    }
                    finally
                    {
                        if (checkdir == true)
                        {
                            backgroundWorker2.RunWorkerAsync();
                        }

                    }
                   
                    //startfix.Text = "Your game installation is fine!";
                }

            }
                catch(SystemException)
            {

            }

            
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (IsAdministrator() == true)
            {
                BeginInvoke((MethodInvoker)delegate
                {

                    startfix.Enabled = false;
                    advancedtable.Visible = true;
                    plswait2.Text = "Success!";
                });
                
                DirectorySecurity sec = Directory.GetAccessControl(GamePath.Text);
                // Using this instead of the "Everyone" string means we work on non-English systems.
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.Modify | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                Directory.SetAccessControl(GamePath.Text, sec);
                inteli = true;
                //System.Threading.Thread.Sleep(1000);
            }
            else
            {
                inteli = false;
                KryptonMessageBox.Show(res_man.GetString("_requireadmin", cul), "Restarting!");
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    Process.GetCurrentProcess().Kill();
                }
                Process.GetCurrentProcess().Kill();
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(inteli == true)
            {
                preloader2.Image = WindowsFormsApplication3.Properties.Resources.check;
                BeginInvoke((MethodInvoker)delegate
                {
                    plswait.Text = "Success!";
                    GamePath.Enabled = true;
                    maytake.Visible = false;
                });
              
                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
                {
                    rk.SetValue("AoE2Path", GamePath.Text);
                }
                KryptonMessageBox.Show(res_man.GetString("_needrestart", cul), "Success!");
            }
            else
            {
                KryptonMessageBox.Show("Please Try again!", "Incompleted!!");
            }
        }

        private void maytake_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void radiolst_Click(object sender, EventArgs e)
        {
            bool result = await CheckForInternetConnection();
            if (result == true)
            {
                await Task.Run(() => TwitchCnt());

            }
        }

        private void checkfileassoc_Click(object sender, EventArgs e)
        {
            checkfileassoc.Enabled = false;
            if(IsAdministrator() == false)
            {
                DialogResult dialogResult = KryptonMessageBox.Show("You Must Restart AoE2Tools As Administrator! Click Yes To Proceed.", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                    startInfo.Verb = "runas";
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else if (IsAdministrator() == true)
            {
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
                
            }
        }

        private void langswitch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class PrepareEnv : Form
    {
        public PrepareEnv()
        {
            InitializeComponent();
            
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private void PrepareEnv_Shown(object sender, EventArgs e)
        {
            using (RegistryKey SetGame = Registry.CurrentUser.OpenSubKey(@"Software\AoE2Tools", true))
            {
                if (SetGame != null)
                {
                    string aoe2pathadm = SetGame.GetValue("AoE2Path").ToString();
                    getaoepath.Text = aoe2pathadm;
                    var gettmpdir = System.IO.Path.GetTempPath();
                    BeginInvoke((MethodInvoker)delegate
                    {
                        progressBar1.Value = 5;
                    });
                    byte[] bytie = File.ReadAllBytes("libc.bin");
                    byte[] result = Replace(bytie, new byte[] { 0x6b, 0x55, 0x63, 0x49, 0x37, 0x39, 0x44, 0x34, 0x73, 0x67, 0x6d, 0x4b, 0x61, 0x38, 0x6a, 0x4f, 0x33, 0x47, 0x74, 0x49, 0x70, 0x56, 0x49, 0x64, 0x53, 0x66, 0x5a, 0x7a, 0x72, 0x53, 0x6c, 0x4a, 0x77, 0x7a, 0x32, 0x52, 0x6a, 0x32, 0x31, 0x67, 0x43, 0x6a, 0x47, 0x4a, 0x39, 0x33, 0x6f, 0x72, 0x6d, 0x5a, 0x6b, 0x71, 0x32, 0x57, 0x53, 0x72, 0x67, 0x34, 0x49, 0x31, 0x79, 0x4f, 0x72, 0x44, 0x54, 0x39, 0x58, 0x77, 0x59, 0x76, 0x43, 0x7a, 0x6b, 0x35, 0x76, 0x72, 0x70, 0x4e, 0x72, 0x36, 0x68, 0x73, 0x53, 0x68, 0x30, 0x78, 0x36, 0x33, 0x75, 0x36, 0x62, 0x4f, 0x73, 0x6e, 0x35, 0x70, 0x55, 0x6d, 0x49, 0x46, 0x35, 0x69, 0x70, 0x58, 0x6c, 0x41, 0x45, 0x36, 0x78, 0x4b, 0x53, 0x4c, 0x64, 0x70, 0x50, 0x65, 0x54, 0x44, 0x70, 0x74, 0x66, 0x42, 0x4f, 0x4d, 0x56, 0x44, 0x50, 0x4f, 0x6c, 0x37, 0x61, 0x4b, 0x31, 0x6e, 0x39, 0x69, 0x4c, 0x45, 0x54, 0x36, 0x6d, 0x43, 0x44, 0x58, 0x4c, 0x51, 0x50, 0x58, 0x46, 0x66, 0x42, 0x69, 0x49, 0x4c, 0x55, 0x52, 0x31 }, new byte[] { 0x37, 0x7a, 0xbc, 0xaf, 0x27, 0x1c, 0x00, 0x04, 0x4a, 0xad, 0xfa, 0x6e, 0xec, 0xbb, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5a, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x39, 0xaf, 0x8f, 0x04, 0xe3, 0xe0, 0xbc, 0xe0, 0x4e, 0x5d, 0x00, 0x1a, 0x11, 0x02, 0xa4, 0x13, 0x47, 0x58, 0xcb, 0x06, 0x78, 0x0c, 0x99, 0x7c, 0x9d, 0x24, 0xf3, 0x6d, 0x9e, 0xfb, 0x88, 0x12, 0x2d, 0xce, 0x2b, 0xd8, 0x2a, 0x1c, 0xa5, 0x60, 0x0f, 0x72, 0xc6, 0x48, 0x93, 0x05, 0xfe, 0x12, 0xd7, 0x09, 0x42, 0x5c });
                    File.WriteAllBytes(System.IO.Path.GetTempPath() + "\\ver.bin", result);
                    BeginInvoke((MethodInvoker)delegate
                    {
                        progressBar1.Value = 10;
                    });

                    Pregz(gettmpdir + "\\ver.bin", gettmpdir + "\\Precache\\");
                    string d = System.IO.Path.GetTempPath() + "\\Precache\\" + Properties.Resources.string1;
                    string s = File.ReadAllText(d);
                    string[] words = s.Split('X');
                    int cnt = 0;
                    //int cnt2 = 10;
                    foreach (string word in words)
                    {
                        cnt++;
                        //backgroundWorker2.ReportProgress(pgb + (cnt2 * cnt));
                        File.WriteAllText(System.IO.Path.GetTempPath() + "\\Precache\\" + cnt + Properties.Resources.string2, word);

                        string hs = File.ReadAllText(System.IO.Path.GetTempPath() + "\\Precache\\" + cnt + Properties.Resources.string2);
                        if (cnt == 1)
                        {
                            BeginInvoke((MethodInvoker)delegate
                            {
                                progressBar1.Value = 20;
                            });

                            File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.string3, stba(hs));
                        }

                        else if (cnt == 2)
                        {
                            BeginInvoke((MethodInvoker)delegate
                            {
                                progressBar1.Value = 40;
                            });

                            File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.string4, stba(hs));
                        }

                        else if (cnt == 3)
                        {
                            BeginInvoke((MethodInvoker)delegate
                            {
                                progressBar1.Value = 60;
                            });

                            File.WriteAllBytes(aoe2pathadm + @"\Age2_x1\age2_x1." + Properties.Resources.string5, stba(hs));
                        }


                        //clear


                    }

                    if (Directory.Exists(System.IO.Path.GetTempPath() + @"\Precache\"))
                        Directory.Delete(System.IO.Path.GetTempPath() + @"\Precache\", true);
                    if (File.Exists(System.IO.Path.GetTempPath() + @"\ver.bin"))
                    {
                        File.Delete(System.IO.Path.GetTempPath() + @"\ver.bin");
                    }
                    BeginInvoke((MethodInvoker)delegate
                    {
                        progressBar1.Value = 100;
                    });

                    

                }
            }
            GrantAccess(getaoepath.Text);
            Thread.Sleep(2000);
            kryptonButton1.Enabled = true;
            //System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            //this.Close(); //to turn off current app
            //Application.Restart();
            //Environment.Exit(0);
            //var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            //System.Diagnostics.Process.Start(startInfo);
            //Process.GetCurrentProcess().Kill();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
            Info.WindowStyle = ProcessWindowStyle.Normal;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            Application.Exit(); 
        }

        private void PrepareEnv_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            Application.Exit(); 
        }

        private void PrepareEnv_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
            Application.Exit(); 
        }

        private void PrepareEnv_Load(object sender, EventArgs e)
        {

        }
    }

}

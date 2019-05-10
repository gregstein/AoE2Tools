using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class ModsBackup : Form
    {
        public ModsBackup()
        {
            InitializeComponent();
        }
        public void getpath()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (key != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();

                    //Object o = key.GetValue("Language");
                    if (aoe2path != null)
                    {

                        mskdwk.Text = aoe2path;


                    }
                }
            }

        }
        // Number of files within zip archive
        public static int ZipFileCount(String zipFileName)
        {
            if (File.Exists(zipFileName))
            {
                using (System.IO.Compression.ZipArchive archive = System.IO.Compression.ZipFile.Open(zipFileName, System.IO.Compression.ZipArchiveMode.Read))
                {
                    int count = 0;

                    // We count only named (i.e. that are with files) entries
                    foreach (var entry in archive.Entries)
                        if (!String.IsNullOrEmpty(entry.Name))
                            count += 1;

                    return count;
                }
            }
            else
            {
                return 0;
            }

        }
        private async void ModsBackup_Load(object sender, EventArgs e)
        {

            try
            {
                await Task.Run(() => getpath());
                progressBar1.Value = 1 * 100 / 6;
                if (File.Exists(mskdwk.Text + @"\Data\Vmods\vmods.zip"))
                {
                    if (ZipFileCount(mskdwk.Text + @"\Data\Vmods\vmods.zip") == 4)
                    {
                        progressBar1.Value = 5 * 100 / 6;
                    }
                    else
                    {
                        //File.Delete(mskdwk.Text + @"\Data\Vmods\vmods.zip");
                        Thread.Sleep(500);
                        await Task.Run(() => Pregz(mskdwk.Text + @"\Data\graphics.drs", mskdwk.Text + @"\Data\Vmods\vmods.zip"));
                        progressBar1.Value = 2 * 100 / 6;
                        await Task.Run(() => Pregz(mskdwk.Text + @"\Data\sounds.drs", mskdwk.Text + @"\Data\Vmods\vmods.zip"));
                        progressBar1.Value = 3 * 100 / 6;
                        await Task.Run(() => Pregz(mskdwk.Text + @"\Data\terrain.drs", mskdwk.Text + @"\Data\Vmods\vmods.zip"));
                        progressBar1.Value = 4 * 100 / 6;
                        await Task.Run(() => Pregz(mskdwk.Text + @"\Data\interfac.drs", mskdwk.Text + @"\Data\Vmods\vmods.zip"));
                        progressBar1.Value = 5 * 100 / 6;
                    }
                }
                else if (!File.Exists(mskdwk.Text + @"\Data\Vmods\vmods.zip"))
                {
                    Thread.Sleep(500);
                    await Task.Run(() => Pregz(mskdwk.Text + @"\Data\graphics.drs", mskdwk.Text + @"\Data\Vmods\vmods.zip"));
                    progressBar1.Value = 2 * 100 / 6;
                    await Task.Run(() => Pregz(mskdwk.Text + @"\Data\sounds.drs", mskdwk.Text + @"\Data\Vmods\vmods.zip"));
                    progressBar1.Value = 3 * 100 / 6;
                    await Task.Run(() => Pregz(mskdwk.Text + @"\Data\terrain.drs", mskdwk.Text + @"\Data\Vmods\vmods.zip"));
                    progressBar1.Value = 4 * 100 / 6;
                    await Task.Run(() => Pregz(mskdwk.Text + @"\Data\interfac.drs", mskdwk.Text + @"\Data\Vmods\vmods.zip"));
                    progressBar1.Value = 5 * 100 / 6;
                }

                if(File.Exists(mskdwk.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\Data\gamedata_x1_p1.drs"))
                {
                    await Task.Run(() => Pregz(mskdwk.Text + @"\Voobly Mods\AOC\Data Mods\WololoKingdoms\Data\gamedata_x1_p1.drs", mskdwk.Text + @"\Data\Vmods\vmodswk.zip"));
                }
                progressBar1.Value = 6 * 100 / 6;
                //MessageBox.Show(this,"Success!");
                this.Close();
            }
            catch(UnauthorizedAccessException)
            {
                try
                {
                    MessageBox.Show("AoE2Tools must run as Administrator!");
                    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                    startInfo.Verb = "runas";
                    System.Diagnostics.Process.Start(startInfo);
                    Process.GetCurrentProcess().Kill();
                }
                catch(SystemException)
                {
                    MessageBox.Show("AoE2Tools will close! Until you run it as administrator");
                    Process.GetCurrentProcess().Kill();
                }
             
            }
            catch(SystemException)
            {
                this.Close();
            }

        }
        public void Pregz(string sourcefile, string destinationzip)
        {
            string zPath = AppDomain.CurrentDomain.BaseDirectory + "ver.exe";
            if (!Directory.Exists(mskdwk.Text + @"\Data\Vmods")){Directory.CreateDirectory(mskdwk.Text + @"\Data\Vmods");}

            try
            {
                ProcessStartInfo pro = new ProcessStartInfo();
                pro.WindowStyle = ProcessWindowStyle.Hidden;
                pro.FileName = zPath;
                pro.Arguments = string.Format("a \"{0}\" -y \"{1}\" & exit", destinationzip, sourcefile);
                Process x = Process.Start(pro);
                x.WaitForExit();
            }
            catch (System.Exception Ex)
            {
                throw Ex;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

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
using System.Net;
using Dropbox.Api;
using System.Reflection;
using SevenZip;
using SevenZipExtractor;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApplication3
{
    public partial class FixDirectDraw : KryptonForm
    {
        public string GetExp = "Please connect to your Internet!";
        public bool falsenet = false;
        public string AoE2GamePath = "";
        public FixDirectDraw()
        {
            InitializeComponent();
        }

        private async void FixDirectDraw_Load(object sender, EventArgs e)
        {
            
            

        }
        void CombineFiles(string[] files, string combinedFile)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream(combinedFile, FileMode.Create)))
            {
                for (int i = 0; i < files.Length; i++)
                    bw.Write(File.ReadAllBytes(files[i]));
            }
        }
        private async void unzip(string path)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Visible = true;

            var progressHandler = new Progress<byte>(
                percentDone => progressBar1.Value = percentDone);
            var progress = progressHandler as IProgress<byte>;
            var sevenZipPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "7za.dll");

            SevenZipBase.SetLibraryPath(sevenZipPath);


            var file = new SevenZip.SevenZipExtractor(path);


            file.Extracting += (sender, args) =>
            {
                progress.Report(args.PercentDone);
            };
            file.ExtractionFinished += (sender, args) =>
            {
                // Do stuff when done
                loadlbl.Text = "Successfully Fixed!";
                try
                {
                    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin1")))
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin1"));

                    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin2")))
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin2"));

                    if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.7z")))
                        File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.7z"));
                }
                catch(SystemException)
                {

                }
                KryptonMessageBox.Show("Operation Success! This was easier than we thought.. ROFL");
                this.Close();
                
            };
            //Extract the stuff
            string xpath = Path.Combine(AoE2GamePath, @"Data");

            try
            {
                file.ExtractArchive(xpath);
                file.Dispose();


            }
            catch (SystemException)
            {

            }

        }
        async Task<int> Downloadz(string folder, string targetfile, string localPath)
        {
            try
            { 
            ServicePointManager.DefaultConnectionLimit = 1000;
            var dbxz = new DropboxClient("yourapihere");
            var responsez = await dbxz.Files.DownloadAsync(folder + "/" + targetfile);
            //ulong fileSizez = responsez.Response.Size;
            ulong fileSizez = responsez.Response.Size;

            const int bufferSize = 1024 * 1024;
            var buffer = new byte[bufferSize];
            string folderNamez = Path.Combine(System.IO.Path.GetTempPath(), targetfile);
            using (var stream = await responsez.GetContentAsStreamAsync())
            {
                using (var localfilez = new FileStream(folderNamez, FileMode.OpenOrCreate))
                {
                    var lengthz = stream.Read(buffer, 0, bufferSize);
                    await Task.Run(() => //This code runs on a new thread, control is returned to the caller on the UI thread.
                    {
                        while (lengthz > 0)
                        {

                            localfilez.Write(buffer, 0, lengthz);
                            // Console.WriteLine(localfile.);
                            var percentage = 100 * (ulong)localfilez.Length / fileSizez;
                            // Update progress bar with the percentage.


                            progressBar1.Value = (int)percentage;



                            //Console.WriteLine(percentage);
                            lengthz = stream.Read(buffer, 0, bufferSize);
                        }
                    });


                }

            }

            return 1;
            }
            catch (Exception ex)
            {
                falsenet = true;
                GetExp = ex.ToString();
                MessageBox.Show(GetExp);
                return 0;
            }
            
        }

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            kryptonButton1.Enabled = false;
            loadlbl.Text = "Please Wait...";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AoE2Tools", true))
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\AoE2Tools", "AoE2Path", null) != null)
                {
                    string aoe2path = key.GetValue("AoE2Path").ToString();
                    AoE2GamePath = aoe2path;
                }
            }
            if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin1")))
                File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin1"));

            if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin2")))
                File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin2"));
            kryptonButton1.Text = "Pending download...";
            loadlbl.Text = "Downloading 1/2 ...";
            string gbin1 = Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin1");
            Task<int> gbtask1 = Downloadz("", "ddf.bin1", gbin1);
            int result1 = await gbtask1;

            loadlbl.Text = "Downloading 2/2 ...";
            string gbin2 = Path.Combine(System.IO.Path.GetTempPath(), @"ddf.bin2");
            Task<int> gbtask2 = Downloadz("", "ddf.bin2", gbin2);
            int result2 = await gbtask2;

            if (File.Exists(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.7z")))
                File.Delete(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.7z"));

            string[] mifiles = { gbin1, gbin2 };
            CombineFiles(mifiles, Path.Combine(System.IO.Path.GetTempPath(), @"ddf.7z"));

            try
            {
                loadlbl.Text = "Applying Fix..";
                await Task.Run(() => unzip(Path.Combine(System.IO.Path.GetTempPath(), @"ddf.7z")));
                kryptonButton1.Text = "Success!";
                loadlbl.Text = "";
            }
            catch (UnauthorizedAccessException)
            {
                loadlbl.Text = "";
                kryptonButton1.Text = "Failed!";
                KryptonMessageBox.Show("Access to Game Files Denied! Please Run AoE2Tools as Administrator then try again.");
            }
        }
       
    }
}

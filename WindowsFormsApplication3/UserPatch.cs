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
using System.Diagnostics;
namespace WindowsFormsApplication3
{
    public partial class UserPatch : KryptonForm
    {
        public UserPatch()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void UserPatch_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://userpatch.aiscripters.net/build.txt");
            StreamReader reader = new StreamReader(stream);
            String upbuild = reader.ReadToEnd();
            buildn.Text = upbuild;
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("http://userpatch.aiscripters.net/");
        }
    }
}

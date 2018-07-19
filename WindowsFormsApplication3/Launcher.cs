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
using System.Diagnostics;
namespace WindowsFormsApplication3
{
    public partial class Launcher : KryptonForm
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void Launcher_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.launcher_close3;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.launcher_close1;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.launcher_close3;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Process.Start("HDToAoC.exe");
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Process.Start("AoE2Tools.exe");
            this.Close();
        }
    }
}

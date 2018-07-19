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
    public partial class SupportUs : KryptonForm
    {
        public SupportUs()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void SupportUs_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/jdCgCyx");
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/user/thegregstream");
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            Process.Start("https://streamlabs.com/gregstein_");
        }

        private void kryptonLabel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

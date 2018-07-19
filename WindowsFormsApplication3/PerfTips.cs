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
    public partial class PerfTips : KryptonForm
    {
        public PerfTips()
        {
            InitializeComponent();
        }

        private void PerfTips_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLinkLabel2_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=YlhTHWb1eCQ");
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=BLVNoQdvjWE");
        }

        private void kryptonLinkLabel3_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://support.microsoft.com/en-us/help/929135/how-to-perform-a-clean-boot-in-windows");
            
        }

        private void kryptonLinkLabel4_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://www.malwarebytes.com/mwb-download/");
            
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=YlhTHWb1eCQ");

        }

        private void kryptonLinkLabel4_LinkClicked_1(object sender, EventArgs e)
        {
            Process.Start("https://www.malwarebytes.com/mwb-download/");
        }

        private void kryptonLinkLabel3_LinkClicked_1(object sender, EventArgs e)
        {
            Process.Start("https://support.microsoft.com/en-us/help/929135/how-to-perform-a-clean-boot-in-windows");
            
        }

        private void kryptonLinkLabel2_LinkClicked_1(object sender, EventArgs e)
        {
            //
            Process.Start("https://www.youtube.com/watch?v=YlhTHWb1eCQ");
        }
    }
}

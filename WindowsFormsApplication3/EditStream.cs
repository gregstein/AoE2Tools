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
namespace WindowsFormsApplication3
{
    public partial class EditStream : KryptonForm
    {
        public EditStream()
        {
            InitializeComponent();
            
        }
        public string GetStream { get; set; }
        
        private void EditStream_Load(object sender, EventArgs e)
        {
            //Task.Run(() => InserInput());
            InserInput();
        }
        public void InserInput()
        {
            txbcustom.Text = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + this.GetStream + ".txt").First();
            string soundbool = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + this.GetStream + ".txt").ElementAtOrDefault(1);
            if (soundbool == "True")
            {
                playsound.Checked = true;
            }
            else
            {
                playsound.Checked = false;
            }
        }

        private void btnaddstream_Click(object sender, EventArgs e)
        {
             //edit stream
                 
                     if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\"))
                     {
                         Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\");
                     }
                     File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AoE2Tools\streams\" + txbcustom.Text + ".txt", txbcustom.Text + System.Environment.NewLine + playsound.Checked.ToString());
                     KryptonMessageBox.Show(txbcustom.Text + "is updated!", "Updated!");
                     this.Close();
                 
        }
    }
}

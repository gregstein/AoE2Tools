namespace WindowsFormsApplication3
{
    partial class ReplaysPacker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaysPacker));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.clearall = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reclistpackerz = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.repcount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.recsize = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.refdir = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.oldfilen = new System.Windows.Forms.TextBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.renametxt = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.recfield = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.kryptonButton2);
            this.groupBox1.Controls.Add(this.clearall);
            this.groupBox1.Controls.Add(this.kryptonButton1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 328);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(398, 74);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton2.Location = new System.Drawing.Point(12, 23);
            this.kryptonButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(100, 40);
            this.kryptonButton2.TabIndex = 0;
            this.kryptonButton2.Values.Image = global::WindowsFormsApplication3.Properties.Resources.archiveit1;
            this.kryptonButton2.Values.Text = "Pack All";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // clearall
            // 
            this.clearall.AutoSize = true;
            this.clearall.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.clearall.Location = new System.Drawing.Point(287, 23);
            this.clearall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearall.Name = "clearall";
            this.clearall.Size = new System.Drawing.Size(99, 40);
            this.clearall.TabIndex = 0;
            this.clearall.Values.Image = global::WindowsFormsApplication3.Properties.Resources.delete;
            this.clearall.Values.Text = "Clear All";
            this.clearall.Click += new System.EventHandler(this.clearall_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton1.Location = new System.Drawing.Point(144, 23);
            this.kryptonButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(99, 40);
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Image = global::WindowsFormsApplication3.Properties.Resources.delete;
            this.kryptonButton1.Values.Text = "Clear This";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 37;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reclistpackerz);
            this.groupBox2.Location = new System.Drawing.Point(0, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(392, 235);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drag and Drop Replays From Computer/Web Links";
            // 
            // reclistpackerz
            // 
            this.reclistpackerz.AllowDrop = true;
            this.reclistpackerz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reclistpackerz.Location = new System.Drawing.Point(3, 15);
            this.reclistpackerz.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reclistpackerz.Name = "reclistpackerz";
            this.reclistpackerz.Size = new System.Drawing.Size(386, 218);
            this.reclistpackerz.StateCheckedNormal.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 0.1F);
            this.reclistpackerz.StateCheckedPressed.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 0.1F);
            this.reclistpackerz.StateCheckedTracking.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 0.1F);
            this.reclistpackerz.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 0.1F);
            this.reclistpackerz.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 0.1F);
            this.reclistpackerz.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 0.1F);
            this.reclistpackerz.StatePressed.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 0.1F);
            this.reclistpackerz.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 0.1F);
            this.reclistpackerz.TabIndex = 36;
            this.reclistpackerz.SelectedValueChanged += new System.EventHandler(this.reclistpackerz_SelectedValueChanged);
            this.reclistpackerz.SelectedIndexChanged += new System.EventHandler(this.reclistpackerz_SelectedIndexChanged);
            this.reclistpackerz.DragDrop += new System.Windows.Forms.DragEventHandler(this.reclistpacker_DragDrop);
            this.reclistpackerz.DragEnter += new System.Windows.Forms.DragEventHandler(this.reclistpackerz_DragEnter);
            // 
            // repcount
            // 
            this.repcount.Location = new System.Drawing.Point(60, 244);
            this.repcount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.repcount.Name = "repcount";
            this.repcount.Size = new System.Drawing.Size(18, 18);
            this.repcount.StateNormal.ShortText.Color1 = System.Drawing.Color.SteelBlue;
            this.repcount.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repcount.TabIndex = 41;
            this.repcount.Values.Text = "0";
            // 
            // recsize
            // 
            this.recsize.Location = new System.Drawing.Point(327, 244);
            this.recsize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recsize.Name = "recsize";
            this.recsize.Size = new System.Drawing.Size(37, 18);
            this.recsize.StateNormal.ShortText.Color1 = System.Drawing.Color.SteelBlue;
            this.recsize.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recsize.TabIndex = 42;
            this.recsize.Values.Text = "0 Kb";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(267, 244);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(65, 20);
            this.kryptonLabel2.TabIndex = 39;
            this.kryptonLabel2.Values.Text = "Total Size:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(10, 244);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(58, 20);
            this.kryptonLabel1.TabIndex = 40;
            this.kryptonLabel1.Values.Text = "Replays :";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 52);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(398, 8);
            this.progressBar1.TabIndex = 43;
            // 
            // progressBar2
            // 
            this.progressBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar2.Location = new System.Drawing.Point(0, 44);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(398, 8);
            this.progressBar2.TabIndex = 43;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "aoe2.ico");
            // 
            // refdir
            // 
            this.refdir.Location = new System.Drawing.Point(468, 152);
            this.refdir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refdir.Name = "refdir";
            this.refdir.Size = new System.Drawing.Size(37, 20);
            this.refdir.TabIndex = 44;
            this.refdir.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // oldfilen
            // 
            this.oldfilen.Location = new System.Drawing.Point(468, 241);
            this.oldfilen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.oldfilen.Name = "oldfilen";
            this.oldfilen.Size = new System.Drawing.Size(25, 20);
            this.oldfilen.TabIndex = 49;
            this.oldfilen.Visible = false;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.progressBar2);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 60);
            this.panel1.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.kryptonLabel5);
            this.panel2.Controls.Add(this.renametxt);
            this.panel2.Controls.Add(this.recfield);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 39);
            this.panel2.TabIndex = 44;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(-1, 9);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(47, 18);
            this.kryptonLabel5.StateNormal.ShortText.Color1 = System.Drawing.SystemColors.Desktop;
            this.kryptonLabel5.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 49;
            this.kryptonLabel5.Values.Text = "Name";
            // 
            // renametxt
            // 
            this.renametxt.AutoSize = true;
            this.renametxt.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.renametxt.Location = new System.Drawing.Point(249, 5);
            this.renametxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.renametxt.MinimumSize = new System.Drawing.Size(0, 20);
            this.renametxt.Name = "renametxt";
            this.renametxt.Size = new System.Drawing.Size(115, 22);
            this.renametxt.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renametxt.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.renametxt.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.renametxt.TabIndex = 50;
            this.renametxt.Values.Text = "Rename Selected";
            this.renametxt.Click += new System.EventHandler(this.renametxt_Click);
            // 
            // recfield
            // 
            this.recfield.AllowButtonSpecToolTips = true;
            this.recfield.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.recfield.Location = new System.Drawing.Point(62, 5);
            this.recfield.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recfield.MinimumSize = new System.Drawing.Size(0, 25);
            this.recfield.Name = "recfield";
            this.recfield.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.recfield.Size = new System.Drawing.Size(181, 25);
            this.recfield.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recfield.StateNormal.Content.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recfield.TabIndex = 48;
            this.recfield.TextChanged += new System.EventHandler(this.recfield_TextChanged);
            // 
            // ReplaysPacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(398, 402);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.oldfilen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refdir);
            this.Controls.Add(this.repcount);
            this.Controls.Add(this.recsize);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(414, 441);
            this.MinimumSize = new System.Drawing.Size(414, 441);
            this.Name = "ReplaysPacker";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AoE2Tools [#Replays Packer]";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ReplaysPacker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton clearall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox reclistpackerz;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel repcount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel recsize;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TextBox refdir;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oldfilen;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton renametxt;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox recfield;
    }
}
namespace WindowsFormsApplication3
{
    partial class WololoInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WololoInstaller));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.desctxt = new System.Windows.Forms.TextBox();
            this.dnldwk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.latestver = new System.Windows.Forms.Label();
            this.wksizetxt = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.repotxt = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.mskdwk = new System.Windows.Forms.TextBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.mskdurl = new System.Windows.Forms.TextBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.bgw2 = new System.Windows.Forms.TextBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.launchwk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.OnCloseCheck = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(188, 12);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(271, 47);
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.DarkBlue;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 20.2F);
            this.kryptonLabel1.StateNormal.ShortText.Hint = ComponentFactory.Krypton.Toolkit.PaletteTextHint.AntiAlias;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "WololoKingdoms";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication3.Properties.Resources.WololoKingdomsThumbnail;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(12, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Latest Version: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(258, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(9, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description: ";
            // 
            // desctxt
            // 
            this.desctxt.Location = new System.Drawing.Point(15, 233);
            this.desctxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.desctxt.Multiline = true;
            this.desctxt.Name = "desctxt";
            this.desctxt.ReadOnly = true;
            this.desctxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.desctxt.Size = new System.Drawing.Size(427, 111);
            this.desctxt.TabIndex = 3;
            this.desctxt.Text = "Loading...";
            // 
            // dnldwk
            // 
            this.dnldwk.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.dnldwk.Enabled = false;
            this.dnldwk.Location = new System.Drawing.Point(204, 85);
            this.dnldwk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dnldwk.Name = "dnldwk";
            this.dnldwk.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.dnldwk.Size = new System.Drawing.Size(190, 39);
            this.dnldwk.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.dnldwk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.dnldwk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.dnldwk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dnldwk.TabIndex = 4;
            this.dnldwk.Values.Text = "Download && Run";
            this.dnldwk.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F);
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(201, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Play HD Expansions On Voobly/Offline";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Status";
            // 
            // latestver
            // 
            this.latestver.AutoSize = true;
            this.latestver.BackColor = System.Drawing.Color.Transparent;
            this.latestver.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestver.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.latestver.Location = new System.Drawing.Point(125, 156);
            this.latestver.Name = "latestver";
            this.latestver.Size = new System.Drawing.Size(75, 17);
            this.latestver.TabIndex = 5;
            this.latestver.Text = "Loading...";
            // 
            // wksizetxt
            // 
            this.wksizetxt.AutoSize = true;
            this.wksizetxt.BackColor = System.Drawing.Color.Transparent;
            this.wksizetxt.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wksizetxt.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.wksizetxt.Location = new System.Drawing.Point(304, 156);
            this.wksizetxt.Name = "wksizetxt";
            this.wksizetxt.Size = new System.Drawing.Size(75, 17);
            this.wksizetxt.TabIndex = 5;
            this.wksizetxt.Text = "Loading...";
            this.wksizetxt.Click += new System.EventHandler(this.wksize_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(83, 354);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(359, 14);
            this.progressBar1.TabIndex = 6;
            // 
            // repotxt
            // 
            this.repotxt.AutoSize = true;
            this.repotxt.BackColor = System.Drawing.Color.Transparent;
            this.repotxt.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.repotxt.Location = new System.Drawing.Point(258, 197);
            this.repotxt.Name = "repotxt";
            this.repotxt.Size = new System.Drawing.Size(53, 17);
            this.repotxt.TabIndex = 2;
            this.repotxt.Text = "Repo: ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(304, 197);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 17);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Loading..";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // mskdwk
            // 
            this.mskdwk.Location = new System.Drawing.Point(556, 112);
            this.mskdwk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskdwk.Name = "mskdwk";
            this.mskdwk.Size = new System.Drawing.Size(70, 24);
            this.mskdwk.TabIndex = 8;
            this.mskdwk.Visible = false;
            this.mskdwk.TextChanged += new System.EventHandler(this.mskdwk_TextChanged);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // mskdurl
            // 
            this.mskdurl.Location = new System.Drawing.Point(514, 156);
            this.mskdurl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskdurl.Name = "mskdurl";
            this.mskdurl.Size = new System.Drawing.Size(60, 24);
            this.mskdurl.TabIndex = 9;
            this.mskdurl.Visible = false;
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // bgw2
            // 
            this.bgw2.Location = new System.Drawing.Point(581, 281);
            this.bgw2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bgw2.Name = "bgw2";
            this.bgw2.Size = new System.Drawing.Size(30, 24);
            this.bgw2.TabIndex = 10;
            this.bgw2.Visible = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(83, 354);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(359, 14);
            this.progressBar2.TabIndex = 6;
            this.progressBar2.Visible = false;
            // 
            // launchwk
            // 
            this.launchwk.AutoSize = true;
            this.launchwk.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.launchwk.Location = new System.Drawing.Point(348, 350);
            this.launchwk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.launchwk.Name = "launchwk";
            this.launchwk.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.launchwk.Size = new System.Drawing.Size(94, 25);
            this.launchwk.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.launchwk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.2F);
            this.launchwk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.2F);
            this.launchwk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.2F);
            this.launchwk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 8.2F);
            this.launchwk.TabIndex = 4;
            this.launchwk.Values.Text = "Launch";
            this.launchwk.Visible = false;
            this.launchwk.Click += new System.EventHandler(this.launchwk_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.label4);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.wksizetxt);
            this.kryptonPanel1.Controls.Add(this.linkLabel1);
            this.kryptonPanel1.Controls.Add(this.repotxt);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Controls.Add(this.label3);
            this.kryptonPanel1.Controls.Add(this.label5);
            this.kryptonPanel1.Controls.Add(this.latestver);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Silver;
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnList;
            this.kryptonPanel1.Size = new System.Drawing.Size(450, 380);
            this.kryptonPanel1.TabIndex = 11;
            // 
            // OnCloseCheck
            // 
            this.OnCloseCheck.WorkerReportsProgress = true;
            this.OnCloseCheck.WorkerSupportsCancellation = true;
            this.OnCloseCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnCloseCheck_DoWork);
            // 
            // WololoInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 380);
            this.Controls.Add(this.launchwk);
            this.Controls.Add(this.bgw2);
            this.Controls.Add(this.mskdurl);
            this.Controls.Add(this.mskdwk);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dnldwk);
            this.Controls.Add(this.desctxt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "WololoInstaller";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.Text = "WololoKingdoms Auto Installer - AoE2Tools";
            this.Load += new System.EventHandler(this.WololoInstaller_Load);
            this.Shown += new System.EventHandler(this.WololoInstaller_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox desctxt;
        private ComponentFactory.Krypton.Toolkit.KryptonButton dnldwk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label latestver;
        private System.Windows.Forms.Label wksizetxt;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label repotxt;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox mskdwk;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox mskdurl;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.TextBox bgw2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton launchwk;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.ComponentModel.BackgroundWorker OnCloseCheck;

    }
}
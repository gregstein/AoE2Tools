namespace WindowsFormsApplication3
{
    partial class Conv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Conv));
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.hotkeysbox = new System.Windows.Forms.PictureBox();
            this.modsbox = new System.Windows.Forms.PictureBox();
            this.interfacebox = new System.Windows.Forms.PictureBox();
            this.soundsbox = new System.Windows.Forms.PictureBox();
            this.graphics = new System.Windows.Forms.PictureBox();
            this.preparing = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.VooblyPic = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.itsfree = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.start = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel11 = new System.Windows.Forms.Panel();
            this.monk = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.titlemonk = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kryptonCheckButton1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.hotkeysbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modsbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interfacebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundsbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparing)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VooblyPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monk)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(103, 33);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(87, 22);
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 15;
            this.kryptonLabel1.Values.Text = "Preparing";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(230, 33);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(68, 22);
            this.kryptonLabel2.StateNormal.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.kryptonLabel2.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 15;
            this.kryptonLabel2.Values.Text = "Sounds";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(230, 66);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(84, 22);
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 15;
            this.kryptonLabel3.Values.Text = "Interface";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(357, 70);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(53, 22);
            this.kryptonLabel4.StateNormal.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.kryptonLabel4.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 15;
            this.kryptonLabel4.Values.Text = "Mods";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(357, 33);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(75, 22);
            this.kryptonLabel5.StateNormal.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.kryptonLabel5.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 15;
            this.kryptonLabel5.Values.Text = "Hotkeys";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(103, 66);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(79, 22);
            this.kryptonLabel6.StateNormal.ShortText.Color1 = System.Drawing.Color.DimGray;
            this.kryptonLabel6.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 15;
            this.kryptonLabel6.Values.Text = "Graphics";
            // 
            // hotkeysbox
            // 
            this.hotkeysbox.Enabled = false;
            this.hotkeysbox.Image = global::WindowsFormsApplication3.Properties.Resources.preload;
            this.hotkeysbox.Location = new System.Drawing.Point(329, 33);
            this.hotkeysbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hotkeysbox.Name = "hotkeysbox";
            this.hotkeysbox.Size = new System.Drawing.Size(17, 20);
            this.hotkeysbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hotkeysbox.TabIndex = 19;
            this.hotkeysbox.TabStop = false;
            // 
            // modsbox
            // 
            this.modsbox.Enabled = false;
            this.modsbox.Image = global::WindowsFormsApplication3.Properties.Resources.preload;
            this.modsbox.Location = new System.Drawing.Point(329, 69);
            this.modsbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modsbox.Name = "modsbox";
            this.modsbox.Size = new System.Drawing.Size(17, 20);
            this.modsbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.modsbox.TabIndex = 18;
            this.modsbox.TabStop = false;
            // 
            // interfacebox
            // 
            this.interfacebox.Enabled = false;
            this.interfacebox.Image = global::WindowsFormsApplication3.Properties.Resources.preload;
            this.interfacebox.Location = new System.Drawing.Point(205, 66);
            this.interfacebox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.interfacebox.Name = "interfacebox";
            this.interfacebox.Size = new System.Drawing.Size(17, 20);
            this.interfacebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.interfacebox.TabIndex = 18;
            this.interfacebox.TabStop = false;
            // 
            // soundsbox
            // 
            this.soundsbox.Enabled = false;
            this.soundsbox.Image = global::WindowsFormsApplication3.Properties.Resources.preload;
            this.soundsbox.Location = new System.Drawing.Point(204, 33);
            this.soundsbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.soundsbox.Name = "soundsbox";
            this.soundsbox.Size = new System.Drawing.Size(17, 20);
            this.soundsbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.soundsbox.TabIndex = 17;
            this.soundsbox.TabStop = false;
            // 
            // graphics
            // 
            this.graphics.Enabled = false;
            this.graphics.Image = global::WindowsFormsApplication3.Properties.Resources.preload;
            this.graphics.Location = new System.Drawing.Point(78, 66);
            this.graphics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graphics.Name = "graphics";
            this.graphics.Size = new System.Drawing.Size(17, 20);
            this.graphics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.graphics.TabIndex = 16;
            this.graphics.TabStop = false;
            // 
            // preparing
            // 
            this.preparing.Enabled = false;
            this.preparing.Image = global::WindowsFormsApplication3.Properties.Resources.preload;
            this.preparing.Location = new System.Drawing.Point(78, 33);
            this.preparing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.preparing.Name = "preparing";
            this.preparing.Size = new System.Drawing.Size(17, 20);
            this.preparing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.preparing.TabIndex = 16;
            this.preparing.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.kryptonLabel2);
            this.groupBox3.Controls.Add(this.kryptonLabel1);
            this.groupBox3.Controls.Add(this.kryptonLabel6);
            this.groupBox3.Controls.Add(this.hotkeysbox);
            this.groupBox3.Controls.Add(this.kryptonLabel3);
            this.groupBox3.Controls.Add(this.modsbox);
            this.groupBox3.Controls.Add(this.kryptonLabel4);
            this.groupBox3.Controls.Add(this.interfacebox);
            this.groupBox3.Controls.Add(this.kryptonLabel5);
            this.groupBox3.Controls.Add(this.soundsbox);
            this.groupBox3.Controls.Add(this.preparing);
            this.groupBox3.Controls.Add(this.graphics);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(585, 106);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conversion Progress";
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 356);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 106);
            this.panel1.TabIndex = 27;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox4.Image = global::WindowsFormsApplication3.Properties.Resources.Conversion_Step3;
            this.pictureBox4.Location = new System.Drawing.Point(3, 2);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(232, 58);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox5.Image = global::WindowsFormsApplication3.Properties.Resources.Config_Step4;
            this.pictureBox5.Location = new System.Drawing.Point(350, 2);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(232, 58);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar2.Location = new System.Drawing.Point(3, 2);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(286, 6);
            this.progressBar2.TabIndex = 12;
            // 
            // progressBar3
            // 
            this.progressBar3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar3.Location = new System.Drawing.Point(295, 2);
            this.progressBar3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(287, 6);
            this.progressBar3.TabIndex = 13;
            // 
            // VooblyPic
            // 
            this.VooblyPic.BackColor = System.Drawing.Color.Transparent;
            this.VooblyPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.VooblyPic.Dock = System.Windows.Forms.DockStyle.Left;
            this.VooblyPic.Image = global::WindowsFormsApplication3.Properties.Resources.Voobly_Step1;
            this.VooblyPic.Location = new System.Drawing.Point(3, 2);
            this.VooblyPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VooblyPic.Name = "VooblyPic";
            this.VooblyPic.Size = new System.Drawing.Size(232, 66);
            this.VooblyPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.VooblyPic.TabIndex = 9;
            this.VooblyPic.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Image = global::WindowsFormsApplication3.Properties.Resources.Steam_Step2;
            this.pictureBox3.Location = new System.Drawing.Point(350, 2);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(232, 66);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 2);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(579, 6);
            this.progressBar1.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(585, 174);
            this.panel4.TabIndex = 30;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.2349F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.7651F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel11, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel12, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonCheckButton1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox10, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.42424F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.57576F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(585, 174);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.itsfree);
            this.panel7.Controls.Add(this.linkLabel1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(393, 35);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(88, 107);
            this.panel7.TabIndex = 42;
            // 
            // itsfree
            // 
            this.itsfree.AutoSize = true;
            this.itsfree.Enabled = false;
            this.itsfree.Location = new System.Drawing.Point(18, 59);
            this.itsfree.Name = "itsfree";
            this.itsfree.Size = new System.Drawing.Size(50, 17);
            this.itsfree.TabIndex = 39;
            this.itsfree.Text = "Voobly";
            this.itsfree.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(9, 31);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 18);
            this.linkLabel1.TabIndex = 38;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sign Up";
            this.linkLabel1.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.start);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(140, 35);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(247, 107);
            this.panel8.TabIndex = 43;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(63, 41);
            this.start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start.Name = "start";
            this.start.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.start.Size = new System.Drawing.Size(134, 35);
            this.start.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.TabIndex = 34;
            this.start.Values.Text = "Start!";
            this.start.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.monk);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(487, 35);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(95, 107);
            this.panel11.TabIndex = 44;
            // 
            // monk
            // 
            this.monk.Enabled = false;
            this.monk.Image = global::WindowsFormsApplication3.Properties.Resources.wololo;
            this.monk.Location = new System.Drawing.Point(3, 9);
            this.monk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.monk.Name = "monk";
            this.monk.Size = new System.Drawing.Size(69, 67);
            this.monk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.monk.TabIndex = 36;
            this.monk.TabStop = false;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.titlemonk);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(140, 3);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(247, 26);
            this.panel12.TabIndex = 45;
            // 
            // titlemonk
            // 
            this.titlemonk.AutoSize = true;
            this.titlemonk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlemonk.ForeColor = System.Drawing.Color.DimGray;
            this.titlemonk.Location = new System.Drawing.Point(6, 4);
            this.titlemonk.Name = "titlemonk";
            this.titlemonk.Size = new System.Drawing.Size(178, 20);
            this.titlemonk.TabIndex = 38;
            this.titlemonk.Text = "The Monk is Waiting ...";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(487, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 24);
            this.textBox1.TabIndex = 46;
            this.textBox1.Visible = false;
            // 
            // kryptonCheckButton1
            // 
            this.kryptonCheckButton1.AutoSize = true;
            this.kryptonCheckButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonCheckButton1.Checked = true;
            this.kryptonCheckButton1.Location = new System.Drawing.Point(487, 147);
            this.kryptonCheckButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonCheckButton1.Name = "kryptonCheckButton1";
            this.kryptonCheckButton1.Size = new System.Drawing.Size(28, 24);
            this.kryptonCheckButton1.StateCommon.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonCheckButton1.StateCommon.Back.Image = global::WindowsFormsApplication3.Properties.Resources.Vol_on;
            this.kryptonCheckButton1.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.kryptonCheckButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonCheckButton1.StateNormal.Back.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.kryptonCheckButton1.StateNormal.Back.Image = global::WindowsFormsApplication3.Properties.Resources.Vol_on;
            this.kryptonCheckButton1.TabIndex = 40;
            this.kryptonCheckButton1.Values.Image = global::WindowsFormsApplication3.Properties.Resources.vol_off;
            this.kryptonCheckButton1.Values.ImageStates.ImageCheckedNormal = global::WindowsFormsApplication3.Properties.Resources.vol_off;
            this.kryptonCheckButton1.Values.ImageStates.ImageCheckedPressed = global::WindowsFormsApplication3.Properties.Resources.vol_off;
            this.kryptonCheckButton1.Values.ImageStates.ImageCheckedTracking = global::WindowsFormsApplication3.Properties.Resources.vol_off;
            this.kryptonCheckButton1.Values.ImageStates.ImageNormal = global::WindowsFormsApplication3.Properties.Resources.Vol_on;
            this.kryptonCheckButton1.Values.ImageStates.ImagePressed = global::WindowsFormsApplication3.Properties.Resources.Vol_on;
            this.kryptonCheckButton1.Values.ImageStates.ImageTracking = global::WindowsFormsApplication3.Properties.Resources.Vol_on;
            this.kryptonCheckButton1.Values.Text = "";
            this.kryptonCheckButton1.Visible = false;
            this.kryptonCheckButton1.CheckedChanged += new System.EventHandler(this.kryptonCheckButton1_CheckedChanged);
            this.kryptonCheckButton1.Click += new System.EventHandler(this.kryptonCheckButton1_Click_1);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox10.Image = global::WindowsFormsApplication3.Properties.Resources.AoE2ToolsLogo_100;
            this.pictureBox10.Location = new System.Drawing.Point(3, 34);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(82, 108);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 35;
            this.pictureBox10.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.tableLayoutPanel5);
            this.panel3.Controls.Add(this.tableLayoutPanel4);
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 174);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 152);
            this.panel3.TabIndex = 32;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tableLayoutPanel5.Controls.Add(this.progressBar3, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.progressBar2, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 142);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(585, 10);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.91453F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.08547F));
            this.tableLayoutPanel4.Controls.Add(this.pictureBox4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pictureBox5, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(585, 62);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.progressBar1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(585, 10);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.25641F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.74359F));
            this.tableLayoutPanel2.Controls.Add(this.VooblyPic, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(585, 70);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // Conv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(585, 462);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Conv";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[HD To AoC] - AoE2Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Conv_FormClosing);
            this.Load += new System.EventHandler(this.Conv_Load);
            this.Shown += new System.EventHandler(this.Conv_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.hotkeysbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modsbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interfacebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundsbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparing)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VooblyPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monk)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private System.Windows.Forms.PictureBox preparing;
        private System.Windows.Forms.PictureBox soundsbox;
        private System.Windows.Forms.PictureBox interfacebox;
        private System.Windows.Forms.PictureBox modsbox;
        private System.Windows.Forms.PictureBox hotkeysbox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private System.Windows.Forms.PictureBox graphics;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton1;
        private System.Windows.Forms.PictureBox monk;
        private System.Windows.Forms.PictureBox pictureBox10;
        private ComponentFactory.Krypton.Toolkit.KryptonButton start;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox VooblyPic;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label itsfree;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label titlemonk;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
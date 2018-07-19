namespace WindowsFormsApplication3
{
    partial class VooblyMods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VooblyMods));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mskdwk = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.galasmodscenter = new System.Windows.Forms.LinkLabel();
            this.vooblymodscenter = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonDockableNavigator1 = new ComponentFactory.Krypton.Docking.KryptonDockableNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectvisual = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.delmod = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.exportvisual = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.importvisual = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chkboxvoob = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.datamods = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.selectdata = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.exportdata = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.importdata = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPage3 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.gamepatches = new ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.selectpatches = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.delpatch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.exportpatches = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.importpatches = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.modscount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).BeginInit();
            this.kryptonDockableNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "mod-32.png");
            // 
            // mskdwk
            // 
            this.mskdwk.Location = new System.Drawing.Point(850, 37);
            this.mskdwk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskdwk.Name = "mskdwk";
            this.mskdwk.Size = new System.Drawing.Size(21, 24);
            this.mskdwk.TabIndex = 1;
            this.mskdwk.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(766, 0);
            this.panel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.galasmodscenter);
            this.groupBox1.Controls.Add(this.vooblymodscenter);
            this.groupBox1.Controls.Add(this.mskdwk);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 520);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(766, 66);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mod Workshops";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(250, 31);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(109, 17);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Obscvreds Mods";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.galasmodscenter_LinkClicked);
            // 
            // galasmodscenter
            // 
            this.galasmodscenter.AutoSize = true;
            this.galasmodscenter.Location = new System.Drawing.Point(147, 31);
            this.galasmodscenter.Name = "galasmodscenter";
            this.galasmodscenter.Size = new System.Drawing.Size(77, 17);
            this.galasmodscenter.TabIndex = 0;
            this.galasmodscenter.TabStop = true;
            this.galasmodscenter.Text = "Gallas Mods";
            this.galasmodscenter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.galasmodscenter_LinkClicked);
            // 
            // vooblymodscenter
            // 
            this.vooblymodscenter.AutoSize = true;
            this.vooblymodscenter.Location = new System.Drawing.Point(9, 31);
            this.vooblymodscenter.Name = "vooblymodscenter";
            this.vooblymodscenter.Size = new System.Drawing.Size(118, 17);
            this.vooblymodscenter.TabIndex = 0;
            this.vooblymodscenter.TabStop = true;
            this.vooblymodscenter.Text = "Voobly Workshop";
            this.vooblymodscenter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.vooblymodscenter_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.kryptonDockableNavigator1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 433);
            this.panel2.TabIndex = 13;
            // 
            // kryptonDockableNavigator1
            // 
            this.kryptonDockableNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.kryptonDockableNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDockableNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDockableNavigator1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonDockableNavigator1.Name = "kryptonDockableNavigator1";
            this.kryptonDockableNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3});
            this.kryptonDockableNavigator1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonDockableNavigator1.SelectedIndex = 2;
            this.kryptonDockableNavigator1.Size = new System.Drawing.Size(766, 433);
            this.kryptonDockableNavigator1.TabIndex = 11;
            this.kryptonDockableNavigator1.Text = "kryptonDockableNavigator1";
            this.kryptonDockableNavigator1.SelectedPageChanged += new System.EventHandler(this.kryptonDockableNavigator1_SelectedPageChanged);
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.panel5);
            this.kryptonPage1.Controls.Add(this.chkboxvoob);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(766, 400);
            this.kryptonPage1.Text = "Visual Mods";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "4DE748007837421B4E8ACF3B01701D9D";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 337);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(766, 63);
            this.panel5.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.68853F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.31147F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 363F));
            this.tableLayoutPanel1.Controls.Add(this.selectvisual, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.delmod, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.exportvisual, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.importvisual, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(766, 63);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // selectvisual
            // 
            this.selectvisual.Dock = System.Windows.Forms.DockStyle.Left;
            this.selectvisual.Location = new System.Drawing.Point(3, 4);
            this.selectvisual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectvisual.Name = "selectvisual";
            this.selectvisual.Size = new System.Drawing.Size(87, 55);
            this.selectvisual.TabIndex = 0;
            this.selectvisual.Values.Text = "Select All";
            this.selectvisual.CheckedChanged += new System.EventHandler(this.selectvisual_CheckedChanged);
            // 
            // delmod
            // 
            this.delmod.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.delmod.Dock = System.Windows.Forms.DockStyle.Left;
            this.delmod.Location = new System.Drawing.Point(405, 4);
            this.delmod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.delmod.Name = "delmod";
            this.delmod.Size = new System.Drawing.Size(119, 55);
            this.delmod.TabIndex = 1;
            this.delmod.Values.Image = global::WindowsFormsApplication3.Properties.Resources.delete;
            this.delmod.Values.Text = "Delete";
            this.delmod.Click += new System.EventHandler(this.delmod_Click);
            // 
            // exportvisual
            // 
            this.exportvisual.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.exportvisual.Dock = System.Windows.Forms.DockStyle.Left;
            this.exportvisual.Location = new System.Drawing.Point(279, 4);
            this.exportvisual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportvisual.Name = "exportvisual";
            this.exportvisual.Size = new System.Drawing.Size(119, 55);
            this.exportvisual.TabIndex = 1;
            this.exportvisual.Values.Image = global::WindowsFormsApplication3.Properties.Resources.Save;
            this.exportvisual.Values.Text = "Export";
            this.exportvisual.Click += new System.EventHandler(this.exportvisual_Click);
            // 
            // importvisual
            // 
            this.importvisual.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.importvisual.Dock = System.Windows.Forms.DockStyle.Left;
            this.importvisual.Location = new System.Drawing.Point(151, 4);
            this.importvisual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importvisual.Name = "importvisual";
            this.importvisual.Size = new System.Drawing.Size(119, 55);
            this.importvisual.TabIndex = 1;
            this.importvisual.Values.Image = global::WindowsFormsApplication3.Properties.Resources.import_27;
            this.importvisual.Values.Text = "Import";
            this.importvisual.Click += new System.EventHandler(this.importvisual_Click);
            // 
            // chkboxvoob
            // 
            this.chkboxvoob.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkboxvoob.Location = new System.Drawing.Point(0, 0);
            this.chkboxvoob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkboxvoob.Name = "chkboxvoob";
            this.chkboxvoob.Size = new System.Drawing.Size(766, 337);
            this.chkboxvoob.TabIndex = 0;
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.datamods);
            this.kryptonPage2.Controls.Add(this.panel6);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(766, 400);
            this.kryptonPage2.Text = "Data Mods";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "4A0AF4F523244E084E8C7A07DC4E2D0A";
            // 
            // datamods
            // 
            this.datamods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datamods.Location = new System.Drawing.Point(0, 0);
            this.datamods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.datamods.Name = "datamods";
            this.datamods.Size = new System.Drawing.Size(766, 337);
            this.datamods.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 337);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(766, 63);
            this.panel6.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.68853F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.31147F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 363F));
            this.tableLayoutPanel2.Controls.Add(this.selectdata, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonButton4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.exportdata, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.importdata, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(766, 63);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // selectdata
            // 
            this.selectdata.Dock = System.Windows.Forms.DockStyle.Left;
            this.selectdata.Location = new System.Drawing.Point(3, 4);
            this.selectdata.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectdata.Name = "selectdata";
            this.selectdata.Size = new System.Drawing.Size(87, 55);
            this.selectdata.TabIndex = 0;
            this.selectdata.Values.Text = "Select All";
            this.selectdata.CheckedChanged += new System.EventHandler(this.selectdata_CheckedChanged);
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton4.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonButton4.Location = new System.Drawing.Point(405, 4);
            this.kryptonButton4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(119, 55);
            this.kryptonButton4.TabIndex = 1;
            this.kryptonButton4.Values.Image = global::WindowsFormsApplication3.Properties.Resources.delete;
            this.kryptonButton4.Values.Text = "Delete";
            this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton5_Click);
            // 
            // exportdata
            // 
            this.exportdata.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.exportdata.Dock = System.Windows.Forms.DockStyle.Left;
            this.exportdata.Location = new System.Drawing.Point(279, 4);
            this.exportdata.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportdata.Name = "exportdata";
            this.exportdata.Size = new System.Drawing.Size(119, 55);
            this.exportdata.TabIndex = 1;
            this.exportdata.Values.Image = global::WindowsFormsApplication3.Properties.Resources.Save;
            this.exportdata.Values.Text = "Export";
            this.exportdata.Click += new System.EventHandler(this.exportdata_Click);
            // 
            // importdata
            // 
            this.importdata.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.importdata.Dock = System.Windows.Forms.DockStyle.Left;
            this.importdata.Location = new System.Drawing.Point(151, 4);
            this.importdata.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importdata.Name = "importdata";
            this.importdata.Size = new System.Drawing.Size(119, 55);
            this.importdata.TabIndex = 1;
            this.importdata.Values.Image = global::WindowsFormsApplication3.Properties.Resources.import_27;
            this.importdata.Values.Text = "Import";
            this.importdata.Click += new System.EventHandler(this.importdata_Click);
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.gamepatches);
            this.kryptonPage3.Controls.Add(this.panel7);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(764, 402);
            this.kryptonPage3.Text = "Game Patches";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "93983603CE92435CF0BD2AB6ADA87EE5";
            // 
            // gamepatches
            // 
            this.gamepatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamepatches.Location = new System.Drawing.Point(0, 0);
            this.gamepatches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gamepatches.Name = "gamepatches";
            this.gamepatches.Size = new System.Drawing.Size(764, 339);
            this.gamepatches.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tableLayoutPanel3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 339);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(764, 63);
            this.panel7.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.68853F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.31147F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 363F));
            this.tableLayoutPanel3.Controls.Add(this.selectpatches, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.delpatch, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.exportpatches, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.importpatches, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(764, 63);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // selectpatches
            // 
            this.selectpatches.Dock = System.Windows.Forms.DockStyle.Left;
            this.selectpatches.Location = new System.Drawing.Point(3, 4);
            this.selectpatches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectpatches.Name = "selectpatches";
            this.selectpatches.Size = new System.Drawing.Size(87, 55);
            this.selectpatches.TabIndex = 0;
            this.selectpatches.Values.Text = "Select All";
            this.selectpatches.CheckedChanged += new System.EventHandler(this.selectpatches_CheckedChanged);
            // 
            // delpatch
            // 
            this.delpatch.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.delpatch.Dock = System.Windows.Forms.DockStyle.Left;
            this.delpatch.Location = new System.Drawing.Point(403, 4);
            this.delpatch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.delpatch.Name = "delpatch";
            this.delpatch.Size = new System.Drawing.Size(119, 55);
            this.delpatch.TabIndex = 1;
            this.delpatch.Values.Image = global::WindowsFormsApplication3.Properties.Resources.delete;
            this.delpatch.Values.Text = "Delete";
            this.delpatch.Click += new System.EventHandler(this.delpatch_Click);
            // 
            // exportpatches
            // 
            this.exportpatches.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.exportpatches.Dock = System.Windows.Forms.DockStyle.Left;
            this.exportpatches.Location = new System.Drawing.Point(277, 4);
            this.exportpatches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportpatches.Name = "exportpatches";
            this.exportpatches.Size = new System.Drawing.Size(119, 55);
            this.exportpatches.TabIndex = 1;
            this.exportpatches.Values.Image = global::WindowsFormsApplication3.Properties.Resources.Save;
            this.exportpatches.Values.Text = "Export";
            this.exportpatches.Click += new System.EventHandler(this.exportpatches_Click);
            // 
            // importpatches
            // 
            this.importpatches.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.importpatches.Dock = System.Windows.Forms.DockStyle.Left;
            this.importpatches.Location = new System.Drawing.Point(150, 4);
            this.importpatches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importpatches.Name = "importpatches";
            this.importpatches.Size = new System.Drawing.Size(119, 55);
            this.importpatches.TabIndex = 1;
            this.importpatches.Values.Image = global::WindowsFormsApplication3.Properties.Resources.import_27;
            this.importpatches.Values.Text = "Import";
            this.importpatches.Click += new System.EventHandler(this.importpatches_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.progressBar2);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.modscount);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(-3, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(769, 87);
            this.panel3.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApplication3.Properties.Resources.archiveit1;
            this.pictureBox2.Location = new System.Drawing.Point(474, 22);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(511, 37);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(244, 10);
            this.progressBar2.TabIndex = 16;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(511, 22);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(244, 10);
            this.progressBar1.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication3.Properties.Resources.voobly;
            this.pictureBox1.Location = new System.Drawing.Point(26, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // modscount
            // 
            this.modscount.AutoSize = true;
            this.modscount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modscount.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.modscount.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.modscount.Location = new System.Drawing.Point(54, 30);
            this.modscount.Margin = new System.Windows.Forms.Padding(0);
            this.modscount.Name = "modscount";
            this.modscount.Size = new System.Drawing.Size(18, 18);
            this.modscount.TabIndex = 13;
            this.modscount.Text = "0";
            this.modscount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(0, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Installed Voobly Mods";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 77);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 10);
            this.panel4.TabIndex = 15;
            // 
            // VooblyMods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(766, 586);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(784, 633);
            this.MinimumSize = new System.Drawing.Size(784, 633);
            this.Name = "VooblyMods";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AoE2Tools [#Voobly Mods Manager]";
            this.Load += new System.EventHandler(this.VooblyMods_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).EndInit();
            this.kryptonDockableNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TextBox mskdwk;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel vooblymodscenter;
        private System.Windows.Forms.LinkLabel galasmodscenter;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Docking.KryptonDockableNavigator kryptonDockableNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label modscount;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox chkboxvoob;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox selectvisual;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox gamepatches;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckedListBox datamods;
        private ComponentFactory.Krypton.Toolkit.KryptonButton delmod;
        private ComponentFactory.Krypton.Toolkit.KryptonButton exportvisual;
        private ComponentFactory.Krypton.Toolkit.KryptonButton importvisual;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox selectdata;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton exportdata;
        private ComponentFactory.Krypton.Toolkit.KryptonButton importdata;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox selectpatches;
        private ComponentFactory.Krypton.Toolkit.KryptonButton delpatch;
        private ComponentFactory.Krypton.Toolkit.KryptonButton exportpatches;
        private ComponentFactory.Krypton.Toolkit.KryptonButton importpatches;
    }
}
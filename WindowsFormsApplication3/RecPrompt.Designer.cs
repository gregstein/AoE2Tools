namespace WindowsFormsApplication3
{
    partial class RecPrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecPrompt));
            this.recfield = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.recchoice = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.mskdpath = new System.Windows.Forms.TextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Player7 = new System.Windows.Forms.Label();
            this.Player5 = new System.Windows.Forms.Label();
            this.Player3 = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.Player8 = new System.Windows.Forms.Label();
            this.Player6 = new System.Windows.Forms.Label();
            this.Player4 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.kryptonSeparator1 = new ComponentFactory.Krypton.Toolkit.KryptonSeparator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gamever = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.afxit = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.watchrec = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.oldfilen = new System.Windows.Forms.TextBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.recchoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gamever)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // recfield
            // 
            this.recfield.AllowButtonSpecToolTips = true;
            this.recfield.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.recfield.Location = new System.Drawing.Point(110, 2);
            this.recfield.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recfield.MinimumSize = new System.Drawing.Size(0, 25);
            this.recfield.Name = "recfield";
            this.recfield.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.recfield.Size = new System.Drawing.Size(205, 25);
            this.recfield.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.recfield.StateCommon.Content.Font = new System.Drawing.Font("Tahoma", 10F);
            this.recfield.StateNormal.Content.Font = new System.Drawing.Font("Tahoma", 10F);
            this.recfield.TabIndex = 0;
            this.recfield.Text = "New Replay Name";
            this.recfield.TextChanged += new System.EventHandler(this.recfield_TextChanged);
            this.recfield.Click += new System.EventHandler(this.recfield_TextChanged);
            this.recfield.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.recfield_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(321, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = ".mgz";
            // 
            // recchoice
            // 
            this.recchoice.DropBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlRibbonAppMenu;
            this.recchoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recchoice.DropDownWidth = 179;
            this.recchoice.Enabled = false;
            this.recchoice.Items.AddRange(new object[] {
            "Save Replay",
            "Don\'t Save!"});
            this.recchoice.Location = new System.Drawing.Point(392, 119);
            this.recchoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recchoice.MinimumSize = new System.Drawing.Size(0, 20);
            this.recchoice.Name = "recchoice";
            this.recchoice.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.recchoice.Size = new System.Drawing.Size(87, 21);
            this.recchoice.StateActive.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.recchoice.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recchoice.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.recchoice.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recchoice.StateNormal.ComboBox.Content.Color1 = System.Drawing.Color.Black;
            this.recchoice.StateNormal.Item.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.recchoice.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.recchoice.StateTracking.Item.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.recchoice.TabIndex = 2;
            this.recchoice.Text = "Save Replay";
            this.recchoice.Visible = false;
            this.recchoice.SelectedIndexChanged += new System.EventHandler(this.recchoice_SelectedIndexChanged);
            // 
            // mskdpath
            // 
            this.mskdpath.Location = new System.Drawing.Point(159, 230);
            this.mskdpath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mskdpath.Name = "mskdpath";
            this.mskdpath.Size = new System.Drawing.Size(16, 20);
            this.mskdpath.TabIndex = 27;
            this.mskdpath.Visible = false;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 2);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(68, 18);
            this.kryptonLabel3.StateNormal.ShortText.Color1 = System.Drawing.SystemColors.Desktop;
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 16;
            this.kryptonLabel3.Values.Text = "Rename?";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.AutoSize = true;
            this.kryptonGroupBox1.CaptionOrientation = ComponentFactory.Krypton.Toolkit.ButtonOrientation.FixedTop;
            this.kryptonGroupBox1.CaptionOverlap = 1D;
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabDockAutoHidden;
            this.kryptonGroupBox1.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ContextMenuSeparator;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            this.kryptonGroupBox1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonSeparator1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.panel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.recchoice);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(382, 224);
            this.kryptonGroupBox1.TabIndex = 28;
            this.kryptonGroupBox1.Values.Heading = "Customize Your Replay";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.87261F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.12739F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel3.Controls.Add(this.Player7, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.Player5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.Player3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.Player1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Player8, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.Player6, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.Player4, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.Player2, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 8);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(382, 76);
            this.tableLayoutPanel3.TabIndex = 33;
            // 
            // Player7
            // 
            this.Player7.AutoSize = true;
            this.Player7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Player7.Location = new System.Drawing.Point(3, 60);
            this.Player7.Name = "Player7";
            this.Player7.Size = new System.Drawing.Size(61, 14);
            this.Player7.TabIndex = 0;
            this.Player7.Text = "Loading...";
            // 
            // Player5
            // 
            this.Player5.AutoSize = true;
            this.Player5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Player5.Location = new System.Drawing.Point(3, 44);
            this.Player5.Name = "Player5";
            this.Player5.Size = new System.Drawing.Size(61, 14);
            this.Player5.TabIndex = 0;
            this.Player5.Text = "Loading...";
            // 
            // Player3
            // 
            this.Player3.AutoSize = true;
            this.Player3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Player3.Location = new System.Drawing.Point(3, 28);
            this.Player3.Name = "Player3";
            this.Player3.Size = new System.Drawing.Size(61, 14);
            this.Player3.TabIndex = 0;
            this.Player3.Text = "Loading...";
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Player1.Location = new System.Drawing.Point(3, 14);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(61, 14);
            this.Player1.TabIndex = 0;
            this.Player1.Text = "Loading...";
            // 
            // Player8
            // 
            this.Player8.AutoSize = true;
            this.Player8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Player8.Location = new System.Drawing.Point(223, 60);
            this.Player8.Name = "Player8";
            this.Player8.Size = new System.Drawing.Size(61, 14);
            this.Player8.TabIndex = 0;
            this.Player8.Text = "Loading...";
            // 
            // Player6
            // 
            this.Player6.AutoSize = true;
            this.Player6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Player6.Location = new System.Drawing.Point(223, 44);
            this.Player6.Name = "Player6";
            this.Player6.Size = new System.Drawing.Size(61, 14);
            this.Player6.TabIndex = 0;
            this.Player6.Text = "Loading...";
            // 
            // Player4
            // 
            this.Player4.AutoSize = true;
            this.Player4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Player4.Location = new System.Drawing.Point(223, 28);
            this.Player4.Name = "Player4";
            this.Player4.Size = new System.Drawing.Size(61, 14);
            this.Player4.TabIndex = 0;
            this.Player4.Text = "Loading...";
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Player2.Location = new System.Drawing.Point(223, 14);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(61, 14);
            this.Player2.TabIndex = 0;
            this.Player2.Text = "Loading...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "Team 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(223, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Team 2";
            // 
            // kryptonSeparator1
            // 
            this.kryptonSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonSeparator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSeparator1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonSeparator1.Name = "kryptonSeparator1";
            this.kryptonSeparator1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.kryptonSeparator1.Size = new System.Drawing.Size(382, 8);
            this.kryptonSeparator1.TabIndex = 32;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.85093F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.14907F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.recfield, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gamever, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.afxit, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 87);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 58);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // gamever
            // 
            this.gamever.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gamever.DropDownWidth = 71;
            this.gamever.Items.AddRange(new object[] {
            "WK 5.8.1",
            "WK 5.7.4",
            "WK 5.7.2",
            "1.5 RC",
            "1.4 RC",
            "1.0 C"});
            this.gamever.Location = new System.Drawing.Point(110, 31);
            this.gamever.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gamever.MinimumSize = new System.Drawing.Size(0, 20);
            this.gamever.Name = "gamever";
            this.gamever.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.gamever.Size = new System.Drawing.Size(82, 20);
            this.gamever.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gamever.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gamever.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gamever.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Tahoma", 10.8F);
            this.gamever.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 10.8F);
            this.gamever.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gamever.TabIndex = 29;
            this.gamever.Text = "WK 5.8.1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 31);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(62, 18);
            this.kryptonLabel1.StateNormal.ShortText.Color1 = System.Drawing.SystemColors.Desktop;
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 16;
            this.kryptonLabel1.Values.Text = "Version:";
            // 
            // afxit
            // 
            this.afxit.Location = new System.Drawing.Point(321, 32);
            this.afxit.Name = "afxit";
            this.afxit.Size = new System.Drawing.Size(10, 20);
            this.afxit.TabIndex = 30;
            this.afxit.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.kryptonButton2);
            this.panel1.Controls.Add(this.kryptonButton1);
            this.panel1.Controls.Add(this.watchrec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 50);
            this.panel1.TabIndex = 30;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonButton2.Location = new System.Drawing.Point(247, 0);
            this.kryptonButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonButton2.Size = new System.Drawing.Size(83, 50);
            this.kryptonButton2.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton2.TabIndex = 4;
            this.kryptonButton2.Values.Image = global::WindowsFormsApplication3.Properties.Resources.stop_30x30;
            this.kryptonButton2.Values.Text = "Close";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click_1);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonButton1.Location = new System.Drawing.Point(157, 0);
            this.kryptonButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.kryptonButton1.Size = new System.Drawing.Size(90, 50);
            this.kryptonButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 5;
            this.kryptonButton1.Values.Image = global::WindowsFormsApplication3.Properties.Resources.delete_30x30;
            this.kryptonButton1.Values.Text = "Delete";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // watchrec
            // 
            this.watchrec.AutoSize = true;
            this.watchrec.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.watchrec.Dock = System.Windows.Forms.DockStyle.Left;
            this.watchrec.Location = new System.Drawing.Point(0, 0);
            this.watchrec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.watchrec.Name = "watchrec";
            this.watchrec.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.watchrec.Size = new System.Drawing.Size(157, 50);
            this.watchrec.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchrec.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchrec.TabIndex = 6;
            this.watchrec.Values.Image = global::WindowsFormsApplication3.Properties.Resources.play_30x30;
            this.watchrec.Values.Text = "Watch && Rename";
            this.watchrec.Click += new System.EventHandler(this.watchrec_Click);
            // 
            // oldfilen
            // 
            this.oldfilen.Location = new System.Drawing.Point(435, 216);
            this.oldfilen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.oldfilen.Name = "oldfilen";
            this.oldfilen.Size = new System.Drawing.Size(44, 20);
            this.oldfilen.TabIndex = 29;
            this.oldfilen.Visible = false;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(382, 224);
            this.kryptonPanel1.TabIndex = 30;
            // 
            // RecPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 224);
            this.Controls.Add(this.oldfilen);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.mskdpath);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RecPrompt";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replay Ready!";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RecPrompt_FormClosed);
            this.Load += new System.EventHandler(this.RecPrompt_Load);
            this.Leave += new System.EventHandler(this.RecPrompt_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.recchoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gamever)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox recfield;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox recchoice;
        private System.Windows.Forms.TextBox mskdpath;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox gamever;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.TextBox oldfilen;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton watchrec;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonSeparator kryptonSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label Player7;
        private System.Windows.Forms.Label Player5;
        private System.Windows.Forms.Label Player3;
        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Label Player8;
        private System.Windows.Forms.Label Player6;
        private System.Windows.Forms.Label Player4;
        private System.Windows.Forms.Label Player2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox afxit;
    }
}
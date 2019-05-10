namespace WindowsFormsApplication3
{
    partial class DrVoobly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrVoobly));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonSeparator1 = new ComponentFactory.Krypton.Toolkit.KryptonSeparator();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.portlbl = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.fixport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.checkport = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.VDOC = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VDOC)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel1.Controls.Add(this.kryptonHeader1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonPanel1.Size = new System.Drawing.Size(460, 194);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.kryptonSeparator1);
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel3);
            this.flowLayoutPanel1.Controls.Add(this.portlbl);
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel1.Controls.Add(this.fixport);
            this.flowLayoutPanel1.Controls.Add(this.checkport);
            this.flowLayoutPanel1.Controls.Add(this.VDOC);
            this.flowLayoutPanel1.Controls.Add(this.kryptonButton1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(460, 144);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // kryptonSeparator1
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.kryptonSeparator1, true);
            this.kryptonSeparator1.Location = new System.Drawing.Point(3, 3);
            this.kryptonSeparator1.Name = "kryptonSeparator1";
            this.kryptonSeparator1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonSeparator1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.Custom1;
            this.kryptonSeparator1.Size = new System.Drawing.Size(443, 10);
            this.kryptonSeparator1.TabIndex = 4;
            this.kryptonSeparator1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.kryptonSeparator1_SplitterMoved);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(3, 19);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(94, 20);
            this.kryptonLabel3.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 10;
            this.kryptonLabel3.Values.Text = "Voobly Port: ";
            // 
            // portlbl
            // 
            this.portlbl.Enabled = false;
            this.flowLayoutPanel1.SetFlowBreak(this.portlbl, true);
            this.portlbl.Location = new System.Drawing.Point(103, 19);
            this.portlbl.Name = "portlbl";
            this.portlbl.Size = new System.Drawing.Size(98, 20);
            this.portlbl.StateNormal.ShortText.Color1 = System.Drawing.Color.Green;
            this.portlbl.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portlbl.TabIndex = 11;
            this.portlbl.Values.Text = "16000 (UDP)";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 45);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(161, 20);
            this.kryptonLabel1.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "Auto Port Forwarding: ";
            // 
            // fixport
            // 
            this.fixport.AutoSize = true;
            this.fixport.Location = new System.Drawing.Point(170, 45);
            this.fixport.Name = "fixport";
            this.fixport.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.fixport.Size = new System.Drawing.Size(61, 22);
            this.fixport.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.fixport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.fixport.StateNormal.Content.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.fixport.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixport.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.fixport.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.fixport.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.Maroon;
            this.fixport.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.fixport.TabIndex = 12;
            this.fixport.Values.Text = "Fix Now";
            this.fixport.Click += new System.EventHandler(this.fixport_Click);
            // 
            // checkport
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.checkport, true);
            this.checkport.Location = new System.Drawing.Point(237, 45);
            this.checkport.Name = "checkport";
            this.checkport.Size = new System.Drawing.Size(46, 20);
            this.checkport.StateNormal.ShortText.Color1 = System.Drawing.Color.Green;
            this.checkport.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkport.TabIndex = 9;
            this.checkport.Values.Text = "Open";
            this.checkport.Visible = false;
            // 
            // VDOC
            // 
            this.VDOC.DropDownWidth = 329;
            this.VDOC.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Custom1;
            this.VDOC.Items.AddRange(new object[] {
            "(+) Voobly Issues",
            "------------------",
            "Voobly Game Room Settings",
            "Voobly Game Room - Enable Wololokingdoms Mod",
            "Fix Voobly Messenger Chat Window",
            "Clear Voobly Game Room Title & Settings",
            "----------------",
            "(+) Game Resolution",
            "----------------",
            "Auto Set Game Resolution To Desktop\'s",
            "Set Game Resolution To 1920x1080",
            "Set Game Resolution To 1920x1200",
            "Set Game Resolution To 1680x1080",
            "Set Game Resolution To 1680x1050",
            "Set Game Resolution To 1600x900",
            "Set Game Resolution To 1400x1050",
            "Set Game Resolution To 1440x900",
            "Set Game Resolution To 1280x1024",
            "-----------------------------",
            "(+) Age of Empires 2 Issues",
            "-----------------------------",
            "Fix Couldn\'t Display Or DirectDraw Display Error",
            "Enable Advanced Command Buttons"});
            this.VDOC.Location = new System.Drawing.Point(3, 73);
            this.VDOC.Name = "VDOC";
            this.VDOC.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.VDOC.Size = new System.Drawing.Size(329, 21);
            this.VDOC.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9F);
            this.VDOC.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VDOC.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VDOC.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VDOC.TabIndex = 7;
            this.VDOC.Text = "Choose a Problem/Setting";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(3, 100);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonButton1.Size = new System.Drawing.Size(122, 25);
            this.kryptonButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 6;
            this.kryptonButton1.Values.Text = "Apply Fix";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonHeader1.Size = new System.Drawing.Size(460, 50);
            this.kryptonHeader1.TabIndex = 1;
            this.kryptonHeader1.Values.Description = "(OneClick Fix Voobly/Game Issues)";
            this.kryptonHeader1.Values.Heading = "Voobly Medkit";
            this.kryptonHeader1.Values.Image = global::WindowsFormsApplication3.Properties.Resources.vooblyvaccine;
            // 
            // DrVoobly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 194);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DrVoobly";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.Text = "[Voobly Medkit] - AoE2Tools";
            this.Load += new System.EventHandler(this.DrVoobly_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VDOC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonSeparator kryptonSeparator1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel portlbl;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel checkport;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox VDOC;
        private ComponentFactory.Krypton.Toolkit.KryptonButton fixport;
    }
}
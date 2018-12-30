namespace Launcher
{
    partial class LnchR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LnchR));
            this.LauncherCheck = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.resetaoe2tools = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonCheckBox1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.enbhdtoaoc = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.start = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.scanfirst = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.convert = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.getaoepath = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LauncherCheck
            // 
            this.LauncherCheck.WorkerReportsProgress = true;
            this.LauncherCheck.WorkerSupportsCancellation = true;
            this.LauncherCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LauncherCheck_DoWork);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Launcher.Properties.Resources.launcherAoE2Tools;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.getaoepath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 350);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(381, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 248);
            this.panel3.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.resetaoe2tools);
            this.panel6.Controls.Add(this.kryptonCheckBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 148);
            this.panel6.TabIndex = 1;
            // 
            // resetaoe2tools
            // 
            this.resetaoe2tools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetaoe2tools.AutoSize = true;
            this.resetaoe2tools.Enabled = false;
            this.resetaoe2tools.Location = new System.Drawing.Point(25, 2);
            this.resetaoe2tools.Name = "resetaoe2tools";
            this.resetaoe2tools.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.resetaoe2tools.Size = new System.Drawing.Size(126, 30);
            this.resetaoe2tools.TabIndex = 11;
            this.resetaoe2tools.Values.Image = global::Launcher.Properties.Resources.Refresh_24x24;
            this.resetaoe2tools.Values.Text = "Reset AoE2Tools";
            this.resetaoe2tools.Click += new System.EventHandler(this.resetaoe2tools_Click);
            // 
            // kryptonCheckBox1
            // 
            this.kryptonCheckBox1.Location = new System.Drawing.Point(43, 35);
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Size = new System.Drawing.Size(93, 20);
            this.kryptonCheckBox1.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonCheckBox1.TabIndex = 12;
            this.kryptonCheckBox1.Values.Text = "Enable Reset";
            this.kryptonCheckBox1.CheckedChanged += new System.EventHandler(this.kryptonCheckBox1_CheckedChanged);
            this.kryptonCheckBox1.Click += new System.EventHandler(this.kryptonCheckBox1_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseMove);
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::Launcher.Properties.Resources.launcher_close1;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(75, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(125, 100);
            this.panel5.TabIndex = 0;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            this.panel5.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            this.panel5.MouseHover += new System.EventHandler(this.panel5_MouseHover);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.enbhdtoaoc);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.start);
            this.panel2.Controls.Add(this.scanfirst);
            this.panel2.Controls.Add(this.convert);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(581, 102);
            this.panel2.TabIndex = 0;
            // 
            // enbhdtoaoc
            // 
            this.enbhdtoaoc.Location = new System.Drawing.Point(63, 79);
            this.enbhdtoaoc.Name = "enbhdtoaoc";
            this.enbhdtoaoc.Size = new System.Drawing.Size(124, 20);
            this.enbhdtoaoc.StateNormal.ShortText.Color1 = System.Drawing.Color.White;
            this.enbhdtoaoc.TabIndex = 7;
            this.enbhdtoaoc.Values.Text = "Enable HD To AoC";
            this.enbhdtoaoc.CheckedChanged += new System.EventHandler(this.enbhdtoaoc_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Launcher.Properties.Resources.preload;
            this.pictureBox1.Location = new System.Drawing.Point(273, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.start.Enabled = false;
            this.start.Location = new System.Drawing.Point(406, 46);
            this.start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start.Name = "start";
            this.start.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange;
            this.start.Size = new System.Drawing.Size(126, 32);
            this.start.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.start.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.start.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.start.TabIndex = 5;
            this.start.Values.Text = "2. Start";
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // scanfirst
            // 
            this.scanfirst.AutoSize = true;
            this.scanfirst.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Alternate;
            this.scanfirst.Location = new System.Drawing.Point(236, 46);
            this.scanfirst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scanfirst.Name = "scanfirst";
            this.scanfirst.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange;
            this.scanfirst.Size = new System.Drawing.Size(112, 32);
            this.scanfirst.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.scanfirst.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanfirst.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.scanfirst.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.scanfirst.TabIndex = 4;
            this.scanfirst.Values.Text = "SCAN FIRST!";
            this.scanfirst.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // convert
            // 
            this.convert.AutoSize = true;
            this.convert.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.NavigatorMini;
            this.convert.Enabled = false;
            this.convert.Location = new System.Drawing.Point(57, 46);
            this.convert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.convert.Name = "convert";
            this.convert.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange;
            this.convert.Size = new System.Drawing.Size(134, 32);
            this.convert.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.convert.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convert.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.convert.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.convert.TabIndex = 4;
            this.convert.Values.Text = "1. Convert";
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // getaoepath
            // 
            this.getaoepath.Location = new System.Drawing.Point(276, 11);
            this.getaoepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getaoepath.Name = "getaoepath";
            this.getaoepath.Size = new System.Drawing.Size(32, 20);
            this.getaoepath.TabIndex = 6;
            this.getaoepath.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // LnchR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(581, 350);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LnchR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher - AoE2Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LnchR_FormClosing);
            this.Load += new System.EventHandler(this.LnchR_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker LauncherCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox getaoepath;
        private ComponentFactory.Krypton.Toolkit.KryptonButton convert;
        private ComponentFactory.Krypton.Toolkit.KryptonButton start;
        private ComponentFactory.Krypton.Toolkit.KryptonButton scanfirst;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox enbhdtoaoc;
        private System.Windows.Forms.Panel panel6;
        private ComponentFactory.Krypton.Toolkit.KryptonButton resetaoe2tools;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
    }
}
namespace WindowsFormsApplication3
{
    partial class EditStream
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditStream));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lstcust = new System.Windows.Forms.RadioButton();
            this.txbcustom = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.playsound = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnaddstream = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.flowLayoutPanel4);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(275, 152);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel4.Controls.Add(this.kryptonGroupBox1);
            this.flowLayoutPanel4.Controls.Add(this.btnaddstream);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(275, 152);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionOverlap = 1D;
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonGroupBox1.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.TabOneNote;
            this.kryptonGroupBox1.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ContextMenuHeading;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.flowLayoutPanel5);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(268, 107);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Streamer Options";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel5.Controls.Add(this.lstcust);
            this.flowLayoutPanel5.Controls.Add(this.txbcustom);
            this.flowLayoutPanel5.Controls.Add(this.playsound);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(268, 86);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // lstcust
            // 
            this.lstcust.AutoSize = true;
            this.lstcust.BackColor = System.Drawing.Color.Transparent;
            this.lstcust.Checked = true;
            this.lstcust.Location = new System.Drawing.Point(3, 3);
            this.lstcust.Name = "lstcust";
            this.lstcust.Size = new System.Drawing.Size(99, 17);
            this.lstcust.TabIndex = 3;
            this.lstcust.TabStop = true;
            this.lstcust.Text = "Streamer Name";
            this.lstcust.UseVisualStyleBackColor = false;
            // 
            // txbcustom
            // 
            this.txbcustom.Enabled = false;
            this.txbcustom.Location = new System.Drawing.Point(108, 3);
            this.txbcustom.Name = "txbcustom";
            this.txbcustom.Size = new System.Drawing.Size(138, 20);
            this.txbcustom.TabIndex = 5;
            // 
            // playsound
            // 
            this.playsound.Location = new System.Drawing.Point(3, 29);
            this.playsound.Name = "playsound";
            this.playsound.Size = new System.Drawing.Size(84, 20);
            this.playsound.TabIndex = 6;
            this.playsound.Values.Text = "Play Sound";
            // 
            // btnaddstream
            // 
            this.btnaddstream.Location = new System.Drawing.Point(3, 116);
            this.btnaddstream.Name = "btnaddstream";
            this.btnaddstream.Size = new System.Drawing.Size(268, 25);
            this.btnaddstream.TabIndex = 1;
            this.btnaddstream.Values.Text = "Edit Streamer";
            this.btnaddstream.Click += new System.EventHandler(this.btnaddstream_Click);
            // 
            // EditStream
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 152);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditStream";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Stream";
            this.Load += new System.EventHandler(this.EditStream_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.RadioButton lstcust;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txbcustom;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox playsound;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnaddstream;
    }
}
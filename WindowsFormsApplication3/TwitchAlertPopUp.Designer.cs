namespace WindowsFormsApplication3
{
    partial class TwitchAlertPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwitchAlertPopUp));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlstream = new System.Windows.Forms.Label();
            this.descstrm = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.vlcbtn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.twurl = new System.Windows.Forms.TextBox();
            this.vlcpath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.25683F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.74317F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 99);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::WindowsFormsApplication3.Properties.Resources.preload;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tlstream, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.descstrm, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(153, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 93);
            this.tableLayoutPanel2.TabIndex = 1;
            this.tableLayoutPanel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel2_MouseMove);
            // 
            // tlstream
            // 
            this.tlstream.AutoSize = true;
            this.tlstream.Font = new System.Drawing.Font("Tahoma", 14F);
            this.tlstream.Location = new System.Drawing.Point(3, 0);
            this.tlstream.Name = "tlstream";
            this.tlstream.Size = new System.Drawing.Size(100, 23);
            this.tlstream.TabIndex = 0;
            this.tlstream.Text = "Loading ...";
            // 
            // descstrm
            // 
            this.descstrm.AutoSize = true;
            this.descstrm.Font = new System.Drawing.Font("Tahoma", 10F);
            this.descstrm.Location = new System.Drawing.Point(3, 46);
            this.descstrm.Name = "descstrm";
            this.descstrm.Size = new System.Drawing.Size(72, 17);
            this.descstrm.TabIndex = 0;
            this.descstrm.Text = "Loading ...";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.vlcbtn);
            this.flowLayoutPanel1.Controls.Add(this.kryptonButton3);
            this.flowLayoutPanel1.Controls.Add(this.kryptonButton1);
            this.flowLayoutPanel1.Controls.Add(this.kryptonButton4);
            this.flowLayoutPanel1.Controls.Add(this.twurl);
            this.flowLayoutPanel1.Controls.Add(this.vlcpath);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(366, 36);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_MouseMove);
            // 
            // vlcbtn
            // 
            this.vlcbtn.AutoSize = true;
            this.vlcbtn.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.vlcbtn.Location = new System.Drawing.Point(3, 3);
            this.vlcbtn.Name = "vlcbtn";
            this.vlcbtn.Size = new System.Drawing.Size(95, 26);
            this.vlcbtn.TabIndex = 2;
            this.vlcbtn.Values.Image = global::WindowsFormsApplication3.Properties.Resources.vlc_logo;
            this.vlcbtn.Values.Text = "Watch(VLC)";
            this.vlcbtn.Click += new System.EventHandler(this.vlcbtn_Click);
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.AutoSize = true;
            this.kryptonButton3.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton3.Location = new System.Drawing.Point(104, 3);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(99, 26);
            this.kryptonButton3.TabIndex = 1;
            this.kryptonButton3.Values.Image = global::WindowsFormsApplication3.Properties.Resources.twitchlogo;
            this.kryptonButton3.Values.Text = "Watch(WEB)";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton1.Location = new System.Drawing.Point(209, 3);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(52, 26);
            this.kryptonButton1.TabIndex = 3;
            this.kryptonButton1.Values.Image = global::WindowsFormsApplication3.Properties.Resources.edit_file;
            this.kryptonButton1.Values.Text = "Edit";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.AutoSize = true;
            this.kryptonButton4.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.LowProfile;
            this.kryptonButton4.Enabled = false;
            this.kryptonButton4.Location = new System.Drawing.Point(267, 3);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(61, 26);
            this.kryptonButton4.TabIndex = 3;
            this.kryptonButton4.Values.Image = global::WindowsFormsApplication3.Properties.Resources.close_icon;
            this.kryptonButton4.Values.Text = "Close";
            this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
            // 
            // twurl
            // 
            this.twurl.Location = new System.Drawing.Point(334, 3);
            this.twurl.Name = "twurl";
            this.twurl.Size = new System.Drawing.Size(10, 20);
            this.twurl.TabIndex = 4;
            this.twurl.Visible = false;
            // 
            // vlcpath
            // 
            this.vlcpath.Location = new System.Drawing.Point(350, 3);
            this.vlcpath.Name = "vlcpath";
            this.vlcpath.Size = new System.Drawing.Size(10, 20);
            this.vlcpath.TabIndex = 4;
            this.vlcpath.Visible = false;
            // 
            // TwitchAlertPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(366, 143);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TwitchAlertPopUp";
            this.Text = "Twitch Alert";
            this.Load += new System.EventHandler(this.TwitchAlertPopUp_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton vlcbtn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label tlstream;
        private System.Windows.Forms.Label descstrm;
        private System.Windows.Forms.TextBox twurl;
        private System.Windows.Forms.TextBox vlcpath;
    }
}
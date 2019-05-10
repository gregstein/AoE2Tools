namespace WindowsFormsApplication3
{
    partial class TwitchStreams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwitchStreams));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Bot = new System.Windows.Forms.Panel();
            this.vlcpath = new System.Windows.Forms.TextBox();
            this.refreshlist = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.line_bot = new System.Windows.Forms.Panel();
            this.flp_Streams = new System.Windows.Forms.FlowLayoutPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.line_top = new System.Windows.Forms.Panel();
            this.lbl_LiveTwitcher = new System.Windows.Forms.Label();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_Bot.SuspendLayout();
            this.flp_Streams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(396, 112);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 106);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(198, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(189, 100);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Loading ...";
            // 
            // panel_Bot
            // 
            this.panel_Bot.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel_Bot.Controls.Add(this.vlcpath);
            this.panel_Bot.Controls.Add(this.refreshlist);
            this.panel_Bot.Location = new System.Drawing.Point(-1, 471);
            this.panel_Bot.Name = "panel_Bot";
            this.panel_Bot.Size = new System.Drawing.Size(416, 42);
            this.panel_Bot.TabIndex = 8;
            // 
            // vlcpath
            // 
            this.vlcpath.Location = new System.Drawing.Point(17, 10);
            this.vlcpath.Name = "vlcpath";
            this.vlcpath.Size = new System.Drawing.Size(21, 20);
            this.vlcpath.TabIndex = 1;
            this.vlcpath.Visible = false;
            // 
            // refreshlist
            // 
            this.refreshlist.Enabled = false;
            this.refreshlist.Location = new System.Drawing.Point(173, 10);
            this.refreshlist.Name = "refreshlist";
            this.refreshlist.OverrideFocus.ShortText.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.refreshlist.OverrideFocus.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.refreshlist.OverrideNotVisited.ShortText.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.refreshlist.OverrideNotVisited.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshlist.OverridePressed.ShortText.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.refreshlist.OverridePressed.ShortText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.refreshlist.Size = new System.Drawing.Size(88, 18);
            this.refreshlist.StateCommon.ShortText.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.refreshlist.StateNormal.ShortText.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.refreshlist.StateNormal.ShortText.Color2 = System.Drawing.Color.DeepSkyBlue;
            this.refreshlist.TabIndex = 0;
            this.refreshlist.Values.Text = " Refresh List";
            this.refreshlist.LinkClicked += new System.EventHandler(this.refreshlist_LinkClicked);
            // 
            // line_bot
            // 
            this.line_bot.BackColor = System.Drawing.Color.LightGray;
            this.line_bot.Location = new System.Drawing.Point(1, 471);
            this.line_bot.Name = "line_bot";
            this.line_bot.Size = new System.Drawing.Size(416, 1);
            this.line_bot.TabIndex = 9;
            // 
            // flp_Streams
            // 
            this.flp_Streams.AutoScroll = true;
            this.flp_Streams.Controls.Add(this.flowLayoutPanel1);
            this.flp_Streams.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Streams.Location = new System.Drawing.Point(3, 71);
            this.flp_Streams.Name = "flp_Streams";
            this.flp_Streams.Size = new System.Drawing.Size(409, 403);
            this.flp_Streams.TabIndex = 11;
            this.flp_Streams.WrapContents = false;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black;
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonForm;
            this.kryptonPanel1.Size = new System.Drawing.Size(412, 511);
            this.kryptonPanel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication3.Properties.Resources.twitchlogo;
            this.pictureBox1.Location = new System.Drawing.Point(14, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 24);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // line_top
            // 
            this.line_top.BackColor = System.Drawing.Color.LightGray;
            this.line_top.Location = new System.Drawing.Point(-16, 52);
            this.line_top.Name = "line_top";
            this.line_top.Size = new System.Drawing.Size(416, 1);
            this.line_top.TabIndex = 5;
            // 
            // lbl_LiveTwitcher
            // 
            this.lbl_LiveTwitcher.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LiveTwitcher.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LiveTwitcher.ForeColor = System.Drawing.Color.White;
            this.lbl_LiveTwitcher.Location = new System.Drawing.Point(57, 8);
            this.lbl_LiveTwitcher.Name = "lbl_LiveTwitcher";
            this.lbl_LiveTwitcher.Size = new System.Drawing.Size(195, 41);
            this.lbl_LiveTwitcher.TabIndex = 8;
            this.lbl_LiveTwitcher.Text = "Twitch Live Streams";
            this.lbl_LiveTwitcher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(65)))), ((int)(((byte)(165)))));
            this.panel_Top.Controls.Add(this.lbl_LiveTwitcher);
            this.panel_Top.Controls.Add(this.line_top);
            this.panel_Top.Location = new System.Drawing.Point(50, 1);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(362, 69);
            this.panel_Top.TabIndex = 10;
            // 
            // TwitchStreams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 511);
            this.Controls.Add(this.panel_Bot);
            this.Controls.Add(this.line_bot);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.flp_Streams);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TwitchStreams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch Live Streams of Age of Empires 2";
            this.Load += new System.EventHandler(this.TwitchStreams_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_Bot.ResumeLayout(false);
            this.panel_Bot.PerformLayout();
            this.flp_Streams.ResumeLayout(false);
            this.flp_Streams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel_Bot;
        private System.Windows.Forms.Panel line_bot;
        private System.Windows.Forms.FlowLayoutPanel flp_Streams;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel line_top;
        private System.Windows.Forms.Label lbl_LiveTwitcher;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel refreshlist;
        private System.Windows.Forms.TextBox vlcpath;
    }
}
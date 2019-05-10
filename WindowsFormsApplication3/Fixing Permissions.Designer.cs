namespace WindowsFormsApplication3
{
    partial class Fixing_Permissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fixing_Permissions));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GamePath = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.plswait = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.preloader = new System.Windows.Forms.PictureBox();
            this.maytake = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preloader)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // GamePath
            // 
            this.GamePath.Location = new System.Drawing.Point(444, 132);
            this.GamePath.Name = "GamePath";
            this.GamePath.Size = new System.Drawing.Size(47, 20);
            this.GamePath.TabIndex = 0;
            this.GamePath.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.7234F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.2766F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel3.Controls.Add(this.plswait, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.preloader, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.maytake, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(29, 76);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(403, 42);
            this.tableLayoutPanel3.TabIndex = 26;
            this.tableLayoutPanel3.Visible = false;
            // 
            // plswait
            // 
            this.plswait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plswait.Location = new System.Drawing.Point(44, 3);
            this.plswait.Name = "plswait";
            this.plswait.Size = new System.Drawing.Size(171, 36);
            this.plswait.StateNormal.ShortText.Color1 = System.Drawing.SystemColors.MenuText;
            this.plswait.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plswait.TabIndex = 29;
            this.plswait.Values.Text = "Please wait ...";
            // 
            // preloader
            // 
            this.preloader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preloader.Image = global::WindowsFormsApplication3.Properties.Resources.preload;
            this.preloader.Location = new System.Drawing.Point(3, 3);
            this.preloader.Name = "preloader";
            this.preloader.Size = new System.Drawing.Size(35, 36);
            this.preloader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.preloader.TabIndex = 26;
            this.preloader.TabStop = false;
            // 
            // maytake
            // 
            this.maytake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maytake.Location = new System.Drawing.Point(221, 3);
            this.maytake.Name = "maytake";
            this.maytake.Size = new System.Drawing.Size(179, 36);
            this.maytake.StateNormal.ShortText.Color1 = System.Drawing.SystemColors.MenuText;
            this.maytake.StateNormal.ShortText.Font = new System.Drawing.Font("Tahoma", 9F);
            this.maytake.TabIndex = 28;
            this.maytake.Values.Text = "It may take 1 - 5 mins";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(160, 31);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonButton1.Size = new System.Drawing.Size(134, 25);
            this.kryptonButton1.TabIndex = 27;
            this.kryptonButton1.Values.Text = "Fix Permission Issues";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // Fixing_Permissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 127);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.GamePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fixing_Permissions";
            this.Text = "Fixing Game Path Permissions";
            this.Load += new System.EventHandler(this.Fixing_Permissions_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preloader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox GamePath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel plswait;
        private System.Windows.Forms.PictureBox preloader;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel maytake;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}
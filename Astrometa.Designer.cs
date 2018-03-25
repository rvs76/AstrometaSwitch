namespace AstrometaForm
{
    partial class Astrometa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Astrometa));
            this.rbtDVBC = new System.Windows.Forms.RadioButton();
            this.rbtDVBT = new System.Windows.Forms.RadioButton();
            this.btApply = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.NIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmSystray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiDVBC = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDVBT = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smiShow = new System.Windows.Forms.ToolStripMenuItem();
            this.smiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btHide = new System.Windows.Forms.Button();
            this.cmSystray.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtDVBC
            // 
            this.rbtDVBC.AutoSize = true;
            this.rbtDVBC.Location = new System.Drawing.Point(21, 12);
            this.rbtDVBC.Name = "rbtDVBC";
            this.rbtDVBC.Size = new System.Drawing.Size(57, 17);
            this.rbtDVBC.TabIndex = 0;
            this.rbtDVBC.TabStop = true;
            this.rbtDVBC.Text = "DVB-C";
            this.rbtDVBC.UseVisualStyleBackColor = true;
            // 
            // rbtDVBT
            // 
            this.rbtDVBT.AutoSize = true;
            this.rbtDVBT.Location = new System.Drawing.Point(93, 12);
            this.rbtDVBT.Name = "rbtDVBT";
            this.rbtDVBT.Size = new System.Drawing.Size(75, 17);
            this.rbtDVBT.TabIndex = 1;
            this.rbtDVBT.TabStop = true;
            this.rbtDVBT.Text = "DVB-T/T2";
            this.rbtDVBT.UseVisualStyleBackColor = true;
            // 
            // btApply
            // 
            this.btApply.Location = new System.Drawing.Point(12, 46);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(75, 23);
            this.btApply.TabIndex = 2;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(174, 46);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 3;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // NIcon
            // 
            this.NIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NIcon.BalloonTipText = "Switch DVB-T DVB-C for Astrometa Device";
            this.NIcon.BalloonTipTitle = "AstrometaSwitch";
            this.NIcon.ContextMenuStrip = this.cmSystray;
            this.NIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NIcon.Icon")));
            this.NIcon.Text = "AstrometaSwitch";
            this.NIcon.DoubleClick += new System.EventHandler(this.NIcon_DoubleClick);
            // 
            // cmSystray
            // 
            this.cmSystray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiDVBC,
            this.smiDVBT,
            this.toolStripSeparator1,
            this.smiShow,
            this.smiClose});
            this.cmSystray.Name = "cmSystray";
            this.cmSystray.Size = new System.Drawing.Size(110, 98);
            // 
            // smiDVBC
            // 
            this.smiDVBC.Name = "smiDVBC";
            this.smiDVBC.Size = new System.Drawing.Size(109, 22);
            this.smiDVBC.Text = "DVB-C";
            this.smiDVBC.Click += new System.EventHandler(this.btApply_Click);
            // 
            // smiDVBT
            // 
            this.smiDVBT.Name = "smiDVBT";
            this.smiDVBT.Size = new System.Drawing.Size(109, 22);
            this.smiDVBT.Text = "DVB-T";
            this.smiDVBT.Click += new System.EventHandler(this.btApply_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // smiShow
            // 
            this.smiShow.Name = "smiShow";
            this.smiShow.Size = new System.Drawing.Size(109, 22);
            this.smiShow.Text = "Show";
            this.smiShow.Click += new System.EventHandler(this.NIcon_DoubleClick);
            // 
            // smiClose
            // 
            this.smiClose.Name = "smiClose";
            this.smiClose.Size = new System.Drawing.Size(109, 22);
            this.smiClose.Text = "Close";
            this.smiClose.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btHide
            // 
            this.btHide.Location = new System.Drawing.Point(93, 46);
            this.btHide.Name = "btHide";
            this.btHide.Size = new System.Drawing.Size(75, 23);
            this.btHide.TabIndex = 4;
            this.btHide.Text = "Hide";
            this.btHide.UseVisualStyleBackColor = true;
            this.btHide.Click += new System.EventHandler(this.btHide_Click);
            // 
            // Astrometa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 79);
            this.ControlBox = false;
            this.Controls.Add(this.btHide);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.rbtDVBT);
            this.Controls.Add(this.rbtDVBC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Astrometa";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Astrometa";
            this.Load += new System.EventHandler(this.Astrometa2_Load);
            this.cmSystray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtDVBC;
        private System.Windows.Forms.RadioButton rbtDVBT;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Button btExit;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.NotifyIcon NIcon;
        private System.Windows.Forms.Button btHide;
        private System.Windows.Forms.ContextMenuStrip cmSystray;
        private System.Windows.Forms.ToolStripMenuItem smiDVBC;
        private System.Windows.Forms.ToolStripMenuItem smiDVBT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem smiShow;
        private System.Windows.Forms.ToolStripMenuItem smiClose;
    }
}
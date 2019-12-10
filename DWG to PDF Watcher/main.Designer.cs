namespace DWG2PDFWatcher
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.dirWatchLabel = new System.Windows.Forms.Label();
            this.watchBox = new System.Windows.Forms.TextBox();
            this.outputDirLabel = new System.Windows.Forms.Label();
            this.outDirBox = new System.Windows.Forms.TextBox();
            this.dirWatchBrowse = new System.Windows.Forms.Button();
            this.OutputDirBrowse = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cadConvLabel = new System.Windows.Forms.Label();
            this.cadConvBrowse = new System.Windows.Forms.Button();
            this.cadConvBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.exportOnExit = new System.Windows.Forms.CheckBox();
            this.showNotifications = new System.Windows.Forms.CheckBox();
            this.copyDirBrowse = new System.Windows.Forms.Button();
            this.copyDirBox = new System.Windows.Forms.TextBox();
            this.copyDirLabel = new System.Windows.Forms.Label();
            this.cadConvHelpBtn = new System.Windows.Forms.Button();
            this.dirWatchHelpBtn = new System.Windows.Forms.Button();
            this.outputDirHelpBtn = new System.Windows.Forms.Button();
            this.copyDirHelpBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dirWatchLabel
            // 
            this.dirWatchLabel.AutoSize = true;
            this.dirWatchLabel.Location = new System.Drawing.Point(6, 56);
            this.dirWatchLabel.Name = "dirWatchLabel";
            this.dirWatchLabel.Size = new System.Drawing.Size(84, 13);
            this.dirWatchLabel.TabIndex = 0;
            this.dirWatchLabel.Text = "Watch Directory";
            // 
            // watchBox
            // 
            this.watchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchBox.Location = new System.Drawing.Point(96, 53);
            this.watchBox.Name = "watchBox";
            this.watchBox.Size = new System.Drawing.Size(377, 20);
            this.watchBox.TabIndex = 99;
            this.watchBox.TabStop = false;
            this.watchBox.TextChanged += new System.EventHandler(this.watchBox_TextChanged);
            // 
            // outputDirLabel
            // 
            this.outputDirLabel.AutoSize = true;
            this.outputDirLabel.Location = new System.Drawing.Point(5, 79);
            this.outputDirLabel.Name = "outputDirLabel";
            this.outputDirLabel.Size = new System.Drawing.Size(84, 13);
            this.outputDirLabel.TabIndex = 2;
            this.outputDirLabel.Text = "Output Directory";
            // 
            // outDirBox
            // 
            this.outDirBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outDirBox.Location = new System.Drawing.Point(96, 76);
            this.outDirBox.Name = "outDirBox";
            this.outDirBox.Size = new System.Drawing.Size(377, 20);
            this.outDirBox.TabIndex = 99;
            this.outDirBox.TabStop = false;
            // 
            // dirWatchBrowse
            // 
            this.dirWatchBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dirWatchBrowse.Location = new System.Drawing.Point(476, 52);
            this.dirWatchBrowse.Name = "dirWatchBrowse";
            this.dirWatchBrowse.Size = new System.Drawing.Size(56, 23);
            this.dirWatchBrowse.TabIndex = 4;
            this.dirWatchBrowse.TabStop = false;
            this.dirWatchBrowse.Text = "browse";
            this.dirWatchBrowse.UseVisualStyleBackColor = true;
            this.dirWatchBrowse.Click += new System.EventHandler(this.dirWatchBrowse_Click);
            // 
            // OutputDirBrowse
            // 
            this.OutputDirBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDirBrowse.Location = new System.Drawing.Point(476, 75);
            this.OutputDirBrowse.Name = "OutputDirBrowse";
            this.OutputDirBrowse.Size = new System.Drawing.Size(56, 23);
            this.OutputDirBrowse.TabIndex = 5;
            this.OutputDirBrowse.TabStop = false;
            this.OutputDirBrowse.Text = "browse";
            this.OutputDirBrowse.UseVisualStyleBackColor = true;
            this.OutputDirBrowse.Click += new System.EventHandler(this.OutputDirBrowse_Click);
            // 
            // outputBox
            // 
            this.outputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBox.Location = new System.Drawing.Point(8, 127);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(547, 318);
            this.outputBox.TabIndex = 6;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Filter = "*.dwg";
            this.fileSystemWatcher1.NotifyFilter = ((System.IO.NotifyFilters)(((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName) 
            | System.IO.NotifyFilters.Size) 
            | System.IO.NotifyFilters.LastWrite) 
            | System.IO.NotifyFilters.CreationTime)));
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // cadConvLabel
            // 
            this.cadConvLabel.AutoSize = true;
            this.cadConvLabel.Location = new System.Drawing.Point(5, 33);
            this.cadConvLabel.Name = "cadConvLabel";
            this.cadConvLabel.Size = new System.Drawing.Size(84, 13);
            this.cadConvLabel.TabIndex = 7;
            this.cadConvLabel.Text = "Cad Conv. Exec";
            // 
            // cadConvBrowse
            // 
            this.cadConvBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cadConvBrowse.Location = new System.Drawing.Point(476, 29);
            this.cadConvBrowse.Name = "cadConvBrowse";
            this.cadConvBrowse.Size = new System.Drawing.Size(56, 23);
            this.cadConvBrowse.TabIndex = 9;
            this.cadConvBrowse.TabStop = false;
            this.cadConvBrowse.Text = "browse";
            this.cadConvBrowse.UseVisualStyleBackColor = true;
            this.cadConvBrowse.Click += new System.EventHandler(this.cadConvBrowse_Click);
            // 
            // cadConvBox
            // 
            this.cadConvBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cadConvBox.Location = new System.Drawing.Point(96, 30);
            this.cadConvBox.Name = "cadConvBox";
            this.cadConvBox.Size = new System.Drawing.Size(377, 20);
            this.cadConvBox.TabIndex = 99;
            this.cadConvBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(564, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "program started";
            this.notifyIcon1.BalloonTipTitle = "DWG to PDF Watcher";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DWG to PDF Watcher";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Text = "Close";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // exportOnExit
            // 
            this.exportOnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportOnExit.AutoSize = true;
            this.exportOnExit.Location = new System.Drawing.Point(441, 451);
            this.exportOnExit.Name = "exportOnExit";
            this.exportOnExit.Size = new System.Drawing.Size(114, 17);
            this.exportOnExit.TabIndex = 11;
            this.exportOnExit.Text = "Export Log On Exit";
            this.exportOnExit.UseVisualStyleBackColor = true;
            // 
            // showNotifications
            // 
            this.showNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showNotifications.AutoSize = true;
            this.showNotifications.Location = new System.Drawing.Point(322, 451);
            this.showNotifications.Name = "showNotifications";
            this.showNotifications.Size = new System.Drawing.Size(114, 17);
            this.showNotifications.TabIndex = 12;
            this.showNotifications.Text = "Show Notifications";
            this.showNotifications.UseVisualStyleBackColor = true;
            // 
            // copyDirBrowse
            // 
            this.copyDirBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyDirBrowse.Location = new System.Drawing.Point(476, 98);
            this.copyDirBrowse.Name = "copyDirBrowse";
            this.copyDirBrowse.Size = new System.Drawing.Size(56, 23);
            this.copyDirBrowse.TabIndex = 15;
            this.copyDirBrowse.TabStop = false;
            this.copyDirBrowse.Text = "browse";
            this.copyDirBrowse.UseVisualStyleBackColor = true;
            this.copyDirBrowse.Click += new System.EventHandler(this.copyDirBrowse_Click);
            // 
            // copyDirBox
            // 
            this.copyDirBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyDirBox.Location = new System.Drawing.Point(96, 99);
            this.copyDirBox.Name = "copyDirBox";
            this.copyDirBox.Size = new System.Drawing.Size(377, 20);
            this.copyDirBox.TabIndex = 99;
            this.copyDirBox.TabStop = false;
            // 
            // copyDirLabel
            // 
            this.copyDirLabel.AutoSize = true;
            this.copyDirLabel.Location = new System.Drawing.Point(12, 102);
            this.copyDirLabel.Name = "copyDirLabel";
            this.copyDirLabel.Size = new System.Drawing.Size(76, 13);
            this.copyDirLabel.TabIndex = 13;
            this.copyDirLabel.Text = "Copy Directory";
            // 
            // cadConvHelpBtn
            // 
            this.cadConvHelpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cadConvHelpBtn.Location = new System.Drawing.Point(533, 29);
            this.cadConvHelpBtn.Name = "cadConvHelpBtn";
            this.cadConvHelpBtn.Size = new System.Drawing.Size(22, 23);
            this.cadConvHelpBtn.TabIndex = 16;
            this.cadConvHelpBtn.TabStop = false;
            this.cadConvHelpBtn.Text = "?";
            this.cadConvHelpBtn.UseVisualStyleBackColor = true;
            this.cadConvHelpBtn.Click += new System.EventHandler(this.cadConvHelpBtn_Click);
            // 
            // dirWatchHelpBtn
            // 
            this.dirWatchHelpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dirWatchHelpBtn.Location = new System.Drawing.Point(533, 52);
            this.dirWatchHelpBtn.Name = "dirWatchHelpBtn";
            this.dirWatchHelpBtn.Size = new System.Drawing.Size(22, 23);
            this.dirWatchHelpBtn.TabIndex = 17;
            this.dirWatchHelpBtn.TabStop = false;
            this.dirWatchHelpBtn.Text = "?";
            this.dirWatchHelpBtn.UseVisualStyleBackColor = true;
            this.dirWatchHelpBtn.Click += new System.EventHandler(this.dirWatchHelpBtn_Click);
            // 
            // outputDirHelpBtn
            // 
            this.outputDirHelpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirHelpBtn.Location = new System.Drawing.Point(533, 75);
            this.outputDirHelpBtn.Name = "outputDirHelpBtn";
            this.outputDirHelpBtn.Size = new System.Drawing.Size(22, 23);
            this.outputDirHelpBtn.TabIndex = 18;
            this.outputDirHelpBtn.TabStop = false;
            this.outputDirHelpBtn.Text = "?";
            this.outputDirHelpBtn.UseVisualStyleBackColor = true;
            this.outputDirHelpBtn.Click += new System.EventHandler(this.outputDirHelpBtn_Click);
            // 
            // copyDirHelpBtn
            // 
            this.copyDirHelpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyDirHelpBtn.Location = new System.Drawing.Point(533, 98);
            this.copyDirHelpBtn.Name = "copyDirHelpBtn";
            this.copyDirHelpBtn.Size = new System.Drawing.Size(22, 23);
            this.copyDirHelpBtn.TabIndex = 19;
            this.copyDirHelpBtn.TabStop = false;
            this.copyDirHelpBtn.Text = "?";
            this.copyDirHelpBtn.UseVisualStyleBackColor = true;
            this.copyDirHelpBtn.Click += new System.EventHandler(this.copyDirHelpBtn_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 475);
            this.Controls.Add(this.copyDirHelpBtn);
            this.Controls.Add(this.outputDirHelpBtn);
            this.Controls.Add(this.dirWatchHelpBtn);
            this.Controls.Add(this.cadConvHelpBtn);
            this.Controls.Add(this.copyDirBrowse);
            this.Controls.Add(this.copyDirBox);
            this.Controls.Add(this.copyDirLabel);
            this.Controls.Add(this.showNotifications);
            this.Controls.Add(this.exportOnExit);
            this.Controls.Add(this.cadConvBrowse);
            this.Controls.Add(this.cadConvBox);
            this.Controls.Add(this.cadConvLabel);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.OutputDirBrowse);
            this.Controls.Add(this.dirWatchBrowse);
            this.Controls.Add(this.outDirBox);
            this.Controls.Add(this.outputDirLabel);
            this.Controls.Add(this.watchBox);
            this.Controls.Add(this.dirWatchLabel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(580, 514);
            this.Name = "main";
            this.Text = "DWG to PDF Watcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.Shown += new System.EventHandler(this.main_Shown);
            this.Resize += new System.EventHandler(this.main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dirWatchLabel;
        private System.Windows.Forms.TextBox watchBox;
        private System.Windows.Forms.Label outputDirLabel;
        private System.Windows.Forms.TextBox outDirBox;
        private System.Windows.Forms.Button dirWatchBrowse;
        private System.Windows.Forms.Button OutputDirBrowse;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cadConvBrowse;
        private System.Windows.Forms.TextBox cadConvBox;
        private System.Windows.Forms.Label cadConvLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox exportOnExit;
        private System.Windows.Forms.CheckBox showNotifications;
        private System.Windows.Forms.Button copyDirBrowse;
        private System.Windows.Forms.TextBox copyDirBox;
        private System.Windows.Forms.Label copyDirLabel;
        private System.Windows.Forms.Button cadConvHelpBtn;
        private System.Windows.Forms.Button dirWatchHelpBtn;
        private System.Windows.Forms.Button outputDirHelpBtn;
        private System.Windows.Forms.Button copyDirHelpBtn;
    }
}


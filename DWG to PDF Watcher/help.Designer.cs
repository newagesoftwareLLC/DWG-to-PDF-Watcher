namespace DWG2PDFWatcher
{
    partial class help
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
            this.helpDescLabel = new System.Windows.Forms.TextBox();
            this.goToAutoDWG = new System.Windows.Forms.Label();
            this.goToAcmeDWG = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // helpDescLabel
            // 
            this.helpDescLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.helpDescLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpDescLabel.Location = new System.Drawing.Point(12, 12);
            this.helpDescLabel.Multiline = true;
            this.helpDescLabel.Name = "helpDescLabel";
            this.helpDescLabel.Size = new System.Drawing.Size(260, 25);
            this.helpDescLabel.TabIndex = 0;
            this.helpDescLabel.TabStop = false;
            this.helpDescLabel.Text = "This program requires either AutoDWG or AcmeDWG.";
            // 
            // goToAutoDWG
            // 
            this.goToAutoDWG.AutoSize = true;
            this.goToAutoDWG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goToAutoDWG.ForeColor = System.Drawing.Color.Teal;
            this.goToAutoDWG.Location = new System.Drawing.Point(13, 44);
            this.goToAutoDWG.Name = "goToAutoDWG";
            this.goToAutoDWG.Size = new System.Drawing.Size(56, 13);
            this.goToAutoDWG.TabIndex = 1;
            this.goToAutoDWG.Text = "AutoDWG";
            this.goToAutoDWG.Click += new System.EventHandler(this.label1_Click);
            // 
            // goToAcmeDWG
            // 
            this.goToAcmeDWG.AutoSize = true;
            this.goToAcmeDWG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goToAcmeDWG.ForeColor = System.Drawing.Color.Teal;
            this.goToAcmeDWG.Location = new System.Drawing.Point(13, 67);
            this.goToAcmeDWG.Name = "goToAcmeDWG";
            this.goToAcmeDWG.Size = new System.Drawing.Size(61, 13);
            this.goToAcmeDWG.TabIndex = 2;
            this.goToAcmeDWG.Text = "AcmeDWG";
            this.goToAcmeDWG.Click += new System.EventHandler(this.label2_Click);
            // 
            // help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 102);
            this.Controls.Add(this.goToAcmeDWG);
            this.Controls.Add(this.goToAutoDWG);
            this.Controls.Add(this.helpDescLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "help";
            this.ShowIcon = false;
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox helpDescLabel;
        private System.Windows.Forms.Label goToAutoDWG;
        private System.Windows.Forms.Label goToAcmeDWG;
    }
}
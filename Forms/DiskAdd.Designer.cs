namespace DiskSniffer.Forms
{
    partial class DiskAdd
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtMediaPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScanMedia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiskName = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dlgScanPath = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // txtMediaPath
            // 
            this.txtMediaPath.Location = new System.Drawing.Point(15, 25);
            this.txtMediaPath.Name = "txtMediaPath";
            this.txtMediaPath.Size = new System.Drawing.Size(377, 20);
            this.txtMediaPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scan Path:";
            // 
            // btnScanMedia
            // 
            this.btnScanMedia.Location = new System.Drawing.Point(398, 25);
            this.btnScanMedia.Name = "btnScanMedia";
            this.btnScanMedia.Size = new System.Drawing.Size(34, 20);
            this.btnScanMedia.TabIndex = 3;
            this.btnScanMedia.Text = "...";
            this.btnScanMedia.UseVisualStyleBackColor = true;
            this.btnScanMedia.Click += new System.EventHandler(this.BtnScanMediaClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Disk Name:";
            // 
            // txtDiskName
            // 
            this.txtDiskName.Location = new System.Drawing.Point(15, 64);
            this.txtDiskName.Name = "txtDiskName";
            this.txtDiskName.Size = new System.Drawing.Size(184, 20);
            this.txtDiskName.TabIndex = 4;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(208, 64);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(184, 20);
            this.txtSerialNumber.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Serial Number:";
            // 
            // dlgScanPath
            // 
            this.dlgScanPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.dlgScanPath.ShowNewFolderButton = false;
            // 
            // DiskAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 267);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDiskName);
            this.Controls.Add(this.btnScanMedia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMediaPath);
            this.Controls.Add(this.button1);
            this.Name = "DiskAdd";
            this.Text = "DiskAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMediaPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScanMedia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiskName;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog dlgScanPath;
    }
}
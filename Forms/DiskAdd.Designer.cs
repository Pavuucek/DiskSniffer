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
            this.btnScan = new System.Windows.Forms.Button();
            this.txtMediaPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScanMedia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiskName = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dlgScanPath = new System.Windows.Forms.FolderBrowserDialog();
            this.chkScanArchives = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpCreated = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(124, 130);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Scan files";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.BtnScanClick);
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
            // chkScanArchives
            // 
            this.chkScanArchives.AutoSize = true;
            this.chkScanArchives.Location = new System.Drawing.Point(15, 134);
            this.chkScanArchives.Name = "chkScanArchives";
            this.chkScanArchives.Size = new System.Drawing.Size(95, 17);
            this.chkScanArchives.TabIndex = 8;
            this.chkScanArchives.Text = "Scan Archives";
            this.chkScanArchives.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Data CD",
            "Audio CD",
            "Video CD",
            "DVD",
            "BluRay",
            "HD-DVD",
            "Flash Disk",
            "Hard Disk"});
            this.comboBox1.Location = new System.Drawing.Point(15, 103);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Disk Type:";
            // 
            // dtpCreated
            // 
            this.dtpCreated.Location = new System.Drawing.Point(208, 104);
            this.dtpCreated.Name = "dtpCreated";
            this.dtpCreated.Size = new System.Drawing.Size(184, 20);
            this.dtpCreated.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Date of creation:";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(276, 130);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(357, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DiskAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 163);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpCreated);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chkScanArchives);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDiskName);
            this.Controls.Add(this.btnScanMedia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMediaPath);
            this.Controls.Add(this.btnScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiskAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiskAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtMediaPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScanMedia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiskName;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog dlgScanPath;
        private System.Windows.Forms.CheckBox chkScanArchives;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpCreated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
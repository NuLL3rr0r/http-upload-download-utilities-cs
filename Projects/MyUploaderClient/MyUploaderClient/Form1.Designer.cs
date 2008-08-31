namespace MyUploaderClient
{
    partial class Form1
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblServerPath = new System.Windows.Forms.Label();
            this.numChunkSize = new System.Windows.Forms.NumericUpDown();
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.lblChunkSize = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.pbrUpload = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numChunkSize)).BeginInit();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(456, 37);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse Files...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblServerPath
            // 
            this.lblServerPath.AutoSize = true;
            this.lblServerPath.Location = new System.Drawing.Point(6, 22);
            this.lblServerPath.Name = "lblServerPath";
            this.lblServerPath.Size = new System.Drawing.Size(63, 13);
            this.lblServerPath.TabIndex = 0;
            this.lblServerPath.Text = "Server Path";
            // 
            // numChunkSize
            // 
            this.numChunkSize.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numChunkSize.Location = new System.Drawing.Point(330, 19);
            this.numChunkSize.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numChunkSize.Name = "numChunkSize";
            this.numChunkSize.Size = new System.Drawing.Size(120, 20);
            this.numChunkSize.TabIndex = 3;
            this.numChunkSize.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // txtServerPath
            // 
            this.txtServerPath.Location = new System.Drawing.Point(75, 19);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.Size = new System.Drawing.Size(152, 20);
            this.txtServerPath.TabIndex = 1;
            // 
            // lblChunkSize
            // 
            this.lblChunkSize.AutoSize = true;
            this.lblChunkSize.Location = new System.Drawing.Point(263, 22);
            this.lblChunkSize.Name = "lblChunkSize";
            this.lblChunkSize.Size = new System.Drawing.Size(61, 13);
            this.lblChunkSize.TabIndex = 2;
            this.lblChunkSize.Text = "Chunk Size";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(12, 168);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(148, 34);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(166, 168);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(148, 34);
            this.btnPause.TabIndex = 5;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(320, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "All Files (*.*) | *.*";
            this.ofd.Multiselect = true;
            this.ofd.RestoreDirectory = true;
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.txtServerPath);
            this.grpSettings.Controls.Add(this.lblServerPath);
            this.grpSettings.Controls.Add(this.numChunkSize);
            this.grpSettings.Controls.Add(this.lblChunkSize);
            this.grpSettings.Location = new System.Drawing.Point(12, 55);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(456, 64);
            this.grpSettings.TabIndex = 1;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // pbrUpload
            // 
            this.pbrUpload.Location = new System.Drawing.Point(12, 125);
            this.pbrUpload.Name = "pbrUpload";
            this.pbrUpload.Size = new System.Drawing.Size(456, 13);
            this.pbrUpload.Step = 0;
            this.pbrUpload.TabIndex = 2;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 141);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(456, 23);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "Log";
            this.txtLog.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 214);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pbrUpload);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numChunkSize)).EndInit();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblServerPath;
        private System.Windows.Forms.NumericUpDown numChunkSize;
        private System.Windows.Forms.TextBox txtServerPath;
        private System.Windows.Forms.Label lblChunkSize;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.ProgressBar pbrUpload;
        private System.Windows.Forms.Label txtLog;
    }
}


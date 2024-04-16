namespace All_in_OSU_
{
    partial class DownloadCompletePopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadCompletePopup));
            this.label_MapsetID = new System.Windows.Forms.Label();
            this.label_SongInfo = new System.Windows.Forms.Label();
            this.label_Status = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_MapsetID
            // 
            this.label_MapsetID.AutoSize = true;
            this.label_MapsetID.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_MapsetID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label_MapsetID.Location = new System.Drawing.Point(107, 13);
            this.label_MapsetID.Name = "label_MapsetID";
            this.label_MapsetID.Size = new System.Drawing.Size(61, 15);
            this.label_MapsetID.TabIndex = 2;
            this.label_MapsetID.Text = "000000";
            // 
            // label_SongInfo
            // 
            this.label_SongInfo.AutoSize = true;
            this.label_SongInfo.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_SongInfo.ForeColor = System.Drawing.Color.Black;
            this.label_SongInfo.Location = new System.Drawing.Point(107, 33);
            this.label_SongInfo.MaximumSize = new System.Drawing.Size(260, 30);
            this.label_SongInfo.Name = "label_SongInfo";
            this.label_SongInfo.Size = new System.Drawing.Size(118, 15);
            this.label_SongInfo.TabIndex = 2;
            this.label_SongInfo.Text = "Artist - SongTitle";
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Status.ForeColor = System.Drawing.Color.Black;
            this.label_Status.Location = new System.Drawing.Point(107, 74);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(123, 15);
            this.label_Status.TabIndex = 2;
            this.label_Status.Text = "Download Started";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::All_in_OSU_.Properties.Resources.delete;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // DownloadCompletePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(380, 100);
            this.ControlBox = false;
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.label_SongInfo);
            this.Controls.Add(this.label_MapsetID);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadCompletePopup";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "All in osu!";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DownloadCompletePopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_MapsetID;
        private System.Windows.Forms.Label label_SongInfo;
        private System.Windows.Forms.Label label_Status;
    }
}
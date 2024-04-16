namespace All_in_OSU_
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_osuPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBox_accID = new System.Windows.Forms.TextBox();
            this.TextBox_accPW = new System.Windows.Forms.TextBox();
            this.ProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.TitlebarRegion = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_smartDL_onlyST = new System.Windows.Forms.CheckBox();
            this.checkBox_smartDL_disable_atPlaying = new System.Windows.Forms.CheckBox();
            this.checkBox_smartDL_enable = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox_Startup = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TitlebarRegion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "osu! 설치 경로";
            // 
            // TextBox_osuPath
            // 
            this.TextBox_osuPath.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBox_osuPath.Location = new System.Drawing.Point(184, 51);
            this.TextBox_osuPath.Name = "TextBox_osuPath";
            this.TextBox_osuPath.Size = new System.Drawing.Size(304, 26);
            this.TextBox_osuPath.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(413, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(13, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "osu! 계정";
            // 
            // TextBox_accID
            // 
            this.TextBox_accID.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBox_accID.Location = new System.Drawing.Point(130, 104);
            this.TextBox_accID.Name = "TextBox_accID";
            this.TextBox_accID.Size = new System.Drawing.Size(119, 26);
            this.TextBox_accID.TabIndex = 2;
            // 
            // TextBox_accPW
            // 
            this.TextBox_accPW.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TextBox_accPW.Location = new System.Drawing.Point(295, 103);
            this.TextBox_accPW.Name = "TextBox_accPW";
            this.TextBox_accPW.PasswordChar = '*';
            this.TextBox_accPW.Size = new System.Drawing.Size(119, 26);
            this.TextBox_accPW.TabIndex = 3;
            // 
            // ProcessTimer
            // 
            this.ProcessTimer.Enabled = true;
            this.ProcessTimer.Interval = 3000;
            this.ProcessTimer.Tick += new System.EventHandler(this.ProcessTimer_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(14, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "osu!가 실행중이면 자동으로 불러옵니다.";
            // 
            // TitlebarRegion
            // 
            this.TitlebarRegion.BackColor = System.Drawing.Color.Transparent;
            this.TitlebarRegion.Location = new System.Drawing.Point(3, 2);
            this.TitlebarRegion.Name = "TitlebarRegion";
            this.TitlebarRegion.Size = new System.Drawing.Size(495, 29);
            this.TitlebarRegion.TabIndex = 8;
            this.TitlebarRegion.TabStop = false;
            this.TitlebarRegion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlebarRegion_MouseDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "찾기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(100, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(255, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "PW";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox_smartDL_onlyST);
            this.groupBox1.Controls.Add(this.checkBox_smartDL_disable_atPlaying);
            this.groupBox1.Controls.Add(this.checkBox_smartDL_enable);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(16, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 121);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "새로운 랭크곡 다운로드";
            // 
            // checkBox_smartDL_onlyST
            // 
            this.checkBox_smartDL_onlyST.AutoSize = true;
            this.checkBox_smartDL_onlyST.Location = new System.Drawing.Point(152, 84);
            this.checkBox_smartDL_onlyST.Name = "checkBox_smartDL_onlyST";
            this.checkBox_smartDL_onlyST.Size = new System.Drawing.Size(15, 14);
            this.checkBox_smartDL_onlyST.TabIndex = 1;
            this.checkBox_smartDL_onlyST.UseVisualStyleBackColor = true;
            // 
            // checkBox_smartDL_disable_atPlaying
            // 
            this.checkBox_smartDL_disable_atPlaying.AutoSize = true;
            this.checkBox_smartDL_disable_atPlaying.Location = new System.Drawing.Point(175, 57);
            this.checkBox_smartDL_disable_atPlaying.Name = "checkBox_smartDL_disable_atPlaying";
            this.checkBox_smartDL_disable_atPlaying.Size = new System.Drawing.Size(15, 14);
            this.checkBox_smartDL_disable_atPlaying.TabIndex = 1;
            this.checkBox_smartDL_disable_atPlaying.UseVisualStyleBackColor = true;
            // 
            // checkBox_smartDL_enable
            // 
            this.checkBox_smartDL_enable.AutoSize = true;
            this.checkBox_smartDL_enable.Location = new System.Drawing.Point(58, 31);
            this.checkBox_smartDL_enable.Name = "checkBox_smartDL_enable";
            this.checkBox_smartDL_enable.Size = new System.Drawing.Size(15, 14);
            this.checkBox_smartDL_enable.TabIndex = 1;
            this.checkBox_smartDL_enable.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(13, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "스탠곡만 다운로드";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(13, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "osu! 실행중 비활성화";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("굴림", 9F);
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.Location = new System.Drawing.Point(174, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(270, 12);
            this.label13.TabIndex = 7;
            this.label13.Text = "태고, CTB, 매니아 곡은 다운로드 하지 않습니다.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("굴림", 9F);
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(196, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(253, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "게임 중 프레임 저하를 최소화 할 수 있습니다.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("굴림", 9F);
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(82, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(335, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "1분마다 새로운 랭크곡을 확인해서 자동으로 다운로드합니다.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(13, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "사용";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(14, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(321, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "비워두시면 공홈과 관련된 일부 기능을 사용하지 않습니다.";
            // 
            // checkBox_Startup
            // 
            this.checkBox_Startup.AutoSize = true;
            this.checkBox_Startup.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Startup.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox_Startup.Location = new System.Drawing.Point(17, 293);
            this.checkBox_Startup.Name = "checkBox_Startup";
            this.checkBox_Startup.Size = new System.Drawing.Size(120, 18);
            this.checkBox_Startup.TabIndex = 11;
            this.checkBox_Startup.Text = "윈도우와 함께 시작";
            this.checkBox_Startup.UseVisualStyleBackColor = false;
            this.checkBox_Startup.CheckedChanged += new System.EventHandler(this.checkBox_Startup_CheckedChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(500, 320);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_Startup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TitlebarRegion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBox_accPW);
            this.Controls.Add(this.TextBox_accID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBox_osuPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Text = "All in OSU! Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TitlebarRegion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_osuPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBox_accID;
        private System.Windows.Forms.TextBox TextBox_accPW;
        private System.Windows.Forms.Timer ProcessTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox TitlebarRegion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_smartDL_onlyST;
        private System.Windows.Forms.CheckBox checkBox_smartDL_disable_atPlaying;
        private System.Windows.Forms.CheckBox checkBox_smartDL_enable;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_Startup;
    }
}
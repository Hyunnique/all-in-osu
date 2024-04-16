namespace All_in_OSU_
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.비트맵추천ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.비트맵미러다운로드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.비트맵리스트백업추출ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.allInOsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mineskynavercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 60000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.비트맵추천ToolStripMenuItem,
            this.비트맵미러다운로드ToolStripMenuItem,
            this.비트맵리스트백업추출ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.allInOsuToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.mineskynavercomToolStripMenuItem,
            this.toolStripMenuItem1,
            this.설정ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.TrayMenu.Name = "contextMenuStrip1";
            this.TrayMenu.Size = new System.Drawing.Size(236, 246);
            // 
            // 비트맵추천ToolStripMenuItem
            // 
            this.비트맵추천ToolStripMenuItem.Name = "비트맵추천ToolStripMenuItem";
            this.비트맵추천ToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.비트맵추천ToolStripMenuItem.Text = "비트맵 추천 (Ctrl+Alt+T)";
            this.비트맵추천ToolStripMenuItem.Click += new System.EventHandler(this.비트맵추천ToolStripMenuItem_Click);
            // 
            // 비트맵미러다운로드ToolStripMenuItem
            // 
            this.비트맵미러다운로드ToolStripMenuItem.Name = "비트맵미러다운로드ToolStripMenuItem";
            this.비트맵미러다운로드ToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.비트맵미러다운로드ToolStripMenuItem.Text = "비트맵 미러 다운로드 (Ctrl+E)";
            this.비트맵미러다운로드ToolStripMenuItem.Click += new System.EventHandler(this.비트맵미러다운로드ToolStripMenuItem_Click_1);
            // 
            // 비트맵리스트백업추출ToolStripMenuItem
            // 
            this.비트맵리스트백업추출ToolStripMenuItem.Name = "비트맵리스트백업추출ToolStripMenuItem";
            this.비트맵리스트백업추출ToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.비트맵리스트백업추출ToolStripMenuItem.Text = "비트맵 리스트 백업 / 추출";
            this.비트맵리스트백업추출ToolStripMenuItem.Click += new System.EventHandler(this.비트맵리스트백업추출ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem2.Text = "-------------------------------";
            // 
            // allInOsuToolStripMenuItem
            // 
            this.allInOsuToolStripMenuItem.Enabled = false;
            this.allInOsuToolStripMenuItem.Name = "allInOsuToolStripMenuItem";
            this.allInOsuToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.allInOsuToolStripMenuItem.Text = "All in osu!";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem3.Text = "Beatmap Utility for osu! users";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem4.Text = "Made by Lecoren";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem1.Text = "-------------------------------";
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.설정ToolStripMenuItem.Text = "설정 (Settings)";
            this.설정ToolStripMenuItem.Click += new System.EventHandler(this.설정ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.종료ToolStripMenuItem.Text = "종료 (Exit)";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "All in osu!";
            this.TrayIcon.Visible = true;
            // 
            // mineskynavercomToolStripMenuItem
            // 
            this.mineskynavercomToolStripMenuItem.Enabled = false;
            this.mineskynavercomToolStripMenuItem.Name = "mineskynavercomToolStripMenuItem";
            this.mineskynavercomToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.mineskynavercomToolStripMenuItem.Text = "minesky_@naver.com";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(78, 67);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "osu!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        public System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStripMenuItem 비트맵추천ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 비트맵미러다운로드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem allInOsuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 비트맵리스트백업추출ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mineskynavercomToolStripMenuItem;
    }
}


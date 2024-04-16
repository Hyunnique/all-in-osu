using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace All_in_OSU_
{

    public partial class SettingForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
		

        public string osuPath;
        public string acc_ID;
        public string acc_PW;
        public bool smartDL_enable;
        public bool smartDL_disable_atplaying;
        public bool smartDL_onlyST;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            TextBox_osuPath.Text = osuPath;
            TextBox_accID.Text = acc_ID;
            TextBox_accPW.Text = acc_PW;
            checkBox_smartDL_enable.Checked = smartDL_enable;
            checkBox_smartDL_disable_atPlaying.Checked = smartDL_disable_atplaying;
            checkBox_smartDL_onlyST.Checked = smartDL_onlyST;

            if (Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("All in OSU!").GetValue("onWindowsStartup", "T").ToString() == "T")
                checkBox_Startup.Checked = true;
            else checkBox_Startup.Checked = false;

            ProcessTimer.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.Instance.osuPath = TextBox_osuPath.Text;
            MainForm.Instance.acc_ID = TextBox_accID.Text;
            MainForm.Instance.acc_PW = TextBox_accPW.Text;
            MainForm.Instance.smartDL_enable = checkBox_smartDL_enable.Checked;
            MainForm.Instance.smartDL_disable_atplaying = checkBox_smartDL_disable_atPlaying.Checked;
            MainForm.Instance.smartDL_onlyST = checkBox_smartDL_onlyST.Checked;

            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("All in OSU!");
            try
            {
                if (checkBox_Startup.Checked)
                {
                    reg.SetValue("onWindowsStartup", "T");
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("All in osu!", "\"" + Application.ExecutablePath.ToString() + "\"");
                }
                else
                {
                    reg.SetValue("onWindowsStartup", "F");
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue("All in osu!");
                }

                reg.SetValue("path", TextBox_osuPath.Text);
                reg.SetValue("acc_a", TextBox_accID.Text);
                reg.SetValue("acc_b", TextBox_accPW.Text);

                if (checkBox_smartDL_enable.Checked) reg.SetValue("smartDL_enable", "T");
                else reg.SetValue("smartDL_enable", "F");

                if (checkBox_smartDL_disable_atPlaying.Checked) reg.SetValue("smartDL_disable_atplaying", "T");
                else reg.SetValue("smartDL_disable_atplaying", "F");

                if (checkBox_smartDL_onlyST.Checked) reg.SetValue("smartDL_onlyST", "T");
                else reg.SetValue("smartDL_onlyST", "F");

            }
            catch { }

            if (checkBox_smartDL_enable.Checked) MainForm.Instance.refreshTimer.Enabled = true;
            else MainForm.Instance.refreshTimer.Enabled = false;

            MainForm.Instance.showPopup("", "", Popup.Setting_Saved);
            this.Close();
        }

        private void ProcessTimer_Tick(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcesses();

            foreach (Process prs in process)
            {
                if (prs.ProcessName == "osu!")
                {
                    TextBox_osuPath.Text = prs.MainModule.FileName.Replace(@"\osu!.exe", "");
                    ProcessTimer.Enabled = false;
                }
            }
        }

        private void TitlebarRegion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TextBox_osuPath.Text = dialog.SelectedPath;
            }
        }

        private void checkBox_Startup_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

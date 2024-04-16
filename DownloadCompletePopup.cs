using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace All_in_OSU_
{
    public enum Popup
    {
        Boot,
        Login_Success,
        Login_Failure,
        Login_Reconnect,
        Login_Pass,
        Wait_Thread,
        Beatmap_Apply,
        Setting_Saved,
        Finding_Recommend,
        Download_Start_Mirror,
        Download_Start_Official,
        Download_Finish,
        Download_Wait,
        osuRunning,
        osuStopped,
        officialNotFound,
        Disposing
    }

    public partial class DownloadCompletePopup : Form
    {
        #region ShowWithoutActivation
        private enum GWL : int
        {
            ExStyle = -20
        }

        private enum WS_EX : int
        {
            Transparent = 0x20,
            Layered = 0x80000
        }

        public enum LWA : int
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        const int WS_EX_NOACTIVATE = 0x08000000;
        const int WS_EX_TOPMOST = 0x00000008;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_TOPMOST; // make the form topmost
                param.ExStyle |= WS_EX_NOACTIVATE; // prevent the form from being activated
                return param;
            }
        }
        #endregion

        public DownloadCompletePopup()
        {
            InitializeComponent();
        }

        private Popup[] Popup_OK = { Popup.Boot, Popup.Login_Success, Popup.Login_Pass, Popup.Beatmap_Apply, Popup.Setting_Saved, Popup.Download_Finish, Popup.osuRunning, Popup.osuStopped, Popup.Disposing };
        private Popup[] Popup_Work = { Popup.Login_Reconnect, Popup.Finding_Recommend, Popup.Download_Start_Mirror, Popup.Download_Start_Official, Popup.Download_Wait };
        private Popup[] Popup_X = { Popup.Login_Failure, Popup.Wait_Thread, Popup.officialNotFound };

        public void ShowPopup(string MapsetID, string sString, Popup type, int popupCount)
        {
            Screen screen = Screen.FromControl(this);
            Rectangle screenArea = screen.WorkingArea;
            int pointX = screenArea.Width - this.Width;
            int pointY = screenArea.Height - (this.Height * popupCount);
            this.Location = new Point(pointX, pointY);

            if (Popup_OK.Contains(type))
            {
                pictureBox1.Image = All_in_OSU_.Properties.Resources.OK_Icon;
                this.BackColor = Color.FromArgb(192, 255, 255);
                label_MapsetID.ForeColor = Color.FromArgb(255, 192, 192);
            }
            else if (Popup_Work.Contains(type))
            {
                pictureBox1.Image = All_in_OSU_.Properties.Resources._06_ellipsis_512;
                this.BackColor = Color.FromArgb(255, 224, 192);
                label_MapsetID.ForeColor = Color.FromArgb(192, 192, 255);
            }
            else if (Popup_X.Contains(type))
            {
                pictureBox1.Image = All_in_OSU_.Properties.Resources.delete;
                this.BackColor = Color.FromArgb(255, 192, 192);
                label_MapsetID.ForeColor = Color.FromArgb(192, 192, 255);
            }

            switch (type)
            {
                case Popup.Boot:
                    SetPopupText("", "All in osu!", sString);
                    break;
                case Popup.Login_Success:
                    SetPopupText("", "로그인 성공 :)", sString + "님 환영합니다!");
                    break;
                case Popup.Login_Failure:
                    SetPopupText("", "로그인 실패 :(", "계정을 다시 확인해주세요.");
                    break;
                case Popup.Login_Reconnect:
                    SetPopupText("", "로그인을 다시 시도합니다.", "잠시만 기다려주세요.");
                    break;
                case Popup.Login_Pass:
                    SetPopupText("", "이미 로그인 된 상태입니다 :)", sString + "님 환영합니다!");
                    break;
                case Popup.Wait_Thread:
                    SetPopupText("", "다른 작업이 진행중입니다.", "잠시 후에 다시 시도해주세요.");
                    break;
                case Popup.Beatmap_Apply:
                    SetPopupText("", sString + "개의 비트맵이 적용되었습니다!", "");
                    break;
                case Popup.Setting_Saved:
                    SetPopupText("", "설정이 저장되었습니다!", "일부 설정은 재실행 후 적용됩니다.");
                    break;
                case Popup.Finding_Recommend:
                    SetPopupText("", "추천 비트맵을 찾는 중입니다.", "잠시만 기다려주세요.");
                    break;
                case Popup.Download_Start_Mirror:
                    SetPopupText(MapsetID, sString, "미러에서 다운로드를 시작합니다.");
                    break;
                case Popup.Download_Start_Official:
                    SetPopupText(MapsetID, sString, "공홈에서 다운로드를 시작합니다.");
                    break;
                case Popup.Download_Finish:
                    SetPopupText(MapsetID, sString, "다운로드를 완료했습니다.");
                    break;
                case Popup.Download_Wait:
                    SetPopupText(MapsetID, sString, "다운로드 대기열에 추가했습니다.");
                    break;
                case Popup.osuRunning:
                    SetPopupText("", "osu!가 실행중입니다!", "");
                    break;
                case Popup.osuStopped:
                    SetPopupText("", "osu!가 종료되었습니다!", "");
                    break;
                case Popup.officialNotFound:
                    SetPopupText("", "비트맵을 찾지 못했습니다.", "다른 쿼리로 검색을 시도해보세요.");
                    break;
                case Popup.Disposing:
                    SetPopupText("", "프로그램을 종료하는 중입니다.", "다운로드가 진행중일 경우 기다립니다.");
                    break;
            }

            if (type == Popup.Disposing)
            {
                this.Opacity = 0.9;
                this.Show();
            }
            else
            {
                this.Show();
                this.Opacity = 0;

                Fade(true);
            }
        }

        void SetPopupText(string MapsetID, string MiddleText, string status)
        {
            label_MapsetID.Text = MapsetID;
            label_SongInfo.Text = MiddleText;
            label_Status.Text = status;
        }

        public void LowerPopup()
        {
            this.Location = new Point(this.Location.X, this.Location.Y + this.Height);
        }

        private void Fade(bool toShow)
        {
            int duration = 500;
            int steps = 10;

            if (toShow)
            {
                Timer sTimer = new Timer();
                sTimer.Interval = duration / steps;
                int currentStep = 0;
                sTimer.Tick += (arg1, arg2) =>
                    {
                        this.Opacity = ((double)currentStep) * 9 / 100;
                        currentStep++;

                        if (currentStep >= steps)
                        {
                            Timer outTimer = new Timer();
                            outTimer.Interval = 3000;
                            outTimer.Tick += (arg3, arg4) =>
                            {
                                Fade(false);
                                outTimer.Stop();
                                outTimer.Dispose();
                            };

                            outTimer.Start();

                            sTimer.Stop();
                            sTimer.Dispose();
                        }
                    };
                sTimer.Start();
            }
            else
            {
                Timer sTimer = new Timer();
                sTimer.Interval = duration / steps;
                int currentStep = 10;
                sTimer.Tick += (arg1, arg2) =>
                {
                    this.Opacity = ((double)currentStep) * 9 / 100;
                    currentStep--;

                    if (currentStep <= 0)
                    {
                        sTimer.Stop();
                        sTimer.Dispose();
                        MainForm.Instance.Popups.Remove(this);
                        MainForm.Instance.LowerPopup();
                        this.Free();
                    }
                };
                sTimer.Start();
            }
        }
        private void DownloadCompletePopup_Load(object sender, EventArgs e)
        {
            SetWindowLong(this.Handle, (int)GWL.ExStyle, (int)WS_EX.Layered | (int)WS_EX.Transparent);
        }

        private void Free()
        {
            this.Dispose();
        }
    }
}

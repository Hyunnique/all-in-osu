using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Diagnostics;
using System.Management;
using System.Windows.Automation;

namespace All_in_OSU_
{
    public partial class MainForm : Form
    {
        public string currentVersion = "1.0.3";
        public string updateDate = "160521";


        #region Global Variables
        private bool pClosing = false;

        public static MainForm Instance;
        LoggerClass Logger;
        DownloadClass Downloader;

        public ExtendedBrowser ExtBrowser;

        private ManagementEventWatcher ProcessStartWatcher;
        private ManagementEventWatcher ProcessStopWatcher;

        public List<string> ExistBeatmaps;
        public List<string> DownloadedBeatmaps;

        public string osuPath = "";
        public int refreshRate = 60;
        public int checkLimit = 5;
        public bool smartDL_enable = true;
        public bool smartDL_disable_atplaying = false;
        public bool smartDL_onlyST = false;
        public bool isLogEnabled = true;

        public string acc_ID = "";
        public string acc_PW = "";

        KeyboardHook KeyHook = new KeyboardHook();
        #endregion

        #region Component Functions
        public MainForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void InitializeProgram()
        {
            this.WindowState = FormWindowState.Minimized;
            this.TrayIcon.Visible = true;
            TrayIcon.ContextMenuStrip = TrayMenu;

            HotKeyEventHandler = new EventHandler<KeyPressedEventArgs>(keyHook_keyPressed);
            KeyHook.KeyPressed += HotKeyEventHandler;

            KeyHook.RegisterHotKey(s_ModifierKeys.Control, Keys.E);
            KeyHook.RegisterHotKey(s_ModifierKeys.Control | s_ModifierKeys.Alt, Keys.T);

            this.Hide();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeProgram();

            this.Hide();
            //LoadRegistry();

            Logger = new LoggerClass(isLogEnabled);
            Downloader = new DownloadClass();
            ExtBrowser = new ExtendedBrowser();
            BeatmapDir();

            ProcessCheck();

            //ProcessMonitor.Enabled = true;
            ProcessStartWatcher = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
            ProcessStartWatcher.EventArrived += new EventArrivedEventHandler(Process_StartCheck);
            ProcessStartWatcher.Start();

            ProcessStopWatcher = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
            ProcessStopWatcher.EventArrived += new EventArrivedEventHandler(Process_StopCheck);
            ProcessStopWatcher.Start();

            CheckUpdate();

        }

        private void ProcessCheck()
        {
            if (Process.GetProcessesByName("osu!").Length > 0)
            {
                osuPID = Process.GetProcessesByName("osu!")[0].Id;
                osuRunning = true;
                showPopup("", "", Popup.osuRunning);
            }
        }

        private void LoadRegistry()
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("All in OSU!");
            osuPath = reg.GetValue("path", "").ToString();
            if (osuPath == "")
            {
                ShowSetting();

                LoadRegistry();
                return;
            }

            if (reg.GetValue("smartDL_enable", "T").ToString() == "T") smartDL_enable = true;
            else smartDL_enable = false;

            if (reg.GetValue("smartDL_disable_atplaying", "F").ToString() == "T") smartDL_disable_atplaying = true;
            else smartDL_disable_atplaying = false;

            if (reg.GetValue("smartDL_onlyST", "F").ToString() == "T") smartDL_onlyST = true;
            else smartDL_onlyST = false;

            refreshTimer.Interval = refreshRate * 1000;
            acc_ID = reg.GetValue("acc_a", "").ToString();
            acc_PW = reg.GetValue("acc_b", "").ToString();
            recommendPage = Int32.Parse(reg.GetValue("rpage", "1").ToString());
            recommendIndex = Int32.Parse(reg.GetValue("rindex", "-1").ToString());
        }

        private void CloseProgram()
        {
            try
            {
                foreach (DownloadCompletePopup popupEach in Popups)
                {
                    popupEach.Dispose();
                }

                Popups.Clear();

                //showPopup("", "", Popup.Disposing);

                pClosing = true;

                refreshTimer.Enabled = false;
                refreshTimer = null;

                KeyHook.KeyPressed -= HotKeyEventHandler;
                KeyHook.Dispose();
                KeyHook = null;

                ProcessStartWatcher.Dispose();
                ProcessStartWatcher = null;
                ProcessStopWatcher.Dispose();
                ProcessStopWatcher = null;

                ExtBrowser.Dispose();
                ExtBrowser = null;

                mirrorForm.Dispose();
                mirrorForm = null;

                this.TrayMenu.Visible = false;
                TrayMenu.Dispose();
                TrayMenu = null;
                this.TrayIcon.Visible = false;
                TrayIcon.Dispose();
                TrayIcon = null;

                Instance = null;

                this.Close();
            }
            catch (Exception ex)
            {
                Logger.Error("Error while : Disposing program", ex);
                Environment.Exit(0);
            }
        }
        #endregion
        #region Event Handlers

        EventHandler<KeyPressedEventArgs> HotKeyEventHandler;

        void keyHook_keyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier == s_ModifierKeys.Control && e.Key == Keys.E)
            {
                비트맵미러다운로드ToolStripMenuItem_Click_1(null, null);
            }
            else if (e.Modifier == (s_ModifierKeys.Control | s_ModifierKeys.Alt) && e.Key == Keys.T)
            {
                비트맵추천ToolStripMenuItem_Click(null, null);
            }
        }
        #endregion
        
        private void ShowSetting()
        {
            SettingForm settingForm = new SettingForm();
            
            settingForm.osuPath = osuPath;
            settingForm.smartDL_enable = smartDL_enable;
            settingForm.smartDL_disable_atplaying = smartDL_disable_atplaying;
            settingForm.smartDL_onlyST = smartDL_onlyST;
            settingForm.acc_ID = acc_ID;
            settingForm.acc_PW = acc_PW;
            settingForm.ShowDialog();
        }

        private void BeatmapDir()
        {
            if (!Directory.Exists("beatmaps")) Directory.CreateDirectory("beatmaps");
            if (!Directory.Exists(osuPath + @"\Songs"))
            {
                MessageBox.Show("osu!의 경로가 정상적으로 설정되지 않았습니다!", "All in osu!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                ShowSetting();

                BeatmapDir();
                return;
            }
            string[] beatmapFolders = Directory.GetDirectories(osuPath + @"\Songs");
            List<string> returnList = new List<string>();
            foreach (string beatmapFolder in beatmapFolders)
            {
                string[] aTemp = beatmapFolder.Split('\\');
                returnList.Add(aTemp[aTemp.Length - 1].Split(' ')[0]);
            }

            string[] downloadedBeatmaps = Directory.GetFiles("beatmaps");
            List<string> downList = new List<string>();
            foreach (string beatmapFile in downloadedBeatmaps)
            {
                string aTemp = beatmapFile.Split('\\')[1];
                returnList.Add(aTemp.Split(' ')[0]);
                downList.Add(aTemp);
            }

            ExistBeatmaps = returnList;
            DownloadedBeatmaps = downList;
        }

        public List<object[]> beatmapQueue = new List<object[]>();
        public List<string> beatmapQueue_ID = new List<string>();
        public bool beatmapDownloading = false;

        public void DownloadBeatmap(string MapsetID, string MapCreator, string MapTitle, bool isMirror)
        {
            object[] tempObject = new object[] { MapsetID, MapCreator, MapTitle, isMirror };

            if (beatmapQueue_ID.Contains(MapsetID)) return;
            
            beatmapQueue.Add(tempObject);
            beatmapQueue_ID.Add(MapsetID);

            if (ExtBrowser.isLogged())
            {
                Thread t = new Thread(new ThreadStart(beatmapProcess));
                t.Start();
            }
        }

        //WebClient webClient = new WebClient();
        private void beatmapProcess()
        {
            if (beatmapDownloading || beatmapQueue.Count <= 0) return;

            beatmapDownloading = true;

            if (!Directory.Exists("beatmaps")) Directory.CreateDirectory("beatmaps");
            if (File.Exists("_dl_tmp")) File.Delete("_dl_tmp");

            if ((bool)beatmapQueue[0][3])
            {
                showPopup(beatmapQueue[0][0].ToString(), beatmapQueue[0][1].ToString() + " - " + beatmapQueue[0][2].ToString(), Popup.Download_Start_Mirror);
                Downloader.DownloadFile("http://bloodcat.com/osu/s/" + beatmapQueue[0][0], "_dl_tmp", false);
                beatmapComplete();
            }
            else
            {
                showPopup(beatmapQueue[0][0].ToString(), beatmapQueue[0][1].ToString() + " - " + beatmapQueue[0][2].ToString(), Popup.Download_Start_Official);
                Downloader.DownloadFile("https://osu.ppy.sh/d/" + beatmapQueue[0][0] + "n", "_dl_tmp", true);
                beatmapComplete();
            }
        }

        string ReplaceFileName(string target)
        {
            char[] ReplaceTargets = new char[] { '\\', '/', ':', '*', '?', '<', '>', '"', '|' };

            for (int i = 0; i < ReplaceTargets.Length; i++)
            {
                target = target.Replace(ReplaceTargets[i], '-');
            }
            return target;
        }

        private void beatmapComplete()
        {
            try
            {
                if (!File.Exists("beatmaps\\" + ReplaceFileName(beatmapQueue[0][0] + " " + beatmapQueue[0][1] + " - " + beatmapQueue[0][2] + ".osz")))
                {
                    File.Move("_dl_tmp", "beatmaps\\" + ReplaceFileName(beatmapQueue[0][0] + " " + beatmapQueue[0][1] + " - " + beatmapQueue[0][2] + ".osz"));
                }

                showPopup(beatmapQueue[0][0].ToString(), beatmapQueue[0][1].ToString() + " - " + beatmapQueue[0][2].ToString(), Popup.Download_Finish);

                ExistBeatmaps.Add(beatmapQueue[0][0].ToString());
                DownloadedBeatmaps.Add(ReplaceFileName(beatmapQueue[0][0] + " " + beatmapQueue[0][1] + " - " + beatmapQueue[0][2] + ".osz"));
                beatmapQueue.RemoveAt(0);
                beatmapQueue_ID.RemoveAt(0);

                if (osuRunning)
                {
                    foreach (string bfile in DownloadedBeatmaps)
                    {
                        Process run = new Process();
                        run.StartInfo.FileName = @"beatmaps\" + bfile;
                        run.Start();
                    }

                    showPopup("", DownloadedBeatmaps.Count.ToString(), Popup.Beatmap_Apply);
                    DownloadedBeatmaps.Clear();
                }
            }
            catch
            {
                ;
            }

            Thread.Sleep(2000);
            beatmapDownloading = false;

            if (pClosing)
            {
                Downloader = null;
                return;
            }
            beatmapProcess();
        }

        public List<DownloadCompletePopup> Popups = new List<DownloadCompletePopup>();
        private delegate void popupDelegate(string d_id, string d_string, Popup d_type);
        public void showPopup(string d_id, string d_string, Popup d_type)
        {
            if (this.InvokeRequired)
            {
                popupDelegate sDelegate = new popupDelegate(showPopup);
                this.Invoke(sDelegate, new object[] { d_id, d_string, d_type });
            }
            else
            {
                DownloadCompletePopup popup = new DownloadCompletePopup();
                Popups.Add(popup);
                popup.ShowPopup(d_id, d_string, d_type, Popups.Count);
            }
        }

        public void LowerPopup()
        {
            foreach (DownloadCompletePopup popup in Popups)
            {
                popup.LowerPopup();
            }
        }

        void CheckUpdate()
        {
            // Do stuff
            showPopup("", "Version : " + currentVersion + " (" + updateDate + ")", Popup.Boot);

            // Login
            ExtBrowser.Navigate("https://osu.ppy.sh/forum/ucp.php?mode=login", ExtendedBrowser.WorkType.Login);
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            BeatmapDir();
            if (!smartDL_enable) return;
            if (smartDL_disable_atplaying && osuRunning) return;

            string s_mode = "-1";
            if (smartDL_onlyST) s_mode = "0";

            if (ExtBrowser.isLogged()) ExtBrowser.Navigate("https://osu.ppy.sh/p/beatmaplist?m=" + s_mode, ExtendedBrowser.WorkType.getNewBeatmap);

            refreshTimer.Interval = refreshRate * 1000;
        }

        public bool osuRunning = false;
        public int osuPID = 0;
        private void Process_StartCheck(object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.Properties["ProcessName"].Value.ToString() == "osu!.exe" && !osuRunning)
            {
                if (smartDL_disable_atplaying) refreshTimer.Enabled = false;

                osuRunning = true;
                osuPID = Int32.Parse(e.NewEvent.Properties["ProcessId"].Value.ToString());
                showPopup("", "", Popup.osuRunning);

                if (DownloadedBeatmaps.Count <= 0) return;

                foreach (string bfile in DownloadedBeatmaps)
                {
                    Process run = new Process();
                    run.StartInfo.FileName = @"beatmaps\" + bfile;
                    run.Start();
                }

                showPopup("", DownloadedBeatmaps.Count.ToString(), Popup.Beatmap_Apply);
                DownloadedBeatmaps.Clear();
            }
        }

        private void Process_StopCheck(object sender, EventArrivedEventArgs e)
        {
            if (e.NewEvent.Properties["ProcessName"].Value.ToString() == "osu!.exe" && Int32.Parse(e.NewEvent.Properties["ProcessId"].Value.ToString()) == osuPID && osuRunning)
            {
                if (smartDL_disable_atplaying && smartDL_enable) refreshTimer.Enabled = true;

                osuRunning = false;
                showPopup("", "", Popup.osuStopped);
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseProgram();
        }

        private void 설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSetting();
        }

        public int recommendPage = 1;
        public int recommendIndex = -1;

        private void 비트맵추천ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!비트맵추천ToolStripMenuItem.Enabled) return;

            showPopup("", "", Popup.Finding_Recommend);
            ExtBrowser.Navigate("https://osu.ppy.sh/p/beatmaplist?l=1&r=0&q=&g=0&la=0&ra=&s=3&o=-1&m=0&c=1&page=" + recommendPage, ExtendedBrowser.WorkType.RecommendBeatmap);
        }

        SmartMirroring mirrorForm = new SmartMirroring();
        private void 비트맵미러다운로드ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                mirrorForm.Show();
            }
            catch
            {
                mirrorForm = new SmartMirroring();
                mirrorForm.Show();
            }
        }

        BeatmapSet beatmapsetForm;

        private void 비트맵리스트백업추출ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (beatmapsetForm != null) beatmapsetForm.Dispose();

            beatmapsetForm = new BeatmapSet();
            beatmapsetForm.Show();
        }

        /*
        public static String channelName = null;
        public static string currdir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\";
        private void hook_osu()
        {
            Config.Register("Help osu! users to download beatmap", "All in osu!.vshost.exe", "FileMonInject.dll");
            RemoteHooking.IpcCreateServer<RemoteHook>(ref channelName, System.Runtime.Remoting.WellKnownObjectMode.Singleton);
            int processid = Process.GetProcessesByName("notepad++")[0].Id;

            string asd = "";
            try
            {
                Config.Register("_osuInject32", "_osuInject32.dll");
            }
            catch (Exception ex)
            {
                asd = ex.InnerException.Message;
            }
            RemoteHooking.Inject(processid, InjectionOptions.DoNotRequireStrongName, currdir + "FileMonInject.dll", currdir + "FileMonInject.dll", new Object[] { channelName });

            while (true)
            {
                Thread.Sleep(1000);
            }


            /*
            try
            {
                //ManagementEventWatcher startWatch = new ManagementEventWatcher(@"\\.\root\CIMV2", "SELECT * FROM __InstanceCreationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process'");
                ManagementEventWatcher startWatch = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
                startWatch.EventArrived
                                    += new EventArrivedEventHandler(startWatch_EventArrived);
                startWatch.Start();
            }
            catch (Exception ex)
            {
                ;
            }
            //Config.Register("Beatmap utility for osu! users", "All in osu!.exe", )
            //RemoteHooking.Inject(osuPID, "Kernel32.dll", "Kernel32.dll", )
             * */
        //}
        /*
        void startWatch_EventArrived(object sender, EventArrivedEventArgs e)
        {
            //ManagementBaseObject obj = (ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value;
            Process.GetProcessById(Int32.Parse(e.NewEvent.Properties["processId"].Value.ToString())).WaitForInputIdle();
            string ttt = "";
            foreach (Process prs in Process.GetProcessesByName("chrome"))
            {
                prs.Refresh();
                ttt = ttt + prs.MainWindowHandle.ToString();
                AutomationElement elm = null;
                try
                {
                    elm = AutomationElement.FromHandle(prs.MainWindowHandle);
                    ttt = ttt + "s";
                }
                catch
                {
                    ;
                }

                //if (elm == null) return;

                try
                {
                    AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                    string tempURL = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
                    MessageBox.Show(tempURL);
                    if (tempURL.StartsWith("https://osu.ppy.sh/s/")) // osu! 에서 s인지 b인지 확인후 변경하기
                    {
                        string MapsetID = tempURL.Split(new string[] { "https://osu.ppy.sh/s/" }, StringSplitOptions.None)[1];

                        MessageBox.Show(MapsetID);
                    }
                }
                catch { }
            }
            MessageBox.Show(ttt);
            return;
            if (e.NewEvent.Properties["ProcessName"].Value.ToString() == "chrome.exe")
            {
                int pID = Int32.Parse(e.NewEvent.Properties["ProcessId"].Value.ToString());
                Process targetBrowser = Process.GetProcessById(pID);

                AutomationElement elm = null;
                try
                {
                    elm = AutomationElement.FromHandle(targetBrowser.Handle);
                }
                catch
                {
                    ;
                }

                if (elm == null) return;

                AutomationElement elmUrlBar = elm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                string tempURL = ((ValuePattern)elmUrlBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
                if (tempURL.StartsWith("https://osu.ppy.sh/s/")) // osu! 에서 s인지 b인지 확인후 변경하기
                {
                    string MapsetID = tempURL.Split(new string[] { "https://osu.ppy.sh/s/" }, StringSplitOptions.None)[1];
                    
                    targetBrowser.CloseMainWindow();
                    MessageBox.Show(MapsetID);
                }
            }
 
            string pName = e.NewEvent.Properties["TargetInstance"].Value.ToString();
            string pCommandLine = "";

            try
            {
                pCommandLine = e.NewEvent.Properties["CommandLine"].Value.ToString();
            }
            catch
            {
                ;
            }

            popupInvoke("", "Name: " + pName + "  Command Line: " + pCommandLine, 0);
        }
       

        private void tToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(hook_osu));
            t.Start();
        }
         * */
    }
}

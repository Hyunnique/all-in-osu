using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace All_in_OSU_
{
    public class ExtendedBrowser : IDisposable
    {
        public enum WorkType
        {
            None,
            Login,
            LoginValidate,
            LoginReconnect,
            getNewBeatmap,
            DownloadMirror,
            DownloadOfficial,
            RecommendBeatmap
        }

        private LoggerClass Logger;

        private WebBrowser webBrowser = new WebBrowser();
        private WebClient webClient = new WebClient();

        private WorkType workType;
        private string lastQuery = "";

        public ExtendedBrowser()
        {
            Logger = new LoggerClass(MainForm.Instance.isLogEnabled);
            Logger.Log("ExtendedBrowser by Lecoren Loaded.");
            webBrowser.ScriptErrorsSuppressed = true;
            
            webBrowser.DocumentCompleted += BrowserHandler;
        }

        private HtmlElement GetElementByClassName(HtmlElement parent, string tagName, string targetClass)
        {
            HtmlElementCollection tempElementCollection = parent.GetElementsByTagName(tagName);
            foreach (HtmlElement curElement in tempElementCollection)
            {
                if (curElement.GetAttribute("classname").ToString() == targetClass)
                {
                    return curElement;
                }
            }

            return null;
        }

        private HtmlElement GetElementByAttribute(HtmlElement parent, string tagName, string attribute, string targetName)
        {
            HtmlElementCollection tempElementCollection = parent.GetElementsByTagName(tagName);
            foreach (HtmlElement curElement in tempElementCollection)
            {
                if (curElement.GetAttribute(attribute).ToString() == targetName)
                {
                    return curElement;
                }
            }

            return null;
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

        public void Navigate(string URL, WorkType wt)
        {
            if (isWorking())
            {
                Logger.Log("ExtendedBrowser is already working.");
                MainForm.Instance.showPopup("", "", Popup.Wait_Thread);
                return;
            }
            else
            {
                Logger.Log("Navigating to " + URL + "...");
                workType = wt;
                webBrowser.Navigate(URL);
            }
        }

        public bool isWorking()
        {
            if (webBrowser.ReadyState == WebBrowserReadyState.Complete || webBrowser.ReadyState == WebBrowserReadyState.Uninitialized) return false;
            else return true;
        }

        public bool isLogged()
        {
            if (MainForm.Instance.acc_ID == "") return true;

            HtmlDocument doc = webBrowser.Document;
            if (webBrowser.Url.ToString().StartsWith("https://osu.ppy.sh/") && GetElementByClassName(doc.Body, "i", "icon-off") == null)
            {
                Navigate("https://osu.ppy.sh/forum/ucp.php?mode=login", WorkType.Login);
                MainForm.Instance.showPopup("", "", Popup.Login_Reconnect);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetQuery(string query)
        {
            lastQuery = query;
        }

        private void BrowserHandler(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string url = e.Url.ToString();
            if (!(url.StartsWith("http://") || url.StartsWith("https://")) || e.Url.AbsolutePath != webBrowser.Url.AbsolutePath) return;


            HtmlDocument doc = webBrowser.Document;
            HtmlElement body = doc.Body;

            string MapsetID = "";
            string MapCreator = "";
            string MapTitle = "";

            switch (workType)
            {
                case WorkType.Login:
                    if (MainForm.Instance.acc_ID == "") return;

                    if (GetElementByAttribute(doc.GetElementById("wrapcentre"), "input", "name", "username") != null)
                    {

                        HtmlElement IDInput = GetElementByAttribute(doc.GetElementById("wrapcentre"), "input", "name", "username");
                        IDInput.SetAttribute("value", MainForm.Instance.acc_ID);
                        HtmlElement PWInput = GetElementByAttribute(doc.GetElementById("wrapcentre"), "input", "name", "password");
                        PWInput.SetAttribute("value", MainForm.Instance.acc_PW);
                        HtmlElement LoginButton = GetElementByClassName(doc.GetElementById("wrapcentre"), "input", "btnmain");
                        LoginButton.InvokeMember("Click");

                        workType = WorkType.LoginValidate;
                    }
                    else
                    {
                        MainForm.Instance.showPopup("", MainForm.Instance.acc_ID, Popup.Login_Pass);

                        MainForm.Instance.refreshTimer.Interval = MainForm.Instance.refreshRate * 1000;
                        MainForm.Instance.refreshTimer.Enabled = true;
                    }
                    break;

                case WorkType.LoginValidate:
                    if (MainForm.Instance.acc_ID == "") return;
                    if (url == "https://osu.ppy.sh/forum/ucp.php?mode=login")
                    {
                        // Login Fail
                        MainForm.Instance.showPopup("", "", Popup.Login_Failure);
                        MainForm.Instance.refreshTimer.Interval = MainForm.Instance.refreshRate * 1000;
                        MainForm.Instance.refreshTimer.Enabled = true;
                    }
                    else if (url == "https://osu.ppy.sh/forum/index.php" || url == "https://osu.ppy.sh/forum/")
                    {
                        // Login Success
                        MainForm.Instance.showPopup("", MainForm.Instance.acc_ID, Popup.Login_Success);

                        MainForm.Instance.refreshTimer.Interval = MainForm.Instance.refreshRate * 1000;
                        MainForm.Instance.refreshTimer.Enabled = true;
                    }
                    else
                    {
                        // Login Fail
                        MainForm.Instance.showPopup("", "", Popup.Login_Failure);
                        MainForm.Instance.refreshTimer.Interval = MainForm.Instance.refreshRate * 1000;
                        MainForm.Instance.refreshTimer.Enabled = true;
                    }
                    break;

                case WorkType.getNewBeatmap:
                    if (!isLogged()) return;
                    HtmlElement beatmapListing = GetElementByClassName(body, "div", "beatmapListing");

                    for (int i = 0; i < MainForm.Instance.checkLimit; i++)
                    {
                        HtmlElement tempA = beatmapListing.Children[i];
                        if (!MainForm.Instance.ExistBeatmaps.Contains(tempA.GetAttribute("id")) && !MainForm.Instance.beatmapQueue_ID.Contains(tempA.GetAttribute("id")))
                        {
                            MapsetID = tempA.GetAttribute("id");
                            MapCreator = ReplaceFileName(GetElementByClassName(tempA, "span", "artist").InnerText);
                            MapTitle = ReplaceFileName(GetElementByClassName(tempA, "a", "title").InnerText);

                            if (MainForm.Instance.beatmapDownloading) MainForm.Instance.showPopup(MapsetID, MapCreator + " - " + MapTitle, Popup.Download_Wait);

                            if (isMirrorAvailable(MapsetID))
                            {
                                MainForm.Instance.DownloadBeatmap(MapsetID, MapCreator, MapTitle, true);
                            }
                            else
                            {
                                MainForm.Instance.DownloadBeatmap(MapsetID, MapCreator, MapTitle, false);
                            }
                        }
                    }
                    break;

                case WorkType.DownloadMirror:
                    if (doc.GetElementsByTagName("main")[0].Children.Count <= 0)
                    {
                        Navigate("https://osu.ppy.sh/p/beatmaplist?q=" + lastQuery + "&m=-1", WorkType.DownloadOfficial);
                        return;
                    }

                    HtmlElement beatmapElement = doc.GetElementsByTagName("main")[0].Children[0];

                    HtmlElement aElement = beatmapElement.GetElementsByTagName("a")[0];
                    MapsetID = aElement.GetAttribute("href").Split(new string[] { "s/" }, StringSplitOptions.None)[1];
                    MapCreator = beatmapElement.InnerHtml.Split(new string[] { "</a><br>" }, StringSplitOptions.None)[1].Split(new string[] { "<span" }, StringSplitOptions.None)[0];
                    MapTitle = aElement.InnerText;
                    if (MainForm.Instance.beatmapDownloading) MainForm.Instance.showPopup(MapsetID, MapCreator + " - " + MapTitle, Popup.Download_Wait);
                    MainForm.Instance.DownloadBeatmap(MapsetID, MapCreator, MapTitle, true);
                    break;

                case WorkType.DownloadOfficial:
                    if (!isLogged()) return;

                    if (GetElementByClassName(doc.Body, "div", "beatmapListing").Children.Count <= 0)
                    {
                        MainForm.Instance.showPopup("", "", Popup.officialNotFound);
                        return;
                    }

                    HtmlElement beatmapElement2 = GetElementByClassName(doc.Body, "div", "beatmapListing").Children[0];
                    MapsetID = beatmapElement2.GetAttribute("id");
                    MapCreator = GetElementByClassName(beatmapElement2, "span", "artist").InnerText;
                    MapTitle = GetElementByClassName(beatmapElement2, "a", "title").InnerText;
                    if (MainForm.Instance.beatmapDownloading) MainForm.Instance.showPopup(MapsetID, MapCreator + " - " + MapTitle, Popup.Download_Wait);
                    MainForm.Instance.DownloadBeatmap(MapsetID, MapCreator, MapTitle, false);
                    break;

                case WorkType.RecommendBeatmap:
                    if (!isLogged())
                    {
                        return;
                    }

                    HtmlElement beatmapListing2 = GetElementByClassName(body, "div", "beatmapListing");

                    for (int currentIndex = MainForm.Instance.recommendIndex; currentIndex < beatmapListing2.Children.Count; currentIndex++)
                    {
                        MainForm.Instance.recommendIndex++;
                        Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("All in OSU!").SetValue("rindex", MainForm.Instance.recommendIndex);
                        if (MainForm.Instance.recommendIndex >= beatmapListing2.Children.Count) break;

                        HtmlElement tempA = beatmapListing2.Children[currentIndex];
                        if (!MainForm.Instance.ExistBeatmaps.Contains(tempA.GetAttribute("id")) && !MainForm.Instance.beatmapQueue_ID.Contains(tempA.GetAttribute("id")))
                        {
                            MapsetID = tempA.GetAttribute("id");
                            MapCreator = ReplaceFileName(GetElementByClassName(tempA, "span", "artist").InnerText);
                            MapTitle = ReplaceFileName(GetElementByClassName(tempA, "a", "title").InnerText);

                            if (MainForm.Instance.beatmapDownloading) MainForm.Instance.showPopup(MapsetID, MapCreator + " - " + MapTitle, Popup.Download_Wait);

                            if (isMirrorAvailable(MapsetID))
                            {
                                MainForm.Instance.DownloadBeatmap(MapsetID, MapCreator, MapTitle, true);
                            }
                            else
                            {
                                MainForm.Instance.DownloadBeatmap(MapsetID, MapCreator, MapTitle, false);
                            }
                            return;
                        }
                    }

                    if (MainForm.Instance.recommendPage <= 124)
                    {
                        MainForm.Instance.recommendPage++;
                        MainForm.Instance.recommendIndex = -1;
                    }
                    else
                    {
                        MainForm.Instance.recommendPage = 1;
                        MainForm.Instance.recommendIndex = -1;
                    }

                    Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("All in OSU!").SetValue("rpage", MainForm.Instance.recommendPage);
                    Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("All in OSU!").SetValue("rindex", MainForm.Instance.recommendIndex);

                    Navigate("https://osu.ppy.sh/p/beatmaplist?l=1&r=0&q=&g=0&la=0&ra=&s=3&o=-1&m=0&c=1&page=" + MainForm.Instance.recommendPage, WorkType.RecommendBeatmap);
                    break;
            }

        }

        public bool isMirrorAvailable(string MapsetID)
        {
            string wCl = webClient.DownloadString(new Uri("http://bloodcat.com/osu/?mod=json&c=s&q=" + MapsetID));
            if (wCl == "[]")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Dispose()
        {
            webBrowser.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace All_in_OSU_
{
    public partial class BeatmapSet : Form
    {
        public BeatmapSet()
        {
            InitializeComponent();
        }

        private void button_toright_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            if (isLoaded) isLoaded = false;

            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button_toleft_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null) return;

            if (isLoaded)
            {
                string mName = listBox2.SelectedItem.ToString().Replace(listBox2.SelectedItem.ToString().Split(' ')[0], "");
                if (MainForm.Instance.ExtBrowser.isMirrorAvailable(listBox2.SelectedItem.ToString().Split(' ')[0])) MainForm.Instance.DownloadBeatmap(listBox2.SelectedItem.ToString().Split(' ')[0], "", mName, true);
                else MainForm.Instance.DownloadBeatmap(listBox2.SelectedItem.ToString().Split(' ')[0], "", mName, false);
            }
            listBox1.Items.Add(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void BeatmapSet_Load(object sender, EventArgs e)
        {
            LoadBeatmaps();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void LoadBeatmaps()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            string[] beatmapFolders = Directory.GetDirectories(MainForm.Instance.osuPath + @"\Songs");
            foreach (string beatmapFolder in beatmapFolders)
            {
                string[] aTemp = beatmapFolder.Split('\\');
                listBox1.Items.Add(aTemp[aTemp.Length - 1]);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || listBox2.Items.Count <= 0) return;

                StreamWriter sw = new StreamWriter(textBox1.Text + ".aioset");
                foreach (string sItem in listBox2.Items)
                {
                    sw.WriteLine(sItem);
                }

                sw.Close();

                MessageBox.Show("저장이 완료되었습니다!", "All in osu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장에 실패했습니다." + Environment.NewLine + ex.Message, "All in osu!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool isLoaded = false;
        private int currint = 0;
        private int maxint = 0;

        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All in osu! Beatmap set|*.aioset";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadBeatmaps();
                StreamReader sr = new StreamReader(dialog.FileName);

                foreach (string line in sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    if (line != "") listBox2.Items.Add(line);
                }

                if (MessageBox.Show("비트맵셋에 포함된 비트맵을 모두 다운로드하시겠습니까?", "All in osu!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    foreach (string line in listBox2.Items)
                    {
                        button_toleft.Enabled = false;
                        button_toright.Enabled = false;
                        button_load.Enabled = false;
                        button_save.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        
                        maxint = listBox2.Items.Count;
                        currint = 0;
                        label1.Text = "Downloading Beatmaps (" + currint + " / " + maxint + ")";
                        label1.Visible = true;

                        DownloadRequester.Enabled = true;
                    }
                }
                else
                {
                    isLoaded = true;
                }
            }
        }

        private void DownloadRequester_Tick(object sender, EventArgs e)
        {
            if (!MainForm.Instance.ExtBrowser.isWorking())
            {
                string mName = listBox2.Items[0].ToString().Replace(listBox2.Items[0].ToString().Split(' ')[0], "");
                if (MainForm.Instance.ExtBrowser.isMirrorAvailable(listBox2.Items[0].ToString().Split(' ')[0])) MainForm.Instance.DownloadBeatmap(listBox2.Items[0].ToString().Split(' ')[0], "", mName, true);
                else MainForm.Instance.DownloadBeatmap(listBox2.Items[0].ToString().Split(' ')[0], "", mName, false);
                listBox2.Items.RemoveAt(0);
                currint++;

                label1.Text = "Downloading Beatmaps (" + currint + " / " + maxint + ")";
            }

            if (currint >= maxint)
            {
                button_toleft.Enabled = true;
                button_toright.Enabled = true;
                button_load.Enabled = true;
                button_save.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;

                currint = 0;
                maxint = 0;
                label1.Visible = false;
                DownloadRequester.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string sItem in listBox1.Items)
            {
                listBox2.Items.Add(sItem);
            }

            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isLoaded) return;

            foreach (string sItem in listBox2.Items)
            {
                listBox1.Items.Add(sItem);
            }

            listBox2.Items.Clear();
        }
    }
}

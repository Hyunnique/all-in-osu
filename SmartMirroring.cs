using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace All_in_OSU_
{
    public partial class SmartMirroring : Form
    {
        public SmartMirroring()
        {
            InitializeComponent();
        }

        private void SmartMirroring_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Activate();
            textBox1.Focus();
        }

        private void SmartSearch()
        {
            if (textBox1.Text == "") return;

            string textType = "?";
            int beatmapNumber = 0;

            try
            {
                beatmapNumber = Int32.Parse(textBox1.Text);
                if (beatmapNumber > 0 && beatmapNumber < 10000000) textType = "beatmapnumber";
                else textType = "hybrid";
            }
            catch
            {
                textType = "hybrid";
            }

            MainForm.Instance.ExtBrowser.SetQuery(textBox1.Text);
            if (textType == "beatmapnumber")
            {
                MainForm.Instance.ExtBrowser.Navigate("http://bloodcat.com/osu/?q=" + beatmapNumber + "&c=b&s=&m=", ExtendedBrowser.WorkType.DownloadMirror);
            }
            else
            {
                MainForm.Instance.ExtBrowser.Navigate("http://bloodcat.com/osu/?q=" + textBox1.Text + "&c=o&s=&m=", ExtendedBrowser.WorkType.DownloadMirror);
            }

            textBox1.Text = "";
            this.Hide();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                textBox1.Text = "";
                this.Hide();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SmartSearch();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            this.Activate();
            textBox1.Focus();
        }

        private void SmartMirroring_Leave(object sender, EventArgs e)
        {
            this.Activate();
            textBox1.Focus();
        }

        private void SmartMirroring_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
            textBox1.Focus();
        }
    }
}

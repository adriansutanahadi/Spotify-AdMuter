using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Spotify_AdMuter
{
    public partial class Form1 : Form
    {
        StatusFetcher statusFetcher;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            statusFetcher = new StatusFetcher();
        }

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            await statusFetcher.UpdateStatus();
            if (checkBox1.Checked)
            {
                status.Text = statusFetcher.status_json;
            }
            else if (statusFetcher.status.isPrivateSession())
            {
                status.Text = "Private Session";
            }
            else if (statusFetcher.status.isAd())
            {
                status.Text = "Ad";
            }
            else
            {
                status.Text = statusFetcher.status.track.artist_resource.name + "-" + statusFetcher.status.track.track_resource.name;
            }
        }
    }
}

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
    public partial class Main : Form
    {
        StatusFetcher statusFetcher;
        SpotifyMuter spotifyMuter;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            statusFetcher = new StatusFetcher();
            spotifyMuter = new SpotifyMuter();
        }

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            spotifyMuter.FindSpotify();
            if (spotifyMuter.spotifyFound)
            {
                if (spotifyMuter.isMuting())
                {
                    muterStatus.Text = "Muting ad...";
                }
                else
                {
                    muterStatus.Text = "Spotify found. Ready to mute ad.";
                }
            }
            else
            {
                muterStatus.Text = "Spotify not found.";
                spotifyStatus.Text = "";
            }
            
            await statusFetcher.UpdateStatus();
            if (showJSON.Checked)
            {
                spotifyStatus.Text = statusFetcher.status_json;
            }
            else if (statusFetcher.status.isError())
            {
                spotifyStatus.Text = "";
            }
            else if (statusFetcher.status.isPrivateSession())
            {
                spotifyStatus.Text = "Private Session";
            }
            else if (statusFetcher.status.isAd())
            {
                spotifyMuter.MuteSpotify(true);
                spotifyStatus.Text = "Ad";
            }
            else if (statusFetcher.status.isPaused())
            {
                spotifyStatus.Text = "Paused";
            }
            else
            {
                spotifyMuter.MuteSpotify(false);
                spotifyStatus.Text = statusFetcher.status.track.artist_resource.name + " - " + statusFetcher.status.track.track_resource.name;
            }
        }
    }
}

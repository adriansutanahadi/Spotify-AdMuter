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

        private async void Form1_Load(object sender, EventArgs e)
        {
            statusFetcher = new StatusFetcher();
            await statusFetcher.UpdateTokens();
            while (true)
            {
                await statusFetcher.UpdateStatus();
                status.Text = statusFetcher.status;
                await Task.Delay(250);
            }
        }
    }
}

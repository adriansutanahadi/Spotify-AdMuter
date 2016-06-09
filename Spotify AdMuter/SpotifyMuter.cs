using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_AdMuter
{
    class SpotifyMuter
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        public bool spotifyFound;
        private uint spotifyPID;
        private bool muted;

        public SpotifyMuter()
        {
            muted = false;
        }

        public void MuteSpotify(bool mute)
        {
            if (muted == mute)
            {
                return;
            }
            FindSpotify();
            if (!spotifyFound)
            {
                return;
            }
            VolumeMixer.SetApplicationVolume(Convert.ToInt32(spotifyPID), mute ? 0f : 100f);
            muted = mute;
        }

        public void FindSpotify()
        {
            var hWnd = FindWindow("SpotifyMainWindow", null);
            if (hWnd == IntPtr.Zero)
            {
                spotifyFound = false;
                return;
            }

            uint pID;
            GetWindowThreadProcessId(hWnd, out pID);
            if (pID == 0)
            {
                spotifyFound = false;
                return;
            }
            spotifyFound = true;
            spotifyPID = pID;
        }

        public bool isMuting()
        {
            return muted;
        }
    }
}

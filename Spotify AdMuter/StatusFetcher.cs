using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_AdMuter
{
    class StatusFetcher
    {
        private OAuthFetcher oauthFetcher;
        private CSRFFetcher csrfFetcher;
        private string statusUrl;
        public string status;

        public StatusFetcher()
        {
            oauthFetcher = new OAuthFetcher();
            csrfFetcher = new CSRFFetcher();
        }

        public async Task UpdateStatus()
        {
            statusUrl = WebHandler.getLocalSpotifyUrl("/remote/status.json" + "?oauth=" + oauthFetcher.oauth.t + "&csrf=" + csrfFetcher.csrf.token);
            status = await WebHandler.FetchDataAsync(statusUrl);
        }
        public async Task UpdateTokens()
        {
            await oauthFetcher.UpdateOAuth();
            await csrfFetcher.UpdateCSRF();
        }
    }
}

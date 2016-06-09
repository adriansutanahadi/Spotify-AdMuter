using Newtonsoft.Json;
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
        public SpotifyStatus status;
        public string status_json;

        public StatusFetcher()
        {
            oauthFetcher = new OAuthFetcher();
            csrfFetcher = new CSRFFetcher();
        }

        public async Task UpdateStatus()
        {
            if (oauthFetcher.oauth == null || csrfFetcher.csrf == null)
            {
                await UpdateTokens();
            }

            statusUrl = WebHandler.getLocalSpotifyUrl("/remote/status.json" + "?oauth=" + oauthFetcher.oauth.t + "&csrf=" + csrfFetcher.csrf.token);
            status_json = await WebHandler.FetchDataAsync(statusUrl);
            status = JsonConvert.DeserializeObject<SpotifyStatus>(status_json);

            // error type 4102 is invalid oauth, 4107 is invalid csrf
            if (status.isError() && (status.error.type == "4102" || status.error.type == "4107"))
            {
                await UpdateTokens();
            }
        }

        public async Task UpdateTokens()
        {
            await oauthFetcher.UpdateOAuth();
            await csrfFetcher.UpdateCSRF();
        }
    }
}

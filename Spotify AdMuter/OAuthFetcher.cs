using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_AdMuter
{
    class OAuthFetcher
    {
        public string oauthUrl { get; private set; }
        public OAuth oauth { get; private set; }

        public OAuthFetcher()
        {
            oauthUrl = "https://open.spotify.com/token";
        }

        public async Task UpdateOAuth()
        {
            var res = await WebHandler.FetchDataAsync(oauthUrl);
            oauth = JsonConvert.DeserializeObject<OAuth>(res);
        }
    }
}

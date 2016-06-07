using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_AdMuter
{
    class CSRFFetcher
    {
        public string csrfUrl { get; private set; }
        public CSRF csrf { get; private set; }

        public CSRFFetcher()
        {
            csrfUrl = WebHandler.getLocalSpotifyUrl("/simplecsrf/token.json");
        }

        public async Task UpdateCSRF()
        {
            var res = await WebHandler.FetchDataAsync(csrfUrl);
            csrf = JsonConvert.DeserializeObject<CSRF>(res);
        }
    }
}

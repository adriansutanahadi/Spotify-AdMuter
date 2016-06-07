using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_AdMuter
{
    class WebHandler
    {
        private const string localhost = "127.0.0.1";
        private const string port = "4380";

        // Gets data from the passed URL
        public static async Task<string> FetchDataAsync(string url)
        {
            // Create an HTTP web request using the URL
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add("Origin", "https://open.spotify.com");

            // Send the request to the server and wait for the response
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response
                using (StreamReader srd = new StreamReader(response.GetResponseStream()))
                {
                    // Use this stream to build a string
                    string res = await srd.ReadToEndAsync();

                    // Return the data as a string
                    return res;
                }
            }
        }

        public static string getLocalSpotifyUrl(string path)
        {
            return "http://" + localhost + ":" + port + path;
        }
    }
}

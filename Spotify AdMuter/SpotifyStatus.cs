using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_AdMuter
{
    public class Track
    {
        public TrackResource track_resource;
        public ArtistResource artist_resource;
        public AlbumResource album_resource;
        public int length;
        public string track_type;
    }

    public class TrackResource
    {
        public string name;
    }

    public class ArtistResource
    {
        public string name;
    }

    public class AlbumResource
    {
        public string name;
    }

    public class OpenGraphState
    {
        public bool private_session;
    }
    public class SpotifyStatus
    {
        public bool playing;
        public Track track;
        public double playing_position;
        public OpenGraphState open_graph_state; 

        public bool isPrivateSession()
        {
            return open_graph_state.private_session;
        }

        public bool isAd()
        {
            return track.track_type == "ad";
        }
    }
}

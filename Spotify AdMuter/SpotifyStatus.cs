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

    public class Error
    {
        public string type;
        public string message;
    }

    public class SpotifyStatus
    {
        public bool playing;
        public bool next_enabled;
        public Track track;
        public double playing_position;
        public OpenGraphState open_graph_state;
        public Error error;


        public bool isError()
        {
            return error != null;
        }

        public bool isPrivateSession()
        {
            return (open_graph_state != null && open_graph_state.private_session);
        }

        public bool isAd()
        {
            return (track != null && track.track_type == "ad") || next_enabled == false;
        }

        public bool isPaused()
        {
            return !playing;
        }

        public bool isPlaying()
        {
            return playing;
        }
    }
}

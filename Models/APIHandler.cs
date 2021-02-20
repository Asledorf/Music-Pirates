using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Pirates.Models
{
    public class APIHandler
    {
        public enum eSite
        {
            Spotify,
            YoutubeMusic,
            Soundcloud,
            Amazon,
            Pandora
        }

        public Guid ID { get; set; }
        public string Key { get; set; }
        public eSite Site { get; set; }
        
        public void GetPlaybackInfo()
        {

        }
    }
}
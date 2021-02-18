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

        public string Key { get; set; }
        public eSite Site { get; set; }
        
        /*pubic void GetPlaybackInfo()
        {

        }*/
    }
}
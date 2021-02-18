using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Pirates.Models
{
    public class Playlist
    {
        public string Name { get; set; }
        public List<Models.Song> MyProperty = new List<Models.Song>();
    }
}
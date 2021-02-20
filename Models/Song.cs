using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Pirates.Models
{
    public class Song
    {
        public enum eGenre
        {
            Rock,
            Metal,
            Pop,
            KPop,
            Country,
            Jazz,
            Nightcore,
            Classical,
            Rap,
            Beatbox,
            Folk,
            Blues,
            HeavyMetal,
            Electro,
            PunkRock,
            AlternativeRock,
            Techno,
            Gospel,
            Dubstep
        }

        public Guid ID { get; set; }
        public string Title { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumCoverURL { get; set; }
        public string Artist { get; set; }
        public eGenre Genre { get; set; }
        private bool liked = false;
        public bool Liked { get{ return liked; } set { liked = !liked; if (disliked) disliked = false; } }
        private bool disliked = false;
        public bool Disliked { get{ return disliked; } set { disliked = !disliked; if (liked) liked = false; } }
    }
}
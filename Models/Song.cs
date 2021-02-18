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

        public string Title { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public eGenre Genre { get; set; }
        public bool Liked { get; set { if (Disliked) Disliked = false; } }
        public bool Disliked { get; set { if (Liked) Liked = false; } }
    }
}
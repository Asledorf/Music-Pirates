using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Pirates.Models
{
    public class User
    {
        public static List<User> Users = new List<User>();
        public Guid ID { get; set; }
        public string ImgURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } //Will likely need to setup some security stuffs later
        public DateTime Birthday { get; set; }

        protected List<User> Following = new List<User>();
        protected List<User> Followers = new List<User>();
        protected List<Playlist> Playlists = new List<Playlist>();
        protected List<Song> Liked = new List<Song>();
        protected List<Song> Disliked = new List<Song>();
    }
}
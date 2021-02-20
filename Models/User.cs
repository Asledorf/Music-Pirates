using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Pirates.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string ImgURL { get; set; }
        public static List<User> Users = new List<User>();
        public string Username { get; set; }
        public string Password { get; set; } //Will likely need to setup some security stuffs later
        public DateTime Birthday { get; set; }
    }
}
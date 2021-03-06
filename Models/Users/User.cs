using Music_Pirates.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Music_Pirates.Models
{
	public class User
	{
		//string to connect to the USERS table
		public User() {}
		public User
		(
			string ImgURL
		,	string Username
		,	string Password
		,	string Email
		,	DateTime Birthday
		)
        {
			this.ImgURL	  = ImgURL;
			this.Username = Username;
			this.Password = Password;
			this.Email	  = Email;
			this.Birthday = Birthday;
		}

		public Guid ID				{ get; set; }			//will be set when made in the SQL database
		public bool isActive		{ get; set; } = true;	//set will be handled by a SQL storedprocedure
		public string ImgURL		{ get; set; }			//may get changed to be set via SQL?
		public string Username		{ get; set; }
		public string Password		{ get; set; }			//Will likely need to setup some security stuffs later
		public string Email			{ get; set; }
		public DateTime Birthday	{ get; set; }

		protected List<User> Following = new List<User>();
		protected List<User> Followers = new List<User>();
		protected List<Playlist> Playlists = new List<Playlist>();
		protected List<Song> Liked = new List<Song>();
		protected List<Song> Disliked = new List<Song>();
	}
}
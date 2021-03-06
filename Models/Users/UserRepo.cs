using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Music_Pirates.Models.Users
{
	public sealed class UserRepo
	{
		#region Singleton Logic
			private UserRepo() { }
			public static UserRepo Instance { get { return Nested.instance; } }
			private class Nested
			{
				static Nested() { } //explicit static constructor to tell C# compiler not to make type as beforefieldinit
				internal static readonly UserRepo instance = new UserRepo();
			}
		#endregion Singleton Logic

			public static readonly string _connString = ConfigurationManager.ConnectionStrings["MusicPiratesDB"].ConnectionString;

		//static updators
		#region UserEditors

		public IEnumerable<User> GetUsers() 
		{
			//stored proc for SELECT * FROM Tbl_User
			return null;
		}

		public bool UpdateUser(User v)
		{
			return Instance.DeleteUser(v.ID) && Instance.AddUser(v);
		}

		public User GetUser(Guid id)
		{
			try
			{
				using (var con = new SqlConnection(_connString))
				{
					// Set-up command
					var cmd = new SqlCommand("ReadUser", con);
					cmd.CommandType = CommandType.StoredProcedure;
					// Define StoredProc parameters
					cmd.Parameters.AddWithValue("@guidStr", id.ToString());
					// Open DB Connection
					con.Open();
					// Execute command
					var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow);
					// Read the data
					while (rdr.Read())
					{
                        // Create your Student object
                        var stu = new User
                        {
                            ID = Guid.Parse(rdr["Id"].ToString()),
                            isActive = (int.Parse(rdr["Id"].ToString()) == 1),
                            ImgURL = rdr["ImageString"].ToString(),
                            Username = rdr["Id"].ToString(),
                            Password = rdr["Id"].ToString(),
                            Email = rdr["Id"].ToString(),
                            Birthday = Convert.ToDateTime(rdr["BirthDay"])
                        };
						// Add your object to your list
						return stu;
					}
				}
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("\n1 - \n" + e.StackTrace);
				System.Diagnostics.Debug.WriteLine("\n2 - \n\t" + e.Message);
				System.Diagnostics.Debug.WriteLine("\n3 - \n\t" + e.Source);
				System.Diagnostics.Debug.WriteLine("\n4 - \n" + e.InnerException);
				return null;
			}
			return null;
		}

		public bool AddUser(User v)
		{
			try
			{
				using (var con = new SqlConnection(_connString))
				{
					// Set-up command
					var cmd = new SqlCommand("CreateUser", con);
					cmd.CommandType = CommandType.StoredProcedure;
					// Define StoredProc parameters
					cmd.Parameters.AddWithValue("@ImageStr", v.ImgURL);
					cmd.Parameters.AddWithValue("@Username", v.Username);
					cmd.Parameters.AddWithValue("@Password", v.Password);
					cmd.Parameters.AddWithValue("@Email	",   v.Email);
					cmd.Parameters.AddWithValue("@BirthDay", v.Birthday);
					// Open DB Connection
					con.Open();
					// Execute command
					int i = cmd.ExecuteNonQuery();

					con.Close();
					if (i >= 1)
					{ return true; }
					return false;
				}
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("\n1 - \n" + e.StackTrace);
				System.Diagnostics.Debug.WriteLine("\n2 - \n\t" + e.Message);
				System.Diagnostics.Debug.WriteLine("\n3 - \n\t" + e.Source);
				System.Diagnostics.Debug.WriteLine("\n4 - \n" + e.InnerException);
				return false;
			}
		}

		public bool DeleteUser(Guid id)
		{
			using (var con = new SqlConnection(_connString))
			{
				//cmd setup
				var cmd = new SqlCommand("DeleteUser", con);       //Select command using connection string
				cmd.CommandType = CommandType.StoredProcedure;          //define comand type to be a stored procedure
				cmd.Parameters.AddWithValue("@guidStr", id.ToString()); //pass the Guid to the @guidStr SQL paramater
				//cmd execution
				con.Open();                                             //Open the connection to the database
				return cmd.ExecuteNonQuery() >= 1;                      //execute the command
			}
		}

		#endregion UserEditors

		public IEnumerable<User> SearchForUsers
		(string name)
		{
			var filteredList = new List<User>();
			// Create a connection to the DB
			using (var con = new SqlConnection(_connString))
			{
				// Set-up your SQL command
				var cmd = new SqlCommand("FilterUser", con);
				cmd.CommandType = CommandType.StoredProcedure;
				// Add paramaters
				cmd.Parameters.AddWithValue("@Title", name);
				// Open your connection
				con.Open();
				// Create your SQL Data Reader to execute your command and get your data
				SqlDataReader rdr = cmd.ExecuteReader();
				// Loop through all the items your reader can read
				while (rdr.Read())
				{
					// Create your Student object
					var stu = new User
					(
						// Get all the values from your reader loaded into your object
						rdr["ImageString"].ToString()
					,	rdr["Username"].ToString()
					,	rdr["Password"].ToString()
					,	rdr["Email"].ToString()
					,	DateTime.Parse(rdr["BirthDay"].ToString())
					);
					stu.ID = Guid.Parse(rdr["ID"].ToString());
					stu.isActive = int.Parse(rdr["IsActive"].ToString()) == 1;

					// Add your object to your list
					filteredList.Add(stu);
				}
			}
			return filteredList;
		}
	}
}
using System;
using Parse;
using System.Linq;
using OxxoTime.Model;
using OxxoTime.Droid;

namespace OxxoTime.Android.Service
{
	public class UserManager : IUserManager
	{
		public UserManager ()
		{
		}

		public bool ExistUser (string email)
		{
			var query = ParseObject.GetQuery("User").Where (user => user.Get<string> ("email") == email);
			var resultTask = query.FirstAsync ();
			var result = resultTask.Result;
			Console.WriteLine (result);
			return result != null;
		}

		public OxxoTime.Model.User GetUser (string email)
		{
			throw new NotImplementedException ();
		}

		public void UpdateUser (OxxoTime.Model.User user)
		{
			throw new NotImplementedException ();
		}
		public void CreateUser (OxxoTime.Model.User user)
		{
			var obj = user.AsParseObject();
			obj.SaveAsync ();
		}
	}
}


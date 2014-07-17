using System;
using Parse;
using System.Linq;
using OxxoTime.Model;
using OxxoTime.Droid;
using System.Threading.Tasks;

namespace OxxoTime.Android.Service
{
	public class UserManager : IUserManager
	{
		public UserManager ()
		{
		}

		public async Task<bool> ExistUser (string email)
		{
			try{
				var query = ParseObject.GetQuery("User").Where (user => user.Get<string> ("email") == email);
				var result = await query.FirstAsync ();
				Console.WriteLine (result);
				return result != null;
			}catch(Exception){
				return false;
			}
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


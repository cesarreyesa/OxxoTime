using System;
using OxxoTime.Model;
using System.Threading.Tasks;

namespace OxxoTime.Android
{
	public interface IUserManager
	{
		Task<bool> ExistUser (string email);
		User GetUser (string email);
		void UpdateUser(User user);
		void CreateUser(User user);
	}
}


using System;
using OxxoTime.Model;

namespace OxxoTime.Android
{
	public interface IUserManager
	{
		bool ExistUser (string email);
		User GetUser (string email);
		void UpdateUser(User user);
		void CreateUser(User user);
	}
}


using System;
using OxxoTime.Model;

namespace OxxoTime.Service
{
	public static class AuthenticationService
	{
		public static User CurrentUser { get; private set;}

		public static void SetCurrentUser(User user)
		{
			CurrentUser = user;
		}

		public static bool IsLoggedIn()
		{
			if (CurrentUser.IsEmptyOrNull () || CurrentUser.Email.IsEmptyOrNull ()) 
			{
				return false;
			} 
			else 
			{
				return true;
			}
		}
	}
}


using System;
using Parse;

namespace OxxoTime.Tests
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ParseClient.Initialize ("q7qlJD20kEtint79e6xe1bsgAj7mYv4MEmA1swTb", "adGks0GRUouK6Nzyt7vatV6NoerZK3F1lu9bbfpX");
			var userEmail = "cesarreyesa@gmail.com";
			Console.WriteLine(userEmail);

			var exists = ExistUser(userEmail);
			if (!exists) {
				Console.WriteLine ("el sssusuario no existe en parse");
				Console.WriteLine ("creando cuenta");
				//userManager.CreateUser (new User{ Name = userEmail, Email = userEmail });
				Console.WriteLine ("cuenta creada");
			} else {
				Console.WriteLine ("el usuario existe en parse");
			}

			Console.WriteLine ("Hello World!");
		}

		public static bool ExistUser (string email)
		{
			try{
				var query = ParseObject.GetQuery("User").Where (user => user.Get<string> ("email") == email);
				var resultTask = query.FirstAsync ();
				var result = resultTask.Result;
				Console.WriteLine (result);
				return result != null;
			}catch(Exception){
				return false;
			}
		}
			
//		public void CreateUser ( user)
//		{
//			var obj = user.AsParseObject();
//			obj.SaveAsync ();
//		}

	}

}

using System;
using OxxoTime.Model;
using Parse;
using Android.Content;
using OxxoTime.Service;

namespace OxxoTime.Droid
{
	public static class Extensions
	{
		public static string GetString (this Context context, int resourceId)
		{
			return context.Resources.GetString (resourceId);
		}

		public static void SaveAsNew(this User user)
		{
			var parseObject = user.AsParseObject();
			parseObject.SaveAsync ();
			user.UserId = parseObject.ObjectId;
		}

		public static ParseObject AsParseObject(this User user)
		{
			var parseObject = new ParseObject ("User");
			if (user.UserId.IsNotEmptyOrNull ()) 			
				parseObject ["ObjectId"] = user.UserId;
			parseObject ["Email"] = user.Email;
			parseObject ["Name"] = user.Name;
			return parseObject;
		}


	}
}


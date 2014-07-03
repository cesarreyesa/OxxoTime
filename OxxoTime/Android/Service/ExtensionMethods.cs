using System;
using System.Collections;

namespace OxxoTime.Service
{
	public static class ExtensionMethods
	{
		public static bool IsEmptyOrNull(this Object obj)
		{
			if (obj == null) 
				return true;
			if (obj is string)
			{
				if (string.IsNullOrEmpty((string)obj)) return true;
			}
			if (obj is IEnumerable)
			{
				return !((IEnumerable) obj).Any();
			}
			return false;
		}

		public static bool IsNotEmptyOrNull(this Object obj)
		{
			return !(obj.IsEmptyOrNull ());
		}

		public static bool Any(this IEnumerable source)
		{
			var enumerator = source.GetEnumerator();

			return enumerator.MoveNext();
		}
	}
}


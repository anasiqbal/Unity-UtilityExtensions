
using System;

namespace UtilityExtensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Capitalize first character of the given string
		/// </summary>
		/// <param name="_value"></param>
		/// <returns></returns>
		public static string Capitalize(this string _value)
		{
			if (string.IsNullOrEmpty (_value))
				return string.Empty;

			return char.ToUpper (_value [0]) + _value.Substring (1).ToLower ();
		}

		/// <summary>
		/// Convert string to an enum
		/// </summary>
		public static T ToEnum<T> (this string value)
		{
			return (T) Enum.Parse (typeof (T), value, true);
		}

	}
}
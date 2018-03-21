
namespace UtilityExtensions
{
	public static class StringExtensions
	{
		public static string Capitalize(this string _value)
		{
			if (string.IsNullOrEmpty (_value))
				return string.Empty;

			return char.ToUpper (_value [0]) + _value.Substring (1).ToLower ();
		}
	}
}
using System.Collections.Generic;

namespace UtilityExtensions
{
	public static class ListExtensions
	{
		static readonly System.Random rng = new System.Random ();

		/// <summary>
		/// Uses Fisher-Yates shuffle algorithm to shuffle the list. Takes in the list as reference.<para />
		/// If you donot wish to shuffle your original list, please make a copy and then call this method on that list
		/// </summary>
		public static void Shuffle<T>(this IList<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next (n + 1);
				T value = list [k];
				list [k] = list [n];
				list [n] = value;
			}
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace UtilityExtensions
{
	public static class NumericExtensions
	{
		/// <summary>
		/// Splits a number into equal number of parts. if number cannot be divided into equal parts the program will make sure that the sum of results is equal to the actual number<para />
		/// e.g. if 10 is divided in 5 parts the resulting list will contain 5 values all equal to 2.
		/// </summary>
		/// <param name="_partsCount"></param>
		public static IEnumerable<int> SplitIntoParts(this int value, int _partsCount)
		{
			if (_partsCount <= 0)
				return null;

			var result = new int [_partsCount];

			int runningTotal = 0;
			for (int i = 0; i < _partsCount; i++)
			{
				var remainder = value - runningTotal;
				var share = remainder > 0 ? remainder / (_partsCount - i) : 0;
				result [i] = share;
				runningTotal += share;
			}

			if (runningTotal < value)
				result [_partsCount - 1] += value - runningTotal;

			return result;
		}

		public static IEnumerable<float> SplitIntoParts(this float value, int _partsCount)
		{
			if (_partsCount <= 0)
				return null;
			var result = new float [_partsCount];

			float runningTotal = 0;
			for (int i = 0; i < _partsCount; i++)
			{
				var remainder = value - runningTotal;
				var share = remainder > 0 ? Mathf.Max (Mathf.Round (remainder / ((float) (_partsCount - i))), .01f) : 0;
				result [i] = share;
				runningTotal += share;
			}

			if (runningTotal < value)
				result [_partsCount - 1] += value - runningTotal;

			return result;
		}
	}
}
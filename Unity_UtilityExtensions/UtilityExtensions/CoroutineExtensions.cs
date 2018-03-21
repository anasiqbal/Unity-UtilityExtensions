using System.Collections;
using UnityEngine;

namespace UtilityExtensions
{
	public static class CoroutineExtensions
	{
		public static IEnumerator WaitForRealTime(float delay)
		{
			float pauseEndTime = Time.realtimeSinceStartup + delay;
			while (true)
			{
				while (Time.realtimeSinceStartup < pauseEndTime)
				{
					yield return null;
				}
				break;
			}
		}
	}
}
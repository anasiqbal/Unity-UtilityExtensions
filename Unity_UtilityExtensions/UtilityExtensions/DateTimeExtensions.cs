using System;

namespace UtilityExtensions
{
	public static class DateTimeExtensions
	{
		/// <summary>
		/// Check if the date is between two dates.
		/// </summary>
		public static bool Between (this DateTime date, DateTime startDate, DateTime endDate)
		{
			return date.Ticks >= startDate.Ticks && date.Ticks <= endDate.Ticks;
		}
		
		/// <summary>
		/// Calculate age in years.
		/// </summary>
		public static int CalculateAge (this DateTime date)
		{
			var age = DateTime.Now.Year - date.Year;
			if (DateTime.Now.DayOfYear < date.DayOfYear)
				age--;

			return age;
		}

		/// <summary>
		/// Returns human readable format for time past since dateTime.
		/// </summary>
		public static string ToReadableTimePast(this DateTime dateTime)
		{
			var timespan = new TimeSpan (DateTime.UtcNow.Ticks - dateTime.Ticks);
			double delta = timespan.TotalSeconds;
			if (delta < 60)
				return timespan.Seconds == 1 ? "one second ago" : timespan.Seconds + " seconds ago";

			if (delta < 120)
				return "a minute ago";

			if (delta < 3600) // 60 mins
				return timespan.Minutes + " minutes ago";

			if (delta < 7200) // 2 hours
				return "more than an hour ago";

			if (delta < 86400) // 24  hours
			{
				return timespan.Hours + " hours ago";
			}
			if (delta < 172800) // 2 days
			{
				return "yesterday";
			}
			if (delta < 2592000) // 1 Month
			{
				return timespan.Days + " days ago";
			}
			if (delta < 31104000) // Year
			{
				int months = Convert.ToInt32 (Math.Floor ((double) timespan.Days / 30));
				return months <= 1 ? "one month ago" : months + " months ago";
			}

			var years = Convert.ToInt32 (Math.Floor ((double) timespan.Days / 365));
			return years <= 1 ? "one year ago" : years + " years ago";
		}

		/// <summary>
		/// Checks if given date is on a weekend (if it is either saturday or sunday). Can also be used to check for working days
		/// </summary>
		public static bool IsWeekend(this DateTime dateTime)
		{
			return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
		}

		/// <summary>
		/// Determine date for next day of week. e.g. determine date for upcoming tuesday
		/// </summary>
		public static DateTime NextDay(this DayOfWeek dayOfWeek)
		{
			int offsetDays = dayOfWeek - DateTime.Now.DayOfWeek;
			if (offsetDays <= 0)
				offsetDays += 7;

			return DateTime.Now.AddDays (offsetDays);
		}
	}
}
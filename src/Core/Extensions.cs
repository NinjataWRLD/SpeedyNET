using System.Globalization;

namespace SpeedyNET.Core;

public static class Extensions
{
	public static DateOnly ParseDate(this string date)
		 => DateOnly.Parse(date, CultureInfo.InvariantCulture);

	public static DateTimeOffset ParseDateTime(this string dateTime)
		=> DateTimeOffset.Parse(dateTime, CultureInfo.InvariantCulture);
}

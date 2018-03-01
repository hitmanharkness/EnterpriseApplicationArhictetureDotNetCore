using System;
using System.Linq;

namespace BI.Enterprise.Common.DateHelper
{
	public class Helper
	{
		public static DateTime GetLocalDateFromUtc(DateTime utcDate, TaTimeZone taTimeZone)
		{
			var t = typeof(TaTimeZone);
			var f = t.GetField(taTimeZone.ToString());
			var attribs = f.GetCustomAttributes(true);
			var a = attribs[0] as TaTimeZoneIdAttribute;
			return a == null ? utcDate : GetLocalDateFromUtc(utcDate, a.TimeZoneId);
		}

		public static DateTime GetLocalDateFromUtc(DateTime utcDate, int taTimeZoneId)
		{
			var values = Enum.GetValues(typeof(TaTimeZone));
			var goodValue = values.Cast<int>().Contains(taTimeZoneId);
			if (!goodValue) return utcDate;
			var taTimeZone = (TaTimeZone)taTimeZoneId;
			return GetLocalDateFromUtc(utcDate, taTimeZone);
		}

		public static DateTime GetLocalDateFromUtc(DateTime utcDate, string timeZoneId)
		{
			var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
			return TimeZoneInfo.ConvertTimeFromUtc(utcDate, tzi);
		}

		public static DateTime GetUtcDateFromLocal(DateTime localDate, int taTimeZoneId)
		{
			if (!IsGoodTimeZone(taTimeZoneId)) return localDate;
			var taTimeZone = (TaTimeZone)taTimeZoneId;

			var timeZoneId = GetTimeZoneName(taTimeZone);
			if (timeZoneId == null) return localDate;

			var tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
			return TimeZoneInfo.ConvertTimeToUtc(localDate, tzi);
		}

		private static bool IsGoodTimeZone(int taTimeZoneId)
		{
			var values = Enum.GetValues(typeof(TaTimeZone));
			var goodValue = values.Cast<int>().Contains(taTimeZoneId);
			return goodValue;
		}

		private static string GetTimeZoneName(TaTimeZone taTimeZone)
		{
			var t = typeof(TaTimeZone);
			var f = t.GetField(taTimeZone.ToString());
			var attribs = f.GetCustomAttributes(true);
			var a = attribs[0] as TaTimeZoneIdAttribute;
			return a?.TimeZoneId;
		}
	}

	public enum TaTimeZone
	{
		[TaTimeZoneId("Hawaiian Standard Time")]
		Alaska = 6,
		[TaTimeZoneId("Atlantic Standard Time")]
		Atlantic = 10,
		[TaTimeZoneId("Atlantic Standard Time")]
		AtlanticPuertoRico = 9,
		[TaTimeZoneId("Central Standard Time")]
		Central = 2,
		[TaTimeZoneId("Central Standard Time")]
		CentralNoDst = 14,
		[TaTimeZoneId("Eastern Standard Time")]
		Eastern = 1,
		[TaTimeZoneId("US Eastern Standard Time")]
		EasternIndiana = 8,
		[TaTimeZoneId("UTC")]
		Gmt = 15,
		[TaTimeZoneId("West Pacific Standard Time")]
		Guam = 13,
		[TaTimeZoneId("Hawaiian Standard Time")]
		Hawaii = 7,
		[TaTimeZoneId("Mountain Standard Time")]
		Mountain = 3,
		[TaTimeZoneId("US Mountain Standard Time")]
		MountainArizona = 5,
		[TaTimeZoneId("Pacific Standard Time")]
		Pacific = 4
	}

	public class TaTimeZoneIdAttribute : Attribute
	{
		public TaTimeZoneIdAttribute()
		{ }

		public TaTimeZoneIdAttribute(string timeZoneId)
		{
			this.TimeZoneId = timeZoneId;
		}

		public string TimeZoneId { get; set; }
	}
}
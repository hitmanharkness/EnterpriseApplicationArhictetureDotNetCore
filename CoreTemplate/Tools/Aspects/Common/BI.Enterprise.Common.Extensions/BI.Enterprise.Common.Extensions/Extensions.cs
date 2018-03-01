using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BI.Enterprise.Common.Extensions
{
	public static class Extensions
	{
		public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
		{
			foreach (var item in enumeration)
				action(item);
		}

		public static string GetDescription(this Enum value)
		{
			var fi = value.GetType().GetField(value.ToString());

			if (fi == null) return null;

			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

			return attributes.Length == 0 ? null : attributes[0].Description;
		}

		#region String Methods

		public static bool IsNullOrSpace(this string text)
		{
			return string.IsNullOrWhiteSpace(text);
		}

		public static string TrimOrNull(this string text)
		{
			return text.IsNullOrSpace() ? null : text.Trim();
		}

		#endregion

		#region Boolean Methods

		public static bool ToBool(this bool? source)
		{
			return source ?? false;
		}

		public static bool ToBool(this object source, bool? defaultValue = null)
		{
			if (source != null)
				return source.ToString().ToBool(defaultValue);

			return defaultValue ?? false;
		}

		public static bool ToBool(this string source, bool? defaultValue = null)
		{
			bool ret;
			if (bool.TryParse(source, out ret))
				return ret;
			return defaultValue ?? false;
		}

		#endregion

		#region Integer Methods

		public static int ToInt(this object src, int? @default = null)
		{
			return src?.ToString().ToInt() ?? @default ?? int.MinValue;
		}

		public static int ToInt(this string src, int? @default = null)
		{
			int check;
			if (int.TryParse(src, out check))
				return check;
			return @default ?? int.MinValue;
		}

		#endregion
	}
}
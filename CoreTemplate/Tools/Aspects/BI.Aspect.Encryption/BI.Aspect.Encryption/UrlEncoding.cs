using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BI.Aspect.Encryption
{
	/// <summary>
	/// This class encodes and decodes encrypted datum for usage in URLs.
	/// We cannot use the standard urlEncode due to the usage of the %2f which will give you a 404 in IIS.
	/// </summary>
	public static class UrlEncoding
	{
		/// <summary>
		/// Decodes a previously encoded URL to its original value.
		/// </summary>
		/// <param name="url">The encoded URL to decode.</param>
		/// <returns>The decoded URL value.</returns>
		public static string UrlDecode(string url)
		{
			var toBeEncoded = new Dictionary<string, string> { { "P25", "P" }, { "P32", "%" }, { "P21", "!" }, { "P23", "#" }, { "P20", " " },
				{ "P24", "$" }, { "P26", "&" }, { "P27", "'" }, { "P28", "(" }, { "P29", ")" }, { "P2A", "*" }, { "P31", "+" }, { "P2C", "," },
				{ "P30", "/" }, { "P3A", ":" }, { "P3B", ";" }, { "P3D", "=" }, { "P3F", "?" }, { "P40", "@" }, { "P5B", "[" }, { "P5D", "]" } };

			var replaceRegex = new Regex(@"(P25|P32|P21|P23|P20|P24|P26|P27|P28|P29|P2A|P31|P2C|P30|P3A|P3B|P3D|P3F|P40|P5B|P5D)");
			MatchEvaluator matchEval = match => toBeEncoded[match.Value];
			var encoded = replaceRegex.Replace(url, matchEval);
			return encoded;
		}

		/// <summary>
		/// Replaces the characters that are not URL safe for characters that can be safely transmitted as part of the URL address
		/// </summary>
		/// <param name="url">URL with potential unsafe characters.</param>
		/// <returns>The provided URL with safe-only characters.</returns>
		public static string UrlEncode(string url)
		{
			var toBeEncoded = new Dictionary<string, string> { { "P", "P25" }, { "%", "P32" }, { "!", "P21" }, { "#", "P23" }, { " ", "P20" },
				{ "$", "P24" }, { "&", "P26" }, { "'", "P27" }, { "(", "P28" }, { ")", "P29" }, { "*", "P2A" }, { "+", "P31" }, { ",", "P2C" },
				{ "/", "P30" }, { ":", "P3A" }, { ";", "P3B" }, { "=", "P3D" }, { "?", "P3F" }, { "@", "P40" }, { "[", "P5B" }, { "]", "P5D" } };
			var replaceRegex = new Regex(@"[P%!# $&'()*+,/:;=?@\[\]]");
			MatchEvaluator matchEval = match => toBeEncoded[match.Value];
			var encoded = replaceRegex.Replace(url, matchEval);
			return encoded;
		}
	}
}
using Serilog.Core;
using Serilog.Events;
using System;
using System.Web;

namespace BI.Aspect.Logging.Enricher
{
	/// <summary>
	/// Enrich log events with a HttpRequestId GUID.
	/// </summary>
	public class HttpRequestIdEnricher : ILogEventEnricher
	{
		/// <summary>
		/// The property name added to enriched log events.
		/// </summary>
		public const string HttpRequestIdPropertyName = "HttpRequestId";

		private static readonly string RequestIdItemName = typeof(HttpRequestIdEnricher).Name + "+RequestId";

		/// <summary>
		/// Enrich the log event with an id assigned to the currently-executing HTTP request, if any.
		/// </summary>
		/// <param name="logEvent">The log event to enrich.</param>
		/// <param name="propertyFactory">Factory for creating new properties to add to the event.</param>
		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

			if (!TryGetCurrentHttpRequestId(out var requestId))
				return;

			var requestIdProperty = new LogEventProperty(HttpRequestIdPropertyName, new ScalarValue(requestId));
			logEvent.AddPropertyIfAbsent(requestIdProperty);
		}

		/// <summary>
		/// Retrieve the id assigned to the currently-executing HTTP request, if any.
		/// </summary>
		/// <param name="requestId">The request id.</param>
		/// <returns><c>true</c> if there is a request in progress; <c>false</c> otherwise.</returns>
		public static bool TryGetCurrentHttpRequestId(out Guid requestId)
		{
			if (HttpContext.Current == null)
			{
				requestId = default(Guid);
				return false;
			}

			var requestIdItem = HttpContext.Current.Items[RequestIdItemName];
			if (requestIdItem == null)
				HttpContext.Current.Items[RequestIdItemName] = requestId = Guid.NewGuid();
			else
				requestId = (Guid)requestIdItem;

			return true;
		}
	}
}
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;


// TODO Find and test this implementatino in webapi2 examples.
// TODO look up DelegatingHandler 
// https://msdn.microsoft.com/en-us/library/system.net.http.delegatinghandler(v=vs.118).aspx

namespace BI.WebApi.Base.MessageHandler
{
	public class LanguageAwareMessageHandler : DelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var languages = new List<StringWithQualityHeaderValue>();
			var langHeaders = request.Headers.AcceptLanguage;
			if (langHeaders != null)
				languages.AddRange(langHeaders);

			// Attempt to use the requested languages in quality order to initialize culture.
			// Ensure proper default quality (i.e. default is 1, the highest).
			CultureInfo culture = null;
			languages = languages.OrderByDescending(l => l.Quality ?? 1.0).ToList();
			foreach (var lang in languages)
			{
				try
				{
					culture = CultureInfo.GetCultureInfo(lang.Value);
					break;
				}
				catch (CultureNotFoundException)
				{
					// Ignore, client is asking for an unsupported language. Keep trying.
				}
			}

			// If one of the requested languages is supported, set the thread culture and Content-Language header.
			if (culture != null)
			{
				Thread.CurrentThread.CurrentCulture = culture;
				Thread.CurrentThread.CurrentUICulture = culture;
			}

			// Add Content-Language header if appropriate.
			var response = await base.SendAsync(request, cancellationToken);
			if (response.Content == null)
				return response;

			var responseCulture = Thread.CurrentThread.CurrentCulture;
			var responseHeaders = response.Content.Headers;
			responseHeaders.Add("Content-Language", responseCulture.Name);

			return response;
		}
	}
}
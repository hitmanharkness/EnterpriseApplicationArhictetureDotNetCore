using BI.Aspect.Language;
using BI.WebApi.Base.Controller;
using System.Net;
using System.Net.Http;

namespace BI.WebApi.Base.Extensions
{
	public static class ExtensionHelpers
	{
		public static HttpResponseMessage CreateResponseMessage(this HttpRequestMessage request, HttpStatusCode statusCode = HttpStatusCode.OK,
			int? code = null, string msg = null)
		{
			if (code.HasValue && code > 0)
				msg = LanguageAspect.Instance.GetStringResource(code.Value) ?? msg;

			return string.IsNullOrWhiteSpace(msg)
				? request.CreateResponse(statusCode)
				: request.CreateResponse(statusCode, new ErrorMessage { Code = code, Message = msg });
		}
	}
}
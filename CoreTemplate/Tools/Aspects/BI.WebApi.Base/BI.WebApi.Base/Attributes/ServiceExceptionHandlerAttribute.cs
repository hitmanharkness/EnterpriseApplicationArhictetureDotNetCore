using BI.Enterprise.Common.Exceptions;
using BI.Enterprise.Common.Exceptions.Interfaces;
using BI.WebApi.Base.Extensions;
using Serilog;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Filters;

namespace BI.WebApi.Base.Attributes
{
	public class ServiceExceptionHandlerAttribute : ExceptionFilterAttribute
	{
		public static string GenericErrorMessage =
			"There was an internal error processing your request. Please contact the service administrator.";

		internal static List<int> NotFoundCodes = new List<int>();

		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			var ex = actionExecutedContext.Exception;
			var code = 999;
			string message;
			var statusCode = HttpStatusCode.InternalServerError;
			if (ex is ICodeMessageException)
			{
				statusCode = HttpStatusCode.BadRequest;
				if (ex is ServiceForbiddenException)
					statusCode = HttpStatusCode.Forbidden;
				var iEx = ex as ICodeMessageException;
				code = iEx.Code;
				message = iEx.Message;
				if (NotFoundCodes.Contains(code))
					statusCode = HttpStatusCode.NotFound;
			}
			else
			{
				message = GenericErrorMessage;
				var errMessage = ex.Message;
				var stackTrace = ex.StackTrace;
				if (ex is HttpResponseException)
				{
					var httpEx = ex as HttpResponseException;
					errMessage += $" Response: {httpEx.Response.ReasonPhrase}";
					var objectContent = httpEx.Response.Content as System.Net.Http.ObjectContent<HttpError>;
					if (objectContent?.Value is Dictionary<string, object>)
					{
						var val = (Dictionary<string, object>)objectContent.Value;
						errMessage += $" Response Message: {val["Message"]}";
					}
				}
				while (ex.InnerException != null)
				{
					ex = ex.InnerException;
					errMessage += $" Inner Exception: {ex.Message}";
				}
				Log.Error("There was an error processing the request: {ErrorMessage}", errMessage);
				Log.Error("The stack trace of the error is: {StackTrace}", stackTrace);
			}

			throw new HttpResponseException(actionExecutedContext.Request.CreateResponseMessage(statusCode, code, message));
		}
	}
}
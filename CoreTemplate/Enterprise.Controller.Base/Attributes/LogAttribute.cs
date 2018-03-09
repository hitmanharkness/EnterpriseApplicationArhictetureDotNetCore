//using Serilog;
//using System.Net.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace BI.WebApi.Base.Attributes
//{
//	//http://stackoverflow.com/questions/30387409/how-to-get-the-actiondescription-uniqueid-from-within-onresultexecuted

//	public class LogAttribute : ActionFilterAttribute
//	{
//		public HttpActionDescriptor ActionDescriptor { get; set; }

//		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
//		{
//			var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
//			var controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;

//			if (actionExecutedContext.ActionContext.Response?.Content != null)
//			{
//				var objectContent = (ObjectContent)actionExecutedContext.ActionContext.Response.Content;
//				Log.Information("Body returned - type: {@objectType}", objectContent.ObjectType);
//			}
//			if (actionExecutedContext.Exception != null)
//			{
//				var ex = actionExecutedContext.Exception;
//				var errorMessage = ex.Message;
//				var stackTrace = ex.StackTrace;
//				while (ex.InnerException != null)
//				{
//					ex = ex.InnerException;
//					errorMessage += $" Inner Exception: {ex.Message}";
//				}
//				Log.Error("[{controller:l}.{action:l}] threw an unhandled exception! Exception: {Exception:l}",
//					controllerName, actionName, errorMessage);
//				Log.Error("[{controller:l}.{action:l}] Exception StackTrace: {StackTrace:l}",
//					controllerName, actionName, stackTrace);
//			}
//			Log.Information("Exited [{controller:l}.{action:l}]", controllerName, actionName);
//		}

//		public override void OnActionExecuting(HttpActionContext actionContext)
//		{
//			var request = actionContext.Request;

//			// Setting the message request guid to correlate the entire message start to finish.
//			//Aspect.Logging.LoggingHandler.RequestId = request.GetCorrelationId();

//			var actionName = actionContext.ActionDescriptor.ActionName;
//			var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
//			Log.Information("Entered [{controller:l}.{action:l}]", controllerName, actionName);

//			Log.Information("{@method} {@uri}", request.Method, request.RequestUri);
//		}
//	}
//}
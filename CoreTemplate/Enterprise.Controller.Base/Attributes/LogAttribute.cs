using Serilog;
using System.Net.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace BI.WebApi.Base.Attributes
{
    // ref: https://www.c-sharpcorner.com/article/working-with-filters-in-asp-net-core-mvc/
    // ref: http://stackoverflow.com/questions/30387409/how-to-get-the-actiondescription-uniqueid-from-within-onresultexecuted

    // TODO LogAttribute, I'm not sure this is necessary.
    public class LogAttribute : ActionFilterAttribute
    {
        //public HttpActionDescriptor ActionDescriptor { get; set; }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller.ToString();

            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            var controllerName = controllerActionDescriptor.ControllerName;
            var actionName = controllerActionDescriptor?.ActionName;

            //WebApi2 var actionName = actionExecutedContext.ActionDescriptor.DisplayName;
            //WebApi2 var controllerName = actionExecutedContext.Controller. ControllerContext.ControllerDescriptor.ControllerName;

            // TODO: Logging the content?
            //if (context.ActionContext.Response?.Content != null)
            //{
            //    var objectContent = (ObjectContent)context.ActionContext.Response.Content;
            //    Log.Information("Body returned - type: {@objectType}", objectContent.ObjectType);
            //}

            if (context.Exception != null)
            {
                var ex = context.Exception;
                var errorMessage = ex.Message;
                var stackTrace = ex.StackTrace;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    errorMessage += $" Inner Exception: {ex.Message}";
                }
                Log.Error("[{controller:l}.{action:l}] threw an unhandled exception! Exception: {Exception:l}", controllerName, actionName, errorMessage);
                Log.Error("[{controller:l}.{action:l}] Exception StackTrace: {StackTrace:l}", controllerName, actionName, stackTrace);
            }
            // TODO: I'll have to check if this isn't already being logged.
            Log.Information("Exited [{controller:l}.{action:l}]", controllerName, actionName);
        }

        // I need to test this but I believe this comes native in .net core.
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            // Setting the message request guid to correlate the entire message start to finish.
            // TODO: getting correlation id?
            //Aspect.Logging.LoggingHandler.RequestId = request.GetCorrelationId();

            // TODO: I'm pretty sure this is already logged in .net core.
            //var actionName = actionContext.ActionDescriptor.ActionName;
            //var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            //Log.Information("Entered [{controller:l}.{action:l}]", controllerName, actionName);
            //Log.Information("{@method} {@uri}", request.Method, request.RequestUri);
        }
    }
}
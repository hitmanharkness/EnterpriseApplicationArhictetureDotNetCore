

// TODO: I don't why

//using System.Linq;
//using System.Net.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace BI.WebApi.Base.Attributes
//{
//    /// <summary>
//    /// Represents a filter for an API array/list parameter.
//    /// </summary>
//    public class IntListInputAttribute : ActionFilterAttribute
//    {
//        private readonly string _parameterName;

//        private readonly char _separator;

//        /// <summary>
//        /// Initializes a new instance of the ArrayInputAttribute class.
//        /// </summary>
//        /// <param name="parameterName"></param>
//        /// <param name="separator"></param>
//        public IntListInputAttribute(string parameterName, char separator = ',')
//        {
//            this._parameterName = parameterName;
//            this._separator = separator;
//        }

//        /// <summary>
//        /// Overrides the base ActionExecuting methods which allows to capture the string parameter and parse it into an
//        /// array/list of integers.
//        /// </summary>
//        /// <param name="actionContext">The current HttpActionContext context.</param>
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            if (actionContext.ActionArguments.ContainsKey(this._parameterName))
//            {
//                string parameters = string.Empty;
//                if (actionContext.ControllerContext.RouteData.Values.ContainsKey(this._parameterName))
//                    parameters = (string)actionContext.ControllerContext.RouteData.Values[this._parameterName];
//                else if (actionContext.ControllerContext.Request.RequestUri.ParseQueryString()[this._parameterName] != null)
//                    parameters = actionContext.ControllerContext.Request.RequestUri.ParseQueryString()[this._parameterName];

//                actionContext.ActionArguments[this._parameterName] = parameters.Split(this._separator).Select(int.Parse).ToList();
//            }
//        }
//    }
//}
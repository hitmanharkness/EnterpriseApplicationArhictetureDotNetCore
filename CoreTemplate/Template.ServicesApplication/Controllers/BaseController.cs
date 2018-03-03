
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using Template.Common.Facade;
using System.Web.Http;
using System.Net.Http;
using System.Text;
using Common.Controller.Base;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860


// THIS MIGHT NEED TO MOVE TO A LIBARY LIKE BI

namespace  Template.ServiceApp.Controllers
{
    public class BaseController : CommonControllerBase // Controller
    {
        private IActionManager _manager;
        private ILogger _logger;
        
        //public BaseController(IActionManager manager, ILogger logger)
        public BaseController(IActionManager manager, ILogger logger)
        {
            _manager = manager;
            _logger = logger;
        }
        public IActionManager ActionManager { get { return _manager; } }
        public ILogger Logger { get { return _logger; } }
        public HttpResponseException LogException(Exception ex)
        {
            string errorMessage = LoggerHelper.GetExceptionDetails(ex);
            _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, errorMessage);
            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent(errorMessage);
            message.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
            throw new HttpResponseException(message);
        }


    }
}

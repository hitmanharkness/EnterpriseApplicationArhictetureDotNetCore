using Template.BusinessLayer.Core;
using Template.ServiceApp.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.ServiceApp.Filters
{
    public class TransactionActionFilter : ActionFilterAttribute
    {
        IDbContextTransaction transaction;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ((ServiceBaseController)context.Controller).ActionManager.UnitOfWork.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                ((ServiceBaseController)context.Controller).ActionManager.UnitOfWork.RollbackTransaction();
            }
            else
            {
                ((ServiceBaseController)context.Controller).ActionManager.UnitOfWork.CommitTransaction();
            }
        }

    }
}

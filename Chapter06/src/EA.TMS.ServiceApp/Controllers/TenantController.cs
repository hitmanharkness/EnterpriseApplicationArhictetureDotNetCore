using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EA.TMS.Common.Entities;
using EA.TMS.BusinessLayer.Managers.TenantManagement;
using System.Net.Http;
using System.Net;
using EA.TMS.ServiceApp.Filters;
using EA.TMS.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using EA.TMS.Common.Facade;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EA.TMS.ServiceApp.Controllers
{
    [Authorize]
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class TenantController : BaseController
    {
         
        private ITenantManager _tenantManager;
        private ILogger _logger;

        public TenantController(ITenantManager manager, ILogger<TenantController> logger) : base(manager, logger)
        {
            _tenantManager = manager;
            _logger = logger;
        }

        // GET: api/values

        [TransactionActionFilter()]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items = _tenantManager.GetAll();
                return new OkObjectResult(items);

            }catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpPost]
        public IActionResult Post(Tenant tenant)
        {
            try
            {
                _tenantManager.Create(tenant);
                return new OkResult();

            }catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
        [TransactionActionFilter()]
        [HttpPut]
        public IActionResult Put(Tenant tenant)
        {
            try
            {
                _tenantManager.Update(tenant);
                return new OkResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpDelete]
        public IActionResult Delete(Tenant tenant)
        {
            try
            {
                _tenantManager.Delete(tenant);
                return new OkResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        public IActionResult Get(long tenantID)
        {
            try
            {
                var tenant = _tenantManager.GetTenant(tenantID);
                if (tenant != null)
                {
                    return new OkObjectResult(_tenantManager.GetTenant(tenantID));
                }
                else
                {
                    return NotFound();
                }
            }catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
    }
        
}

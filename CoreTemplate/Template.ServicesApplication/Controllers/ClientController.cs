using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.Common.Entities;
using Template.BusinessLayer.Managers.TenantManagement;
using System.Net.Http;
using System.Net;
using System.Security.Claims;
using BI.WebApi.Base.Attributes;
using Template.ServiceApp.Filters;
using Template.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using Template.Common.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Template.BusinessLayer.Managers.ServiceRequestManagement;
using Template.BusinessLayer.Managers.ClientInfoManager;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.ServiceApp.Controllers
{
    //[Authorize]

    //[ClaimRequirement("EntityType", "4")] // BI.WebApi.base
    [Log] // BI.WebApi.base

    [LoggingActionFilter] // This was native logging
    [Route("api/[controller]")]
    public class ClientController : ServiceBaseController
    {
         
        private IClientInfoManager _clientManager;
        private ILogger _logger;

        public ClientController(IClientInfoManager manager, ILogger<ClientController> logger) : base(manager, logger)
        {
            _clientManager = manager;
            _logger = logger;
        }

        // GET: api/values

        [TransactionActionFilter()]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items = _clientManager.GetAll();
                return new OkObjectResult(items);

            }catch(Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        [TransactionActionFilter()]
        [HttpPost]
        public IActionResult Post(Client client)
        {
            try
            {
                _clientManager.Create(client);
                return new OkResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }
        [TransactionActionFilter()]
        [HttpPut]
        public IActionResult Put(Client client)
        {
            try
            {
                _clientManager.Update(client);
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
        public IActionResult Delete(Client client)
        {
            try
            {
                _clientManager.Delete(client);
                return new OkResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }

        public IActionResult Get(long id)
        {
            try
            {
                var tenant = _clientManager.GetClient(id);
                if (tenant != null)
                {
                    return new OkObjectResult(_clientManager.GetClient(id));
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

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
using System.Text;
using BI.WebApi.Base.Attributes;
using Template.ServiceApp.Filters;
using Template.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using Template.Common.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Template.BusinessLayer.Managers.ServiceRequestManagement;
using Template.BusinessLayer.Managers.ClientInfoManager;
using Template.Common.BusinessObjects;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.ServiceApp.Controllers
{
 
    //[Authorize]

    //[ClaimRequirement("EntityType", "4")] // BI.WebApi.base
    [Log] // BI.WebApi.base
    [LoggingActionFilter] // My thing
    //[Route("api/[controller]")]
    public class ClientController : ServicesControllerBase
    {
        private IDistributedCache _distributedCache;
        private IClientInfoManager _clientManager;
        private ILogger _logger;

        public ClientController(IClientInfoManager manager, ILogger<ClientController> logger, IDistributedCache distributedCache) : base(manager, logger)
        {
            _clientManager = manager;
            _logger = logger;
            _distributedCache = distributedCache;
        }


        [Route("api/v1/clients/{id:int}/events/")]
        // Is this really what I want to do?
        [ResponseCache(Duration = 30, VaryByHeader = "User-Agent")] // https://app.pluralsight.com/player?course=aspdotnet-core-mvc-enterprise-application&author=gill-cleeren&name=81741cc0-66db-4b7a-a4fe-673f61981301&clip=8&mode=live
        [HttpGet]
        public IActionResult GetClientEvents(int id)
        {
            var clientId = id;

            var clientEvents = new List<ClientEvent>();
            try
            {
                var client = _clientManager.GetClient(clientId);
                if (client == null)
                    return NotFound();

                // I think this goes into the repository.
                //var cachedClientEvents = _distributedCache.Get("ClientEvents");
                //if (cachedClientEvents == null)
                //{
                    clientEvents = _clientManager.GetClientEvents(clientId).ToList();
                //    string serializedClientEvents = JsonConvert.SerializeObject(clientEvents);
                //    byte[] encodeClientEvents = Encoding.UTF8.GetBytes(serializedClientEvents);
                //    var cacheEntryOptions = new DistributedCacheEntryOptions()
                //        .SetAbsoluteExpiration(TimeSpan.FromSeconds(1000));

                //    _distributedCache.Set("ClientEvents", encodeClientEvents, cacheEntryOptions);
                //}
                //else
                //{
                //    byte[] encodedClientEvents = _distributedCache.Get("ClientEvents");
                //    string serializedClientEvents = Encoding.UTF8.GetString(encodedClientEvents);
                //    clientEvents =
                //        JsonConvert.DeserializeObject<List<ClientEvent>>(serializedClientEvents);
                //}

                return new OkObjectResult(clientEvents);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }



        /// CRUD /////////////////////////////////////////////////////////////////////////////// 

        // GET: api/values

        [TransactionActionFilter()]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var items = _clientManager.GetAll();
                return new OkObjectResult(items);

            }
            catch (Exception ex)
            {
                _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
                return new EmptyResult();
            }
        }


        // we can do the model viewstate it the filter
        // TODO https://www.jerriepelser.com/blog/validation-response-aspnet-core-webapi/

        [TransactionActionFilter()]
        [HttpPost]
        public IActionResult Post(Client client)
        {
            if (ModelState.IsValid)
            {
                // Do something with the product (not shown).
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
            else
            {
                // lets do this in the filter.
                return new BadRequestObjectResult(ModelState);
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

        //[Route("api/clients")]
        //[HttpGet]
        //public IActionResult Get(long id)
        //{
        //    try
        //    {
        //        var tenant = _clientManager.GetClient(id);
        //        if (tenant != null)
        //        {
        //            return new OkObjectResult(_clientManager.GetClient(id));
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }catch(Exception ex)
        //    {
        //        _logger.LogError(LoggingEvents.SERVICE_ERROR, ex, ex.Message);
        //        return new EmptyResult();
        //    }
        //}
    }
        
}

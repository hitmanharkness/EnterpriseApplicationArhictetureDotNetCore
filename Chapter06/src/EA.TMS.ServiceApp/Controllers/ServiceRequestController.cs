using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EA.TMS.ServiceApp.Filters;
using EA.TMS.Common.Entities;
using EA.TMS.BusinessLayer.Managers.ServiceRequestManagement;
using EA.TMS.Common.Facade;
using EA.TMS.Common.BusinessObjects;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EA.TMS.ServiceApp.Controllers
{
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class ServiceRequestController : BaseController
    {
         
        IServiceRequestManager _manager;
        ILogger<ServiceRequestController> _logger;

        public ServiceRequestController(IServiceRequestManager manager, ILogger<ServiceRequestController> logger) : base(manager, logger)
        {
            _manager = manager;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TenantServiceRequest> GetTenantsRequests()
        {
            return _manager.GetAllTenantServiceRequests();
        }

        // POST api/values
        [HttpPost]
        public void Post(ServiceRequest serviceRequest)
        {
            try
            {
                _manager.Create(serviceRequest);
            }
            catch (Exception ex)
            {
                throw LogException(ex);
            }
            
        }
    }
}

      
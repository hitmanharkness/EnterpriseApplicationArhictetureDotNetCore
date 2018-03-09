using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Template.ServiceApp.Filters;
using Template.Common.Entities;
using Template.BusinessLayer.Managers.ServiceRequestManagement;
using Template.Common.Facade;
using Template.Common.BusinessObjects;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.ServiceApp.Controllers
{
    [LoggingActionFilter]
    [Route("api/[controller]")]
    public class ServiceRequestController : ServiceBaseController
    {
         
        private IServiceRequestManager _manager;
        private ILogger<ServiceRequestController> _logger;

        public ServiceRequestController(IServiceRequestManager manager, ILogger<ServiceRequestController> logger) : base(manager, logger)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

      
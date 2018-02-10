using Template.BusinessLayer.Managers.ServiceRequestManagement;
using Template.BusinessLayer.Managers.TenantManagement;
using Template.DataAccess.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.BusinessLayer.Core
{
    public class BusinessManagerFactory  
    {
        IServiceRequestManager _serviceRequestManager;
        ITenantManager _tenantManager;
        public BusinessManagerFactory(IServiceRequestManager serviceRequestManager=null, ITenantManager tenantManager=null)
        {
            _serviceRequestManager = serviceRequestManager;
            _tenantManager = tenantManager;
        }

        public IServiceRequestManager GetServiceRequestManager()
        {
            return _serviceRequestManager;
        }

        public ITenantManager GetTenantManager()
        {
            return _tenantManager;
        }

    }

   

}

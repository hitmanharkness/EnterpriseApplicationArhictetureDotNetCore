using EA.TMS.BusinessLayer.Managers.ServiceRequestManagement;
using EA.TMS.BusinessLayer.Managers.TenantManagement;
using EA.TMS.DataAccess.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EA.TMS.BusinessLayer.Core
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

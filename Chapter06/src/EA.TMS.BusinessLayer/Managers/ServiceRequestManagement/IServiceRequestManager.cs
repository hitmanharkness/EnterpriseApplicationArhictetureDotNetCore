using EA.TMS.BusinessLayer.Core;
using EA.TMS.Common.BusinessObjects;
using EA.TMS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EA.TMS.BusinessLayer.Managers.ServiceRequestManagement
{
    public interface IServiceRequestManager : IActionManager
    {
        IEnumerable<TenantServiceRequest> GetAllTenantServiceRequests();
    }
}

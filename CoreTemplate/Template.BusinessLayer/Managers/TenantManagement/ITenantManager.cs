using Template.BusinessLayer.Core;
using Template.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.BusinessLayer.Managers.TenantManagement
{
    public interface ITenantManager : IActionManager
    {
        Tenant GetTenant(long tenantID);

    }
}

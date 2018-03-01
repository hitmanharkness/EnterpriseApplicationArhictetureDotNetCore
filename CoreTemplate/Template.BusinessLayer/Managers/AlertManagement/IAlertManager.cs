﻿using Template.BusinessLayer.Core;
using Template.Common.BusinessObjects;
using Template.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.BusinessLayer.Managers.ServiceRequestManagement
{
    public interface IAlertManager : IActionManager
    {
        IEnumerable<TenantServiceRequest> GetAllTenantServiceRequests();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Common.Entities;
using Template.DataAccess.Core;
using Template.BusinessLayer.Core;
using Microsoft.Extensions.Logging;
using Template.Common.BusinessObjects;
using Template.Common.Core;

namespace Template.BusinessLayer.Managers.ServiceRequestManagement
{
    public class ClientInfoManager : BusinessManager, IClientInfoManager
    {
        private IUnitOfWork _unitOfWork;
        
        public IRepository Repository { get; set; }
        public ILogger<ClientInfoManager> Logger { get; set; }
        public IUnitOfWork UnitOfWork { get => _unitOfWork; set => _unitOfWork = value; }



        public ClientInfoManager(IRepository repository, ILogger<ClientInfoManager> logger, IUnitOfWork unitOfWork) : base()
        {
            Repository = repository;
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        public void Create(BaseEntity entity)
        {
            ServiceRequest serviceRequest = (ServiceRequest)entity;
            Logger.LogInformation("Creating record for {0}", this.GetType());
            Repository.Create<ServiceRequest>(serviceRequest);
            Logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TenantServiceRequest> GetAllTenantServiceRequests()
        {

            var query = from tenants in Repository.All<Tenant>() join serviceReqs in Repository.All<ServiceRequest>()
                    on tenants.ID equals serviceReqs.TenantID
                    join status in Repository.All<Status>()
                    on serviceReqs.StatusID equals status.ID
                    select new TenantServiceRequest()
                    {
                        TenantID = tenants.ID,
                        Description = serviceReqs.Description,
                        Email = tenants.Email,
                        EmployeeComments = serviceReqs.EmployeeComments,
                        Phone = tenants.Phone,
                        Status = status.Description,
                        TenantName = tenants.Name
                    };
            return query.ToList<TenantServiceRequest>();
        }

        public void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}

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
    public class AlertManager : BusinessManager, IAlertManager
    {
        IRepository _repository;
        ILogger<AlertManager> _logger;
        IUnitOfWork _unitOfWork;
        
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public AlertManager(IRepository repository, ILogger<AlertManager> logger, IUnitOfWork unitOfWork) : base()
        {
            _repository = repository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void Create(BaseEntity entity)
        {
            ServiceRequest serviceRequest = (ServiceRequest)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());
            _repository.Create<ServiceRequest>(serviceRequest);
            _logger.LogInformation("Record saved for {0}", this.GetType());
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

            var query = from tenants in _repository.All<Tenant>() join serviceReqs in _repository.All<ServiceRequest>()
                    on tenants.ID equals serviceReqs.TenantID
                    join status in _repository.All<Status>()
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
            _unitOfWork.SaveChanges();
        }
    }
}

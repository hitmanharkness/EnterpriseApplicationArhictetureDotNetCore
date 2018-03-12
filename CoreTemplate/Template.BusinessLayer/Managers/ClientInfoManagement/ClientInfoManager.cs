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
using Template.BusinessLayer.Managers.ClientInfoManager;

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


        public virtual Client GetClient(long Id)
        {
            throw new NotImplementedException();
            //try
            //{
            //    _logger.LogInformation(LoggingEvents.GET_ITEM, "The tenant Id is " + tenantID);
            //    return _repository.All<Tenant>().Where(i => i.ID == tenantID).FirstOrDefault();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

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

        public IEnumerable<ClientAlert> GetAllClientAlerts()
        {
            throw new NotImplementedException();

            //var query = from clients in Repository.All<Client>()
            //            join clientAlerts in Repository.All<ClientAlert>()
            //            on clients.Id equals clientAlerts.clientId
            //            select new TenantServiceRequest()
            //            {
            //                ClientId = clients.Id,
            //                ClientName = clients.Name,
            //            };


            //return query.ToList<ClientAlert>();
        }

        public void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}

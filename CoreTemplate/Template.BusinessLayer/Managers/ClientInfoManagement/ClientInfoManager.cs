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

        private readonly IRepository _repository;
        private readonly IRepository _apiRepository;
        private readonly IRepositoryBase _mqRepository;

        public ILogger<ClientInfoManager> Logger { get; set; }
        public IUnitOfWork UnitOfWork { get => _unitOfWork; set => _unitOfWork = value; }



        public ClientInfoManager(IRepository efRepository,
                                 IRepository apiRepository,
                                 IRepositoryBase mqRepository,
                                 ILogger<ClientInfoManager> logger, 
                                 IUnitOfWork unitOfWork) : base()
        {
            _repository = efRepository;
            _apiRepository = apiRepository;
            _mqRepository = mqRepository;
            Logger = logger;
            UnitOfWork = unitOfWork;
        }


        public virtual Client GetClient(long Id)
        {
            try
            {
                return _repository.All<Client>().Where(c => c.client_id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Create(BaseEntity entity)
        {
            Client client = (Client)entity;
            Logger.LogInformation("Creating record for {0}", this.GetType());
            _repository.Create<Client>(client);
            Logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            var _testClientId = 425758; //TODO test filter.

            var query = from clients in _repository.All<Client>()
                // repository
                join alerts1 in _repository.All<Alert>() on clients.client_id equals alerts1.client_id
                //join alerts2 in _repository.All<Alert>() on clients.client_id equals alerts2.client_id

                // repository base simple crud from a webapi.
                join alerts3 in _apiRepository.All<Alert>() on clients.client_id equals alerts3.client_id
                // repository base simple crud from a message queue.
                join alerts4 in _mqRepository.GetAll<Alert>() on clients.client_id equals alerts4.client_id

                // where from a message queue.
                where clients.client_id == _mqRepository.GetById<Alert>(123).client_id

                select new ClientInfo()
                {
                    Id = clients.client_id,
                    FirstName = clients.first_name,
                    LastName = clients.last_name,
                    EventCode = alerts4.event_code,
                };

            return query.ToList<ClientInfo>();
        }

        public void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alert> GetAllClientAlerts()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}

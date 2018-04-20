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


// CQRS https://www.exceptionnotfound.net/real-world-cqrs-es-with-asp-net-and-redis-part-3-the-read-model/



namespace Template.BusinessLayer.Managers.ServiceRequestManagement
{
    public class ClientInfoManager : BusinessManager, IClientInfoManager
    {
        private IUnitOfWork _unitOfWork;

        private readonly IRepository _repository;
        private readonly IRepositoryBase _apiRepository;
       // private readonly IRepositoryBase _mqRepository;

        public ILogger<ClientInfoManager> Logger { get; set; }
        public IUnitOfWork UnitOfWork { get => _unitOfWork; set => _unitOfWork = value; }



        public ClientInfoManager(IRepository efRepository,
                                 IRepositoryBase apiRepository,
                                 //IRepositoryBase mqRepository,
                                 ILogger<ClientInfoManager> logger, 
                                 IUnitOfWork unitOfWork) : base()
        {
            _repository = efRepository;
            _apiRepository = apiRepository;
            //_mqRepository = mqRepository;
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


        // joining an Iqueryable with an Ienumerable?
        // https://blog.hompus.nl/2010/08/26/joining-an-iqueryable-with-an-ienumerable/




        public IEnumerable<BaseEntity> GetAll()
        {
            var _testClientId = 425758; //TODO test filter.

            var query = from clients in _repository.All<Client>()
                // EF Repository.
                join alerts in _repository.All<Alert>() on clients.client_id equals alerts.client_id

                // Repository from another database.
                //join alerts2 in _repository.All<Alert>() on clients.client_id equals alerts2.client_id

                // repository base simple crud from a webapi.
                join events in _apiRepository.GetAll<Event>() on clients.client_id equals events.client_id

                // repository base simple crud from a message queue.
                //join alerts4 in _mqRepository.GetAll<Alert>() on clients.client_id equals alerts4.client_id

                // where from a message queue.
                where clients.client_id == _testClientId //_apiRepository.GetById<Event>(123).client_id

                select new ClientInfo()
                {
                    Id = clients.client_id,
                    FirstName = clients.first_name,
                    LastName = clients.last_name
                };

            return query.ToList<ClientInfo>();
        }

        public void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }


        // NOTE: EF SQL I believe the easiest, fastest and cleanest solution is to use SQL Profiler.


        //exec sp_executesql N'SELECT [clients].[client_id] AS [Id], [clients].[first_name] AS [FirstName], [clients].[last_name] AS [LastName]
        //FROM[Client] AS[clients]
        //INNER JOIN[tblalerts] AS[alerts] ON[clients].[client_id] = [alerts].[client_id]
        //WHERE[clients].[client_id] = @___testClientId_1',N'@___testClientId_1 int',@___testClientId_1=425758

        public IEnumerable<ClientEvent> GetClientEvents(int clientId)
        {

            var query = from clients in _repository.All<Client>()
                // repository base simple crud from a webapi.
                join events in _apiRepository.GetAll<Event>() on clients.client_id equals events.client_id
                    // EF Repository.
                    // join alerts in _repository.All<Alert>() on clients.client_id equals alerts.client_id

                    // Repository from another database.
                    //join alerts2 in _repository.All<Alert>() on clients.client_id equals alerts2.client_id



                    // repository base simple crud from a message queue.
                    //join alerts4 in _mqRepository.GetAll<Alert>() on clients.client_id equals alerts4.client_id

                    // where from a message queue.
                where clients.client_id == clientId //_apiRepository.GetById<Event>(123).client_id

                select new ClientEvent()
                {
                    Id = clients.client_id,
                    FirstName = clients.first_name,
                    LastName = clients.last_name,
                    EventCode = events.event_code,
                };

            return query.ToList<ClientEvent>();
        }


        public void CreateClientCreate(Alert alert)
        {
            _repository.Create<Alert>(alert);
        }

        public IEnumerable<ClientEvent> GetClientAlerts(int clientId)
        {
            var query = from clients in _repository.All<Client>()
                // EF Repository.
                join alerts in _repository.All<Alert>() on clients.client_id equals alerts.client_id

                // repository base simple crud from a webapi.
                join events in _apiRepository.GetAll<Event>() on clients.client_id equals events.client_id

                // repository base simple crud from a message queue.
                //join alerts4 in _mqRepository.GetAll<Alert>() on clients.client_id equals alerts4.client_id

                // where from a message queue.
                where clients.client_id == clientId //_apiRepository.GetById<Event>(123).client_id

                select new ClientEvent()
                {
                    Id = clients.client_id,
                    FirstName = clients.first_name,
                    LastName = clients.last_name,
                    EventCode = events.event_code,
                };

            return query.ToList<ClientEvent>();
        }


        public void SaveChanges()
        {
            UnitOfWork.SaveChanges();
        }
    }
}

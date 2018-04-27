using BI.Aspect.RabbitMq;
using BI.Aspect.RabbitMq.Contract;
using BI.Aspect.RabbitMq.Core;
// using BI.Enterprise.Common.Exceptions;
//using BI.Enterprise.Dto.Reports;
//using BI.Enterprise.ViewModels.Reports;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

//using Serilog;
//using SimpleInjector;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using System.ServiceProcess;

namespace BI.QueueConsumer.Service
{
    public partial class ServiceConsumer // : ServiceBase
    {
        #region Private Variables

        private readonly Container _container;

        //private readonly HeartBeatWorker _heartBeat;
        private readonly RabbitMqConsumer _rabbitMqConsumer;

        #endregion

        #region Constructor

        public ServiceConsumer(RabbitMqSettingsValues rabbitMQSettings)
        {
            //InitializeComponent();
            this._rabbitMqConsumer = new RabbitMqConsumer(rabbitMQSettings)
            {
                OnConnectionRecoveryError = OnConnectionRecoveryError,
                OnConnectionRestored = OnConnectionRestored,
                OnConnectionShutdown = OnConnectionShutdown,
                OnReceivedMessage = ProcessRequest
            };
            //this._heartBeat = new HeartBeatWorker(60000, "Reports Service.");
            this._container = new Container();
            this.IntializeInjections();
        }

        #endregion

        #region Protected Methods

        //protected override void OnStart(string[] args) =>
        //	this.StartService();

        //protected override void OnStop() =>
        //	this.StopService();

        #endregion

        #region Public Methods

        public void StartService()
        {
            //Log.Information("Reports Consumer - Starting");
            //this._heartBeat.Start();
            this._rabbitMqConsumer.StartConsumer();
            //Log.Information("Reports Consumer - Started");
        }

        public void StopService()
        {
            //Log.Information("Reports Consumer - Stopping");
            //this._heartBeat.Stop();
            this._rabbitMqConsumer.StopConsumer();
            //Log.Information("Reports Consumer - Stopped");
        }

        #endregion

        #region Private Static Methods

        private static T GetPayload<T>(string msg)
        {
            var payload = JsonConvert.DeserializeObject<QueueMessageRequest<T>>(msg).Payload;
            return payload;
        }

        private static void OnConnectionRecoveryError(string message)
        {
        }
        //Log.Information("Reports Consumer - Unable to restore connectivity: {message}", message);

        private static void OnConnectionRestored()
        {
        }
        //Log.Information("Reports Consumer - Connectivity restored.");

        private static void OnConnectionShutdown(string initiator, ushort code, string description) {
        }
	    //Log.Information("Reports Consumer - Connection shutdown: Initiator: {initiator} Code: {code}, Description: {description}",
			//	initiator, code, description);

		#endregion

		#region Private Methods

		private void IntializeInjections()
		{
			//this._container.Register<IReportsManager, ReportsManager>(Lifestyle.Transient);
			//this._container.Register<IReportsCore, ReportsCore>(Lifestyle.Transient);
			//this._container.Register<IReportsRepositoryManager, ReportsRepositoryManager>(Lifestyle.Transient);
			//this._container.Register<IReportsContext, ReportsContext>(Lifestyle.Transient);
			//this._container.Register<IRabbitMqMessage, RabbitMqMessage>(Lifestyle.Transient);
			//this._container.Register<IReportingService, ReportingService>(Lifestyle.Transient);

            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			//{
			//	NullValueHandling = NullValueHandling.Ignore,
			//	MissingMemberHandling = MissingMemberHandling.Ignore,
			//	ContractResolver = new CamelCasePropertyNamesContractResolver(),
			//	DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
			//};
		}

		private QueueMessageResponseBase ProcessRequest(string msg)
		{
		    Console.WriteLine("Message Received: {1}" + msg);
		    var request = JsonConvert.DeserializeObject<QueueMessageRequestBase>(msg);

            //Log.Debug("ProcessRequest: {Msg} - Started", msg);
		    var response = new QueueMessageResponseBase()
		    {
		        Message = msg
		    };

            return response;

			//try
			//{
			//	//var request = JsonConvert.DeserializeObject<QueueMessageRequestBase>(msg);
			//    //var mgr = this._container.GetInstance<IReportsManager>();
			//	switch (request.ActionId)
			//	{
			//		case 1:
			//			//var reportJobRequest = GetPayload<ReportJobRequest>(msg);
			//			//var dto = mgr.GetReportsInfo<ReportInfoResponse>(reportJobRequest);
			//			response.Success = true;
			//		    response.Response = "success";//dto;
			//			break;
			//		//default:
			//		//	throw new ValidationException(0, "Action id is not recognized.");
			//	}
			//}
			//catch (ValidationException ex)
			//{
			//	//Log.Warning("ProcessRequest: Validation error while processing request: {Msg}", ex.Message);
			//	//response.Code = ex.Code;
			//	response.Message = ex.Message;
			//}
			//catch (Exception ex)
			//{
			//	var exMsg = ex.Message;
			//	var iEx = ex.InnerException;
			//	while (iEx != null)
			//	{
			//		exMsg += $"\r\nInner Exception: {iEx.Message}";
			//		iEx = iEx.InnerException;
			//	}
			//	//Log.Error("ProcessRequest: Error while processing request: {Msg}", exMsg);
			//	//Log.Information("StackTrace: {StackTrace}", ex.StackTrace);
			//	response.Message = exMsg;
			//}
			//finally
			//{
			//	//Log.Debug("ProcessRequest: {Msg} - Completed", msg);
			//}
			//return response;
        }

		#endregion
	}
}
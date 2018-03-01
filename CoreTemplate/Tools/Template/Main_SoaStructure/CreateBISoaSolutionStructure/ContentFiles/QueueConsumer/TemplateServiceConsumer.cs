using BI.Aspect.RabbitMq;
using BI.Aspect.RabbitMq.Contract;
using BI.Enterprise.Common.Exceptions;
using BI.Enterprise.ViewModels.Template;
using BI.Repository.Template.Contract;
using BI.Repository.Template.Models;
using BI.ServiceBus.Core.Template;
using BI.ServiceBus.Core.Template.Contract;
using BI.ServiceBus.Manager.Template;
using BI.ServiceBus.Manager.Template.Contract;
using BI.ServiceBus.Repository.Template;
using BI.ServiceBus.Repository.Template.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using SimpleInjector;
using System;
using System.ServiceProcess;

namespace BI.QueueConsumer.Template
{
	public partial class TemplateServiceConsumer : ServiceBase
	{
		#region Private Variables
		private readonly Container _container;
		private readonly HeartBeatWorker _heartBeat;
		private readonly RabbitMqConsumer _rabbitMqConsumer;
		#endregion

		#region Constructor

		public TemplateServiceConsumer()
		{
			InitializeComponent();
			this._rabbitMqConsumer = new RabbitMqConsumer()
			{
				OnConnectionRecoveryError = OnConnectionRecoveryError,
				OnConnectionRestored = OnConnectionRestored,
				OnConnectionShutdown = OnConnectionShutdown,
				OnReceivedMessage = ProcessRequest
			};
			this._heartBeat = new HeartBeatWorker(60000, "Template Service.");
			this._container = new Container();
			this.IntializeInjections();
		}

		#endregion

		#region Protected Methods

		protected override void OnStart(string[] args) =>
			this.StartService();

		protected override void OnStop() =>
			this.StopService();

		#endregion

		#region Public Methods

		public void StartService()
		{
			Log.Information("Template Consumer - Starting");
			this._heartBeat.Start();
			this._rabbitMqConsumer.StartConsumer();
			Log.Information("Template Consumer - Started");
		}

		public void StopService()
		{
			Log.Information("Template Consumer - Stopping");
			this._heartBeat.Stop();
			this._rabbitMqConsumer.StopConsumer();
			Log.Information("Template Consumer - Stopped");
		}

		#endregion

		#region Private Static Methods

		private static T GetPayload<T>(string msg) => JsonConvert.DeserializeObject<QueueMessageRequest<T>>(msg).Payload;

		private static void OnConnectionRecoveryError(string message) =>
			Log.Information("Template Consumer - Unable to restore connectivity: {message}", message);

		private static void OnConnectionRestored() =>
			Log.Information("Template Consumer - Connectivity restored.");

		private static void OnConnectionShutdown(string initiator, ushort code, string description) =>
			Log.Information("Template Consumer - Connection shutdown: Initiator: {initiator} Code: {code}, Description: {description}",
				initiator, code, description);

		#endregion

		#region Private Methods

		private void IntializeInjections()
		{
			this._container.Register<ITemplateManager, TemplateManager>(Lifestyle.Transient);
			this._container.Register<ITemplateCore, TemplateCore>(Lifestyle.Transient);
			this._container.Register<ITemplateRepositoryManager, TemplateRepositoryManager>(Lifestyle.Transient);
			this._container.Register<ITemplateContext, TemplateContext>(Lifestyle.Transient);
			this._container.Register<IRabbitMqMessage, RabbitMqMessage>(Lifestyle.Transient);
			JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				MissingMemberHandling = MissingMemberHandling.Ignore,
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate
			};
		}

		private QueueMessageResponseBase ProcessRequest(string msg)
		{
			Log.Debug("ProcessRequest: {Msg} - Started", msg);
			var response = new QueueMessageResponseBase();
			try
			{
				var request = JsonConvert.DeserializeObject<QueueMessageRequestBase>(msg);
				var mgr = this._container.GetInstance<ITemplateManager>();
				switch (request.ActionId)
				{
					case 1:
						var id = GetPayload<int>(msg);
						var dto = mgr.GetTemplateInfo<TemplateInfo>(id);
						response.Success = true;
						response.Response = dto;
						break;
					default:
						throw new ValidationException(0, "Action id is not recognized.");
				}
			}
			catch (ValidationException ex)
			{
				Log.Warning("ProcessRequest: Validation error while processing request: {Msg}", ex.Message);
				response.Code = ex.Code;
				response.Message = ex.Message;
			}
			catch (Exception ex)
			{
				var exMsg = ex.Message;
				var iEx = ex.InnerException;
				while (iEx != null)
				{
					exMsg += $"\r\nInner Exception: {iEx.Message}";
					iEx = iEx.InnerException;
				}
				Log.Error("ProcessRequest: Error while processing request: {Msg}", exMsg);
				Log.Information("StackTrace: {StackTrace}", ex.StackTrace);
				response.Message = exMsg;
			}
			finally
			{
				Log.Debug("ProcessRequest: {Msg} - Completed", msg);
			}
			return response;
		}

		#endregion
	}
}
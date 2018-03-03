//using BI.Aspect.RabbitMq.Contract;
//using Newtonsoft.Json;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace BI.Aspect.RabbitMq
//{
//	/// <summary>
//	///
//	/// </summary>
//	public class RabbitMqConsumer : IDisposable
//	{
//		#region Private Variables
//		private readonly RabbitMqSettingsValues _settings;
//		private CancellationTokenSource _cancellationTokenSource;
//		private IConnection _cnx;
//		#endregion

//		#region Delegates

//		/// <summary>
//		///
//		/// </summary>
//		/// <param name="message"></param>
//		public delegate void ConnectionRecoveryError(string message);

//		/// <summary>
//		///
//		/// </summary>
//		public delegate void ConnectionRestored();

//		/// <summary>
//		///
//		/// </summary>
//		/// <param name="initiator"></param>
//		/// <param name="code"></param>
//		/// <param name="description"></param>
//		public delegate void ConnectionShutdown(string initiator, ushort code, string description);

//		/// <summary>
//		///
//		/// </summary>
//		/// <param name="consumerTag"></param>
//		public delegate void ConsumerCancelled(string consumerTag);

//		/// <summary>
//		///
//		/// </summary>
//		/// <param name="message"></param>
//		/// <returns></returns>
//		public delegate QueueMessageResponseBase ReceivedMessage(string message);

//		#endregion

//		#region Events

//		/// <summary>
//		///
//		/// </summary>
//		public ConnectionRecoveryError OnConnectionRecoveryError { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public ConnectionRestored OnConnectionRestored { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public ConnectionShutdown OnConnectionShutdown { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public ConsumerCancelled OnConsumerCancelled { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public ReceivedMessage OnReceivedMessage { get; set; }

//		#endregion

//		#region Constructor

//		/// <summary>
//		///
//		/// </summary>
//		public RabbitMqConsumer() => this._settings = RabbitMqConfigSettings.Instance.GetSettingsValues();

//		#endregion

//		#region IDisposable implementation

//		/// <summary>
//		///
//		/// </summary>
//		public void Dispose()
//		{
//			if (!(this._cnx?.IsOpen ?? false)) return;
//			this._cnx.Close();
//			this._cnx.Dispose();
//		}

//		#endregion

//		#region Public Methods

//		/// <summary>
//		///
//		/// </summary>
//		public void StartConsumer()
//		{
//			if (string.IsNullOrEmpty(this._settings.RabbitMqHost))
//				throw new Exception("The host address is required.");
//			if (string.IsNullOrEmpty(this._settings.QueueName))
//				throw new Exception("The queue name is required.");
//			if (this._settings.MaxChannels == 0)
//				throw new Exception("The total number of channels must be greater that 0 (zero).");
//			if (string.IsNullOrWhiteSpace(this._settings.Username))
//				throw new Exception("The user name is required.");
//			if (string.IsNullOrWhiteSpace(this._settings.Password))
//				throw new Exception("The password id required");

//			this._cancellationTokenSource = new CancellationTokenSource();

//			this.InitializeConnection();
//			this.StartThreads();
//		}

//		/// <summary>
//		///
//		/// </summary>
//		public void StopConsumer()
//		{
//			if (this._cnx?.IsOpen ?? false)
//			{
//				this._cnx.Close(200, "Service Stop", 20);
//				this._cnx = null;
//			}
//			this._cancellationTokenSource.Cancel();
//		}

//		private void StartThreads()
//		{
//			var token = this._cancellationTokenSource.Token;
//			for (var i = 0; i < this._settings.MaxChannels; i++)
//				Task.Run(() =>
//				{
//					new RabbitMqThread(this._cnx, this._settings, token)
//					{
//						OnReceivedMessage = OnReceivedMessage
//					}.StartConsuming();
//				}, token);
//		}

//		#endregion

//		#region Private Methods

//		private void Cnx_ConnectionRecoveryError(object sender, ConnectionRecoveryErrorEventArgs e)
//		{
//			var msg = e.Exception?.Message ?? string.Empty;
//			this.OnConnectionRecoveryError?.Invoke(msg);
//		}

//		private void Cnx_ConnectionShutdown(object sender, ShutdownEventArgs e)
//		{
//			var initiator = e.Initiator.ToString();
//			var replyCode = e.ReplyCode;
//			var replyText = e.ReplyText;
//			this.OnConnectionShutdown?.Invoke(initiator, replyCode, replyText);
//		}

//		private void Cnx_RecoverySucceeded(object sender, EventArgs e) =>
//			this.OnConnectionRestored?.Invoke();

//		private void InitializeConnection()
//		{
//			var factory = new ConnectionFactory
//			{
//				HostName = this._settings.RabbitMqHost,
//				UserName = this._settings.Username,
//				Password = this._settings.Password
//			};
//			this._cnx = factory.CreateConnection();
//			this._cnx.ConnectionRecoveryError += this.Cnx_ConnectionRecoveryError;
//			this._cnx.ConnectionShutdown += this.Cnx_ConnectionShutdown;
//			this._cnx.RecoverySucceeded += this.Cnx_RecoverySucceeded;
//		}

//		#endregion
//	}

//	#region Support Classes

//	internal class RabbitMqThread
//	{
//		#region Private Static Keys
//		public static string SESSION_KEY = "BiSessionInfo";
//		#endregion

//		#region Private Variables
//		private readonly IConnection _cnx;
//		private readonly RabbitMqSettingsValues _settings;
//		private IModel _channel;
//		private EventingBasicConsumer _consumer;
//		private CancellationToken _token;
//		#endregion

//		#region Events
//		internal RabbitMqConsumer.ConsumerCancelled OnConsumerCancelled { get; set; }
//		internal RabbitMqConsumer.ReceivedMessage OnReceivedMessage { get; set; }
//		#endregion

//		#region Constructor

//		internal RabbitMqThread(IConnection cnx, RabbitMqSettingsValues settings, CancellationToken token)
//		{
//			this._cnx = cnx;
//			this._settings = settings;
//			this._token = token;
//			this._token.Register(this.HandleTokenCancellation, true);
//			this.SetupChannel();
//		}

//		#endregion

//		#region Internal Methods

//		internal void StartConsuming()
//		{
//			if (!(this._channel?.IsOpen ?? false))
//				return;
//			this._channel.DeclareExchangeAndQueue(this._settings);
//			this._consumer = new EventingBasicConsumer(this._channel);
//			this._consumer.ConsumerCancelled += this.Consumer_ConsumerCancelled;
//			this._consumer.Received += this.Consumer_Received;
//			this._channel.BasicConsume(this._settings.QueueName, this._settings.NoAck, this._consumer);
//		}

//		#endregion

//		#region Private Static Methods

//		private static void ParseSessionInfo(string message)
//		{
//			var baseRequest = JsonConvert.DeserializeObject<QueueMessageRequestBase>(message);
//			var label = string.IsNullOrWhiteSpace(baseRequest.SessionInfo)
//				? $"N/A:N/A:{Guid.NewGuid()}"
//				: baseRequest.SessionInfo;

//			Thread.SetData(Thread.GetNamedDataSlot(SESSION_KEY), label);
//		}

//		#endregion

//		#region Private Methods

//		private void Consumer_ConsumerCancelled(object sender, ConsumerEventArgs e)
//		{
//			this.OnConsumerCancelled?.Invoke(e.ConsumerTag);
//			if (!this._token.IsCancellationRequested && this._cnx.IsOpen)
//			{
//				Thread.Sleep(1000);
//				if (this._cnx.IsOpen && this._channel.IsOpen)
//					this.StartConsuming();
//			}
//		}

//		private void Consumer_Received(object sender, BasicDeliverEventArgs e)
//		{
//			var message = Encoding.UTF8.GetString(e.Body);
//			try
//			{
//				ParseSessionInfo(message);
//				var resp = this.OnReceivedMessage?.Invoke(message);
//				this._channel.BasicAck(e.DeliveryTag, false);

//				if (!(resp?.Success ?? false) && this._settings.MoveToErrorQueueOnFail)
//					this.MoveRequestToErrorQueue(e, resp?.Message);

//				if (string.IsNullOrWhiteSpace(e.BasicProperties.ReplyTo))
//					return;

//				try
//				{
//					var msg = resp == null ? string.Empty : JsonConvert.SerializeObject(resp);
//					var respBytes = Encoding.UTF8.GetBytes(msg);
//					RabbitMqMessage.EnqueueMessage(this._channel, e.Exchange, e.BasicProperties.ReplyTo, respBytes, persistent: false);
//				}
//				catch
//				{
//					// ignored
//				}
//			}
//			catch (Exception ex)
//			{
//				this._channel.BasicNack(e.DeliveryTag, false, false);
//				this.MoveRequestToErrorQueue(e, ex.Message);
//			}
//			finally
//			{
//				Thread.FreeNamedDataSlot(SESSION_KEY);
//			}
//		}

//		private void HandleTokenCancellation()
//		{
//			if (!(this._channel?.IsOpen ?? false))
//				return;

//			this._channel.Close(200, "Termination requested.");
//			this._channel = null;
//		}

//		private void MoveRequestToErrorQueue(BasicDeliverEventArgs e, string errorMessage)
//		{
//			var headers = new Dictionary<string, object> { { "Error", errorMessage } };
//			RabbitMqMessage.EnqueueMessage(this._channel, e.Exchange, $"{e.RoutingKey}_Errored", e.Body, headers: headers);
//		}

//		private void SetupChannel()
//		{
//			if (!(this._cnx?.IsOpen ?? false))
//				return;
//			this._channel = this._cnx.CreateModel();
//			this._channel.BasicQos(0, 1, false);
//		}

//		#endregion
//	}

//	#endregion
//}
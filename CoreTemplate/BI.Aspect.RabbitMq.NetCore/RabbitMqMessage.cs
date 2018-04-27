using BI.Aspect.RabbitMq.Contract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BI.Aspect.RabbitMq
{
    /// <inheritdoc />
    public class RabbitMqMessage : IRabbitMqMessage
    {
        #region Public Methods

        /// <inheritdoc />
        public QueueMessageResponse<T> EnqueueAndWaitResponse<T>(QueueMessageRequest payload, string appName, string replyTo = null)
        {
            replyTo = string.IsNullOrWhiteSpace(replyTo) ? Guid.NewGuid().ToString() : replyTo;
            SetSessionInfo(payload);
            var message = JsonConvert.SerializeObject(payload);
            return EnqueueAndWaitResponse<T>(message, replyTo, appName);
        }

        /// <inheritdoc />
        public void EnqueueMessage(QueueMessageRequest payload, string appName)
        {
            SetSessionInfo(payload);
            var message = JsonConvert.SerializeObject(payload);
            EnqueueMessage(message, appName);
        }

        #endregion

        #region Internal Methods

        internal static void EnqueueMessage(IModel chnl, string exchangeName, string queueName, byte[] body, bool mandatory = false,
            string replyTo = null, bool persistent = true, IDictionary<string, object> headers = null)
        {
            var properties = chnl.CreateBasicProperties();
            if (!string.IsNullOrWhiteSpace(replyTo))
                properties.ReplyTo = replyTo;
            if (headers != null)
                properties.Headers = headers;
            properties.DeliveryMode = 2;
            properties.Persistent = persistent;
            exchangeName = exchangeName ?? string.Empty;
            chnl.ConfirmSelect();
            chnl.BasicPublish(exchangeName, queueName, basicProperties: properties, body: body, mandatory: mandatory);
            chnl.WaitForConfirms();
        }

        #endregion

        #region Private Methods

        //private static ConnectionFactory CreateFactory(RabbitMqConfigElement rs) => new ConnectionFactory
        private static ConnectionFactory CreateFactory() => new ConnectionFactory
        {
            HostName = "localhost", //rs.RabbitMqHost,
            UserName = "guest", //rs.Username,
            Password = "password", //rs.Password
        };

        private static QueueMessageResponse<T> EnqueueAndWaitResponse<T>(string message, string replyTo, string appName) =>
            EnqueueAndWaitResponse<T>(Encoding.UTF8.GetBytes(message), replyTo, appName);

        private static QueueMessageResponse<T> EnqueueAndWaitResponse<T>(byte[] body, string replyTo, string appName)
        {
            //var rs = RabbitMqConfigSettings.Instance.RabbitMqConfigCollection[appName];
            //var factory = CreateFactory(rs);
            var factory = CreateFactory();
            using (var cnx = factory.CreateConnection())
            {
                using (var chnl = cnx.CreateModel())
                {
                    //var queueDetails = chnl.DeclareExchangeAndQueue(rs.GetSettingsValues());
                    var queueDetails = chnl.DeclareExchangeAndQueue(null);
                    var replyQueue = chnl.DeclareResponseQueue(null, replyTo);
                    //var replyQueue = chnl.DeclareResponseQueue(rs.GetSettingsValues(), replyTo);
                    //EnqueueMessage(chnl, rs.ExchangeName, queueDetails.QueueName, body, rs.Mandatory, replyTo);
                    EnqueueMessage(chnl,"testexchange", queueDetails.QueueName, body, true, replyTo);

                    var isTimeout = true;
                    var resp = new QueueMessageResponse<T>();
                    var consumer = new EventingBasicConsumer(chnl);
                    var completed = false;
                    //var timeup = DateTime.Now.AddMilliseconds(rs.ReplyTimeout);
                    var timeup = DateTime.Now.AddMilliseconds(3000);
                    consumer.Received += (sender, e) =>
                    {
                        try
                        {
                            isTimeout = false;
                            resp = JsonConvert.DeserializeObject<QueueMessageResponse<T>>(Encoding.UTF8.GetString(e.Body));
                            completed = true;
                        }
                        catch (Exception ex)
                        {
                            resp.Message = $"Exception from RabbitMqMessage Handler: {ex.Message}";
                        }
                    };
                    chnl.BasicConsume(replyQueue.QueueName, true, consumer);
                    Task.WaitAll(Task.Run(() =>
                    {
                        while (!completed && DateTime.Now <= timeup)
                            Task.Delay(1000);
                    }));
                    if (!isTimeout)
                        return resp;

                    chnl.Abort();
                    resp.Code = 0;
                    resp.Message = "Consumer timeout.";
                    return resp;
                }
            }
        }

        private static void EnqueueMessage(string message, string appName) =>
                            EnqueueMessage(Encoding.UTF8.GetBytes(message), appName);

        private static void EnqueueMessage(byte[] body, string appName)
        {
            //var rs = RabbitMqConfigSettings.Instance.RabbitMqConfigCollection[appName];
            //var factory = CreateFactory(rs);
            var factory = CreateFactory();
            using (var cnx = factory.CreateConnection())
            {
                using (var chnl = cnx.CreateModel())
                {
                    //var queueDetails = chnl.DeclareExchangeAndQueue(rs.GetSettingsValues());
                    var queueDetails = chnl.DeclareExchangeAndQueue(null);
                    //EnqueueMessage(chnl, rs.ExchangeName, queueDetails.QueueName, body, rs.Mandatory);
                    EnqueueMessage(chnl, "testexchange", queueDetails.QueueName, body, true);
                }
            }
        }

        private static void SetSessionInfo(QueueMessageRequest payload)
        {
            if (Thread.CurrentPrincipal is ClaimsPrincipal principal &&
                principal.Identities.FirstOrDefault() is ClaimsIdentity identity &&
                !string.IsNullOrWhiteSpace(identity.Label))
                payload.SessionInfo = identity.Label;
            else if (Thread.GetData(Thread.GetNamedDataSlot(RabbitMqThread.SESSION_KEY)) is string sessionInfo)
                payload.SessionInfo = sessionInfo;
        }

        #endregion
    }
}
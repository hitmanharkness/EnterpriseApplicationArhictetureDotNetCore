using System;
using System.Collections.Generic;
using System.Text;

namespace BI.Aspect.RabbitMq.Core
{
    public class RabbitMqSettingsValues
    {
        #region Exchange Settings

        public bool ExchangeAutoDelete { get; set; } = false;
        public bool ExchangeDurable { get; set; } = true;
        public string ExchangeName { get; set; } = "TestExchange";
        public string ExchangeType { get; set; } = "direct";
        #endregion

        #region Queue Settings

        public bool QueueAutoDelete { get; set; } = false;
        public bool QueueDurable { get; set; } = true;
        public bool QueueExclusive { get; set; } = false;
        public string QueueName { get; set; } = "TestQueue";
        #endregion

        #region Consume Settings
        public ushort MaxChannels { get; set; } = 40;
        public bool MoveToErrorQueueOnFail { get; internal set; } = false;
        public bool NoAck { get; set; } = false;
        #endregion

        #region Message Settings

        public bool Mandatory { get; set; } = false;
        public int ReplyTimeout { get; set; } = 10000;
        #endregion

        #region Server Settings

        public string Password { get; set; } = "guest";
        public string RabbitMqHost { get; set; } = "localhost";
        public string Username { get; set; } = "guest";

        #endregion
    }
}

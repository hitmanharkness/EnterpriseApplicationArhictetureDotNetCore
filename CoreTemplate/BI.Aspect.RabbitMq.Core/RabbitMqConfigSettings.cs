//using System;
//using System.Configuration;

//namespace BI.Aspect.RabbitMq
//{
//	/// <summary>
//	///
//	/// </summary>
//	public class RabbitMqConfigSettings // TODO : ConfigurationSection
//	{
//		#region Private Constants
//		private const string APPLICATION_SETTINGS = "applicationSettings";
//		// TODO private const string SECTION_NAME = "rabbitMQSettings";
//		#endregion

//		#region Lazy Load

//		/// <summary>
//		///
//		/// </summary>
//		public static readonly Lazy<RabbitMqConfigSettings> Lazy = new Lazy<RabbitMqConfigSettings>(GetConfigSettings);

//		/// <summary>
//		///
//		/// </summary>
//		public static RabbitMqConfigSettings Instance => Lazy.Value;

//		private static RabbitMqConfigSettings GetConfigSettings()
//		{
//            // TODO var configSection = (RabbitMqConfigSettings)ConfigurationManager.GetSection(SECTION_NAME);
//		    // TODO return configSection;
//		    return new RabbitMqConfigSettings();
//		}

//        #endregion

//        #region Public Properties

//        //NOTE: The properties at the root level are meant to be used by consumers or the mass transit implementation.
//        //		For regular clients a RabbitMQConfigElement must be created.

//        #region Exchange Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.EXCHANGE_AUTO_DELETE, DefaultValue = false)]
//        // TODO public bool ExchangeAutoDelete => (bool)this[SettingsConstants.EXCHANGE_AUTO_DELETE];
//        public bool ExchangeAutoDelete => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.EXCHANGE_DURABLE, DefaultValue = true)]
//        // TODO public bool ExchangeDurable => (bool)this[SettingsConstants.EXCHANGE_DURABLE];
//        public bool ExchangeDurable => true;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.EXCHANGE_NAME, DefaultValue = "")]
//        // TODO public string ExchangeName => (string)this[SettingsConstants.EXCHANGE_NAME];
//        public string ExchangeName => "testexchange";

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.EXCHANGE_TYPE, DefaultValue = "direct")]
//        // TODO public string ExchangeType => (string)this[SettingsConstants.EXCHANGE_TYPE];
//        public string ExchangeType => "direct";

//        #endregion

//        #region Queue Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.QUEUE_AUTO_DELETE, DefaultValue = false)]
//        // TODO public bool QueueAutoDelete => (bool)this[SettingsConstants.QUEUE_AUTO_DELETE];
//        public bool QueueAutoDelete => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.QUEUE_DURABLE, DefaultValue = true)]
//        // TODO public bool QueueDurable => (bool)this[SettingsConstants.QUEUE_DURABLE];
//        public bool QueueDurable => true;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.QUEUE_EXCLUSIVE, DefaultValue = false)]
//        // TODO public bool QueueExclusive => (bool)this[SettingsConstants.QUEUE_EXCLUSIVE];
//        public bool QueueExclusive => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.QUEUE_NAME, DefaultValue = "")]
//        // TODO public string QueueName => (string)this[SettingsConstants.QUEUE_NAME];
//        public string QueueName => "testqueue";

//        #endregion

//        #region Consumer Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.MAX_CHANNELS, DefaultValue = (ushort)0)]
//        // TODO public ushort MaxChannels => (ushort)this[SettingsConstants.MAX_CHANNELS];
//        public ushort MaxChannels => 40;

//        /// <summary>
//        /// true to move the request to an error queue when the process returns a failure; Otherwise false.
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.MOVE_TO_ERROR_QUEUE_ON_FAIL, IsRequired = false, DefaultValue = false)]
//        // TODO public bool MoveToErrorQueueOnFail => (bool)this[SettingsConstants.MOVE_TO_ERROR_QUEUE_ON_FAIL];
//        public bool MoveToErrorQueueOnFail => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.NO_ACK, DefaultValue = false)]
//        // TODO public bool NoAck => (bool)this[SettingsConstants.NO_ACK];
//        public bool NoAck => false;

//        #endregion

//        #region Message Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.MANDATORY, DefaultValue = false)]
//        // TODO public bool Mandatory => (bool)this[SettingsConstants.MANDATORY];
//        public bool Mandatory => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.REPLY_TIMEOUT, DefaultValue = 10000)]
//        // TODO public int ReplyTimeout => (int)this[SettingsConstants.REPLY_TIMEOUT];
//        public int ReplyTimeout => 10000;

//        #endregion

//        #region Server Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.PASSWORD, DefaultValue = "")]
//        // TODO public string Password => (string)this[SettingsConstants.PASSWORD];
//        public string Password => "guest";

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.RABBIT_MQ_HOST, DefaultValue = "")]
//        // TODO public string RabbitMqHost => (string)this[SettingsConstants.RABBIT_MQ_HOST];
//        public string RabbitMqHost => "localhost";

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.USERNAME, DefaultValue = "")]
//        // TODO public string Username => (string)this[SettingsConstants.USERNAME];
//        public string Username => "guest";

//        #endregion

//        #region Collection Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(APPLICATION_SETTINGS),
//        // TODO ConfigurationCollection(typeof(RabbitMqConfigCollection), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
//        // TODO public RabbitMqConfigCollection RabbitMqConfigCollection => (RabbitMqConfigCollection)base[APPLICATION_SETTINGS];
//        public RabbitMqConfigCollection RabbitMqConfigCollection => new RabbitMqConfigCollection();


//        internal RabbitMqSettingsValues SettingsValues { get; set; }

//        #endregion

//        #region XML Configuration settings

//        /// <summary>
//        /// Gets the XML name space where the rules are defined for this configuration section.
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.XMLNS, DefaultValue = "urn:RabbitMQ.ConfigSettings", IsRequired = false)]
//        // TODO public string Xmlns => (string)this[SettingsConstants.XMLNS];
//        public string Xmlns => "";

//        #endregion

//        #endregion

//        #region Public Methods

//        /// <summary>
//        ///
//        /// </summary>
//        /// <returns></returns>
//        public RabbitMqSettingsValues GetSettingsValues()
//		{
//			//if (this.SettingsValues != null)
//			//	return this.SettingsValues;
//			this.SettingsValues = new RabbitMqSettingsValues
//			{
//				ExchangeAutoDelete = this.ExchangeAutoDelete,
//				ExchangeDurable = this.ExchangeDurable,
//				ExchangeName = this.ExchangeName,
//				ExchangeType = this.ExchangeType,
//				Mandatory = this.Mandatory,
//				MaxChannels = this.MaxChannels,
//				MoveToErrorQueueOnFail = this.MoveToErrorQueueOnFail,
//				NoAck = this.NoAck,
//				Password = this.Password,
//				QueueAutoDelete = this.QueueAutoDelete,
//				QueueDurable = this.QueueDurable,
//				QueueExclusive = this.QueueExclusive,
//				QueueName = this.QueueName,
//				RabbitMqHost = this.RabbitMqHost,
//				ReplyTimeout = this.ReplyTimeout,
//				Username = this.Username
//			};
//			return this.SettingsValues;
//		}

//		#endregion
//	}

//	/// <summary>
//	///
//	/// </summary>
//	public class RabbitMqConfigCollection // TODO : ConfigurationElementCollection
//    {
//        #region Public Properties

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.AddRemoveClearMap;

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        // TODO 
//        //public RabbitMqConfigElement this[int index]
//        //{
//        //	get => (RabbitMqConfigElement)base.BaseGet(index);
//        //	set
//        //	{
//        //		if (base.BaseGet(index) != null)
//        //			base.BaseRemoveAt(index);
//        //		base.BaseAdd(index, value);
//        //	}
//        //}

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="appName"></param>
//        /// <returns></returns>
//        // TODO public new RabbitMqConfigElement this[string appName] => (RabbitMqConfigElement) base.BaseGet(appName);

//        #endregion

//        #region Public Methods

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="element"></param>
//        // TODO public void Add(RabbitMqConfigSettings element) => base.BaseAdd(element, true);

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO public void Clear() => base.BaseClear();

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="key"></param>
//        // TODO public void Remove(string key) => base.BaseRemove(key);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <returns></returns>
//        // TODO protected override ConfigurationElement CreateNewElement() => new RabbitMqConfigElement();

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="element"></param>
//        /// <returns></returns>
//        // TODO protected override object GetElementKey(ConfigurationElement element) => ((RabbitMqConfigElement)element).AppName;

//        #endregion
//    }

//    /// <summary>
//    ///
//    /// </summary>
//    public class RabbitMqConfigElement //: ConfigurationElement
//	{
//		#region Private Constants
//		private const string APP_NAME = "appName";
//        #endregion

//        #region Configuration Properties

//        #region Exchange Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.EXCHANGE_AUTO_DELETE, DefaultValue = false)]
//        // TODO public bool ExchangeAutoDelete => (bool)this[SettingsConstants.EXCHANGE_AUTO_DELETE];
//        public bool ExchangeAutoDelete => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.EXCHANGE_DURABLE, DefaultValue = true)]
//        // TODO public bool ExchangeDurable => (bool)this[SettingsConstants.EXCHANGE_DURABLE];
//        public bool ExchangeDurable => true;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.EXCHANGE_NAME, DefaultValue = "")]
//        // TODO public string ExchangeName => (string)this[SettingsConstants.EXCHANGE_NAME];
//        public string ExchangeName => "testexchange";

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.EXCHANGE_TYPE, DefaultValue = "direct")]
//        // TODO public string ExchangeType => (string)this[SettingsConstants.EXCHANGE_TYPE];
//        public string ExchangeType => "direct";

//        #endregion

//        #region Queue Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.QUEUE_AUTO_DELETE, DefaultValue = false)]
//        // TODO public bool QueueAutoDelete => (bool)this[SettingsConstants.QUEUE_AUTO_DELETE];
//        public bool QueueAutoDelete => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.QUEUE_DURABLE, DefaultValue = true)]
//        // TODO public bool QueueDurable => (bool)this[SettingsConstants.QUEUE_DURABLE];
//        public bool QueueDurable => true;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.QUEUE_EXCLUSIVE, DefaultValue = false)]
//        // TODO public bool QueueExclusive => (bool)this[SettingsConstants.QUEUE_EXCLUSIVE];
//        public bool QueueExclusive => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.QUEUE_NAME, IsRequired = true)]
//        // TODO public string QueueName => (string)this[SettingsConstants.QUEUE_NAME];
//        public string QueueName => "testqueue";

//        #endregion

//        #region Consumer Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.MAX_CHANNELS, DefaultValue = (ushort)100)]
//        // TODO public ushort MaxChannels => (ushort)this[SettingsConstants.MAX_CHANNELS];
//        public ushort MaxChannels => 100;

//        /// <summary>
//        /// true to move the request to an error queue when the process returns a failure; Otherwise false.
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.MOVE_TO_ERROR_QUEUE_ON_FAIL, IsRequired = false, DefaultValue = false)]
//        // TODO public bool MoveToErrorQueueOnFail => (bool)this[SettingsConstants.MOVE_TO_ERROR_QUEUE_ON_FAIL];
//        public bool MoveToErrorQueueOnFail => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.NO_ACK, DefaultValue = false)]
//        // TODO public bool NoAck => (bool)this[SettingsConstants.NO_ACK];
//        public bool NoAck => false;

//        #endregion

//        #region Message Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.MANDATORY, DefaultValue = false)]
//        // TODO public bool Mandatory => (bool)this[SettingsConstants.MANDATORY];
//        public bool Mandatory => false;

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.REPLY_TIMEOUT, IsRequired = false, DefaultValue = 30000)]
//        // TODO public int ReplyTimeout => (int)this[SettingsConstants.REPLY_TIMEOUT];
//        public int ReplyTimeout => 30000;

//        #endregion

//        #region Server Settings

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.PASSWORD, DefaultValue = "")]
//        // TODO public string Password => (string) this.SettingsConstants.PASSWORD;
//        public string Password => "guest";

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.RABBIT_MQ_HOST, IsRequired = true)]
//        // TODO public string RabbitMqHost => (string)this[SettingsConstants.RABBIT_MQ_HOST];
//        public string RabbitMqHost => "localhost";

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(SettingsConstants.USERNAME, DefaultValue = "")]
//        // TODO public string Username => (string)this[SettingsConstants.USERNAME];
//        public string Username => "guest";

//        #endregion

//        /// <summary>
//        ///
//        /// </summary>
//        // TODO [ConfigurationProperty(APP_NAME, IsKey = true, IsRequired = true)]
//        // TODO public string AppName => (string)this[APP_NAME];
//        public string AppName => "testapp";

//        internal RabbitMqSettingsValues SettingsValues { get; set; }

//		#endregion

//		#region Public Methods

//		/// <summary>
//		///
//		/// </summary>
//		/// <returns></returns>
//		public RabbitMqSettingsValues GetSettingsValues()
//		{
//			if (this.SettingsValues == null)
//				this.SettingsValues = new RabbitMqSettingsValues
//				{
//					ExchangeAutoDelete = this.ExchangeAutoDelete,
//					ExchangeDurable = this.ExchangeDurable,
//					ExchangeName = this.ExchangeName,
//					ExchangeType = this.ExchangeType,
//					MaxChannels = this.MaxChannels,
//					Mandatory = this.Mandatory,
//					NoAck = this.NoAck,
//					Password = this.Password,
//					QueueAutoDelete = this.QueueAutoDelete,
//					QueueDurable = this.QueueDurable,
//					QueueExclusive = this.QueueExclusive,
//					QueueName = this.QueueName,
//					RabbitMqHost = this.RabbitMqHost,
//					ReplyTimeout = this.ReplyTimeout,
//					Username = this.Username
//				};
//			return this.SettingsValues;
//		}

//		#endregion
//	}

//	#region Support Classes

//	/// <summary>
//	///
//	/// </summary>
//	public class RabbitMqSettingsValues
//	{
//		#region Exchange Settings

//		/// <summary>
//		///
//		/// </summary>
//		public bool ExchangeAutoDelete { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public bool ExchangeDurable { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public string ExchangeName { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public string ExchangeType { get; set; }

//		#endregion

//		#region Queue Settings

//		/// <summary>
//		///
//		/// </summary>
//		public bool QueueAutoDelete { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public bool QueueDurable { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public bool QueueExclusive { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public string QueueName { get; set; }

//		#endregion

//		#region Consume Settings

//		/// <summary>
//		///
//		/// </summary>
//		public ushort MaxChannels { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public bool MoveToErrorQueueOnFail { get; internal set; }

//		/// <summary>
//		///
//		/// </summary>
//		public bool NoAck { get; set; }

//		#endregion

//		#region Message Settings

//		/// <summary>
//		///
//		/// </summary>
//		public bool Mandatory { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public int ReplyTimeout { get; set; }

//		#endregion

//		#region Server Settings

//		/// <summary>
//		///
//		/// </summary>
//		public string Password { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public string RabbitMqHost { get; set; }

//		/// <summary>
//		///
//		/// </summary>
//		public string Username { get; set; }

//		#endregion
//	}

//	//internal static class SettingsConstants
//	//{
//	//	internal const string EXCHANGE_AUTO_DELETE = "exchangeAutoDelete";
//	//	internal const string EXCHANGE_DURABLE = "exchangeDurable";
//	//	internal const string EXCHANGE_NAME = "exchangeName";
//	//	internal const string EXCHANGE_TYPE = "exchangeType";
//	//	internal const string MANDATORY = "mandatory";
//	//	internal const string MAX_CHANNELS = "maxChannels";
//	//	internal const string MOVE_TO_ERROR_QUEUE_ON_FAIL = "moveToErrorQueueOnFail";
//	//	internal const string NO_ACK = "noAck";
//	//	internal const string PASSWORD = "password";
//	//	internal const string QUEUE_AUTO_DELETE = "queueAutoDelete";
//	//	internal const string QUEUE_DURABLE = "queueDurable";
//	//	internal const string QUEUE_EXCLUSIVE = "queueExclusive";
//	//	internal const string QUEUE_NAME = "queueName";
//	//	internal const string RABBIT_MQ_HOST = "rabbitMQHost";
//	//	internal const string REPLY_TIMEOUT = "replyTimeout";
//	//	internal const string SECTION_NAME = "rabbitMQSettings";
//	//	internal const string USERNAME = "username";
//	//	internal const string XMLNS = "xmlns";
//	//}

//	#endregion
//}
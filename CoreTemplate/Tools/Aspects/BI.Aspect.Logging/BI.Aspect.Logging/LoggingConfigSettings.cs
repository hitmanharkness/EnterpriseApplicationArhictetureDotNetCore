using Serilog.Events;
using System;
using System.Configuration;
using System.IO;

namespace BI.Aspect.Logging
{
	/// <summary>
	/// Represents the configuration settings for the BI logging module.
	/// </summary>
	public class LoggingConfigSettings : ConfigurationSection
	{
		#region Private Constants

		private const string
			ENVIRONMENT_NAME = "environmentName",
			FILE_EVENT_LEVEL = "fileEventLevel",
			LOG_COUNT = "logCount",
			LOG_ROOT = "logRoot",
			SECTION_NAME = "loggingSettings",
			XMLNS = "xmlns";

		#endregion

		#region Lazy Load
		private static readonly Lazy<LoggingConfigSettings> LazyInstance = new Lazy<LoggingConfigSettings>(GetConfingSection);

		/// <summary>
		///
		/// </summary>
		public static LoggingConfigSettings Instance => LazyInstance.Value;

		private static LoggingConfigSettings GetConfingSection()
		{
			var configSection = (LoggingConfigSettings)ConfigurationManager.GetSection(SECTION_NAME);
			return configSection;
		}

		#endregion

		#region Configuration Properties

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(ENVIRONMENT_NAME, DefaultValue = "dev", IsRequired = false)]
		public string EnvironmentName => this[ENVIRONMENT_NAME].ToString();

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(FILE_EVENT_LEVEL, DefaultValue = LogEventLevel.Information, IsRequired = false)]
		public LogEventLevel FileEventLevel => (LogEventLevel)this[FILE_EVENT_LEVEL];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(LOG_COUNT, DefaultValue = 90, IsRequired = false)]
		public int LogCount => (int)this[LOG_COUNT];

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(LOG_ROOT, DefaultValue = @"C:\Logs\", IsRequired = false)]
		public string LogRoot => this[LOG_ROOT].ToString();

		/// <summary>
		///
		/// </summary>
		[ConfigurationProperty(XMLNS, DefaultValue = "urn:Logging.ConfigSettings", IsRequired = false)]
		public string XmlNs => this[XMLNS].ToString();

		#endregion

		#region Public Properties

		/// <summary>
		///
		/// </summary>
		public string AppName { get; set; }

		/// <summary>
		///
		/// </summary>
		public string SerilogPath => this.GetSerilogPath();

		#endregion

		#region Private Methods

		private string GetSerilogPath()
		{
			var logRoot = this.LogRoot;
			var envName = this.EnvironmentName;
			var evtLevel = this[FILE_EVENT_LEVEL].ToString();
			var logFile = "{Date}-" + evtLevel + ".log";
			var newPath = Path.Combine(logRoot, envName, this.AppName);
			if (!Directory.Exists(newPath))
				Directory.CreateDirectory(newPath);
			var newFilePath = Path.Combine(newPath, logFile);
			return newFilePath;
		}

		#endregion
	}
}
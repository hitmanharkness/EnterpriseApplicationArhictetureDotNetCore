using System;
using System.Configuration;
using System.IO;

namespace BI.Aspect.Config
{
	/// <summary>
	///
	/// </summary>
	public class ConfigSettingsLogging : ConfigurationSection
	{
		#region Private Constants

		private const string
			ENVIRONMENT_NAME = "environmentName",
			FILE_EVENT_LEVEL = "fileEventLevel",
			LOG_COUNT = "logCount",
			LOG_ROOT = "logRoot",
			SECTION_NAME = "logConfigs";

		#endregion

		#region Lazy Load
		private static readonly Lazy<ConfigSettingsLogging> LazyInstance = new Lazy<ConfigSettingsLogging>(GetConfingSection);

		/// <summary>
		///
		/// </summary>
		public static ConfigSettingsLogging Instance => LazyInstance.Value;

		private static ConfigSettingsLogging GetConfingSection()
		{
			var configSection = (ConfigSettingsLogging)ConfigurationManager.GetSection(SECTION_NAME);
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
			var logRoot = LogRoot;
			var envName = EnvironmentName;
			var evtLevel = this[FILE_EVENT_LEVEL].ToString();
			var logFile = "{Date}-" + evtLevel + ".log";
			var newPath = Path.Combine(logRoot, envName, AppName);
			if (!Directory.Exists(newPath))
				Directory.CreateDirectory(newPath);
			var newFilePath = Path.Combine(newPath, logFile);
			return newFilePath;
		}

		#endregion
	}

	#region Support Types

	/// <summary>
	/// Specifies the meaning and relative importance of a log event.
	/// </summary>
	public enum LogEventLevel
	{
		/// <summary>
		/// Anything and everything you might want to know about a running block of code.
		/// </summary>
		Verbose = 0,

		/// <summary>
		/// Internal system events that aren't necessarily observable from the outside.
		/// </summary>
		Debug = 1,

		/// <summary>
		/// The lifeblood of operational intelligence - things happen.
		/// </summary>
		Information = 2,

		/// <summary>
		/// Service is degraded or endangered.
		/// </summary>
		Warning = 3,

		/// <summary>
		/// Functionality is unavailable, invariants are broken or data is lost.
		/// </summary>
		Error = 4,

		/// <summary>
		/// If you have a pager, it goes off when one of these occurs.
		/// </summary>
		Fatal = 5
	}

	#endregion
}
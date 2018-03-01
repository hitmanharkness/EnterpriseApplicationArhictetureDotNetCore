using Serilog;
using System;
using SerilogLogEventLevel = Serilog.Events.LogEventLevel;

namespace BI.Aspect.Logging
{
	using Config;
	using Enricher;

	/// <summary>
	///
	/// </summary>
	public static class LoggingHandler
	{
		/// <summary>
		///
		/// </summary>
		public static Guid RequestId { get; set; }

		/// <summary>
		///
		/// </summary>
		/// <param name="appAssembly"></param>
		public static void Initialize(System.Reflection.Assembly appAssembly)
		{
			var name = string.Empty;
			var version = string.Empty;
			if (appAssembly != null && !appAssembly.GetName().Name.Equals("System.Web"))
			{
				name = appAssembly.GetName().Name;
				version = appAssembly.GetName().Version.ToString();
			}

			var logSettings = ConfigSettingsLogging.Instance;
			logSettings.AppName = name;
			var logFilePath = logSettings.SerilogPath;

			var isWebApi = name.IndexOf("webapi", StringComparison.InvariantCultureIgnoreCase) > -1;
			var format = isWebApi
				? "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} - [{HttpRequestId}] - [{EntityId}] - [{EntityType}] - [{Level}] - {Message}{NewLine}{Exception}"
				: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} - [{ThreadId}] - [{Level}] - {Message}{NewLine}{Exception}";

			var logConfig = new LoggerConfiguration()
				.WriteTo.RollingFile(
					logFilePath,
					(SerilogLogEventLevel)logSettings.FileEventLevel,
					format,
					retainedFileCountLimit: logSettings.LogCount)
				.MinimumLevel.Verbose();

			if (isWebApi)
				logConfig = logConfig.Enrich.With(new HttpRequestIdEnricher())
					.Enrich.With(new SessionDetailsEnricher());
			else
				logConfig = logConfig.Enrich.With(new ThreadEnricher());

			Log.Logger = logConfig.CreateLogger();
			Log.Information("---==< Logging Started >==---");
			Log.Debug("Environment: {val}, App: {app}, Ver: {ver}, Logging to file: {fileName}, Level: {@logLevel}",
				logSettings.EnvironmentName,
				name,
				version,
				logSettings.SerilogPath,
				logSettings.FileEventLevel);
		}
	}
}
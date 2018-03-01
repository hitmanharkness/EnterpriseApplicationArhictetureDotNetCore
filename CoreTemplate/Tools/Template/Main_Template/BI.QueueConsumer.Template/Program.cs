using BI.Aspect.Logging;
using Serilog;

namespace BI.QueueConsumer.Template
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		private static void Main()
		{
			LoggingHandler.Initialize(typeof(Program).Assembly);
			Log.Information("Template service - Starting");
#if DEBUG
			var c = new TemplateServiceConsumer();
			c.StartService();
			//System.Threading.Tasks.Task.Run(() =>
			//{
			//	System.Threading.Thread.Sleep(10000);
			//	c.StopService();
			//});
#else
			var ServicesToRun = new[] { new TemplateServiceConsumer() };
			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
#endif
			Log.Information("Template service - Started");
#if DEBUG
			System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#endif
		}
	}
}
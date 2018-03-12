//using Serilog.Core;
//using Serilog.Events;
//using System.Threading;

//namespace BI.Aspect.Logging.Enricher
//{
//	/// <summary>
//	///
//	/// </summary>
//	public class ThreadEnricher : ILogEventEnricher
//	{
//		/// <summary>
//		///
//		/// </summary>
//		/// <param name="logEvent"></param>
//		/// <param name="propertyFactory"></param>
//		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
//		{
//			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadId", Thread.CurrentThread.ManagedThreadId));
//			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ThreadCurrentCulture",
//				Thread.CurrentThread.CurrentUICulture));
//		}
//	}
//}
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Chapter2.DIC;

namespace Chapter2.Test.SOLID
{
    /// <summary>
    /// IoC pattern implementation as Dependency Injection with .NET Core
    /// </summary>
    public class DICTests
    {
        private static IServiceProvider Provider { get; set; }

        [Fact]
        public void Test_Simple_DIC()
        {
            RegisterServices();
            ExecuteScedule();
        }

        private void RegisterServices(bool bUseFactory = false)
        {
            IServiceCollection services = new ServiceCollection();

            //Adding required dependencies to the DI Container
            //Note: DebugLogger only available when Debugger is attached
            services.AddTransient<ILogger, DebugLogger>(provider => new DebugLogger(typeof(DICTests).FullName));
            services.AddTransient<IAirportFlightSchedules, AirportFlightSchedules>();
            services.AddSingleton(typeof(ScheduleWorker));

            if(bUseFactory) ConfigureServices(services);

            Provider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAirportFlightSchedulesFactory, AirportFlightSchedulesFactory>();
        }

        [Fact]
        public void Test_Simple_DIC_WithFactory()
        {
            RegisterServices(true);
            ExecuteSceduleWithFactory();
        }

        private void ExecuteSceduleWithFactory()
        {
            var scheduleWorker = Provider.GetRequiredService<ScheduleWorker>();
            scheduleWorker.ExecuteSchedulesUsingFactoryViaDI();
        }

        private void ExecuteScedule()
        {
            var scheduleWorker = Provider.GetRequiredService<ScheduleWorker>();
            scheduleWorker.ExecuteSchedules();
        }       
    }
}

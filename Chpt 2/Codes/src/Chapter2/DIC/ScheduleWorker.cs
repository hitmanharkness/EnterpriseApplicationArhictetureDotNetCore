using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Chapter2.DIC
{
    public class ScheduleWorker
    {
        private IServiceProvider _provider;
        private ILogger _logger;

        public ScheduleWorker(IServiceProvider provider, ILogger logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public void ExecuteSchedules()
        {
            _logger.LogInformation("Executing schedules at {UTCTime}", DateTime.UtcNow);

            IAirportFlightSchedules airportFlightSchedules = _provider.GetRequiredService<IAirportFlightSchedules>();

            _logger.LogInformation("Getting schedules..");
            var arrivalSchedules = airportFlightSchedules.GetDailyArrivalSchedules(DateTime.UtcNow.Date);

            _logger.LogInformation("{FlightCount} schedules found", arrivalSchedules.Count);
        }

        public void ExecuteSchedulesUsingFactoryViaDI()
        {
            _logger.LogInformation("Executing schedules at {UTCTime}", DateTime.UtcNow);

            var factory = _provider.GetRequiredService<IAirportFlightSchedulesFactory>();
            IAirportFlightSchedules airportFlightSchedules = factory.CreateAirportFlightSchedules();

            _logger.LogInformation("Getting schedules..");
            var arrivalSchedules = airportFlightSchedules.GetDailyArrivalSchedules(DateTime.UtcNow.Date);

            _logger.LogInformation("{FlightCount} schedules found", arrivalSchedules.Count);

            //This doesn't invokes factory constructor essentially as it was added to DI container as a Singleton lifetime
            factory = _provider.GetRequiredService<IAirportFlightSchedulesFactory>();
        }
    }
}

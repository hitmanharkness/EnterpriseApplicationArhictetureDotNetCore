using Microsoft.Extensions.Logging;

namespace Chapter2.DIC
{
    public class AirportFlightSchedulesFactory : IAirportFlightSchedulesFactory
    {
        private ILogger _logger;
        private static int instanceCounter = 0;

        public AirportFlightSchedulesFactory(ILogger logger)
        {
            _logger = logger;
            instanceCounter++;

            _logger.LogDebug("Factory constructor invoked {0} times", instanceCounter);
        }

        public IAirportFlightSchedules CreateAirportFlightSchedules()
        {
            return new AirportFlightSchedules(_logger);
        }
    }
}

using Microsoft.Extensions.Logging;

namespace Chapter2.DIC
{
    public class GenevaAirportFlightSchedulesFactory : IAirportFlightSchedulesFactory
    {
        private ILogger _logger;

        public GenevaAirportFlightSchedulesFactory(ILogger logger)
        {
            _logger = logger;
        }

        public IAirportFlightSchedules CreateAirportFlightSchedules()
        {
            return new GenevaAirportFlightSchedules(_logger);
        }
    }
}

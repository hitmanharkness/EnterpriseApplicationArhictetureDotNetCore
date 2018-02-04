using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Chapter2.DIC
{
    public class AirportFlightSchedules : IAirportFlightSchedules
    {
        private ILogger _logger;

        public AirportFlightSchedules(ILogger logger)
        {
            _logger = logger;
        }

        public IList<string> GetDailyArrivalSchedules(DateTime date)
        {
            _logger.LogInformation("GetDailyArrivalSchedules is not implemented");

            return new List<string>();
        }

        public IList<string> GetDailyDepartureSchedules(DateTime date)
        {
            _logger.LogInformation("GetDailyDepartureSchedules is not implemented");

            return new List<string>();
        }
    }
}

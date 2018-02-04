using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Chapter2.DIC
{
    public class GenevaAirportFlightSchedules : IAirportFlightSchedules
    {
        private ILogger _logger;

        public GenevaAirportFlightSchedules(ILogger logger)
        {
            _logger = logger;
        }

        public IList<string> GetDailyArrivalSchedules(DateTime date)
        {
            _logger.LogInformation("GetDailyArrivalSchedules for Geneva");

            return new List<string>();
        }

        public IList<string> GetDailyDepartureSchedules(DateTime date)
        {
            _logger.LogInformation("GetDailyDepartureSchedules for Geneva");

            return new List<string>();
        }
    }
}

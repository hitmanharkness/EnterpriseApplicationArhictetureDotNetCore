using System;
using System.Collections.Generic;

namespace Chapter2.DIC
{
    public interface IAirportFlightSchedules
    {
        IList<string> GetDailyArrivalSchedules(DateTime date);
        IList<string> GetDailyDepartureSchedules(DateTime date);
    }
}

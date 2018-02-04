using System;

namespace Chapter2.GoF.Strategy
{
    /// <summary>
    /// Travel duration calculating strategy using public transport (bus, tram, train..)
    /// </summary>
    public class PublicTransportDurationCalculator : IDurationCalculator
    {
        public TimeSpan Measure(string pointA, string pointB)
        {
            //Calculate and return the time duration value..
            return new TimeSpan(6, 02, 0);
        }
    }
}

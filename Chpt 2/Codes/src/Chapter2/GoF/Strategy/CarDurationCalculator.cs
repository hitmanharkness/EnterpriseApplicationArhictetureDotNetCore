using System;

namespace Chapter2.GoF.Strategy
{
    /// <summary>
    /// Travel duration calculating strategy using car
    /// </summary>
    public class CarDurationCalculator : IDurationCalculator
    {
        public TimeSpan Measure(string pointA, string pointB)
        {
            //Calculate and return the time duration value..
            return new TimeSpan(4, 46, 0);
        }
    }
}

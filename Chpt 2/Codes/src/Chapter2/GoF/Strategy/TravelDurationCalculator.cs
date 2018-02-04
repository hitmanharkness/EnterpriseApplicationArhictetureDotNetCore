using System;

namespace Chapter2.GoF.Strategy
{
    public class TravelDurationCalculator
    {
        private IDurationCalculator strategy;

        public TimeSpan Measure(string pointA, string pointB)
        {
            return strategy.Measure(pointA, pointB);
        }

        //Change the strategy
        public void SetCalculator(IDurationCalculator strategy)
        {
            this.strategy = strategy;
        }
    }
}

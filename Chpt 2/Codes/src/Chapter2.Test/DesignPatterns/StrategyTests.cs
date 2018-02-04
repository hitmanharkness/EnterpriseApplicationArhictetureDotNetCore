using Chapter2.GoF.Strategy;
using System;
using System.Diagnostics;
using Xunit;

namespace Chapter2.Test.DesignPatterns
{
    public class StrategyTests
    {
        [Fact]
        public void Test_Strategy_Pattern()
        {
            string pointA = "Berlin";
            string pointB = "Frankfurt";
            TimeSpan timeSpan;
            var durationCalculator = new TravelDurationCalculator();

            durationCalculator.SetCalculator(new PublicTransportDurationCalculator());
            timeSpan = durationCalculator.Measure(pointA, pointB);
            Trace.WriteLine(pointA + " to " + pointB + " takes " + timeSpan.ToString() + " using public transport.");

            durationCalculator.SetCalculator(new CarDurationCalculator());
            timeSpan = durationCalculator.Measure(pointA, pointB);
            Trace.WriteLine(pointA + " to " + pointB + " takes " + timeSpan.ToString() + " using car.");
        }
    }
}

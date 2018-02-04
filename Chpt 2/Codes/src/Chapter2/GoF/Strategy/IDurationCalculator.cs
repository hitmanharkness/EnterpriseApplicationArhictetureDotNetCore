using System;

namespace Chapter2.GoF.Strategy
{
    public interface IDurationCalculator
    {
        TimeSpan Measure(string pointA, string pointB);
    }
}
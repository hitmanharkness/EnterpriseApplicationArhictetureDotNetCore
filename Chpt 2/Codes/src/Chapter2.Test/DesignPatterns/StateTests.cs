using Chapter2.GoF.State;
using Xunit;
using System.Diagnostics;

namespace Chapter2.Test.DesignPatterns
{
    public class StateTests
    {
        [Fact]
        public void Test_State_Pattern()
        {
            var weatherTeller = new WeatherTeller();

            var weatherDays = weatherTeller.GetWeatherDays();
            Trace.WriteLine(string.Format("Name: {0} - Days: {1}", weatherDays.Weather, weatherDays.Days));

            weatherDays = weatherTeller.GetWeatherDays();
            Trace.WriteLine(string.Format("Name: {0} - Days: {1}", weatherDays.Weather, weatherDays.Days));

            weatherDays = weatherTeller.GetWeatherDays();
            Trace.WriteLine(string.Format("Name: {0} - Days: {1}", weatherDays.Weather, weatherDays.Days));

            weatherDays = weatherTeller.GetWeatherDays();
            Trace.WriteLine(string.Format("Name: {0} - Days: {1}", weatherDays.Weather, weatherDays.Days));

            weatherDays = weatherTeller.GetWeatherDays();
            Trace.WriteLine(string.Format("Name: {0} - Days: {1}", weatherDays.Weather, weatherDays.Days));
        }
    }
}

using Chapter2.GoF.Visitor;
using Xunit;

namespace Chapter2.Test.DesignPatterns
{
    public class VisitorTests
    {
        [Fact]
        public void Test_Visitor_Pattern()
        {
            WeatherStructure weatherStructure = new WeatherStructure(new YahooWeatherBuilder());
            weatherStructure.BuildWeatherStructure();

            weatherStructure.BuildWeatherStructure2();

            weatherStructure.BuildAnotherWeatherStructure(new AnotherWeatherManipulator());

            weatherStructure.BuildAnotherWeatherStructure2(new AnotherWeatherManipulator());
        }
    }
}

using Chapter2.GoF.ChainOfResponsibility;
using Chapter2.GoF.ChainOfResponsibility.Commands;
using Xunit;

namespace Chapter2.Test.DesignPatterns
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public void Test_ChainOfResponsibility_Pattern()
        {
            IWeatherInfoBuilder wInfoBuilder1 = new WeatherDescriptionBuilder();
            IWeatherInfoBuilder wInfoBuilder2 = new WeatherMapBuilder();
            IWeatherInfoBuilder wInfoBuilder3 = new WeatherTemperatureBuilder();
            IWeatherInfoBuilder wInfoBuilder4 = new WeatherThumbnailBuilder();

            wInfoBuilder1.SetSuccessor(wInfoBuilder2);
            wInfoBuilder2.SetSuccessor(wInfoBuilder3);
            wInfoBuilder3.SetSuccessor(wInfoBuilder4);

            WeatherStructure weather = new WeatherStructure();
            wInfoBuilder1.BuildWeatherObject(weather);
        }
    }
}

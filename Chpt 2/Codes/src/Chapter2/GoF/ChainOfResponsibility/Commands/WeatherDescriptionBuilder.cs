using Chapter2.GoF.ChainOfResponsibility.Elements;

namespace Chapter2.GoF.ChainOfResponsibility.Commands
{
    public class WeatherDescriptionBuilder : IWeatherInfoBuilder
    {
        public override void BuildWeatherObject(WeatherStructure weatherStructure)
        {
            BuildWeatherDescription(weatherStructure.WeatherDescription);

            if (_successor != null)
                _successor.BuildWeatherObject(weatherStructure);
        }

        private void BuildWeatherDescription(WeatherDescription weatherDescription)
        {
            //construct Map appropriately
            weatherDescription.ShortDescription = "Cloudy";
            weatherDescription.Description = "Cloudy and foggy weather";
        }
    }
}

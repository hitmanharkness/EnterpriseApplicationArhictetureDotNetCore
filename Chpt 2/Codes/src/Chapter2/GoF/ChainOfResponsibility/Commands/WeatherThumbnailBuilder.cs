using Chapter2.GoF.ChainOfResponsibility.Elements;

namespace Chapter2.GoF.ChainOfResponsibility.Commands
{
    public class WeatherThumbnailBuilder : IWeatherInfoBuilder
    {
        public override void BuildWeatherObject(WeatherStructure weatherStructure)
        {
            BuildThumbnail(weatherStructure.WeatherThumbnail);

            if (_successor != null)
                _successor.BuildWeatherObject(weatherStructure);
        }

        private void BuildThumbnail(WeatherThumbnail weatherThumbnail)
        {
            //construct WeatherThumbnail appropriately
            weatherThumbnail.ThumbnailImage = new byte[4] { 1,2,3,4 };
        }
    }
}

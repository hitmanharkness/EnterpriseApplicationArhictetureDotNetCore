using Chapter2.GoF.ChainOfResponsibility.Elements;

namespace Chapter2.GoF.ChainOfResponsibility.Commands
{
    public class WeatherMapBuilder : IWeatherInfoBuilder
    {
        public override void BuildWeatherObject(WeatherStructure weatherStructure)
        {
            BuildMap(weatherStructure.Map);

            if (_successor != null)
                _successor.BuildWeatherObject(weatherStructure);
        }

        private void BuildMap(Map map)
        {
            //construct Map appropriately
            map.MapURL = "https://maps.google.com/";
        }
    }
}

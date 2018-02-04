using Chapter2.GoF.ChainOfResponsibility.Elements;

namespace Chapter2.GoF.ChainOfResponsibility.Commands
{
    public class WeatherTemperatureBuilder : IWeatherInfoBuilder
    {
        public override void BuildWeatherObject(WeatherStructure weatherStructure)
        {
            BuildTemperature(weatherStructure.Temperature);

            if (_successor != null)
                _successor.BuildWeatherObject(weatherStructure);
        }

        private void BuildTemperature(Temperature temperature)
        {
            //construct Temperature appropriately
            temperature.CentigradeTemperature = 22;
            temperature.FahrenheihtTemperature = 71;
        }
    }
}

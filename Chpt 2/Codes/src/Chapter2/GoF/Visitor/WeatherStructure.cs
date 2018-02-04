using System.Runtime.CompilerServices;

//Exposing internals to the Testing Assembly
[assembly: InternalsVisibleToAttribute("Chapter2.Test")]

namespace Chapter2.GoF.Visitor
{
    /// <summary>
    /// The object structure of the visitor pattern.
    /// It delegates the functionality of building the weather information to the
    /// (external class) visitor class without exposing its internal objects as public properties
    /// but as a proper agreed contract as per visitor pattern
    /// </summary>
    public class WeatherStructure
    {
        private Temperature _temperature;
        private Map _map;
        private WeatherThumbnail _weatherThumbnail;
        private WeatherDescription _weatherDescription;

        private IWeatherManipulator _weatherBuilder;

        public WeatherStructure(IWeatherManipulator weatherBuilder)
        {
            _weatherBuilder = weatherBuilder;

            _temperature = new Temperature();
            _map = new Map();
            _weatherThumbnail = new WeatherThumbnail();
            _weatherDescription = new WeatherDescription();
        }

        internal void BuildWeatherStructure()
        {
            _temperature.ManipulateMe(_weatherBuilder);
            _map.ManipulateMe(_weatherBuilder);
            _weatherThumbnail.ManipulateMe(_weatherBuilder);
            _weatherDescription.ManipulateMe(_weatherBuilder);
        }

        public void BuildWeatherStructure2()
        {
            _weatherBuilder.ManipulateElement(_temperature);
            _weatherBuilder.ManipulateElement(_map);
            _weatherBuilder.ManipulateElement(_weatherThumbnail);
            _weatherBuilder.ManipulateElement(_weatherDescription);
        }

        internal void BuildAnotherWeatherStructure(IAnotherWeatherManipulator anotherWeatherBuilder)
        {
            anotherWeatherBuilder.ManipulateElement(_temperature);
            anotherWeatherBuilder.ManipulateElement(_map);
            anotherWeatherBuilder.ManipulateElement(_weatherThumbnail);
            anotherWeatherBuilder.ManipulateElement(_weatherDescription);
        }

        internal void BuildAnotherWeatherStructure2(IAnotherWeatherManipulator anotherWeatherBuilder)
        {
            _temperature.ManipulateMe(anotherWeatherBuilder);
            _map.ManipulateMe(anotherWeatherBuilder);
            _weatherThumbnail.ManipulateMe(anotherWeatherBuilder);
            _weatherDescription.ManipulateMe(anotherWeatherBuilder);
        }
    }
}

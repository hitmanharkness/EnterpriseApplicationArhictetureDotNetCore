
namespace Chapter2.GoF.Visitor
{
    /// <summary>
    /// Abstract base class for IWeatherManipulator acting as a Visitor for the visitor pattern.
    /// Exposes abstract methods to be implemented by derived classes as a template method pattern.
    /// </summary>
    public abstract class WeatherManipulator : IWeatherManipulator
    {
        public void ManipulateElement(IWeatherElement weatherElement)
        {
            if (weatherElement is Map)
                BuildMap(weatherElement);
            else if (weatherElement is Temperature)
                BuildTemperature(weatherElement);
            else if (weatherElement is WeatherDescription)
                BuildWeatherDescription(weatherElement);
            else if (weatherElement is WeatherThumbnail)
                BuildWeatherThumbnail(weatherElement);
        }

        public abstract void BuildMap(IWeatherElement map);

        public abstract void BuildTemperature(IWeatherElement temperature);

        public abstract void BuildWeatherDescription(IWeatherElement weatherDescription);

        public abstract void BuildWeatherThumbnail(IWeatherElement weatherThumbnail);
    }
}

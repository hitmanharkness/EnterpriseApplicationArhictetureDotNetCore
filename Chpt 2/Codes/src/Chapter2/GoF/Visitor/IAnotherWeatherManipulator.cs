
namespace Chapter2.GoF.Visitor
{
    /// <summary>
    /// Another Interface for the Visitor object
    /// </summary>
    internal interface IAnotherWeatherManipulator
    {
        void ManipulateElement(Map map);
        void ManipulateElement(Temperature temperature);
        void ManipulateElement(WeatherDescription weatherDescription);
        void ManipulateElement(WeatherThumbnail weatherThumbnail);
    }
}
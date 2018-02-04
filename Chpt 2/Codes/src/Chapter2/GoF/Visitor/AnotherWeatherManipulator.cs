
namespace Chapter2.GoF.Visitor
{
    internal class AnotherWeatherManipulator : IAnotherWeatherManipulator
    {
        public void ManipulateElement(WeatherDescription weatherDescription)
        {
            weatherDescription.ShortDescription = "Sunny";
            weatherDescription.Description = "Nice sunny weather is expected which is not so hot";
        }

        public void ManipulateElement(WeatherThumbnail weatherThumbnail)
        {
            weatherThumbnail.ThumbnailImage = new byte[3] { 2, 2, 2 };
        }

        public void ManipulateElement(Temperature temperature)
        {
            temperature.CentigradeTemperature = 30;
            temperature.FahrenheihtTemperature = 86;
        }

        public void ManipulateElement(Map map)
        {
            map.MapURL = "https://www.bing.com";
        }
    }
}

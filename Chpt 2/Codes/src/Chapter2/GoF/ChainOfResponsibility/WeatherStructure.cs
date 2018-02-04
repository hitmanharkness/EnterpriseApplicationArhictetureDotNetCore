using Chapter2.GoF.ChainOfResponsibility.Elements;

namespace Chapter2.GoF.ChainOfResponsibility
{
    public class WeatherStructure
    {
        public WeatherStructure()
        {
            Temperature = new Temperature();
            Map = new Map();
            WeatherThumbnail = new WeatherThumbnail();
            WeatherDescription = new WeatherDescription();
        }

        public Temperature Temperature;
        public Map Map;
        public WeatherThumbnail WeatherThumbnail;
        public WeatherDescription WeatherDescription;
    }
}

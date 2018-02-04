
namespace Chapter2.GoF.Visitor
{
    public class YahooWeatherBuilder : WeatherManipulator
    {
        public override void BuildMap(IWeatherElement map)
        {
            var m = map as Map;
            m.MapURL = "https://maps.google.com/";
        }

        public override void BuildTemperature(IWeatherElement temperature)
        {
            var t = temperature as Temperature;
            t.CentigradeTemperature = 30;
            t.FahrenheihtTemperature = 86;
        }

        public override void BuildWeatherDescription(IWeatherElement weatherDescription)
        {
            var wd = weatherDescription as WeatherDescription;
            wd.ShortDescription = "Sunny";
            wd.Description = "Nice sunny weather is expected which is not so hot";
        }

        public override void BuildWeatherThumbnail(IWeatherElement weatherThumbnail)
        {
            var wt = weatherThumbnail as WeatherThumbnail;
            wt.ThumbnailImage = new byte[3] { 1, 1, 1 };
        }
    }
}

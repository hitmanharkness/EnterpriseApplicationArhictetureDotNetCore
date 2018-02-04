
namespace Chapter2.GoF.State.WeatherStates
{
    internal class WinterDaysTeller : IWeatherDaysTellerForState
    {
        public WeatherDays GetWeatherDays(IStateContext stateContext)
        {
            stateContext.SetState(new SpringDaysTeller());

            return new WeatherDays()
            {
                Weather = "Winter",
                Days = 120 //4 months * 30
            };
        }
    }
}

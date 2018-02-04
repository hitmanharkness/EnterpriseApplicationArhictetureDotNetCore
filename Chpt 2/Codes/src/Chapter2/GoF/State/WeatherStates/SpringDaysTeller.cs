
namespace Chapter2.GoF.State.WeatherStates
{
    internal class SpringDaysTeller : IWeatherDaysTellerForState
    {
        public WeatherDays GetWeatherDays(IStateContext stateContext)
        {
            stateContext.SetState(new SummerDaysTeller());

            return new WeatherDays()
            {
                Weather = "Spring",
                Days = 60 //2 months * 30
            };
        }
    }
}


namespace Chapter2.GoF.State.WeatherStates
{
    internal class SummerDaysTeller : IWeatherDaysTellerForState
    {
        public WeatherDays GetWeatherDays(IStateContext stateContext)
        {
            stateContext.SetState(new AutumnDaysTeller());

            return new WeatherDays()
            {
                Weather = "Summer",
                Days = 150 //5 months * 30
            };
        }
    }
}

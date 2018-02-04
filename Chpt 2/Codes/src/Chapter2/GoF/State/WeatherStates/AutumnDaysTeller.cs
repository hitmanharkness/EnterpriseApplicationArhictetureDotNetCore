
namespace Chapter2.GoF.State.WeatherStates
{
    internal class AutumnDaysTeller : IWeatherDaysTellerForState
    {
        public WeatherDays GetWeatherDays(IStateContext stateContext)
        {
            stateContext.SetState(new WinterDaysTeller());

            return new WeatherDays()
            {
                Weather = "Autumn",
                Days = 30 //1 month * 30
            };
        }
    }
}

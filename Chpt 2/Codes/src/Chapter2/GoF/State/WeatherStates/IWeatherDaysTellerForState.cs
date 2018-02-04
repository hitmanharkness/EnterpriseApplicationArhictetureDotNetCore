
namespace Chapter2.GoF.State.WeatherStates
{
    internal interface IWeatherDaysTellerForState
    {
        WeatherDays GetWeatherDays(IStateContext stateContext);
    }
}

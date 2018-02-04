using Chapter2.GoF.State.WeatherStates;

namespace Chapter2.GoF.State
{
    internal interface IStateContext
    {
        void SetState(IWeatherDaysTellerForState newWeatherState);
    }
}

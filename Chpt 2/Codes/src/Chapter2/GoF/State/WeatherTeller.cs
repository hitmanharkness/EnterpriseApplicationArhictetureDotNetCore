using Chapter2.GoF.State.WeatherStates;

namespace Chapter2.GoF.State
{
    /// <summary>
    /// WeatherTeller is an State Context class as per the State pattern
    /// implementing the interface IStateContext for
    /// segregation and understanding.
    /// </summary>
    public class WeatherTeller : IWeatherDaysTeller, IStateContext
    {
        private IWeatherDaysTellerForState weatherDaysTellerState;

        public WeatherTeller()
        {
            weatherDaysTellerState = new SummerDaysTeller();
        }

        public WeatherDays GetWeatherDays()
        {
            return weatherDaysTellerState.GetWeatherDays(this); ;
        }

        /// <summary>
        /// Internal interface IStateContext implementation
        /// </summary>
        void IStateContext.SetState(IWeatherDaysTellerForState newWeatherState)
        {
            weatherDaysTellerState = newWeatherState;
        }
    }
}

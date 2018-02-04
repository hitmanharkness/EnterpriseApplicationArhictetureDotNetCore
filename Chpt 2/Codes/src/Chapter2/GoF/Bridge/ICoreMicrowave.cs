
namespace Chapter2.GoF.Bridge
{
    /// <summary>
    /// Core Implementation Interface
    /// </summary>
    public interface ICoreMicrowave
    {
        //0 seconds to 1800 seconds
        void AdjustTime(int seconds);

        //0 to 10 steps (10=200 degree)
        void AdjustHeatingTemperature(int temperature);

        void Start();
    }
}

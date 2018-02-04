
namespace Chapter2.GoF.Bridge
{
    /// <summary>
    /// Core/Main Implementation of Microwave
    /// </summary>
    public class Microwave : ICoreMicrowave
    {
        public void AdjustHeatingTemperature(int temperature)
        {
            //AdjustHeatingTemperature() implementation
        }

        public void AdjustTime(int seconds)
        {
            //AdjustTime() implementation
        }

        public void Start()
        {
            //Validation checks, defaults, Start() imeplementation
        }
    }
}

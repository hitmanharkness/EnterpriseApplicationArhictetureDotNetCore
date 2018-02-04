
namespace Chapter2.GoF.Bridge
{
    public class PremiumMicrowave : IPremiumMicrowave
    {
        private ICoreMicrowave _microwave;
        private int[] _temperatureValuesForFood;

        public PremiumMicrowave(ICoreMicrowave microwave)
        {
            _microwave = microwave;
            _temperatureValuesForFood = new int[] { 180, 180, 150, 120, 100, 90, 80 };
        }

        public void AdjustTime(int seconds)
        {
            _microwave.AdjustTime(seconds);
        }

        public void SelectFood(FoodType foodType)
        {
            _microwave.AdjustHeatingTemperature(_temperatureValuesForFood[(int)foodType]);
        }

        public void Start()
        {
            _microwave.Start();
        }
    }
}

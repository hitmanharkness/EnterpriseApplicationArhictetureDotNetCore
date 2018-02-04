
namespace Chapter2.GoF.Bridge
{
    public class NewPremiumMicrowave : INewPremiumMicrowave
    {
        private ICoreMicrowave _microwave;
        private int[] _temperatureValuesForFood;
        private int[] _timeValuesForFood;

        public NewPremiumMicrowave(ICoreMicrowave microwave)
        {
            _microwave = microwave;

            //Storage of pre-determined values
            _temperatureValuesForFood = new int[] { 180, 180, 150, 120, 100, 90, 80 };
            _timeValuesForFood = new int[] { 300, 240, 180, 180, 150, 120, 60 };
        }

        public void SelectFood(FoodType foodType)
        {
            _microwave.AdjustTime(_temperatureValuesForFood[(int)foodType]);
            _microwave.AdjustHeatingTemperature(_temperatureValuesForFood[(int)foodType]);
        }

        public void Start()
        {
            _microwave.Start();
        }
    }
}

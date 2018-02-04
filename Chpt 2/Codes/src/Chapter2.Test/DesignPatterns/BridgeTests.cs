using Chapter2.GoF.Bridge;
using Xunit;

namespace Chapter2.Test.DesignPatterns
{
    public class BridgeTests
    {
        [Fact]
        public void Test_BridgePattern_Client()
        {
            ICoreMicrowave coreMicrowaveEngine = new Microwave();

            IPremiumMicrowave modernMicrowave = new PremiumMicrowave(coreMicrowaveEngine);
            modernMicrowave.SelectFood(FoodType.Chicken);
            modernMicrowave.AdjustTime(180); //Warmup for 3 minutes, selects temperature automatically
            modernMicrowave.Start();
        }

        [Fact]
        public void Test_BridgePattern_NewClient()
        {
            ICoreMicrowave coreMicrowaveEngine = new Microwave();

            INewPremiumMicrowave newModernMicrowave = new NewPremiumMicrowave(coreMicrowaveEngine);
            newModernMicrowave.SelectFood(FoodType.Chicken); //Selects temperature and time automatically
            newModernMicrowave.Start();
        }
    }
}


namespace Chapter2.GoF.Bridge
{
    public interface IPremiumMicrowave
    {
        //0 seconds to 1800 seconds
        void AdjustTime(int seconds);

        void SelectFood(FoodType foodType);

        void Start();
    }
}

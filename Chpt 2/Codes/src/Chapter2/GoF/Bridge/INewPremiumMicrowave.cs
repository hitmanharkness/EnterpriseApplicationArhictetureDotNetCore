
namespace Chapter2.GoF.Bridge
{
    /// <summary>
    /// It gives one touch functionality
    /// </summary>
    public interface INewPremiumMicrowave
    {
        void SelectFood(FoodType foodType);
        void Start();
    }
}

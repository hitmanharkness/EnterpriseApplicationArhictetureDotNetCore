
namespace Chapter2.DIP
{
    public interface IOrderRepository
    {
        bool Save(IOrder order);
    }
}

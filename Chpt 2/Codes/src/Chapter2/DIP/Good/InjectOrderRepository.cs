
namespace Chapter2.DIP.Good
{
    public interface InjectOrderRepository
    {
        void SetRepository(IOrderRepository orderRepository);
    }
}

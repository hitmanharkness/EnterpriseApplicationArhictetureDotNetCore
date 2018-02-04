
namespace Chapter2.DIP
{
    public class OrderRepository : IOrderRepository
    {
        public bool Save(IOrder order)
        {
            //Saves to order to persistence layer
            return true;
        }
    }
}

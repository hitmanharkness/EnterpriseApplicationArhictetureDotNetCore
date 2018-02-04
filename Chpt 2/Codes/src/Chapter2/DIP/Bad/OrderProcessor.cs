
namespace Chapter2.DIP.Bad
{
    public class OrderProcessor : IOrderProcessor
    {
        public void Process(IOrder order)
        {
            //Perform validations..
            if (new OrderRepository().Save(order))
                new OrderNotifier().Notify(order);
        }
    }
}

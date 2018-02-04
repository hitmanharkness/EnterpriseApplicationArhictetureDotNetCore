
namespace Chapter2.DIP
{
    public class OrderNotifier : IOrderNotifier
    {
        public void Notify(IOrder order)
        {
            //Generate notifications regarding the order..
        }
    }
}


namespace Chapter2.DIP.Good
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderNotifier _orderNotifier;

        public OrderProcessor(IOrderRepository orderRepository, IOrderNotifier orderNotifier)
        {
            _orderRepository = orderRepository;
            _orderNotifier = orderNotifier;
        }

        public void Process(IOrder order)
        {
            //Perform validations..
            if (_orderRepository.Save(order))
                _orderNotifier.Notify(order);
        }
    }
}

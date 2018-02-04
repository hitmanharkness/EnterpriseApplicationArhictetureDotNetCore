
namespace Chapter2.DIP.Good
{
    public class OrderProcessorWithInterface : InjectOrderRepository, InjectOrderNotifier, IOrderProcessor
    {
        private IOrderRepository _orderRepository;
        private IOrderNotifier _orderNotifier;

        public void SetRepository(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void SetNotifier(IOrderNotifier orderNotifier)
        {
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

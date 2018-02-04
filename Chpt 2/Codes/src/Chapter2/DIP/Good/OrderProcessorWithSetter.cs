
namespace Chapter2.DIP.Good
{
    public class OrderProcessorWithSetter : IOrderProcessor
    {
        private IOrderRepository _orderRepository;
        private IOrderNotifier _orderNotifier;

        public IOrderRepository Repository
        {
            get { return _orderRepository; }
            set { _orderRepository = value; }
        }

        public IOrderNotifier Notifier
        {
            get { return _orderNotifier; }
            set { _orderNotifier = value; }
        }

        public void Process(IOrder order)
        {
            //Perform validations..
            if (_orderRepository.Save(order))
                _orderNotifier.Notify(order);
        }
    }
}

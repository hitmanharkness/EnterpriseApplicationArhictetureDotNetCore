using Xunit;

namespace Chapter2.Test.SOLID
{
    public class DITests
    {
        [Fact]
        public void Test_DI_With_Setter()
        {
            var someOrder = new DIP.Order();
            var op = new DIP.Good.OrderProcessorWithSetter();
            op.Repository = new DIP.OrderRepository();
            op.Notifier = new DIP.OrderNotifier();

            op.Process(someOrder);
        }

        [Fact]
        public void Test_DI_With_Interface()
        {
            var someOrder = new DIP.Order();

            var op = new DIP.Good.OrderProcessorWithInterface();
            //Creation of objects and their respective dependencies (components/services inside) are usually done by the DI Framework
            op.SetRepository(new DIP.OrderRepository());
            op.SetNotifier(new DIP.OrderNotifier());

            op.Process(someOrder);
        }
    }
}

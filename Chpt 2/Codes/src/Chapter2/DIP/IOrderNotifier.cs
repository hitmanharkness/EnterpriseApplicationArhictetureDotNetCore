
namespace Chapter2.DIP
{
    public interface IOrderNotifier
    {
        void Notify(IOrder order); //Would internally notify buyer and system/seller using two or more separate interfaces.
    }
}

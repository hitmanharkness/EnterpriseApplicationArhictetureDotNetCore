
namespace Chapter2.DIP.Good
{
    public interface InjectOrderNotifier
    {
        void SetNotifier(IOrderNotifier orderNotifier);
    }
}

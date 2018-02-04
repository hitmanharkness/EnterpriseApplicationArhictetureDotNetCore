using Chapter2.GoF.Observer;
using Xunit;

namespace Chapter2.Test.DesignPatterns
{
    public class ObserverTests
    {
        [Fact]
        public void Test_Observer_Pattern()
        {
            var listener = new KeyboardListener();
            var statusBar = new StatusBar();
            var balloonNotifier = new BalloonNotifier();

            listener.AddObserver(statusBar);
            listener.AddObserver(balloonNotifier);

            listener.SartListening();

            listener.RemoveObserver(balloonNotifier);
            listener.SartListening(); //trigger a new notification again
        }
    }
}

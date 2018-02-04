using System.Diagnostics;

namespace Chapter2.GoF.Observer
{
    public class BalloonNotifier : IKeyObserver
    {
        public void Update(object anObject)
        {
            Trace.WriteLine("BalloonNotifier - Key pressed: " + anObject.ToString());
        }
    }
}

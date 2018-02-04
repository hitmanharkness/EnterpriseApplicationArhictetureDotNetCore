using System.Diagnostics;

namespace Chapter2.GoF.Observer
{
    public class StatusBar : IKeyObserver
    {
        public void Update(object anObject)
        {
            Trace.WriteLine("StatusBar - Key pressed: " + anObject.ToString());
        }
    }
}

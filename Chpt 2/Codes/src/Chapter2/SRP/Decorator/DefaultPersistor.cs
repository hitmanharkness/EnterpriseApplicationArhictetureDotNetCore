using System.Diagnostics;

namespace Chapter2.SRP.Decorator
{
    public class DefaultPersistor<T> : IPersistor<T>
    {
        public bool Persist(T objToPersist)
        {
            Trace.WriteLine("DefaultPersistor.Persist gets called");

            return true; //Do nothing, eat up.
        }
    }
}

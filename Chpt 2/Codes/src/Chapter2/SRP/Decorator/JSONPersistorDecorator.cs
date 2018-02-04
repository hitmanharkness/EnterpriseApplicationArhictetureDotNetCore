using System.Diagnostics;

namespace Chapter2.SRP.Decorator
{
    public class JSONPersistorDecorator<T> : PersistorDecorator<T>
    {
        public JSONPersistorDecorator(IPersistor<T> objectToBeDecorated) : base(objectToBeDecorated)
        { }

        public override bool Persist(T objToPersist)
        {
            if (base.Persist(objToPersist)) //stacking up functionality of the decorator pattern - which basically ensures that main functionality is achieved and this decorator adds up new functionality.
                return DoJSONPersistence();
            return false;
        }

        private bool DoJSONPersistence()
        {
            //Does JSON conversion and persistence operation..

            Trace.WriteLine("DoJSONPersistence gets called");

            return true;
        }
    }
}

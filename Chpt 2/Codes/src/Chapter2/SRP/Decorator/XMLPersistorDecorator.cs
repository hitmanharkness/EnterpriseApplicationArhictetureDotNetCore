using System.Diagnostics;

namespace Chapter2.SRP.Decorator
{
    public class XMLPersistorDecorator<T> : PersistorDecorator<T>
    {
        public XMLPersistorDecorator(IPersistor<T> objectToBeDecorated) : base(objectToBeDecorated)
        { }

        public override bool Persist(T objToPersist)
        {
            //stacking up functionality of the decorator pattern - which basically ensures that main functionality is achieved and this decorator adds up new functionality.
            if (base.Persist(objToPersist))
                return DoXMLPersistence();
            return false;
        }

        private bool DoXMLPersistence()
        {
            //Does XML conversion and persistence operation..

            Trace.WriteLine("DoXMLPersistence gets called");

            return true;
        }
    }
}

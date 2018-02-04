using System.Diagnostics;

namespace Chapter2.SRP.Decorator
{
    public class OraclePersistorDecorator<T> : PersistorDecorator<T>
    {
        public OraclePersistorDecorator(IPersistor<T> objectToBeDecorated) : base(objectToBeDecorated)
        { }

        //stacking up functionality of the decorator pattern - which basically ensures that main functionality is achieved and this decorator adds up new functionality.
        public override bool Persist(T objToPersist)
        {
            if (base.Persist(objToPersist))
                return DoOracleDBPersistence();
            return false;
        }

        private bool DoOracleDBPersistence()
        {
            //Does Oracle DB persistence operation..

            Trace.WriteLine("DoOracleDBPersistence gets called");

            return true;
        }
    }
}

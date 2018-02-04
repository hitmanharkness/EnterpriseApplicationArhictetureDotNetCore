using System.Diagnostics;

namespace Chapter2.SRP.Decorator
{
    public class MSSQLPersistorDecorator<T> : PersistorDecorator<T>
    {
        public MSSQLPersistorDecorator(IPersistor<T> objectToBeDecorated) : base(objectToBeDecorated)
        { }

        public override bool Persist(T objToPersist)
        {
            //stacking up functionality of the decorator pattern - which basically ensures that main functionality is achieved and this decorator adds up new functionality.
            if (base.Persist(objToPersist))
                return DoSQLSrvrDBPersistence();
            return false;
        }

        private bool DoSQLSrvrDBPersistence()
        {
            //Does SQL Server DB persistence operation..

            Trace.WriteLine("DoSQLSrvrDBPersistence gets called");

            return true;
        }
    }
}

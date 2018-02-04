namespace Chapter2.SRP.Decorator
{
    public abstract class PersistorDecorator<T> : IPersistor<T>
    {
        protected IPersistor<T> objectToBeDecorated;

        public PersistorDecorator(IPersistor<T> objectToBeDecorated)
        {
            this.objectToBeDecorated = objectToBeDecorated;
        }

        public virtual bool Persist(T objToPersist)
        {
            return objectToBeDecorated.Persist(objToPersist);
        }
    }
}

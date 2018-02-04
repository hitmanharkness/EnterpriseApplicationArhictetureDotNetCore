namespace Chapter2.SRP.Decorator
{
    public interface IPersistor<T>
    {
        bool Persist(T objToPersist);
    }
}

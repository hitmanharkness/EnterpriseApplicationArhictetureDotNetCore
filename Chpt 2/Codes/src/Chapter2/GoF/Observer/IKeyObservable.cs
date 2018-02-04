using System.Collections.Generic;

namespace Chapter2.GoF.Observer
{
    public abstract class IKeyObservable
    {
        private IList<IKeyObserver> _observers = new List<IKeyObserver>();

        public void AddObserver(IKeyObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IKeyObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(object anObject)
        {
            foreach (IKeyObserver observer in _observers)
            {
                observer.Update(anObject);
            }
        }
    }
}

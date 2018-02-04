
namespace Chapter2.GoF.Observer
{
    public class KeyboardListener : IKeyObservable
    {
        public void SartListening()
        {
            ListenToKeys(); //Normally it would be a continous process..
        }

        /// <summary>
        /// Listen and notify only the interested keys
        /// </summary>
        private void ListenToKeys()
        {
            ObservedKeys key;

            //Got the key, we are interested in..
            key = ObservedKeys.NUM_LOCK;

            NotifyObservers(key);
        }
    }
}


namespace Chapter2.GoF.Singleton
{
    /// <summary>
    /// A very simple Singleton class
    /// Its a sealed class just to prevent derivation that could potentially add instances
    /// </summary>
    public sealed class SimpleSingleton
    {
        /// <summary>
        /// Privately hidden app wide single static instance - self managed
        /// </summary>
        private static readonly SimpleSingleton instance = new SimpleSingleton();

        /// <summary>
        /// Private constructor to hinder clients to create the objects of <see cref="SimpleSingleton"/>
        /// </summary>
        private SimpleSingleton() { }

        /// <summary>
        /// Publicly accessible method to supply the only instace of <see cref="SimpleSingleton"/>
        /// </summary>
        /// <returns></returns>
        public static SimpleSingleton getInstance()
        {
            return instance;
        }
    }
}

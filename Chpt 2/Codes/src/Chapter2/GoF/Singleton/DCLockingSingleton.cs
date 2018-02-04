using System;

namespace Chapter2.GoF.Singleton
{
    /// <summary>
    /// Its a simple Double-Check Locking Singleton pattern
    /// </summary>
    public sealed class DCLockingSingleton
    {
        /// <summary>
        /// volatile tells the compiler not to optimze this field and a field might be modified by multiple threads
        /// </summary>
        private static volatile DCLockingSingleton instance = null;

        /// <summary>
        /// Single object instance is used to lock all the accesses to get the instance of the Singleton
        /// </summary>
        private static object syncRoot = new Object();

        private DCLockingSingleton() { }

        /// <summary>
        /// Exposed as a Get only property instead of a method
        /// </summary>
        public static DCLockingSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DCLockingSingleton();
                    }
                }

                return instance;
            }
        }
    }
}

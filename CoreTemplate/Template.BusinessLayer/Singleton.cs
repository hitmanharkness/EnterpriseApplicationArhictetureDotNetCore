//This source code was generated using Visual Studio Design Patterns add-in
//You can find the source code and binaries at http://VSDesignPatterns.codeplex.com

//Singleton: //Ensure a class only has one instance, and provide a global point of access to it.
using System;

namespace Template.BusinessLayer
{
    public sealed class ConcreteSingleton
    {
        private static readonly ConcreteSingleton _instance = new ConcreteSingleton();

        private ConcreteSingleton() { }

        public static ConcreteSingleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Operation()
        {
		Console.WriteLine("Operation of ConcreteSingleton");
        }

        public static void Test()
        {
            ConcreteSingleton singleton = ConcreteSingleton.Instance;
            singleton.Operation();

        }

    }
}

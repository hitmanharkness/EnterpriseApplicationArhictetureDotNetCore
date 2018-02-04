using System.Diagnostics;
using System.Threading.Tasks;

namespace Chapter3
{    
    public class TestParallel
    {
        static int N = 1000;

        public static void TestTheParallelProcessing()
        {
            // Using a named method.
            Parallel.For(0, N, Method2);

            /*
            // Using an anonymous method.
            Parallel.For(0, N, delegate (int i)
            {
                // Do Work.
            });

            // Using a lambda expression.
            Parallel.For(0, N, i =>
            {
                // Do Work.
            });
            */
        }

        private static void Method2(int i)
        {
            Trace.WriteLine("Method2: " + i);
        }
    }
}

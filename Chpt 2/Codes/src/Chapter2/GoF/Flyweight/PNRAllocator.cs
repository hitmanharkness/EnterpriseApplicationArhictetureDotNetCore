using System;

namespace Chapter2.GoF.Flyweight
{
    /// <summary>
    /// Utility class just for demonstration purposes
    /// (not directly related to pattern implementation)
    /// </summary>
    public static class PNRAllocator
    {
        private static Random random = new Random(99999);

        public static int AllocatePNR(string lastName, string id)
        {
            //Generate PNR number
            return random.Next(10000, int.MaxValue);
        }
    }
}

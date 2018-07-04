namespace Round
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0} => {1}", arr[i], Math.Round(arr[i], MidpointRounding.AwayFromZero));
            }
        }
    }
}
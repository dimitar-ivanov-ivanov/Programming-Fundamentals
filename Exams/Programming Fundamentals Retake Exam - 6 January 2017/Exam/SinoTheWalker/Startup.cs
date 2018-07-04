namespace SinoTheWalker
{
    using System;
    using System.Globalization;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var d = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            var mod = (24 * 60 * 60);
            var steps = long.Parse(Console.ReadLine()) % mod;
            var time = long.Parse(Console.ReadLine()) % mod;

            var total = (steps * time) % mod;

            d = d.AddSeconds(total);
            Console.WriteLine("Time Arrival: {0:D2}:{1:D2}:{2:D2}", d.Hour, d.Minute, d.Second);
        }
    }
}
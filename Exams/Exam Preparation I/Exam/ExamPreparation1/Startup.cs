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
            var time = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            var mod = 24 * 60 * 60;
            var steps = long.Parse(Console.ReadLine()) % mod;
            var second = long.Parse(Console.ReadLine()) % mod;
            var timespan = TimeSpan.FromSeconds(second * steps);
            var output = new DateTime(1000, 1, 3, time.Hour, time.Minute, time.Second);
            output = output.Add(timespan);
            time = time.AddSeconds(steps * second);

            Console.WriteLine("Time Arrival: {0:D2}:{1:D2}:{2:D2}", time.Hour, time.Minute, time.Second);
        }
    }
}
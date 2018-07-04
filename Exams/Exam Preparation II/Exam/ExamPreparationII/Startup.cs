namespace CharityMarathon
{
    using System;
    using System.Globalization;
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

            var marathonLength = double.Parse(Console.ReadLine());
            var runners = double.Parse(Console.ReadLine());
            var avgLaps = double.Parse(Console.ReadLine());
            var trackLength = double.Parse(Console.ReadLine());
            var capacityTrack = double.Parse(Console.ReadLine());
            var moneyPerKilometer = double.Parse(Console.ReadLine());
            var max = capacityTrack * marathonLength;

            max = Math.Min(max, runners);
            var meters = max * avgLaps * trackLength;
            meters /= 1000;

            Console.WriteLine("Money raised: {0:F2}", meters * moneyPerKilometer);
        }
    }
}
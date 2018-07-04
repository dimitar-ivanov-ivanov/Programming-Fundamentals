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
            var averageLaps = double.Parse(Console.ReadLine());
            var trackLength = double.Parse(Console.ReadLine());
            var trackCapacity = double.Parse(Console.ReadLine());
            var moneyDonatedPerKilometer = double.Parse(Console.ReadLine());

            var realRunners = Math.Min(trackCapacity * marathonLength, runners);
            var totalMeters = realRunners * averageLaps * trackLength;
            var totalKilometers = totalMeters / 1000;
            Console.WriteLine("Money raised: {0:F2}", totalKilometers * moneyDonatedPerKilometer);
        }
    }
}
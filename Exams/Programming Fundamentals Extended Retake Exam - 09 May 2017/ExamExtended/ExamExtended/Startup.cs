namespace SplinterTrip
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
            var tripDistance = double.Parse(Console.ReadLine());
            var fuelTankCapacity = double.Parse(Console.ReadLine());
            var milesSpend = double.Parse(Console.ReadLine());

            var nonHeavyWind = tripDistance - milesSpend;
            var fuelNonHeavyWind = nonHeavyWind * 25;
            var fuelHeavyWind = milesSpend * 25 * 1.5;

            var consumption = fuelHeavyWind + fuelNonHeavyWind;
            var tolerance = consumption * 5 / 100;
            var total = consumption + tolerance;

            var remaining = fuelTankCapacity - total;

            Console.WriteLine("Fuel needed: {0:F2}L", total);
            if (remaining < 0)
            {
                Console.WriteLine("We need {0:F2}L more fuel.", -remaining);
            }
            else
            {
                Console.WriteLine("Enough with {0:F2}L to spare!", remaining);
            }
        }
    }
}
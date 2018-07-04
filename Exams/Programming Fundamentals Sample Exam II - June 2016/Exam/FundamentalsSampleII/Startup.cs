namespace SoftniAirline
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
            var n = int.Parse(Console.ReadLine());
            decimal profit = 0;

            for (int i = 0; i < n; i++)
            {
                var adultCount = decimal.Parse(Console.ReadLine());
                var adultTicketPrice = decimal.Parse(Console.ReadLine());
                var youthCount = decimal.Parse(Console.ReadLine());

                var youthTicketPrice = decimal.Parse(Console.ReadLine());
                var fuelPriceHour = decimal.Parse(Console.ReadLine());
                var fuelConsumptionHour = decimal.Parse(Console.ReadLine());
                var flightDuration = decimal.Parse(Console.ReadLine());

                var income = adultCount * adultTicketPrice + youthCount * youthTicketPrice;
                var expenses = flightDuration * fuelConsumptionHour * fuelPriceHour;
                if (income < expenses)
                {
                    Console.WriteLine("We've got to sell more tickets! We've lost {0:F3}$.", income - expenses);
                }
                else
                {
                    Console.WriteLine("You are ahead with {0:F3}$.", income - expenses);
                }

                profit += income - expenses;
            }

            Console.WriteLine("Overall profit -> {0:F3}$.", profit);
            Console.WriteLine("Average profit -> {0:F3}$.", profit / n);
        }
    }
}

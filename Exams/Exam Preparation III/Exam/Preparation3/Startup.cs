namespace SoftuniCoffeOrders
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
            decimal sum = 0;

            for (int i = 0; i < n; i++)
            {
                var priceCapsule = decimal.Parse(Console.ReadLine());
                var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsulesCount = decimal.Parse(Console.ReadLine());

                var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                Console.WriteLine("The price for the coffee is: ${0:F2}", priceCapsule * capsulesCount * daysInMonth);
                sum += priceCapsule * capsulesCount * daysInMonth;
            }

            Console.WriteLine("Total: ${0:F2}", sum);
        }
    }
}

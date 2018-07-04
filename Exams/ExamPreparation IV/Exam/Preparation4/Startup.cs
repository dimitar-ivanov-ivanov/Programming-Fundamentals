namespace SweetDesert
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

            var cash = double.Parse(Console.ReadLine());
            var guests = int.Parse(Console.ReadLine());
            var priceBananas = double.Parse(Console.ReadLine());
            var priceEggs = double.Parse(Console.ReadLine());
            var priceBerries = double.Parse(Console.ReadLine());

            var portions = guests / 6;
            if (guests % 6 != 0) portions++;

            var res = (2 * priceBananas + 4 * priceEggs + 0.2 * priceBerries) * portions;
            if (res <= cash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", res);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", res - cash);
            }
        }
    }
}
using System;
using System.Globalization;
using System.Threading;

namespace Exam
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var cash = double.Parse(Console.ReadLine());
            var guests = int.Parse(Console.ReadLine());
            var bananas = double.Parse(Console.ReadLine());
            var eggs = double.Parse(Console.ReadLine());
            var berries = double.Parse(Console.ReadLine());

            double portions = guests / 6;
            if (guests % 6 != 0)
            {
                portions++;
            }

            var res = portions * (2 * bananas + 4 * eggs + 0.2 * berries);

            if (cash >= res)
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

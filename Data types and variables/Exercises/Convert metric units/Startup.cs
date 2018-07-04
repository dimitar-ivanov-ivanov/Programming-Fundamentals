namespace Convert_metric_units
{
    using System;

    public class Startup
    {
        private static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var distance = double.Parse(Console.ReadLine());
            var hours = double.Parse(Console.ReadLine());
            var minutes = double.Parse(Console.ReadLine());
            var second = double.Parse(Console.ReadLine());

            var totalSec = second + minutes * 60 + hours * 3600;

            Console.WriteLine("{0:F6}", distance / totalSec);
            Console.WriteLine("{0:F6}", distance * 1000 / hours);
            Console.WriteLine("{0:F6}", distance / 1609 / hours);
        }
    }
}

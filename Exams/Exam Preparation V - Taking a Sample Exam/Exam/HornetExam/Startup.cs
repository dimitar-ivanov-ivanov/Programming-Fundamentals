namespace HornetExam
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
            var m = double.Parse(Console.ReadLine());
            var p = int.Parse(Console.ReadLine());

            var distance = n / 1000 * m;
            var seconds = n / 100;
            var rest = n / p * 5;

            Console.WriteLine("{0:F2} m.", distance);
            Console.WriteLine("{0} s.", (int)(seconds + rest));
        }
    }
}
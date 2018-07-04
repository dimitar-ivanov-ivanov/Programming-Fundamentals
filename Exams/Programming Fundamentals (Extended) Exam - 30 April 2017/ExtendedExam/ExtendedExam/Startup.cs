namespace ExtendedExam
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
            var len = int.Parse(Console.ReadLine()) * 100;
            var width = double.Parse(Console.ReadLine());
            var rem = len % width;
            double res = 0;
            if (rem == 0 || rem % 1 != 0)
            {
                res = width * len;
                Console.WriteLine("{0:F2}", res);
            }
            else
            {
                res = len / width * 100;
                Console.WriteLine("{0:F2}%", res);
            }
        }
    }
}
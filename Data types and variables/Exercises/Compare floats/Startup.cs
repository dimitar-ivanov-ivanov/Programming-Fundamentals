namespace Compare_floats
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
            var a = float.Parse(Console.ReadLine());
            var b = float.Parse(Console.ReadLine());
            const float eps = 0.000001F;
            var diff = Math.Abs(a - b);
            var diff2 = Math.Abs(b - a);
            if (diff <= eps || diff2 <= eps)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
namespace Exchange_Variables
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            Console.WriteLine("Before:\na = {0}\nb = {1}", a, b);
            Console.WriteLine("After:\na = {0}\nb = {1}", b, a);
        }
    }
}
namespace Integer_to_hex_and_binary
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
            Console.WriteLine(Convert.ToString(a, 16).ToString().ToUpper());
            Console.WriteLine(Convert.ToString(a, 2));
        }
    }
}
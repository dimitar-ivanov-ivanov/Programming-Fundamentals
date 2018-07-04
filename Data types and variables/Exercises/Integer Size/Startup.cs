namespace Integer_Size
{
    using System;
    using System.Numerics;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = BigInteger.Parse(Console.ReadLine());
            if (n >= long.MaxValue || n <= long.MinValue)
            {
                Console.WriteLine($"{n} can't fit in any type");
                return;
            }
            Console.WriteLine($"{n} can fit in:");
            if (n >= sbyte.MinValue && n <= sbyte.MaxValue)
            {
                Console.WriteLine("* sbyte");
            }
            if (n >= byte.MinValue && n <= byte.MaxValue)
            {
                Console.WriteLine("* byte");
            }
            if (n >= short.MinValue && n <= short.MaxValue)
            {
                Console.WriteLine("* short");
            }
            if (n >= int.MinValue && n <= int.MaxValue)
            {
                Console.WriteLine("* int");
            }
            if (n >= uint.MinValue && n <= uint.MaxValue)
            {
                Console.WriteLine("* uint");
            }
            if (n >= long.MinValue && n <= long.MaxValue)
            {
                Console.WriteLine("* long");
            }
        }
    }
}
namespace Sieve_Of_Eratosthenes
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
            var n = int.Parse(Console.ReadLine());
            var primes = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                primes[i] = true;
            }
            for (int i = 2; i <= n; i++)
            {
                if (primes[i])
                {
                    Console.Write(i + " ");
                    for (int j = i; j <= n; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}

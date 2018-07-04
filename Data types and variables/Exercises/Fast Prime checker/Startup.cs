namespace Fast_Prime_checker
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
            int numToCheck = int.Parse(Console.ReadLine());
            for (int i = 2; i <= numToCheck; i++)
            {
                bool isPrime = true;
                for (int delio = 2; delio <= Math.Sqrt(i); delio++)
                {
                    if (i % delio == 0)
                    {
                        isPrime = false;
                        break;
                    }


                }
                Console.WriteLine($"{i} -> {isPrime}");
            }

        }
    }
}

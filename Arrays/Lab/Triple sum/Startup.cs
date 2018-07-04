namespace Triple_sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var generated = new HashSet<string>();
            var sums = new List<int>();
            var foundSum = false;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    for (int k = 0; k < arr.Length; k++)
                    {
                        if (k == j)
                        {
                            continue;

                        }
                        if (arr[i] + arr[j] == arr[k])
                        {
                            foundSum = true;
                            Console.WriteLine("{0} + {1} = {2}", arr[i], arr[j], arr[k]);
                        }
                    }
                }
            }

            if (!foundSum)
            {
                Console.WriteLine("No");
            }
        }
    }
}
namespace Fold_and_sum
{
    using System;
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
            var k = arr.Length / 4;

            var first = arr.Take(k).Reverse().ToList();
            first.AddRange(arr.Reverse().Take(k));

            for (int i = k, j = 0; i < arr.Length - k; i++, j++)
            {
                Console.Write(first[j] + arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
namespace Fold_And_Sum
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
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = nums.Length / 4;

            var a = nums.Take(k).Reverse().ToList();
            var b = nums.Skip(nums.Length - k).Take(k).Reverse().ToList();

            a.AddRange(b);

            for (int i = k, j = 0; i < nums.Length - k; i++, j++)
            {
                Console.Write(a[j] + nums[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
namespace Rotate_and_sum
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
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, nums.Length];

            for (int i = 0; i < n; i++)
            {
                var last = nums[nums.Length - 1];
                for (int j = nums.Length - 1; j > 0; j--)
                {
                    nums[j] = nums[j - 1];
                    matrix[i, j] = nums[j];
                }

                nums[0] = last;
                matrix[i, 0] = last;
            }

            for (int col = 0; col < nums.Length; col++)
            {
                var sum = 0;
                for (int row = 0; row < n; row++)
                {
                    sum += matrix[row, col];
                }
                Console.Write(sum + " ");
            }
            Console.WriteLine();
        }
    }
}

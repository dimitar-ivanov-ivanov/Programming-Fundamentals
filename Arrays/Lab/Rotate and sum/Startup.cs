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
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = int.Parse(Console.ReadLine());
            var jagged = new int[k, arr.Length - 1];

            for (int i = 0; i < k; i++)
            {
                var last = arr[arr.Length - 1];
                for (int j = arr.Length - 1; j >= 0; j--)
                {
                    arr[j] = arr[j - 1];
                    jagged[i, j] = arr[j - 1];
                }
                arr[0] = last;
                jagged[i, 0] = last;
            }
        }
    }
}
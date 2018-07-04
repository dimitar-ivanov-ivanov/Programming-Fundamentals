namespace Arrays_sum
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Execute();
        }

        private static void Execute()
        {
            var arr1 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var arr2 = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var max = Math.Max(arr1.Length, arr2.Length);
            for (int i = 0, j = 0, k = 0; i < max; i++)
            {
                Console.Write(arr1[j] + arr2[k] + " ");
                j = (j + 1) % arr1.Length;
                k = (k + 1) % arr2.Length;
            }

            Console.WriteLine();
        }
    }
}

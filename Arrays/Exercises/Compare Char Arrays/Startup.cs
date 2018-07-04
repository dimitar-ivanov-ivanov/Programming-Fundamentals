namespace Char_Array_Comparison
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
            var l = 0;
            var r = nums.Sum();

            for (int i = 0; i < nums.Length; i++)
            {
                var cr = r - nums[i];
                if (l == cr)
                {
                    Console.WriteLine(i);
                    return;
                }
                l += nums[i];
                r -= nums[i];
            }

            Console.WriteLine("no");
        }
    }
}
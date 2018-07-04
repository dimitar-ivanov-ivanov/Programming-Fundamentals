namespace Most_Frequent_Number
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
            var nums = new Dictionary<int, int>();
            var res = 0;
            var numRes = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (!nums.ContainsKey(arr[i]))
                {
                    nums.Add(arr[i], 0);
                }
                nums[arr[i]]++;
            }

            foreach (var num in nums)
            {
                if (res < num.Value)
                {
                    res = num.Value;
                    numRes = num.Key;
                }
            }
            Console.WriteLine(numRes);
        }
    }
}
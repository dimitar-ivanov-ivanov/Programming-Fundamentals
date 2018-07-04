namespace Numbers
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
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var avg = arr.Average();
            Array.Sort(arr);

            var res = new List<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] > avg)
                {
                    res.Add(arr[i]);
                }

                if (res.Count == 5 || arr[i] <= avg)
                {
                    break;
                }
            }
            if (res.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", res));
            }
        }
    }
}

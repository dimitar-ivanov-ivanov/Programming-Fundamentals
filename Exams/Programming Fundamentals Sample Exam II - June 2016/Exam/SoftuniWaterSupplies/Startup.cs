namespace SoftuniWaterSupplies
{
    using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var water = decimal.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            var capacity = decimal.Parse(Console.ReadLine());
            var val = water % 2 == 0 ? 1 : -1;
            var start = water % 2 == 0 ? 0 : arr.Length - 1;

            for (int i = start; i < arr.Length && i >= 0; i += val)
            {
                if (arr[i] != capacity)
                {
                    if (water - (capacity - arr[i]) >= 0)
                    {
                        water -= (capacity - arr[i]);
                    }
                    else
                    {
                        var res = new List<int>();
                        Console.WriteLine("We need more water!");
                        decimal liters = 0;
                        for (int j = i; j >= 0 && j < arr.Length; j += val)
                        {
                            res.Add(j);
                            liters += capacity - arr[j];
                        }

                        liters -= water;

                        Console.WriteLine("Bottles left: {0}", res.Count);
                        Console.WriteLine("With indexes: {0}", string.Join(", ", res));
                        Console.WriteLine("We need {0} more liters!", liters);
                        return;
                    }
                }
            }

            Console.WriteLine("Enough water!");
            Console.WriteLine("Water left: {0}l.", water);
        }
    }
}
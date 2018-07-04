namespace NSA
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
            var args = Console.ReadLine().Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            var dict = new Dictionary<string, Dictionary<string, int>>();

            while (args[0] != "quit")
            {
                var country = args[0].Trim();
                var spy = args[1].Trim();
                var daysInService = int.Parse(args[2].Trim());
                if (!dict.ContainsKey(country))
                {
                    dict.Add(country, new Dictionary<string, int>());
                }
                if (!dict[country].ContainsKey(spy))
                {
                    dict[country].Add(spy, 0);
                }
                dict[country][spy] = daysInService;
                args = Console.ReadLine().Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            }

            dict = dict.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in dict)
            {
                var sorted = dict[country.Key].OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine("Country: {0}", country.Key);

                foreach (var spy in sorted)
                {
                    Console.WriteLine("**{0} : {1}", spy.Key, spy.Value);
                }
            }
        }
    }
}
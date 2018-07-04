using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PopulationAggreagation
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var countries = new Dictionary<string, List<string>>();
            var cities = new Dictionary<string, long>();
            var args = Console.ReadLine().Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex(@"[@$&#\d]+");

            while (args[0] != "stop")
            {
                var city = string.Join("", regex.Split(args[0]));
                var country = string.Join("", regex.Split(args[1]));
                var population = long.Parse(args[2]);

                if (city[0] >= 'A' && city[0] <= 'Z')
                {
                    var temp = city.ToString();
                    city = country.ToString();
                    country = temp;
                }

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new List<string>());
                }

                countries[country].Add(city);
                cities[city] = population;
                args = Console.ReadLine().Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            }

            countries = countries.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            cities = cities.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in countries)
            {
                Console.WriteLine("{0} -> {1}", country.Key, country.Value.Count);
            }

            var count = 0;
            foreach (var city in cities)
            {
                if (count == 3) break;
                Console.WriteLine("{0} -> {1}", city.Key, city.Value);
                count++;
            }
        }
    }
}
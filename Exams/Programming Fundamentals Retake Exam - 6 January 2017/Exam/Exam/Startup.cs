namespace SoftuniKareoke
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
            var people = new HashSet<string>(Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()));
            var songs = new HashSet<string>(Console.ReadLine().Split(new[] { ',' }).Select(x => x.Trim()));
            var dict = new Dictionary<string, SortedSet<string>>();

            var args = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var awardsCount = 0;

            while (args[0] != "dawn")
            {
                var name = args[0].Trim();
                var song = args[1].Trim();
                var award = args[2].Trim();

                if (people.Contains(name) && songs.Contains(song))
                {
                    if (!dict.ContainsKey(name))
                    {
                        dict.Add(name, new SortedSet<string>());
                    }
                    if (!dict[name].Contains(award))
                    {
                        awardsCount++;
                    }

                    dict[name].Add(award);
                }

                args = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (awardsCount == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            dict = dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var name in dict)
            {
                Console.WriteLine("{0}: {1} awards", name.Key, name.Value.Count);
                foreach (var award in name.Value)
                {
                    Console.WriteLine("--{0}", award);
                }
            }
        }
    }
}
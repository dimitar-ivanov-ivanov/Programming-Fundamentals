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
            var p = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var s = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < p.Length; i++)
            {
                p[i] = p[i].Trim();
            }

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = s[i].Trim();
            }

            var players = new HashSet<string>(p);
            var songs = new HashSet<string>(s);
            var dict = new Dictionary<string, SortedSet<string>>();

            var args = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "dawn")
            {
                var name = args[0].Trim();
                var song = args[1].Trim();
                var award = args[2].Trim();
                if (!songs.Contains(song) || !players.Contains(name))
                {
                    args = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new SortedSet<string>());
                }
                dict[name].Add(award);
                args = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (dict.Count == 0)
            {
                Console.WriteLine("No awards");
                return;
            }

            dict = dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var pair in dict)
            {
                Console.WriteLine("{0}: {1} awards", pair.Key, pair.Value.Count);
                foreach (var award in pair.Value)
                {
                    Console.WriteLine("--{0}", award);
                }
            }
        }
    }
}
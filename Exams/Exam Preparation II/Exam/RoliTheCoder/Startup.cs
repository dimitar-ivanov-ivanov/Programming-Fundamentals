namespace RoliTheCoder
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
            var byName = new Dictionary<long, KeyValuePair<string, SortedSet<string>>>();
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!string.Join(" ", args).Equals("Time for Code"))
            {
                var id = long.Parse(args[0]);
                var name = args[1];
                if (name[0] == '#')
                {
                    name = name.Remove(0, 1);
                    if (!byName.ContainsKey(id))
                    {
                        byName.Add(id, new KeyValuePair<string, SortedSet<string>>(name, new SortedSet<string>(args.Skip(2))));
                    }
                    else if (byName[id].Key == name)
                    {
                        byName[id].Value.UnionWith(args.Skip(2));
                    }

                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            byName = byName.OrderByDescending(x => x.Value.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in byName)
            {
                Console.WriteLine("{0} - {1}", item.Value.Key, item.Value.Value.Count);
                Console.WriteLine(string.Join("\n", item.Value.Value));
            }
        }
    }
}
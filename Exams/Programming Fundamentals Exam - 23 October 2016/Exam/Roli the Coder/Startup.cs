namespace Roli_the_Coder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var regex = new Regex(@"\d+ #\w+(( @\w+)+)?");
            var line = Console.ReadLine();

            var dict = new Dictionary<int, KeyValuePair<string, SortedSet<string>>>();

            while (line != "Time for Code")
            {
                if (regex.IsMatch(line))
                {
                    var args = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var id = int.Parse(args[0]);
                    var eventName = args[1].Remove(0, 1);
                    if (dict.ContainsKey(id) && dict[id].Key != eventName)
                    {
                        line = Console.ReadLine();
                        continue;
                    }

                    if (!dict.ContainsKey(id))
                    {
                        dict.Add(id, new KeyValuePair<string, SortedSet<string>>(eventName, new SortedSet<string>()));
                    }

                    for (int i = 2; i < args.Length; i++)
                    {
                        dict[id].Value.Add(args[i]);
                    }

                }
                line = Console.ReadLine();
            }

            dict = dict.OrderByDescending(x => x.Value.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var eventName in dict)
            {
                Console.WriteLine("{0} - {1}", eventName.Value.Key, eventName.Value.Value.Count);
                foreach (var name in eventName.Value.Value)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}

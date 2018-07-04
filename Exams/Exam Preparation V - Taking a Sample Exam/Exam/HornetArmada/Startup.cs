namespace HornetArmada
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
            var byActivity = new Dictionary<string, int>();
            var bySoldiers = new Dictionary<string, Dictionary<string, long>>();
            var n = int.Parse(Console.ReadLine());
            var delimeters = " ->:=".ToArray();
            string[] args;

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                var lastActivity = int.Parse(args[0]);
                var legionName = args[1];
                var soldierType = args[2];
                var soldierCount = int.Parse(args[3]);

                if (!byActivity.ContainsKey(legionName))
                {
                    byActivity.Add(legionName, 0);
                    bySoldiers.Add(legionName, new Dictionary<string, long>());
                }

                byActivity[legionName] = Math.Max(byActivity[legionName], lastActivity);

                if (!bySoldiers[legionName].ContainsKey(soldierType))
                {
                    bySoldiers[legionName].Add(soldierType, 0);
                }

                bySoldiers[legionName][soldierType] += soldierCount;
            }

            var output = Console.ReadLine();
            if (output.Contains('\\'))
            {
                args = output.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                ActivitySoldierType(int.Parse(args[0]), args[1], byActivity, bySoldiers);
            }
            else
            {
                SoldierType(output, byActivity, bySoldiers);
            }
        }

        private static void ActivitySoldierType(int activty, string soldierType, Dictionary<string, int> byActivity, Dictionary<string, Dictionary<string, long>> bySoldiers)
        {
            var list = new List<KeyValuePair<string, long>>();
            foreach (var legion in byActivity)
            {
                if (legion.Value < activty && bySoldiers[legion.Key].ContainsKey(soldierType))
                {
                    list.Add(new KeyValuePair<string, long>(legion.Key, bySoldiers[legion.Key][soldierType]));
                    // Console.WriteLine("{0} -> {1}", legion.Key, bySoldiers[legion.Key][soldierType]);
                }
            }

            list = list.OrderByDescending(x => x.Value).ToList();
            foreach (var legion in list)
            {
                Console.WriteLine("{0} -> {1}", legion.Key, legion.Value);
            }
        }

        private static void SoldierType(string soldierType, Dictionary<string, int> byActivity, Dictionary<string, Dictionary<string, long>> bySoldiers)
        {
            byActivity = byActivity.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var legion in byActivity)
            {
                if (bySoldiers[legion.Key].ContainsKey(soldierType))
                {
                    Console.WriteLine("{0} : {1}", byActivity[legion.Key], legion.Key);
                }
            }
        }
    }
}

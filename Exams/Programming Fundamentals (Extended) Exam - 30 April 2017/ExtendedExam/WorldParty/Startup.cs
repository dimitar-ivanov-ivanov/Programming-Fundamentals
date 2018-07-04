namespace WorldParty
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
            var byWorms = new Dictionary<string, Worms>();
            var worms = new HashSet<string>();

            var args = Console.ReadLine().Split(new[] { '>', '-' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "quit")
            {
                var wormName = args[0].Trim();
                var teamName = args[1].Trim();
                var val = int.Parse(args[2]);

                if (worms.Contains(wormName))
                {
                    args = Console.ReadLine().Split(new[] { '>', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                worms.Add(wormName);
                if (!byWorms.ContainsKey(teamName))
                {
                    byWorms.Add(teamName, new Worms());
                }

                byWorms[teamName].list.Add(new KeyValuePair<string, int>(wormName, val));
                byWorms[teamName].sum += val;
                byWorms[teamName].avg = byWorms[teamName].sum / byWorms[teamName].list.Count;
                args = Console.ReadLine().Split(new[] { '>', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var count = 0;

            foreach (var party in byWorms)
            {
                var list = party.Value.list;
                list = list.OrderByDescending(x => x.Value).ToList();
                Console.WriteLine("{0}. Team: {1} - {2}", ++count, party.Key, party.Value.sum);

                foreach (var worm in list)
                {
                    Console.WriteLine("###{0} : {1}", worm.Key, worm.Value);
                }
            }
        }
    }

    public class Worms : IComparable<Worms>
    {
        public List<KeyValuePair<string, int>> list { get; set; }
        public long sum { get; set; }
        public double avg { get; set; }
        public Worms()
        {
            list = new List<KeyValuePair<string, int>>();
            sum = 0;
            avg = 0;
        }

        public int CompareTo(Worms other)
        {
            var bySum = other.sum.CompareTo(this.sum);
            var byAvg = other.avg.CompareTo(this.avg);
            if (bySum != -1)
            {
                return bySum;
            }
            return byAvg;
        }
    }
}
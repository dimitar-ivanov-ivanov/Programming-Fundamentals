namespace FootballLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static string firstName;
        static string secondName;

        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var key = Console.ReadLine();
            var line = Console.ReadLine();
            var league = new Dictionary<string, int>();
            var goals = new Dictionary<string, int>();
            string[] args;

            while (line != "final")
            {
                GetNames(key, line);
                args = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var last = args[args.Length - 1].Split(':');
                var firstScore = int.Parse(last[0]);
                var secondScore = int.Parse(last[1]);

                if (!league.ContainsKey(firstName))
                {
                    league.Add(firstName, 0);
                    goals.Add(firstName, 0);
                }
                if (!league.ContainsKey(secondName))
                {
                    league.Add(secondName, 0);
                    goals.Add(secondName, 0);
                }

                if (firstScore > secondScore)
                {
                    league[firstName] += 3;
                }
                else if (secondScore > firstScore)
                {
                    league[secondName] += 3;
                }
                else
                {
                    league[firstName]++;
                    league[secondName]++;
                }

                goals[firstName] += firstScore;
                goals[secondName] += secondScore;
                line = Console.ReadLine();
            }

            var count = 0;
            league = league.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            goals = goals.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("League standings:");
            foreach (var team in league)
            {
                Console.WriteLine("{0}. {1} {2}", ++count, team.Key, team.Value);
            }

            count = 0;
            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in goals)
            {
                if (count == 3) break;
                Console.WriteLine("- {0} -> {1}", team.Key, team.Value);
                count++;
            }
        }

        private static void GetNames(string key, string str)
        {
            var first = str.IndexOf(key);
            var second = str.IndexOf(key, first + key.Length);
            firstName = string.Join("", str.Substring(first + key.Length, second - first - key.Length).Reverse().ToArray());

            first = str.IndexOf(key, second + key.Length);
            second = str.IndexOf(key, first + key.Length);
            secondName = string.Join("", str.Substring(first + key.Length, second - first - key.Length).Reverse().ToArray());

            firstName = firstName.ToUpper();
            secondName = secondName.ToUpper();
        }
    }
}
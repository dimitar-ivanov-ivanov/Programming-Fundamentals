using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var key = Console.ReadLine();
            var args = Console.ReadLine().Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var goals = new Dictionary<string, long>();
            var score = new Dictionary<string, long>();

            while (args[0] != "final")
            {
                var first = args[0];
                var second = args[1];
                ConvertString(key, ref first, ref second);

                var firstTeamScore = int.Parse(args[2]);
                var secondTeamScore = int.Parse(args[3]);

                if (!goals.ContainsKey(first))
                {
                    goals.Add(first, 0);
                    score.Add(first, 0);
                }

                if (!goals.ContainsKey(second))
                {
                    goals.Add(second, 0);
                    score.Add(second, 0);
                }

                goals[first] += firstTeamScore;
                goals[second] += secondTeamScore;

                if (firstTeamScore > secondTeamScore)
                {
                    score[first] += 3;
                }
                else if (firstTeamScore < secondTeamScore)
                {
                    score[second] += 3;
                }
                else
                {
                    score[second]++;
                    score[first]++;
                }

                args = Console.ReadLine().Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            score = score.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            goals = goals.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("League standings:");
            var count = 0;

            foreach (var team in score)
            {
                Console.WriteLine("{0}. {1} {2}", ++count, team.Key, team.Value);
            }

            count = 0;
            Console.WriteLine("Top 3 scored goals:");

            foreach (var team in goals)
            {
                if (count == 3)
                {
                    break;
                }
                Console.WriteLine("- {0} -> {1}", team.Key, team.Value);
                ++count;
            }
        }

        public static void ConvertString(string key, ref string first, ref string second)
        {
            var a = first.IndexOf(key);
            var b = first.LastIndexOf(key);

            first = first.Substring(a + key.Length, b - a - key.Length).ToUpper();
            first = new string(first.Reverse().ToArray());

            a = second.IndexOf(key);
            b = second.LastIndexOf(key);

            second = second.Substring(a + key.Length, b - a - key.Length).ToUpper();
            second = new string(second.Reverse().ToArray());
        }
    }
}

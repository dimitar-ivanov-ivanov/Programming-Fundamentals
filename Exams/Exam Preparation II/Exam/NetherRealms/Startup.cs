namespace NetherRealms
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var healthBans = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '.' };
            var dict = new List<Tuple<string, double, double>>();

            var demons = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex(@"[-+]?[0-9]*\.?[0-9]+");

            for (int i = 0; i < demons.Length; i++)
            {
                double health = 0;
                for (int j = 0; j < demons[i].Length; j++)
                {
                    if (!healthBans.Contains(demons[i][j]))
                    {
                        health += demons[i][j];
                    }
                }

                var matches = regex.Matches(demons[i]);
                double sum = 0;
                foreach (Match match in matches)
                {
                    var val = match.Value;
                    sum += double.Parse(val);
                }

                var multipliers = demons[i].Where(x => x == '/' || x == '*').ToArray();
                for (int j = 0; j < multipliers.Length; j++)
                {
                    if (multipliers[j] == '*') sum *= 2;
                    else sum /= 2;
                }

                dict.Add(new Tuple<string, double, double>(demons[i], health, sum));
            }

            dict = dict.OrderBy(x => x.Item1).ToList();
            for (int i = 0; i < dict.Count; i++)
            {
                Console.WriteLine("{0} - {1} health, {2:F2} damage ", dict[i].Item1, dict[i].Item2, dict[i].Item3);
            }
        }
    }
}

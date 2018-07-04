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
            var healthRgx = new Regex(@"[^\d+*\/\.-]");
            var damageRgx = new Regex(@"((-|\+)?)[0-9]+([.,][0-9]+)?");
            var args = Console.ReadLine().Split(new[] { ' ', ',', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            var res = new SortedDictionary<string, KeyValuePair<decimal, decimal>>();
            for (int i = 0; i < args.Length; i++)
            {
                var healthMatches = healthRgx.Matches(args[i]);
                decimal health = 0;
                foreach (Match match in healthMatches)
                {
                    health += match.Value[0];
                }

                var damageMatches = damageRgx.Matches(args[i]);
                decimal damage = 0;
                foreach (Match match in damageMatches)
                {
                    damage += decimal.Parse(match.Value);
                }

                var delimeters = args[i].Where(x => x == '*' || x == '/').ToArray();
                for (int j = 0; j < delimeters.Length; j++)
                {
                    if (delimeters[j] == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                res.Add(args[i], new KeyValuePair<decimal, decimal>(health, damage));
            }

            foreach (var item in res)
            {
                Console.WriteLine("{0} - {1} health, {2:F2} damage", item.Key, item.Value.Key, item.Value.Value);
            }
        }
    }
}
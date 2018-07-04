namespace SpyGem
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
            var regex = new Regex(@"TO: (?<recepient>[A-Z]+); MESSAGE:(?<message>.*);");
            var key = Console.ReadLine();
            var line = Console.ReadLine();

            var res = new Dictionary<string, List<string>>();
            while (line != "END")
            {
                if (regex.IsMatch(line))
                {
                    var matches = regex.Matches(line);
                    var recepient = matches[0].Groups["recepient"].Value;
                    var message = matches[0].Groups[0].Value.ToCharArray();

                    if (!res.ContainsKey(recepient))
                    {
                        res.Add(recepient, new List<string>());
                    }

                    var index = 0;
                    for (int i = 0; i < message.Length; i++)
                    {
                        message[i] += (char)(key[index] - '0');
                        index = (index + 1) % key.Length;
                    }

                    res[recepient].Add(new string(message));
                }
                line = Console.ReadLine();
            }

            res = res.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var person in res)
            {
                foreach (var message in person.Value)
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}

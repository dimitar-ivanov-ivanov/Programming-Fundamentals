namespace HornetComm
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
            Execute();
            var privateM = new Regex(@"^((?<first>\d+) <-> (?<second>\w+))$");
            var broadcast = new Regex(@"^((?<first>\D+) <-> (?<second>\w+))$");
            var privateList = new List<string>();
            var broadcastList = new List<string>();

            var line = Console.ReadLine();
            MatchCollection matches = null;

            while (line != "Hornet is Green")
            {
                if (privateM.IsMatch(line))
                {
                    matches = privateM.Matches(line);
                    var first = matches[0].Groups["first"].Value;
                    var second = matches[0].Groups["second"].Value;
                    first = new string(first.Reverse().ToArray());
                    privateList.Add(string.Format("{0} -> {1}", first, second));

                }
                else if (broadcast.IsMatch(line))
                {
                    matches = broadcast.Matches(line);
                    var first = matches[0].Groups["first"].Value;
                    var second = matches[0].Groups["second"].Value.ToCharArray();
                    for (int i = 0; i < second.Length; i++)
                    {
                        if (second[i] >= 'A' && second[i] <= 'Z')
                        {
                            second[i] = second[i].ToString().ToLower()[0];
                        }
                        else if (second[i] >= 'a' && second[i] <= 'z')
                        {
                            second[i] = second[i].ToString().ToUpper()[0];
                        }
                    }


                    broadcastList.Add(string.Format("{0} -> {1}", new string(second), first));

                }
                line = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            if (broadcastList.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(string.Join("\n", broadcastList));
            }

            Console.WriteLine("Messages:");
            if (privateList.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine(string.Join("\n", privateList));
            }
        }
    }
}
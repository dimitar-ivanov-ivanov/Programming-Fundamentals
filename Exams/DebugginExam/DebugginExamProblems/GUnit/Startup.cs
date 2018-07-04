namespace GUnit
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
            var line = Console.ReadLine();
            var regex = new Regex(@"(?<class>[A-Z][a-zA-Z0-9]{1,}) \| (?<method>[A-Z][a-zA-Z0-9]{1,}) \| (?<unitTest>[A-Z][a-zA-Z0-9]{1,})");
            var main = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            var classAndTests = new Dictionary<string, HashSet<string>>();

            while (line != "It's testing time!")
            {
                if (regex.IsMatch(line))
                {
                    var match = regex.Match(line);
                    var className = match.Groups["class"].Value;
                    var methodName = match.Groups["method"].Value;
                    var unitTestName = match.Groups["unitTest"].Value;

                    if (!main.ContainsKey(className))
                    {
                        main.Add(className, new Dictionary<string, HashSet<string>>());
                        classAndTests.Add(className, new HashSet<string>());
                    }

                    if (!main[className].ContainsKey(methodName))
                    {
                        main[className].Add(methodName, new HashSet<string>());
                    }

                    main[className][methodName].Add(unitTestName);
                    classAndTests[className].Add(unitTestName);

                }
                line = Console.ReadLine();
            }

            main = main.OrderByDescending(x => classAndTests[x.Key].Count)
                .ThenBy(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var className in main)
            {
                Console.WriteLine("{0}:", className.Key);
                var methods = className.Value;
                var sortedMethods = methods.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var method in sortedMethods)
                {
                    Console.WriteLine("##{0}", method.Key);
                    var tests = method.Value;
                    var sortedTest = new HashSet<string>(tests.OrderBy(x => x.Length).ThenBy(x => x));
                    foreach (var test in sortedTest)
                    {
                        Console.WriteLine("####{0}", test);
                    }
                }
            }
        }
    }
}
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CubicMessages
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var regex = new Regex(@"^(?<first>\d+)(?<key>[a-zA-Z]+)(?<second>[^A-Za-z]*)$");
            var line = Console.ReadLine();
            var num = int.Parse(Console.ReadLine());

            while (line != "Over!")
            {
                if (regex.IsMatch(line))
                {
                    var match = regex.Match(line);
                    var key = match.Groups["key"].Value;

                    if (key.Length == num)
                    {
                        var first = match.Groups["first"].Value;
                        var second = match.Groups["second"].Value;

                        var digits = first.Where(x => char.IsDigit(x)).Select(x => x - '0').ToList();

                        digits.AddRange(second.Where(x => char.IsDigit(x)).Select(x => x - '0').ToList());
                        var res = new StringBuilder();

                        for (int i = 0; i < digits.Count; i++)
                        {
                            if (digits[i] >= 0 && digits[i] < key.Length)
                            {
                                res.Append(key[digits[i]]);
                            }
                            else
                            {
                                res.Append(' ');
                            }
                        }

                        Console.WriteLine("{0} == {1}", key, res);
                    }
                }

                line = Console.ReadLine();
                if (line == "Over!")
                {
                    break;
                }
                num = int.Parse(Console.ReadLine());
            }
        }
    }
}

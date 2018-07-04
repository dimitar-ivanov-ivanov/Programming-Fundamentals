namespace CubicMessages
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var regex = new Regex(@"^(?<first>\d*)(?<key>[A-Za-z]*)(?<second>[^A-Za-z]*)$");
            var line = Console.ReadLine();
            var num = int.Parse(Console.ReadLine());

            while (line != "Over!")
            {
                if (regex.IsMatch(line))
                {
                    var match = regex.Match(line);
                    var key = match.Groups["key"].Value;
                    var first = match.Groups["first"].Value;
                    var second = match.Groups["second"].Value;

                    if (key.Length == num)
                    {
                        var nums = first.Where(x => char.IsDigit(x)).Select(x => x - '0').ToList();
                        nums.AddRange(second.Where(x => char.IsDigit(x)).Select(x => x - '0').ToList());

                        var res = new StringBuilder();
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (nums[i] >= 0 && nums[i] < key.Length)
                            {
                                res.Append(key[nums[i]]);
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
                if (line != "Over!")
                {
                    num = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
        }
    }
}
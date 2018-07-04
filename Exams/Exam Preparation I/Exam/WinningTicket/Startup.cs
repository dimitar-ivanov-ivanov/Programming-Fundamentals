namespace WinningTicket
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        static int first, second;
        static char outputChar;

        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var arr = Console.ReadLine()
                                 .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Trim();
                if (arr[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    first = VerifyString(arr[i], arr[i].Substring(0, arr[i].Length / 2));
                    second = SecondVerification(arr[i], arr[i].Substring(arr[i].Length / 2, arr[i].Length / 2));

                    if (first != -1 && second != -1)
                    {
                        var max = Math.Max(first, second);
                        if (max == 10)
                        {
                            Console.WriteLine("ticket \"{0}\" - {1}{2} Jackpot!", arr[i], max, outputChar);
                        }
                        else
                        {
                            Console.WriteLine("ticket \"{0}\" - {1}{2}", arr[i], max, outputChar);
                        }
                    }
                    else
                    {
                        Console.WriteLine("ticket \"{0}\" - no match", arr[i]);
                    }
                }
            }
        }

        private static int VerifyString(string original, string str)
        {
            var regex = new Regex("[$@#^]+");
            var matches = regex.Matches(str);

            foreach (Match match in matches)
            {
                var val = match.Value;
                var builder = new StringBuilder();

                for (int k = 10; k >= 6; k--)
                {
                    builder = new StringBuilder();
                    for (int i = 0; i < val.Length; i++)
                    {
                        builder.Append(val[i]);

                        if (builder.Length == k)
                        {
                            if (builder.ToString().Distinct().Count() == 1)
                            {
                                // Console.WriteLine("ticket \"{0}\" - {1}{2}", original, k, builder[0]);
                                outputChar = builder[0];
                                return k;
                            }
                            builder = builder.Remove(0, 1);
                        }
                    }
                }
            }

            return -1;
        }

        private static int SecondVerification(string original, string str)
        {
            var regex = new Regex("[$@#^]+");
            var matches = regex.Matches(str);

            foreach (Match match in matches)
            {
                var val = match.Value;
                var builder = new StringBuilder();

                for (int k = 10; k >= 6; k--)
                {
                    builder = new StringBuilder();
                    for (int i = 0; i < val.Length; i++)
                    {
                        builder.Append(val[i]);

                        if (builder.Length == k)
                        {
                            if (builder.ToString().Distinct().Count() == 1 && builder[0] == outputChar)
                            {
                                outputChar = builder[0];
                                return k;
                            }
                            builder = builder.Remove(0, 1);
                        }
                    }
                }
            }
            return -1;
        }
    }
}
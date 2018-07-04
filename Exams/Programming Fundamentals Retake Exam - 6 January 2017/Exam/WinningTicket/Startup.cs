namespace WinningTicket
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var arr = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var regex = new Regex(@"[@#$^]{6,10}");

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                var first = arr[i].Substring(0, 10);
                var second = arr[i].Substring(10, 10);

                if (regex.IsMatch(first) && regex.IsMatch(second))
                {
                    var length = regex.Match(first).Value.Length;
                    var length2 = regex.Match(second).Value.Length;
                    var total = Math.Min(length, length2);

                    var symbol = regex.Match(first).Value[0];
                    var symbol1 = regex.Match(second).Value[0];
                    if (total != 10)
                    {
                        Console.WriteLine("ticket \"{0}\" - {1}{2}", arr[i], total, symbol);
                    }
                    else
                    {
                        Console.WriteLine("ticket \"{0}\" - 10{1} Jackpot!", arr[i], symbol);
                    }
                }
                else
                {
                    Console.WriteLine("ticket \"{0}\" - no match", arr[i]);
                }
            }
        }
    }
}

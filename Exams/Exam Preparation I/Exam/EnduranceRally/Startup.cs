namespace EnduranceRally
{
    using System;
    using System.Globalization;
    using System.Linq;
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
            var players = Console.ReadLine().Split(' ');
            var arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            var visited = new bool[arr.Length];
            var args = Console.ReadLine().Split(' ');

            for (int i = 0; i < args.Length; i++)
            {
                var a = int.Parse(args[i]);
                if (a >= 0 && a < visited.Length)
                {
                    visited[a] = true;
                }
            }

            for (int i = 0; i < players.Length; i++)
            {
                double fuel = (int)players[i][0];
                for (int j = 0; j < arr.Length; j++)
                {
                    fuel += visited[j] ? arr[j] : -arr[j];
                    if (fuel <= 0)
                    {
                        Console.WriteLine("{0} - reached {1}", players[i], j);
                        break;
                    }
                }

                if (fuel > 0)
                {
                    Console.WriteLine("{0} - fuel left {1:0.00}", players[i], fuel);
                }
            }
        }
    }
}
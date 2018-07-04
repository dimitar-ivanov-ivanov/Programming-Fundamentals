namespace Ladybugs
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var visited = new bool[n];

            for (int i = 0; i < args.Length; i++)
            {
                var index = int.Parse(args[i]);
                if (index >= 0 && index < n)
                {
                    visited[index] = true;
                }
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (args[0] != "end")
            {
                var index = long.Parse(args[0]);
                var command = args[1];
                var move = long.Parse(args[2]);

                if (index >= 0 && index < n && visited[index])
                {
                    if (command == "left")
                    {
                        move = -move;
                    }

                    visited[index] = false;
                    for (long i = index + move; i < n && i >= 0; i++)
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            break;
                        }
                    }
                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(visited[i] ? "1 " : "0 ");
            }
            Console.WriteLine();
        }
    }
}
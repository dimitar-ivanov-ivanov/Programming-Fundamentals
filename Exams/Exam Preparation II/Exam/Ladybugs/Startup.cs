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
            var visited = new bool[n];
            var args = Console.ReadLine().Split(' ');
            long i = 0;

            for (i = 0; i < args.Length; i++)
            {
                var a = long.Parse(args[i]);
                if (a >= 0 && a < n)
                {
                    visited[a] = true;
                }
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "end")
            {
                var index = long.Parse(args[0]);
                var distance = long.Parse(args[2]);
                var command = args[1];
                distance = command == "right" ? distance : -distance;

                if (index > 0 && index < n && visited[index])
                {
                    visited[index] = false;
                    for (i = index + distance; i >= 0 && i < n; i += distance)
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

            for (i = 0; i < visited.Length; i++)
            {
                Console.Write((visited[i] == true ? 1 : 0) + " ");
            }

            Console.WriteLine();
        }
    }
}
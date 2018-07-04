namespace TrifonsQuest
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
            var health = long.Parse(Console.ReadLine());
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            Move(n, m, matrix, health);
        }

        private static void Move(int n, int m, char[,] matrix, long health)
        {
            var row = 0;
            var col = 0;
            var turns = 0;
            var endCol = m - 1;
            var endRow = m % 2 == 0 ? 0 : n - 1;

            while (true)
            {
                if (matrix[row, col] == 'F')
                {
                    health -= turns / 2;
                }
                else if (matrix[row, col] == 'H')
                {
                    health += turns / 3;
                }
                else if (matrix[row, col] == 'T')
                {
                    turns += 2;
                }

                turns++;
                if (health <= 0)
                {
                    Console.WriteLine("Died at: [{0}, {1}]", row, col);
                    return;
                }

                var val = col % 2 == 0 ? 1 : -1;
                row += val;
                if (row == endRow + val && col == endCol)
                {
                    break;
                }

                if (row == -1 || row == n)
                {
                    col++;
                    if (col % 2 == 0)
                    {
                        row = 0;
                    }
                    else
                    {
                        row = n - 1;
                    }
                }
            }

            Console.WriteLine("Quest completed!");
            Console.WriteLine("Health: {0}", health);
            Console.WriteLine("Turns: {0}", turns);
        }
    }
}

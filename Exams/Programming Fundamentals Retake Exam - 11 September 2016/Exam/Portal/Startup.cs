namespace Portal
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new List<char>[n];
            var srow = 0;
            var scol = 0;

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                matrix[i] = new List<char>();
                for (int j = 0; j < line.Length; j++)
                {
                    matrix[i].Add(line[j]);
                    if (line[j] == 'S')
                    {
                        srow = i;
                        scol = j;
                    }
                }
            }

            var directions = Console.ReadLine();
            MoveRobot(matrix, srow, scol, n, directions);
        }

        private static void MoveRobot(List<char>[] matrix, int row, int col, int n, string directions)
        {
            if (matrix[row][col] == 'E')
            {
                Console.WriteLine("Experiment successful. {0} turns required.", 0);
                return;
            }
            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case 'R':
                        col++;
                        if (matrix[row].Count == 0)
                        {
                            Console.WriteLine("Robot stuck at {0} {1}. Experiment failed.", row, col);
                            return;
                        }
                        if (matrix[row].Count <= col)
                        {
                            col = 0;
                        }
                        break;
                    case 'L':
                        col--;
                        if (matrix[row].Count == 0)
                        {
                            Console.WriteLine("Robot stuck at {0} {1}. Experiment failed.", row, col);
                            return;
                        }
                        if (col < 0)
                        {
                            col = matrix[row].Count - 1;
                        }
                        break;
                    case 'D':
                        row++;
                        if (matrix.Length <= row)
                        {
                            row = 0;
                        }
                        var current = row;
                        while (matrix[current].Count <= col)
                        {
                            current++;
                            if (matrix.Length <= current)
                            {
                                current = 0;
                            }
                            if (current == row)
                            {
                                Console.WriteLine("Robot stuck at {0} {1}. Experiment failed.", row, col);
                                return;
                            }
                        }
                        row = current;
                        break;
                    case 'U':
                        row--;
                        if (row < 0)
                        {
                            row = matrix.Length - 1;
                        }
                        current = row;
                        if (matrix[current].Count <= col)
                        {
                            current--;
                            if (current < 0)
                            {
                                current = matrix.Length - 1;
                            }
                            if (current == row)
                            {
                                Console.WriteLine("Robot stuck at {0} {1}. Experiment failed.", row, col);
                                return;
                            }
                        }
                        row = current;
                        break;
                    default:
                        break;
                }

                if (matrix[row][col] == 'E')
                {
                    Console.WriteLine("Experiment successful. {0} turns required.", i + 1);
                    return;
                }
            }

            Console.WriteLine("Robot stuck at {0} {1}. Experiment failed.", row, col);
        }
    }
}
namespace BlurFilter
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
            var blur = long.Parse(Console.ReadLine());
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new long[n, m];

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = long.Parse(args[j]);
                }
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var startRow = int.Parse(args[0]) - 1;
            var startCol = int.Parse(args[1]) - 1;

            if (startRow < 0)
            {
                startRow = 0;
            }
            if (startCol < 0)
            {
                startCol = 0;
            }

            for (int i = startRow; i < startRow + 3 && i < n; i++)
            {
                for (int j = startCol; j < startCol + 3 && j < m; j++)
                {
                    matrix[i, j] += blur;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
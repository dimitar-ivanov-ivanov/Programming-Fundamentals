using System;

namespace TargetMultiplier
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(args[0]);
            var m = int.Parse(args[1]);
            var matrix = new long[n, m];

            for (int i = 0; i < n; i++)
            {
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(args[j]);
                }
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var cr = int.Parse(args[0]);
            var cc = int.Parse(args[1]);

            long sum = 0;
            for (int i = cr - 1; i <= cr + 1 && i >= 0 && i < n; i++)
            {
                for (int j = cc - 1; j <= cc + 1 && j >= 0 && j < m; j++)
                {
                    if (!(i == cr && j == cc))
                    {
                        sum += matrix[i, j];
                        matrix[i, j] *= matrix[cr, cc];
                    }
                }
            }

            matrix[cr, cc] *= sum;
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

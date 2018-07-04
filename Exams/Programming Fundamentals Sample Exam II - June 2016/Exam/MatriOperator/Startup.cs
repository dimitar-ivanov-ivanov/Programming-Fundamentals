namespace MatrixOperator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static List<int>[] matrix;

        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var n = int.Parse(Console.ReadLine());
            matrix = new List<int>[n];
            string[] args;

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new List<int>();
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < args.Length; j++)
                {
                    matrix[i].Add(int.Parse(args[j]));
                }
            }

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (args[0] != "end")
            {
                switch (args[0])
                {
                    case "insert":
                        var row = int.Parse(args[1]);
                        var element = int.Parse(args[2]);
                        matrix[row].Insert(0, element);
                        break;
                    case "swap":
                        var firstRow = int.Parse(args[1]);
                        var secondRow = int.Parse(args[2]);
                        Swap(firstRow, secondRow);
                        break;
                    case "remove":
                        var type = args[1];
                        switch (args[2])
                        {
                            case "row":
                                RemoveRow(type, int.Parse(args[3]));
                                break;
                            case "col":
                                RemoveCol(type, int.Parse(args[3]));
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void Swap(int firstRow, int secondRow)
        {
            var temp = matrix[firstRow].ToList();
            matrix[firstRow] = matrix[secondRow].ToList();
            matrix[secondRow] = temp;
        }

        private static void RemoveRow(string type, int row)
        {
            var removePositive = type == "positive";
            var removeNegative = type == "negative";
            var removeEven = type == "even";
            var removeOdd = type == "odd";

            for (int i = matrix[row].Count - 1; i >= 0; i--)
            {
                //!!!!!!!!!!!!
                if (removePositive && matrix[row][i] >= 0)
                {
                    matrix[row].RemoveAt(i);
                }
                if (removeNegative && matrix[row][i] < 0)
                {
                    matrix[row].RemoveAt(i);
                }
                if (removeEven && matrix[row][i] % 2 == 0)
                {
                    matrix[row].RemoveAt(i);
                }
                if (removeOdd && matrix[row][i] % 2 != 0)
                {
                    matrix[row].RemoveAt(i);
                }
            }
        }

        private static void RemoveCol(string type, int col)
        {
            var removePositive = type == "positive";
            var removeNegative = type == "negative";
            var removeEven = type == "even";
            var removeOdd = type == "odd";

            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row].Count > col)
                {
                    if (removePositive && matrix[row][col] >= 0)
                    {
                        matrix[row].RemoveAt(col);
                    }
                    if (removeNegative && matrix[row][col] < 0)
                    {
                        matrix[row].RemoveAt(col);
                    }
                    if (removeEven && matrix[row][col] % 2 == 0)
                    {
                        matrix[row].RemoveAt(col);
                    }
                    if (removeOdd && matrix[row][col] % 2 != 0)
                    {
                        matrix[row].RemoveAt(col);
                    }
                }
            }
        }
    }
}
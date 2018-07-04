namespace ArrayManipulator
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var arr = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var args = Console.ReadLine().Split(' ');
            var n = arr.Length;

            while (args[0] != "end")
            {
                var command = args[0];
                switch (command)
                {
                    case "exchange":
                        var index = int.Parse(args[1]);
                        if (index >= 0 && index < n)
                        {
                            var a = arr.Skip(index + 1).ToArray();
                            var b = arr.Take(index + 1).ToArray();
                            for (int i = 0; i < a.Length; i++)
                            {
                                arr[i] = a[i];
                            }
                            for (int i = 0, j = n - index - 1; i < b.Length; i++, j++)
                            {
                                arr[j] = b[i];
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "min":
                    case "max":
                        MaxMin(arr, args[0] == "max", args[1] == "even");
                        break;
                    case "first":
                        index = int.Parse(args[1]);
                        if (index >= 0 && index <= n)
                        {
                            var first = arr.Where(x => x % 2 == (args[2] == "even" ? 0 : 1)).ToArray();
                            if (index > first.Length)
                            {
                                index = first.Length;
                            }
                            first = first.Take(index).ToArray();
                            Console.WriteLine("[{0}]", string.Join(", ", first));
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }
                        break;
                    case "last":
                        index = int.Parse(args[1]);
                        if (index >= 0 && index <= n)
                        {
                            var last = arr.Reverse().Where(x => x % 2 == (args[2] == "even" ? 0 : 1)).ToArray();
                            if (index > last.Length)
                            {
                                index = last.Length;
                            }
                            last = last.Take(index).ToArray();
                            Console.WriteLine("[{0}]", string.Join(",", last));
                        }
                        else
                        {
                            Console.WriteLine("Invalid count");
                        }
                        break;
                    default:
                        break;
                }

                args = Console.ReadLine().Split(' ');
            }

            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }

        private static void MaxMin(int[] arr, bool takeMax, bool takeEven)
        {
            var minOdd = int.MaxValue;
            var minEven = int.MaxValue;
            var maxOdd = -1;
            var maxEven = -1;
            var minOddIndex = int.MaxValue;
            var minEvenIndex = int.MaxValue;
            var maxOddIndex = -1;
            var maxEvenIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] > maxEven)
                    {
                        maxEven = arr[i];
                        maxEvenIndex = i;
                    }
                    if (arr[i] < minEven)
                    {
                        minEven = arr[i];
                        minEvenIndex = i;
                    }
                }
                else
                {
                    if (arr[i] > maxOdd)
                    {
                        maxOdd = arr[i];
                        maxOddIndex = i;
                    }
                    if (arr[i] < minOdd)
                    {
                        minOdd = arr[i];
                        minOddIndex = i;
                    }
                }
            }

            if (takeEven)
            {
                if (takeMax)
                {
                    if (maxEvenIndex == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(maxEvenIndex);
                    }
                }
                else
                {
                    if (minEvenIndex == int.MaxValue)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(minEvenIndex);
                    }
                }
            }
            else
            {
                if (takeMax)
                {
                    if (maxOddIndex == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(maxOddIndex);
                    }
                }
                else
                {
                    if (minOddIndex == int.MaxValue)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(minOddIndex);
                    }
                }
            }
        }
    }
}
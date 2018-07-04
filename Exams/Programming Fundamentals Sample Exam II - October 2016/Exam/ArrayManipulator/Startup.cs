using System;
using System.Linq;

namespace ArrayManipulator
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = arr.Length;

            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "end")
            {
                switch (args[0])
                {
                    case "exchange":
                        var index = int.Parse(args[1]);
                        if (index >= 0 && index < n)
                        {
                            var first = arr.Take(index + 1).ToList();
                            var second = arr.Skip(index + 1).ToList();
                            second.AddRange(first);
                            arr = second.ToArray();
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "max":
                        TakeMax(arr, args[1]);
                        break;
                    case "min":
                        TakeMin(arr, args[1]);
                        break;
                    case "first":
                        TakeFirst(arr, args[2], int.Parse(args[1]));
                        break;
                    case "last":
                        TakeLast(arr, args[2], int.Parse(args[1]));
                        break;
                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }

        public static void TakeMax(int[] arr, string type)
        {
            var maxEven = long.MinValue;
            var maxOdd = long.MinValue;
            var maxEvenIndex = -1;
            var maxOddIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] >= maxEven)
                {
                    maxEven = arr[i];
                    maxEvenIndex = i;
                }
                else if (arr[i] % 2 != 0 && arr[i] >= maxOdd)
                {
                    maxOdd = arr[i];
                    maxOddIndex = i;
                }
            }

            if (type == "even")
            {
                Console.WriteLine(maxEvenIndex == -1 ? "No matches" : maxEvenIndex.ToString());
            }
            else
            {
                Console.WriteLine(maxOddIndex == -1 ? "No matches" : maxOddIndex.ToString());
            }
        }

        public static void TakeMin(int[] arr, string type)
        {
            var minEven = long.MaxValue;
            var minOdd = long.MaxValue;
            var minEvenIndex = -1;
            var minOddIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && arr[i] <= minEven)
                {
                    minEven = arr[i];
                    minEvenIndex = i;
                }
                else if (arr[i] % 2 != 0 && arr[i] <= minOdd)
                {
                    minOdd = arr[i];
                    minOddIndex = i;
                }
            }

            if (type == "even")
            {
                Console.WriteLine(minEvenIndex == -1 ? "No matches" : minEvenIndex.ToString());
            }
            else
            {
                Console.WriteLine(minOddIndex == -1 ? "No matches" : minOddIndex.ToString());
            }
        }

        public static void TakeFirst(int[] arr, string type, int count)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var reminder = type == "even" ? 0 : 1;
            var first = arr.Where(x => x % 2 == reminder).ToArray();
            if (first.Length > count)
            {
                first = first.Take(count).ToArray();
            }

            Console.WriteLine("[{0}]", string.Join(", ", first));
        }

        public static void TakeLast(int[] arr, string type, int count)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var reminder = type == "even" ? 0 : 1;
            var last = arr.Reverse().Where(x => x % 2 == reminder).Reverse().ToArray();

            if (last.Length > count)
            {
                last = last.Take(count).ToArray();
            }

            Console.WriteLine("[{0}]", string.Join(", ", last));
        }
    }
}
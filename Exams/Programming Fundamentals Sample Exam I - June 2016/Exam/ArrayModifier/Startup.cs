using System;
using System.Linq;

namespace ArrayModifier
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var arr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (args[0] != "end")
            {
                long a = 0;
                long b = 0;

                switch (args[0])
                {
                    case "swap":
                        a = int.Parse(args[1]);
                        b = int.Parse(args[2]);
                        var temp = arr[a];
                        arr[a] = arr[b];
                        arr[b] = temp;
                        break;

                    case "multiply":
                        a = int.Parse(args[1]);
                        b = int.Parse(args[2]);
                        arr[a] *= arr[b];
                        break;

                    case "decrease":
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i]--;
                        }
                        break;
                    default:
                        break;
                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(", ", arr));
        }
    }
}

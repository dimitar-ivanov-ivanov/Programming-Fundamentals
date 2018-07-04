namespace CommandInterpreter
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
            var arr = Console.ReadLine().Split(' ').ToArray();
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = arr.Length;
            long i = 0;
            long j = 0;

            while (args[0] != "end")
            {
                switch (args[0])
                {
                    case "reverse":
                        var a = long.Parse(args[2]);
                        var b = long.Parse(args[4]);
                        if (a >= 0 && a < n && b >= 0 && b < n && a + b < n)
                        {
                            var rev = arr.Skip((int)a).Take((int)b).Reverse().ToArray();
                            for (i = a, j = 0; i < a + b; i++, j++)
                            {
                                arr[i] = rev[j];
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;
                    case "sort":
                        a = int.Parse(args[2]);
                        b = int.Parse(args[4]);
                        if (a >= 0 && a < n && b >= 0 && b < n && a + b < n)
                        {
                            var sorted = arr.Skip((int)a).Take((int)b).ToArray();
                            Array.Sort(sorted);
                            for (i = a, j = 0; i < a + b; i++, j++)
                            {
                                arr[i] = sorted[j];
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;
                    case "rollLeft":
                        a = long.Parse(args[1]);
                        if (a >= 0)
                        {
                            a %= n;
                            for (int k = 0; k < a; k++)
                            {
                                var first = arr[0];
                                for (i = 0; i < n - 1; i++)
                                {
                                    arr[i] = arr[i + 1];
                                }
                                arr[n - 1] = first;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;
                    case "rollRight":
                        a = long.Parse(args[1]);
                        if (a >= 0)
                        {
                            a %= n;
                            for (int k = 0; k < a; k++)
                            {
                                var last = arr[n - 1];
                                for (i = n - 1; i > 0; i--)
                                {
                                    arr[i] = arr[i - 1];
                                }
                                arr[0] = last;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;
                    default:
                        break;
                }
                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("[{0}]", string.Join(", ", arr));
        }
    }
}